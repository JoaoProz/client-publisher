using RINPOSYS.CustomClasses.RFIDReads;
using System;
using System.Collections.Generic;

namespace RINPOSYS.CustomClasses.Algorithm
{
    /// <summary>
    /// Deals with the generation of Tags through the calculation of a Tag position, using it's respective TagRead's data.
    /// </summary>
    public static class MathematicalModel
    {
        /// <summary>
        /// Apply mathematical Model to each TagRead on TagReads list, generating a new list of Tags.
        /// </summary>
        /// <param name="tagReads"></param>
        /// <returns>
        /// Returns a List of Tags
        /// </returns>
        public static List<Tag> RunMathematicalModel(List<TagRead> tagReads)
        {
            /// Initialize a list of Tags
            List<Tag> newTags = new List<Tag>();

            /// Create new Tags, each based on data from a tagRead 
            foreach (TagRead tagRead in tagReads)
            {
                /// Creation of new Tag
                Tag tag = CalculateTagPosition(tagRead);

                /// Go to next iteration if Tag wasn't created
                if (tag == null)
                {
                    continue;
                }

                /// Set Tag's timestamp with TagRead's timestamp
                tag.TimeStampDateTime = tagRead.TimeStampDateTime;
                tag.TimeStamp = tagRead.TimeStamp;

                /// Add Tag to list of Tags
                newTags.Add(tag);
            }

            return newTags;
        }

        /// <summary>
        /// Creates a new Tag by calculating its position based on a TagRead's data.
        /// </summary>
        /// <param name="tagRead"></param>
        /// <returns>
        /// Returns a new Tag
        /// Returns null if unable to calculate new Tag's position
        /// </returns>
        private static Tag CalculateTagPosition(TagRead tagRead)
        {
            /// Ignore TagRead if it wasn't obtained by at least 2 UHFreaders
            if (tagRead.AntennasReads.Count < 2)
            {
                return null;
            }

            /// Used to get the sum of all x coordinates values
            double xx = 0;

            /// Used to get the sum of all y coordinates values
            double yy = 0;

            /// Number of (x, y) positions found
            int counter = 0;

            /// Obtains every combination of AntennaReads of different UHFReaders and calculates x and y positions for the new Tag
            for (int i = 0; i < tagRead.AntennasReads.Count - 1; i++)
            {
                for (int j = i + 1; j < tagRead.AntennasReads.Count; j++)
                {
                    /// First AntennaRead of combination of AntennaReads
                    AntennaRead ant1 = tagRead.AntennasReads[i];
                    
                    /// Second AntennaRead of combination of AntennaReads
                    AntennaRead ant2 = tagRead.AntennasReads[j];

                    /// Obtain x by calculating its value with both AntennaReads
                    double x = CalculateTagXCoordinate(ant1, ant2);

                    /// Ignore AntennaReads combination if x doesn't have a valid value 
                    if (double.IsNaN(x))
                    {
                        continue;
                    }

                    /// Obtain y by calculating its value with AntennaRead and obtained x coordinate
                    double y = CalculateTagYCoordinate(ant2, x);

                    /// Ignore AntennaReads combination if y doesn't have a valid value 
                    if (double.IsNaN(y))
                    {
                        continue;
                    }

                    xx += x;
                    yy += y;
                    counter++;
                }
            }

            /// If no position was obtained, discard
            if (counter == 0)
            {
                return null;
            }

            /// If position value is not valid, discard
            if (double.IsInfinity(yy))
            {
                return null;
            }

            /// Get average values of all x and y, obtained during the iteration of every combination of AntennaReads
            double xAvg = xx / counter;
            double yAvg = yy / counter;

            /// Convert x and y values to a decimal with only 2 decimal digits
            decimal xRounded = (decimal)Math.Round(xAvg * 100) / 100;
            decimal yRounded = (decimal)Math.Round(yAvg * 100) / 100;

            /// Create new Tag
            Tag tag = new Tag(tagRead.ID, xRounded, yRounded, tagRead.AntennasReads);

            return tag;
        }

        /// <summary>
        /// Calculates x coordinate based on the AntennaReads combination and the Mathematical Model parameters
        /// </summary>
        /// <param name="ant1"></param>
        /// <param name="ant2"></param>
        /// <returns>
        /// Returns calculated x coordinate
        /// </returns>
        private static double CalculateTagXCoordinate(AntennaRead ant1, AntennaRead ant2)
        {
            /**
             * Tag X Coordinate
             *
             * ( ( RSSI_1 * ( RSSI_1 - ( 2 * RSSI_MAX ) + RSSI_2 * ( 2 * RSSI_MAX - RSSI_2 ) )
             *      /
             *      ( 2 * X_AMP^2 ) * ( ANT_2_X_COORD - ANT_1_X_COORD ) )
             * +
             * ( ( ANT_1_COORD + ANT_2_COORD ) / 2 )
             */

            double var1 = ant1.RSSI * (ant1.RSSI - 2 * MathematicModelParameters.RssiMax)
                + ant2.RSSI * (2 * MathematicModelParameters.RssiMax - ant2.RSSI);

            double var2 = 2 * Math.Pow(MathematicModelParameters.XAmp, 2) * (double)(ant2.Antenna.Position.X - ant1.Antenna.Position.X);

            double var3 = var1 / var2;

            double tagXCoordinate = var3 + ((double)(ant1.Antenna.Position.X + ant2.Antenna.Position.X) / 2);

            return tagXCoordinate;
        }

        /// <summary>
        /// Calculates y coordinate based on the AntennaRead, the calculated x coordinate and the Mathematical Model parameters 
        /// </summary>
        /// <param name="ant2"></param>
        /// <param name="tagXCoordinate"></param>
        /// <returns>
        /// Returns calculated y coordinate
        /// </returns>
        private static double CalculateTagYCoordinate(AntennaRead ant2, double tagXCoordinate)
        {
            /**
             * Tag Y Coordinate
             *
             * RAIZQ(
             *  ( RSSI_MAX - RSSI_2 )^2 - ( X_AMP^2 * ( TAG_X_COORDINATE - ANT_2_X_COORD )^2 )
             * )
             * *
             * L_MAX / ( RSSI_MAX - RSSI_MIN )
             */

            double tagYCoordinate = Math.Sqrt(
                Math.Pow(MathematicModelParameters.RssiMax - ant2.RSSI, 2)
                - (Math.Pow(MathematicModelParameters.XAmp, 2) * Math.Pow(tagXCoordinate - (double)ant2.Antenna.Position.X, 2))
            ) * MathematicModelParameters.LMax / (MathematicModelParameters.RssiMax - MathematicModelParameters.RssiMin);

            return tagYCoordinate;
        }
    }
}

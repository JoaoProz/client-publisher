using RINPOSYS.CustomClasses.Devices.GenericDevice;
using RINPOSYS.CustomClasses.Devices.LaserModule;
using RINPOSYS.CustomClasses.Devices.Servo;
using RINPOSYS.CustomClasses.Devices.UHFReader;
using RINPOSYS.CustomClasses.RFIDReads;
using RINPOSYS.CustomClasses.Utils;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace RINPOSYS.CustomClasses.Algorithm
{
    /// <summary>
    /// Provides methods capable of:
    /// <para>- Obtaining distance from Lasers;</para>
    /// <para>- Obtaining angle from servo;</para>
    /// <para>- Joining obtained lists of MetaTags into a list of TagReads;</para>
    /// <para>- Applying transformations on a Tag's position.</para>
    /// </summary>
    public static class LocalizationAlgorithm
    {
        /// <summary>
        /// Tries to get a Position through the read distance of two lasers( one for x coordinates and another for y coordinates).
        /// <para>If one of the distances cannot be retrieved, a null Position is returned.</para>
        /// </summary>
        /// <param name="devices"></param>
        /// <returns> 
        /// Returns a position if both lasers have successfully gotten a distance.
        /// Returns null if at least one laser failed to obtain a distance.
        /// </returns>
        public static Position GetPositionFromLasers(List<Device> devices)
        {
            /// Initialize with a constant value
            decimal x = decimal.MinValue;
            decimal y = decimal.MinValue;

            /// Change values of x and y for each laser
            foreach (Device d in devices)
            {
                if (d is LaserModule)
                {
                    if ((d as LaserModule).Direction == LaserDirection.X)
                    {
                        x = (d as LaserModule).Distance;
                    }
                    else if ((d as LaserModule).Direction == LaserDirection.Y)
                    {
                        y = (d as LaserModule).Distance;
                    }
                }
            }

            /// If one laser failed to obtain distance, dont return a Position
            if (x == decimal.MinValue || y == decimal.MinValue)
            {
                return null;
            }

            /// Reset distance value on lasers
            foreach (Device d in devices)
            {
                if (d is LaserModule)
                {
                    (d as LaserModule).Distance = decimal.MinValue;
                }
            }

            return new Position(x, y);
        }

        /// <summary>
        /// Tries to get the angle from servo.
        /// <para>If angle cannot be retrieved, returns 0 as the angle value.</para>
        /// </summary>
        /// <param name="devices"></param>
        /// <returns>
        /// Returns angle obtained by servo.
        /// Returns angle = 0 if servo didn't obtain an angle. 
        /// </returns>
        public static int GetAngleFromServo(List<Device> devices)
        {
            /// Initialize with a constant value (0)
            int angle = 0;

            /// Change value of angle with obtained angle from servo
            foreach (Device d in devices)
            {
                if (d is Servo)
                {
                    angle = (d as Servo).Angle;
                    break;
                }
            }

            return angle;
        }

        /// <summary>
        /// Joins all MetaTags from both UHFReaders and transforms them into a new list of TagReads.
        /// </summary>
        /// <param name="devices"></param>
        /// <returns>
        /// List of TagReads
        /// </returns>
        public static List<TagRead> GetTagsReads(List<Device> devices, Action<MetaTag> removeFromUIGridMetaTagsDel)
        {
            #region initialize vars

            List<List<MetaTag>> mtll = new List<List<MetaTag>>();
            List<MetaTag> l1 = new List<MetaTag>();
            List<MetaTag> l2 = new List<MetaTag>();

            ConcurrentDictionary<string, MetaTag> cd1 = new ConcurrentDictionary<string, MetaTag>();
            ConcurrentDictionary<string, MetaTag> cd2 = new ConcurrentDictionary<string, MetaTag>();

            int dCounter = 1;

            #endregion

            /// Fill cd1 and cd2 with the copies of both UHFReaders ConcurrentDictionaries
            foreach (Device d in devices)
            {
                if (d is UHFReader)
                {
                    if (dCounter == 1)
                    {
                        cd1 = (d as UHFReader).MetaTagsDictionary;
                        dCounter++;
                    }
                    else
                    {
                        cd2 = (d as UHFReader).MetaTagsDictionary;
                        break;
                    }
                }
            }

            /// Compares both ConcurrentDictionaries
            /// If both have a value for the RSSIAvg (meaning that the MetaTag has its RSSI queue filled, and thus, RSSIAvg != -1),
            ///  Remove those Keys from the cds and add them to their list, respectively.
            foreach (string epc in cd1.Keys)
            {
                if (cd2.ContainsKey(epc)
                    && cd1[epc].RSSIAvg != -1
                    && cd2[epc].RSSIAvg != -1)
                {
                    /// Remove entries from the UI component 'dataGridViewMetaTagsList'
                    removeFromUIGridMetaTagsDel(cd1[epc]);
                    removeFromUIGridMetaTagsDel(cd2[epc]);

                    /// Remove from cd -> add to list
                    cd1.TryRemove(epc, out MetaTag omt1);
                    l1.Add(omt1);

                    /// Remove from cd -> add to list
                    cd2.TryRemove(epc, out MetaTag omt2);
                    l2.Add(omt2);
                }
            }

            dCounter = 1;
            /// Updates UHFReaders concurrentDictionaries, respectively
            foreach (Device d in devices)
            {
                if (d is UHFReader)
                {
                    if (dCounter == 1)
                    {
                        (d as UHFReader).MetaTagsDictionary = cd1;
                        dCounter++;
                    }
                    else
                    {
                        (d as UHFReader).MetaTagsDictionary = cd2;
                        break;
                    }
                }
            }

            /// Add both lists of MetaTags to a list of lists<MetaTag>, that is used by TransformReadsIntoTagReads method
            mtll.Add(l1);
            mtll.Add(l2);

            return TransformReadsIntoTagReads(mtll);
        }

        /// <summary>
        /// Takes all MetaTags joined, from both UHFReaders, and transforms them into tagReads.
        /// <para>This process is necessary because the mathematical model works with TagReads instead of MetaTags.</para>
        /// </summary>
        /// <param name="mtll"></param>
        /// <returns>
        /// Returns list of TagReads
        /// </returns>
        public static List<TagRead> TransformReadsIntoTagReads(List<List<MetaTag>> mtll)
        {
            /// Initialize the new list of TagReads
            List<TagRead> tagsReads = new List<TagRead>();

            /// For each Metatag, of each list:
            ///  Creates/Adds a new TagRead into the list of TagReads, if it doesn't exist yet in the list;
            ///  Creates/Updates the TagRead on the list of TagReads, if it already exists in the list.
            foreach (List<MetaTag> mtl in mtll)
            {
                foreach (MetaTag mt in mtl)
                {
                    /// Create new TagRead from MetaTag's EPC
                    TagRead tagRead = new TagRead(mt.EPC);

                    bool found = false;
                    foreach (TagRead tr in tagsReads)
                    {
                        /// Compares TagRead's ID (EPC) with MetaTag's EPC
                        if (tr.ID == mt.EPC)
                        {
                            /// TagRead doesn't exist in TagReads list

                            found = true;

                            if (tr.TimeStamp < mt.TimeStamp)
                            {
                                /// Update TagRead to its most recent timestamp
                                tr.TimeStampDateTime = mt.TimeStampDateTime;
                                tr.TimeStamp = mt.TimeStamp;
                            }

                            if (mt.RSSIAvg != -1)
                            {
                                /// Update list of AntennaRead of TagRead
                                AntennaRead antRead = new AntennaRead(mt.Antenna, mt.RSSIAvg);
                                tr.AntennasReads.Add(antRead);
                            }

                            break;
                        }
                    }

                    /// TagRead doesn't exist in TagReads list
                    if (!found)
                    {
                        /// Get timestamp from MetaTag that created this TagRead
                        tagRead.TimeStampDateTime = mt.TimeStampDateTime;
                        tagRead.TimeStamp = mt.TimeStamp;

                        if (mt.RSSIAvg != -1)
                        {
                            /// Add AntennaRead to list of AntennaRead of TagRead
                            AntennaRead antRead = new AntennaRead(mt.Antenna, mt.RSSIAvg);
                            tagRead.AntennasReads.Add(antRead);

                            tagsReads.Add(tagRead);
                        }

                    }
                }
            }

            return tagsReads;
        }

        /// <summary>
        /// Updates each tag's position with:
        /// <para>- laser's distance(if applicable);</para>
        /// <para>- servo's angle(if applicable)</para>
        /// <para>- conversion of position from meters into millis.</para>
        /// <para></para>
        /// <para>Finally, orders list of tags by tag's Timestamp.</para>
        /// </summary>
        /// <param name="tags"></param>
        /// <param name="laserPosition"></param>
        /// <param name="servoAngle"></param>
        /// <param name="usingLasers"></param>
        /// <param name="usingServo"></param>
        /// <returns>
        /// Returns a list of Tags, ordered by timestamp
        /// </returns>
        public static List<Tag> TagsPosteriorTreatment(List<Tag> tags, Position laserPosition, int servoAngle, bool usingLasers, bool usingServo)
        {
            if (!usingLasers)
            {
                /// Use default Position
                laserPosition = new Position(0, 0);
            }

            if (!usingServo)
            {
                /// Use default angle
                servoAngle = 0;
            }

            /// Apply transformation to each Tag's position
            foreach (Tag t in tags)
            {
                /// Add offset position from lasers
                t.Position = ApplyLaserPositionOffSet(t.Position, laserPosition);

                if (servoAngle != 0)
                {
                    /// Apply angle correction
                    t.Position = ApplyAngleTransformation(servoAngle, t.Position, out double D, out double alpha);
                }

                /// Convert meters to millis
                t.Position.X = t.Position.X * 1000;
                t.Position.Y = t.Position.Y * 1000;
            }

            return tags.OrderBy(x => x.TimeStamp).ToList();
        }

        /// <summary>
        /// Applys offset of Lasers's Position on Tag's Position.
        /// </summary>
        /// <param name="tagPosition"></param>
        /// <param name="laserPosition"></param>
        /// <returns>
        /// Returns transformed position
        /// </returns>
        public static Position ApplyLaserPositionOffSet(Position tagPosition, Position laserPosition)
        {
            tagPosition.X += laserPosition.X;
            tagPosition.Y += laserPosition.Y;

            return tagPosition;
        }

        /// <summary>
        /// Changes Tag's Position by applying an angle transformation, using Servo's angle on Tag's Position.
        /// </summary>
        /// <param name="delta"></param>
        /// <param name="angle"></param>
        /// <param name="position"></param>
        /// <returns>
        /// Returns transformed position
        /// </returns>
        public static Position ApplyAngleTransformation(int angle, Position position, out double D, out double alpha)
        {
            /// angle (degrees) -> a (radians)
            double a = angle * Math.PI / 180;

            double xi = Convert.ToDouble(position.X);
            double yi = Convert.ToDouble(position.Y);

            /// D = RAIZQ ( (Xi)^2 + (Yi)^2 )
            D = Math.Sqrt((Math.Pow((xi), 2)) + Math.Pow(yi, 2));

            /// ALPHA = ( arccos ( Yi / D ) ) + ANGLE
            alpha = Math.Acos(yi / D) + a;
            if (xi < 0)
            {
                alpha = Math.PI - alpha;
            }

            /// Xf = D * cos( ALPHA )
            double xf = Math.Round(D * Math.Cos(alpha), 2);

            /// Yf = D * sin( ALPHA )
            double yf = Math.Round(D * Math.Sin(alpha), 2);
            
            /// Used only for debugging purposes
            alpha *= 180 / Math.PI;

            return new Position(Convert.ToDecimal(xf), Convert.ToDecimal(yf));
        }
    }
}

using RINPOSYS.CustomClasses.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RINPOSYS.CustomClasses.RFIDReads
{
    /// <summary>
    /// Represents tag and its position
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// Timestamp in DateTime format
        /// </summary>
        public DateTime TimeStampDateTime { get; set; }

        /// <summary>
        /// Timestamp in long format
        /// </summary>
        /// <remarks>
        /// [Browsable(false)] means that an UI component shall not use this vareable when showing results associated with this object
        /// </remarks>
        [Browsable(false)]
        public long TimeStamp { get; set; }

        /// <summary>
        /// Identifier, obtained through the EPC value from MetaTag
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// List of Antennas and their respective received signal
        /// </summary>
        /// <remarks>
        /// [Browsable(false)] means that an UI component shall not use this vareable when showing results associated with this object
        /// </remarks>
        [Browsable(false)]
        public List<AntennaRead> AntennasReads { get; set; }

        /// <summary>
        /// Tag position (x, y)
        /// </summary>
        /// <remarks>
        /// [Browsable(false)] means that an UI component shall not use or show this vareable when showing results associated with this object
        /// </remarks>
        [Browsable(false)]
        public Position Position { get; set; }

        /// <summary>
        /// Used on UI components
        /// </summary>
        /// <remarks>
        /// Workaround to show position x in UI component, because UI component couldn't use or show Position
        /// </remarks>
        public decimal PositionX {
            get {
                return Position.X;
            }
        }

        /// <summary>
        /// Used on UI components
        /// </summary>
        /// <remarks>
        /// Workaround to show position y in UI component, because UI component couldn't use or show Position
        /// </remarks>
        public decimal PositionY
        {
            get
            {
                return Position.Y;
            }
        }

        /// <summary>
        /// RSSI obtained by Reader 1, that was applied on MM to generate this Tag
        /// </summary>
        public double R1RSSI
        {
            get
            {
                AntennaRead antRead = AntennasReads.Find(ar => ar.Antenna.ID == 1);

                if (antRead != null)
                {
                    return antRead.RSSI;
                }

                return double.NaN;
            }
        }

        /// <summary>
        /// RSSI obtained by Reader 2, that was applied on MM to generate this Tag
        /// </summary>
        public double R2RSSI
        {
            get
            {
                AntennaRead antRead = AntennasReads.Find(ar => ar.Antenna.ID == 2);

                if (antRead != null)
                {
                    return antRead.RSSI;
                }

                return double.NaN;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="xCoordinate"></param>
        /// <param name="yCoordinate"></param>
        /// <param name="antennasReads"></param>
        public Tag(string id, decimal xCoordinate, decimal yCoordinate, List<AntennaRead> antennasReads)
        {
            ID = id;
            Position = new Position(xCoordinate, yCoordinate);

            AntennasReads = antennasReads;
        }

        /// <summary>
        /// CustomToString()
        /// </summary>
        /// <returns>
        /// Returns Tag's parameters
        /// </returns>
        public override string ToString()
        {
            return "\nID:\t" + ID + "\n\tPosition:\t" + Position + "\n\tAntReads:\t" + AntennasReads;
        }
    }
}

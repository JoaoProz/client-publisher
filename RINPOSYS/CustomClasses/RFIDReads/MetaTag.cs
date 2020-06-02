using RINPOSYS.CustomClasses.Utils;
using System;

namespace RINPOSYS.CustomClasses.RFIDReads
{
    /// <summary>
    /// Represents a data that may be used to generate a Tag and its position
    /// </summary>
    public class MetaTag : IComparable<MetaTag>
    {
        /// <summary>
        /// Timestamp in DateTime format
        /// </summary>
        public DateTime TimeStampDateTime { get; set; }

        /// <summary>
        /// Timestamp in long format
        /// </summary>
        public long TimeStamp { get; set; }

        /// <summary>
        /// One of the Tag fabricator identifier
        /// </summary>
        public string EPC { get; set; }
        
        /// <summary>
        /// Number of times a RSSI value was obtained for this MetaTag
        /// </summary>
        public int RSSICounter { get; set; } = 0;

        /// <summary>
        /// Last RSSI value obtained for this MetaTag
        /// </summary>
        public int RSSI { get; set; }

        /// <summary>
        /// RSSI average value
        /// </summary>
        /// <remarks>
        /// Value is -1 until RSSI queue 'rssiQueue' becomes full.
        /// When RSSI queue is full, value is the average value of all RSSIs in RSSI queue
        /// </remarks>
        public double RSSIAvg { get; set; } = -1;

        /// <summary>
        /// Antenna that received signal
        /// </summary>
        public Antenna Antenna { get; set; }

        /// <summary>
        /// Queue of RSSIs
        /// </summary>
        /// <remarks>
        /// Used to obtain a RSSI average when its full
        /// </remarks>
        private readonly FixedSizedQueue<int> rssiQueue;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="epc"></param>
        /// <param name="antenna"></param>
        public MetaTag(string epc, Antenna antenna)
        {
            EPC = epc;

            Antenna = antenna;

            TimeStampDateTime = DateTime.Now;
            TimeStamp = TimeStampDateTime.Ticks;

            rssiQueue = new FixedSizedQueue<int>(FixedSizedQueue<int>.Size);
        }

        /// <summary>
        /// Adds RSSI to RSSI queue and updates RSSIAvg
        /// </summary>
        /// <param name="rssi"></param>
        public void AddRSSI(int rssi)
        {
            /// Update MetaTag's timestamps
            TimeStampDateTime = DateTime.Now;
            TimeStamp = TimeStampDateTime.Ticks;

            /// Update last RSSI obtained
            RSSI = rssi;

            /// Update number of times a RSSI value was obtained
            RSSICounter++;

            if (RSSICounter == Int32.MaxValue)
            {
                /// Reset counter
                RSSICounter = 1;
            }

            /// Get RSSI average from RSSI queue
            RSSIAvg = Math.Round(rssiQueue.CustomAdd(rssi), 2);

            if (double.IsNegativeInfinity(RSSIAvg))
            {
                /// Queue isn't full

                RSSIAvg = -1;
            }
        }

        /// <summary>
        /// Custom ToString()
        /// </summary>
        /// <returns>
        /// Returns MetaTag parameters
        /// </returns>
        public override string ToString()
        {
            return EPC + "\t(" + Antenna.Position.X + ", " + Antenna.Position.Y + ")\t" + RSSICounter + "\t" + RSSIAvg;
        }

        /// <summary>
        /// Sort MetaTags by name ascending
        /// </summary>
        /// <param name="name1"></param>
        /// <param name="name2"></param>
        /// <returns>
        /// Returns:
        /// Less than 0 if name1 precedes name2
        /// Equal to 0 if name1 has same position in sort order as name2
        /// Greater than 0 if name1 follows name2
        /// </returns>
        public int SortByNameAscending(string name1, string name2)
        {
            return name1.CompareTo(name2);
        }

        /// <summary>
        /// IComparable method
        /// </summary>
        /// <param name="mt"></param>
        /// <returns>
        /// Less than 0 if name1 precedes name2
        /// Equal to 0 if name1 has same position in sort order as name2
        /// Greater than 0 if name1 follows name2
        /// </returns>
        public int CompareTo(MetaTag mt)
        {
            // A null value means that this object is greater.
            if (mt == null)
            {
                return 1;
            }
            else
            {
                return SortByNameAscending(EPC, mt.EPC);
            }
        }
    }
}

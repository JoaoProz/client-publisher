using System;
using System.Collections.Generic;

namespace RINPOSYS.CustomClasses.RFIDReads
{
    /// <summary>
    /// Represents a transformed MetaTag, with the objective to be applied on the Mathematical Model
    /// </summary>
    public class TagRead
    {
        /// <summary>
        /// Tag identifier
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// List of Antennas and their respective received signal
        /// </summary>
        public List<AntennaRead> AntennasReads { get; set; }

        /// <summary>
        /// Timestamp in DateTime format
        /// </summary>
        public DateTime TimeStampDateTime { get; set; }

        /// <summary>
        /// Timestamp in long format
        /// </summary>
        public long TimeStamp { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        public TagRead(string id)
        {
            ID = id;
            AntennasReads = new List<AntennaRead>();
        }

        /// <summary>
        /// Custom ToString()
        /// </summary>
        /// <returns>
        /// Returns TagRead's parameters
        /// </returns>
        public override string ToString()
        {
            string s = "ID:\t" + ID + "\n\tAntReads:\n";
            foreach (AntennaRead antRead in AntennasReads)
            {
                s += antRead.ToString() + "\n";
            }

            return s;
        }
    }
}

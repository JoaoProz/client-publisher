using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RINPOSYS.CustomClasses.Utils
{
    /// <summary>
    /// Converts frequencies into 1 byte with band region and min frequency format
    /// </summary>
    public static class RegionFrequencyConverter
    {
        /// <summary>
        /// band region:
        /// <para>Chinese = 1</para>
        /// <para>US = 2</para>
        /// <para>Korean = 3</para>
        /// <para>EU = 4</para>
        /// </summary>
        private const int band = 4;

        /// <summary>
        /// Dictionary of frequencies and their respective index
        /// <para>Key => frequency</para>
        /// <para>Value => index</para>
        /// </summary>
        private static Dictionary<string, int> DicFreqIndex = new Dictionary<string, int>()
        {
            //{ "865,1", 0 },
            //{ "865,3", 1 },
            //{ "865,5", 2 },
            //{ "865,7", 3 },
            //{ "865,9", 4 },
            //{ "866,1", 5 },
            //{ "866,3", 6 },
            //{ "866,5", 7 },
            //{ "866,7", 8 },
            //{ "866,9", 9 },
            //{ "867,1", 10 },
            //{ "867,3", 11 },
            //{ "867,5", 12 },
            //{ "867,7", 13 },
            //{ "867,9", 14 }

            { "865.1", 0 },
            { "865.3", 1 },
            { "865.5", 2 },
            { "865.7", 3 },
            { "865.9", 4 },
            { "866.1", 5 },
            { "866.3", 6 },
            { "866.5", 7 },
            { "866.7", 8 },
            { "866.9", 9 },
            { "867.1", 10 },
            { "867.3", 11 },
            { "867.5", 12 },
            { "867.7", 13 },
            { "867.9", 14 }
        };

        /// <summary>
        /// Get the array of frequencies 
        /// </summary>
        /// <returns>
        /// Returns array of frequencies in string format
        /// </returns>
        public static string[] GetFrequencies()
        {
            return DicFreqIndex.Keys.ToList().ConvertAll(freq => freq.ToString()).ToArray();
        }

        /// <summary>
        /// Verifies if frequency is valid
        /// </summary>
        /// <param name="frequency"></param>
        /// <returns>
        /// Returns true if frequency is valid
        /// Returns false if frequency is not valid
        /// </returns>
        public static bool ValidFrequency(decimal frequency)
        {
            return DicFreqIndex.ContainsKey(frequency.ToString());
        }

        /// <summary>
        /// Converts minimum frequency into 1 byte with band region and min frequency
        /// </summary>
        /// <param name="frequency"></param>
        /// <param name="dminfre"></param>
        public static void ConvertMinFrequencyToByte(decimal frequency, out byte dminfre)
        {
            if (!ValidFrequency(frequency))
            {
                throw new Exception("Can't convert an invalid frequency");
            }

            int freqIndex = DicFreqIndex[frequency.ToString()];

            /// bit 7 and bit 6 used for band region
            /// bit 5 to bit 0 used for minimum frequency
            /// 0x0C => 12 => 0000 1100
            /// 0x03 => 3  => 0000 0011
            /// 0x06 => 6  => 0000 0110
            /// 0x3F => 63 => 0011 1111
            //dminfre = Convert.ToByte(((band & 0x03) << 0x06) | (freqIndex & 0x3F));

            dminfre = Convert.ToByte(freqIndex);
        }

        /// <summary>
        /// Converts maximum frequency into 1 byte with band region and max frequency
        /// </summary>
        /// <param name="frequency"></param>
        /// <param name="dmaxfre"></param>
        public static void ConvertMaxFrequencyToByte(decimal frequency, out byte dmaxfre)
        {
            if (!ValidFrequency(frequency))
            {
                throw new Exception("Can't convert an invalid frequency");
            }

            int freqIndex = DicFreqIndex[frequency.ToString()];

            /// bit 7 and bit 6 used for band region
            /// bit 5 to bit 0 used for maximum frequency
            /// 0x0C => 12 => 0000 1100
            /// 0x04 => 4  => 0000 0100
            /// 0x3F => 63 => 0011 1111
            //dmaxfre = Convert.ToByte(((band & 0x0C) << 0x04) | (freqIndex & 0x3F));

            dmaxfre = Convert.ToByte((64 + freqIndex));
        }
    }
}

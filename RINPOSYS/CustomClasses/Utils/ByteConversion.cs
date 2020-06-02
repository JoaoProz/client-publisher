using System;
using System.Text;

namespace RINPOSYS.CustomClasses.Utils
{
    /// <summary>
    /// Deals with string to byte[] conversion
    /// </summary>
    public static class ByteConversion
    {
        /// <summary>
        /// Transform s into byte[]
        /// </summary>
        /// <param name="s"></param>
        /// <returns>
        /// Returns byte[]
        /// </returns>
        public static byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        /// <summary>
        /// Transforms data into string
        /// </summary>
        /// <param name="data"></param>
        /// <returns>
        /// Returns a string, in uppercase
        /// </returns>
        public static string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            return sb.ToString().ToUpper();

        }

        /// <summary>
        /// Transforms baudrate string into a byte index
        /// </summary>
        /// <param name="baudRate"></param>
        /// <returns>
        /// Returns a byte as index
        /// </returns>
        public static byte GetBaudRateIndexByte(string baudRate)
        {
            byte b;

            switch (baudRate)
            {
                case "9600bps": b = Convert.ToByte(0); break;
                case "19200bps": b = Convert.ToByte(1); break;
                case "38400bps": b = Convert.ToByte(2); break;
                case "57600bps": b = Convert.ToByte(5); break;
                case "115200bps": b = Convert.ToByte(6); break;
                default: b = Convert.ToByte(-1); break;
            }

            return b;
        }
    }
}

using RINPOSYS.CustomClasses.Algorithm;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace RINPOSYS.CustomClasses.IOFiles
{
    /// <summary>
    /// Manages interaction with Mathematical Model Parameters config file
    /// </summary>
    internal static class ConfigFileMMParameters
    {
        /// <summary>
        /// config file filename
        /// </summary>
        internal const string Filename = "MathematicalModelParameters.txt";

        /// <summary>
        /// Reads and validates each line of config file
        /// </summary>
        /// <param name="filePath"></param>
        internal static void ReadFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (ConfigFilesMediator.IgnoreLine(line))
                {
                    continue;
                }

                LineValidations(line);

                ReadLine(line);
            }
        }

        /// <summary>
        /// Generates default content for config file
        /// </summary>
        /// <returns>
        /// Return string with default content
        /// </returns>
        internal static string DefaultContent()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("L Max: {0}", 5.5); sb.AppendLine();
            sb.AppendFormat("RSSI Min: {0}", 185); sb.AppendLine();
            sb.AppendFormat("RSSI Max: {0}", 210); sb.AppendLine();
            sb.AppendFormat("Antenna type value: {0}", 16); sb.AppendLine();

            return sb.ToString();
        }

        /// <summary>
        /// Validates line
        /// </summary>
        /// <param name="line"></param>
        private static void LineValidations(string line)
        {
            string[] lineSplit = line.Split(':');


            if (lineSplit.Count() < 2)
            {
                /// line isn't in 'x: y' format

                throw new Exception("\tMathematical Model parameters config -> Invalid line: '" + line + "'");
            }

            string p = lineSplit[0];

            if (p != "L Max" && p != "RSSI Min" && p != "RSSI Max" && p != "Antenna type value")
            {
                /// line doesn't start with accepted parameter

                throw new Exception("\tMathematical Model parameters config -> Invalid parameter: '" + p + "'");
            }

            try
            {
                double value = Convert.ToDouble(lineSplit[1]);
            }
            catch (Exception)
            {
                /// value is NaN

                throw new Exception("\tMathematical Model parameters config -> Invalid value: '" + lineSplit[1] + "' on parameter '" + p + "'");
            }
        }

        /// <summary>
        /// Reads line and updates the corresponding Mathematic Model parameter
        /// </summary>
        /// <param name="line"></param>
        private static void ReadLine(string line)
        {
            string[] lineSplit = line.Split(':');

            string parameter = lineSplit[0];
            double value = Convert.ToDouble(lineSplit[1]);

            switch (parameter)
            {
                case "L Max":
                    MathematicModelParameters.LMax = value;
                    break;
                case "RSSI Min":
                    MathematicModelParameters.RssiMin = value;
                    break;
                case "RSSI Max":
                    MathematicModelParameters.RssiMax = value;
                    break;
                case "Antenna type value":
                    MathematicModelParameters.XAmp = value;
                    break;
            }
        }
    }
}

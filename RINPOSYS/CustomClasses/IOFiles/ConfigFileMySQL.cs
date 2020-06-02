using System;
using System.IO;
using System.Linq;
using System.Text;

namespace RINPOSYS.CustomClasses.IOFiles
{
    /// <summary>
    /// Manages interaction with MySQL config file
    /// </summary>
    internal static class ConfigFileMySQL
    {
        /// <summary>
        /// config file filename
        /// </summary>
        internal const string Filename = "MySQLConfig.txt";

        /// <summary>
        /// Reads and validates each line of config file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="tableName"></param>
        /// <param name="connStr"></param>
        internal static void ReadFile(string filePath, ref string tableName, ref string connStr)
        {
            /// string array with each line's value 
            string[] connStrArr = new string[5];

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (ConfigFilesMediator.IgnoreLine(line))
                {
                    continue;
                }

                LineValidations(line);

                ReadLine(line, ref connStrArr, ref tableName);
            }

            /// transfroms string array into a string, separating each element with a ';'
            connStr = string.Join(";", connStrArr);
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

            sb.AppendFormat("server: {0}", "localhost"); sb.AppendLine();
            sb.AppendFormat("port: {0}", 3306); sb.AppendLine();
            sb.AppendFormat("database: {0}", "rfid"); sb.AppendLine();
            sb.AppendFormat("user: {0}", "user"); sb.AppendLine();
            sb.AppendFormat("password: {0}", "RINPOSYS"); sb.AppendLine();
            sb.AppendFormat("table: {0}", "rfid_log"); sb.AppendLine();

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

                throw new Exception("\tMySQL config -> Invalid line: '" + line + "'");
            }

            string p = lineSplit[0];

            if (p != "server" && p != "port" && p != "database" && p != "user" && p != "password" && p != "table")
            {
                /// line doesn't start with accepted parameter

                throw new Exception("\tMySQL config -> Invalid parameter: '" + p + "'");
            }
        }

        /// <summary>
        /// Reads line and updates the corresponding MySQL parameter
        /// </summary>
        /// <param name="line"></param>
        /// <param name="connStrArr"></param>
        /// <param name="tableName"></param>
        private static void ReadLine(string line, ref string[] connStrArr, ref string tableName)
        {
            string[] lineSplit = line.Split(':');

            string parameter = lineSplit[0];
            string value = lineSplit[1].Trim();

            switch (lineSplit[0])
            {
                case "server":
                    connStrArr[0] = "server=" + value;
                    break;
                case "user":
                    connStrArr[1] = "user=" + value;
                    break;
                case "database":
                    connStrArr[2] = "database=" + value;
                    break;
                case "port":
                    connStrArr[3] = "port=" + value;
                    break;
                case "password":
                    connStrArr[4] = "password=" + value;
                    break;
                case "table":
                    tableName = lineSplit[1].Trim();
                    break;
            }
        }
    }
}

using System;
using System.IO;
using System.Text;

namespace RINPOSYS.CustomClasses.IOFiles
{
    /// <summary>
    /// Manages interaction with Notes config file
    /// </summary>
    internal static class ConfigFileNotes
    {
        /// <summary>
        /// config file filename
        /// </summary>
        internal const string Filename = "Notes.txt";

        /// <summary>
        /// Reads and validates each line of config file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="notes"></param>
        internal static void ReadFile(string filePath, ref string notes)
        {
            string[] lines = File.ReadAllLines(filePath);

            bool gotAnyText = false;

            foreach (string line in lines)
            {
                if (ConfigFilesMediator.IgnoreLine(line))
                {
                    continue;
                }

                LineValidations(line);

                gotAnyText = true;

                notes += ReadLine(line);
            }

            if (!gotAnyText)
            {
                throw new Exception("Notes file doesn't have any notes");
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

            sb.AppendLine("Armazem zona 1");

            return sb.ToString();
        }

        /// <summary>
        /// Validates line
        /// </summary>
        /// <param name="line"></param>
        private static void LineValidations(string line)
        {
        }

        /// <summary>
        /// Reads line and updates notes
        /// </summary>
        /// <param name="line"></param>
        private static string ReadLine(string line)
        {
            return line + Environment.NewLine;
        }
    }
}

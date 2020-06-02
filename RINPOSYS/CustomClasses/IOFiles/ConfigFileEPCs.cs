using RINPOSYS.CustomClasses.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RINPOSYS.CustomClasses.IOFiles
{
    /// <summary>
    /// Manages interaction with Devices config file
    /// </summary>
    internal static class ConfigFileEPCs
    {
        /// <summary>
        /// config file filename
        /// </summary>
        internal const string Filename = "EPCDatasets.txt";

        private const string EPCDefault = "000000000000000000000000";

        /// <summary>
        /// Reads and validates each line of config file
        /// </summary>
        /// <param name="filePath"></param>
        internal static void ReadFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            
            string dataSetLabel = null;
            List<string> epcs = new List<string>();
            
            foreach (string line in lines)
            {
                if (ConfigFilesMediator.IgnoreLine(line))
                {
                    if (dataSetLabel != null)
                    {
                        EPCsComparer.AddDataSet(dataSetLabel, epcs.ToList());

                        dataSetLabel = null;
                        epcs.Clear();
                    }

                    continue;
                }

                LineValidations(ref dataSetLabel, line);

                ReadLine(line, epcs);
            }

            if (dataSetLabel != null)
            {
                EPCsComparer.AddDataSet(dataSetLabel, epcs);
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

            sb.AppendLine("Dataset: d1");
            sb.AppendLine("E200001931030056157076BB");
            sb.AppendLine("E200001931030091158074D8");
            sb.AppendLine("E200001931030093158074E5");
            sb.AppendLine("E200001931030106158074F0");
            sb.AppendLine("E200001931030108158074FD");
            sb.AppendLine("E20000193103011315807507");
            sb.AppendLine("E20000193103011415807500");
            sb.AppendLine("E20000193103012315807518");
            sb.AppendLine("E2000019310301241580751D");
            sb.AppendLine("E20000193103012515807525");
            sb.AppendLine("E2000019310301261580751E");
            sb.AppendLine("E20000193103014115807545");
            sb.AppendLine("E2000019310301421580753E");
            sb.AppendLine("E20000193103014315807546");
            sb.AppendLine("E2000019310301441580753F");
            sb.AppendLine("E2000019310301501580754E");
            sb.AppendLine("E2000019310301601580755F");
            sb.AppendLine("E20000193103016115807567");
            sb.AppendLine("E20000193103016215807560");
            sb.AppendLine("E20000193103016315807568");
            sb.AppendLine("E20000193103017715807587");
            sb.AppendLine("E20000193103017815807580");
            sb.AppendLine("E20000193103017915807588");
            sb.AppendLine("E200001931030199158075B6");
            sb.AppendLine();
            sb.AppendLine("Dataset: d2");
            sb.AppendLine("E200001931030056157076BB");
            sb.AppendLine("E200001931030091158074D8");
            sb.AppendLine("E200001931030093158074E5");
            sb.AppendLine("E200001931030106158074F0");
            sb.AppendLine();
            sb.AppendLine("Dataset: d3");
            sb.AppendLine("E2000019310301241580751D");
            sb.AppendLine("E20000193103012515807525");
            sb.AppendLine("E2000019310301261580751E");
            sb.AppendLine("E20000193103014115807545");
            sb.AppendLine("E2000019310301421580753E");
            sb.AppendLine("E20000193103014315807546");
            sb.AppendLine("E2000019310301441580753F");
            sb.AppendLine("E2000019310301501580754E");
            sb.AppendLine("E2000019310301601580755F");
            sb.AppendLine("E20000193103016115807567");
            sb.AppendLine("E20000193103016215807560");
            sb.AppendLine("E20000193103016315807568");
            sb.AppendLine("E20000193103017715807587");

            return sb.ToString();
        }

        /// <summary>
        /// Validates line
        /// </summary>
        /// <param name="label"></param>
        /// <param name="line"></param>
        private static void LineValidations(ref string label, string line)
        {
            string[] lineSplit = line.Split(':');

            if (lineSplit.Count() == 2)
            {
                /// line is dataset label

                label = lineSplit[1].Trim();

                return;
            }

            if (line.Length != EPCDefault.Length)
            {
                throw new Exception("\tEPCs Datasets config -> Invalid EPC: '" + line + "'. Can only be EPC must have " + EPCDefault.Length + " length");
            }
        }

        /// <summary>
        /// Reads line and updates EPCs list
        /// </summary>
        /// <param name="line"></param>
        /// <param name="epcs"></param>
        private static void ReadLine(string line, List<string> epcs)
        {
            epcs.Add(line);
        }

    }
}

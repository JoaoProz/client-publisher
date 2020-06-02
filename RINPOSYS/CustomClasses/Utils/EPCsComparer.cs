using RINPOSYS.CustomClasses.RFIDReads;
using System.Collections.Generic;
using System.Linq;

namespace RINPOSYS.CustomClasses.Utils
{
    /// <summary>
    /// Manages and is capable of applying comparation methods in lists of EPCs
    /// </summary>
    public static class EPCsComparer
    {
        /// <summary>
        /// EPC datasets
        /// </summary>
        /// <remarks>
        /// Can be used to idenfity tags that weren't found by UHFReader's inventories
        /// </remarks>
        private static Dictionary<string, List<string>> epcDatasets = new Dictionary<string, List<string>>();

        /// <summary>
        /// Selected dataset label 
        /// </summary>
        /// <remarks>
        /// dataset label corresponds to a Key in epcDatasets Dictionary
        /// </remarks>
        public static string SelectedDataset { get; set; } = null;

        /// <summary>
        /// Updates newList with every EPC string that doesn't exist in any MetaTag in lmt, from epcDatasets[SelectedDataset]
        /// </summary>
        /// <param name="lmt"></param>
        /// <param name="newList"></param>
        public static void GetEpcsNotInList(List<MetaTag> lmt, out List<string> newList)
        {
            newList = new List<string>();

            foreach (string s in epcDatasets[SelectedDataset])
            {
                MetaTag mt = lmt.Find(nmt => nmt.EPC == s);

                if (mt == null)
                {
                    newList.Add(s);
                }
            }

            newList = newList.Distinct().ToList();
        }

        /// <summary>
        /// Updates newList with every string that doesn't exist in list, from epcDatasets[SelectedDataset]
        /// </summary>
        /// <param name="list"></param>
        /// <param name="newList"></param>
        public static void GetEpcsNotInList(List<string> list, out List<string> newList)
        {
            newList = new List<string>();

            foreach (string s in epcDatasets[SelectedDataset])
            {
                if (!list.Contains(s))
                {
                    newList.Add(s);
                }
            }

            newList = newList.Distinct().ToList();
        }

        /// <summary>
        /// Adds dataset to epcDatasets
        /// </summary>
        /// <param name="dataSetLabel"></param>
        /// <param name="epcs"></param>
        public static void AddDataSet(string dataSetLabel, List<string> epcs)
        {
            if (epcDatasets.ContainsKey(dataSetLabel))
            {
                epcDatasets.Remove(dataSetLabel);
            }

            epcDatasets.Add(dataSetLabel, epcs);

            if (SelectedDataset == null)
            {
                SelectedDataset = dataSetLabel;
            }
        }

        /// <summary>
        /// Gets all dataset labels from epcDatasets
        /// </summary>
        /// <returns>
        /// Returns all keys from epcDatasets in array format
        /// </returns>
        public static string[] GetDatasetsLabels()
        {
            return epcDatasets.Keys.ToArray();
        }

        /// <summary>
        /// Change selected dataset
        /// </summary>
        /// <param name="selected"></param>
        public static void ChangeSelectedDataSet(string selected)
        {
            SelectedDataset = selected;
        }
    }
}

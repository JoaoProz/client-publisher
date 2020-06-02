namespace RINPOSYS.CustomClasses.Devices.UHFReader
{
    /// <summary>
    /// Gets statistical information about UHFReader's inventories
    /// </summary>
    public class UHFReaderInvCounter
    {
        /// <summary>
        /// Number of inventories done that retrieved at least one tag
        public int invsWithTags;

        /// <summary>
        /// Number of inventories done that didn't found any tag
        /// </summary>
        public int invsWithoutTags;

        /// <summary>
        /// Number of tags found, incremented by each new inventory execution that retrieved at least one tag
        /// </summary>
        public int numTagsFound;

        /// <summary>
        /// Minimal number of tags retrieved during an inventory
        /// </summary>
        public int numTagsFoundMin;

        /// <summary>
        /// Maximum number of tags retrieved during an inventory
        /// </summary>
        public int numTagsFoundMax;

        /// <summary>
        /// Constructor
        /// </summary>
        public UHFReaderInvCounter()
        {
            Reset();
        }

        /// <summary>
        /// Resets all parameters
        /// </summary>
        public void Reset()
        {
            invsWithTags = 0;
            invsWithoutTags = 0;

            numTagsFound = 0;
            numTagsFoundMin = int.MaxValue;
            numTagsFoundMax = int.MinValue;
        }

        /// <summary>
        /// Increments number of inventories done that didn't found any tag
        /// </summary>
        public void UpdateWithoutTags()
        {
            invsWithoutTags++;
        }

        /// <summary>
        /// Increments number of inventories done that retrieved at least one tag and other data
        /// </summary>
        /// <param name="numTags"></param>
        public void UpdateWithTags(int numTags)
        {
            /// Increment number of inventories done that retrieved
            invsWithTags++;

            /// Increment Number of tags found by inventory
            numTagsFound += numTags;

            /// Update minimum number of tags found by inventory if numTags is inferior to numTagsFoundMin
            numTagsFoundMin = numTags < numTagsFoundMin ? numTags : numTagsFoundMin;

            /// Update maximum number of tags found by inventory if numTags is superior to numTagsFoundMax
            numTagsFoundMax = numTags > numTagsFoundMax ? numTags : numTagsFoundMax;
        }

        /// <summary>
        /// Calculates and returns average of tags found per inventory
        /// </summary>
        /// <returns>
        /// Returns average of tags found per inventory
        /// </returns>
        public double GetTagsAvg()
        {
            return (double)numTagsFound / invsWithTags;
        }
    }
}

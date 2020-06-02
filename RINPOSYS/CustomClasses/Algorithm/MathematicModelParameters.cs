
namespace RINPOSYS.CustomClasses.Algorithm
{
    /// <summary>
    /// Controls the values of the parameters used for the mathematical Model.
    /// </summary>
    public static class MathematicModelParameters
    {
        /// <summary>
        /// Max Distance for the RSSImin value
        /// </summary>
        public static double LMax { get; set; }

        /// <summary>
        /// Represents the mininum value of RSSI for the maximum distance represented by LMax, that can be used on the Mathematical Model
        /// </summary>
        public static double RssiMin { get; set; }

        /// <summary>
        /// Represents the maximum value of RSSI that can be used on the Mathematical Model
        /// </summary>
        public static double RssiMax { get; set; }

        /// <summary>
        /// Represents tge directivety of the antennas used
        /// </summary>
        public static double XAmp { get; set; }

        /// <summary>
        /// Update Mathematical Model parameters
        /// </summary>
        public static void UpdateParams(double lMax, double rssiMin, double rssiMax, double xAmp)
        {
            LMax = lMax;
            RssiMin = rssiMin;
            RssiMax = rssiMax;
            XAmp = xAmp;
        }

        /// <summary>
        /// Custom ToString()
        /// </summary>
        /// <returns></returns>
        public static string ParametersToString()
        {
            return string.Format("LMax:{0} | RssiMin:{1} | RssiMax:{2} | XAmp:{3}", LMax, RssiMin, RssiMax, XAmp);
        }
    }
}

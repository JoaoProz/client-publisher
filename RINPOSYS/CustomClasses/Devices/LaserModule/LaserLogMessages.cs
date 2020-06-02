namespace RINPOSYS.CustomClasses.Devices.LaserModule
{
    /// <summary>
    /// Returns laser module related log messages from errorCode
    /// </summary>
    internal static class LaserLogMessages
    {
        #region code to description

        /// <summary>
        /// Transforms errorCode into string error description and returns it
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns>
        /// Returns a string description of errorCode
        /// </returns>
        internal static string GetReturnCodeDesc(int errorCode)
        {
            switch (errorCode)
            {
                case 1:
                    return "Power input too low, power voltage should >= 2.0V";
                case 2:
                    return "Internal error, don't care";
                case 3:
                    return "Module temperature is too low(< -20℃)";
                case 4:
                    return "Module temperature is too high(> +40℃)";
                case 5:
                    return "Target out of range";
                case 6:
                    return "Measure result invalid";
                case 7:
                    return "Background light too strong";
                case 8:
                    return "Laser signal too weak";
                case 9:
                    return "Laser signal too strong";
                case 10:
                    return "Hardware fault 1";
                case 11:
                    return "Hardware fault 2";
                case 12:
                    return "Hardware fault 3";
                case 13:
                    return "Hardware fault 4";
                case 14:
                    return "Hardware fault 5";
                case 15:
                    return "Laser signal not stable";
                case 16:
                    return "Hardware fault 6";
                case 17:
                    return "Hardware fault 7";
                default:
                    return "";
            }
        }

        #endregion
    }

}

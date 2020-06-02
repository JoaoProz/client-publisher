namespace RINPOSYS.CustomClasses.Devices.Servo
{
    /// <summary>
    /// Contains every acessible command that can be used on Servo
    /// </summary>
    internal static class ServoCommands
    {
        /// <summary>
        /// Set Servo to minimum angle (0º)
        /// </summary>
        internal const char Zero = 'Z';

        /// <summary>
        /// Make Servo move one iteration (+1/18*270º or -1/18*270º) 
        /// </summary>
        internal const char Change = 'C';

        /// <summary>
        /// Set Servo to maximum angle (270º)
        /// </summary>
        internal const char Max = 'M';

        /// <summary>
        /// Set Servo to minimum angle (0º), then make Servo move one iteration (+10º or -10º), Set Servo to minimum angle (0º)
        /// </summary>
        internal const char Start = 'S';
    }
}

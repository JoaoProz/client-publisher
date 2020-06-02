namespace RINPOSYS.CustomClasses.Devices.LaserModule
{
    /// <summary>
    /// Contains every acessible command that can be used on the Laser module
    /// </summary>
    internal static class LaserCommands
    {
        /// <summary>
        /// Opens Laser module (turns infrared LED ON)
        /// </summary>
        public const char Open = 'O';

        /// <summary>
        /// Closes Laser module (turns infrared LED OFF)
        /// </summary>
        public const char Close = 'C';

        /// <summary>
        /// Gets Status from Laser Module (Temperature and voltage)
        /// </summary>
        public const char Status = 'S';

        /// <summary>
        /// Laser Module Get distance read mode
        /// Speed: Auto
        /// Accuracy: Normal
        /// </summary>
        public const char AutoMode = 'D';

        /// <summary>
        /// Laser Module Get distance read mode
        /// Speed: Slow
        /// Accuracy: Higher
        /// </summary>
        public const char SlowMode = 'M';

        /// <summary>
        /// Laser Module Get distance read mode
        /// Speed: Fast
        /// Accuracy: Lower
        /// </summary>
        public const char FastMode = 'F';
    }
}

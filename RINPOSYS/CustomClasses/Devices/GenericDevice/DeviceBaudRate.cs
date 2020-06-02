namespace RINPOSYS.CustomClasses.Devices.GenericDevice
{
    /// <summary>
    /// Associates Device type to baudrate value
    /// </summary>
    public static class DeviceBaudRate
    {
        public const int Reader = 57600;
        public const string ReaderStr = "57600bps";

        public const int Laser = 19200;
        public const string LaserStr = "19200bps";

        public const int Servo = 9600;
        public const string ServoStr = "9600bps";
    }
}

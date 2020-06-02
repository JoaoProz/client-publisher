using System;

namespace RINPOSYS.CustomClasses.Devices.LaserModule
{
    /// <summary>
    /// Custom exception with laser module related errors
    /// </summary>
    internal class LaserException : Exception
    {
        public int ErrCode;

        public LaserException(string message, int errCode) : base(message)
        {
            ErrCode = errCode;
        }
    }
}

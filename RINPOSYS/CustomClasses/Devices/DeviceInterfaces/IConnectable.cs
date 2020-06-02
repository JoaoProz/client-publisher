
namespace RINPOSYS.CustomClasses.Devices.DeviceInterfaces
{
    /// <summary>
    /// Represents a Device with the capability of connecting/disconnecting
    /// </summary>
    public interface IConnectable
    {
        /// <summary>
        /// Tell Device to Connect
        /// </summary>
        /// <returns></returns>
        bool Connect();

        /// <summary>
        /// Tell Device to Disconnect
        /// </summary>
        /// <returns></returns>
        bool Disconnect();
    }
}

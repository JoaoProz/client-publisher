namespace RINPOSYS.CustomClasses.IOFiles
{
    /// <summary>
    /// Indicates the configuration file type (Devices/MMParameters/Notes/MySQL)
    /// </summary>
    public enum ConfigFileType
    {
        MMParameters = 0,
        Devices = 1,
        Notes = 2,
        MySQL = 3,
        EPCDatasets = 4,
        Log = 5
    }
}

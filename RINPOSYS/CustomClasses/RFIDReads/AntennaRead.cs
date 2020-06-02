namespace RINPOSYS.CustomClasses.RFIDReads
{
    /// <summary>
    /// Represents an antenna and the received signal strength 
    /// </summary>
    public class AntennaRead
    {
        /// <summary>
        /// Antenna that received signal
        /// </summary>
        public Antenna Antenna { get; set; }

        /// <summary>
        /// Obtained Received Signal Strengh Indicator
        /// </summary>
        public double RSSI { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="antenna"></param>
        /// <param name="rssi"></param>
        public AntennaRead(Antenna antenna, double rssi)
        {
            Antenna = antenna;
            RSSI = rssi;
        }

        /// <summary>
        /// Custom ToString()
        /// </summary>
        /// <returns>
        /// Returns Antenna parameters and RSSI
        /// </returns>
        public override string ToString()
        {
            return "\t\t\tID: " + Antenna.ID + "\t(" + Antenna.Position.X + ", " + Antenna.Position.Y + ")\t" + RSSI;
        }
    }
}

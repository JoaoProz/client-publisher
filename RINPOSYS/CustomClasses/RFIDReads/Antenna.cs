using RINPOSYS.CustomClasses.Utils;

namespace RINPOSYS.CustomClasses.RFIDReads
{
    /// <summary>
    /// Rrepresents the antenna connected to the UHFReader
    /// </summary>
    public class Antenna
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Antenna's Position (x,y)
        /// </summary>
        public Position Position { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Antenna(int id, decimal x, decimal y)
        {
            ID = id;
            Position = new Position(x, y);
        }

        /// <summary>
        /// Custom ToString()
        /// </summary>
        /// <returns>
        /// Returns Antenna parameters
        /// </returns>
        public override string ToString()
        {
            return "ID: " + ID + Position.ToString();
        }
    }
}

namespace RINPOSYS.CustomClasses.Utils
{
    /// <summary>
    /// Represents a Position of an Object (Antenna/Tag/Laser)
    /// </summary>
    public class Position
    {
        /// <summary>
        /// X coordinate
        /// </summary>
        public decimal X { get; set; }

        /// <summary>
        /// Y coordinate
        /// </summary>
        public decimal Y { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Position(decimal x, decimal y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Custom ToSting()
        /// </summary>
        /// <returns>
        /// Returns Position parameters
        /// </returns>
        public override string ToString()
        {
            return "(" + X + "; " + Y + ')';
        }
    }
}

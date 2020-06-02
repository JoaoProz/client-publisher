using System.Collections.Concurrent;
using System.Linq;

namespace RINPOSYS.CustomClasses.Utils
{
    /// <summary>
    /// Custom adaptation of a ConcurrentQueue where a limit of elements is set to it
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FixedSizedQueue<T>
    {
        /// <summary>
        /// Generic ConcurrentQueue<double>
        /// </summary>
        readonly ConcurrentQueue<double> customQueue = new ConcurrentQueue<double>();

        /// <summary>
        /// Static queue limit size value
        /// </summary>
        public static int Size { get; set; } = 50;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="size"></param>
        public FixedSizedQueue(int size)
        {
            Size = size;
        }

        /// <summary>
        /// Adds RSSI value to RSSI queue
        /// </summary>
        /// <param name="rssi"></param>
        /// <returns>
        /// Returns Average RSSI value in queue
        /// Returns NegativeInfinity if queue is not full
        /// </returns>
        public double CustomAdd(double rssi)
        {
            CustomEnqueue(rssi);

            if (customQueue.Count != Size)
            {
                /// Queue not full
                
                return double.NegativeInfinity;
            }
            else
            {
                /// Queue is full

                return GetAvg();
            }
        }

        /// <summary>
        /// Iterates every element in queue and obtains RSSI average through that
        /// </summary>
        /// <returns>
        /// Returns Average RSSI value in queue
        /// </returns>
        private double GetAvg()
        {
            double sum = 0;

            for (int i = 0; i < customQueue.Count - 1; i++)
            {
                sum += customQueue.ElementAt(i);
            }

            double avg = sum / (customQueue.Count - 1);

            return avg;
        }

        /// <summary>
        /// Custom Enqueue
        /// </summary>
        /// <param name="obj"></param>
        /// <remarks>
        /// Enqueues obj.
        /// Dequeues last objects from queue if queue is full.
        /// </remarks>
        private void CustomEnqueue(double obj)
        {
            customQueue.Enqueue(obj);

            while (customQueue.Count > Size)
            {
                customQueue.TryDequeue(out double outObj);
            }
        }
    }
}

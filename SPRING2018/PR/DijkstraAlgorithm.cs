using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorithm
{
    public interface IPriorityQueue<TKey>
    {
        bool TryGetValue(TKey key, out double value);
        void Add(TKey key, double value);
        void Delete(TKey key);
        void Update(TKey key, double newValue);
        Tuple<TKey, double> ExtractMin();
    }

    public class Program
    {
        public static List<Node> DijkstraAlgorithm(
            Graph graph,
            Dictionary<Edge, double> weights,
            Node start,
            Node end,
            IPriorityQueue<Node> queue
            )
        {
            var track = new Dictionary<Node, Node>();
            track[start] = null;
            queue.Add(start, 0);

            while (true)
            {
                var toOpenPair = queue.ExtractMin();
                if (toOpenPair == null) return null;
                var toOpen = toOpenPair.Item1;
                var price = toOpenPair.Item2;
                if (toOpen == end) break;

                foreach (var e in toOpen.IncidentEdges.Where(z => z.From == toOpen))
                {
                    var currentPrice = price + weights[e];
                    var nextNode = e.OtherNode(toOpen);
                    double oldPrice;
                    var nodeInQueue = queue.TryGetValue(nextNode, out oldPrice);
                    if (!nodeInQueue || oldPrice > currentPrice)
                    {
                        queue.Update(nextNode, currentPrice);
                        track[nextNode] = toOpen;
                    }
                }
            }
            return GetPathTo(end, track);
        }

        private static List<Node> GetPathTo(Node end, Dictionary<Node, Node> track)
        {
            var result = new List<Node>();
            while (end != null)
            {
                result.Add(end);
                end = track[end];
            }
            result.Reverse();
            return result;
        }
    }
}

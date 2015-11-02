using System.Collections.Generic;
using System.Linq;

namespace Problem2
{
    public static class NodeExtensions
    {
        public static IEnumerable<string> Values(this IEnumerable<StNode> nodes)
        {
            return nodes.Select(n => n.Value);
        }
    }
}
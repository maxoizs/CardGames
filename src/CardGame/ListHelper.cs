using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{

    /// <summary>
    /// List extensions
    /// </summary>
    public static class ListExtensions
    {
        public static List<T> ProduceShuffle<T>(this IEnumerable<T> original, Random random)
        {
            return original.OrderBy(x => random.NextDouble()).ToList();
        }
    }
}
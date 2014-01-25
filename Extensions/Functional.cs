using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Extensions
{
    /// <summary>
    /// The functional class adds some additional functional capabilities to the existing Linq
    /// libraries including lazy aggregation, unfolding and memoization.
    /// </summary>
    public static class Functional
    {
        public static IEnumerable<TAccumulate> LazyAggregate<T, TAccumulate>(this IEnumerable<T> sequence, TAccumulate seed, Func<T, TAccumulate, TAccumulate> aggregator)
        {
            var accumulatedValue = seed;
            yield return seed;

            foreach (var item in sequence)
            {
                accumulatedValue = aggregator(item, accumulatedValue);
                yield return accumulatedValue;
            }
        }

        public static IEnumerable<T> Unfold<T>(this IList<T> seedList, Func<IList<T>, T> generator)
        {
            List<T> previousItems = new List<T>(seedList);

            foreach (T item in seedList)
            {
                yield return item;
            }

            while (true)
            {
                T newItem = generator(previousItems);
                previousItems.Add(newItem);
                yield return newItem;
            }
        }

        public static IEnumerable<T> Unfold<T>(this T seed, Func<T, T> generator)
        {
            yield return seed;

            T current = seed;

            while (true)
            {
                current = generator(current);
                yield return current;
            }
        }

        public static Func<T, TResult> Memoize<T, TResult>(this Func<T, TResult> function)
        {
            var cache = new Dictionary<T, TResult>();

            return (T arg) =>
            {
                TResult result;
                if (cache.TryGetValue(arg, out result))
                {
                    return result;
                }
                else
                {
                    result = function(arg);
                    cache.Add(arg, result);
                    return result;
                }
            };
        }
    }
}

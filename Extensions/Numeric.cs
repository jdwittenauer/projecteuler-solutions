using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace Extensions
{
    /// <summary>
    /// The numeric class provides assorted extension methods, functions and number generators
    /// for dealing with common calculations and mathematical processes.
    /// </summary>
    public static class Numeric
    {
        #region Numeric Methods - Integer
        public static bool IsPrime(int number)
        {
            for (long i = 3; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsAmicable(int number)
        {
            int sumOfDivisors = 0;
            for (int i = 1; i <= (number / 2); i++)
            {
                if (number.IsDivisibleBy(i))
                {
                    sumOfDivisors += i;
                }
            }

            int pair = sumOfDivisors;
            sumOfDivisors = 0;
            for (int i = 1; i <= (pair / 2); i++)
            {
                if (pair.IsDivisibleBy(i))
                {
                    sumOfDivisors += i;
                }
            }

            if ((number == sumOfDivisors) && (number != pair))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsAbundant(int number)
        {
            int sumOfDivisors = 0;
            for (int i = 1; i <= (number / 2); i++)
            {
                if (number.IsDivisibleBy(i))
                {
                    sumOfDivisors += i;
                }
            }

            if (sumOfDivisors > number)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsDivisibleBy(this int number, int factor)
        {
            return (number % factor == 0);
        }

        public static bool IsPalindromic(this int number)
        {
            char[] characters = number.ToString().ToCharArray();
            return characters.SequenceEqual(characters.Reverse());
        }

        public static int GreatestCommonDenominator(this int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return GreatestCommonDenominator(b, a % b);
            }
        }

        public static int LeastCommonMultiple(this int a, int b)
        {
            return (a * b) / GreatestCommonDenominator(a, b);
        }

        public static int Product(this IEnumerable<int> factors)
        {
            int product = 1;

            foreach (var factor in factors)
            {
                product *= factor;
            }

            return product;
        }

        public static int NumberOfFactors(this int number)
        {
            int count = 0;

            for (int i = 1; i * i <= number; i++)
            {
                if (number.IsDivisibleBy(i))
                {
                    count += 2;

                    if (number / i == i)
                    {
                        count--;
                    }
                }
            }

            return count;
        }

        public static IEnumerable<int> Digits(this int number)
        {
            return number.ToString().ToCharArray().Select(character => int.Parse(character.ToString()));
        }

        public static IList<PrimeFactor> PrimeFactors(this int number)
        {
            return ContinueFactorisation(new List<PrimeFactor> { PrimeFactor.Init }, number);
        }

        public static IEnumerable<int> To(this int first, int last)
        {
            if (first == last)
            {
                yield return first;
            }
            else if (first < last)
            {
                for (var i = first; i <= last; i++)
                {
                    yield return i;
                }
            }
            else
            {
                for (var i = first; i >= last; i--)
                {
                    yield return i;
                }
            }
        }
        #endregion

        #region Numeric Methods - Long
        public static bool IsPrime(long number)
        {
            for (long i = 3; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsAmicable(long number)
        {
            int sumOfDivisors = 0;
            for (int i = 1; i <= (number / 2); i++)
            {
                if (number.IsDivisibleBy(i))
                {
                    sumOfDivisors += i;
                }
            }

            int pair = sumOfDivisors;
            sumOfDivisors = 0;
            for (int i = 1; i <= (pair / 2); i++)
            {
                if (pair.IsDivisibleBy(i))
                {
                    sumOfDivisors += i;
                }
            }

            if ((number == sumOfDivisors) && (number != pair))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsAbundant(long number)
        {
            int sumOfDivisors = 0;
            for (int i = 1; i <= (number / 2); i++)
            {
                if (number.IsDivisibleBy(i))
                {
                    sumOfDivisors += i;
                }
            }

            if (sumOfDivisors > number)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsDivisibleBy(this long number, long factor)
        {
            return (number % factor == 0);
        }

        public static bool IsPalindromic(this long number)
        {
            char[] characters = number.ToString().ToCharArray();
            return characters.SequenceEqual(characters.Reverse());
        }

        public static long GreatestCommonDenominator(this long a, long b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return GreatestCommonDenominator(b, a % b);
            }
        }

        public static long LeastCommonMultiple(this long a, long b)
        {
            return (a * b) / GreatestCommonDenominator(a, b);
        }

        public static long Product(this IEnumerable<long> factors)
        {
            long product = 1;

            foreach (var factor in factors)
            {
                product *= factor;
            }

            return product;
        }

        public static int NumberOfFactors(this long number)
        {
            int count = 0;

            for (int i = 1; i * i <= number; i++)
            {
                if (number.IsDivisibleBy(i))
                {
                    count +=2;

                    if (number / i == i)
                    {
                        count--;
                    }
                }
            }

            return count;
        }

        public static IEnumerable<long> Digits(this long number)
        {
            return number.ToString().ToCharArray().Select(character => long.Parse(character.ToString()));
        }

        public static IList<PrimeFactor> PrimeFactors(this long number)
        {
            return ContinueFactorisation(new List<PrimeFactor> { PrimeFactor.Init }, number);
        }

        public static IEnumerable<long> To(this long first, long last)
        {
            if (first == last)
            {
                yield return first;
            }
            else if (first < last)
            {
                for (var i = first; i <= last; i++)
                {
                    yield return i;
                }
            }
            else
            {
                for (var i = first; i >= last; i--)
                {
                    yield return i;
                }
            }
        }
        #endregion

        #region Numeric Methods - Other
        public static bool IsInteger(this string value)
        {
            int number;
            return int.TryParse(value, out number);
        }

        public static bool IsLong(this string value)
        {
            long number;
            return long.TryParse(value, out number);
        }

        public static IEnumerable<T> RangeFrom<T>(this IList<T> list, int startIndex, int count)
        {
            for (var i = startIndex; i < startIndex + count; i++)
            {
                yield return list[i];
            }
        }

        public static IEnumerable<T> Concat<T>(this IEnumerable<IEnumerable<T>> sequences)
        {
            return sequences.SelectMany(sequence => sequence);
        }

        public static IEnumerable<T> Concat<T>(this IEnumerable<T[]> sequences)
        {
            return Concat(sequences.Cast<IEnumerable<T>>());
        }

        public static T MaxItem<T, TCompare>(this IEnumerable<T> sequence, Func<T, TCompare> comparatorSelector) where TCompare : IComparable<TCompare>
        {
            T max = sequence.First();
            TCompare maxComparator = comparatorSelector(max);

            foreach (var item in sequence)
            {
                var comparator = comparatorSelector(item);

                if (comparator.CompareTo(maxComparator) > 0)
                {
                    max = item;
                    maxComparator = comparator;
                }
            }

            return max;

        }

        public static IEnumerable<IEnumerable<T>> Zip<T>(this IEnumerable<IEnumerable<T>> sequences)
        {
            var enumerators = sequences.Select(sequence => sequence.GetEnumerator()).ToList();

            var activeEnumerators = new List<IEnumerator<T>>();
            var items = new List<T>();

            while (enumerators.Count > 0)
            {
                items.Clear();
                activeEnumerators.Clear();

                foreach (var enumerator in enumerators)
                {
                    if (enumerator.MoveNext())
                    {
                        items.Add(enumerator.Current);
                        activeEnumerators.Add(enumerator);
                    }
                }

                if (items.Count > 0)
                {
                    yield return items;
                }

                enumerators.Clear();
                enumerators.AddRange(activeEnumerators);
            }
        }

        public static IEnumerable<int> SumNumbers(IEnumerable<int> number1, IEnumerable<int> number2)
        {  
            var numbers = new[] {number1, number2};

            return numbers.Zip().Aggregate(new { Digits = Stack<int>.Empty, CarryOver = 0 }, 
                (previousResult, columnDigits) => 
            {
                var columnSum = columnDigits.Sum() + previousResult.CarryOver;
                var nextDigit = columnSum % 10;
                var carryOver = columnSum / 10;
                return new { Digits = previousResult.Digits.Push(nextDigit), CarryOver = carryOver };
            }, (completeSum) => completeSum.CarryOver == 0 ? completeSum.Digits.Reverse() 
                : completeSum.CarryOver.Digits().Concat(completeSum.Digits).Reverse());
        }
        #endregion

        #region Read/Validate Methods
        public static IEnumerable<string> ReadLines(this TextReader reader)
        {
            while (true)
            {
                yield return reader.ReadLine();
            }
        }

        public static IEnumerable<T> Validate<T>(this IEnumerable<T> sequence, Func<T, bool> predicate, string invalidItemMessage)
        {
            foreach (var item in sequence)
            {
                if (predicate(item))
                {
                    yield return item;
                }
                else
                {
                    Console.WriteLine(invalidItemMessage);
                }
            }
        }
        #endregion

        #region Pascal's Triangle
        public static long GetPascalsTriangleEntry(int row, int column)
        {
            return Functional.Unfold(new { Entry = 1L, Column = 1 }, previous => new
                {
                    Entry = (previous.Entry * (row + 1 - previous.Column)) / previous.Column,
                    Column = previous.Column + 1
                })
            .SkipWhile(item => item.Column <= column)
            .First()
            .Entry;
        }
        #endregion

        #region Number Generators
        public static IEnumerable<long> TriangleNumbers()
        {
            yield return 1;
            long number = 1, count = 2;

            while (true)
            {
                number = number + count;
                yield return number;
                count++;
            }
        }

        public static IEnumerable<long> PrimeNumbers()
        {
            yield return 2;
            yield return 3;
            long current = 5;

            while (true)
            {
                if (IsPrime(current))
                {
                    yield return current;
                }
                current += 2;
            }
        }

        public static IEnumerable<long> FibonacciTerms(long firstTerm, long secondTerm)
        {
            yield return firstTerm;
            yield return secondTerm;
            long previous = firstTerm;
            long current = secondTerm;

            while (true)
            {
                long next = previous + current;
                previous = current;
                current = next;
                yield return current;
            }
        }
        #endregion

        #region Private Methods
        private static IEnumerable<long> Range(long first, long last)
        {
            if (first == last)
            {
                yield return first;
            }
            else if (first < last)
            {
                for (long l = first; l <= last; l++)
                {
                    yield return l;
                }
            }
            else
            {
                for (long l = first; l >= last; l--)
                {
                    yield return l;
                }
            }
        }

        private static IList<PrimeFactor> ContinueFactorisation(IList<PrimeFactor> partialFactorisation, long remainder)
        {
            var factorGreaterThan = partialFactorisation.Last().Prime;

            long nextFactor = Range(factorGreaterThan + 1, remainder)
                .SkipWhile(x => remainder % x > 0).FirstOrDefault();

            if (nextFactor == remainder)
            {
                return ExtendList<PrimeFactor>(partialFactorisation, new PrimeFactor { Prime = remainder, Multiplicity = 1 });
            }
            else
            {
                long multiplicity = Enumerable.Range(1, Int32.MaxValue).TakeWhile(x => remainder % (long)Math.Pow(nextFactor, x) == 0).Last();
                long quotient = remainder / (long)Math.Pow(nextFactor, multiplicity);

                PrimeFactor nextPrimeFactor = new PrimeFactor { Prime = nextFactor, Multiplicity = multiplicity };
                var extendedList = ExtendList<PrimeFactor>(partialFactorisation, nextPrimeFactor);

                if (quotient == 1)
                {
                    return extendedList;
                }
                else
                {
                    return ContinueFactorisation(extendedList, quotient);
                }
            }
        }

        private static IList<T> ExtendList<T>(IList<T> list, T additionalItem)
        {
            List<T> extendedList = new List<T>(list);
            extendedList.Add(additionalItem);

            return extendedList;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareVersion.Logic
{
    public static class Version
    {
        /// <summary>
        /// Compare two software versions, returning true if firstVersion is larger.
        /// </summary>
        /// <param name="firstVersion"></param>
        /// <param name="secondVersion"></param>
        /// <returns></returns>
        public static bool GreaterThanOrEqual(string firstVersion, string secondVersion)
        {
            var firstVersionArray = CreateArray(firstVersion);
            var secondVersionArray = CreateArray(secondVersion);

            var minimum = GetMinimum(firstVersionArray, secondVersionArray);

            var areEqual = true;
            var firstIsLarger = true;
            var i = 0;

            do
            {
                var first = 0;
                if (firstVersionArray.Count > i)
                    first = firstVersionArray[i];

                var second = 0;
                if (secondVersionArray.Count > i)
                    second = secondVersionArray[i];

                if (first < second)
                {
                    areEqual = false;
                    firstIsLarger = false;
                }
                else if (first > second)
                {
                    areEqual = false;
                    firstIsLarger = true;
                }

                i++;
            } while (areEqual);

            return firstIsLarger; 
        }

        private static List<int> CreateArray(string version)
        {
            if (version.EndsWith("."))
                version = $"{version}0";

            if (version.StartsWith("."))
                version = $"0{version}";

            return version.Split('.').Select(n => Int32.Parse(n)).ToList();
        }

        private static int GetMaximum<T>(IEnumerable<T> a, IEnumerable<T> b)
        {
            var aCount = a.Count();
            var bCount = b.Count();

            if (aCount >= bCount)
                return aCount;
            else
                return bCount;
        }

        private static int GetMinimum<T>(IEnumerable<T> a, IEnumerable<T> b)
        {
            var aCount = a.Count();
            var bCount = b.Count();

            if (aCount <= bCount)
                return aCount;
            else
                return bCount;
        }

    }
}

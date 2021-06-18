using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareVersion.Logic
{
    public static class Version
    {
        public static bool Compare(string firstVersion, string secondVersion)
        {
            var firstVersionArray = CreateArray(firstVersion);
            var secondVersionArray = CreateArray(secondVersion);

            var minimum = GetMinimum(firstVersionArray, secondVersionArray);

            var areEqual = true;
            var firstIsLarger = true;
            var i = 0;

            do
            {
                

                var first = firstVersionArray[i];
                var second = secondVersionArray[i];

                if (first < second)
                {
                    areEqual = false;
                    firstIsLarger = false;
                }
                else if (first > second)
                {
                    areEqual = false;
                    //firstIsLarger is already set to true, but lets make it explicit. 
                    firstIsLarger = true;
                }

                i++;
            } while (areEqual);


            return firstIsLarger; 
        }

        private static List<int> CreateArray(string version)
        {
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

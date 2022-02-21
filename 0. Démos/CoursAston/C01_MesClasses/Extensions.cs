using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C01_MesClasses
{
    public static class Extensions
    {
        public static string ToCapitalize(this string source)
        {
            return source.Substring(0, 1).ToUpper() + source.Substring(1, source.Length -1).ToLower();
        }

        public static List<int> SortInferiorTo(this List<int> source, int maxValue)
        {
            List<int> result = new List<int>();

            foreach (int item in source) if(item <= maxValue) result.Add(item);

            return result;
        }

        public static List<T> SortMyList<T>(this List<T> source, Func<T, bool> predicate)
        {
            List<T> result = new List<T>();

            foreach (var item in source) if(predicate(item)) result.Add(item);

            return result;
        }
    }
}

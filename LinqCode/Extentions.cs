using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LinqCode
{
    internal static class Extentions
    {
        public static IEnumerable<T> Diff<T>(this IEnumerable<T> list1, IEnumerable<T> list2, Func<T,T,bool> func)
        {
            var diff = list1.Where(x => !list2.Any(y => func(x, y))).ToList();
            return diff;
        }

        public static List<List<T>> ChunkList<T>(IEnumerable<T> data, int chunkSize)
        {
            return data
              .Select((x, i) => new { Index = i, Value = x })
              .GroupBy(x => x.Index / chunkSize)
              .Select(x => x.Select(v => v.Value).ToList())
              .ToList();
        }
    }
}

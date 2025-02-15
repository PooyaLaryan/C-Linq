using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCode
{
    internal class NewLinqCode
    {
        public static void Run(IEnumerable<Person> people)
        {
            var p = people.Take(1..4).ToList();
        }

        public static void TestNullInList()
        {

        }
    }
}

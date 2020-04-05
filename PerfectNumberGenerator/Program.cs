// Perfect Number Generator
// Michael Hollas, 2020/4/2
// ---------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;

namespace PerfectNumberGenerator
{
    /// <summary>
    /// Contains the main fuction:
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var gen = new PerfectNumbers();
            List<BigInteger> perfectNumbers = gen.Generate(20);
            PerfectNumbers.Show(perfectNumbers);
            //Console.WriteLine(String.Join(", ", GeneratePerfectNumbers.Validate(perfectNumbers)));
        }
    }
}

using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PerfectNumberGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var gen = new GeneratePerfectNumbers(9);
            gen.Show();
            Console.WriteLine(String.Join(", ", gen.Validate()));

             

        }
    }
}

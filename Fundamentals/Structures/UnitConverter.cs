using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    public class UnitConverter
    {
        static Dictionary<string, double> units = new Dictionary<string, double>
        {
            { "mega", 1000000 },
            { "kilo", 1000 },
            { "base", 1 },
            { "mili", 0.001 },
            { "micro", 0.000001 },
        };



        public static double Calculate(double value, string from, string to)
        {
            var fromRate = units[from];
            var toRate = units[to];

            var result = value * fromRate / toRate;


            return result;
        }
    }
}

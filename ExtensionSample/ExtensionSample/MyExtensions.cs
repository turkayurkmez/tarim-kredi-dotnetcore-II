using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionSample
{
    public static class MyExtensions
    {
        public static double GetSquare(this int value)
        {
            return value * value;
        }

        public static string RemoveSpaces(this string value)
        {
            return value.Replace(" ", "");
        }
    }
}

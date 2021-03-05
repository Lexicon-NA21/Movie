using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Extensions
{
    public static class StringExtensions
    {

        public static bool IsSame(this string value, string input)
        {
            return value == input;
        }
    }
}

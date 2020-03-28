using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoliScheme.Core
{
    public static class StringHelper
    {

        public static IEnumerable<Char> TakeFromLastWhile(this string source, Func<char, bool> predicate)
        {
            string ret = "";
            for (int i = source.Length - 1; i > 0; i--)
            {
                if (predicate(source[i]))
                    ret += source[i];
                else
                    break;
            }

            return ret.ToCharArray().Reverse();
        }
    }
}

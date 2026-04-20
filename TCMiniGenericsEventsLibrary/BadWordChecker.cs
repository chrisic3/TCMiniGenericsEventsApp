using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCMiniGenericsEventsLibrary
{
    internal static class BadWordChecker
    {
        internal static bool BadWordCheck(string word)
        {
            bool output = false;

            if (word.ToLower().Contains("darn") || word.ToLower().Contains("heck"))
            {
                output = true;
            }

            return output;
        }
    }
}

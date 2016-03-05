using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Compile.TypesToBeDecompiled
{
    public class CanYouDecompileMe
    {
        public void CanYouSerializeThisMethod(string input)
        {
            int largeNumber = 3333;
            for (int i = 0; i < largeNumber; i++)
            {

            }
            input = input.Replace("A", "B");

            Regex r = new Regex("");
            input = r.Replace(input, "xxx");

           

        }
    }
}

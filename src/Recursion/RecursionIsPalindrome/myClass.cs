using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionIsPalindrome
{
    public class myClass
    {
        public static bool IsPalindrome(string input)
        {
            if (input.Length == 0 || input.Length == 1)
            {
                return true;
            }

            if (input[0] == input[input.Length - 1])
            {
                return IsPalindrome(input.Substring(1, (input.Length -1)));
            }
            return false;
        }
    }
}

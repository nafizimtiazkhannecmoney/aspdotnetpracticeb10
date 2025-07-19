using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionReverseString
{
    public class myClass
    {
        //public static string ReverseString(string str)
        //{
        //    // Base case: if the input string is empty or has length 1, return the string itself
        //    if (string.IsNullOrEmpty(str) || str.Length == 1)
        //    {
        //        return str;
        //    }

        //    // Recursive case: return the last character concatenated with the reversed substring
        //    return ReverseString(str.Substring(1) + str[0]);
        //}

        public static string ReverseString(string str)
        {
            if (str == "")
            {
                return "";
            }

            return ReverseString(str.Substring(1)) + str[0];
        }

    }
}

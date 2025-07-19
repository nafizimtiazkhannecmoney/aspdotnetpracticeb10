using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    public class REQ
    {
        public static void geek1(int n)
        {
            n = n - 1;
           
            if (n>0)
            {
                Console.Write($"{n} "); //1st Statement 
                // n = n - 1;
                //int x = n - 1;
                geek1(n);    //2nd statement 

            }
        }
    }
}

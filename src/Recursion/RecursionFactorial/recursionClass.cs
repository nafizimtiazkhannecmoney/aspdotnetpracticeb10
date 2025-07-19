using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionFactorial
{
    public class recursionClass
    {
        public static int facto(int n)
        {
            if (n == 0)
            {
                return (1);
            }
            else 
            {
                //n = n - 1;
                int f = (n * facto(n-1));
                return f;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Factory
{
    internal class Pizza : Food
    {
        public bool IsSpicy { get; set; }
        public bool IsItalian { get; set; }
        public static Food prepare()
        {
                   new Pizza { Name = "Brazilian", Price = 200, IsItalian = true, IsSpicy = true };
            return new Pizza { Name = "Italian", Price = 200, IsItalian = true, IsSpicy = true };
        }
    }
}

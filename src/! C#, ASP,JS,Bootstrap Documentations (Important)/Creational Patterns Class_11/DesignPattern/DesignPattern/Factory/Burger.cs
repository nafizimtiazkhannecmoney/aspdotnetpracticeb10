using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Factory
{
    internal class Burger : Food
    {
        public bool HasCheese { get; set; }
        public static Food prepare()
        {
            return new Burger
            {
                HasCheese = true,
                Name = "Chicken",
                Price = 1,
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Prototype
{
    internal class Product : ICloneable
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }



        public object Clone()
        {
            return Copy();
        }


        // Think like copy Constructor
        public Product Copy()
        {
            return new Product
            {
                Name = Name,
                Price = Price,
                Color = Color,
                Description = Description
            };
        }
    }
}

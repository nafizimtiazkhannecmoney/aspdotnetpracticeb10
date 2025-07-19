using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Factory
{
    internal class FoodFactory
    {
        public Food FrepareFood(string foodType)
        {
            if(foodType == "Burger")
            {
                return Burger.prepare();
            }
            else 
                return Pizza.prepare();
        }
    }
}

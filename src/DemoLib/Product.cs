namespace DemoLib
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public double GetDiscount(double price, double discount)
        {
            return price * discount/100;
        }
        public int additionFunc(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}

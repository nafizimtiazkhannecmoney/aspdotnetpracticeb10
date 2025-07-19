using System;
using System.Collections;

class Program
{
    static void Main()
    {
        //List<int> value = new List<int>  { 1, 2, 3, 4, 5 };
        //List<string> value = new List<string> { "sd", "asdasd", "asdas", "sd", "sd" };
        List<bool> value = new List<bool> { true, false, true, false, true };

        if (value is IEnumerable enumerable)
        {
            Console.WriteLine("Value is an IEnumerable collection:");
            foreach (var item in enumerable)
            {
                Console.WriteLine(item);
            }
        }
        else
        {
            Console.WriteLine("Value is not an IEnumerable collection.");
        }
    }
}

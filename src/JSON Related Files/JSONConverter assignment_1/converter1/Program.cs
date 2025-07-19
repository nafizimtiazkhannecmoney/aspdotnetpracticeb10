using converter1;
using System.Reflection;
using System.Text;

Console.WriteLine("Hello, World!");

//StringBuilder sb = new StringBuilder("My name is methos");
//Console.WriteLine(sb[3]);

Course course = new Course()
{
    Title = "ASP.NET",
    Fees = 30000,
    Teacher = new Instructor
    {
       // Name = "Jalal Uddin",
        Email = "jalaluddin@example.com"
    }
};

string json = Jsonformatter.Convert(course);
Console.WriteLine(json);

List<Course> list = new List<Course>();
var p = list.GetType();


//foreach (var pi in p)
//{
//    Console.WriteLine(pi);
//}
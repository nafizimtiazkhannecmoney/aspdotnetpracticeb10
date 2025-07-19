using converter1;
using System.Reflection;
using System.Text;

//Console.WriteLine("Hello, World!");

////StringBuilder sb = new StringBuilder("My name is methos");
////Console.WriteLine(sb[3]);

//Course course = new Course()
//{
//    Title = "ASP.NET",
//    Fees = 30000,
//    Teacher = new Instructor
//    {
//       // Name = "Jalal Uddin",
//        Email = "jalaluddin@example.com"
//    }
//};

//string json = Jsonformatter.Convert(course);
//Console.WriteLine(json);

//List<Course> list = new List<Course>();
//var p = list.GetType();



////=========================================================================================================

//Course course = new Course
//{
//    Title = "Asp.net",
//    Fees = 30000,
//    Teacher = new Instructor
//    {
//        Name = "Jalaluddin",
//        Email = "jalaluddin@example.com"
//    },
//    Topics = new List<Topic>
//            {
//                new Topic
//                {
//                    Title = "Introduction to ASP.NET",
//                    Description = "Learn the basics of ASP.NET framework",
//                    Sessions = new List<Session>
//                    {
//                        new Session { DurationInHour = 2, LearningObjective = "Understand ASP.NET fundamentals" },
//                        new Session { DurationInHour = 3, LearningObjective = "Build a simple ASP.NET application" }
//                    }
//                },
//                new Topic
//                {
//                    Title = "Advanced ASP.NET",
//                    Description = "Deep dive into ASP.NET features",
//                    Sessions = new List<Session>
//                    {
//                        new Session { DurationInHour = 2, LearningObjective = "Learn about ASP.NET MVC" },
//                        new Session { DurationInHour = 3, LearningObjective = "Implement authentication and authorization" }
//                    }
//                }
//            }
//};

Course course2 = new Course
{
    Title = "C#",
    Teacher = new Instructor
    {
        Name = "Jalal Uddin",
        Email = "csharp@gmail.com",
    },
    Topics = new List<Topic>
    {
        new Topic
        {
            Title = "Loops",
            Description = "For, Foreach, while, do",
            Sessions = new List<Session>
            {
                new Session{ DurationInHour = 2, LearningObjective = "Understand Loops" },
                new Session{ DurationInHour = 3, LearningObjective = "Understand flow"}
            }
        },
        new Topic
        {
            Title = "Strings",
            Description = "string builder , string",
            Sessions = new List<Session>
            {
                new Session{ DurationInHour = 2, LearningObjective = "string builder " },
                new Session{ DurationInHour = 3, LearningObjective = "Understand string"}
            }
        }
    }
};


string json = Jsonformatter.Convert(course2);
Console.WriteLine(json);

//==================================================================================================================

//ArrayNormal arrayNormal = new ArrayNormal
//{
//    array = [1, 2, 3, 4],
//    array2 = ["asd", "asdad", "232323"]
//};

//string json2 = Jsonformatter.Convert(arrayNormal);
//Console.WriteLine(json2);



//int[] k = [1, 2, 3];
//Array ab = (Array)k;
//Console.WriteLine(ab.GetValue(2));
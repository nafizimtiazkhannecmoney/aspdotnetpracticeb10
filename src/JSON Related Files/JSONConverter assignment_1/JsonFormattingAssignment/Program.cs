using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using converter1;
using JsonFormattingAssignment;


//Console.WriteLine("Hello, World!");



////StringBuilder sb = new StringBuilder("My name is methos");
////Console.WriteLine(sb[3]);


//************************************************************************************

Course course = new Course()
{
    Title = "ASP.NET",
    Fees = 30000,
    Teacher = new Instructor
    {
        Name = "Jalal Uddin",
        Email = "jalaluddin@example.com",
        PresentAddress = new Address
        {
            Street = "21 Street",
            City = "Dhaka",
            Country = "Bangladesh"
        },
        PermanentAddress = new Address
        {
            Street = "21 Street",
            City = "Dhaka",
            Country = "Bangladesh"
        },
        PhoneNumbers = new List<Phone>
        {
            new Phone { Number = "123456789014", CountryCode = "+880", Extension = "231" },
            new Phone { Number = "123456789121", CountryCode = "+880", Extension = "231" },
            new Phone { Number = "123456123456", CountryCode = "+880", Extension = "231" },
            new Phone { Number = "123456789123", CountryCode = "+880", Extension = "231" }
        }
    },
    Topics = new List<Topic>
    {
        new Topic 
        {   Title = "title 1", 
            Description = "Description 1", 
            Sessions = new List<Session> 
            { 
                new Session { DurationInHour = 2, LearningObjective = "Learn Title 1" },
                new Session { DurationInHour = 1, LearningObjective = "Learn Title 1.1"},
                new Session { DurationInHour = 3, LearningObjective = "Learn Title 1.2"},
                new Session { DurationInHour = 1, LearningObjective = "Learn Title 1.3"},
                new Session { DurationInHour = 4, LearningObjective = "Learn Title 1.4"}
            } 
        },
        new Topic
        {
            Title = "title 2",
            Description = "Description 2",
            Sessions = new List<Session>
            {
                new Session { DurationInHour = 2, LearningObjective = "Learn Title 2" },
                new Session { DurationInHour = 1, LearningObjective = "Learn Title 2.1" },
                new Session { DurationInHour = 3, LearningObjective = "Learn Title 2.2"},
                new Session { DurationInHour = 1, LearningObjective = "Learn Title 2.3"},
                new Session { DurationInHour = 1, LearningObjective = "Learn title 2.4"}
            }
        }
    },
    Tests = new List<AdmissionTest>
    {
        new AdmissionTest { StartDateTime = new DateTime(2022,12,1), EndDateTime = new DateTime(2023,12,1), TestFees = 1200  },
        new AdmissionTest { StartDateTime = new DateTime(2000,12,1), EndDateTime = new DateTime(2023,1,01), TestFees = 1100  }
    }
};

string json = JsonFormatter.Convert(course);
Console.WriteLine(json);
//************************************************************************************




//----------------------------------------------------
//List<Course> list = new List<Course>();
//var p = list.GetType();
//----------------------------------------------------



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



//Course course2 = new Course
//{
//    Title = "C#",
//    Teacher = new Instructor
//    {
//        Name = "Jalal Uddin",
//        Email = "csharp@gmail.com",
//    },
//    Topics = new List<Topic>
//    {
//        new Topic
//        {
//            Title = "Loops",
//            Description = "For, Foreach, while, do",
//            Sessions = new List<Session>
//            {
//                new Session{ DurationInHour = 2, LearningObjective = "Understand Loops" },
//                new Session{ DurationInHour = 3, LearningObjective = "Understand flow"}
//            }
//        },
//        new Topic
//        {
//            Title = "Strings",
//            Description = "string builder , string",
//            Sessions = new List<Session>
//            {
//                new Session{ DurationInHour = 2, LearningObjective = "string builder " },
//                new Session{ DurationInHour = 3, LearningObjective = "Understand string"}
//            }
//        }
//    }
//};


//string json = JsonFormatter.Convert(course2);
//Console.WriteLine(json);

//==================================================================================================================

//ArrayNormal arrayNormal = new ArrayNormal
//{
//    array = [1, 2, 3, 4],
//    array2 = ["asd", "asdad", "232323"]
//};

//string json2 = JsonFormatter.Convert(arrayNormal);
//Console.WriteLine(json2);



//int[] k = [1, 2, 3];
//Array ab = (Array)k;
//Console.WriteLine(ab.GetValue(2));
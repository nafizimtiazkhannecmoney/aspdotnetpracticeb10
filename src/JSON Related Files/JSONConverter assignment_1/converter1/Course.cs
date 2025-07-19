using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace converter1
{
    public class Course
    {
        public string Title { get; set; }
        public Instructor Teacher { get; set; }
        public double Fees { get; set; }
    }
}

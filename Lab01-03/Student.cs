using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_03
{
    public class Student : Person
    {
        public string Faculty { get; set; }
        public double GPA { get; set; }

        public Student() { }

        public Student(string id, string name, string faculty, double gpa)
            : base(id, name)
        {
            Faculty = faculty;
            GPA = gpa;
        }
    }
}

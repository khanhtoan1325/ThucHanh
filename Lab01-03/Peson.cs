using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_03
{
    public class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Person() { }

        public Person(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

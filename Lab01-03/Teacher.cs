using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_03
{
    public class Teacher : Person
    {
        public string Address { get; set; }

        public Teacher() { }

        public Teacher(string id, string name, string address)
            : base(id, name)
        {
            Address = address;
        }
    }
}

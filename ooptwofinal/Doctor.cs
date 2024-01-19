using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptwofinal
{
    public class Doctor : IDoctor
    {
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string ID { get; set; }
        public string ContactNumber { get; set; }

        public Doctor(string name, string specialty, string id, string contactNo)
        {
            Name = name;
            Specialty = specialty;
            ID = id;
            ContactNumber = contactNo;
        }
    }
}

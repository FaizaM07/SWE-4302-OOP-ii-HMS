using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptwofinal
{
    public class Patient : IPatient
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string ID { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }

        public decimal Balance { get; set; }




        public Patient(string name, int age, string id, string gender, string contactNo, string address)
        {
            Name = name;
            Age = age;
            ID = id;
            Gender = gender;
            ContactNumber = contactNo;
            Address = address;

            Balance = new Random().Next(100, 1000);
        }




    }
}

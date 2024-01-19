using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptwofinal
{
    public class Manager:IManager
    {
        public List<Doctor> doctors = new List<Doctor>();
        public void AddDoctor()
        {
            Console.Write("Enter Doctor's Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Specialty: ");
            string specialty = Console.ReadLine();

            Console.Write("Enter ID: ");
            string id = Console.ReadLine();

            Console.Write("Enter Contact No: ");
            string contactNo = Console.ReadLine();

            doctors.Add(new Doctor(name, specialty, id, contactNo));
            Console.WriteLine("Doctor added successfully.");
        }
        public List<Doctor> Lists()
        { return doctors; }

    }
}

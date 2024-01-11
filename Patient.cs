using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System
{
    class Patient
    {
        public int PatientID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }

        public string Disease { get; set; }
    }
}

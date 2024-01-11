using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System
{
    interface IAppointmentViewer
    {




        List<Appointment> GetAppointmentsByPatient(int patientID);
        List<Appointment> GetAppointmentsByDoctor(int doctorID);
    }






}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System
{
    class HospitalAppointmentViewer : IAppointmentViewer
    {
        private List<Appointment> appointments;

        public HospitalAppointmentViewer()
        {
            appointments = new List<Appointment>();
        }

        public List<Appointment> GetAppointmentsByPatient(int patientID)
        {
            // Logic to get appointments for a patient
            return appointments.FindAll(app => app.Patient.PatientID == patientID);
        }

        public List<Appointment> GetAppointmentsByDoctor(int doctorID)
        {
            // Logic to get appointments for a doctor
            return appointments.FindAll(app => app.Doctor.DoctorID == doctorID);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptwofinal
{
    public class Appointment : IAppointment
    {
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime Date { get; set; }

        public Appointment(Patient patient, Doctor doctor, DateTime date)
        {
            Patient = patient;
            Doctor = doctor;
            Date = date;
        }

        public void ScheduleAppointment()
        {

        }

        public void ViewAppointments()
        {

        }

        public void CancelAppointment()
        {

        }

        public void Search()
        {

        }

        public void Run()
        {

        }
    }
}

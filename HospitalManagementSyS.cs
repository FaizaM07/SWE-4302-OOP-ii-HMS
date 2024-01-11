using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System
{
    class HospitalManagementSyS : IAppointmentScheduler
    {
        private List<Patient> patients;
        private List<Doctor> doctors;
        private List<Appointment> appointments;

        private Dictionary<string, string> diseaseToDoctorMapping;
        public HospitalManagementSyS()
        {
            patients = new List<Patient>();
            doctors = new List<Doctor>();
            appointments = new List<Appointment>();


            diseaseToDoctorMapping = new Dictionary<string, string>
{
    {"fever", "MedicineSpecialist"},
    {"toothache", "Dentist"},
    {"heartproblem", "Cardiologist"},
    {"headache", "Neurologist"},
    {"cold", "Pediatrician"},
    
};









        }

        public void ScheduleAppointment(Appointment appointment)
        {
            // Logic to schedule an appointment
            // Check if the chosen doctor is available at the specified date and time
            bool isDoctorAvailable = IsDoctorAvailable(appointment.Doctor, appointment.Date, appointment.Time);

            if (isDoctorAvailable)
            {
                // Check if the chosen date and time are available for scheduling
                bool isDateTimeAvailable = IsDateTimeAvailable(appointment.Date, appointment.Time);

                if (isDateTimeAvailable)
                {
                    // If both doctor and date/time are available, add the appointment
                    appointments.Add(appointment);
                    Console.WriteLine("Appointment scheduled successfully!");
                }
                else
                {
                    Console.WriteLine("Sorry, the chosen date and time are not available. Please choose another slot.");
                }
            }
            else
            {
                Console.WriteLine("Sorry, the chosen doctor is not available at the specified date and time. Please choose another doctor or time.");
            }
        }

        // Helper method to check if a doctor is available at a specific date and time
        private bool IsDoctorAvailable(Doctor doctor, string date, string time)
        {
            // Implement your logic to check doctor availability (e.g., from a database)
            // For simplicity, let's assume all doctors are always available
            return true;
        }

        // Helper method to check if a date and time slot is available for scheduling
        private bool IsDateTimeAvailable(string date, string time)
        {
            // Implement your logic to check if the date and time slot is available
            // For simplicity, let's assume all dates and times are always available
            return true;
        }



        public List<Doctor> GetSpecialistDoctorsForDisease(string disease)
        {
            // Check if the disease is in the mapping
            if (diseaseToDoctorMapping.TryGetValue(disease.ToLower(), out string specialist))
            {
                return doctors.FindAll(d => d.Specialization.ToLower() == specialist.ToLower());
            }
            else
            {
                Console.WriteLine($"No specialist doctors found for {disease}");
                return new List<Doctor>();
            }
        }




















        public void CancelAppointment(int appointmentID)
        {
            // Logic to cancel an appointment
            Appointment appointmentToRemove = appointments.Find(app => app.AppointmentID == appointmentID);
            if (appointmentToRemove != null)
            {
                appointments.Remove(appointmentToRemove);
            }
        }

        public List<Appointment> GetAppointments()
        {
            return new List<Appointment>(appointments);
        }

        public void AddPatient(Patient patient)
        {
            patients.Add(patient);
        }

        public void RemovePatient(int patientID)
        {
            Patient patientToRemove = patients.Find(p => p.PatientID == patientID);
            if (patientToRemove != null)
            {
                patients.Remove(patientToRemove);
            }
        }

        public List<Patient> GetAllPatients()
        {
            return new List<Patient>(patients);
        }

        public void AddDoctor(Doctor doctor)
        {
            doctors.Add(doctor);
        }

        public void RemoveDoctor(int doctorID)
        {
            Doctor doctorToRemove = doctors.Find(d => d.DoctorID == doctorID);
            if (doctorToRemove != null)
            {
                doctors.Remove(doctorToRemove);
            }
        }

        public List<Doctor> GetAllDoctors()
        {
            return new List<Doctor>(doctors);
        }

        
    }
}


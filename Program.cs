using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Hospital_Management_System
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            HospitalManagementSyS hospitalSystem = new HospitalManagementSyS();

            
            Doctor Cardiologist = new Doctor { DoctorID = 1, Name = "Dr. Smith", Specialization = "Cardiologist", ContactNumber = "987654321" };
            Doctor Neurologist = new Doctor { DoctorID = 2, Name = "Dr. Johnson", Specialization = "Neurologist", ContactNumber = "123456789" };
            Doctor MedicineSpecialist = new Doctor { DoctorID = 3, Name = "Dr. Williams", Specialization = "MedicineSpecialist", ContactNumber = "555555555" };
            Doctor Dentist = new Doctor { DoctorID = 3, Name = "Dr. White", Specialization = "Dentist", ContactNumber = "555555555" };
            Doctor Pediatrician = new Doctor { DoctorID = 4, Name = "Dr. Miller", Specialization = "Pediatrician", ContactNumber = "999999999" };
            hospitalSystem.AddDoctor(Cardiologist);
            hospitalSystem.AddDoctor(Neurologist);
            hospitalSystem.AddDoctor(MedicineSpecialist);
            hospitalSystem.AddDoctor(Dentist);
            hospitalSystem.AddDoctor(Pediatrician);

            
            Console.WriteLine("Welcome to the Hospital Management System");
            Console.Write("Enter patient name: ");
            string patientName = Console.ReadLine();
            Console.Write("Enter patient age: ");
            int patientAge = int.Parse(Console.ReadLine());
            Console.Write("Enter patient gender: ");
            string patientGender = Console.ReadLine();
            Console.Write("Enter patient contact number: ");
            string patientContactNumber = Console.ReadLine();
            Console.Write("Enter patient address: ");
            string patientAddress = Console.ReadLine();
            Console.Write("Enter patient's disease: ");
            string patientDisease = Console.ReadLine();

            // a new patient is created
            Patient patient = new Patient
            {
                PatientID = hospitalSystem.GetAllPatients().Count + 1,
                Name = patientName,
                Age = patientAge,
                Gender = patientGender,
                ContactNumber = patientContactNumber,
                Address = patientAddress,
                Disease = patientDisease
            };

            // Display specialist doctors for the patient's disease
            List<Doctor> specialistDoctors = hospitalSystem.GetSpecialistDoctorsForDisease(patientDisease);
            if (specialistDoctors.Count == 0)
            {
                Console.WriteLine($"No specialist doctors found for {patientDisease}");
                return;
            }

            Console.WriteLine($"Specialist doctors for {patientDisease}:");
            foreach (var doctor in specialistDoctors)
            {
                Console.WriteLine($"ID: {doctor.DoctorID}, Name: {doctor.Name}, Specialization: {doctor.Specialization}, Contact: {doctor.ContactNumber}");
            }

            // Patient chooses a doctor
            Doctor chosenDoctor = specialistDoctors[0];
            // Schedule an appointment
            Console.Write("Enter appointment date (yyyy-MM-dd): ");
            string appointmentDate = Console.ReadLine();
            Console.Write("Enter appointment time: ");
            string appointmentTime = Console.ReadLine();

            // Create an appointment object
            Appointment appointment = new Appointment
            {
                AppointmentID = hospitalSystem.GetAppointments().Count + 1,
                Patient = patient,
                Doctor = chosenDoctor,
                Date = appointmentDate,
                Time = appointmentTime
            };

            // Schedule the appointment
            hospitalSystem.ScheduleAppointment(appointment);

            // Display appointment details
            Console.WriteLine($"Appointment scheduled successfully!");
            Console.WriteLine($"Patient: {patient.Name}, Doctor: {chosenDoctor.Name}, Date: {appointment.Date}, Time: {appointment.Time}");
        }
    }
}
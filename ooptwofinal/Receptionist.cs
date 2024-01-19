using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptwofinal
{
    public class Receptionist : IReceptionist
    {
        private List<Patient> patients = new List<Patient>();
        
        private List<Appointment> appointments = new List<Appointment>();
        IManager manager = new Manager();

        
        private readonly Dictionary<string, string> diseaseToDoctorMapping = new Dictionary<string, string>
        {
            {"fever", "MedicineSpecialist"},
            {"toothache", "Dentist"},
            {"heartproblem", "Cardiologist"},
            {"headache", "Neurologist"},
            {"cold", "Pediatrician"},
        };

      

        public void AddPatient()
        {
            // To add a patient
            Console.Write("Enter Patient's Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter ID: ");
            string id = Console.ReadLine();

            Console.Write("Enter Gender: ");
            string gender = Console.ReadLine();

            Console.Write("Enter Contact No: ");
            string contactNo = Console.ReadLine();

            Console.Write("Enter Address: ");
            string address = Console.ReadLine();

            patients.Add(new Patient(name, age, id, gender, contactNo, address));
            Console.WriteLine("Patient added successfully.");
        }

        public void ScheduleAppointment()
        {
            // To schedule an appointment
            Console.Write("Enter Patient ID: ");
            string patientId = Console.ReadLine();
            Patient patient = patients.FirstOrDefault(p => p.ID == patientId);
            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            Console.Write("Enter Disease: ");
            string disease = Console.ReadLine().ToLower();

            if (!diseaseToDoctorMapping.TryGetValue(disease, out string specialist))
            {
                Console.WriteLine("Specialist not found for the given disease.");
                return;
            }

            List<Doctor> list=manager.Lists();
            Doctor doctor = list.FirstOrDefault(d => d.Specialty == specialist);
            if (doctor == null)
            {
                Console.WriteLine("Doctor not found for the specified disease.");
                return;
            }

            Console.Write("Enter Time of Appointment (hh:mm): ");
            string timeInput = Console.ReadLine();
            if (!DateTime.TryParse(timeInput, out DateTime time))
            {
                Console.WriteLine("Invalid time format.");
                return;
            }

            DateTime date = DateTime.Now.Date + time.TimeOfDay;

            appointments.Add(new Appointment(patient, doctor, date));
            Console.WriteLine($"Appointment scheduled successfully. Patient: {patient.Name}, Doctor: {doctor.Name}, Time: {date}");
        }

        public void ViewAppointments()
        {
            // To view appointments
            foreach (var appointment in appointments)
            {
                Console.WriteLine($"Appointment: {appointment.Patient.Name} with {appointment.Doctor.Name} on {appointment.Date.ToShortDateString()}");
            }
        }

        public void CancelAppointment()
        {
            // To cancel an appointment
            Console.Write("Enter Patient ID: ");
            string patientId = Console.ReadLine();

            var appointment = appointments.FirstOrDefault(a => a.Patient.ID == patientId);
            if (appointment != null)
            {
                appointments.Remove(appointment);
                Console.WriteLine("Appointment cancelled successfully.");
            }
            else
            {
                Console.WriteLine("Appointment not found.");
            }
        }

        public void Search()
        {
            // To search for a doctor or patient
            Console.WriteLine("Search For:");
            Console.WriteLine("1. Doctor");
            Console.WriteLine("2. Patient");
            var type = Console.ReadLine();

            Console.Write("Enter Name or ID: ");
            var searchTerm = Console.ReadLine().ToLower();
            List<Doctor> list = manager.Lists();
            if (type == "1")
            {
                var foundDoctors = list.Where(d => d.Name.ToLower().Contains(searchTerm) || d.ID.ToLower() == searchTerm);
                foreach (var doctor in foundDoctors)
                {
                    Console.WriteLine($"Doctor: {doctor.Name}, Specialty: {doctor.Specialty}, ID: {doctor.ID}");
                }
            }
            else if (type == "2")
            {
                var foundPatients = patients.Where(p => p.Name.ToLower().Contains(searchTerm) || p.ID.ToLower() == searchTerm);
                foreach (var patient in foundPatients)
                {
                    Console.WriteLine($"Patient: {patient.Name}, Age: {patient.Age}, ID: {patient.ID}");
                }
            }
            else
            {
                Console.WriteLine("Invalid search type.");
            }
        }

        public void ProcessPayment()
        {
            Console.Write("Enter Patient ID: ");
            string patientId = Console.ReadLine();

            var patient = patients.FirstOrDefault(p => p.ID == patientId);

            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            Console.WriteLine($"Patient: {patient.Name}, Balance: ${patient.Balance}");

            Console.Write("Enter Amount to Pay: ");
            decimal paymentAmount;

            while (!decimal.TryParse(Console.ReadLine(), out paymentAmount) || paymentAmount < 0)
            {
                Console.WriteLine("Invalid amount. Please enter a valid positive amount.");
                Console.Write("Enter Amount to Pay: ");
            }

            if (paymentAmount <= patient.Balance)
            {
                patient.Balance -= paymentAmount;
                Console.WriteLine($"Payment of ${paymentAmount} processed successfully.");
                Console.WriteLine($"Remaining Balance: ${patient.Balance}");
            }
            else
            {
                Console.WriteLine($"Invalid payment amount. The payment exceeds the remaining balance.");
            }
        }


        public void Run()
        {
            // Logic for the main system
            Console.WriteLine("XYZ Hospital");

            while (true)
            {
                Console.WriteLine("\nHospital Management System");
                Console.WriteLine("1.  Add Doctor");
                Console.WriteLine("2.  Add Patient");
                Console.WriteLine("3.  Schedule Appointment");
                Console.WriteLine("4.  View Appointments");
                Console.WriteLine("5.  Cancel Appointment");
                Console.WriteLine("6.  Search");
                Console.WriteLine("7.  Generate Reports");
                Console.WriteLine("8.  Manage Staff");
                Console.WriteLine("9.  Manage Patient Records");
                Console.WriteLine("10. Payment");
                Console.WriteLine("0.  Exit");
                Console.Write("Enter option: ");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        manager.AddDoctor();
                        break;
                    case "2":
                        AddPatient();
                        break;
                    case "3":
                        ScheduleAppointment();
                        break;
                    case "4":
                        ViewAppointments();
                        break;
                    case "5":
                        CancelAppointment();
                        break;
                    case "6":
                        Search();
                        break;
                    case "7":
                        GenerateReports();
                        break;
                    case "8":
                        ManageStaff();
                        break;
                    case "9":
                        ManagePatientRecords();
                        break;
                    case "10":
                        ProcessPayment();
                        break;

                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        
        public void GenerateReports()
        {
         
            Console.WriteLine("Reports generated successfully.");
        }

        public void ManageStaff()
        {
                        Console.WriteLine("Staff management logic.");
        }

        public void ManagePatientRecords()
        {
          
            Console.WriteLine("Patient records management logic.");
        }
    }




    }



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System
{
    interface IAppointmentScheduler
    {


        void ScheduleAppointment(Appointment appointment);
        void CancelAppointment(int appointmentID);





    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptwofinal
{
    public interface IAppointment
    {
        void ScheduleAppointment();
        void ViewAppointments();
        void CancelAppointment();
        void Search();
        void Run();
    }
}

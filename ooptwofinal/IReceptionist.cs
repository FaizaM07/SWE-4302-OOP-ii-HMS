using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooptwofinal
{
    public interface IReceptionist : IAppointment
    {
        void GenerateReports();
        void ManageStaff();
        void ManagePatientRecords();
    }
}

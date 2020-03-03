using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    class Shift
    {
        public DateTime startTime { get; private set; }
        public DateTime endTime { get; private set; }

        public Shift(DateTime start, DateTime end)
        {
            startTime = start;
            endTime = end;
        }

        public void EditShift(DateTime start, DateTime end)
        {
            startTime = start;
            endTime = end;
        }
    }
}

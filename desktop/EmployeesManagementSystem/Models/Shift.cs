using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    class Shift
    {
        public int ID { get; set; }
        public int AssignedEmployeeID { get; set; }
       
        public bool Availability { get; set; }

        public DateTime ShiftDate { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public ShiftType Type { get; set; }

        public Shift() { }
        public Shift( int assignedEmployeeID, bool availability, DateTime shiftDate, DateTime startTime, DateTime endTime, ShiftType type)
        {
            AssignedEmployeeID = assignedEmployeeID;
            Availability = availability;
            ShiftDate = shiftDate;
            StartTime = startTime;
            EndTime = endTime;
            Type = type;
        }
    }

    enum ShiftType
    {
        MORNING,
        AFTERNOON,
        EVENING,
        OTHER
    }
}

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
        public int DepartmentID { get; set; }
        public bool Availability { get; set; }
        public DateTime ShiftDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ShiftType Type { get; set; }
        public AttendanceType Attendance { get; set; }


        public Shift() { }
        public Shift(int assignedEmployeeID, bool availability, int department, DateTime shiftDate, DateTime startTime, DateTime endTime, ShiftType type, AttendanceType attendance)
        {
            AssignedEmployeeID = assignedEmployeeID;
            DepartmentID = department;
            Availability = availability;
            ShiftDate = shiftDate;
            StartTime = startTime;
            EndTime = endTime;
            Type = type;
            Attendance = attendance;
        }
        public int GetInfo()
        {
            if (this.Attendance.ToString() ==  "ATTENDED")
            {
                TimeSpan span = this.EndTime.Subtract(this.StartTime);
                int hrs = (int)span.TotalHours;
                return hrs;
            }
            return 0;
        }
    }

    enum ShiftType
    {
        MORNING,
        AFTERNOON,
        EVENING,
        OTHER
    }
    enum AttendanceType
    {
        SCHEDULED,
        ATTENDED,
        EXCUSED,
        ABSENT,
        CANCELLED
    }
}

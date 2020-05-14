using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    public class Shift
    {
        public int ID { get; set; }
        public bool Availability { get; set; }
        public DateTime ShiftDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ShiftType Type { get; set; }
        public bool Attended { get; set; } = false;
        public bool Cancelled { get; set; } = true;
        private User user = new User();
        public User AssignedUser { get { return user; } set { this.user = value; } }
        private Department department = new Department();
        public Department Department { get { return this.department; } set { this.department = value; } }

        public Shift() { }
        public Shift(User assignedUser, bool availability, Department department,
            DateTime shiftDate, DateTime startTime, DateTime endTime, ShiftType type)
        {
            this.AssignedUser = assignedUser;
            this.Department = department;

            this.Availability = availability;
            this.ShiftDate = shiftDate;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Type = type;
        }
        public int GetShiftHours()
        {
            if (this.Attended)
            {
                return (int)this.EndTime.Subtract(this.StartTime).TotalHours;
            }
            return 0;
        }
    }
}

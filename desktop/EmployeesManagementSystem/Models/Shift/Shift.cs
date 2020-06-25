using System;

namespace EmployeesManagementSystem.Models
{
    public class Shift : IShift, IComparable<Shift>
    {
        public int ID { get; set; }
        public bool Availability { get; set; }
        public DateTime ShiftDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public ShiftType Type { get; set; }
        public bool Attended { get; set; } = false;
        public bool Cancelled { get; set; } = true;
        
        // User 
        private User user = new User();
        public User AssignedUser { get { return user; } set { this.user = value; } }
        
        // Department
        private Department department = new Department();
        public Department Department { get { return this.department; } set { this.department = value; } }

        
        public Shift() { }
        
        public Shift(User assignedUser, bool availability, Department department,
            DateTime shiftDate, string startTime, string endTime, ShiftType type)
        {
            this.AssignedUser = assignedUser;
            this.Department = department;

            this.Availability = availability;
            this.ShiftDate = shiftDate;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Type = type;
        }

        public override string ToString()
        {
            return $"Available: {ShiftDate.Day, 20}/{ShiftDate.Month,5}/{ShiftDate.Year,5}  {StartTime, 15}  to  {EndTime, -15}   {("Type " + Type), - 20}";
        }
        public int CompareTo(Shift other)
        {
            if (other == null) return 1;

            return this.ShiftDate.CompareTo(other.ShiftDate);

        }
    }
}

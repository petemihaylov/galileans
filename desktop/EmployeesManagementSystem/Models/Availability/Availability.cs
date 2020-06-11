using System.Collections.Generic;

namespace EmployeesManagementSystem.Models
{
    public class Availability
    {
        private User user = new User();

        public int ID { get; set; }
        public User User { get { return this.user; } set { this.user = value; } }
        public AvailabilityType State { get; set; }
        public List<DayType> Days { get; set; }
        public bool IsWeekly { get; set; }
        public bool IsMonthly { get; set; }

        public Availability()
        {

        }

        public Availability(User user, AvailabilityType availability, List<DayType> days, bool isWeekly, bool isMonthly)
        {
            this.User = user;
            this.State = availability;
            this.Days = days;
            this.IsWeekly = isWeekly;
            this.IsMonthly = isMonthly;
        }

        public string GetDays()
        {
            return string.Join("    ", this.Days.ToArray());
        }
        public string GetInfo()
        {
            if (this.IsWeekly)
                return  this.GetDays() + ", weekly";
            else if (this.IsMonthly)
                return  this.GetDays() + ", monthly";
             
            
            return this.GetDays() + ", once";
        }
    }
}

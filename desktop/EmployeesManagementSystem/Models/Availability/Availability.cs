
using System.Collections.Generic;

namespace EmployeesManagementSystem.Models
{
    public class Availability : IAvailability
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
            return string.Join(", ", this.Days.ToArray());
        }

        public List<string> GetFormatedDays()
        {
            List<string> result = new List<string>();
            Days.ForEach(d => result.Add(GetFormatedName(d)));
            return result;
        }
        private string GetFormatedName(DayType day)
        {
            switch (day)
            {
                case DayType.Mon:
                    return "Monday";
                case DayType.Tue:
                    return "Tuesday";
                case DayType.Wed:
                    return "Wednesday";
                case DayType.Thu:
                    return "Thursday"; 
                case DayType.Fri:
                    return "Friday";
                case DayType.Sat:
                    return "Saturday";
                default:
                    return "Sunday";
            }
        }
        public string GetInfo()
        {
            if (this.IsWeekly)
                return  this.GetDays() + "  -  Weekly";
            else if (this.IsMonthly)
                return  this.GetDays() + "  -  Monthly";
             
            
            return this.GetDays() + ", once";
        }
    }
}

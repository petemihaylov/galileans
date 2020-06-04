using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    public class Availability
    {
        private User user = new User();

        public int ID { get; set; }
        public User User { get { return this.user; } set { this.user = value; } }
        public AvailabilityType State { get; set; }
        public DayType Days { get; set; }
        public bool IsWeekly { get; set; }
        public bool IsMonthly { get; set; }

        public Availability()
        {

        }

        public Availability(User user, AvailabilityType availability, DayType days, bool isWeekly, bool isMonthly)
        {
            this.User = user;
            this.State = availability;
            this.Days = days;
            this.IsWeekly = isWeekly;
            this.IsMonthly = isMonthly;
        }

    }
}

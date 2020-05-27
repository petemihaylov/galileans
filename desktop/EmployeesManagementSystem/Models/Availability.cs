using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    public class Availability
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public bool Available { get; set; } = false;

        private User user = new User();
        public User User { get { return this.user; } set { this.user = value; } }
        public Availability() { }

        public Availability(User user, DateTime date, bool available)
        {
            this.Date = date;
            this.Available = available;
            this.User = user;
        }

    }
}

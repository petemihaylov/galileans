using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    public class Notification : INotification
    {
        public int ID { get; set; }
        public string Message { get; set; }

        private User user = new User();
        public User User { get { return this.user; } set { this.user = value; } }

        public Notification(string message, User user)
        {
            this.Message = message;
            this.User = user;
        }
    }
}

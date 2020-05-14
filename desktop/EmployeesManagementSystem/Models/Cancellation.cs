using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    public class Cancellation
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        private User user = new User();
        public User Employee { get { return this.user; } set { this.user = value; } }
        public Cancellation() { }
        public Cancellation(int id, DateTime date, string email, string subject, string message, User employee)
        {
            this.ID = id;
            this.Date = date;
            this.Subject = subject;
            this.Message = message;
            this.Email = email;
            this.Employee = employee;
        }
        public string[] GetInfo()
        {
            string[] s = { this.ID.ToString() , this.Date.ToString() , "Name", this.Email, this.Subject, this.Message, "Delete"};
            return s;
        }
    }
}

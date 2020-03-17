using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    class Cancellations
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string EmployeeName { get; set; }

        public Cancellations() { }
        public Cancellations(int id, DateTime date, string email, string subject, string message, string employeeName)
        {
            this.ID = id;
            this.Date = date;
            this.Subject = subject;
            this.Message = message;
            this.Email = email;
            this.EmployeeName = employeeName;
        }
        public string[] GetInfo()
        {
            string[] s = { Convert.ToString(this.ID) , this.Date.ToString() , this.EmployeeName, this.Email, this.Subject, this.Message, "Delete"};
            return s;
        }
    }
}

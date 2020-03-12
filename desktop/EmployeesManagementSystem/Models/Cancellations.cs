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
        public string Date { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Employee { get; set; }

        public Cancellations() { }
        public Cancellations(int id, string date, string subject, string description, string employee)
        {
            this.ID = id;
            this.Date = date;
            this.Subject = subject;
            this.Description = description;
            this.Employee = employee;
        }

        public string[] GetInfo()
        {
            string[] s = { Convert.ToString(this.ID) , this.Date , this.Employee, this.Subject, this.Description, "Delete"};
            return s;
        }
    }
}

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
        public string Subject { get; set; }
        public string Message { get; set; }
        public CState State { get; set; } = CState.Pending;

        private User user = new User();
        public User Employee { get { return this.user; } set { this.user = value; } }
        
        public Cancellation() { }
        public Cancellation(int id, DateTime date, string subject, string message, User employee, CState state)
        {
            this.ID = id;
            this.Date = date;
            this.Subject = subject;
            this.Message = message;
            this.Employee = employee;
            this.State = state;
        }
        public string[] GetInfo()
        {
            string[] s = { this.ID.ToString() , this.Date.ToString() , "Name", this.Subject, this.Message, this.State.ToString(), "Delete" };
            return s;
        }

    }

    public enum CState
    {
        Pending,
        Approved,
        Declined
    }   
}

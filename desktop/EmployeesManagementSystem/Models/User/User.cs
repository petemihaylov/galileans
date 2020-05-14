using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    public class User
    {
        public int ID { get; set; }

        private string fullname;
        public string FullName
        {
            get { return this.fullname; }
            set
            {
                if (value.Length > 0) this.fullname = value;
                else { Console.WriteLine(ErrorMessage.EmptyFullName()); }
            }
        }
        private string email;
        public string Email
        {
            get { return this.email; }
            set
            {
                if (isEmailValid(value) == true)
                {
                    this.email = value;
                }
            }
        }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public Role Role { get; set; }
        private double wage;
        public double Wage
        {
            get
            {
                return this.wage;
            }
            set
            {
                if (value >= 0) this.wage = value;
                else { Console.WriteLine(ErrorMessage.InvalidWage()); }
            }
        }

        public User() { }
        public User(int id, string fullName, string email, string phoneNumber, string password, Role role, double wage)
        {
            this.ID = id;
            this.FullName = fullName;
            this.Email = email;
            this.Role = role;
            this.Password = password;
            this.PhoneNumber = phoneNumber;
            this.Wage = wage;
        }


        public string[] GetInfo()
        {
            string[] s = { this.ID.ToString(), this.FullName, this.Email, this.Role.ToString(), ""};
            return s;
        }

        private bool isEmailValid(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(ErrorMessage.InvalidEmail());
            }

            return false;
        }
    }
}

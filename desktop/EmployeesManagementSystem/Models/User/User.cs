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
        private decimal wage;
        public decimal Wage
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
        public Department Department { get; set; }


        public User() { }
        public User(int id, string fullName, string email, string phoneNumber, string password, Role role, decimal wage, Department department)
        {
            this.ID = id;
            this.FullName = fullName;
            this.Email = email;
            this.Role = role;
            this.Password = password;
            this.PhoneNumber = phoneNumber;
            this.Wage = wage;
            this.Department = department;
        }


        public string[] GetInfo()
        {
            string[] s = { this.ID.ToString(), this.FullName, this.Email, this.Role.ToString(), this.Department.Name };
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

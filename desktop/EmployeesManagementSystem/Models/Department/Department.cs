using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    public class Department : IDepartment
    {
        public int ID { get; set; }
        private string name;
        public string Name {
            get { return this.name; }
            set
            {
                if (value.Length > 0) this.name = value;
                else { Console.WriteLine(ErrorMessage.EmptyFullName()); }
            }
        }

        public Department() { }

        public Department(string name)
        {
            this.Name = name;
        }

        public string[] GetInfo()
        {
            string[] output = { ID.ToString(), Name };
            return output;
        }
    }
}

using System.Collections.Generic;

namespace EmployeesManagementSystem.Models
{
    public class Department : IDepartment
    {
        public int ID { get; set; }
        public string Name { get; set; }

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

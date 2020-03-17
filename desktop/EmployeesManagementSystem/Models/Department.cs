using System.Collections.Generic;

namespace EmployeesManagementSystem.Models
{
    public class Department
    {
        public int ID { get; set; };
        public string Name { get; set; };

        public Department()
        {
        }

        public Department(string name)
        {
            Name = name;
        }

        public string[] GetInfo()
        {
            string[] s = { $"{ID}", Name };
            return s;
        }
    }
}

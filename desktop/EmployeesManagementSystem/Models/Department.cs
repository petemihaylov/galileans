using System.Collections.Generic;

namespace EmployeesManagementSystem.Models
{
    public class Department
    {
        public int ID;
        public string Name;

        public Department()
        {
        }

        public Department(string name)
        {
            Name = name;
        }

        public string[] GetInfo()
        {
            string[] s = { $"{ID}", Name, "Delete" };
            return s;
        }
    }
}

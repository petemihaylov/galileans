using System.Collections.Generic;

namespace EmployeesManagementSystem.Models
{
    class Department
    {
        public string name { get; private set; }
        List<Stock> stocks;
        List<User> employees;

        public Department(string name)
        {
            this.name = name;
            stocks = new List<Stock>();
            employees = new List<User>();
        }
    }
}

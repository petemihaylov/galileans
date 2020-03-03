using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    class Department
    {
        public string name { get; private set; }
        List<Stock> stocks;

        public Department(string name)
        {
            this.name = name;
            stocks = new List<Stock>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    interface IUser
    {
        int ID { get; set; }
        string FullName { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string PhoneNumber { get; set; }
        double Wage { get; set; }

        Role Role { get; set; }


        string[] GetInfo();

    }
}

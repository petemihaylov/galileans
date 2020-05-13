﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    class Employee : User
    {
        public Employee(int id, string fullName, string email, string phoneNumber, string password, decimal wage, Department department)
            : base(id, fullName, email, phoneNumber, password, Role.Employee, wage, department)
        {

        }
    }
}

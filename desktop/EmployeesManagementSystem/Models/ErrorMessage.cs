using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagementSystem.Models
{
    public static class ErrorMessage
    {
        public static string InvalidWage()
        {
            return "Wage could not be less than a zero.";
        } 
        public static string EmptyFullName()
        {
            return "Empty Fullname property.";
        }

        public static string InvalidEmail()
        {
            return "Format Exception! Invalid Email address.";
        }
        public static string NegativePrice()
        {
            return "Stock could not have a negative price.";
        }
    }
}

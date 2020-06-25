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
            throw new System.ArgumentException("Wage could not be less than a zero.");
            //return "Wage could not be less than a zero.";
        } 
        public static string EmptyFullName()
        {
            throw new System.ArgumentException("Empty Fullname property.");
            //return "Empty Fullname property.";

        }

        public static string InvalidEmail()
        {
            throw new System.ArgumentException("Format Exception! Invalid Email address.");
            //return "Format Exception! Invalid Email address.";
        }
        public static string NegativePrice()
        {
            throw new System.ArgumentException("Stock could not have a negative price.");
            //return "Stock could not have a negative price.";
        }
    }
}

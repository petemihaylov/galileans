using EmployeesManagementSystem.Data;
using EmployeesManagementSystem.Models;
using System;

namespace EmployeesManagementSystem
{
    public static class DataConverter
    {
        public static void Run()
        {
            Console.WriteLine("Ready for usage ... ");

            // Declare JsonSerializer
            JsonSerializer serializer = new JsonSerializer("users.json");

            // Get data from the Context
            UserContext userContext = new UserContext();
            User[] users = userContext.GetAllUsers();

            // Write to users.json
            serializer.Write(users);
            
        }
    }
}

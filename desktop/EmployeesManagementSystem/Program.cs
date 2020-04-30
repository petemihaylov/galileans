using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using EmployeesManagementSystem.Data;
using EmployeesManagementSystem.Models;

namespace EmployeesManagementSystem
{  
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Now instead of email you can type
            // admin and the password is: admin 
            // Application.Run(new Login());
            DataConverterCSV c = new DataConverterCSV("file");

            User user1 = new User("Chat", "chat@email", "+31 888 444 666", "password", "Manager", 30, 888);
            User user2 = new User("John", "john@email", "+31 888 444 666", "password", "Admin", 30, 999);


            List<User> userList = new List<User>();
            userList.Add(user1);
            userList.Add(user2);
            c.CSVFileWrite<User>(userList);

            c.CSVFileRead();
            c.CSVFileReadByField("Admin", 5);
            c.CSVFileReadByField("John", 1);
        }
    }
}

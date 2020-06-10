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

            //Application.Run(new Login());
            
            //new UserRfidTag().Show();
            //new TimeTable().Show();
            new Login().Show();
            Application.Run();
            
            // ConversionManager.Run();
        }
    }
}

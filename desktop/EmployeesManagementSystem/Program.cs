using EmployeesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
             Application.Run(new Statistic());
        }
    }
}

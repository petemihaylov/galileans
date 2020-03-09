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
        /// <summary>
        /// Some form of state is required to remember what your last visited page was.
        /// </summary>
        public static class FormState
        {
            public static Form PreviousPage;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Now instead of email you can type
            // admin and the password is: admin 
            Application.Run(new Dashboard());
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeesManagementSystem.Models;


namespace EmployeesManagementSystem
{
    public partial class Statistic : Form
    {
        private DbContext databaseContext = new DbContext();
        private User user;
        private List<Shift> shifts;
        private int hoursWorked, hrs, id;
        private int hoursSkipped;
        DateTime today = DateTime.Today;
        DateTime dateHour = DateTime.Now;

        public Statistic(int UserID)
        {
            InitializeComponent();
            this.user = databaseContext.GetUserByID(UserID);
            this.shifts = databaseContext.GetShiftsByID(UserID);
            this.id = UserID;
            /*this.tbFullName.Text = user.FullName;
            this.tbPassword.Text = user.Password;
            this.tbEmail.Text = user.Email;
            // this.tbLocation.Text = "to add in db";
            this.tbPhoneNumber.Text = user.PhoneNumber;
            this.cbRole.Text = user.Role;
            // this.cbDepartment.Text = "to add in db";*/

        }
    }
}

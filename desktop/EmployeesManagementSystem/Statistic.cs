using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
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

        private void exit_Click(object sender, EventArgs e)
        {
            databaseContext.Dispose(true);
            this.Close();
            if (Application.MessageLoop)
            {
                Application.Exit();
            }
        }

        public Statistic(int UserID)
        {
            InitializeComponent();
            this.user = databaseContext.GetUserByID(UserID);
            this.shifts = databaseContext.GetShiftsByID(UserID);
            this.id = UserID;
            this.tbFullName.Text = user.FullName;
            this.tbPassword.Text = user.Password;
            this.tbEmail.Text = user.Email;
            // this.tbLocation.Text = "to add in db";
            this.tbPhoneNumber.Text = user.PhoneNumber;
            this.cbRole.Text = user.Role;
            // this.cbDepartment.Text = "to add in db";

            chartAttendence.Titles.Add("Attendence");
            foreach (Shift shift in shifts)
            {
                //MessageBox.Show(Convert.ToString((today - shift.ShiftDate).Days));

                if ((today - shift.ShiftDate).Days > 0)
                {
                    if (!shift.Attended)
                    {
                        hoursSkipped++;
                    }
                    else
                    {
                        hrs = shift.GetInfo();
                        hoursWorked += hrs;
                    }
                }

                
            }
            chartAttendence.Series["attendence"].Points.AddXY(hoursWorked*100/(hoursWorked+hoursSkipped) + "%", hoursWorked);
            chartAttendence.Series["attendence"].Points.AddXY(hoursSkipped*100/(hoursWorked + hoursSkipped) + "%", hoursSkipped);

        }
        private void picBack_Click(object sender, EventArgs e)
        {

            databaseContext.Dispose(true);
            this.Close();

            Details det = new Details(this.id);
            det.Closed += (s, args) => this.Close();
            det.Show();
        }

    }
}

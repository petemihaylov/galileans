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
        float money = 0;
        DateTime today = DateTime.Today;
        DateTime dateHour = DateTime.Now;

        public Statistic(int UserID)
        {
            InitializeComponent();
            this.user = databaseContext.GetUserByID(UserID);
            this.shifts = databaseContext.GetShiftsByID(UserID);
            this.id = UserID;
            this.tbFullName.Text = user.FullName;
            this.tbEmail.Text = user.Email;
            // this.tbLocation.Text = "to add in db";
            this.tbPhoneNumber.Text = user.PhoneNumber;
            this.cbRole.Text = user.Role;
            // this.cbDepartment.Text = "to add in db"; 

            foreach (Shift shift in shifts)
            {
                //MessageBox.Show(Convert.ToString((today - shift.ShiftDate).Days));
                
                money = (shift.EndTime - shift.StartTime).Hours * user.HourlyRate;
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

            chart1.Series["Series1"].Points.AddXY(hoursWorked * 100 / (hoursWorked + hoursSkipped) + "%", hoursWorked);
            chart1.Series["Series1"].Points.AddXY(hoursSkipped * 100 / (hoursWorked + hoursSkipped) + "%", hoursSkipped);

            lbMoneyMade.Text = Convert.ToString(money) + "$";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            databaseContext.ResetPassword(user.ID);
            MessageBox.Show("Password Reset to 'WelcomeToMediaBazaar'");
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            databaseContext.Dispose(true);
            this.Close();
            // Show Dashboard
            Details details = new Details(this.id);
            details.Closed += (s, args) => this.Close();
            details.Show();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            databaseContext.Dispose(true);
            this.Close();
            if (Application.MessageLoop)
            {
                Application.Exit();
            }
        }
        private void exit_MouseEnter(object sender, EventArgs e)
        {
            Color color = Color.DarkGray;
            this.exit.BackColor = color;
        }

        private void exit_MouseLeave(object sender, EventArgs e)
        {
            Color color = Color.White;
            this.exit.BackColor = color;
        }

    }
}

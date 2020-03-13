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
        int counter = 0;
        bool worked = false;

        float money = 0;
        DateTime today = DateTime.Today;
        DateTime keepTrack = DateTime.Today;


        public Statistic(int UserID)
        {
            InitializeComponent();
            this.user = databaseContext.GetUserByID(UserID);
            this.shifts = databaseContext.GetShiftsByID(UserID);
            this.id = UserID;

            monthCenter.Text = today.ToString("MMM").ToUpper();
            yearCenter.Text = today.ToString("yyyy");
            monthLeft.Text = today.AddMonths(-1).ToString("MMM").ToUpper();
            yearLeft.Text = today.ToString("yyyy");
            monthRight.Text = today.AddMonths(1).ToString("MMM").ToUpper();
            yearLeft.Text = today.ToString("yyyy");
            UpdateStatistics();
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

        private void UpdateStatistics()
        {
            if (keepTrack.ToString("MMM").ToUpper() == monthCenter.Text && keepTrack.ToString("yyyy") == yearCenter.Text)
            {
                foreach (Shift shift in shifts)
                {
                    worked = false;
                    money = 0;

                    //to add  && DateTime.Compare(keepTrack,shift.ShiftDate) > 0
                    if (keepTrack.Month == shift.ShiftDate.Month && keepTrack.Day > shift.ShiftDate.Day)
                    {
                        money = (shift.EndTime - shift.StartTime).Hours * user.HourlyRate;
                        if (money > 0)
                        {
                            if (!shift.Attended)
                            {
                                hoursSkipped++;
                                worked = true;
                            }
                            else
                            {
                                hrs = shift.GetInfo();
                                hoursWorked += hrs;
                            }
                        }
                    }
                }

                if (worked)
                {
                    foreach (var series in chartAttendenceMonth.Series)
                    {
                        series.Points.Clear();
                    }
                    chartAttendenceMonth.Series["Series1"].Points.AddXY(hoursWorked * 100 / (hoursWorked + hoursSkipped) + "%", hoursWorked);
                    chartAttendenceMonth.Series["Series1"].Points.AddXY(hoursSkipped * 100 / (hoursWorked + hoursSkipped) + "%", hoursSkipped);
                    
                    foreach (var series in chart1.Series)
                    {
                        series.Points.Clear();
                    }
                    chart1.Series["Series1"].Points.AddXY(hoursWorked, money); ;
                    lbMoneyMadeMonth.Text = Convert.ToString(money) + "$";
                }
                else
                {
                    foreach (var series in chartAttendenceMonth.Series)
                    {
                        series.Points.Clear();
                    }
                    chartAttendenceMonth.Series["Series1"].Points.AddXY(0 + "%", 0);
                    chartAttendenceMonth.Series["Series1"].Points.AddXY(100 + "%", 100);

                    lbMoneyMadeMonth.Text = "Did not work.";
                }
            }

        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            counter = 0;
            keepTrack = today;

            monthLeft.Text = today.ToString("MMM").ToUpper();
            monthCenter.Text = today.ToString("MMM").ToUpper();
            monthRight.Text = today.AddMonths(counter + 1).ToString("MMM").ToUpper();

            yearLeft.Text = today.ToString("yyyy");
            yearCenter.Text = today.ToString("yyyy");
            yearRight.Text = today.ToString("yyyy");

            UpdateStatistics();
        }

        private void arrowLeft_Click(object sender, EventArgs e)
        {
            counter--;

            keepTrack = today.AddMonths(counter);
            monthCenter.Text = today.AddMonths(counter).ToString("MMM").ToUpper();
            monthLeft.Text = today.AddMonths(counter - 1).ToString("MMM").ToUpper();
            monthRight.Text = today.AddMonths(counter + 1).ToString("MMM").ToUpper();

            yearLeft.Text = today.AddMonths(counter - 1).ToString("yyyy");
            yearCenter.Text = today.AddMonths(counter).ToString("yyyy");
            yearRight.Text = today.AddMonths(counter + 1).ToString("yyyy");

            UpdateStatistics();
        }

        private void arrowRight_Click(object sender, EventArgs e)
        {
            counter++;
            keepTrack = today.AddMonths(counter);
            monthCenter.Text = today.AddMonths(counter).ToString("MMM").ToUpper();
            monthLeft.Text = today.AddMonths(counter - 1).ToString("MMM").ToUpper();
            monthRight.Text = today.AddMonths(counter + 1).ToString("MMM").ToUpper();

            yearLeft.Text = today.AddMonths(counter - 1).ToString("yyyy");
            yearCenter.Text = today.AddMonths(counter).ToString("yyyy");
            yearRight.Text = today.AddMonths(counter + 1).ToString("yyyy");

            UpdateStatistics();
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

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void monthLeft_Click(object sender, EventArgs e)
        {

        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EmployeesManagementSystem.Models;


namespace EmployeesManagementSystem
{
    public partial class Statistic : Form
    {
        private DbContext databaseContext = new DbContext();
        private User[] users;
        private List<Shift> shifts;
        private int hoursWorked, hrs, id;
        private int hoursSkipped;
        int counter = 0;
        bool worked = false;


        // Keeps  track of the current loggedUser
        private User loggedUser;

        float money = 0;
        DateTime today = DateTime.Today;
        DateTime keepTrack = DateTime.Today;


        public Statistic(User user)
        {
            InitializeComponent();
            this.users = this.databaseContext.GetAllUsers();
            this.loggedUser = user;

            monthCenter.Text = today.ToString("MMM").ToUpper();
            yearCenter.Text = today.ToString("yyyy");
            monthLeft.Text = today.AddMonths(-1).ToString("MMM").ToUpper();
            yearLeft.Text = today.ToString("yyyy");
            monthRight.Text = today.AddMonths(1).ToString("MMM").ToUpper();
            yearLeft.Text = today.ToString("yyyy");
        }


        private void picBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Dashboard dashboard = new Dashboard( this.loggedUser);
            dashboard.Closed += (s, args) => this.Close();
            dashboard.Show();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
            if (Application.MessageLoop)
            {
                Application.Exit();
            }
        }

        private void UpdateStatisticsEmployee()
        {
            shifts = databaseContext.GetShiftsByID(Convert.ToInt32(cbEmployee.Text)); // try catch 
            User user = databaseContext.GetUserByID(Convert.ToInt32(cbEmployee.Text));

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

                foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }
                foreach (Shift shift in shifts)
                {
                    if (shift.Attended == true)
                        chart1.Series["Present"].Points.AddXY(shift.ShiftDate.Day + "/" + shift.ShiftDate.Month, shift.StartTime);
                    else
                        chart1.Series["Absent"].Points.AddXY(shift.ShiftDate.Day + "/" + shift.ShiftDate.Month, shift.StartTime);
                    if (shift.ShiftDate > today)
                    {
                        chart1.Series["Scheduled"].Points.AddXY(shift.ShiftDate.Day + "/" + shift.ShiftDate.Month, shift.StartTime);
                    }
                }

                //chart1.Series["Series1"].Points.AddXY(hoursWorked * 100 / (hoursWorked + hoursSkipped) + "%", hoursWorked);
                //chart1.Series["Series1"].Points.AddXY(hoursSkipped * 100 / (hoursWorked + hoursSkipped) + "%", hoursSkipped);

                /*foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }
                chart1.Series["Series1"].Points.AddXY(hoursWorked, money); ;
                lbMoneyMadeMonth.Text = Convert.ToString(money) + "$";*/
            }

        }

        public void UpdateStatisticDepartment()
        {

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

            if (cbStatistic.Text.Contains("employee"))
                UpdateStatisticsEmployee();
            else if (cbStatistic.Text.Contains("department"))
                UpdateStatisticDepartment();

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

            if (cbStatistic.Text.Contains("employee"))
                UpdateStatisticsEmployee();
            else if (cbStatistic.Text.Contains("department"))
                UpdateStatisticDepartment();

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

        private void cbStatistic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStatistic.Text.Contains("employee"))
            {
                cbEmployee.Items.Clear();
                lbEmployee.Text = "Select an employee";
                cbEmployee.Enabled = true;
                cbEmployee.Show();
                lbEmployee.Show();
                foreach (User item in users)
                {
                    cbEmployee.Items.Add(item.ID);
                }

            }
            else if (cbStatistic.Text.Contains("department"))
            {
                cbEmployee.Items.Clear();
                cbEmployee.Enabled = true;
                lbEmployee.Text = "Select a department";
                foreach (User item in users)
                {
                    cbEmployee.Items.Add(item.Department);
                }

            }
            else
            {
                cbEmployee.Hide();
                lbEmployee.Hide();
            }
        }

        private void Statistic_Load(object sender, EventArgs e)
        {

            cbEmployee.Hide();
            lbEmployee.Hide();
        }

        private void cbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {

            UpdateStatisticsEmployee();
        }
    }
}

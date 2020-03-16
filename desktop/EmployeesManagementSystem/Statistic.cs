using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using EmployeesManagementSystem.Data;
using EmployeesManagementSystem.Models;
using System.Windows.Forms.DataVisualization.Charting;

namespace EmployeesManagementSystem
{
    public partial class Statistic : Form
    {
        private UserContext userContext = new UserContext();
        private ShiftContext shiftContext = new ShiftContext();

        private User[] users;
        private List<Shift> shifts;
        private int hoursWorked, hrs, id;
        private int hoursSkipped;
        int counter = 0;

        // Keeps  track of the current loggedUser
        private User loggedUser;

        float money = 0;
        DateTime today = DateTime.Today;
        //keeps track of the month at the center
        DateTime keepTrack = DateTime.Today;


        public Statistic(User user)
        {
            InitializeComponent();
            this.users = this.userContext.GetAllUsers();
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

        private void AttendancePerEmployee()
        {
            try
            {
                shifts = shiftContext.GetShiftsByUserId(Convert.ToInt32(cbEmployee.Text)); // try catch
            }
            catch (Exception)
            {
                throw new Exception("Can't take employee's shifts");
            }

            User user = userContext.GetUserByID(Convert.ToInt32(cbEmployee.Text));

            //clears the chart
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }

            //attendance per employee
            foreach (Shift shift in shifts)
            {
                if (keepTrack.ToString("MMM").ToUpper() == monthCenter.Text && keepTrack.ToString("yyyy") == yearCenter.Text)
                {
                    //marks attended
                    if (shift.Attended == true)
                        chart1.Series["Present"].Points.Add(new DataPoint() { AxisLabel = Convert.ToString(shift.ShiftDate.Day) + "/" + Convert.ToString(shift.ShiftDate.Month), XValue = 31 * shift.ShiftDate.Month + shift.ShiftDate.Day, YValues = new double[] { shift.StartTime.Hour + shift.StartTime.Minute / 60, shift.EndTime.Hour + shift.EndTime.Minute / 60 } });
                    //marks absent
                    else if (shift.Attended == false && shift.ShiftDate < today)
                        chart1.Series["Absent"].Points.Add(new DataPoint() { AxisLabel = Convert.ToString(shift.ShiftDate.Day) + "/" + Convert.ToString(shift.ShiftDate.Month), XValue = 31 * shift.ShiftDate.Month + shift.ShiftDate.Day, YValues = new double[] { shift.StartTime.Hour + shift.StartTime.Minute / 60, shift.EndTime.Hour + shift.EndTime.Minute / 60 } });
                    //marks future scheduled shifts
                    else if (shift.Attended == false && shift.ShiftDate > today)
                    {
                        chart1.Series["Scheduled"].Points.Add(new DataPoint() { AxisLabel = Convert.ToString(shift.ShiftDate.Day) + "/" + Convert.ToString(shift.ShiftDate.Month), XValue = 31 * shift.ShiftDate.Month + shift.ShiftDate.Day, YValues = new double[] { shift.StartTime.Hour + shift.StartTime.Minute / 60, shift.EndTime.Hour + shift.EndTime.Minute / 60 } });
                    }
                }
            }
        }

        private void AttendancePerDepartment()
        {
            //clears the chart
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
        }

        private void WagePerEmployee()
        {
            try
            {
                shifts = shiftContext.GetShiftsByUserId(Convert.ToInt32(cbEmployee.Text)); // try catch
            }
            catch (Exception)
            {
                throw new Exception("Can't take employee's shifts");
            }
            User user = userContext.GetUserByID(Convert.ToInt32(cbEmployee.Text));

            //clears the chart
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }

            //if the month selected is the one in center
            if (keepTrack.ToString("MMM").ToUpper() == monthCenter.Text && keepTrack.ToString("yyyy") == yearCenter.Text)
            {
                foreach (Shift shift in shifts)
                {
                    money = 0;
                    if (shift.Attended)
                    {
                        //for all shifts that took place during the selected month, before todays date (in case of current month)
                        if (keepTrack.Month == shift.ShiftDate.Month && keepTrack.Day > shift.ShiftDate.Day)
                        {
                            //money = hrsWorked * wage
                            money = (shift.EndTime - shift.StartTime).Hours * user.HourlyRate;
                            hrs = shift.GetInfo();
                            hoursWorked += hrs;
                        }
                    }
                    else
                    {
                        if (keepTrack.Month == shift.ShiftDate.Month && keepTrack.Day > shift.ShiftDate.Day)
                        {
                            hoursSkipped++;
                        }
                    }
                }
            }
            /*
            chart1.Series["Series1"].Points.AddXY(hoursWorked * 100 / (hoursWorked + hoursSkipped) + "%", hoursWorked);
            chart1.Series["Series1"].Points.AddXY(hoursSkipped * 100 / (hoursWorked + hoursSkipped) + "%", hoursSkipped);
            */
            /*foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            chart1.Series["Series1"].Points.AddXY(hoursWorked, money); ;
            lbMoneyMadeMonth.Text = Convert.ToString(money) + "$";*/
        }

        private void Turnover()
        {
            //clears the chart
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }

        }

    
        private void btnToday_Click(object sender, EventArgs e)
        {
            counter = 0;
            keepTrack = today;

            monthLeft.Text = today.AddMonths(counter - 1).ToString("MMM").ToUpper();
            monthCenter.Text = today.ToString("MMM").ToUpper();
            monthRight.Text = today.AddMonths(counter + 1).ToString("MMM").ToUpper();

            yearLeft.Text = today.ToString("yyyy");
            yearCenter.Text = today.ToString("yyyy");
            yearRight.Text = today.ToString("yyyy");

            if (cbStatistic.Text == "Attendance per employee")
                AttendancePerEmployee();

            else if (cbStatistic.Text == "Attendance per department")
                AttendancePerDepartment();

            else if (cbStatistic.Text == "Turnover")
                Turnover();

            else if (cbStatistic.Text == "Wage per employee")
                WagePerEmployee();
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

            if (cbStatistic.Text == "Attendance per employee")
                AttendancePerEmployee();

            else if (cbStatistic.Text == "Attendance per department")
                AttendancePerDepartment();

            else if (cbStatistic.Text == "Turnover")
                Turnover();

            else if (cbStatistic.Text == "Wage per employee")
                WagePerEmployee();
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

            if (cbStatistic.Text == "Attendance per employee")
                AttendancePerEmployee();

            else if (cbStatistic.Text == "Attendance per department")
                AttendancePerDepartment();

            else if (cbStatistic.Text == "Turnover")
                Turnover();

            else if (cbStatistic.Text == "Wage per employee")
                WagePerEmployee();

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

            if (cbStatistic.Text.Contains("Attendance"))
            {
                //labels for y axis hours
                CustomLabel label1 = new CustomLabel
                {
                    FromPosition = 8.5,
                    ToPosition = 9.5,
                    Text = "09:00"
                };

                CustomLabel label2 = new CustomLabel
                {
                    FromPosition = 9.5,
                    ToPosition = 10.5,
                    Text = "10:00"
                };

                CustomLabel label3 = new CustomLabel
                {
                    FromPosition = 10.5,
                    ToPosition = 11.5,
                    Text = "11:00"
                };

                CustomLabel label4 = new CustomLabel
                {
                    FromPosition = 11.5,
                    ToPosition = 12.5,
                    Text = "12:00"
                };

                CustomLabel label5 = new CustomLabel
                {
                    FromPosition = 12.5,
                    ToPosition = 13.5,
                    Text = "13:00"
                };

                CustomLabel label6 = new CustomLabel
                {
                    FromPosition = 13.5,
                    ToPosition = 14.5,
                    Text = "14:00"
                };

                CustomLabel label7 = new CustomLabel
                {
                    FromPosition = 14.5,
                    ToPosition = 15.5,
                    Text = "15:00"
                };

                CustomLabel label8 = new CustomLabel
                {
                    FromPosition = 15.5,
                    ToPosition = 16.5,
                    Text = "16:00"
                };

                CustomLabel label9 = new CustomLabel
                {
                    FromPosition = 16.5,
                    ToPosition = 17.5,
                    Text = "17:00"
                };

                CustomLabel label10 = new CustomLabel
                {
                    FromPosition = 17.5,
                    ToPosition = 18.5,
                    Text = "18:00"
                };

                CustomLabel label11 = new CustomLabel
                {
                    FromPosition = 18.5,
                    ToPosition = 19.5,
                    Text = "19:00"
                };

                CustomLabel label12 = new CustomLabel
                {
                    FromPosition = 19.5,
                    ToPosition = 20.5,
                    Text = "20:00"
                };

                CustomLabel label13 = new CustomLabel
                {
                    FromPosition = 20.5,
                    ToPosition = 21.5,
                    Text = "21:00"
                };

                CustomLabel label14 = new CustomLabel
                {
                    FromPosition = 21.5,
                    ToPosition = 22.5,
                    Text = "22:00"
                };

                CustomLabel label15 = new CustomLabel
                {
                    FromPosition = 22.5,
                    ToPosition = 23.5,
                    Text = "23:00"
                };

                chart1.ChartAreas[0].AxisY.CustomLabels.Add(label1);
                chart1.ChartAreas[0].AxisY.CustomLabels.Add(label2);
                chart1.ChartAreas[0].AxisY.CustomLabels.Add(label3);
                chart1.ChartAreas[0].AxisY.CustomLabels.Add(label4);
                chart1.ChartAreas[0].AxisY.CustomLabels.Add(label5);
                chart1.ChartAreas[0].AxisY.CustomLabels.Add(label6);
                chart1.ChartAreas[0].AxisY.CustomLabels.Add(label7);
                chart1.ChartAreas[0].AxisY.CustomLabels.Add(label8);
                chart1.ChartAreas[0].AxisY.CustomLabels.Add(label9);
                chart1.ChartAreas[0].AxisY.CustomLabels.Add(label10);
                chart1.ChartAreas[0].AxisY.CustomLabels.Add(label11);
                chart1.ChartAreas[0].AxisY.CustomLabels.Add(label12);
                chart1.ChartAreas[0].AxisY.CustomLabels.Add(label13);
                chart1.ChartAreas[0].AxisY.CustomLabels.Add(label14);
                chart1.ChartAreas[0].AxisY.CustomLabels.Add(label15);

            }
            else
            {
                chart1.ChartAreas[0].AxisY.CustomLabels.Clear();
            }
        }

        private void Statistic_Load(object sender, EventArgs e)
        {

            cbEmployee.Hide();
            lbEmployee.Hide();
            
        }

        private void cbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbStatistic.Text == "Attendance per employee")
                AttendancePerEmployee();

            else if (cbStatistic.Text == "Attendance per department")
                AttendancePerDepartment();

            else if (cbStatistic.Text == "Turnover")
                Turnover();

            else if (cbStatistic.Text == "Wage per employee")
                WagePerEmployee();
        }
    }
}

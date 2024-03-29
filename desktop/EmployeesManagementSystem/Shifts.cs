﻿using EmployeesManagementSystem.Models;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;
using EmployeesManagementSystem.Controllers;

namespace EmployeesManagementSystem
{
    public partial class Shifts : Form
    {
        // Variables        
        private List<int> morningId;
        private List<int> afternoonId;
        private List<int> eveningId;

        private IDictionary<string, int> departmentList;
        private int addDays = 0;
        private int counter = 0;
        private char attendedMark = '*';


        private ShiftController controller = new ShiftController();
        private User loggedUser;

        // Constructor
        public Shifts(User user)
        {

            InitializeComponent();
            this.loggedUser = user;

            this.departmentList = new Dictionary<string, int>();

            morningId = new List<int>();
            afternoonId = new List<int>();
            eveningId = new List<int>();

            this.cbDepartment.Items.Add("All");


            // Add departments to their place
            List<Department> departments = controller.GetDepartments();
            foreach (Department department in departments)
            {
                this.cbDepartment.Items.Add(department.Name);
                this.departmentList.Add(department.Name, department.ID);
            }
        }


        private Color Enter = Color.DarkGray;
        private Color Leave = Color.LightGray;

        private void RoleDivision()
        {
            // Roles division
            if (this.loggedUser.Role == Models.Role.Manager)
            {
                this.btnEmployees.Enabled = true;
                this.btnCancellations.Enabled = true;
                this.btnCancellations.BackColor = Leave;
                this.btnDepartments.Enabled = true;

                this.btnStocks.Enabled = true;
                this.btnStocks.BackColor = Leave;

                this.btnStatistics.Enabled = true;
                this.btnStatistics.BackColor = Leave;

                this.btnShifts.Enabled = false;
                this.btnShifts.BackColor = Leave;

                this.btnTimetable.Enabled = true;
                this.btnTimetable.BackColor = Leave;

            }
            else if (this.loggedUser.Role == Models.Role.Administrator)
            {
                this.btnEmployees.Enabled = true;
                this.btnDepartments.Enabled = true;
                this.btnShifts.Enabled = true;

                this.btnStocks.Enabled = false;
                this.btnCancellations.Enabled = false;
                this.btnTimetable.Enabled = false;
                this.btnTimetable.BackColor = Leave;
                this.btnStatistics.Enabled = false;
            }

        }
        private void showDate(DateTime now)
        {
            this.dateCenter.Text = now.ToString("dd");
            this.monthCenter.Text = now.ToString("MMM").ToUpper();
            this.dateCenter.ForeColor = Color.Black;

            DateTime yesterday = now.AddDays(-1);
            this.dateLeft.Text = yesterday.ToString("dd");
            this.monthLeft.Text = yesterday.ToString("MMM").ToUpper();


            DateTime tomorrow = now.AddDays(+1);
            this.dateRight.Text = tomorrow.ToString("dd");
            this.monthRight.Text = tomorrow.ToString("MMM").ToUpper();
        }
        private void Shifts_Load(object sender, EventArgs e)
        {
            RoleDivision();
            DateTime now = DateTime.UtcNow.Date;
            showDate(now);

            displayShifts(now);
        }
        private void displayShifts(DateTime dateTime)
        {
            // Updating the shifts from db
            List<Shift> shifts = this.controller.GetShifts();
            if (this.cbDepartment.SelectedIndex > -1)
            {
                morningId.Clear();
                eveningId.Clear();
                afternoonId.Clear();
                string selectedDepartment = this.cbDepartment.SelectedItem.ToString();
                if (selectedDepartment.ToString() != "All")
                {
                    // Morning
                    List<Shift> morning = controller.getMorningShiftsForDate(dateTime);
                    this.morningList.Items.Clear();
                    foreach (var item in morning)
                    {
                        if (item.Department.ID == this.departmentList[selectedDepartment])
                        {

                            char mark = item.Attended ? attendedMark : ' ';

                            this.morningList.Items.Add(item.StartTime + "-" + item.EndTime + "     " + controller.GetUser(item.AssignedUser.ID).FullName + " " + mark);
                            morningId.Add(item.ID);
                        }
                    }

                    // Evening
                    List<Shift> evening = controller.getEveningShiftsForDate(dateTime);
                    this.eveningList.Items.Clear();
                    foreach (var item in evening)
                    {
                        if (item.Department.ID == this.departmentList[selectedDepartment])
                        {

                            char mark = item.Attended ? attendedMark : ' ';
                            this.eveningList.Items.Add(item.StartTime + "-" + item.EndTime + "     " + controller.GetUser(item.AssignedUser.ID).FullName + " " + mark);
                            eveningId.Add(item.ID);
                        }
                    }

                    // Afternoon
                    List<Shift> afternoon = controller.getAfternoonShiftsForDate(dateTime);
                    this.afternoonList.Items.Clear();
                    foreach (var item in afternoon)
                    {
                        if (item.Department.ID == this.departmentList[selectedDepartment])
                        {

                            char mark = item.Attended ? attendedMark : ' ';
                            this.afternoonList.Items.Add(item.StartTime + "-" + item.EndTime + "     " + controller.GetUser(item.AssignedUser.ID).FullName + " " + mark);
                            afternoonId.Add(item.ID);
                        }
                    }
                }
                else
                {
                    showAll(dateTime);
                }
            }
            else
            {
                showAll(dateTime);
            }

        }


        private void showAll(DateTime dateTime)
        {
            // Morning
            List<Shift> morning = controller.getMorningShiftsForDate(dateTime);
            morningId.Clear();
            eveningId.Clear();
            afternoonId.Clear();
            this.morningList.Items.Clear();
            foreach (var item in morning)
            {
                char mark = item.Attended ? attendedMark : ' ';
                this.morningList.Items.Add(item.StartTime + "-" + item.EndTime + "     " + controller.GetUser(item.AssignedUser.ID).FullName + " " + mark);
                morningId.Add(item.ID);
            }

            // Evening
            List<Shift> evening = controller.getEveningShiftsForDate(dateTime);
            this.eveningList.Items.Clear();
            foreach (var item in evening)
            {

                char mark = item.Attended ? attendedMark : ' ';
                this.eveningList.Items.Add(item.StartTime + "-" + item.EndTime + "     " + controller.GetUser(item.AssignedUser.ID).FullName + " " + mark);
                eveningId.Add(item.ID);


            }

            // Afternoon
            List<Shift> afternoon = controller.getAfternoonShiftsForDate(dateTime);
            this.afternoonList.Items.Clear();
            foreach (var item in afternoon)
            {

                char mark = item.Attended ? attendedMark : ' ';
                this.afternoonList.Items.Add(item.StartTime + "-" + item.EndTime + "     " + controller.GetUser(item.AssignedUser.ID).FullName + " " + mark);
                afternoonId.Add(item.ID);

            }
        }

        // Exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

            // exiting properly the application
            if (Application.MessageLoop)
            {
                Application.Exit();
            }
        }

        // Arrows
        private void arrowRight_Click(object sender, EventArgs e)
        {
            addDays++;
            showDate(DateTime.UtcNow.Date.AddDays(addDays));
            displayShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }
        private void arrowLeft_Click(object sender, EventArgs e)
        {

            addDays--;
            showDate(DateTime.UtcNow.Date.AddDays(addDays));
            displayShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }

        // Today
        private void btnToday_Click(object sender, EventArgs e)
        {
            addDays = 0;
            DateTime now = DateTime.UtcNow.Date;
            showDate(now);
            displayShifts(now);
        }

        // Display
        private void btnDisplay_Click(object sender, EventArgs e)
        {
            showDate(DateTime.UtcNow.Date.AddDays(addDays));
            displayShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }

        // Time
        private void currentTime_Tick(object sender, EventArgs e)
        {
            this.lbTime.Text = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt");
        }

        // Stocks
        private void btnStocks_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Stocks stock = new Stocks(this.loggedUser);
            stock.Closed += (s, args) => this.Close();
            stock.Show();
        }

        // Departments
        private void btnDepartments_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Departments dep = new Departments(this.loggedUser);
            dep.Closed += (s, args) => this.Close();
            dep.Show();
        }

        // Cancellations
        private void btnCancellations_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Messages cncl = new Messages(this.loggedUser);
            cncl.Closed += (s, args) => this.Close();
            cncl.Show();
        }

        // Employees
        private void btnEmployees_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Dashboard dashboard = new Dashboard(this.loggedUser);
            dashboard.Closed += (s, args) => this.Close();
            dashboard.Show();
        }
        private void btnStatistics_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Statistic stat = new Statistic(loggedUser, this);
            stat.Closed += (s, args) => this.Close();
            stat.Show();
        }

        // Settings
        private void Settings_Click(object sender, EventArgs e)
        {
            settingsPanel.Visible = !settingsPanel.Visible;
        }
        private void editAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Admin details
            AdminDetails adminDetails = new AdminDetails(this.loggedUser, this);
            adminDetails.Closed += (s, args) => this.Hide();
            adminDetails.Show();
        }
        private void LogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Log In
            Login login = new Login();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }


        // Hovering
        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            this.btnExit.BackColor = Color.LightGray;
        }
        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            this.btnExit.BackColor = Color.White;
        }
        private void btnEmployees_MouseEnter(object sender, EventArgs e)
        {
            this.btnEmployees.BackColor = Color.DarkGray;
        }
        private void btnEmployees_MouseLeave(object sender, EventArgs e)
        {
            this.btnEmployees.BackColor = Color.LightGray;
        }
        private void btnShifts_MouseEnter(object sender, EventArgs e)
        {
            this.btnShifts.BackColor = Color.DarkGray;
        }
        private void btnShifts_MouseLeave(object sender, EventArgs e)
        {
            this.btnShifts.BackColor = Color.LightGray;
        }
        private void btnCancellations_MouseEnter(object sender, EventArgs e)
        {
            this.btnCancellations.BackColor = Color.DarkGray;
        }
        private void btnCancellations_MouseLeave(object sender, EventArgs e)
        {
            this.btnCancellations.BackColor = Color.LightGray;
        }
        private void btnDepartments_MouseEnter(object sender, EventArgs e)
        {
            this.btnDepartments.BackColor = Color.DarkGray;
        }
        private void btnDepartments_MouseLeave(object sender, EventArgs e)
        {
            this.btnDepartments.BackColor = Color.LightGray;
        }
        private void btnStocks_MouseEnter(object sender, EventArgs e)
        {
            this.btnStocks.BackColor = Color.DarkGray;
        }
        private void btnStocks_MouseLeave(object sender, EventArgs e)
        {
            this.btnStocks.BackColor = Color.LightGray;
        }
        private void btnStatistics_MouseEnter(object sender, EventArgs e)
        {
            this.btnStatistics.BackColor = Color.DarkGray;
        }
        private void btnStatistics_MouseLeave(object sender, EventArgs e)
        {
            this.btnStatistics.BackColor = Color.LightGray;
        }
        private void btnToday_MouseEnter(object sender, EventArgs e)
        {
            this.btnToday.BackColor = Color.DarkGray;
        }
        private void btnToday_MouseLeave(object sender, EventArgs e)
        {
            this.btnToday.BackColor = Color.LightGray;
        }
        private void btnDisplay_MouseEnter(object sender, EventArgs e)
        {
            this.btnDisplay.BackColor = Color.DarkGray;
        }
        private void btnDisplay_MouseLeave(object sender, EventArgs e)
        {
            this.btnDisplay.BackColor = Color.LightGray;
        }
        private void btnArrowRight_MouseEnter(object sender, EventArgs e)
        {
            this.btnArrowRight.BackColor = Color.DarkGray;
        }
        private void btnArrowRight_MouseLeave(object sender, EventArgs e)
        {
            this.btnArrowRight.BackColor = Color.LightGray;
        }
        private void btnArrowLeft_MouseEnter(object sender, EventArgs e)
        {
            this.btnArrowLeft.BackColor = Color.DarkGray;
        }
        private void btnArrowLeft_MouseLeave(object sender, EventArgs e)
        {
            this.btnArrowLeft.BackColor = Color.LightGray;
        }
        private void btnSettings_MouseEnter(object sender, EventArgs e)
        {
            this.btnSettings.BackColor = Color.DarkGray;
        }
        private void btnSettings_MouseLeave(object sender, EventArgs e)
        {
            this.btnSettings.BackColor = Color.LightGray;
        }

        private void btnAttended_Click(object sender, EventArgs e)
        {
            if (morningList.SelectedItem != null)
            {
                int shiftId = morningId[morningList.SelectedIndex];
                Shift shiftAttended = controller.shiftContext.GetShiftByID(shiftId);
                shiftAttended.Attended = true;
                shiftAttended.Cancelled = false;
                controller.shiftContext.UpdateShift(shiftAttended);
            }

            if (afternoonList.SelectedItem != null)
            {
                int shiftId = afternoonId[afternoonList.SelectedIndex];
                Shift shiftAttended = controller.shiftContext.GetShiftByID(shiftId);
                shiftAttended.Attended = true;
                shiftAttended.Cancelled = false;
                controller.shiftContext.UpdateShift(shiftAttended);
            }

            if (eveningList.SelectedItem != null)
            {
                int shiftId = eveningId[eveningList.SelectedIndex];
                Shift shiftAttended = controller.shiftContext.GetShiftByID(shiftId);
                shiftAttended.Attended = true;
                shiftAttended.Cancelled = false;
                controller.shiftContext.UpdateShift(shiftAttended);
            }

            MessageBox.Show("The employee(s) have been marked as present.");


            // Updating listing of shifts 
            displayShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }

        private void btnMissed_Click(object sender, EventArgs e)
        {

            if (morningList.SelectedItem != null)
            {
                int shiftId = morningId[morningList.SelectedIndex];
                Shift shiftAttended = controller.shiftContext.GetShiftByID(shiftId);
                shiftAttended.Attended = false;
                shiftAttended.Cancelled = true;
                controller.shiftContext.UpdateShift(shiftAttended);
            }

            else if (afternoonList.SelectedItem != null)
            {
                int shiftId = afternoonId[afternoonList.SelectedIndex];
                Shift shiftAttended = controller.shiftContext.GetShiftByID(shiftId);
                shiftAttended.Attended = false;
                shiftAttended.Cancelled = true;
                controller.shiftContext.UpdateShift(shiftAttended);
            }

            else if (eveningList.SelectedItem != null)
            {
                int shiftId = eveningId[eveningList.SelectedIndex];
                Shift shiftAttended = controller.shiftContext.GetShiftByID(shiftId);
                shiftAttended.Attended = false;
                shiftAttended.Cancelled = true;
                controller.shiftContext.UpdateShift(shiftAttended);
            }

            MessageBox.Show("The employee(s) have been marked as absent.");

            // Updating listing of shifts 
            displayShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnScan_Paint(object sender, PaintEventArgs e)
        {
            UserRfidTag userRfid = new UserRfidTag();
            userRfid.Show();
        }
    }
}

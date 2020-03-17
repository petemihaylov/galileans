using EmployeesManagementSystem.Data;
using EmployeesManagementSystem.Models;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;


namespace EmployeesManagementSystem
{
    public partial class Shifts : Form
    {
        private ShiftContext shiftContext = new ShiftContext();
        private UserContext userContext = new UserContext();

        private List<Shift> shifts;
        private User loggedUser;
        private int addDays = 0;

        public Shifts(User user)
        {
            InitializeComponent();
            this.shifts = shiftContext.GetAllShifts();
            this.loggedUser = user;
        }

        private void showDate(DateTime now)
        {
            dateCenter.Text = now.ToString("dd");
            monthCenter.Text = now.ToString("MMM").ToUpper();
            dateCenter.ForeColor = Color.Black;

            DateTime yesterday = now.AddDays(-1);
            dateLeft.Text = yesterday.ToString("dd");
            monthLeft.Text = yesterday.ToString("MMM").ToUpper();


            DateTime tomorrow = now.AddDays(+1);
            dateRight.Text = tomorrow.ToString("dd");
            monthRight.Text = tomorrow.ToString("MMM").ToUpper();
        }
        private void Shifts_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.UtcNow.Date;
            showDate(now);

            displayShifts(now);
        }
        private void displayShifts(DateTime dateTime)
        {
            // MORNING
            List<Shift> morning = getMorningShiftsForDate(dateTime);
            this.morningList.Items.Clear();
            foreach (var item in morning)
            {
                this.morningList.Items.Add(item.StartTime.ToString("hh:mm") + "-" + item.EndTime.ToString("hh:mm tt") + "     " + userContext.GetUserByID(item.AssignedEmployeeID).FullName);
            }

            // EVENING
            List<Shift> evening = getEveningShiftsForDate(dateTime);
            this.eveningList.Items.Clear();
            foreach (var item in evening)
            {
               this.eveningList.Items.Add(item.StartTime.ToString("hh:mm") + "-" + item.EndTime.ToString("hh:mm tt") + "     " + userContext.GetUserByID(item.AssignedEmployeeID).FullName);
            }

            // AFTERNOON
            List<Shift> afternoon = getAfternoonShiftsForDate(dateTime);
            this.afternoonList.Items.Clear();
            foreach (var item in afternoon)
            {
                this.afternoonList.Items.Add(item.StartTime.ToString("hh:mm") + "-" + item.EndTime.ToString("hh:mm tt") + "     " + userContext.GetUserByID(item.AssignedEmployeeID).FullName);
            }

        }
        private List<Shift> getMorningShiftsForDate(DateTime dateTime)
        {
            List<Shift> list = new List<Shift>();
            foreach (var item in shifts)
            {
                if(item.Type == ShiftType.MORNING && (DateTime.Compare(dateTime.Date, item.ShiftDate.Date)) ==  0)
                {
                    list.Add(item);
                }
            }
            return list;
        }
        private List<Shift> getAfternoonShiftsForDate(DateTime dateTime)
        {
            List<Shift> list = new List<Shift>();
            foreach (var item in shifts)
            {
                if (item.Type == ShiftType.AFTERNOON && (DateTime.Compare(dateTime.Date, item.ShiftDate.Date)) == 0)
                {
                    list.Add(item);
                }
            }
            return list;
        }
        private List<Shift> getEveningShiftsForDate(DateTime dateTime)
        {
            List<Shift> list = new List<Shift>();
            foreach (var item in shifts)
            {
                if (item.Type == ShiftType.EVENING && (DateTime.Compare(dateTime.Date, item.ShiftDate.Date)) == 0)
                {
                    list.Add(item);
                }
            }
            return list;
        }
        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void btnToday_Click(object sender, EventArgs e)
        {
            addDays = 0;
            DateTime now = DateTime.UtcNow.Date;
            showDate(now);
            displayShifts(now);
        }
        private void currentTime_Tick(object sender, EventArgs e)
        {
            this.lbTime.Text = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss tt");
        }
        private void btnStocks_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Stocks stock = new Stocks(this.loggedUser);
            stock.Closed += (s, args) => this.Close();
            stock.Show();
        }
        private void btnDepartments_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Departments dep = new Departments(this.loggedUser);
            dep.Closed += (s, args) => this.Close();
            dep.Show();
        }
        private void btnCancellations_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Cancellations cncl = new Cancellations(this.loggedUser);
            cncl.Closed += (s, args) => this.Close();
            cncl.Show();
        }
        private void btnEmployee_MouseEnter(object sender, EventArgs e)
        {
            Color color = Color.DarkGray;
            this.btnEmployee.BackColor = color;
        }
        private void btnEmployee_MouseLeave(object sender, EventArgs e)
        {
            Color color = Color.LightGray;
            this.btnEmployee.BackColor = color;
        }
        private void btnEmployee_Click(object sender, EventArgs e)
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
            Statistic stat = new Statistic(this.loggedUser);
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
    }
}

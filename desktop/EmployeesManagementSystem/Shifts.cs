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
        // Variables
        private ShiftContext shiftContext = new ShiftContext();
        private UserContext userContext = new UserContext();

        private List<Shift> shifts;
        private User loggedUser;
        private int addDays = 0;

        // Default constructor
        public Shifts()
        {

        }

        // Constructor
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

        // Exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
            Cancellations cncl = new Cancellations(this.loggedUser);
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

        // Settings
        private void editAccount_Click(object sender, EventArgs e)
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
        private void lblLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Log In
            Login login = new Login();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            settingsPanel.Visible = !settingsPanel.Visible;
        }

        private void lbSettings_Click(object sender, EventArgs e)
        {
            settingsPanel.Visible = !settingsPanel.Visible;
        }

        // Statistics
        private void btnStatistics_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Statistic stat = new Statistic(this.loggedUser);
            stat.Closed += (s, args) => this.Close();
            stat.Show();
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
    }
}

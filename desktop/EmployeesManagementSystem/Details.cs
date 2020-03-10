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
    public partial class Details : Form
    {
        private DbContext databaseContext = new DbContext();
        private User user;
        private List<Shift> shifts;
        private int id;
        private int addDays = 0;


        public Details(int UserID)
        {
            InitializeComponent();

            this.user = databaseContext.GetUserByID(UserID);
            this.id = UserID;
            this.tbFullName.Text = user.FullName;
            this.tbPassword.Text = user.Password;
            this.tbEmail.Text = user.Email;
            // this.tbLocation.Text = "to add in db";
            this.tbPhoneNumber.Text = user.PhoneNumber;
            this.cbRole.Text = user.Role;
            // this.cbDepartment.Text = "to add in db";
        }

        // Shifts
        private void Details_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.UtcNow.Date;
            showDate(now);
            shifts = databaseContext.GetAllShifts();
            visualizeShifts(now);
        }

        private void visualizeShifts(DateTime date)
        {
            //morning
            List<Shift> morning = getMorningShiftsForDate(date);
            resetShiftVisualMorning();
            foreach (var item in morning)
            {
                if(item.StartTime.Hour == 9)
                {
                    if (item.Availability) { lbMorn_first.Font = new Font("Arial", float.Parse("10.2")); picMor_first.Image = Properties.Resources.btnAdd; lbMorn_first.ForeColor = Color.Black; }
                    else { lbMorn_first.Font = new Font("Arial", float.Parse("10.2"), FontStyle.Strikeout); picMor_first.Image = Properties.Resources.btnBlock; lbMorn_first.ForeColor = Color.DimGray; }
                }

                if(item.StartTime.Hour == 10)
                {
                    if (item.Availability) { lbMorn_second.Font = new Font("Arial", float.Parse("10.2")); picMor_second.Image = Properties.Resources.btnAdd; lbMorn_second.ForeColor = Color.Black; }
                    else { lbMorn_second.Font = new Font("Arial", float.Parse("10.2"), FontStyle.Strikeout); picMor_second.Image = Properties.Resources.btnBlock; lbMorn_second.ForeColor = Color.DimGray; }
                }

                if (item.StartTime.Hour == 11)
                {
                    if (item.Availability) { lbMorn_third.Font = new Font("Arial", float.Parse("10.2")); picMor_third.Image = Properties.Resources.btnAdd; lbMorn_third.ForeColor = Color.Black; }

                    else { lbMorn_third.Font = new Font("Arial", float.Parse("10.2"), FontStyle.Strikeout); picMor_third.Image = Properties.Resources.btnBlock; lbMorn_third.ForeColor = Color.DimGray; }
                }
            }

            // afternoon
            List<Shift> afternoon = getAfternoonShiftsForDate(date);
            resetShiftVisualAfternoon();
            foreach (var item in afternoon)
            {
                if (item.StartTime.Hour == 14)
                {
                    if (item.Availability) { lbAft_first.Font = new Font("Arial", float.Parse("10.2")); picAft_first.Image = Properties.Resources.btnAdd; lbAft_first.ForeColor = Color.Black; }
                    else { lbAft_first.Font = new Font("Arial", float.Parse("10.2"), FontStyle.Strikeout); picAft_first.Image = Properties.Resources.btnBlock; lbAft_first.ForeColor = Color.DimGray; }
                }

                if (item.StartTime.Hour == 15)
                {
                    if (item.Availability) { lbAft_second.Font = new Font("Arial", float.Parse("10.2")); picAft_second.Image = Properties.Resources.btnAdd; lbAft_second.ForeColor = Color.Black; }
                    else { lbAft_second.Font = new Font("Arial", float.Parse("10.2"), FontStyle.Strikeout); picAft_second.Image = Properties.Resources.btnBlock; lbAft_second.ForeColor = Color.DimGray; }
                }

                if (item.StartTime.Hour == 16)
                {
                    if (item.Availability) { lbAft_third.Font = new Font("Arial", float.Parse("10.2")); picAft_third.Image = Properties.Resources.btnAdd; lbAft_third.ForeColor = Color.Black; }

                    else { lbAft_third.Font = new Font("Arial", float.Parse("10.2"), FontStyle.Strikeout); picAft_third.Image = Properties.Resources.btnBlock; lbAft_third.ForeColor = Color.DimGray; }
                }
            }

            // evening
            List<Shift> evening = getEveningShiftsForDate(date);
            resetShiftVisualEvening();
            foreach (var item in evening)
            {
                if (item.StartTime.Hour == 20)
                {
                    if (item.Availability) { lbEvn_first.Font = new Font("Arial", float.Parse("10.2")); picEvn_first.Image = Properties.Resources.btnAdd; lbEvn_first.ForeColor = Color.Black; }
                    else { lbEvn_first.Font = new Font("Arial", float.Parse("10.2"), FontStyle.Strikeout); picEvn_first.Image = Properties.Resources.btnBlock; lbEvn_first.ForeColor = Color.DimGray; }
                }

                if (item.StartTime.Hour == 21)
                {
                    if (item.Availability) { lbEvn_second.Font = new Font("Arial", float.Parse("10.2")); picEvn_second.Image = Properties.Resources.btnAdd; lbEvn_second.ForeColor = Color.Black; }
                    else { lbEvn_second.Font = new Font("Arial", float.Parse("10.2"), FontStyle.Strikeout); picEvn_second.Image = Properties.Resources.btnBlock; lbEvn_second.ForeColor = Color.DimGray; }
                }

                if (item.StartTime.Hour == 22)
                {
                    if (item.Availability) { lbEvn_third.Font = new Font("Arial", float.Parse("10.2")); picEvn_third.Image = Properties.Resources.btnAdd; lbEvn_third.ForeColor = Color.Black; }

                    else { lbEvn_third.Font = new Font("Arial", float.Parse("10.2"), FontStyle.Strikeout); picEvn_third.Image = Properties.Resources.btnBlock; lbEvn_third.ForeColor = Color.DimGray; }
                }
            }
        }
        private void resetShiftVisualMorning()
        {
            // Morning
            lbMorn_first.Font = new Font("Arial", float.Parse("10.2"));
            lbMorn_first.ForeColor = Color.Black;
            picMor_first.Image = Properties.Resources.btnAdd;

            lbMorn_second.Font = new Font("Arial", float.Parse("10.2"));
            lbMorn_second.ForeColor = Color.Black;
            picMor_second.Image = Properties.Resources.btnAdd;

            lbMorn_third.Font = new Font("Arial", float.Parse("10.2"));
            lbMorn_third.ForeColor = Color.Black;
            picMor_third.Image = Properties.Resources.btnAdd;
        }

        private void resetShiftVisualAfternoon() 
        { 
            // Afernoon
            lbAft_first.Font = new Font("Arial", float.Parse("10.2"));
            lbAft_first.ForeColor = Color.Black;
            picAft_first.Image = Properties.Resources.btnAdd;
            
            lbAft_second.Font = new Font("Arial", float.Parse("10.2"));
            lbAft_second.ForeColor = Color.Black;
            picAft_second.Image = Properties.Resources.btnAdd;
            
            lbAft_third.Font = new Font("Arial", float.Parse("10.2"));
            lbAft_third.ForeColor = Color.Black;
            picAft_third.Image = Properties.Resources.btnAdd;
        }

        private void resetShiftVisualEvening()
        {
            // Evening
            lbEvn_first.Font = new Font("Arial", float.Parse("10.2"));
            lbEvn_first.ForeColor = Color.Black;
            picEvn_first.Image = Properties.Resources.btnAdd;

            lbEvn_second.Font = new Font("Arial", float.Parse("10.2"));
            lbEvn_second.ForeColor = Color.Black;
            picEvn_second.Image = Properties.Resources.btnAdd;

            lbEvn_third.Font = new Font("Arial", float.Parse("10.2"));
            lbEvn_third.ForeColor = Color.Black;
            picEvn_third.Image = Properties.Resources.btnAdd;
        }

        private List<Shift> getMorningShiftsForDate(DateTime dateTime)
        {
            List<Shift> list = new List<Shift>();
            shifts = databaseContext.GetAllShifts();
            foreach (var item in shifts)
            {
                if (item.Type == ShiftType.MORNING && (DateTime.Compare(dateTime.Date, item.ShiftDate.Date)) == 0)
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Fields should be validated!

            databaseContext.UpdateUserInfo(user.ID, tbFullName.Text, tbEmail.Text, tbPassword.Text, tbPhoneNumber.Text, cbRole.Text);           
            databaseContext.Dispose(true);
            MessageBox.Show("User updated!");


            this.Hide();
            // Show Dashboard
            Dashboard dashboard = new Dashboard();
            dashboard.Closed += (s, args) => this.Close();
            dashboard.Show();

        }

        // Buttons
        private void picBack_Click(object sender, EventArgs e)
        {

            databaseContext.Dispose(true);
            this.Close();
            // Show Dashboard
            Dashboard dashboard = new Dashboard();
            dashboard.Closed += (s, args) => this.Close();
            dashboard.Show();

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

        private void lbBack_Click(object sender, EventArgs e)
        {
            databaseContext.Dispose(true);
            this.Close();
            // Show Dashboard
            Dashboard dashboard = new Dashboard();
            dashboard.Closed += (s, args) => this.Close();
            dashboard.Show();
        }

        private void arrowRight_Click(object sender, EventArgs e)
        {
            addDays++;
            showDate(DateTime.UtcNow.Date.AddDays(addDays));
            visualizeShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }

        private void arrowLeft_Click(object sender, EventArgs e)
        {
            addDays--;
            showDate(DateTime.UtcNow.Date.AddDays(addDays));
            visualizeShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }

        private void picMor_first_Click(object sender, EventArgs e)
        {

            DateTime d = DateTime.UtcNow.Date.AddDays(addDays).Date;
            if (lbMorn_first.ForeColor != Color.DimGray)
            {
                
                databaseContext.InsertShift(new Shift(user.ID, false, d,
                    new DateTime(d.Year, d.Month,d.Day,9,0,0), new DateTime(d.Year, d.Month, d.Day, 10, 0, 0), ShiftType.MORNING, false));

            }else
            {
                Shift shift = databaseContext.GetShiftByDate(d, new DateTime(d.Year, d.Month, d.Day, 9, 0, 0));
                databaseContext.DeleteShiftByID(shift.ID);
            }

            visualizeShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }

        private void picMor_second_Click(object sender, EventArgs e)
        {

            DateTime d = DateTime.UtcNow.Date.AddDays(addDays).Date;
            if (lbMorn_second.ForeColor != Color.DimGray)
            {

                databaseContext.InsertShift(new Shift(user.ID, false, d,
                    new DateTime(d.Year, d.Month, d.Day, 10, 0, 0), new DateTime(d.Year, d.Month, d.Day, 11, 0, 0), ShiftType.MORNING, false));

            }
            else
            {
                Shift shift = databaseContext.GetShiftByDate(d, new DateTime(d.Year, d.Month, d.Day, 10, 0, 0));
                databaseContext.DeleteShiftByID(shift.ID);
            }

            visualizeShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }

        private void picMor_third_Click(object sender, EventArgs e)
        {
            DateTime d = DateTime.UtcNow.Date.AddDays(addDays).Date;
            if (lbMorn_third.ForeColor != Color.DimGray)
            {

                databaseContext.InsertShift(new Shift(user.ID, false, d,
                    new DateTime(d.Year, d.Month, d.Day, 11, 0, 0), new DateTime(d.Year, d.Month, d.Day, 12, 0, 0), ShiftType.MORNING, false));

            }
            else
            {
                Shift shift = databaseContext.GetShiftByDate(d, new DateTime(d.Year, d.Month, d.Day, 11, 0, 0));
                databaseContext.DeleteShiftByID(shift.ID);
            }

            visualizeShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }

        private void picAft_first_Click(object sender, EventArgs e)
        {

            DateTime d = DateTime.UtcNow.Date.AddDays(addDays).Date;
            if (lbAft_first.ForeColor != Color.DimGray)
            {

                databaseContext.InsertShift(new Shift(user.ID, false, d,
                    new DateTime(d.Year, d.Month, d.Day, 14, 0, 0), new DateTime(d.Year, d.Month, d.Day, 15, 0, 0), ShiftType.AFTERNOON, false));

            }
            else
            {
                Shift shift = databaseContext.GetShiftByDate(d, new DateTime(d.Year, d.Month, d.Day, 14, 0, 0));
                databaseContext.DeleteShiftByID(shift.ID);
            }

            visualizeShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }

        private void picAft_second_Click(object sender, EventArgs e)
        {
            DateTime d = DateTime.UtcNow.Date.AddDays(addDays).Date;
            if (lbAft_second.ForeColor != Color.DimGray)
            {

                databaseContext.InsertShift(new Shift(user.ID, false, d,
                    new DateTime(d.Year, d.Month, d.Day, 15, 0, 0), new DateTime(d.Year, d.Month, d.Day, 16, 0, 0), ShiftType.AFTERNOON, false));

            }
            else
            {
                Shift shift = databaseContext.GetShiftByDate(d, new DateTime(d.Year, d.Month, d.Day, 15, 0, 0));
                databaseContext.DeleteShiftByID(shift.ID);
            }

            visualizeShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }

        private void picAft_third_Click(object sender, EventArgs e)
        {

            DateTime d = DateTime.UtcNow.Date.AddDays(addDays).Date;
            if (lbAft_third.ForeColor != Color.DimGray)
            {

                databaseContext.InsertShift(new Shift(user.ID, false, d,
                    new DateTime(d.Year, d.Month, d.Day, 16, 0, 0), new DateTime(d.Year, d.Month, d.Day, 17, 0, 0), ShiftType.AFTERNOON, false));

            }
            else
            {
                Shift shift = databaseContext.GetShiftByDate(d, new DateTime(d.Year, d.Month, d.Day, 16, 0, 0));
                databaseContext.DeleteShiftByID(shift.ID);
            }

            visualizeShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }

        private void picEvn_first_Click(object sender, EventArgs e)
        {

            DateTime d = DateTime.UtcNow.Date.AddDays(addDays).Date;
            if (lbEvn_first.ForeColor != Color.DimGray)
            {

                databaseContext.InsertShift(new Shift(user.ID, false, d,
                    new DateTime(d.Year, d.Month, d.Day, 20, 0, 0), new DateTime(d.Year, d.Month, d.Day, 21, 0, 0), ShiftType.EVENING, false));

            }
            else
            {
                Shift shift = databaseContext.GetShiftByDate(d, new DateTime(d.Year, d.Month, d.Day, 20, 0, 0));
                databaseContext.DeleteShiftByID(shift.ID);
            }

            visualizeShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }
        private void picEvn_second_Click(object sender, EventArgs e)
        {

            DateTime d = DateTime.UtcNow.Date.AddDays(addDays).Date;
            if (lbEvn_second.ForeColor != Color.DimGray)
            {

                databaseContext.InsertShift(new Shift(user.ID, false, d,
                    new DateTime(d.Year, d.Month, d.Day, 21, 0, 0), new DateTime(d.Year, d.Month, d.Day, 22, 0, 0), ShiftType.EVENING, false));

            }
            else
            {
                Shift shift = databaseContext.GetShiftByDate(d, new DateTime(d.Year, d.Month, d.Day, 21, 0, 0));
                databaseContext.DeleteShiftByID(shift.ID);
            }

            visualizeShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }

        private void picEvn_third_Click(object sender, EventArgs e)
        {

            DateTime d = DateTime.UtcNow.Date.AddDays(addDays).Date;
            if (lbEvn_third.ForeColor != Color.DimGray)
            {

                databaseContext.InsertShift(new Shift(user.ID, false, d,
                    new DateTime(d.Year, d.Month, d.Day, 22, 0, 0), new DateTime(d.Year, d.Month, d.Day, 23, 0, 0), ShiftType.EVENING, false));

            }
            else
            {
                Shift shift = databaseContext.GetShiftByDate(d, new DateTime(d.Year, d.Month, d.Day, 22, 0, 0));
                databaseContext.DeleteShiftByID(shift.ID);
            }

            visualizeShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            addDays = 0;
            DateTime now = DateTime.UtcNow.Date;
            showDate(now);
            visualizeShifts(now);
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            databaseContext.Dispose(true);
            this.Hide();
            // Show Selected Form
            Statistic stat = new Statistic(id);
            stat.Closed += (s, args) => this.Close();
            stat.Show();
        }
    }
}

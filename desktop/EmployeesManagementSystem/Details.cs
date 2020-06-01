using System;
using System.Net;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using EmployeesManagementSystem.Data;
using EmployeesManagementSystem.Models;
using System.Text.RegularExpressions;

namespace EmployeesManagementSystem
{
    public partial class Details : Form
    {

        // Need to be refactored


        // Variables
        private UserContext userContext = new UserContext();
        private ShiftContext shiftContext = new ShiftContext();
        private ImageContext imageContext = new ImageContext();
        private AvailabilityContext availabilityContext = new AvailabilityContext();
        private DepartmentContext departmentContext = new DepartmentContext();
        private UserDepartmentContext userDepartmentContext = new UserDepartmentContext();

        private Form previousForm;

        private int id;
        private int addDays = 0;
        private Department department;

        private User user;
        private User loggedUser;
        private List<Shift> shifts;
        private Dashboard dashboard = null;

        // Constructor
        public Details(int UserID, User loggedUser, Form previousForm)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            this.previousForm = previousForm;

            this.user = userContext.GetUserByID(UserID);
            this.id = UserID;

            this.department = userDepartmentContext.GetDepartmentByUser(user.ID);
            this.tbFullName.Text = user.FullName;
            this.tbEmail.Text = user.Email;

            this.tbPhoneNumber.Text = user.PhoneNumber;
            this.cbRole.Text = user.Role.ToString();
            foreach (Department d in departmentContext.GetAllDepartments())
            {
                this.cbDepartment.Items.Add(d.Name);
            }
            if (department != null)
                this.cbDepartment.Text = department.Name;


            foreach (Availability availability in availabilityContext.GetAllAvailabilitiesByID(UserID))
            {
                listOfAvailabilities.Items.Add(" shift: " + availability.Date.ToString() + " " + userDepartmentContext.GetDepartmentByUser(availability.User.ID).Name + "  " + user.FullName);
            }

        }
        public void DashoboardUpdate(Dashboard dashboard)
        {
            this.dashboard = dashboard;
        }
        private void Details_Load(object sender, EventArgs e)
        {
            this.UpdateImg(user.ID);
            DateTime now = DateTime.UtcNow.Date;
            showDate(now);
            this.shifts = shiftContext.GetAllShifts();
            visualizeShifts(now);
        }

        private void visualizeShifts(DateTime date)
        {
            //morning
            List<Shift> morning = getMorningShiftsForDate(date);
            resetShiftVisualMorning();
            foreach (var item in morning)
            {
                if (item.StartTime.Hour == 9)
                {
                    if (item.Availability) { lbMorn_first.Font = new Font("Arial", float.Parse("10.2")); picMor_first.Image = Properties.Resources.btnAdd; lbMorn_first.ForeColor = Color.Black; }
                    else
                    {
                        lbMorn_first.Font = new Font("Arial", float.Parse("10.2"), FontStyle.Strikeout); picMor_first.Image = Properties.Resources.btnBlock; lbMorn_first.ForeColor = Color.DimGray;
                        if (user.ID == item.AssignedUser.ID) picMor_first.Image = Properties.Resources.taken1;
                    }
                }

                if (item.StartTime.Hour == 10)
                {
                    if (item.Availability) { lbMorn_second.Font = new Font("Arial", float.Parse("10.2")); picMor_second.Image = Properties.Resources.btnAdd; lbMorn_second.ForeColor = Color.Black; }
                    else
                    {
                        lbMorn_second.Font = new Font("Arial", float.Parse("10.2"), FontStyle.Strikeout); picMor_second.Image = Properties.Resources.btnBlock; lbMorn_second.ForeColor = Color.DimGray;
                        if (user.ID == item.AssignedUser.ID) picMor_second.Image = Properties.Resources.taken1;
                    }
                }

                if (item.StartTime.Hour == 11)
                {
                    if (item.Availability) { lbMorn_third.Font = new Font("Arial", float.Parse("10.2")); picMor_third.Image = Properties.Resources.btnAdd; lbMorn_third.ForeColor = Color.Black; }

                    else
                    {
                        lbMorn_third.Font = new Font("Arial", float.Parse("10.2"), FontStyle.Strikeout); picMor_third.Image = Properties.Resources.btnBlock; lbMorn_third.ForeColor = Color.DimGray;
                        if (user.ID == item.AssignedUser.ID) picMor_third.Image = Properties.Resources.taken1;
                    }
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
                    else
                    {
                        lbAft_first.Font = new Font("Arial", float.Parse("10.2"), FontStyle.Strikeout); picAft_first.Image = Properties.Resources.btnBlock; lbAft_first.ForeColor = Color.DimGray;
                        if (user.ID == item.AssignedUser.ID) picAft_first.Image = Properties.Resources.taken1;
                    }
                }

                if (item.StartTime.Hour == 15)
                {
                    if (item.Availability) { lbAft_second.Font = new Font("Arial", float.Parse("10.2")); picAft_second.Image = Properties.Resources.btnAdd; lbAft_second.ForeColor = Color.Black; }
                    else
                    {
                        lbAft_second.Font = new Font("Arial", float.Parse("10.2"), FontStyle.Strikeout); picAft_second.Image = Properties.Resources.btnBlock; lbAft_second.ForeColor = Color.DimGray;
                        if (user.ID == item.AssignedUser.ID) picAft_second.Image = Properties.Resources.taken1;
                    }
                }

                if (item.StartTime.Hour == 16)
                {
                    if (item.Availability) { lbAft_third.Font = new Font("Arial", float.Parse("10.2")); picAft_third.Image = Properties.Resources.btnAdd; lbAft_third.ForeColor = Color.Black; }

                    else
                    {
                        lbAft_third.Font = new Font("Arial", float.Parse("10.2"), FontStyle.Strikeout); picAft_third.Image = Properties.Resources.btnBlock; lbAft_third.ForeColor = Color.DimGray;
                        if (user.ID == item.AssignedUser.ID) picAft_third.Image = Properties.Resources.taken1;
                    }
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
                    else
                    {
                        lbEvn_first.Font = new Font("Arial", float.Parse("10.2"), FontStyle.Strikeout); picEvn_first.Image = Properties.Resources.btnBlock; lbEvn_first.ForeColor = Color.DimGray;
                        if (user.ID == item.AssignedUser.ID) picEvn_first.Image = Properties.Resources.taken1;
                    }
                }

                if (item.StartTime.Hour == 21)
                {
                    if (item.Availability) { lbEvn_second.Font = new Font("Arial", float.Parse("10.2")); picEvn_second.Image = Properties.Resources.btnAdd; lbEvn_second.ForeColor = Color.Black; }
                    else
                    {
                        lbEvn_second.Font = new Font("Arial", float.Parse("10.2"), FontStyle.Strikeout); picEvn_second.Image = Properties.Resources.btnBlock; lbEvn_second.ForeColor = Color.DimGray;
                        if (user.ID == item.AssignedUser.ID) picEvn_second.Image = Properties.Resources.taken1;
                    }
                }

                if (item.StartTime.Hour == 22)
                {
                    if (item.Availability) { lbEvn_third.Font = new Font("Arial", float.Parse("10.2")); picEvn_third.Image = Properties.Resources.btnAdd; lbEvn_third.ForeColor = Color.Black; }

                    else
                    {
                        lbEvn_third.Font = new Font("Arial", float.Parse("10.2"), FontStyle.Strikeout); picEvn_third.Image = Properties.Resources.btnBlock; lbEvn_third.ForeColor = Color.DimGray;
                        if (user.ID == item.AssignedUser.ID) picEvn_third.Image = Properties.Resources.taken1;
                    }
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
            shifts = shiftContext.GetAllShifts();
            foreach (var item in shifts)
            {
                if (item.Type == ShiftType.Morning && (DateTime.Compare(dateTime.Date, item.ShiftDate.Date)) == 0)
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
                if (item.Type == ShiftType.Afternoon && (DateTime.Compare(dateTime.Date, item.ShiftDate.Date)) == 0)
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
                if (item.Type == ShiftType.Evening && (DateTime.Compare(dateTime.Date, item.ShiftDate.Date)) == 0)
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
            User u = new User();
            if (isNameValid(tbFullName.Text))
            {
                u.ID = user.ID;
                u.FullName = tbFullName.Text;

                u.Email = tbEmail.Text;
                u.PhoneNumber = tbPhoneNumber.Text;

                Enum.TryParse(cbRole.SelectedIndex.ToString(), out Role role);
                u.Role = role;

                Department department = departmentContext.GetDepartmentByName(cbDepartment.Text);
                if (department != null)
                {
                    userDepartmentContext.UpdateInfo(u.ID, department.ID);
                    userContext.UpdateUserInfo(u);
                    MessageBox.Show("User updated!");

                    if (this.dashboard != null) dashboard.UpdateDashboard();
                    
                }
                else
                {
                    MessageBox.Show("The given department doesn't exist");
                }


                // Show previous form
                previousForm.Closed += (s, args) => this.Close();
                previousForm.Show();
                this.Hide();
            }

        }

        // Helper methods
        // Correction of the password
        private bool isPasswordValid(string password)
        {
            Regex rx = new Regex(@"(?=.{6,})(?=(.*\d){1,})(?=(.*\W){1,})");

            if (!rx.IsMatch(password))
            {
                MessageBox.Show("The Password is invalid!" +
                    "Password must be at least 6 characters long and " +
                    "contain at least one number and one special character.");
                return false;
            }

            return true;
        }

        // Validate the name
        private bool isNameValid(string name)
        {
            Regex rx = new Regex(@"^[A-Z][a-zA-Z]*$");

            if (!rx.IsMatch(name))
            {
                MessageBox.Show("The Name is invalid! Only \"A-Z\"  \"a-z\" characters, at least one uppercase letter ");
                return false;
            }

            return true;
        }

        // Buttons
        private void Back_Click(object sender, EventArgs e)
        {
            // Show previous form
            previousForm.Closed += (s, args) => this.Close();
            previousForm.Show();
            this.Hide();

        }
        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
            if (Application.MessageLoop)
            {
                Application.Exit();
            }
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
                shiftContext.Insert(new Shift(user, false, this.department, d,
                    new DateTime(d.Year, d.Month, d.Day, 9, 0, 0), new DateTime(d.Year, d.Month, d.Day, 10, 0, 0), ShiftType.Morning));

            }
            else
            {
                Shift shift = shiftContext.GetShiftByDate(d, new DateTime(d.Year, d.Month, d.Day, 9, 0, 0));
                shiftContext.DeleteById(shift.ID);
            }

            visualizeShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }
        private void picMor_second_Click(object sender, EventArgs e)
        {

            DateTime d = DateTime.UtcNow.Date.AddDays(addDays).Date;
            if (lbMorn_second.ForeColor != Color.DimGray)
            {

                shiftContext.Insert(new Shift(user, false, department, d,
                    new DateTime(d.Year, d.Month, d.Day, 10, 0, 0), new DateTime(d.Year, d.Month, d.Day, 11, 0, 0), ShiftType.Morning));

            }
            else
            {
                Shift shift = shiftContext.GetShiftByDate(d, new DateTime(d.Year, d.Month, d.Day, 10, 0, 0));
                shiftContext.DeleteById(shift.ID);
            }

            visualizeShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }
        private void picMor_third_Click(object sender, EventArgs e)
        {
            DateTime d = DateTime.UtcNow.Date.AddDays(addDays).Date;
            if (lbMorn_third.ForeColor != Color.DimGray)
            {

                shiftContext.Insert(new Shift(user, false, department, d,
                    new DateTime(d.Year, d.Month, d.Day, 11, 0, 0), new DateTime(d.Year, d.Month, d.Day, 12, 0, 0), ShiftType.Morning));

            }
            else
            {
                Shift shift = shiftContext.GetShiftByDate(d, new DateTime(d.Year, d.Month, d.Day, 11, 0, 0));
                shiftContext.DeleteById(shift.ID);
            }

            visualizeShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }
        private void picAft_first_Click(object sender, EventArgs e)
        {
            DateTime d = DateTime.UtcNow.Date.AddDays(addDays).Date;
            if (lbAft_first.ForeColor != Color.DimGray)
            {

                shiftContext.Insert(new Shift(user, false, department, d,
                    new DateTime(d.Year, d.Month, d.Day, 14, 0, 0), new DateTime(d.Year, d.Month, d.Day, 15, 0, 0), ShiftType.Afternoon));

            }
            else
            {
                Shift shift = shiftContext.GetShiftByDate(d, new DateTime(d.Year, d.Month, d.Day, 14, 0, 0));
                shiftContext.DeleteById(shift.ID);
            }

            visualizeShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }
        private void picAft_second_Click(object sender, EventArgs e)
        {
            DateTime d = DateTime.UtcNow.Date.AddDays(addDays).Date;
            if (lbAft_second.ForeColor != Color.DimGray)
            {
                shiftContext.Insert(new Shift(user, false, department, d,
                    new DateTime(d.Year, d.Month, d.Day, 15, 0, 0), new DateTime(d.Year, d.Month, d.Day, 16, 0, 0), ShiftType.Afternoon));
            }
            else
            {
                Shift shift = shiftContext.GetShiftByDate(d, new DateTime(d.Year, d.Month, d.Day, 15, 0, 0));
                shiftContext.DeleteById(shift.ID);
            }

            visualizeShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }
        private void picAft_third_Click(object sender, EventArgs e)
        {
            DateTime d = DateTime.UtcNow.Date.AddDays(addDays).Date;
            if (lbAft_third.ForeColor != Color.DimGray)
            {
                shiftContext.Insert(new Shift(user, false, department, d,
                    new DateTime(d.Year, d.Month, d.Day, 16, 0, 0), new DateTime(d.Year, d.Month, d.Day, 17, 0, 0), ShiftType.Afternoon));
            }
            else
            {
                Shift shift = shiftContext.GetShiftByDate(d, new DateTime(d.Year, d.Month, d.Day, 16, 0, 0));
                shiftContext.DeleteById(shift.ID);
            }

            visualizeShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }
        private void picEvn_first_Click(object sender, EventArgs e)
        {

            DateTime d = DateTime.UtcNow.Date.AddDays(addDays).Date;
            if (lbEvn_first.ForeColor != Color.DimGray)
            {
                shiftContext.Insert(new Shift(user, false, department, d,
                    new DateTime(d.Year, d.Month, d.Day, 20, 0, 0), new DateTime(d.Year, d.Month, d.Day, 21, 0, 0), ShiftType.Evening));
            }
            else
            {
                Shift shift = shiftContext.GetShiftByDate(d, new DateTime(d.Year, d.Month, d.Day, 20, 0, 0));
                shiftContext.DeleteById(shift.ID);
            }

            visualizeShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }
        private void picEvn_second_Click(object sender, EventArgs e)
        {
            DateTime d = DateTime.UtcNow.Date.AddDays(addDays).Date;
            if (lbEvn_second.ForeColor != Color.DimGray)
            {

                shiftContext.Insert(new Shift(user, false, department, d,
                    new DateTime(d.Year, d.Month, d.Day, 21, 0, 0), new DateTime(d.Year, d.Month, d.Day, 22, 0, 0), ShiftType.Evening));

            }
            else
            {
                Shift shift = shiftContext.GetShiftByDate(d, new DateTime(d.Year, d.Month, d.Day, 21, 0, 0));
                shiftContext.DeleteById(shift.ID);
            }

            visualizeShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }
        private void picEvn_third_Click(object sender, EventArgs e)
        {

            DateTime d = DateTime.UtcNow.Date.AddDays(addDays).Date;
            if (lbEvn_third.ForeColor != Color.DimGray)
            {
                shiftContext.Insert(new Shift(user, false, department, d,
                    new DateTime(d.Year, d.Month, d.Day, 22, 0, 0), new DateTime(d.Year, d.Month, d.Day, 23, 0, 0), ShiftType.Evening));
            }
            else
            {
                Shift shift = shiftContext.GetShiftByDate(d, new DateTime(d.Year, d.Month, d.Day, 22, 0, 0));
                shiftContext.DeleteById(shift.ID);
            }

            visualizeShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Enter new password!");
            }
            else
            {

                string password = txtPassword.Text;
                if (isPasswordValid(password))
                {
                    userContext.UpdatePassword(user.ID, password);
                    MessageBox.Show($"Password Reset to '{password}'");
                }
            }
        }
        private void arrowRight_Click(object sender, EventArgs e)
        {
            addDays++;
            showDate(DateTime.UtcNow.Date.AddDays(addDays));
            visualizeShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }
        private void bToday_Click(object sender, EventArgs e)
        {
            addDays = 0;
            DateTime now = DateTime.UtcNow.Date;
            showDate(now);
            visualizeShifts(now);
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            UploadImg uploadImg = new UploadImg(user.ID, this);
            uploadImg.Show();
        }

        public void UpdateImg(int userId)
        {
            Picture img = imageContext.GetImgByUser(userId);

            if (img == null) { return; }

            try
            {
                WebRequest request = WebRequest.Create(img.UrlPath);
                using (var response = request.GetResponse())
                {
                    using (var str = response.GetResponseStream())
                    {
                        profilePic.Image = Bitmap.FromStream(str);
                    }
                }
            }
            catch (WebException web)
            {
                MessageBox.Show("Incorect url path! " + web.Message);
            }

        }
    }
}

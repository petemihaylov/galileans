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
            this.tbHw.Text = user.Wage.ToString();
            this.tbPhoneNumber.Text = user.PhoneNumber;
            this.cbRole.Text = user.Role.ToString();
            foreach (Department d in departmentContext.GetAllDepartments())
            {
                this.cbDepartment.Items.Add(d.Name);
            }
            if (department != null)
                this.cbDepartment.Text = department.Name;


            //foreach (Availability availability in availabilityContext.GetAllAvailabilitiesByID(UserID))
            //{
            //    throw new System.ArgumentException("Created changes in AvailabilityContext", "original");
            //    // listOfAvailabilities.Items.Add(" shift: " + availability.Date.ToString() + " " + userDepartmentContext.GetDepartmentByUser(availability.User.ID).Name + "  " + user.FullName);
            //}

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


        // Display shifts functionality
        private void setShiftsProperties(List<Shift> shifts, List<Label> labels, List<PictureBox> pictures, List<string> startTime)
        {
            foreach (var shift in shifts)
            {

                for (int i = 0; i < labels.Count; i++)
                {
                    if (shift.StartTime == startTime[i])
                    {
                        if (shift.Availability) { labels[i].Font = new Font("Arial", float.Parse("10.2")); pictures[i].Image = Properties.Resources.btnAdd; labels[i].ForeColor = Color.Black; }
                        else
                        {
                            labels[i].Font = new Font("Arial", float.Parse("10.2"), FontStyle.Strikeout); pictures[i].Image = Properties.Resources.btnBlock; labels[i].ForeColor = Color.DimGray;
                            if (user.ID == shift.AssignedUser.ID) pictures[i].Image = Properties.Resources.taken1;
                        }
                    }

                }

            }
        }
        private void resetShiftsProperties(List<Label> labels, List<PictureBox> pictures)
        {
            foreach (var label in labels)
            {
                label.Font = new Font("Arial", float.Parse("10.2"));
                label.ForeColor = Color.Black;
            }
            pictures.ForEach(p => p.Image = Properties.Resources.btnAdd);
        }
        private void visualizeShifts(DateTime date)
        {
            
            //morning arrange
            List<Shift> morning = getMorningShiftsForDate(date);
            List<Label> lbMorning = new List<Label>()
            {
                lbMorn_first,
                lbMorn_second,
                lbMorn_third
            };
            List<PictureBox> picMorning = new List<PictureBox>()
            {
                picMor_first,
                picMor_second,
                picMor_third
            };

            resetShiftsProperties(lbMorning, picMorning);
            setShiftsProperties(morning, lbMorning, picMorning, StartTime.morning);

            // afternoon arrange
            List<Shift> afternoon = getAfternoonShiftsForDate(date);
            List<Label> lbAfternoon = new List<Label>()
            {
                lbAft_first,
                lbAft_second,
                lbAft_third
            };
            List<PictureBox> picAfternoon = new List<PictureBox>()
            {
                picAft_first,
                picAft_second,
                picAft_third
            };

            resetShiftsProperties(lbAfternoon, picAfternoon);
            setShiftsProperties(afternoon, lbAfternoon, picAfternoon, StartTime.afternoon);


            // evening arrange
            List<Shift> evening = getEveningShiftsForDate(date);
            List<Label> lbEvening = new List<Label>()
            {
                lbEvn_first,
                lbEvn_second,
                lbEvn_third
            };
            List<PictureBox> picEvening = new List<PictureBox>()
            {
                picEvn_first,
                picEvn_second,
                picEvn_third
            };

            resetShiftsProperties(lbEvening, picEvening);
            setShiftsProperties(evening, lbEvening, picEvening, StartTime.evening);


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
                u.Wage = Convert.ToDouble(tbHw.Text);
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


        // Helper method
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

        // Click Events
        private void picMor_first_Click(object sender, EventArgs e)
        {

            DateTime d = DateTime.UtcNow.Date.AddDays(addDays).Date;
            if (lbMorn_first.ForeColor != Color.DimGray)
            {
                shiftContext.Insert(new Shift(user, false, this.department, d, StartTime.morning[0], EndTime.morning[0], ShiftType.Morning));
            }
            else
            {

                Shift shift = shiftContext.GetShiftByDate(d, StartTime.morning[0]);
                shiftContext.DeleteById(shift.ID);
            }

            visualizeShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }
        private void picMor_second_Click(object sender, EventArgs e)
        {

            DateTime d = DateTime.UtcNow.Date.AddDays(addDays).Date;
            if (lbMorn_second.ForeColor != Color.DimGray)
            {

                shiftContext.Insert(new Shift(user, false, department, d, StartTime.morning[1], EndTime.morning[1], ShiftType.Morning));

            }
            else
            {

                Shift shift = shiftContext.GetShiftByDate(d, StartTime.morning[1]);
                shiftContext.DeleteById(shift.ID);
            }

            visualizeShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }
        private void picMor_third_Click(object sender, EventArgs e)
        {
            DateTime d = DateTime.UtcNow.Date.AddDays(addDays).Date;
            if (lbMorn_third.ForeColor != Color.DimGray)
            {

                shiftContext.Insert(new Shift(user, false, department, d, StartTime.morning[2], EndTime.morning[2], ShiftType.Morning));

            }
            else
            {

                Shift shift = shiftContext.GetShiftByDate(d, StartTime.morning[2]);
                shiftContext.DeleteById(shift.ID);
            }

            visualizeShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }

        // Click Events
        private void picAft_first_Click(object sender, EventArgs e)
        {
            DateTime d = DateTime.UtcNow.Date.AddDays(addDays).Date;
            if (lbAft_first.ForeColor != Color.DimGray)
            {
                shiftContext.Insert(new Shift(user, false, department, d, StartTime.afternoon[0], EndTime.afternoon[0], ShiftType.Afternoon));
            }
            else
            {
                Shift shift = shiftContext.GetShiftByDate(d, StartTime.afternoon[0]);
                shiftContext.DeleteById(shift.ID);
            }
            visualizeShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }
        private void picAft_second_Click(object sender, EventArgs e)
        {
            DateTime d = DateTime.UtcNow.Date.AddDays(addDays).Date;
            if (lbAft_second.ForeColor != Color.DimGray)
            {
                shiftContext.Insert(new Shift(user, false, department, d, StartTime.afternoon[1], EndTime.afternoon[1], ShiftType.Afternoon));
            }
            else
            {

                Shift shift = shiftContext.GetShiftByDate(d, StartTime.afternoon[1]);
                shiftContext.DeleteById(shift.ID);
            }

            visualizeShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }
        private void picAft_third_Click(object sender, EventArgs e)
        {
            DateTime d = DateTime.UtcNow.Date.AddDays(addDays).Date;
            if (lbAft_third.ForeColor != Color.DimGray)
            {
                shiftContext.Insert(new Shift(user, false, department, d, StartTime.afternoon[2], EndTime.afternoon[2], ShiftType.Afternoon));
            }
            else
            {

                Shift shift = shiftContext.GetShiftByDate(d, StartTime.afternoon[2]);
                shiftContext.DeleteById(shift.ID);
            }

            visualizeShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }

        // Click Events
        private void picEvn_first_Click(object sender, EventArgs e)
        {

            DateTime d = DateTime.UtcNow.Date.AddDays(addDays).Date;
            if (lbEvn_first.ForeColor != Color.DimGray)
            {
                shiftContext.Insert(new Shift(user, false, department, d, StartTime.evening[0], EndTime.evening[0], ShiftType.Evening));
            }
            else
            {

                Shift shift = shiftContext.GetShiftByDate(d, StartTime.evening[0]);
                shiftContext.DeleteById(shift.ID);
            }

            visualizeShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }
        private void picEvn_second_Click(object sender, EventArgs e)
        {
            DateTime d = DateTime.UtcNow.Date.AddDays(addDays).Date;
            if (lbEvn_second.ForeColor != Color.DimGray)
            {

                shiftContext.Insert(new Shift(user, false, department, d, StartTime.evening[1], EndTime.evening[1], ShiftType.Evening));

            }
            else
            {

                Shift shift = shiftContext.GetShiftByDate(d, StartTime.evening[1]);
                shiftContext.DeleteById(shift.ID);
            }

            visualizeShifts(DateTime.UtcNow.Date.AddDays(addDays));
        }
        private void picEvn_third_Click(object sender, EventArgs e)
        {

            DateTime d = DateTime.UtcNow.Date.AddDays(addDays).Date;
            if (lbEvn_third.ForeColor != Color.DimGray)
            {
                shiftContext.Insert(new Shift(user, false, department, d, StartTime.evening[2], EndTime.evening[2], ShiftType.Evening));
            }
            else
            {

                Shift shift = shiftContext.GetShiftByDate(d, StartTime.evening[2]);
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

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

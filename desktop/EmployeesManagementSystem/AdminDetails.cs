using System;
using System.Net;
using System.Drawing;
using System.Windows.Forms;
using EmployeesManagementSystem.Models;
using System.Text.RegularExpressions;

namespace EmployeesManagementSystem
{
    public partial class AdminDetails : Form
    {
        private DbContext databaseContext = new DbContext();
        private User user;
       
        public AdminDetails(User loggedUser)
        {
            InitializeComponent();
            this.user = loggedUser;

            // Temporary validation used when debugging
            if(user == null)
            {
                this.user = databaseContext.GetUserByEmail("admin");
            }

        }
        private void AdminDetails_Load(object sender, EventArgs e)
        {
            tbFullName.Text = this.user.FullName;
            tbPhoneNumber.Text = this.user.PhoneNumber;
            tbEmail.Text = this.user.Email;
            cbDepartment.Text = this.user.Department;
            cbRole.Text = this.user.Role;
            this.UpdateImg(this.user.ID);
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // basic validation
            if (ifEmptyOrNull(tbFullName.Text, tbEmail.Text, tbPhoneNumber.Text, cbRole.Text))
            {

                string fullName = removeWhiteSpaces(this.tbFullName.Text);
                
                databaseContext.UpdateUserInfo(this.user.ID, fullName, tbEmail.Text, tbPhoneNumber.Text, cbRole.Text, cbDepartment.Text);
                MessageBox.Show("User updated!");

                user = databaseContext.GetUserByID(this.user.ID);
                this.Hide();
                // Show Dashboard
                AdminDetails admin = new AdminDetails(user);
                admin.Closed += (s, args) => this.Close();
                admin.Show();
            }

        }


        private bool ifEmptyOrNull(string fullName, string email, string phone, string role)
        {

            if (string.IsNullOrWhiteSpace(removeWhiteSpaces(fullName)))
            {
                MessageBox.Show("Change the Name field");
                return false;
            }


            if (string.IsNullOrWhiteSpace(removeWhiteSpaces(phone)))
            {
                MessageBox.Show("Change the Phone field");
                return false;
            }

            if (string.IsNullOrWhiteSpace(removeWhiteSpaces(email)))
            {
                MessageBox.Show("Change the Email field");
                return false;
            }

            return true;
        }

        private string removeWhiteSpaces(string text)
        {
            return Regex.Replace(text, @"\s+|\t|\n|\r", String.Empty);
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
                databaseContext.ResetPassword(user.ID, password);
                MessageBox.Show($"Password Reset to '{password}'");
            }
        }

        public void UpdateImg(int userId)
        {
            ImageClass img = databaseContext.GetUserImg(userId);

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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var user = databaseContext.GetUserByEmail("admin"); 
            UploadImg uploadImg = new UploadImg(user.ID, this);
            uploadImg.Show();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Dashboard dashboard = new Dashboard(this.user);
            dashboard.Closed += (s, args) => this.Close();
            dashboard.Show();
        }
    }
}

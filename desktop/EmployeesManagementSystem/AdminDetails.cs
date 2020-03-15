using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using EmployeesManagementSystem.Models;

namespace EmployeesManagementSystem
{
    public partial class AdminDetails : Form
    {
        private DbContext databaseContext = new DbContext();
        private User user;
        

        public AdminDetails()
        {
            InitializeComponent();

        }

        private void AdminDetails_Load(object sender, EventArgs e)
        {
            var user = databaseContext.GetUserByEmail("admin");
            tbFullName.Text = user.FullName;
            tbPhoneNumber.Text = user.PhoneNumber;
            tbEmail.Text = user.Email;
            cbDepartment.Text = user.Department;
            cbRole.Text = user.Role;
            txtPassword.Text = user.Password;
            this.UpdateImg(user.ID);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var user = databaseContext.GetUserByEmail("admin");
            databaseContext.UpdateUserInfo(user.ID, tbFullName.Text, tbEmail.Text, tbPhoneNumber.Text, cbRole.Text, cbDepartment.Text);
            MessageBox.Show("User updated!");

            this.Hide();
            // Show Dashboard
            AdminDetails admin = new AdminDetails();
            admin.Closed += (s, args) => this.Close();
            admin.Show();
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
            this.Close();
            // exiting properly the application
            if (Application.MessageLoop)
            {
                Application.Exit();
            }
        }
    }
}

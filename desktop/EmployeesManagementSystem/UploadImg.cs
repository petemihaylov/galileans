using EmployeesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeesManagementSystem
{
    public partial class UploadImg : Form
    {

        private DbContext databaseContext = new DbContext();
        private Details details;
        private AdminDetails admin;
        private int userId;
        public UploadImg(int userId, Details details)
        {
            InitializeComponent();
            this.userId = userId;
            this.details = details;
        }
        public UploadImg(int userId, AdminDetails admin)
        {
            InitializeComponent();
            this.userId = userId;
            this.admin = admin;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUrl.Text))
            {
                MessageBox.Show("Please input url");
                return;
            }

            ImageClass img = databaseContext.GetUserImg(userId);
            if (img != null)
            {
                databaseContext.DeleteImgById(img.ID);
            }

            img = new ImageClass(userId, txtUrl.Text);
            databaseContext.InsertImage(img);

            this.Close();
            User user = databaseContext.GetUserByID(userId);
            if(user.Email == "admin")
            {
                this.admin.UpdateImg(userId);
            }
            else
            {
                this.details.UpdateImg(userId);
            }
        }
    }
}

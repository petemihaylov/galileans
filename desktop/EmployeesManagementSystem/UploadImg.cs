using EmployeesManagementSystem.Data;
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
        private int userId;

        private Details details;
        private AdminDetails admin;

        private ImageContext imgContext = new ImageContext();
        private UserContext userContext = new UserContext();

        
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

            Picture img = imgContext.GetImgByUser(userId);
            if (img != null)
            {
               imgContext.DeleteById(img.ID);
            }
            imgContext.Insert(new Picture(userContext.GetUserByID(userId), txtUrl.Text));

            this.Close();
            User user = userContext.GetUserByID(userId);
            if (admin != null)
                this.admin.UpdateImg(userId);
            else details.UpdateImg(userId);     
        }
    }
}

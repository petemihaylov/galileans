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
        private int userId;
        public UploadImg(int userId, Details details)
        {
            InitializeComponent();
            this.userId = userId;
            this.details = details;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            databaseContext.Dispose(true);
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
            if(img != null)
            {
                databaseContext.DeleteImgById(img.ID);
            }
            
            img = new ImageClass(userId, txtUrl.Text);
            databaseContext.InsertImage(img);

            databaseContext.Dispose(true);
            this.Close();
            this.details.UpdateImg(userId);
        }
    }
}

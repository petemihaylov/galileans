﻿using System;
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
        int ID;

        public Details(int ID)
        {
            InitializeComponent();
            this.ID = ID;
            User user = databaseContext.GetUserByID(this.ID);
            tbFullName.Text = user.FullName;
            tbPassword.Text = user.Password;
            tbEmail.Text = user.Email;
            tbLocation.Text = "to add in db";
            tbPhoneNumber.Text = Convert.ToString(user.PhoneNumber);
            cbRole.Text = user.Role;
            cbDepartment.Text = "to add in db";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            // TO-DO
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // TO-DO
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Dashboard dash = new Dashboard();
            dash.Show();
            this.Hide();

        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

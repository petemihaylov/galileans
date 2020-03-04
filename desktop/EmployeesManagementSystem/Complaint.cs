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
    public partial class Complaint : Form
    {
        private DbContext databaseContext = new DbContext();

        public Complaint()
        {
            InitializeComponent();
        }

        private void Complaint_Load(object sender, EventArgs e)
        {
            //needs to upload as the program runs in the future
            try
            {
                Cancellations cancel = databaseContext.GetAnnouncements();
                dataGridView.Rows.Add(cancel.GetInfo());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

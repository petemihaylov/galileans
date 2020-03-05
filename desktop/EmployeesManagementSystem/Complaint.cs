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
    public partial class Complaint : Form
    {
        private DbContext databaseContext = new DbContext();
        List<int> ids = new List<int>();


        public Complaint()
        {
            InitializeComponent();
        }

        private void Complaint_Load(object sender, EventArgs e)
        {
            //needs to upload as the program runs in the future
            try
            {
                Cancellations[] cancels = databaseContext.GetAnnouncements();
                foreach (Cancellations cancel in cancels)
                {
                    dataGridView.Rows.Add(cancel.GetInfo());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.CurrentCell.ColumnIndex.Equals(4) && e.RowIndex != -1 && dataGridView.CurrentCell != null)
            {
                // open another message box with the whole description
                MessageBox.Show("Description:" + dataGridView.CurrentCell.Value.ToString());
            }
            else if (dataGridView.CurrentCell.ColumnIndex.Equals(5) && e.RowIndex != -1 && dataGridView.CurrentCell != null)
            {
                int index = dataGridView.CurrentCell.RowIndex;
                //MessageBox.Show(Convert.ToString(dataGridView.Rows[index].Cells[0].Value));
                int id = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                databaseContext.DeleteAnnouncement(id);
                dataGridView.Rows.Remove(dataGridView.Rows[index]);

            }


        }
    }
}

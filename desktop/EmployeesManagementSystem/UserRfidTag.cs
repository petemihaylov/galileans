using EmployeesManagementSystem.Controllers;
using EmployeesManagementSystem.Data;
using EmployeesManagementSystem.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeesManagementSystem
{
    public partial class UserRfidTag : Form
    {
        RfidController rfidController = new RfidController();
        private Form previousForm;

        public UserRfidTag()
        {
            InitializeComponent();
            updateDataGrid();
            updateComboBox();
            this.previousForm = previousForm;

        }

        private void updateDataGrid()
        {

            // DataGridInformation

            this.dataGridRfid.Rows.Clear();

            List<Rfid> rfids = rfidController.Rfids;
            rfids.Reverse();

            foreach(Rfid rfid in rfids)
            {
                User user = rfidController.GetUserById(rfid.UserID);
                this.dataGridRfid.Rows.Add(rfid.RfidTag.ToString(), user.FullName.ToString(), rfid.EnteredAt.ToString(), rfid.LeftAt.ToString());
            }
        }

        private void updateComboBox()
        {
            this.comboUsers.Items.Clear();

            List<User> users = rfidController.Users;

            foreach(User user in users)
            {
                this.comboUsers.Items.Add(user.FullName);
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection cells = this.dataGridRfid.SelectedCells;
            List<DataGridViewRow> rows = new List<DataGridViewRow>();

            foreach (DataGridViewCell cell in this.dataGridRfid.SelectedCells)
            {
                rows.Add(this.dataGridRfid.Rows[cell.RowIndex]);
            }

            foreach (DataGridViewRow selectedRow in rows)
            {
                string rfidId = Convert.ToString(selectedRow.Cells[0].Value);
                Rfid rfid = rfidController.GetRfidByRfidID(rfidId);
                if (rfid == null)
                {
                    continue;
                }

                rfid.EnteredAt = DateTime.Now;

                updateDataGrid();
            }

            MessageBox.Show("Successfully saved the changes");          


        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection cells = this.dataGridRfid.SelectedCells;
            List<DataGridViewRow> rows = new List<DataGridViewRow>();

            foreach (DataGridViewCell cell in this.dataGridRfid.SelectedCells)
            {
                rows.Add(this.dataGridRfid.Rows[cell.RowIndex]);
            }

            foreach (DataGridViewRow selectedRow in rows)
            {
                string rfidId = Convert.ToString(selectedRow.Cells[0].Value);
                Rfid rfid = rfidController.GetRfidByRfidID(rfidId);

                if(rfid == null)
                {
                    continue; 
                }

                if (DateTime.Compare(rfid.EnteredAt, DateTime.Now) > 0)
                {
                    MessageBox.Show("There is a definitely a mistake!");
                    return;
                }

                rfid.LeftAt = DateTime.Now;

                updateDataGrid();
            }

            MessageBox.Show("Successfully saved the changes");


        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            this.txtRfid.Text = rfidController.GenerateRandomNo().ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string rfid = this.txtRfid.Text;

            if (!rfidController.isRfidValid(rfid))
            {
                MessageBox.Show("This is not valid rfid");
            }
            else
            {
                try
                {
                    string name = this.comboUsers.SelectedItem.ToString();
                    User user = new User();

                    user = rfidController.GetUserByFullname(name);

                    rfidController.SaveRfid(rfid, user.ID);

                    updateDataGrid();
                    MessageBox.Show("You saved the user!");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Please select a name for combo box!");
                }
            }

        }

        private void btnClearSelected_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection cells = this.dataGridRfid.SelectedCells;
            List<DataGridViewRow> rows = new List<DataGridViewRow>();

            foreach (DataGridViewCell cell in this.dataGridRfid.SelectedCells)
            {
                rows.Add(this.dataGridRfid.Rows[cell.RowIndex]);
            }

            foreach (DataGridViewRow  selectedRow in  rows)
            {
                string rfidId = Convert.ToString(selectedRow.Cells[0].Value);                
                rfidController.DeleteRfidByRfidID(rfidId);

                updateDataGrid();
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please wait for the changes to be saved.");

            if (rfidController.ApplyAllChanges())
            {
                MessageBox.Show("You successfully updated the table!");
            }
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            // Show previous form
            previousForm.Closed += (s, args) => this.Close();
            previousForm.Show();
            this.Hide();
        }

        private void UserRfidTag_Load(object sender, EventArgs e)
        {

        }

        private void lbBack_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}

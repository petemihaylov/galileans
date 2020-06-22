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
            fillComboBox();
        }
        //
        private void updateDataGrid()
        {

            // DataGridInformation

            this.dataGridRfid.Rows.Clear();

            List<Rfid> rfids = rfidController.GetRfids();
            rfids.Reverse();

            foreach (Rfid rfid in rfids)
            {
                User user = rfidController.GetUserById(rfid.UserID);

                string leftAt = "";
                if (rfid.LeftAt.Year != 1) leftAt = rfid.LeftAt.ToString();

                this.dataGridRfid.Rows.Add(rfid.RfidTag.ToString(), user.FullName.ToString(), rfid.EnteredAt.ToString(), leftAt);
            }
        }
        //
        private void fillComboBox()
        {
            // Filling the combo with users fullnames
            this.comboUsers.Items.Clear();

            rfidController.Users.ForEach(user =>
              this.comboUsers.Items.Add(user.FullName)
            ) ;

          
            this.cbUsers.Items.AddRange(comboUsers.Items.OfType<string>().ToArray());
            this.cbUsers.Text = "All";
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
                rfid.LeftAt = DateTime.Now;

                rfidController.UpdateRfid(rfid);
                updateDataGrid();
            }

            MessageBox.Show("Successfully saved the changes");


        }
        
        private void picDelete_Click(object sender, EventArgs e)
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
                rfidController.DeleteRfidByRfidID(rfidId);
            }
            updateDataGrid();

        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (this.cbUsers.SelectedItem != null)
            {
                string name = this.cbUsers.SelectedItem.ToString();
                User user = rfidController.GetUserByFullname(name);

                if(user == null) { updateDataGrid(); return; }

                List<Rfid> rfids = rfidController.SortRfidByUser(user);

                this.dataGridRfid.Rows.Clear();

                rfids.Reverse();

                foreach (Rfid rfid in rfids)
                {
                    string leftAt = "";
                    if (rfid.LeftAt.Year != 1) leftAt = rfid.LeftAt.ToString();

                    this.dataGridRfid.Rows.Add(rfid.RfidTag.ToString(), user.FullName.ToString(), rfid.EnteredAt.ToString(), leftAt);
                }
            }
            else
            {
                updateDataGrid();
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

        private void buttonCheckIn_Click(object sender, EventArgs e)
        {
            // Checks if there is selected user 
            try
            {
                string name = this.comboUsers.SelectedItem.ToString();

                User user = rfidController.GetUserByFullname(name);

                rfidController.CanCheckIn(user, DateTime.Now);

                Dictionary<User, int> rfids = rfidController.GetUsers();
                var rfidTag = rfids[user];

                Rfid r = new Rfid(rfidTag.ToString(), user.ID);
                r.EnteredAt = DateTime.Now;
                rfidController.Insert(r);

                MessageBox.Show("Successfully saved the changes");
                updateDataGrid();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select a user!");
            }

        }
    }
}

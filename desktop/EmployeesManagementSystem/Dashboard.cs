using System;
using System.Drawing;
using System.Windows.Forms;
using EmployeesManagementSystem.Models;

namespace EmployeesManagementSystem
{
    public partial class Dashboard : Form
    {
        private DbContext databaseContext = new DbContext();

        public Dashboard()
        {
            InitializeComponent();
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                User[] users = databaseContext.GetAllUsers();
                foreach(User user in users)
                {
                    dataGridView.Rows.Add(user.GetInfo());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        /*
            dataGridView.Rows.Add("John Smith", "j.smith@student.fontys.nl", "Employee");
            dataGridView.Rows.Add("Martin Ivanov", "m.ivanov@student.fontys.nl", "Manager");
            dataGridView.Rows.Add("George Lennon", "g.lennon@student.fontys.nl", "Employee");
            dataGridView.Rows.Add("Mateos Matty", "m.matty@student.fontys.nl", "Employee");
            */
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Details = 4;
            int Delete = 5;
            if (dataGridView.CurrentCell.ColumnIndex.Equals(Details))
            {
                // show view of current user id
                //MessageBox.Show("Details: " + dataGridView.CurrentRow.Index.ToString());
                int index = dataGridView.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                Details details = new Details(id);
                details.Show();
                this.Hide();
            }

            if (dataGridView.CurrentCell.ColumnIndex.Equals(Delete))
            {
                //ask if you want to delete and proccess
                int index = dataGridView.CurrentCell.RowIndex;
                int id = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                Delete delete = new Delete(id);
                delete.Show();

               //MessageBox.Show("Delete: " + dataGridView.CurrentRow.Index.ToString());
            }

        }


               
        // Hovering
        private void exit_MouseEnter(object sender, EventArgs e)
        {
            this.exit.BackColor = Color.LightGray;
        }
        private void exit_MouseLeave(object sender, EventArgs e)
        {
            this.exit.BackColor = Color.White;
        }

        private void btn1_MouseEnter(object sender, EventArgs e)
        {
            Color color = Color.DarkGray;
            this.panel1.BackColor = color;
        }
        private void btn1_MouseLeave(object sender, EventArgs e)
        {

            Color color = Color.LightGray;
            this.panel1.BackColor = color;
        }

        private void btn2_MouseEnter(object sender, EventArgs e)
        {
            Color color = Color.DarkGray;
            this.panel2.BackColor = color;
        }
        private void btn2_MouseLeave(object sender, EventArgs e)
        {

            Color color = Color.LightGray;
            this.panel2.BackColor = color;
        }
        
        private void btn3_MouseEnter(object sender, EventArgs e)
        {
            Color color = Color.DarkGray;

            this.panel3.BackColor = color;
        }
        private void btn3_MouseLeave(object sender, EventArgs e)
        {

            Color color = Color.LightGray;

            this.panel3.BackColor = color;
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panelAccount_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            CreateAccounts createAccount= new CreateAccounts();
            createAccount.Show();

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

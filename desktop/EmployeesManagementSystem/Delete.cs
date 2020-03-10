using System;
using System.Drawing;
using System.Windows.Forms;
using static EmployeesManagementSystem.Program;

namespace EmployeesManagementSystem
{
    public partial class Delete : Form
    {
        private DbContext databaseContext = new DbContext();

        // Variables
        private int id;
        private Dashboard dashboard;
        
        // Constructor
        public Delete(int ID, Dashboard dashboard)
        {
            InitializeComponent();
            this.id = ID;
            this.dashboard = dashboard;
        }

        // Methods
        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.databaseContext.DeleteShiftOfUser(this.id);
            this.databaseContext.DeleteUser(this.id);
            this.dashboard.UpdateDashboard();
            this.Close();
        }

        // Methods
        private void bntNo_Click(object sender, EventArgs e)
        {

            databaseContext.Dispose(true);
            this.Close();
        }

        private void exit_Click(object sender, EventArgs e)
        {

            databaseContext.Dispose(true);
            this.Close();
        }

        // Hovering 
        private void exit_MouseEnter(object sender, EventArgs e)
        {
            Color color = Color.DarkGray;
            this.exit.BackColor = color;

        }

        private void exit_MouseLeave(object sender, EventArgs e)
        {
            Color color = Color.LightGray;
            this.exit.BackColor = color;
        }

    }
}

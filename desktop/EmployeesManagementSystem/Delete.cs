using System;
using System.Drawing;
using System.Windows.Forms;
using EmployeesManagementSystem.Data;

namespace EmployeesManagementSystem
{
    public partial class Delete : Form
    {
        private int id;
        private Dashboard dashboard;
        private ShiftContext shiftContext = new ShiftContext();
        private UserContext userContext = new UserContext();

        public Delete(int ID, Dashboard dashboard)
        {
            InitializeComponent();
            this.id = ID;
            this.dashboard = dashboard;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.shiftContext.DeleteShiftByUserId(this.id);
            this.userContext.DeleteById(this.id);
            this.dashboard.UpdateDashboard();
            this.Close();
            dashboard.Show();
        }

        private void bntNo_Click(object sender, EventArgs e)
        {
            this.Close();
            dashboard.Show();
        }
        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
            dashboard.Show();
        }

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

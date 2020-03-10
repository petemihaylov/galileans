using System;
using System.Drawing;
using System.Windows.Forms;

namespace EmployeesManagementSystem
{
    public partial class Warning : Form
    {

        private Dashboard dashboard;
        
        public Warning(Dashboard dashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            dashboard.Show();
            this.Close();

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

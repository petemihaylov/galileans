using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EmployeesManagementSystem.Program;

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

        private void back_Click(object sender, EventArgs e)
        {
            dashboard.Show();
            this.Close();
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

        private void back_MouseEnter(object sender, EventArgs e)
        {
            Color color = Color.DarkGray;
            this.back.BackColor = color;

        }

        private void back_MouseLeave(object sender, EventArgs e)
        {
            Color color = Color.LightGray;
            this.back.BackColor = color;
        }

    }
}

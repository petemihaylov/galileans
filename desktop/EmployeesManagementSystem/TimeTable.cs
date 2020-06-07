using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeesManagementSystem
{
    public partial class TimeTable : Form
    {
        private TimeTableManager manager = new TimeTableManager();
        public TimeTable()
        {
            InitializeComponent();
        }



        // Hovering
        private void lbMonday_MouseEnter(object sender, EventArgs e)
        {
            manager.ItemSetStyle(this.lbMonday);
        }
        private void lbMonday_MouseLeave(object sender, EventArgs e)
        {
            lbMonday.ResetBackColor();
            lbMonday.ResetForeColor();
        }
    }

    public class TimeTableManager
    {

        private Color hoverColor = Color.Gray;
        private Color textColor = Color.LightGray;
        public void ItemSetStyle(ListBox lb)
        {
            lb.BackColor = hoverColor;
            lb.ForeColor = textColor;

        }
    }
}

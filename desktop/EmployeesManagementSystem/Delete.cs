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
    public partial class Delete : Form
    {
        private DbContext databaseContext = new DbContext();

        int ID;
        public Delete(int ID)
        {
            InitializeComponent();
            this.ID = ID;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Convert.ToString(dataGridView.Rows[index].Cells[0].Value));
            databaseContext.DeleteUser(ID);
            Hide();
        }
    }
}

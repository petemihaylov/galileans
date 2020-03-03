using EmployeesManagementSystem.Models;
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
    public partial class Login : Form
    {

        private DbContext databaseContext = new DbContext();
        public Login()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ifNotExists(new User()))
            {

            }
            else
            {
                MessageBox.Show("This user has been already taken!");
            }

        }

        private bool ifNotExists(User user)
        {
            return true;
        }

        private void GenerateRandomID()
        {
            const int rangeMin = 1000;
            const int rangeMax = 9999;

            Random a = new Random();

            List<int> randomList = new List<int>();
            int MyNumber = 0;

            MyNumber = a.Next(rangeMin, rangeMax);

            if (!randomList.Contains(MyNumber))
                randomList.Add(MyNumber);
        }
    }
}

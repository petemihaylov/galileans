using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using EmployeesManagementSystem.Data;
using EmployeesManagementSystem.Models;

namespace EmployeesManagementSystem
{
    public partial class TimeTable : Form
    {
        private User loggedUser;
        private Form previousForm;
        private AvailabilityContext availabilityContext = new AvailabilityContext();
     
        private TimeTableManager manager = new TimeTableManager();
        private UserContext userContext = new UserContext();
        private List<Availability> reqAvas = new List<Availability>();
        public TimeTable(User user, Form previousForm)
        {
            InitializeComponent();
            this.loggedUser = user;
            this.previousForm = previousForm;


            foreach (User u in userContext.GetAllUsers())
            {
                cbEmployees.Items.Add(u.FullName);
            }

          
            foreach (Availability av in availabilityContext.GetAllAvailabilities())
            {
                if (av.State.ToString() == "Pendding")
                {
                    reqAvas.Add(av);
                    string name = userContext.GetUserByID(av.User.ID).FullName;
                    lbRequested.Items.Add(name + " " + av.GetInfo());
                }
            }
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

        private void btnDecline_Click(object sender, EventArgs e)
        {
            int index = lbRequested.SelectedIndex;
            Availability av = new Availability();
            av = reqAvas[index];
            av.State = AvailabilityType.Declined;
            availabilityContext.UpdateAvailabilityInfo(av);
            UpdateList();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            int index = lbRequested.SelectedIndex;
            Availability av = new Availability();
            av = reqAvas[index];
            av.State = AvailabilityType.Declined;
            availabilityContext.UpdateAvailabilityInfo(av);
            UpdateList();
        }
        public void UpdateList()
        {
            lbRequested.Items.Clear();
            reqAvas.Clear();

            foreach (Availability av in availabilityContext.GetAllAvailabilities())
            {
                if (av.State.ToString() == "Pendding")
                {
                    lbRequested.Items.Add(av.GetInfo());
                    reqAvas.Add(av);
                }

            }
 
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            // Show previous form
            previousForm.Closed += (s, args) => this.Close();
            previousForm.Show();
            this.Hide();
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

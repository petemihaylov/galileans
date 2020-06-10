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
            
        // For automation part
        private TimeTableManager manager = new TimeTableManager();

        private AvailabilityContext availabilityContext = new AvailabilityContext();
        private UserContext userContext = new UserContext();
        private List<Availability> reqAvas = new List<Availability>();

        public TimeTable(User user, Form previousForm)
        {
            InitializeComponent();
            this.loggedUser = user;
            this.previousForm = previousForm;

            DisplayList();            
        }

        private void DisplayList()
        {
            lbRequested.Items.Clear();
            lbAccepted.Items.Clear();
            reqAvas.Clear();

            foreach (Availability av in availabilityContext.GetAllAvailabilities())
            {

                string name = userContext.GetUserByID(av.User.ID).FullName;
                if (av.State.ToString() == "Pendding")
                {
                    reqAvas.Add(av);
                    lbRequested.Items.Add(name + " " + av.GetInfo());
                }
                else if (av.State.ToString() == "Approved")
                {
                    lbAccepted.Items.Add(name + " " + av.GetInfo());
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
            DisplayList(); // change the name if you want
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            int index = lbRequested.SelectedIndex;
            Availability av = new Availability();

            if(reqAvas.Count > index) // small validation
            av = reqAvas[index];
            
            av.State = AvailabilityType.Approved;
            availabilityContext.UpdateAvailabilityInfo(av);

            DisplayList(); // one reusable function
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            // Show previous form
            previousForm.Closed += (s, args) => this.Close();
            previousForm.Show();
            this.Hide();
        }

        private void lbAccepted_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = lbAccepted.SelectedIndex;
            Availability av = new Availability();
            av = reqAvas[index];

            txtEmployee.Text = userContext.GetUserByID(av.User.ID).FullName;

            if (av.IsMonthly) rbMonthly.Checked = true;
            if (av.IsWeekly) rbWeekly.Checked = true;
            if (!av.IsMonthly && !av.IsWeekly) rbOnce.Checked = true;

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

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

        // List of all the availabilities from DB
        private List<Availability> reqAvas = new List<Availability>();
        // I need it for RUN
        private Availability availability;

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
            reqAvas.Clear();

            foreach (Availability av in availabilityContext.GetAllAvailabilities())
            {
                string name = userContext.GetUserByID(av.User.ID).FullName;
                if (av.State.ToString() == "Pendding")
                {
                    reqAvas.Add(av);
                    lbRequested.Items.Add(name + "  -  " + av.GetInfo());
                }

            }
        }

        // Hovering


        private void picBack_Click(object sender, EventArgs e)
        {
            // Show previous form
            previousForm.Closed += (s, args) => this.Close();
            previousForm.Show();
            this.Hide();
        }



        private void lbRequested_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = lbRequested.SelectedIndex;

            // List validation

            try
            {
                availability = this.reqAvas[selectedIndex];
            }
            catch (Exception) { return; }

            List<string> days = availability.GetFormatedDays();
            txtWeekdays.Text = string.Join(", ", days.ToArray());
            txtEmployee.Text = userContext.GetUserByID(availability.User.ID).FullName;

            cbDaysOfWeek.Items.Clear();
            days.ForEach(i => cbDaysOfWeek.Items.Add(i));

            if (availability.IsMonthly) rbMonthly.Checked = true;
            if (availability.IsWeekly) rbWeekly.Checked = true;
            if (!availability.IsMonthly && !availability.IsWeekly) rbOnce.Checked = true;

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            int repeatitions = (int)numUpDown.Value;
            string dayOfWeek = cbDaysOfWeek.Text;

            var result = new List<Shift>();
            if (availability != null)
            {
                result = ShiftAutomationManager.Run(repeatitions, dayOfWeek, availability.User);

            }

            lbFoundResults.Items.Clear();
            result.ForEach(r => lbFoundResults.Items.Add(r.ToString()));

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

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
        private List<Availability> reqApprovedAvas = new List<Availability>();
        // I need it for RUN
        private Availability availability;
        private List<Shift> result = null;

        public TimeTable(User user, Form previousForm)
        {
            InitializeComponent();
            this.loggedUser = user;
            this.previousForm = previousForm;

            DisplayList();
            DisplayListOfApproved();
        }

        private void DisplayList()
        {
            lbRequested.Items.Clear();
            reqAvas.Clear();

            foreach (Availability av in availabilityContext.GetAllAvailabilities())
            {
                string name = userContext.GetUserByID(av.User.ID).FullName;
                if (av.State.ToString() == "Pending")
                {
                    reqAvas.Add(av);
                    lbRequested.Items.Add(name + "  -  " + av.GetInfo());
                }

            }
        }

        private void DisplayListOfApproved()
        {
            lbAcceptedRequests.Items.Clear();

            foreach (Availability av in availabilityContext.GetAllAvailabilities())
            {
                string name = userContext.GetUserByID(av.User.ID).FullName;
                if (av.State.ToString() == "Approved")
                {

                    reqApprovedAvas.Add(av);
                    lbAcceptedRequests.Items.Add(name + "  -  " + av.GetInfo());
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

            if (availability != null)
            {
                result = ShiftAutomationManager.Run(repeatitions, dayOfWeek, availability.User);

            }
            DisplayFoundResults(result);

        }

        private void DisplayFoundResults(List<Shift> result)
        {

            lbFoundResults.Items.Clear();
            result.ForEach(r => lbFoundResults.Items.Add(r.ToString()));
        }

        private void picDelete_MouseClick(object sender, MouseEventArgs e)
        {
            if(result != null && result.Count > 0)
            {
                if(lbFoundResults.SelectedItem != null)
                {
                    result.RemoveAt(lbFoundResults.SelectedIndex);
                    DisplayFoundResults(result);
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            // Deleting all the shifts for the employee from the current
            if(availability != null)
            {
                User u = userContext.GetUserByID(availability.User.ID);
                ShiftAutomationManager.DeleteShiftFromCurrentDate(u);
            }

            if(result != null)
            {
                // Execution 
                ShiftContext shiftContext = new ShiftContext();
                result.ForEach(shift => shiftContext.Insert(shift));

                // Message
                lbFoundResults.Items.Clear();
                lbFoundResults.Items.Add("Successfully applied!");

                // Sets the states of availability and updates it
                availability.State = AvailabilityType.Approved;
                new AvailabilityContext().UpdateAvailabilityInfo(availability);

                //Updates view
                DisplayList();
                DisplayListOfApproved();
            }

        }

        private void lbAcceptedRequests_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = lbAcceptedRequests.SelectedIndex;
                var request = reqApprovedAvas[lbAcceptedRequests.SelectedIndex];
                request.State = AvailabilityType.Pending;

                new AvailabilityContext().UpdateAvailabilityInfo(request);

                //Updates view
                DisplayList();
                DisplayListOfApproved();

            }
            catch (Exception) { return; }
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

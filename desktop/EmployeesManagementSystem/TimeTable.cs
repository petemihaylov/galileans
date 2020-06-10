using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeesManagementSystem.Data;
using System.Text.RegularExpressions;
using EmployeesManagementSystem.Models;

namespace EmployeesManagementSystem
{
    public partial class TimeTable : Form
    {
        private User loggedUser;


        private AvailabilityContext availabilityContext = new AvailabilityContext();
        private TimeTableManager manager = new TimeTableManager();

        private UserContext userContext = new UserContext();
        private List<Availability> reqAvas = new List<Availability>();
        public TimeTable(User user)
        {
            InitializeComponent();
            this.loggedUser = user;

            foreach (Availability av in availabilityContext.GetAllAvailabilities())
            {
                if (av.State.ToString() == "Pendding")
                {

                    Availability avs = new Availability();
                    avs.User = av.User;
                    avs.IsMonthly = av.IsMonthly;
                    avs.IsWeekly = av.IsWeekly;
                    avs.State = av.State;
                    avs.Days = av.Days;
   
                    reqAvas.Add(avs);
                    lbRequested.Items.Add(avs.GetInfo());

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
            try
            {
                int index = lbRequested.SelectedIndex;
                Availability av = new Availability();
                av = reqAvas[index];
                av.State = AvailabilityType.Declined;
                availabilityContext.UpdateAvailabilityInfo(av);
                UpdateList();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select a pendding preference");
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                int index = lbRequested.SelectedIndex;
                Availability av = new Availability();
                av = reqAvas[index];
                av.State = AvailabilityType.Declined;
                availabilityContext.UpdateAvailabilityInfo(av);
                UpdateList();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select a pendding preference");
            }
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

                    Availability avs = new Availability();
                    avs.User = av.User;
                    avs.IsMonthly = av.IsMonthly;
                    avs.IsWeekly = av.IsWeekly;
                    avs.State = av.State;
                    avs.Days = av.Days;

                    reqAvas.Add(avs);
                }

            }
 
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

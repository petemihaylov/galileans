using System;
using LiveCharts;
using System.Linq;
using LiveCharts.Wpf;
using System.Drawing;
using LiveCharts.Defaults;
using System.Globalization;
using System.Windows.Forms;
using System.Collections.Generic;
using EmployeesManagementSystem.Data;
using EmployeesManagementSystem.Models;
using SeriesCollection = LiveCharts.SeriesCollection;

namespace EmployeesManagementSystem
{
    public partial class Statistic : Form
    {
        // Context variables
        private UserContext userContext = new UserContext();
        private ShiftContext shiftContext = new ShiftContext();
        private DepartmentContext departmentContext = new DepartmentContext();
        private UserDepartmentContext userDepartmentContext = new UserDepartmentContext();


        // Loading Data On Form Load
        List<Department> departments = new List<Department>();
        List<string> months = new List<string>();
        List<User> users = new List<User>();

        Dictionary<string, List< KeyValuePair<string, int> >> shiftDictionary
                 = new Dictionary<string, List< KeyValuePair<string, int> >>();

        Dictionary<string, List<KeyValuePair<string, int>>> attendedShifts
                 = new Dictionary<string, List<KeyValuePair<string, int>>>();

        Dictionary<string, List<KeyValuePair<string, int>>> cancelledShifts
                 = new Dictionary<string, List<KeyValuePair<string, int>>>();

        public Statistic()
        {
            InitializeComponent();

            departments = departmentContext.GetAllDepartments().OfType<Department>().ToList();
            users = userContext.GetAllUsers().OfType<User>().ToList();


            for (int i = 0; i < 6; i++)
            {
                months.Add(DateTime.Now.AddMonths(-i).ToString("MMM"));
            }
            // Preload shiftDictionary data into a structure
            foreach (var m in months)
            {
                var list = new List<KeyValuePair<string, int>>();

                DateTime date = DateTime.ParseExact(m, "MMM", CultureInfo.InvariantCulture);
                departments.ForEach(
                    d => list.Add(new KeyValuePair<string, int>(d.Name, shiftContext.GetShiftsByDateAndDepartment(date, d.ID).Count))
                );

                shiftDictionary.Add(m, list);
            }

            // Preload attendedShifts data into a structure
            foreach (var u in users)
            {
                var attendedList = new List<KeyValuePair<string, int>>();
                var cancelledList = new List<KeyValuePair<string, int>>();

                foreach (var m in months)
                {
                    var date = DateTime.ParseExact(m, "MMM", CultureInfo.InvariantCulture);
                    attendedList.Add(new KeyValuePair<string, int>(m, shiftContext.GetShiftsByDateAndUser(date, u.ID).Count));
                    cancelledList.Add(new KeyValuePair<string, int>(m, shiftContext.GetCancelledShiftsByDateAndUser(date, u.ID).Count));

                };

                 attendedShifts.Add(u.Email, attendedList);
                cancelledShifts.Add(u.Email, cancelledList);
            }
        }
        private void Statistic_Load(object sender, EventArgs e)
        {
            LoadUsers();
            LoadMonths();
            DisplayPieChart(DateTime.Now.ToString("MMM"));
            DisplayCartesianChart(users[0].FullName);
        }

        private void LoadUsers()
        {
            users.ForEach(u => cbUsers.Items.Add(u.FullName));
            cbUsers.Text = users[0].FullName;
        }
        private void LoadMonths()
        {
            // from current get 6 months back
            months.ForEach(m => cbMonths.Items.Add(m));
            cbMonths.Text = (DateTime.Now.ToString("MMM"));
        }
        private void DisplayPieChart(string month)
        {


            pieChart.Series = new SeriesCollection();
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);


            // Load from cached data
            foreach (var keyValuePair in shiftDictionary[month])
            {
                pieChart.Series.Add(
                      new PieSeries()
                      {
                          Title = keyValuePair.Key,
                          Values = new ChartValues<int> { keyValuePair.Value },
                          DataLabels = true,
                          LabelPoint = labelPoint
                      }
                );
     

            }

        }
        private void DisplayCartesianChart(string fullname)
        {
            User u = userContext.GetUserByFullName(fullname);


            var chartShiftsAttended = new ChartValues<int>();
            var chartShiftsCancelled = new ChartValues<int>();
            List<string> chartMonths = new List<string>();

            foreach (var keyValuePair in attendedShifts[u.Email])
            {
                chartShiftsAttended.Add(keyValuePair.Value);
                chartMonths.Add(keyValuePair.Key);
            }

            cancelledShifts[u.Email].ForEach(kv => chartShiftsCancelled.Add(kv.Value));

            cartesianChart.Series = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Attended",
                        Values = chartShiftsAttended
                    },
                    new LineSeries
                    {
                        Title = "Cancelled",
                        Values = chartShiftsCancelled
                    }
                };

            cartesianChart.AxisY.Clear();
            cartesianChart.AxisX.Clear();

            cartesianChart.AxisX.Add(new Axis
            {
                Title = "This Year",
                Labels = chartMonths
            });

            cartesianChart.AxisY.Add(new Axis
            {
                Title = "Shift count"
            });



        }



        // Additional functions 
        private void exit_MouseEnter(object sender, EventArgs e)
        {
            Color color = Color.DarkGray;
            this.exit.BackColor = color;
        }
        private void exit_MouseLeave(object sender, EventArgs e)
        {
            Color color = Color.White;
            this.exit.BackColor = color;
        }
        private void picBack_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Show Dashboard
            Dashboard dashboard = new Dashboard();
            dashboard.Closed += (s, args) => this.Close();
            dashboard.Show();
        }
        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
            if (Application.MessageLoop)
            {
                Application.Exit();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Declare JsonSerializer
            JsonSerializer serializer = new JsonSerializer("users.json");
            // Get data from the Context
            UserContext userContext = new UserContext();
            User[] users = userContext.GetAllUsers();
            // Write to users.json
            serializer.Write(users);
            MessageBox.Show(@"Users info is stored in ' Users.JSON ' file!");
        }
        private void csvbtn_Click(object sender, EventArgs e)
        {
            DataConverterCSV dataConverterCSV = new DataConverterCSV("users.csv");
            UserContext userContext = new UserContext();
            User[] users = userContext.GetAllUsers();

            dataConverterCSV.CSVFileWrite(users.OfType<User>().ToList());

            MessageBox.Show(@"Users info is stored in ' User.CSV ' file!");
        }



        private void cbMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            string date = cbMonths.SelectedItem.ToString();
            DisplayPieChart(date);
        }
        private void cbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

            string fullname = cbUsers.SelectedItem.ToString();
            DisplayCartesianChart(fullname);
        }
    }

    public class DateModel
    {
        public System.DateTime DateTime { get; set; }
        public double Value { get; set; }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using EmployeesManagementSystem.Data;
using EmployeesManagementSystem.Models;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;
using LiveCharts;
using LiveCharts.Wpf;
using SeriesCollection = LiveCharts.SeriesCollection;
using System.Linq;
using LiveCharts.Defaults;

namespace EmployeesManagementSystem
{
    public partial class Statistic : Form
    {
        // Context variables
        private UserContext userContext = new UserContext();
        private ShiftContext shiftContext = new ShiftContext();
        private DepartmentContext departmentContext = new DepartmentContext();
        private UserDepartmentContext userDepartmentContext = new UserDepartmentContext();

        public Statistic()
        {
            InitializeComponent();

        }
        private void Statistic_Load(object sender, EventArgs e)
        {
            LoadUsers();
            LoadMonths();
            DisplayPieChart(DateTime.Now);
            DisplayCartesianChart();
        }

        private void LoadUsers()
        {
            List<User> list = userContext.GetAllUsers().OfType<User>().ToList();
            list.ForEach(u => cbUsers.Items.Add(u.FullName));
            cbUsers.Text = "SELECT USER";
        }
        private void LoadMonths()
        {
            for (int i = 0; i < 6; i++)
            {
                cbMonths.Items.Add(DateTime.Now.AddMonths(i).ToString("MMM"));
            }
        }
        private void DisplayPieChart(DateTime date)
        {


            pieChart.Series = new SeriesCollection();
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            
            // Load data
            List<Department> departments = departmentContext.GetAllDepartments().OfType<Department>().ToList();
            departments.ForEach(item =>
                        pieChart.Series.Add(

                            new PieSeries()
                            {
                                Title = item.Name,
                                Values = new ChartValues<int> { shiftContext.GetShiftsByDateAndDepartment(date,item.ID).Count },
                                DataLabels = true,
                                LabelPoint = labelPoint
                            })
                        );

        }
        private void DisplayCartesianChart()
        {

            
            cartesianChart.Series = new SeriesCollection();
            
            Func<ChartPoint, string> labelPoint = chartPoint => string.Format("User ({0})", chartPoint.X);
            DateTime now = DateTime.Now;

            
            cartesianChart.Series.Add(
                new LineSeries()
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0, 2),
                        new ObservablePoint(4, 7),
                        new ObservablePoint(5, 3),
                        new ObservablePoint(7, 13),
                        new ObservablePoint(8, 8),
                        new ObservablePoint(10, 12),
                        new ObservablePoint(15, 18)
                    },
                    PointGeometrySize = 15,
                    LabelPoint = labelPoint,
                    Title = "Attendance"
                }

            );
            cartesianChart.Series.Add(
                new LineSeries()
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0, 3),
                        new ObservablePoint(1, 1),
                        new ObservablePoint(2, 1),
                        new ObservablePoint(5, 2),
                        new ObservablePoint(7, 3),
                        new ObservablePoint(9, 0),
                        new ObservablePoint(15, 2)
                    },
                    PointGeometrySize = 10,
                    LabelPoint = labelPoint,
                    Title = "Late cancellation"
                }

            );


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

        private void cbMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime date = DateTime.ParseExact(cbMonths.SelectedItem.ToString(), "MMM", CultureInfo.InvariantCulture);
            DisplayPieChart(date);
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
            MessageBox.Show(@"User info is stored in ' user.JSON ' file!");
        }
    }

    public class DateModel
    {
        public System.DateTime DateTime { get; set; }
        public double Value { get; set; }
    }
}

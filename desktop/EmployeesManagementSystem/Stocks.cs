﻿using System;
using System.Drawing;
using System.Windows.Forms;
using EmployeesManagementSystem.Data;
using EmployeesManagementSystem.Models;
using EmployeesManagementSystem.Controllers;
using System.Collections.Generic;

namespace EmployeesManagementSystem
{
    public partial class Stocks : Form
    {
        // Variables
        private IDictionary<string, int> departmentList;
        private Stock[] stocks;
        private User loggedUser;
        private DepartmentContext departmentContext = new DepartmentContext();
        private StockContext stockContext = new StockContext();
        private ShiftController controller = new ShiftController();
        // Default contructor
        public Stocks()
        {

        }

        // Constructor
        public Stocks(User user)
        {
            InitializeComponent();
            this.loggedUser = user;
            this.cbDepartment.Items.Add("All");
            Department[] departments = departmentContext.GetAllDepartments();
            foreach (Department department in departments)
            {
                this.cbDepartment.Items.Add(department.Name);
            }

        }

        private void Stocks_Load(object sender, EventArgs e)
        {
            // Roles division
            if (this.loggedUser.Role == Role.Manager)
            {
                this.btnEmployees.Enabled = true;
                this.btnCancellations.Enabled = true;
                this.btnDepartments.Enabled = true;
                this.btnStocks.Enabled = true;
                this.btnShifts.Enabled = false;
                this.btnStatistics.Enabled = true;
            }
            else if (this.loggedUser.Role == Role.Administrator)
            {
                this.btnEmployees.Enabled = true;
                this.btnCancellations.Enabled = false;
                this.btnDepartments.Enabled = true;
                this.btnStocks.Enabled = false;
                this.btnShifts.Enabled = true;
                this.btnStatistics.Enabled = false;
            }

            try
            {
                this.stocks = stockContext.GetAllStocks();
                showInformation(this.stocks);
            }
            catch (Exception)
            {
                throw new Exception("Can't display info correctly!");
            }
        }

       

        public void UpdateStocks()
        {
            this.stockDataGrid.Rows.Clear();

            Stock[] stock = stockContext.GetAllStocks();
            stockDataGrid.Rows.Clear();
            showInformation(stock);
        }
        private void stockDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int btnReload = 5;
            int btnDelete = 6;

            int index = stockDataGrid.CurrentCell.RowIndex;
            int stockId = Convert.ToInt32(stockDataGrid.Rows[index].Cells[0].Value);

            if (stockDataGrid.CurrentCell.ColumnIndex.Equals(btnReload))
            {
                ReloadStock reloadStock = new ReloadStock(stockId, this);
                reloadStock.Show();
            }
            else if (stockDataGrid.CurrentCell.ColumnIndex.Equals(btnDelete))
            {
                stockContext.DeleteById(stockId);
                UpdateStocks();
            }
        }

        private void showInformation(Stock[] stocks)
        {
            // Clean the dataGrid

            stockDataGrid.Rows.Clear();

            foreach (Stock stock in stocks)
            {
                //MessageBox.Show(stock.Department.Name);

                this.stockDataGrid.Rows.Add(stock.GetInfo());
            }
        }

        // Create
        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateStock createStocks = new CreateStock(this);
            createStocks.Show();
        }

        // Employees
        private void btnEmployees_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Dashboard dashboard = new Dashboard(this.loggedUser);
            dashboard.Closed += (s, args) => this.Close();
            dashboard.Show();
        }

        // Cancellations
        private void btnCancellations_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Messages cncl = new Messages(this.loggedUser);
            cncl.Closed += (s, args) => this.Close();
            cncl.Show();
        }

        // Departments
        private void btnDepartments_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Departments dep = new Departments(this.loggedUser);
            dep.Closed += (s, args) => this.Close();
            dep.Show();

        }

        // Stocks
        private void btnStocks_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Stocks stock = new Stocks(this.loggedUser);
            stock.Closed += (s, args) => this.Close();
            stock.Show();
        }

        // Shifts
        private void btnShifts_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Shifts shifts = new Shifts(this.loggedUser);
            shifts.Closed += (s, args) => this.Close();
            shifts.Show();
        }

        // Exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

            // exiting properly the application
            if (Application.MessageLoop)
            {
                Application.Exit();
            }
        } 

        // Statistics
        private void btnStatistics_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Dashboard
            Statistic stat = new Statistic(loggedUser, this);
            stat.Closed += (s, args) => this.Close();
            stat.Show();
        }

        // Settings
        private void Settings_Click(object sender, EventArgs e)
        {
            settingsPanel.Visible = !settingsPanel.Visible;
        }
        private void editAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Admin details
            AdminDetails adminDetails = new AdminDetails(this.loggedUser, this);
            adminDetails.Closed += (s, args) => this.Hide();
            adminDetails.Show();
        }
        private void LogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Show Log In
            Login login = new Login();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }


        // Hovering
        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            this.btnExit.BackColor = Color.LightGray;
        }
        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            this.btnExit.BackColor = Color.White;
        }
        private void btnEmployees_MouseEnter(object sender, EventArgs e)
        {
            this.btnEmployees.BackColor = Color.DarkGray;
        }
        private void btnEmployees_MouseLeave(object sender, EventArgs e)
        {
            this.btnEmployees.BackColor = Color.LightGray;
        }
        private void btnShifts_MouseEnter(object sender, EventArgs e)
        {
            this.btnShifts.BackColor = Color.DarkGray;
        }
        private void btnShifts_MouseLeave(object sender, EventArgs e)
        {
            this.btnShifts.BackColor = Color.LightGray;
        }
        private void btnCancellations_MouseEnter(object sender, EventArgs e)
        {
            this.btnCancellations.BackColor = Color.DarkGray;
        }
        private void btnCancellations_MouseLeave(object sender, EventArgs e)
        {
            this.btnCancellations.BackColor = Color.LightGray;
        }
        private void btnDepartments_MouseEnter(object sender, EventArgs e)
        {
            this.btnDepartments.BackColor = Color.DarkGray;
        }
        private void btnDepartments_MouseLeave(object sender, EventArgs e)
        {
            this.btnDepartments.BackColor = Color.LightGray;
        }
        private void btnStocks_MouseEnter(object sender, EventArgs e)
        {
            this.btnStocks.BackColor = Color.DarkGray;
        }
        private void btnStocks_MouseLeave(object sender, EventArgs e)
        {
            this.btnStocks.BackColor = Color.LightGray;
        }
        private void btnStatistics_MouseEnter(object sender, EventArgs e)
        {
            this.btnStatistics.BackColor = Color.DarkGray;
        }
        private void btnStatistics_MouseLeave(object sender, EventArgs e)
        {
            this.btnStatistics.BackColor = Color.LightGray;
        }
        private void btnCreate_MouseEnter(object sender, EventArgs e)
        {
            this.btnCreate.BackColor = Color.DarkGray;
        }
        private void btnCreate_MouseLeave(object sender, EventArgs e)
        {
            this.btnCreate.BackColor = Color.LightGray;
        }
        private void btnSettings_MouseEnter(object sender, EventArgs e)
        {
            this.btnSettings.BackColor = Color.DarkGray;
        }
        private void btnSettings_MouseLeave(object sender, EventArgs e)
        {
            this.btnSettings.BackColor = Color.LightGray;
        }

        private void btnCreate_Paint(object sender, PaintEventArgs e)
        {

        }

        private void searchField_TextChanged(object sender, EventArgs e)
        {

            stockDataGrid.Rows.Clear();
            Stock[] search = stockContext.SearchByName(searchField.Text);
            if (search.Length > 0)
            {
                foreach (Stock stock in search)
                {
                    this.stockDataGrid.Rows.Add(stock.GetInfo());
                }
            }
            else
            {
                UpdateStocks();
            }

        }

        private void cbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            Stock[] stocks = stockContext.GetAllStocks();

            string selectedDepartment = cbDepartment.SelectedItem.ToString();
            if (selectedDepartment != "All")
            {
                stockDataGrid.Rows.Clear();
                foreach (Stock stock in stocks)
                {
                    if(stock.Department.ID == departmentContext.GetDepartmentByName(selectedDepartment).ID)
                        this.stockDataGrid.Rows.Add(stock.GetInfo());
                }
            }
            else
            {
                UpdateStocks();
            }
        }
    }
}

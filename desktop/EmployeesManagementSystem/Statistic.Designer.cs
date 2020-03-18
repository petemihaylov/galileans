namespace EmployeesManagementSystem
{
    partial class Statistic
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbBack = new System.Windows.Forms.Label();
            this.picBack = new System.Windows.Forms.PictureBox();
            this.exit = new System.Windows.Forms.PictureBox();
            this.lbMoneyMadeMonth = new System.Windows.Forms.Label();
            this.cbStatistic = new System.Windows.Forms.ComboBox();
            this.cbEmployee = new System.Windows.Forms.ComboBox();
            this.lbSelect = new System.Windows.Forms.Label();
            this.lbEmployee = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lbMonth = new System.Windows.Forms.Label();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.lbBack);
            this.panel4.Controls.Add(this.picBack);
            this.panel4.Controls.Add(this.exit);
            this.panel4.Controls.Add(this.lbMoneyMadeMonth);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1511, 63);
            this.panel4.TabIndex = 4;
            // 
            // lbBack
            // 
            this.lbBack.AutoSize = true;
            this.lbBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBack.Location = new System.Drawing.Point(78, 25);
            this.lbBack.Name = "lbBack";
            this.lbBack.Size = new System.Drawing.Size(47, 20);
            this.lbBack.TabIndex = 4;
            this.lbBack.Text = "Back";
            // 
            // picBack
            // 
            this.picBack.Image = global::EmployeesManagementSystem.Properties.Resources.baseline_arrow_back_ios_black_48dp;
            this.picBack.Location = new System.Drawing.Point(26, 15);
            this.picBack.Name = "picBack";
            this.picBack.Size = new System.Drawing.Size(39, 35);
            this.picBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBack.TabIndex = 3;
            this.picBack.TabStop = false;
            this.picBack.Click += new System.EventHandler(this.picBack_Click);
            // 
            // exit
            // 
            this.exit.Image = global::EmployeesManagementSystem.Properties.Resources.baseline_clear_black_48dp;
            this.exit.Location = new System.Drawing.Point(1446, 15);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(39, 35);
            this.exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exit.TabIndex = 2;
            this.exit.TabStop = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            this.exit.MouseEnter += new System.EventHandler(this.exit_MouseEnter);
            this.exit.MouseLeave += new System.EventHandler(this.exit_MouseLeave);
            // 
            // lbMoneyMadeMonth
            // 
            this.lbMoneyMadeMonth.AutoSize = true;
            this.lbMoneyMadeMonth.Font = new System.Drawing.Font("Arial", 12F);
            this.lbMoneyMadeMonth.Location = new System.Drawing.Point(778, 27);
            this.lbMoneyMadeMonth.Name = "lbMoneyMadeMonth";
            this.lbMoneyMadeMonth.Size = new System.Drawing.Size(62, 23);
            this.lbMoneyMadeMonth.TabIndex = 67;
            this.lbMoneyMadeMonth.Text = "label1";
            // 
            // cbStatistic
            // 
            this.cbStatistic.Font = new System.Drawing.Font("Arial", 12F);
            this.cbStatistic.FormattingEnabled = true;
            this.cbStatistic.Items.AddRange(new object[] {
            "Attendance per employee",
            "Attendance per department",
            "Wage per employee"});
            this.cbStatistic.Location = new System.Drawing.Point(97, 143);
            this.cbStatistic.Name = "cbStatistic";
            this.cbStatistic.Size = new System.Drawing.Size(327, 31);
            this.cbStatistic.TabIndex = 73;
            this.cbStatistic.SelectedIndexChanged += new System.EventHandler(this.cbStatistic_SelectedIndexChanged);
            // 
            // cbEmployee
            // 
            this.cbEmployee.Font = new System.Drawing.Font("Arial", 12F);
            this.cbEmployee.FormattingEnabled = true;
            this.cbEmployee.Location = new System.Drawing.Point(605, 141);
            this.cbEmployee.Name = "cbEmployee";
            this.cbEmployee.Size = new System.Drawing.Size(327, 31);
            this.cbEmployee.TabIndex = 74;
            this.cbEmployee.SelectedIndexChanged += new System.EventHandler(this.cbEmployee_SelectedIndexChanged);
            // 
            // lbSelect
            // 
            this.lbSelect.AutoSize = true;
            this.lbSelect.Font = new System.Drawing.Font("Arial", 14F);
            this.lbSelect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbSelect.Location = new System.Drawing.Point(92, 113);
            this.lbSelect.Name = "lbSelect";
            this.lbSelect.Size = new System.Drawing.Size(186, 27);
            this.lbSelect.TabIndex = 75;
            this.lbSelect.Text = "Select a statistic";
            // 
            // lbEmployee
            // 
            this.lbEmployee.AutoSize = true;
            this.lbEmployee.Font = new System.Drawing.Font("Arial", 14F);
            this.lbEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbEmployee.Location = new System.Drawing.Point(600, 113);
            this.lbEmployee.Name = "lbEmployee";
            this.lbEmployee.Size = new System.Drawing.Size(224, 27);
            this.lbEmployee.TabIndex = 76;
            this.lbEmployee.Text = "Select an employee";
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.SystemColors.Control;
            chartArea2.AxisX.Interval = 1D;
            chartArea2.AxisX.IsStartedFromZero = false;
            chartArea2.AxisX.ScaleBreakStyle.CollapsibleSpaceThreshold = 10;
            chartArea2.AxisX.ScaleBreakStyle.Enabled = true;
            chartArea2.AxisX.ScaleBreakStyle.StartFromZero = System.Windows.Forms.DataVisualization.Charting.StartFromZero.No;
            chartArea2.AxisY.Interval = 1D;
            chartArea2.AxisY.IsStartedFromZero = false;
            chartArea2.AxisY.Maximum = 23D;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.SystemColors.Control;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(39, 221);
            this.chart1.Name = "chart1";
            series5.BorderColor = System.Drawing.SystemColors.Control;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.RangeColumn;
            series5.CustomProperties = "DrawSideBySide=False";
            series5.EmptyPointStyle.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series5.EmptyPointStyle.BorderWidth = 0;
            series5.EmptyPointStyle.IsVisibleInLegend = false;
            series5.Legend = "Legend1";
            series5.Name = "Present";
            series5.YValuesPerPoint = 2;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.RangeColumn;
            series6.CustomProperties = "DrawSideBySide=False";
            series6.EmptyPointStyle.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series6.EmptyPointStyle.BorderWidth = 0;
            series6.EmptyPointStyle.IsVisibleInLegend = false;
            series6.Legend = "Legend1";
            series6.Name = "Absent";
            series6.YValuesPerPoint = 2;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.RangeColumn;
            series7.Color = System.Drawing.Color.Silver;
            series7.CustomProperties = "DrawSideBySide=False";
            series7.EmptyPointStyle.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series7.EmptyPointStyle.BorderWidth = 0;
            series7.EmptyPointStyle.IsVisibleInLegend = false;
            series7.Legend = "Legend1";
            series7.Name = "Scheduled";
            series7.YValuesPerPoint = 2;
            series8.ChartArea = "ChartArea1";
            series8.Color = System.Drawing.Color.ForestGreen;
            series8.Font = new System.Drawing.Font("Roboto", 12F);
            series8.IsValueShownAsLabel = true;
            series8.Legend = "Legend1";
            series8.Name = "Money";
            series8.ShadowColor = System.Drawing.Color.ForestGreen;
            series8.YValuesPerPoint = 2;
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Series.Add(series7);
            this.chart1.Series.Add(series8);
            this.chart1.Size = new System.Drawing.Size(1432, 579);
            this.chart1.TabIndex = 77;
            this.chart1.Text = "u";
            // 
            // lbMonth
            // 
            this.lbMonth.AutoSize = true;
            this.lbMonth.Font = new System.Drawing.Font("Arial", 14F);
            this.lbMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbMonth.Location = new System.Drawing.Point(1101, 113);
            this.lbMonth.Name = "lbMonth";
            this.lbMonth.Size = new System.Drawing.Size(174, 27);
            this.lbMonth.TabIndex = 79;
            this.lbMonth.Text = "Select a month";
            // 
            // cbMonth
            // 
            this.cbMonth.Font = new System.Drawing.Font("Arial", 12F);
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.Location = new System.Drawing.Point(1106, 141);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(327, 31);
            this.cbMonth.TabIndex = 78;
            this.cbMonth.SelectedIndexChanged += new System.EventHandler(this.cbMonth_SelectedIndexChanged);
            // 
            // Statistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1511, 827);
            this.Controls.Add(this.lbMonth);
            this.Controls.Add(this.cbMonth);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.lbEmployee);
            this.Controls.Add(this.lbSelect);
            this.Controls.Add(this.cbEmployee);
            this.Controls.Add(this.cbStatistic);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Statistic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistic";
            this.Load += new System.EventHandler(this.Statistic_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbBack;
        private System.Windows.Forms.PictureBox picBack;
        private System.Windows.Forms.PictureBox exit;
        private System.Windows.Forms.Label lbMoneyMadeMonth;
        private System.Windows.Forms.ComboBox cbStatistic;
        private System.Windows.Forms.ComboBox cbEmployee;
        private System.Windows.Forms.Label lbSelect;
        private System.Windows.Forms.Label lbEmployee;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lbMonth;
        private System.Windows.Forms.ComboBox cbMonth;
    }
}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Statistic));
            this.panel4 = new System.Windows.Forms.Panel();
            this.exit = new System.Windows.Forms.PictureBox();
            this.lbMoneyMadeMonth = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pieChart = new LiveCharts.WinForms.PieChart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbUsers = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMonths = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.csvbtn = new System.Windows.Forms.Button();
            this.cartesianChart = new LiveCharts.WinForms.CartesianChart();
            this.label5 = new System.Windows.Forms.Label();
            this.cbExport = new System.Windows.Forms.ComboBox();
            this.picBack = new System.Windows.Forms.PictureBox();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.exit);
            this.panel4.Controls.Add(this.picBack);
            this.panel4.Controls.Add(this.lbMoneyMadeMonth);
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1636, 63);
            this.panel4.TabIndex = 4;
            // 
            // exit
            // 
            this.exit.Image = global::EmployeesManagementSystem.Properties.Resources.baseline_clear_black_48dp;
            this.exit.Location = new System.Drawing.Point(1566, 17);
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
            this.lbMoneyMadeMonth.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbMoneyMadeMonth.Location = new System.Drawing.Point(147, 23);
            this.lbMoneyMadeMonth.Name = "lbMoneyMadeMonth";
            this.lbMoneyMadeMonth.Size = new System.Drawing.Size(122, 23);
            this.lbMoneyMadeMonth.TabIndex = 67;
            this.lbMoneyMadeMonth.Text = "STATISTICS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EmployeesManagementSystem.Properties.Resources.stock_icon_png_12;
            this.pictureBox1.Location = new System.Drawing.Point(79, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 72;
            this.pictureBox1.TabStop = false;
            // 
            // pieChart
            // 
            this.pieChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.pieChart.Location = new System.Drawing.Point(43, 130);
            this.pieChart.Name = "pieChart";
            this.pieChart.Size = new System.Drawing.Size(436, 403);
            this.pieChart.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 552);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "ATTENDANCE PER DEPARTMENT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(683, 615);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "USER RECENT ACTIVITY";
            // 
            // cbUsers
            // 
            this.cbUsers.FormattingEnabled = true;
            this.cbUsers.Location = new System.Drawing.Point(1333, 608);
            this.cbUsers.Name = "cbUsers";
            this.cbUsers.Size = new System.Drawing.Size(272, 24);
            this.cbUsers.TabIndex = 9;
            this.cbUsers.SelectedIndexChanged += new System.EventHandler(this.cbUsers_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1264, 611);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "USER :";
            // 
            // cbMonths
            // 
            this.cbMonths.FormattingEnabled = true;
            this.cbMonths.Location = new System.Drawing.Point(141, 608);
            this.cbMonths.Name = "cbMonths";
            this.cbMonths.Size = new System.Drawing.Size(229, 24);
            this.cbMonths.TabIndex = 11;
            this.cbMonths.SelectedIndexChanged += new System.EventHandler(this.cbMonths_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 612);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 69;
            this.label4.Text = "MONTH :";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.SlateGray;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(1014, 808);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(270, 34);
            this.btnUpdate.TabIndex = 70;
            this.btnUpdate.Text = "JSON";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // csvbtn
            // 
            this.csvbtn.BackColor = System.Drawing.Color.SlateGray;
            this.csvbtn.FlatAppearance.BorderSize = 0;
            this.csvbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.csvbtn.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csvbtn.ForeColor = System.Drawing.Color.White;
            this.csvbtn.Location = new System.Drawing.Point(1335, 808);
            this.csvbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.csvbtn.Name = "csvbtn";
            this.csvbtn.Size = new System.Drawing.Size(270, 34);
            this.csvbtn.TabIndex = 71;
            this.csvbtn.Text = "CSV";
            this.csvbtn.UseVisualStyleBackColor = false;
            this.csvbtn.Click += new System.EventHandler(this.csvbtn_Click);
            // 
            // cartesianChart
            // 
            this.cartesianChart.Location = new System.Drawing.Point(662, 98);
            this.cartesianChart.Name = "cartesianChart";
            this.cartesianChart.Size = new System.Drawing.Size(943, 471);
            this.cartesianChart.TabIndex = 74;
            this.cartesianChart.Text = "cartesianChart";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(395, 808);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(312, 17);
            this.label5.TabIndex = 76;
            this.label5.Text = "CHOOSE WHAT DATA YOU WANT EXPORTED";
            // 
            // cbExport
            // 
            this.cbExport.FormattingEnabled = true;
            this.cbExport.Items.AddRange(new object[] {
            "Users",
            "Shifts",
            "Cancellations"});
            this.cbExport.Location = new System.Drawing.Point(724, 808);
            this.cbExport.Name = "cbExport";
            this.cbExport.Size = new System.Drawing.Size(229, 24);
            this.cbExport.TabIndex = 75;
            // 
            // picBack
            // 
            this.picBack.Image = global::EmployeesManagementSystem.Properties.Resources.baseline_arrow_back_ios_black_48dp;
            this.picBack.Location = new System.Drawing.Point(13, 14);
            this.picBack.Margin = new System.Windows.Forms.Padding(4);
            this.picBack.Name = "picBack";
            this.picBack.Size = new System.Drawing.Size(37, 32);
            this.picBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBack.TabIndex = 77;
            this.picBack.TabStop = false;
            this.picBack.Click += new System.EventHandler(this.picBack_Click);
            // 
            // Statistic
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(1511, 827);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1636, 867);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbExport);
            this.Controls.Add(this.cartesianChart);
            this.Controls.Add(this.csvbtn);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbMonths);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbUsers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pieChart);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1640, 900);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1636, 867);
            this.Name = "Statistic";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistic";
            this.Load += new System.EventHandler(this.Statistic_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox exit;
        private System.Windows.Forms.Label lbMoneyMadeMonth;
        private LiveCharts.WinForms.PieChart pieChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbUsers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMonths;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button csvbtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private LiveCharts.WinForms.CartesianChart cartesianChart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbExport;
        private System.Windows.Forms.PictureBox picBack;
    }
}
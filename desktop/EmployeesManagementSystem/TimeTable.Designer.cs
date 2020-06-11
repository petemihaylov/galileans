namespace EmployeesManagementSystem
{
    partial class TimeTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeTable));
            this.lbRequested = new System.Windows.Forms.ListBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnDecline = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbDaysOfWeek = new System.Windows.Forms.ComboBox();
            this.numUpDown = new System.Windows.Forms.NumericUpDown();
            this.btnRun = new System.Windows.Forms.Button();
            this.txtWeekdays = new System.Windows.Forms.TextBox();
            this.txtEmployee = new System.Windows.Forms.TextBox();
            this.rbOnce = new System.Windows.Forms.RadioButton();
            this.rbWeekly = new System.Windows.Forms.RadioButton();
            this.rbMonthly = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbBack = new System.Windows.Forms.Label();
            this.picBack = new System.Windows.Forms.PictureBox();
            this.exit = new System.Windows.Forms.PictureBox();
            this.lbFoundResults = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbAcceptedRequests = new System.Windows.Forms.ListBox();
            this.picDelete = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).BeginInit();
            this.SuspendLayout();
            // 
            // lbRequested
            // 
            this.lbRequested.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbRequested.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbRequested.FormattingEnabled = true;
            this.lbRequested.ItemHeight = 16;
            this.lbRequested.Items.AddRange(new object[] {
            ""});
            this.lbRequested.Location = new System.Drawing.Point(27, 35);
            this.lbRequested.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbRequested.Name = "lbRequested";
            this.lbRequested.ScrollAlwaysVisible = true;
            this.lbRequested.Size = new System.Drawing.Size(381, 496);
            this.lbRequested.TabIndex = 66;
            this.lbRequested.SelectedIndexChanged += new System.EventHandler(this.lbRequested_SelectedIndexChanged);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.DimGray;
            this.btnApply.FlatAppearance.BorderSize = 0;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(562, 711);
            this.btnApply.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(187, 37);
            this.btnApply.TabIndex = 72;
            this.btnApply.Text = "APPLY";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnDecline
            // 
            this.btnDecline.BackColor = System.Drawing.Color.DarkGray;
            this.btnDecline.FlatAppearance.BorderSize = 0;
            this.btnDecline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecline.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnDecline.ForeColor = System.Drawing.Color.White;
            this.btnDecline.Location = new System.Drawing.Point(27, 547);
            this.btnDecline.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDecline.Name = "btnDecline";
            this.btnDecline.Size = new System.Drawing.Size(151, 29);
            this.btnDecline.TabIndex = 73;
            this.btnDecline.Text = "Decline";
            this.btnDecline.UseVisualStyleBackColor = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbDaysOfWeek);
            this.groupBox6.Controls.Add(this.numUpDown);
            this.groupBox6.Controls.Add(this.btnRun);
            this.groupBox6.Controls.Add(this.txtWeekdays);
            this.groupBox6.Controls.Add(this.txtEmployee);
            this.groupBox6.Controls.Add(this.rbOnce);
            this.groupBox6.Controls.Add(this.rbWeekly);
            this.groupBox6.Controls.Add(this.rbMonthly);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Location = new System.Drawing.Point(30, 70);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(719, 255);
            this.groupBox6.TabIndex = 75;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Settings";
            // 
            // cbDaysOfWeek
            // 
            this.cbDaysOfWeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbDaysOfWeek.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbDaysOfWeek.FormattingEnabled = true;
            this.cbDaysOfWeek.Location = new System.Drawing.Point(90, 75);
            this.cbDaysOfWeek.Name = "cbDaysOfWeek";
            this.cbDaysOfWeek.Size = new System.Drawing.Size(300, 24);
            this.cbDaysOfWeek.TabIndex = 79;
            // 
            // numUpDown
            // 
            this.numUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numUpDown.InterceptArrowKeys = false;
            this.numUpDown.Location = new System.Drawing.Point(337, 129);
            this.numUpDown.Name = "numUpDown";
            this.numUpDown.Size = new System.Drawing.Size(53, 22);
            this.numUpDown.TabIndex = 86;
            this.numUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.Silver;
            this.btnRun.FlatAppearance.BorderSize = 0;
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnRun.ForeColor = System.Drawing.Color.White;
            this.btnRun.Location = new System.Drawing.Point(9, 197);
            this.btnRun.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(700, 42);
            this.btnRun.TabIndex = 78;
            this.btnRun.Text = "RUN SCRIPT";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // txtWeekdays
            // 
            this.txtWeekdays.Enabled = false;
            this.txtWeekdays.Location = new System.Drawing.Point(324, 35);
            this.txtWeekdays.Name = "txtWeekdays";
            this.txtWeekdays.Size = new System.Drawing.Size(388, 22);
            this.txtWeekdays.TabIndex = 85;
            // 
            // txtEmployee
            // 
            this.txtEmployee.Enabled = false;
            this.txtEmployee.Location = new System.Drawing.Point(90, 35);
            this.txtEmployee.Name = "txtEmployee";
            this.txtEmployee.Size = new System.Drawing.Size(218, 22);
            this.txtEmployee.TabIndex = 83;
            // 
            // rbOnce
            // 
            this.rbOnce.AutoSize = true;
            this.rbOnce.Location = new System.Drawing.Point(12, 128);
            this.rbOnce.Margin = new System.Windows.Forms.Padding(4);
            this.rbOnce.Name = "rbOnce";
            this.rbOnce.Size = new System.Drawing.Size(63, 21);
            this.rbOnce.TabIndex = 82;
            this.rbOnce.TabStop = true;
            this.rbOnce.Text = "Once";
            this.rbOnce.UseVisualStyleBackColor = true;
            // 
            // rbWeekly
            // 
            this.rbWeekly.AutoSize = true;
            this.rbWeekly.Location = new System.Drawing.Point(224, 129);
            this.rbWeekly.Margin = new System.Windows.Forms.Padding(4);
            this.rbWeekly.Name = "rbWeekly";
            this.rbWeekly.Size = new System.Drawing.Size(75, 21);
            this.rbWeekly.TabIndex = 81;
            this.rbWeekly.TabStop = true;
            this.rbWeekly.Text = "Weekly";
            this.rbWeekly.UseVisualStyleBackColor = true;
            // 
            // rbMonthly
            // 
            this.rbMonthly.AutoSize = true;
            this.rbMonthly.Location = new System.Drawing.Point(109, 128);
            this.rbMonthly.Margin = new System.Windows.Forms.Padding(4);
            this.rbMonthly.Name = "rbMonthly";
            this.rbMonthly.Size = new System.Drawing.Size(78, 21);
            this.rbMonthly.TabIndex = 80;
            this.rbMonthly.TabStop = true;
            this.rbMonthly.Text = "Monthly";
            this.rbMonthly.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 38);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 17);
            this.label9.TabIndex = 79;
            this.label9.Text = "Employee :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 82);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 17);
            this.label8.TabIndex = 76;
            this.label8.Text = "Days:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.lbBack);
            this.panel4.Controls.Add(this.picBack);
            this.panel4.Controls.Add(this.exit);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1394, 49);
            this.panel4.TabIndex = 76;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EmployeesManagementSystem.Properties.Resources.download;
            this.pictureBox1.Location = new System.Drawing.Point(1313, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // lbBack
            // 
            this.lbBack.AutoSize = true;
            this.lbBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBack.Location = new System.Drawing.Point(60, 14);
            this.lbBack.Name = "lbBack";
            this.lbBack.Size = new System.Drawing.Size(47, 20);
            this.lbBack.TabIndex = 4;
            this.lbBack.Text = "Back";
            // 
            // picBack
            // 
            this.picBack.Image = global::EmployeesManagementSystem.Properties.Resources.baseline_arrow_back_ios_black_48dp;
            this.picBack.Location = new System.Drawing.Point(15, 8);
            this.picBack.Margin = new System.Windows.Forms.Padding(4);
            this.picBack.Name = "picBack";
            this.picBack.Size = new System.Drawing.Size(37, 32);
            this.picBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBack.TabIndex = 3;
            this.picBack.TabStop = false;
            this.picBack.Click += new System.EventHandler(this.picBack_Click);
            // 
            // exit
            // 
            this.exit.Image = global::EmployeesManagementSystem.Properties.Resources.baseline_clear_black_48dp;
            this.exit.Location = new System.Drawing.Point(1928, 18);
            this.exit.Margin = new System.Windows.Forms.Padding(4);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(52, 43);
            this.exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exit.TabIndex = 2;
            this.exit.TabStop = false;
            // 
            // lbFoundResults
            // 
            this.lbFoundResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbFoundResults.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbFoundResults.FormattingEnabled = true;
            this.lbFoundResults.ItemHeight = 16;
            this.lbFoundResults.Items.AddRange(new object[] {
            ""});
            this.lbFoundResults.Location = new System.Drawing.Point(30, 386);
            this.lbFoundResults.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbFoundResults.Name = "lbFoundResults";
            this.lbFoundResults.ScrollAlwaysVisible = true;
            this.lbFoundResults.Size = new System.Drawing.Size(742, 304);
            this.lbFoundResults.TabIndex = 77;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lbAcceptedRequests);
            this.groupBox1.Controls.Add(this.lbRequested);
            this.groupBox1.Controls.Add(this.btnDecline);
            this.groupBox1.Location = new System.Drawing.Point(936, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(419, 606);
            this.groupBox1.TabIndex = 78;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Requested Shifts";
            // 
            // lbAcceptedRequests
            // 
            this.lbAcceptedRequests.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbAcceptedRequests.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbAcceptedRequests.FormattingEnabled = true;
            this.lbAcceptedRequests.ItemHeight = 16;
            this.lbAcceptedRequests.Items.AddRange(new object[] {
            ""});
            this.lbAcceptedRequests.Location = new System.Drawing.Point(27, 419);
            this.lbAcceptedRequests.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbAcceptedRequests.Name = "lbAcceptedRequests";
            this.lbAcceptedRequests.ScrollAlwaysVisible = true;
            this.lbAcceptedRequests.Size = new System.Drawing.Size(381, 112);
            this.lbAcceptedRequests.TabIndex = 74;
            this.lbAcceptedRequests.SelectedIndexChanged += new System.EventHandler(this.lbAcceptedRequests_SelectedIndexChanged);
            // 
            // picDelete
            // 
            this.picDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDelete.Image = global::EmployeesManagementSystem.Properties.Resources.taken1;
            this.picDelete.Location = new System.Drawing.Point(30, 711);
            this.picDelete.Margin = new System.Windows.Forms.Padding(4);
            this.picDelete.Name = "picDelete";
            this.picDelete.Size = new System.Drawing.Size(22, 23);
            this.picDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDelete.TabIndex = 6;
            this.picDelete.TabStop = false;
            this.picDelete.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picDelete_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.2F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(32, 395);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Approved";
            // 
            // TimeTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 798);
            this.Controls.Add(this.picDelete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbFoundResults);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btnApply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TimeTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox lbRequested;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnDecline;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rbOnce;
        private System.Windows.Forms.RadioButton rbWeekly;
        private System.Windows.Forms.RadioButton rbMonthly;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbBack;
        private System.Windows.Forms.PictureBox picBack;
        private System.Windows.Forms.PictureBox exit;
        private System.Windows.Forms.TextBox txtEmployee;
        private System.Windows.Forms.ListBox lbFoundResults;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.NumericUpDown numUpDown;
        private System.Windows.Forms.TextBox txtWeekdays;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbDaysOfWeek;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picDelete;
        private System.Windows.Forms.ListBox lbAcceptedRequests;
        private System.Windows.Forms.Label label1;
    }
}
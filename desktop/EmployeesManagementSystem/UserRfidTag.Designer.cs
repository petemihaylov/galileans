namespace EmployeesManagementSystem
{
    partial class UserRfidTag
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
            this.btnSave = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.txtRfid = new System.Windows.Forms.TextBox();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.dataGridRfid = new System.Windows.Forms.DataGridView();
            this.comboUsers = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClearSelected = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.Rfid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnteredAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LeftAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRfid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Honeydew;
            this.btnSave.Location = new System.Drawing.Point(102, 299);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(132, 33);
            this.btnSave.TabIndex = 52;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1130, 45);
            this.panel4.TabIndex = 49;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::EmployeesManagementSystem.Properties.Resources.baseline_dashboard_black_48dp;
            this.pictureBox1.Location = new System.Drawing.Point(12, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 51;
            this.label1.Text = "RFID:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.Honeydew;
            this.btnGenerate.Location = new System.Drawing.Point(102, 144);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(132, 34);
            this.btnGenerate.TabIndex = 53;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnCheckOut.FlatAppearance.BorderSize = 0;
            this.btnCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCheckOut.Location = new System.Drawing.Point(647, 405);
            this.btnCheckOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(171, 33);
            this.btnCheckOut.TabIndex = 54;
            this.btnCheckOut.Text = "CheckOut";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // txtRfid
            // 
            this.txtRfid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.1F);
            this.txtRfid.Location = new System.Drawing.Point(102, 99);
            this.txtRfid.Name = "txtRfid";
            this.txtRfid.Size = new System.Drawing.Size(294, 25);
            this.txtRfid.TabIndex = 56;
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnCheckIn.FlatAppearance.BorderSize = 0;
            this.btnCheckIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCheckIn.Location = new System.Drawing.Point(448, 405);
            this.btnCheckIn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(171, 33);
            this.btnCheckIn.TabIndex = 57;
            this.btnCheckIn.Text = "CheckIn";
            this.btnCheckIn.UseVisualStyleBackColor = false;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // dataGridRfid
            // 
            this.dataGridRfid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridRfid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRfid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rfid,
            this.UserName,
            this.EnteredAt,
            this.LeftAt});
            this.dataGridRfid.Location = new System.Drawing.Point(444, 83);
            this.dataGridRfid.Name = "dataGridRfid";
            this.dataGridRfid.RowHeadersWidth = 51;
            this.dataGridRfid.RowTemplate.Height = 24;
            this.dataGridRfid.Size = new System.Drawing.Size(659, 292);
            this.dataGridRfid.TabIndex = 58;
            // 
            // comboUsers
            // 
            this.comboUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.1F);
            this.comboUsers.FormattingEnabled = true;
            this.comboUsers.Items.AddRange(new object[] {
            "Admin"});
            this.comboUsers.Location = new System.Drawing.Point(102, 248);
            this.comboUsers.Name = "comboUsers";
            this.comboUsers.Size = new System.Drawing.Size(294, 26);
            this.comboUsers.TabIndex = 59;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 60;
            this.label2.Text = "Users:";
            // 
            // btnClearSelected
            // 
            this.btnClearSelected.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnClearSelected.FlatAppearance.BorderSize = 0;
            this.btnClearSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearSelected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClearSelected.Location = new System.Drawing.Point(933, 405);
            this.btnClearSelected.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClearSelected.Name = "btnClearSelected";
            this.btnClearSelected.Size = new System.Drawing.Size(171, 33);
            this.btnClearSelected.TabIndex = 61;
            this.btnClearSelected.Text = "Clear Selected ";
            this.btnClearSelected.UseVisualStyleBackColor = false;
            this.btnClearSelected.Click += new System.EventHandler(this.btnClearSelected_Click);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnApply.FlatAppearance.BorderSize = 0;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnApply.ForeColor = System.Drawing.Color.Honeydew;
            this.btnApply.Location = new System.Drawing.Point(933, 485);
            this.btnApply.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(170, 29);
            this.btnApply.TabIndex = 62;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // Rfid
            // 
            this.Rfid.HeaderText = "Rfid";
            this.Rfid.MinimumWidth = 6;
            this.Rfid.Name = "Rfid";
            this.Rfid.Width = 90;
            // 
            // UserName
            // 
            this.UserName.HeaderText = "UserName";
            this.UserName.MinimumWidth = 6;
            this.UserName.Name = "UserName";
            this.UserName.Width = 90;
            // 
            // EnteredAt
            // 
            this.EnteredAt.HeaderText = "EnteredAt";
            this.EnteredAt.MinimumWidth = 6;
            this.EnteredAt.Name = "EnteredAt";
            this.EnteredAt.Width = 125;
            // 
            // LeftAt
            // 
            this.LeftAt.HeaderText = "LeftAt";
            this.LeftAt.MinimumWidth = 6;
            this.LeftAt.Name = "LeftAt";
            this.LeftAt.Width = 125;
            // 
            // UserRfidTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1130, 535);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnClearSelected);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboUsers);
            this.Controls.Add(this.dataGridRfid);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.txtRfid);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UserRfidTag";
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRfid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtRfid;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.DataGridView dataGridRfid;
        private System.Windows.Forms.ComboBox comboUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClearSelected;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rfid;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnteredAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn LeftAt;
    }
}
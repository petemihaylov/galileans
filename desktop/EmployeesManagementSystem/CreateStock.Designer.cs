namespace EmployeesManagementSystem
{
    partial class CreateStock
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
            this.exit = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCreateStock = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.exit)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // exit
            // 
            this.exit.Image = global::EmployeesManagementSystem.Properties.Resources.baseline_clear_black_48dp;
            this.exit.Location = new System.Drawing.Point(413, 12);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(39, 35);
            this.exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exit.TabIndex = 2;
            this.exit.TabStop = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.exit);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(464, 231);
            this.panel4.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(27, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(412, 58);
            this.label3.TabIndex = 3;
            this.label3.Text = "CREATE STOCK";
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmail.ForeColor = System.Drawing.Color.Black;
            this.lbEmail.Location = new System.Drawing.Point(69, 371);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(48, 23);
            this.lbEmail.TabIndex = 45;
            this.lbEmail.Text = "Price";
            // 
            // tbPrice
            // 
            this.tbPrice.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPrice.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPrice.Location = new System.Drawing.Point(75, 395);
            this.tbPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(300, 25);
            this.tbPrice.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(68, 430);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 23);
            this.label6.TabIndex = 43;
            this.label6.Text = "Amount";
            // 
            // tbAmount
            // 
            this.tbAmount.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbAmount.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAmount.Location = new System.Drawing.Point(75, 455);
            this.tbAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(300, 25);
            this.tbAmount.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(71, 320);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 23);
            this.label1.TabIndex = 42;
            this.label1.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(75, 344);
            this.tbName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(300, 25);
            this.tbName.TabIndex = 36;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel3.Location = new System.Drawing.Point(72, 376);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 0);
            this.panel3.TabIndex = 41;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Location = new System.Drawing.Point(75, 366);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 1);
            this.panel2.TabIndex = 40;
            // 
            // btnCreateStock
            // 
            this.btnCreateStock.BackColor = System.Drawing.SystemColors.GrayText;
            this.btnCreateStock.FlatAppearance.BorderSize = 0;
            this.btnCreateStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateStock.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateStock.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCreateStock.Location = new System.Drawing.Point(130, 571);
            this.btnCreateStock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCreateStock.Name = "btnCreateStock";
            this.btnCreateStock.Size = new System.Drawing.Size(179, 38);
            this.btnCreateStock.TabIndex = 46;
            this.btnCreateStock.Text = "Create Stock";
            this.btnCreateStock.UseVisualStyleBackColor = false;
            this.btnCreateStock.Click += new System.EventHandler(this.btnCreateStock_Click);
            // 
            // CreateStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 752);
            this.Controls.Add(this.btnCreateStock);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbAmount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreateStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateStock";
            this.Load += new System.EventHandler(this.CreateStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exit)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox exit;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCreateStock;
    }
}
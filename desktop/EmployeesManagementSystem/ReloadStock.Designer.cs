namespace EmployeesManagementSystem
{
    partial class ReloadStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReloadStock));
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbAmount = new System.Windows.Forms.ComboBox();
            this.Amount = new System.Windows.Forms.Label();
            this.btnReaload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Image = global::EmployeesManagementSystem.Properties.Resources.baseline_clear_black_48dp;
            this.btnExit.Location = new System.Drawing.Point(234, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(39, 35);
            this.btnExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnExit.TabIndex = 2;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panel4.Controls.Add(this.btnExit);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(287, 45);
            this.panel4.TabIndex = 7;
            // 
            // cbAmount
            // 
            this.cbAmount.FormattingEnabled = true;
            this.cbAmount.Items.AddRange(new object[] {
            "1",
            "5",
            "10",
            "25",
            "50",
            "100",
            "500"});
            this.cbAmount.Location = new System.Drawing.Point(54, 110);
            this.cbAmount.Name = "cbAmount";
            this.cbAmount.Size = new System.Drawing.Size(182, 24);
            this.cbAmount.TabIndex = 8;
            // 
            // Amount
            // 
            this.Amount.AutoSize = true;
            this.Amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Amount.Location = new System.Drawing.Point(51, 89);
            this.Amount.Name = "Amount";
            this.Amount.Size = new System.Drawing.Size(59, 18);
            this.Amount.TabIndex = 9;
            this.Amount.Text = "Amount";
            // 
            // btnReaload
            // 
            this.btnReaload.BackColor = System.Drawing.SystemColors.GrayText;
            this.btnReaload.FlatAppearance.BorderSize = 0;
            this.btnReaload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReaload.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReaload.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnReaload.Location = new System.Drawing.Point(54, 169);
            this.btnReaload.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReaload.Name = "btnReaload";
            this.btnReaload.Size = new System.Drawing.Size(182, 34);
            this.btnReaload.TabIndex = 47;
            this.btnReaload.Text = "REALOAD";
            this.btnReaload.UseVisualStyleBackColor = false;
            this.btnReaload.Click += new System.EventHandler(this.btnReaload_Click);
            // 
            // ReloadStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 236);
            this.Controls.Add(this.btnReaload);
            this.Controls.Add(this.Amount);
            this.Controls.Add(this.cbAmount);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReloadStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReloadStock";
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnExit;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cbAmount;
        private System.Windows.Forms.Label Amount;
        private System.Windows.Forms.Button btnReaload;
    }
}
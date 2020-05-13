namespace EmployeesManagementSystem
{
    partial class ConfirmCancellation
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lb = new System.Windows.Forms.Label();
            this.btnDeny = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lbShiftTime = new System.Windows.Forms.Label();
            this.lbShiftDate = new System.Windows.Forms.Label();
            this.lbDepartment = new System.Windows.Forms.Label();
            this.lbEnd = new System.Windows.Forms.Label();
            this.lbMessage = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblName.Location = new System.Drawing.Point(60, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(64, 25);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "label1";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblSubject.Location = new System.Drawing.Point(60, 65);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(64, 25);
            this.lblSubject.TabIndex = 1;
            this.lblSubject.Text = "label1";
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lb.Location = new System.Drawing.Point(88, 291);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(468, 25);
            this.lb.TabIndex = 2;
            this.lb.Text = "Should the employee marked as excused or absent?";
            // 
            // btnDeny
            // 
            this.btnDeny.BackColor = System.Drawing.Color.SlateBlue;
            this.btnDeny.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnDeny.ForeColor = System.Drawing.Color.White;
            this.btnDeny.Location = new System.Drawing.Point(383, 329);
            this.btnDeny.Name = "btnDeny";
            this.btnDeny.Size = new System.Drawing.Size(129, 37);
            this.btnDeny.TabIndex = 5;
            this.btnDeny.Text = "Absent";
            this.btnDeny.UseVisualStyleBackColor = false;
            this.btnDeny.Click += new System.EventHandler(this.btnDeny_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.SlateBlue;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(155, 331);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(134, 37);
            this.btnConfirm.TabIndex = 6;
            this.btnConfirm.Text = "Excused";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lbShiftTime
            // 
            this.lbShiftTime.AutoSize = true;
            this.lbShiftTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbShiftTime.Location = new System.Drawing.Point(378, 65);
            this.lbShiftTime.Name = "lbShiftTime";
            this.lbShiftTime.Size = new System.Drawing.Size(64, 25);
            this.lbShiftTime.TabIndex = 9;
            this.lbShiftTime.Text = "label1";
            // 
            // lbShiftDate
            // 
            this.lbShiftDate.AutoSize = true;
            this.lbShiftDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbShiftDate.Location = new System.Drawing.Point(378, 30);
            this.lbShiftDate.Name = "lbShiftDate";
            this.lbShiftDate.Size = new System.Drawing.Size(64, 25);
            this.lbShiftDate.TabIndex = 8;
            this.lbShiftDate.Text = "label1";
            // 
            // lbDepartment
            // 
            this.lbDepartment.AutoSize = true;
            this.lbDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbDepartment.Location = new System.Drawing.Point(60, 99);
            this.lbDepartment.Name = "lbDepartment";
            this.lbDepartment.Size = new System.Drawing.Size(64, 25);
            this.lbDepartment.TabIndex = 10;
            this.lbDepartment.Text = "label1";
            // 
            // lbEnd
            // 
            this.lbEnd.AutoSize = true;
            this.lbEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbEnd.Location = new System.Drawing.Point(378, 99);
            this.lbEnd.Name = "lbEnd";
            this.lbEnd.Size = new System.Drawing.Size(64, 25);
            this.lbEnd.TabIndex = 11;
            this.lbEnd.Text = "label1";
            // 
            // lbMessage
            // 
            this.lbMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lbMessage.Location = new System.Drawing.Point(65, 136);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(515, 152);
            this.lbMessage.TabIndex = 12;
            this.lbMessage.Text = "";
            // 
            // ConfirmCancellation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 390);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.lbEnd);
            this.Controls.Add(this.lbDepartment);
            this.Controls.Add(this.lbShiftTime);
            this.Controls.Add(this.lbShiftDate);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnDeny);
            this.Controls.Add(this.lb);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.lblName);
            this.Name = "ConfirmCancellation";
            this.Text = "ConfirmCancellation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.Button btnDeny;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lbShiftTime;
        private System.Windows.Forms.Label lbShiftDate;
        private System.Windows.Forms.Label lbDepartment;
        private System.Windows.Forms.Label lbEnd;
        private System.Windows.Forms.RichTextBox lbMessage;
    }
}
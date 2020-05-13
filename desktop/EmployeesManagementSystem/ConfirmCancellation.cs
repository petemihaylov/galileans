using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeesManagementSystem.Data;
using EmployeesManagementSystem.Models;


namespace EmployeesManagementSystem
{
    public partial class ConfirmCancellation : Form
    {
        private CancellationContext cancellationContext = new CancellationContext();
        private ShiftContext shiftContext = new ShiftContext();
        private UserContext userContext = new UserContext();
        private DepartmentContext depContext = new DepartmentContext();
        int userId;
        public ConfirmCancellation(int id)
        {
            InitializeComponent();
            userId = id;
            Models.Cancellation cancel = cancellationContext.GetCancellationByID(id);
            Shift shift = shiftContext.GetShiftByID(cancel.ShiftID);

            lblName.Text = cancel.EmployeeName;
            lblSubject.Text = cancel.Subject;
            lbDepartment.Text = depContext.GetNameById(shift.DepartmentID);
            lbEnd.Text = shift.EndTime.ToString();
            lbShiftDate.Text = shift.ShiftDate.ToString();
            lbShiftTime.Text = shift.StartTime.ToString();

            lbMessage.Text = cancel.Message;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Models.Cancellation cancel = cancellationContext.GetCancellationByID(userId);
            Shift shift = shiftContext.GetShiftByID(cancel.ShiftID);
            shift.Attendance = AttendanceType.EXCUSED;
            shiftContext.UpdateShift(shift);

            this.Close();
        }
        private void btnDeny_Click(object sender, EventArgs e)
        {
            Models.Cancellation cancel = cancellationContext.GetCancellationByID(userId);
            Shift shift = shiftContext.GetShiftByID(cancel.ShiftID);
            shift.Attendance = AttendanceType.ABSENT;
            shiftContext.UpdateShift(shift);
            
            this.Close();
        }
    }
}

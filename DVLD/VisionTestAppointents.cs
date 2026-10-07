using Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD
{
    public partial class VisionTestAppointents : Form
    {
        private int _LocalDrivingLicenseApplicationID;
        private int _TestTypeID;

        public VisionTestAppointents(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;

            this.Load += VisionTestAppointents_Load;
            btnAddAppointment.Click += btnAddAppointment_Click;
            btnClose.Click += (s, e) => this.Close();
        }

        private void VisionTestAppointents_Load(object sender, EventArgs e)
        {
            var testType = TestTypeBusiness.Find(_TestTypeID);
            label1.Text = (testType?.TestTypeTitle ?? "Test") + " Appointments";

            applicationInfo1.LoadApplication(_LocalDrivingLicenseApplicationID);
            _RefreshAppointments();
        }

        private void _RefreshAppointments()
        {
            dtAppointments.DataSource = TestAppointmentBusiness.GetAppointmentsWithResults(_LocalDrivingLicenseApplicationID, _TestTypeID);
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            if (TestAppointmentBusiness.FindOpenAppointment(_LocalDrivingLicenseApplicationID, _TestTypeID) != null)
            {
                MessageBox.Show("An open appointment already exists for this test. Use Edit instead of adding a new appointment.");
                return;
            }

            new ScheduleTest(_LocalDrivingLicenseApplicationID, _TestTypeID).ShowDialog();
            _RefreshAppointments();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dtAppointments.CurrentRow == null) { MessageBox.Show("Please select an appointment first"); return; }

            if ((int)dtAppointments.CurrentRow.Cells["IsLocked"].Value == 1)
            {
                MessageBox.Show("Cannot edit an appointment that has already been taken");
                return;
            }

            new ScheduleTest(_LocalDrivingLicenseApplicationID, _TestTypeID).ShowDialog();
            _RefreshAppointments();
        }

        private void tackTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtAppointments.CurrentRow == null) { MessageBox.Show("Please select an appointment first"); return; }

            if ((int)dtAppointments.CurrentRow.Cells["IsLocked"].Value == 1)
            {
                MessageBox.Show("The result for this test has already been recorded");
                return;
            }

            int appointmentId = (int)dtAppointments.CurrentRow.Cells["TestAppointmentID"].Value;
            new TackTest(appointmentId).ShowDialog();
            _RefreshAppointments();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
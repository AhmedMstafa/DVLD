using Business;
using Common;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class TackTest : Form
    {
        private int _TestAppointmentID;
        private TestAppointmentBusiness _Appointment;

        public TackTest(int TestAppointmentID)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;

            this.Load += TackTest_Load;
            button1.Click += btnSave_Click;
            btnClose.Click += (s, e) => this.Close();
        }

        private void TackTest_Load(object sender, EventArgs e)
        {
            _Appointment = TestAppointmentBusiness.FindByID(_TestAppointmentID);

            if (_Appointment == null)
            {
                MessageBox.Show("Appointment not found");
                this.Close();
                return;
            }

            lblDLAppID.Text = _Appointment.LocalDrivingLicenseApplicationID.ToString();
            lblDate.Text = _Appointment.AppointmentDate.ToString("dd/MM/yyyy");
            lblFees.Text = _Appointment.PaidFees.ToString();
            lblTestID.Text = "Not Taken Yet";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!rbPass.Checked && !rbFail.Checked)
            {
                MessageBox.Show("Please select the result");
                return;
            }

            bool result = rbPass.Checked;
            int testId = TestBusiness.AddNewTest(_Appointment.TestAppointmentID, result, textBox1.Text.Trim(), UserSession.UserId);

            if (testId <= 0)
            {
                MessageBox.Show("An error occurred while saving the test result");
                return;
            }

            MessageBox.Show(result ? "Congratulations, the test was passed!" : "Unfortunately, the test was not passed. A retake appointment will be opened.");
            this.Close();
        }
    }
}
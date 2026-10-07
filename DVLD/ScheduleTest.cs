using Business;
using Common;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace DVLD
{
    public partial class ScheduleTest : Form
    {
        private int _LocalDrivingLicenseApplicationID;
        private int _TestTypeID;
        private TestAppointmentBusiness _Appointment;

        public ScheduleTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;

            button1.Click += button1_Click;
            btnClose.Click += btnClose_Click;
        }

        private void ScheduleTest_Load(object sender, EventArgs e)
        {
            lblDLAppID.Text = _LocalDrivingLicenseApplicationID.ToString();

            var appDetails = LocalDrivingLicenseApplicationBusiness.FindByID(_LocalDrivingLicenseApplicationID);
            if (appDetails != null)
            {
                lblDClass.Text = appDetails.ClassName;
                lblName.Text = appDetails.FullName;
            }

            _Appointment = TestAppointmentBusiness.FindOpenAppointment(_LocalDrivingLicenseApplicationID, _TestTypeID);

            if (_Appointment == null)
            {
                int trial = TestAppointmentBusiness.GetNextTrialNumber(_LocalDrivingLicenseApplicationID, _TestTypeID);
                decimal baseFees = _GetBaseFees();

                _Appointment = new TestAppointmentBusiness
                {
                    LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplicationID,
                    TestTypeID = _TestTypeID,
                    AppointmentDate = DateTime.Now,
                    PaidFees = baseFees
                };

                lblTrail.Text = trial.ToString();
                dtTestDate.Value = DateTime.Now;
                lblFees.Text = baseFees.ToString();

                if (trial > 1)
                {
                    decimal retakeFees = baseFees;
                    groupBox1.Visible = true;
                    lblRFees.Text = retakeFees.ToString();
                    lblRTestAppID.Text = TestAppointmentBusiness.GetLastAppointmentID(_LocalDrivingLicenseApplicationID, _TestTypeID).ToString();
                    lblTotalFees.Text = (baseFees + retakeFees).ToString();

                    _Appointment.PaidFees = baseFees + retakeFees;
                }
                else
                {
                    groupBox1.Visible = false;
                }
            }
            else
            {
                lblTrail.Text = "—";
                dtTestDate.Value = _Appointment.AppointmentDate;
                lblFees.Text = _Appointment.PaidFees.ToString();
                groupBox1.Visible = false;
            }
        }

        private decimal _GetBaseFees()
        {
            var testType = TestTypeBusiness.Find(_TestTypeID);
            return testType != null ? testType.TestTypeFees : 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _Appointment.AppointmentDate = dtTestDate.Value;

            if (!_Appointment.Save(UserSession.UserId))
            {
                MessageBox.Show("An error occurred while saving the appointment");
                return;
            }

            MessageBox.Show("Appointment saved successfully");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
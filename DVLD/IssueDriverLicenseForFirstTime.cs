using Business;
using Common;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class IssueDriverLicenseForFirstTime : Form
    {
        private int _LocalDrivingLicenseApplicationID;

        public IssueDriverLicenseForFirstTime(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

            this.Load += IssueDriverLicenseForFirstTime_Load;
            btnSave.Click += btnSave_Click;
            btnClose.Click += (s, e) => this.Close();
        }

        private void IssueDriverLicenseForFirstTime_Load(object sender, EventArgs e)
        {
            applicationInfo1.LoadApplication(_LocalDrivingLicenseApplicationID);

            if (!TestAppointmentBusiness.HasPassedAllTests(_LocalDrivingLicenseApplicationID))
            {
                MessageBox.Show("The license cannot be issued before passing all tests");
                btnSave.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int personId = applicationInfo1.PersonID;
            int applicationId = applicationInfo1.ApplicationID;
            int licenseClassId = applicationInfo1.LicenseClassID;

            if (personId <= 0 || applicationId <= 0 || licenseClassId <= 0)
            {
                MessageBox.Show("Application data is incomplete");
                return;
            }

            int licenseId = LicenseBusiness.IssueFirstTimeLicense(
                personId, applicationId, licenseClassId, textBox1.Text.Trim(), UserSession.UserId, out string errorMessage);

            if (licenseId <= 0)
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("License issued successfully");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
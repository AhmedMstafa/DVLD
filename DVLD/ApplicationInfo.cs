using Business;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ApplicationInfo : UserControl
    {
        private LocalDrivingLicenseApplicationBusiness _Application;

        public int LocalDrivingLicenseApplicationID { get; private set; }
        public int ApplicationID => _Application?.ApplicationID ?? 0;
        public int PersonID => _Application?.PersonID ?? 0;
        public int LicenseClassID => _Application?.LicenseClassID ?? 0;

        public ApplicationInfo()
        {
            InitializeComponent();
            llViewPersonInfo.Click += llViewPersonInfo_Click;
            linkLabel1.Click += linkLabel1_Click;
        }

        public void LoadApplication(int LocalDrivingLicenseApplicationID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

            _Application = LocalDrivingLicenseApplicationBusiness.FindByID(LocalDrivingLicenseApplicationID);

            if (_Application == null)
            {
                MessageBox.Show("Application not found");
                return;
            }

            lblDLAppID.Text = LocalDrivingLicenseApplicationID.ToString();
            lblApplicationForLicense.Text = _Application.ClassName;

            int passedTests = TestAppointmentBusiness.GetPassedTestsCount(LocalDrivingLicenseApplicationID);
            lblPasedTests.Text = $"{passedTests}/3";

            bool hasLicense = LicenseBusiness.GetLicenseByApplicationID(_Application.ApplicationID).Rows.Count > 0;
            linkLabel1.Enabled = hasLicense;

            lblID.Text = _Application.ApplicationID.ToString();
            lblStatus.Text = _GetStatusText(_Application.ApplicationStatus);
            lblFees.Text = _Application.PaidFees.ToString();
            lblType.Text = _Application.ApplicationTypeTitle;
            lblApplication.Text = _Application.FullName;
            dtDate.Value = _Application.ApplicationDate;
            dtStatusDate.Value = _Application.LastStatusDate;
            lblCreatedBy.Text = _Application.CreatedByUserName;
        }

        private string _GetStatusText(byte status)
        {
            switch (status)
            {
                case 1: return "New";
                case 2: return "Completed";
                case 3: return "Cancelled";
                default: return "Unknown";
            }
        }

        private void llViewPersonInfo_Click(object sender, EventArgs e)
        {
            if (_Application == null) return;

            UserInfo personInfoForm = new UserInfo(_Application.PersonID);
            personInfoForm.Show();
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            if (_Application == null || !linkLabel1.Enabled) return;

            LicenseInfo licenseForm = new LicenseInfo(_Application.ApplicationID);
            licenseForm.ShowDialog();
        }
    }
}
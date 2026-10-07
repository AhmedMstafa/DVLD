using Business;
using Common;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class InternationalDriverLicense : Form
    {
        public InternationalDriverLicense()
        {
            InitializeComponent();
            btnSave.Click += btnSave_Click;
            btnClose.Click += (s, e) => this.Close();
            llShowLicenseHistory.Click += llShowLicenseHistory_Click;
            llShowLicenseInfo.Click += llShowLicenseInfo_Click;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!drivingLicenseInfo1.IsReady)
            {
                MessageBox.Show("Please search for a valid license first");
                return;
            }

            int internationalLicenseId = InternationalLicenseBusiness.IssueInternationalLicense(
                drivingLicenseInfo1.DriverID,
                drivingLicenseInfo1.PersonID,
                drivingLicenseInfo1.LocalLicenseID,
                drivingLicenseInfo1.GetProposedFees(),
                UserSession.UserId,
                out string errorMessage);

            if (internationalLicenseId <= 0)
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("International license issued successfully");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void llShowLicenseHistory_Click(object sender, EventArgs e)
        {
            if (drivingLicenseInfo1.PersonID <= 0)
            {
                MessageBox.Show("Please search first");
                return;
            }
            new LicenseHistory(drivingLicenseInfo1.PersonID).ShowDialog();
        }

        private void llShowLicenseInfo_Click(object sender, EventArgs e)
        {
            if (drivingLicenseInfo1.DriverID <= 0)
            {
                MessageBox.Show("Please search first");
                return;
            }
            new LicenseInfo(drivingLicenseInfo1.ApplicationID).ShowDialog();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

        private void InternationalDriverLicense_Load(object sender, EventArgs e)
        {

        }
    }
}
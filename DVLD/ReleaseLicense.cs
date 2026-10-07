using Business;
using Common;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ReleaseLicense : Form
    {
        private LicenseBusiness _License;
        private DetainedLicenseBusiness _ActiveDetain;
        private int _LicenseID;
        private bool _IsReady;

        public ReleaseLicense()
        {
            InitializeComponent();

            btnSearch.Click += btnSearch_Click;
            btnRelease.Click += btnRelease_Click;
            btnClose.Click += (s, e) => this.Close();
            llShowLicenseHistory.Click += llShowLicenseHistory_Click;
            llShowNewLicenseInfo.Click += llShowNewLicenseInfo_Click;

            llShowNewLicenseInfo.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSearch.Text.Trim(), out int licenseId))
            {
                MessageBox.Show("Please enter a valid license ID");
                return;
            }

            _License = LicenseBusiness.FindByLicenseID(licenseId);

            if (_License == null)
            {
                MessageBox.Show("No license found with this ID");
                _IsReady = false;
                return;
            }

            _LicenseID = licenseId;

            lblClass.Text = _License.ClassName;
            lblName.Text = _License.FullName;
            lblLicenseID.Text = licenseId.ToString();
            lblNationalID.Text = _License.NationalNo;
            lblGendor.Text = _License.Gender == 0 ? "Male" : "Female";
            lblIssueDate.Text = _License.IssueDate.ToString("dd/MM/yyyy");
            lblIssueReason.Text = "First Time";
            lblNotes.Text = string.IsNullOrEmpty(_License.Notes) ? "No Notes" : _License.Notes;
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = _License.DateOfBirth.ToString("dd/MM/yyyy");
            lblDriverID.Text = _License.DriverID.ToString();
            lblExpirationDate.Text = _License.ExpirationDate.ToString("dd/MM/yyyy");

            bool isDetained = DetainedLicenseBusiness.IsLicenseDetained(licenseId);
            lblIsDetained.Text = isDetained ? "Yes" : "No";

            if (!string.IsNullOrEmpty(_License.ImagePath) && File.Exists(_License.ImagePath))
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(_License.ImagePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch { }
            }

            if (!isDetained)
            {
                MessageBox.Show("This license is not currently detained");
                _IsReady = false;
                return;
            }

            _ActiveDetain = DetainedLicenseBusiness.FindActiveDetainByLicenseID(licenseId);

            if (_ActiveDetain == null)
            {
                MessageBox.Show("An error occurred while retrieving detain data");
                _IsReady = false;
                return;
            }

            llDetainedID.Text = _ActiveDetain.DetainID.ToString();
            llDetainedDate.Text = _ActiveDetain.DetainDate.ToString("dd/MM/yyyy");
            llLicenseID.Text = licenseId.ToString();
            llLicenseFees.Text = _ActiveDetain.FineFees.ToString();

            _IsReady = true;
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (!_IsReady)
            {
                MessageBox.Show("Please search for a detained license first");
                return;
            }

            var appType = ApplicationTypeBusiness.Find(DetainedLicenseBusiness.RELEASE_DETAINED_APPLICATION_TYPE_ID);
            decimal applicationFees = appType != null ? appType.ApplicationFees : 0;

            int personId = DriverBusiness.GetPersonIdByDriverId(_License.DriverID);

            bool released = DetainedLicenseBusiness.ReleaseLicense(
                _ActiveDetain.DetainID,
                _LicenseID,
                personId,
                applicationFees,
                UserSession.UserId,
                out string errorMessage);

            if (!released)
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lblIsDetained.Text = "No";
            llShowNewLicenseInfo.Enabled = true;

            MessageBox.Show("License released successfully");
        }

        private void llShowLicenseHistory_Click(object sender, EventArgs e)
        {
            if (_License == null) return;
            int personId = DriverBusiness.GetPersonIdByDriverId(_License.DriverID);
            new LicenseHistory(personId).ShowDialog();
        }

        private void llShowNewLicenseInfo_Click(object sender, EventArgs e)
        {
            if (_License == null) return;
            new LicenseInfo(_License.ApplicationID).ShowDialog();
        }
    }
}
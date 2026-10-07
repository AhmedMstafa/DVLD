using Business;
using Common;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DVLD
{
    public partial class DetainLicense : Form
    {
        private LicenseBusiness _License;
        private int _LicenseID;
        private bool _IsReady;

        public DetainLicense()
        {
            InitializeComponent();

            btnSearch.Click += btnSearch_Click;
            btnSave.Click += btnSave_Click;
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

            if (!_License.IsActive)
            {
                MessageBox.Show("Cannot detain an inactive license");
                _IsReady = false;
                return;
            }

            if (isDetained)
            {
                MessageBox.Show("This license is already detained");
                _IsReady = false;
                return;
            }

            this.llDetainedID.Text = "[???]";
            llLicenseFees.Text = "0";

            _IsReady = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_IsReady)
            {
                MessageBox.Show("Please search for an eligible license to detain first");
                return;
            }

            if (!decimal.TryParse(llLicenseFees.Text.Trim(), out decimal fineFees))
            {
                MessageBox.Show("Please enter a valid fine fee");
                return;
            }

            int detainId = DetainedLicenseBusiness.DetainLicense(_LicenseID, fineFees, UserSession.UserId, out string errorMessage);

            if (detainId <= 0)
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.llDetainedID.Text = detainId.ToString();
            lblIsDetained.Text = "Yes";
            llShowNewLicenseInfo.Enabled = true;

            MessageBox.Show("License detained successfully");
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
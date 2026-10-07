using Business;
using Common;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DVLD
{
    public partial class DrivingLicenseInfo : UserControl
    {
        private LicenseBusiness _License;

        public bool IsReady { get; private set; }
        public int DriverID => _License?.DriverID ?? 0;
        public int PersonID => _License?.PersonID ?? 0;
        public int ApplicationID => _License?.ApplicationID ?? 0;
        public int LocalLicenseID { get; private set; }

        public DrivingLicenseInfo()
        {
            InitializeComponent();
            btnSearch.Click += btnSearch_Click;
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
                IsReady = false;
                return;
            }

            LocalLicenseID = licenseId;

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

            bool eligible = InternationalLicenseBusiness.IsEligible(_License.DriverID, licenseId, out string errorMessage);

            if (!eligible)
            {
                MessageBox.Show(errorMessage, "Not Eligible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                IsReady = false;
                lblLLAplicationID.Text = "[???]";
                return;
            }

            DateTime proposedIssueDate = DateTime.Now;
            DateTime proposedExpDate = proposedIssueDate.AddYears(1);
            var appType = ApplicationTypeBusiness.Find(InternationalLicenseBusiness.NEW_INTERNATIONAL_LICENSE_APPLICATION_TYPE_ID);
            decimal proposedFees = appType != null ? appType.ApplicationFees : 0;

            lblLLAplicationID.Text = "[???]";
            llApplicationDate.Text = proposedIssueDate.ToString("dd/MM/yyyy");
            IssueDate.Text = proposedIssueDate.ToString("dd/MM/yyyy");
            lblFees.Text = proposedFees.ToString();
            lblLLLicenseID.Text = "[???]";
            lblLocalLicenseID.Text = licenseId.ToString();
            llExpirationDate.Text = proposedExpDate.ToString("dd/MM/yyyy");
            llCreatedBy.Text = UserSession.Username;

            IsReady = true;
        }

        public decimal GetProposedFees()
        {
            return decimal.TryParse(lblFees.Text, out decimal fees) ? fees : 0;
        }
    }
}
using Business;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DVLD
{
    public partial class LicenseInfo : Form
    {
        private int _ApplicationID;
        private LicenseBusiness _License;

        public LicenseInfo(int ApplicationID)
        {
            InitializeComponent();
            _ApplicationID = ApplicationID;

            this.Load += LicenseInfo_Load;
            btnClose.Click += (s, e) => this.Close();
        }

        private void LicenseInfo_Load(object sender, EventArgs e)
        {
            _License = LicenseBusiness.FindByApplicationID(_ApplicationID);

            if (_License == null)
            {
                MessageBox.Show("License not found");
                this.Close();
                return;
            }

            lblClass.Text = _License.ClassName;
            lblName.Text = _License.FullName;
            lblNationalNo.Text = _License.NationalNo;
            lblGendor.Text = _License.Gender == 0 ? "Male" : "Female";
            lblIssueDate.Text = _License.IssueDate.ToString("dd/MM/yyyy");
            lblIssueReason.Text = "First Time";
            lblNotes.Text = string.IsNullOrEmpty(_License.Notes) ? "No Notes" : _License.Notes;

            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = _License.DateOfBirth.ToString("dd/MM/yyyy");
            lblDriverID.Text = _License.DriverID.ToString();
            lblExpirationDate.Text = _License.ExpirationDate.ToString("dd/MM/yyyy");

            bool isDetained = DetainedLicenseBusiness.IsLicenseDetained(_License.LicenseID);
            lblIsDetained.Text = isDetained ? "Yes" : "No";

            if (!string.IsNullOrEmpty(_License.ImagePath) && File.Exists(_License.ImagePath))
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(_License.ImagePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}");
                }
            }
        }
    }
}
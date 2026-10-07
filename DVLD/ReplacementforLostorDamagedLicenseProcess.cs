using Business;
using Common;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ReplacementforLostorDamagedLicenseProcess : Form
    {
        private LicenseBusiness _OldLicense;
        private int _OldLicenseID;
        private bool _IsReady;
        private int _NewLicenseID = -1;
        private int _NewApplicationID = -1;
        private int _SelectedApplicationTypeID;

        public ReplacementforLostorDamagedLicenseProcess()
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

            _OldLicense = LicenseBusiness.FindByLicenseID(licenseId);

            if (_OldLicense == null)
            {
                MessageBox.Show("No license found with this ID");
                _IsReady = false;
                return;
            }

            _OldLicenseID = licenseId;

            lblClass.Text = _OldLicense.ClassName;
            lblName.Text = _OldLicense.FullName;
            lblLicenseID.Text = licenseId.ToString();
            lblNationalID.Text = _OldLicense.NationalNo;
            lblGendor.Text = _OldLicense.Gender == 0 ? "Male" : "Female";
            lblIssueDate.Text = _OldLicense.IssueDate.ToString("dd/MM/yyyy");
            lblIssueReason.Text = "First Time";
            lblNotes.Text = string.IsNullOrEmpty(_OldLicense.Notes) ? "No Notes" : _OldLicense.Notes;
            lblIsActive.Text = _OldLicense.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = _OldLicense.DateOfBirth.ToString("dd/MM/yyyy");
            lblDriverID.Text = _OldLicense.DriverID.ToString();
            lblExpirationDate.Text = _OldLicense.ExpirationDate.ToString("dd/MM/yyyy");

            bool isDetained = DetainedLicenseBusiness.IsLicenseDetained(licenseId);
            lblIsDetained.Text = isDetained ? "Yes" : "No";

            if (!string.IsNullOrEmpty(_OldLicense.ImagePath) && File.Exists(_OldLicense.ImagePath))
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(_OldLicense.ImagePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch { }
            }

            bool eligible = LicenseBusiness.IsEligibleForReplacement(_OldLicense.IsActive, licenseId, out string errorMessage);

            if (!eligible)
            {
                MessageBox.Show(errorMessage, "Not Eligible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _IsReady = false;
                llRLApplicationID.Text = "[???]";
                return;
            }

            DialogResult result = MessageBox.Show(
                "Is the license lost (Yes) or damaged (No)?",
                "Replacement Reason",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            _SelectedApplicationTypeID = (result == DialogResult.Yes)
                ? LicenseBusiness.REPLACEMENT_LOST_APPLICATION_TYPE_ID
                : LicenseBusiness.REPLACEMENT_DAMAGED_APPLICATION_TYPE_ID;

            DateTime proposedIssueDate = DateTime.Now;
            var appType = ApplicationTypeBusiness.Find(_SelectedApplicationTypeID);
            decimal applicationFees = appType != null ? appType.ApplicationFees : 0;

            int classId = _GetLicenseClassIdByName(_OldLicense.ClassName);
            LicenseClassBusiness.Find(classId, out _, out decimal classFees, out byte validityYears);

            DateTime proposedExpDate = proposedIssueDate.AddYears(validityYears > 0 ? validityYears : 10);
            decimal totalFees = applicationFees + classFees;

            llRLApplicationID.Text = "[???]";
            llAplicationDate.Text = proposedIssueDate.ToString("dd/MM/yyyy");
            llIssueDate.Text = proposedIssueDate.ToString("dd/MM/yyyy");
            llApplicationFees.Text = applicationFees.ToString();
            llLicenseFees.Text = classFees.ToString();
            llRenwedLicenseID.Text = "[???]";
            llOldLiceseID.Text = licenseId.ToString();
            llExpirationDate.Text = proposedExpDate.ToString("dd/MM/yyyy");
            llCreaetedBy.Text = UserSession.Username;
            llTotalFees.Text = totalFees.ToString();

            _IsReady = true;
        }

        private int _GetLicenseClassIdByName(string className)
        {
            var dt = LicenseClassBusiness.GetAllLicenseClasses();
            foreach (System.Data.DataRow row in dt.Rows)
            {
                if (row["ClassName"].ToString() == className)
                    return Convert.ToInt32(row["LicenseClassID"]);
            }
            return 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_IsReady)
            {
                MessageBox.Show("Please search for a license eligible for replacement first");
                return;
            }

            int classId = _GetLicenseClassIdByName(_OldLicense.ClassName);
            decimal applicationFees = decimal.TryParse(llApplicationFees.Text, out decimal af) ? af : 0;
            decimal licenseFees = decimal.TryParse(llLicenseFees.Text, out decimal lf) ? lf : 0;

            int applicationId = ApplicationBusiness.AddNewApplication(
                DriverBusiness.GetPersonIdByDriverId(_OldLicense.DriverID),
                _SelectedApplicationTypeID,
                applicationFees,
                UserSession.UserId);

            if (applicationId <= 0)
            {
                MessageBox.Show("An error occurred while creating the replacement application");
                return;
            }

            int newLicenseId = LicenseBusiness.ReplaceLicense(
                _OldLicenseID,
                _OldLicense.DriverID,
                applicationId,
                classId,
                licenseFees,
                textBox1.Text.Trim(),
                UserSession.UserId,
                out string errorMessage);

            if (newLicenseId <= 0)
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ApplicationBusiness.UpdateApplicationStatus(applicationId, ApplicationBusiness.enApplicationStatus.Completed);

            _NewLicenseID = newLicenseId;
            _NewApplicationID = applicationId;

            llRLApplicationID.Text = applicationId.ToString();
            llRenwedLicenseID.Text = newLicenseId.ToString();
            llShowNewLicenseInfo.Enabled = true;

            MessageBox.Show("Replacement license issued successfully");
        }

        private void llShowLicenseHistory_Click(object sender, EventArgs e)
        {
            if (_OldLicense == null) return;
            int personId = DriverBusiness.GetPersonIdByDriverId(_OldLicense.DriverID);
            new LicenseHistory(personId).ShowDialog();
        }

        private void llShowNewLicenseInfo_Click(object sender, EventArgs e)
        {
            if (_NewApplicationID <= 0)
            {
                MessageBox.Show("No new license has been issued yet");
                return;
            }

            new LicenseInfo(_NewApplicationID).ShowDialog();
        }
    }
}
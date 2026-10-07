using Business;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class DriverInteranationalLicenseInfo : UserControl
    {
        public DriverInteranationalLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadInternationalLicense(int InternationalLicenseID)
        {
            var intlLicense = InternationalLicenseBusiness.FindByID(InternationalLicenseID);

            if (intlLicense == null)
            {
                MessageBox.Show("International License not found");
                return;
            }

            lblName.Text = intlLicense.FullName;
            lblIntLIcenseID.Text = InternationalLicenseID.ToString();
            label12.Text = intlLicense.LocalLicenseID.ToString();
            lblNationalID.Text = intlLicense.NationalNo;
            lblGendor.Text = intlLicense.Gender == 0 ? "Male" : "Female";
            lblIssueDate.Text = intlLicense.IssueDate.ToString("dd/MM/yyyy");
            lblApplicationID.Text = intlLicense.ApplicationID.ToString();
            lblIsActive.Text = intlLicense.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = intlLicense.DateOfBirth.ToString("dd/MM/yyyy");
            lblDriverID.Text = intlLicense.DriverID.ToString();
            lblExpirationDate.Text = intlLicense.ExpirationDate.ToString("dd/MM/yyyy");
        }
    }
}
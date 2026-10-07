using Business;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class LicenseHistory : Form
    {
        private int _PersonID;

        public LicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            btnClose.Click += (s, e) => this.Close();
        }

        private void LicenseHistory_Load(object sender, EventArgs e)
        {
            PeopleBusiness selectedPerson = PeopleBusiness.Find(_PersonID);

            if (selectedPerson == null)
            {
                MessageBox.Show("Person not found");
                this.Close();
                return;
            }

            personInformation1.LoadPerson(selectedPerson);

            if (!DataAccess.DriverData.GetDriverByPersonID(_PersonID, out int driverId))
            {
                dtLocalLicense.DataSource = null;
                dtInternationalLicense.DataSource = null;
                return;
            }

            dtLocalLicense.DataSource = LicenseBusiness.GetLocalLicensesByDriverID(driverId);
            dtInternationalLicense.DataSource = LicenseBusiness.GetInternationalLicensesByDriverID(driverId);
        }
    }
}
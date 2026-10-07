using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class InternationalDriverInfo : Form
    {
        private int _InternationalLicenseID;

        public InternationalDriverInfo(int InternationalLicenseID)
        {
            InitializeComponent();
            _InternationalLicenseID = InternationalLicenseID;

            this.Load += InternationalDriverInfo_Load;
            btnClose.Click += (s, e) => this.Close();
        }

        private void InternationalDriverInfo_Load(object sender, EventArgs e)
        {
            driverInteranationalLicenseInfo1.LoadInternationalLicense(_InternationalLicenseID);
        }
    }
}
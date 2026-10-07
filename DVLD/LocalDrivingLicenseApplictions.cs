using Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD
{
    public partial class LocalDrivingLicenseApplictions : Form
    {
        private DataTable dtApplications;
        private DataView dvApplications;

        public LocalDrivingLicenseApplictions()
        {
            InitializeComponent();

            this.Load += LocalDrivingLicenseApplictions_Load;
            btnNewApplication.Click += btnNewApplication_Click;
            btnClose.Click += btnClose_Click;
            txtFindValue.TextChanged += txtFindValue_TextChanged;
            cbFindBy.SelectedIndexChanged += cbFindBy_SelectedIndexChanged;

            issueDrivingLicenseFirstTimeToolStripMenuItem.Click += issueDrivingLicenseFirstTimeToolStripMenuItem_Click;
            showLicenseToolStripMenuItem.Click += showLicenseToolStripMenuItem_Click;
            showPersonHistoryLToolStripMenuItem.Click += showPersonHistoryLToolStripMenuItem_Click;

            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
        }

        private void LocalDrivingLicenseApplictions_Load(object sender, EventArgs e)
        {
            _RefreshList();
            _FillFindByComboBox();
        }

        private void _RefreshList()
        {
            dtApplications = LocalDrivingLicenseApplicationBusiness.GetAllLocalDrivingLicenseApplications();
            dvApplications = new DataView(dtApplications);
            dgvApplications.DataSource = dvApplications;
        }

        private void _FillFindByComboBox()
        {
            cbFindBy.Items.Clear();
            foreach (DataColumn col in dtApplications.Columns)
                cbFindBy.Items.Add(col.ColumnName);

            cbFindBy.SelectedIndex = 0;
        }

        private void _ApplyFilter()
        {
            if (dvApplications == null || cbFindBy.SelectedItem == null) return;

            string column = cbFindBy.SelectedItem.ToString();
            string value = txtFindValue.Text.Replace("'", "''");

            if (string.IsNullOrEmpty(value))
            {
                dvApplications.RowFilter = "";
                return;
            }

            dvApplications.RowFilter = $"[{column}] LIKE '%{value}%'";
        }

        private void cbFindBy_SelectedIndexChanged(object sender, EventArgs e) => _ApplyFilter();
        private void txtFindValue_TextChanged(object sender, EventArgs e) => _ApplyFilter();

        private void btnNewApplication_Click(object sender, EventArgs e)
        {
            NewLocalDrivingLicenseApplications newAppForm = new NewLocalDrivingLicenseApplications();
            newAppForm.ShowDialog();
            _RefreshList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
            => _OpenAppointmentsForm((int)TestAppointmentBusiness.enTestType.Vision);

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
            => _OpenAppointmentsForm((int)TestAppointmentBusiness.enTestType.Written);

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
            => _OpenAppointmentsForm((int)TestAppointmentBusiness.enTestType.Street);

        private void _OpenAppointmentsForm(int testTypeId)
        {
            int localAppId = (int)dgvApplications.CurrentRow.Cells["L.D.L.AppID"].Value;
            new VisionTestAppointents(localAppId, testTypeId).ShowDialog();
            _RefreshList();
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dgvApplications.CurrentRow == null) { e.Cancel = true; return; }

            int localAppId = (int)dgvApplications.CurrentRow.Cells["L.D.L.AppID"].Value;

            var appDetails = LocalDrivingLicenseApplicationBusiness.FindByID(localAppId);
            if (appDetails == null) return;

            bool allTestsPassed = TestAppointmentBusiness.HasPassedAllTests(localAppId);
            bool hasLicense = LicenseBusiness.GetLicenseByApplicationID(appDetails.ApplicationID).Rows.Count > 0;

            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = allTestsPassed && !hasLicense;
            showLicenseToolStripMenuItem.Enabled = hasLicense;
            showPersonHistoryLToolStripMenuItem.Enabled = true;

            int? nextTestType = TestAppointmentBusiness.GetNextRequiredTestType(localAppId);
            sechdulVisionTestToolStripMenuItem.Enabled = nextTestType == (int)TestAppointmentBusiness.enTestType.Vision;
            sechdulWrittenTestToolStripMenuItem.Enabled = nextTestType == (int)TestAppointmentBusiness.enTestType.Written;
            schedulStreetTestToolStripMenuItem.Enabled = nextTestType == (int)TestAppointmentBusiness.enTestType.Street;
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localAppId = (int)dgvApplications.CurrentRow.Cells["L.D.L.AppID"].Value;

            IssueDriverLicenseForFirstTime issueForm = new IssueDriverLicenseForFirstTime(localAppId);
            issueForm.ShowDialog();

            _RefreshList();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localAppId = (int)dgvApplications.CurrentRow.Cells["L.D.L.AppID"].Value;

            var appDetails = LocalDrivingLicenseApplicationBusiness.FindByID(localAppId);
            if (appDetails == null) return;

            LicenseInfo licenseForm = new LicenseInfo(appDetails.ApplicationID);
            licenseForm.ShowDialog();
        }

        private void showPersonHistoryLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localAppId = (int)dgvApplications.CurrentRow.Cells["L.D.L.AppID"].Value;

            var appDetails = LocalDrivingLicenseApplicationBusiness.FindByID(localAppId);
            if (appDetails == null) return;

            LicenseHistory historyForm = new LicenseHistory(appDetails.PersonID);
            historyForm.ShowDialog();
        }
    }
}
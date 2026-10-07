using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ctxApplications.Show(btnApplications, new Point(0, btnApplications.Height));
        }

        private void btnPoeple_Click(object sender, EventArgs e)
        {
            new PeopleList().ShowDialog();

        }

        private void MainScreen_Load(object sender, EventArgs e)
        {

        }

        private void btnAccountSettings_Click(object sender, EventArgs e)
        {
            ctxAccountSettings.Show(btnAccountSettings, new Point(0, btnAccountSettings.Height));
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
      "Are you sure you want to sign out?",
      "Confirmation",
      MessageBoxButtons.YesNo,
      MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                UserSession.ClearSession();
                Application.Restart();
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void changePasswordToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ChangePassword changePasswordForm = new ChangePassword();
            changePasswordForm.Show();
        }

        private void currentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserInfo currentUserInfoForm = new UserInfo(UserSession.PersonId);
            currentUserInfoForm.Show();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            UsersList usersListForm = new UsersList();
            usersListForm.Show();
        }

        private void manaeApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageApplicationTypes manageApplicationForm = new ManageApplicationTypes();
            manageApplicationForm.Show();

        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageTestTypes manageTestTypesForm = new ManageTestTypes();
            manageTestTypesForm.Show();
        }

        private void relacmentForToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReplacementforLostorDamagedLicenseProcess replacementforLostorDamagedLicenseProcessForm = new ReplacementforLostorDamagedLicenseProcess();
            replacementforLostorDamagedLicenseProcessForm.Show();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewLocalDrivingLicenseApplications newLocalDrivingLicenseApplicationsForm = new NewLocalDrivingLicenseApplications();
            newLocalDrivingLicenseApplicationsForm.Show();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalDrivingLicenseApplictions localDrivingLicenseApplictionsForm = new LocalDrivingLicenseApplictions();
            localDrivingLicenseApplictionsForm.Show();
        }

        private void btnDrivers_Click(object sender, EventArgs e)
        {
            ManageDrivers manageDriversForm = new ManageDrivers();
            manageDriversForm.Show();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InternationalLicenseApplicatinos internationalLicenseApplicatinosForm = new InternationalLicenseApplicatinos();
            internationalLicenseApplicatinosForm.Show();
        }

        private void internationalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InternationalLicenseApplicatinos internationalLicenseApplicatinosForm = new InternationalLicenseApplicatinos();
            internationalLicenseApplicatinosForm.Show();
        }

        private void renewDrivengLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenewLocalDrivingLicense renwLocalDrivingLicenseForm = new RenewLocalDrivingLicense();
            renwLocalDrivingLicenseForm.Show();
        }

        private void manageDetaindLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListDetainLicenses listDetainLicensesForm = new ListDetainLicenses();
            listDetainLicensesForm.Show();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetainLicense detainLicenseForm = new DetainLicense();
            detainLicenseForm.Show();
        }

        private void releaseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleaseLicense releaseLicenseForm = new ReleaseLicense();
            releaseLicenseForm.Show();
        }
    }
}

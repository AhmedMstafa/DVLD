using Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD
{
    public partial class InternationalLicenseApplicatinos : Form
    {
        private DataTable dtApplications;
        private DataView dvApplications;

        public InternationalLicenseApplicatinos()
        {
            InitializeComponent();

            this.Load += InternationalLicenseApplicatinos_Load;
            btnAddNew.Click += btnAddNew_Click;
            btnClose.Click += btnClose_Click;
            txtSearch.TextChanged += txtSearch_TextChanged;
            cbFilter.SelectedIndexChanged += cbFilter_SelectedIndexChanged;
            showPersonDetailsToolStripMenuItem.Click += showPersonDetailsToolStripMenuItem_Click;
            showLicenseDetailsToolStripMenuItem.Click += showLicenseDetailsToolStripMenuItem_Click;
            showPersonLicenseHistoryToolStripMenuItem.Click += showPersonLicenseHistoryToolStripMenuItem_Click;
        }

        private void InternationalLicenseApplicatinos_Load(object sender, EventArgs e)
        {
            _RefreshList();
        }

        private void _RefreshList()
        {
            dtApplications = InternationalLicenseBusiness.GetAllInternationalLicenseApplications();
            dvApplications = new DataView(dtApplications);
            dgvInternationalLicenseList.DataSource = dvApplications;

            _FillFilterComboBox();
        }

        private void _FillFilterComboBox()
        {
            cbFilter.Items.Clear();
            cbFilter.Items.Add("None");
            foreach (DataColumn col in dtApplications.Columns)
                cbFilter.Items.Add(col.ColumnName);
            cbFilter.SelectedIndex = 0;
        }

        private void _ApplyFilter()
        {
            if (dvApplications == null) return;

            if (cbFilter.SelectedItem == null || cbFilter.SelectedItem.ToString() == "None")
            {
                dvApplications.RowFilter = "";
                return;
            }

            string column = cbFilter.SelectedItem.ToString();
            string value = txtSearch.Text.Replace("'", "''");

            if (string.IsNullOrEmpty(value))
            {
                dvApplications.RowFilter = "";
                return;
            }

            if (dtApplications.Columns[column].DataType == typeof(int) || dtApplications.Columns[column].DataType == typeof(long))
            {
                if (int.TryParse(value, out int numValue))
                    dvApplications.RowFilter = $"[{column}] = {numValue}";
                else
                    dvApplications.RowFilter = "1=0";
            }
            else
            {
                dvApplications.RowFilter = $"[{column}] LIKE '%{value}%'";
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e) => _ApplyFilter();
        private void txtSearch_TextChanged(object sender, EventArgs e) => _ApplyFilter();

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            InternationalDriverLicense addForm = new InternationalDriverLicense();
            addForm.ShowDialog();
            _RefreshList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvInternationalLicenseList.CurrentRow == null) return;
            int driverId = (int)dgvInternationalLicenseList.CurrentRow.Cells["DriverID"].Value;
            int personId = DriverBusiness.GetPersonIdByDriverId(driverId);
            new UserInfo(personId).Show();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvInternationalLicenseList.CurrentRow == null) return;
            int intlLicenseId = (int)dgvInternationalLicenseList.CurrentRow.Cells["Intl License ID"].Value;
            new InternationalDriverInfo(intlLicenseId).ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvInternationalLicenseList.CurrentRow == null) return;
            int driverId = (int)dgvInternationalLicenseList.CurrentRow.Cells["DriverID"].Value;
            int personId = DriverBusiness.GetPersonIdByDriverId(driverId);
            new LicenseHistory(personId).ShowDialog();
        }
    }
}
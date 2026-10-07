using Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ListDetainLicenses : Form
    {
        private DataTable dtDetained;
        private DataView dvDetained;

        public ListDetainLicenses()
        {
            InitializeComponent();

            this.Load += ListDetainLicenses_Load;
            button1.Click += (s, e) => this.Close();
            txtSearch.TextChanged += txtSearch_TextChanged;
            cbFilter.SelectedIndexChanged += cbFilter_SelectedIndexChanged;

            showLicenseDetailsToolStripMenuItem.Click += showLicenseDetailsToolStripMenuItem_Click;
            showPersonDetailsToolStripMenuItem.Click += showPersonDetailsToolStripMenuItem_Click;
            showToolStripMenuItem.Click += showToolStripMenuItem_Click;
        }

        private void ListDetainLicenses_Load(object sender, EventArgs e)
        {
            _RefreshList();
        }

        private void _RefreshList()
        {
            dtDetained = DetainedLicenseBusiness.GetAllDetainedLicenses();
            dvDetained = new DataView(dtDetained);
            dgvUsersList.DataSource = dvDetained;

            _FillFilterComboBox();
        }

        private void _FillFilterComboBox()
        {
            cbFilter.Items.Clear();
            cbFilter.Items.Add("None");
            foreach (DataColumn col in dtDetained.Columns)
                cbFilter.Items.Add(col.ColumnName);
            cbFilter.SelectedIndex = 0;
        }

        private void _ApplyFilter()
        {
            if (dvDetained == null) return;

            if (cbFilter.SelectedItem == null || cbFilter.SelectedItem.ToString() == "None")
            {
                dvDetained.RowFilter = "";
                return;
            }

            string column = cbFilter.SelectedItem.ToString();
            string value = txtSearch.Text.Replace("'", "''");

            if (string.IsNullOrEmpty(value))
            {
                dvDetained.RowFilter = "";
                return;
            }

            if (dtDetained.Columns[column].DataType == typeof(int) || dtDetained.Columns[column].DataType == typeof(long))
            {
                if (int.TryParse(value, out int numValue))
                    dvDetained.RowFilter = $"[{column}] = {numValue}";
                else
                    dvDetained.RowFilter = "1=0";
            }
            else
            {
                dvDetained.RowFilter = $"[{column}] LIKE '%{value}%'";
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e) => _ApplyFilter();
        private void txtSearch_TextChanged(object sender, EventArgs e) => _ApplyFilter();

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsersList.CurrentRow == null) return;
            int licenseId = (int)dgvUsersList.CurrentRow.Cells["L.ID"].Value;

            var license = LicenseBusiness.FindByLicenseID(licenseId);
            if (license == null) return;

            new LicenseInfo(license.ApplicationID).ShowDialog();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsersList.CurrentRow == null) return;
            int licenseId = (int)dgvUsersList.CurrentRow.Cells["L.ID"].Value;

            var license = LicenseBusiness.FindByLicenseID(licenseId);
            if (license == null) return;

            int personId = DriverBusiness.GetPersonIdByDriverId(license.DriverID);
            new UserInfo(personId).Show();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsersList.CurrentRow == null) return;
            int licenseId = (int)dgvUsersList.CurrentRow.Cells["L.ID"].Value;

            var license = LicenseBusiness.FindByLicenseID(licenseId);
            if (license == null) return;

            int personId = DriverBusiness.GetPersonIdByDriverId(license.DriverID);
            new LicenseHistory(personId).ShowDialog();
        }

     
    }
}
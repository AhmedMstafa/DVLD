using Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ManageDrivers : Form
    {
        private DataTable dtDrivers;
        private DataView dvDrivers;

        public ManageDrivers()
        {
            InitializeComponent();

            btnClose.Click += btnClose_Click;
            txtSearch.TextChanged += txtSearch_TextChanged;
            cbFilter.SelectedIndexChanged += cbFilter_SelectedIndexChanged;
        }

        private void ManageDrivers_Load(object sender, EventArgs e)
        {
            _RefreshDriversList();
        }

        private void _RefreshDriversList()
        {
            dtDrivers = DriverBusiness.GetAllDrivers();
            dvDrivers = new DataView(dtDrivers);
            dgvDriversList.DataSource = dvDrivers;

            _FillFilterComboBox();
        }

        private void _FillFilterComboBox()
        {
            cbFilter.Items.Clear();
            cbFilter.Items.Add("None");

            foreach (DataColumn col in dtDrivers.Columns)
                cbFilter.Items.Add(col.ColumnName);

            cbFilter.SelectedIndex = 0;
        }

        private void _ApplyFilter()
        {
            if (dvDrivers == null) return;

            if (cbFilter.SelectedItem == null || cbFilter.SelectedItem.ToString() == "None")
            {
                dvDrivers.RowFilter = "";
                return;
            }

            string column = cbFilter.SelectedItem.ToString();
            string value = txtSearch.Text.Replace("'", "''");

            if (string.IsNullOrEmpty(value))
            {
                dvDrivers.RowFilter = "";
                return;
            }

            if (dtDrivers.Columns[column].DataType == typeof(int) ||
                dtDrivers.Columns[column].DataType == typeof(long))
            {
                if (int.TryParse(value, out int numValue))
                    dvDrivers.RowFilter = $"[{column}] = {numValue}";
                else
                    dvDrivers.RowFilter = "1=0";
            }
            else
            {
                dvDrivers.RowFilter = $"[{column}] LIKE '%{value}%'";
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e) => _ApplyFilter();
        private void txtSearch_TextChanged(object sender, EventArgs e) => _ApplyFilter();

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
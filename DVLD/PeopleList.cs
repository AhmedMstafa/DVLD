using Business;
using System.Data;

namespace DVLD
{
    public partial class PeopleList : Form
    {
        private DataTable dtPeople;
        private DataView dvPeople;

        public PeopleList()
        {
            InitializeComponent();
        }

        private void _RefreshPeopleList()
        {
            dtPeople = PeopleBusiness.GetAllPeople();
            dvPeople = new DataView(dtPeople);
            dgvUsersList.DataSource = dvPeople;

            _FillFilterComboBox();
        }

        private void _FillFilterComboBox()
        {
            cbFilter.Items.Clear();
            cbFilter.Items.Add("None");

            foreach (DataColumn col in dtPeople.Columns)
            {
                cbFilter.Items.Add(col.ColumnName);
            }

            cbFilter.SelectedIndex = 0;
        }

        private void _ApplyFilter()
        {
            if (dvPeople == null) return;

            if (cbFilter.SelectedItem == null || cbFilter.SelectedItem.ToString() == "None")
            {
                dvPeople.RowFilter = "";
                return;
            }

            string column = cbFilter.SelectedItem.ToString();
            string value = txtSearch.Text.Replace("'", "''");

            if (string.IsNullOrEmpty(value))
            {
                dvPeople.RowFilter = "";
                return;
            }

            if (dtPeople.Columns[column].DataType == typeof(int) ||
                dtPeople.Columns[column].DataType == typeof(long))
            {
                if (int.TryParse(value, out int numValue))
                    dvPeople.RowFilter = $"[{column}] = {numValue}";
                else
                    dvPeople.RowFilter = "1=0";
            }
            else
            {
                dvPeople.RowFilter = $"[{column}] LIKE '%{value}%'";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _ApplyFilter();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete " + dgvUsersList.CurrentRow.Cells["FirstName"].Value, "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (PeopleBusiness.DeletePeople((int)dgvUsersList.CurrentRow.Cells["PersonID"].Value))
                {
                    MessageBox.Show("Person deleted successfully.");
                    _RefreshPeopleList();
                }
                else
                {
                    MessageBox.Show("Error deleting person.");
                }
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddEditPeople addEditPeople = new AddEditPeople(-1);
            addEditPeople.ShowDialog();
            _RefreshPeopleList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditPeople addEditPeople = new AddEditPeople((int)dgvUsersList.CurrentRow.Cells["PersonID"].Value);
            addEditPeople.ShowDialog();
            _RefreshPeopleList();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonDetails personDetails = new PersonDetails((int)dgvUsersList.CurrentRow.Cells["PersonID"].Value);
            personDetails.ShowDialog();
            _RefreshPeopleList();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditPeople addEditPeople = new AddEditPeople(-1);
            addEditPeople.ShowDialog();
            _RefreshPeopleList();
        }
    }
}
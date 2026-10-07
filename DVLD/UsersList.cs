using Business;
using System.Data;
using System.Windows.Forms;

namespace DVLD
{
    public partial class UsersList : Form
    {
        private DataTable dtUsers;
        private DataView dvUsers;

        public UsersList()
        {
            InitializeComponent();
        }

        private void _RefreshUsersList()
        {
            dtUsers = UserBusiness.GetAllUsers();
            dvUsers = new DataView(dtUsers);
            dgvUsersList.DataSource = dvUsers;

            _FillFilterComboBox();
        }

        private void _FillFilterComboBox()
        {
            cbFilter.Items.Clear();
            cbFilter.Items.Add("None");

            foreach (DataColumn col in dtUsers.Columns)
            {
                cbFilter.Items.Add(col.ColumnName);
            }

            cbFilter.SelectedIndex = 0;
        }

        private void _ApplyFilter()
        {
            if (dvUsers == null) return;

            if (cbFilter.SelectedItem == null || cbFilter.SelectedItem.ToString() == "None")
            {
                dvUsers.RowFilter = "";
                return;
            }

            string column = cbFilter.SelectedItem.ToString();
            string value = txtSearch.Text.Replace("'", "''");

            if (string.IsNullOrEmpty(value))
            {
                dvUsers.RowFilter = "";
                return;
            }

            if (dtUsers.Columns[column].DataType == typeof(int) ||
                dtUsers.Columns[column].DataType == typeof(long))
            {
                if (int.TryParse(value, out int numValue))
                    dvUsers.RowFilter = $"[{column}] = {numValue}";
                else
                    dvUsers.RowFilter = "1=0";
            }
            else if (dtUsers.Columns[column].DataType == typeof(bool))
            {
                if (bool.TryParse(value, out bool boolValue))
                    dvUsers.RowFilter = $"[{column}] = {boolValue}";
                else
                    dvUsers.RowFilter = "1=0";
            }
            else
            {
                dvUsers.RowFilter = $"[{column}] LIKE '%{value}%'";
            }
        }

        private void UsersList_Load(object sender, EventArgs e)
        {
            _RefreshUsersList();
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
            if (dgvUsersList.CurrentRow == null) return;

            if (MessageBox.Show("Are you sure you want to delete " + dgvUsersList.CurrentRow.Cells["UserName"].Value,
                "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int userId = (int)dgvUsersList.CurrentRow.Cells["UserID"].Value;

                if (UserBusiness.DeleteUser(userId))
                {
                    MessageBox.Show("User deleted successfully.");
                    _RefreshUsersList();
                }
                else
                {
                    MessageBox.Show("Error deleting user.");
                }
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddEditUser addEditUser = new AddEditUser();
            addEditUser.ShowDialog();
            _RefreshUsersList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsersList.CurrentRow == null) return;

            int userId = (int)dgvUsersList.CurrentRow.Cells["UserID"].Value;
            AddEditUser addEditUser = new AddEditUser(userId);
            addEditUser.ShowDialog();
            _RefreshUsersList();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditUser addEditUser = new AddEditUser();
            addEditUser.ShowDialog();
            _RefreshUsersList();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personId = (int)dgvUsersList.CurrentRow.Cells["PersonID"].Value;
            UserInfo userInfoForm = new UserInfo(personId);
            userInfoForm.ShowDialog();
            _RefreshUsersList();
        }

        private void btnAddNew_Click_1(object sender, EventArgs e)
        {
            AddEditUser addEditUser = new AddEditUser();
            addEditUser.ShowDialog();
            _RefreshUsersList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
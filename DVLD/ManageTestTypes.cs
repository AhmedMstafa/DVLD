using Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ManageTestTypes : Form
    {
        private DataTable dtTestTypes;

        public ManageTestTypes()
        {
            InitializeComponent();

            btnClose.Click += btnClose_Click;
            editTestTypeToolStripMenuItem.Click += editTestTypeToolStripMenuItem_Click;

            dgvTestTypes.ContextMenuStrip = contextMenuStrip1;
        }

        private void _RefreshTestTypesList()
        {
            dtTestTypes = TestTypeBusiness.GetAllTestTypes();
            dgvTestTypes.DataSource = dtTestTypes;
        }

        private void ManageTestTypes_Load(object sender, EventArgs e)
        {
            _RefreshTestTypesList();
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvTestTypes.CurrentRow == null)
            {
                MessageBox.Show("Please select a test type first");
                return;
            }

            int testTypeId = (int)dgvTestTypes.CurrentRow.Cells["TestTypeID"].Value;

            EditTestTypes editForm = new EditTestTypes(testTypeId);
            editForm.ShowDialog();

            _RefreshTestTypesList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
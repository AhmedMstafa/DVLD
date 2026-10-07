using Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ManageApplicationTypes : Form
    {
        private DataTable dtApplicationTypes;

        public ManageApplicationTypes()
        {
            InitializeComponent();

            this.Load += ManageApplicationTypes_Load;
            btnClose.Click += btnClose_Click;
            editApplicationTypeToolStripMenuItem.Click += editApplicationTypeToolStripMenuItem_Click;
        }

        private void _RefreshApplicationTypesList()
        {
            dtApplicationTypes = ApplicationTypeBusiness.GetAllApplicationTypes();
            dgvApplicationTypes.DataSource = dtApplicationTypes;
        }

        private void ManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreshApplicationTypesList();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvApplicationTypes.CurrentRow == null) return;

            int applicationTypeId = (int)dgvApplicationTypes.CurrentRow.Cells["ApplicationTypeID"].Value;

            EditApplicationType editForm = new EditApplicationType(applicationTypeId);
            editForm.ShowDialog();

            _RefreshApplicationTypesList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
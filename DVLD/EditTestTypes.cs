using Business;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class EditTestTypes : Form
    {
        private int _TestTypeID;
        private TestTypeBusiness _TestType;

        public EditTestTypes(int TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;

            btnSave.Click += btnSave_Click;
            btnClose.Click += btnClose_Click;
        }

        private void EditTestTypes_Load(object sender, EventArgs e)
        {
            _TestType = TestTypeBusiness.Find(_TestTypeID);

            if (_TestType == null)
            {
                MessageBox.Show("Test Type not found");
                this.Close();
                return;
            }

            txtID.Text = _TestType.TestTypeID.ToString();
            txtID.Enabled = false;

            txtTitle.Text = _TestType.TestTypeTitle;
            txtDescription.Text = _TestType.TestTypeDescription;
            txtFees.Text = _TestType.TestTypeFees.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter the title");
                return;
            }

            if (!decimal.TryParse(txtFees.Text.Trim(), out decimal fees) || fees < 0)
            {
                MessageBox.Show("Please enter a valid fee value");
                return;
            }

            _TestType.TestTypeTitle = txtTitle.Text.Trim();
            _TestType.TestTypeDescription = txtDescription.Text.Trim();
            _TestType.TestTypeFees = fees;

            if (_TestType.Save())
            {
                MessageBox.Show("Saved successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("An error occurred while saving");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
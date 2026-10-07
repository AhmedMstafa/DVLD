using Business;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class EditApplicationType : Form
    {
        private int _ApplicationTypeID;
        private ApplicationTypeBusiness _ApplicationType;

        public EditApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = ApplicationTypeID;

            this.Load += EditApplicationType_Load;
            btnSave.Click += btnSave_Click;
            btnClose.Click += btnClose_Click;
        }

        private void EditApplicationType_Load(object sender, EventArgs e)
        {
            _ApplicationType = ApplicationTypeBusiness.Find(_ApplicationTypeID);

            if (_ApplicationType == null)
            {
                MessageBox.Show("Application Type not found");
                this.Close();
                return;
            }

            textBox1.Text = _ApplicationType.ApplicationTypeID.ToString();
            textBox1.Enabled = false;

            textBox2.Text = _ApplicationType.ApplicationTypeTitle;
            textBox3.Text = _ApplicationType.ApplicationFees.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter the title");
                return;
            }

            if (!decimal.TryParse(textBox3.Text.Trim(), out decimal fees) || fees < 0)
            {
                MessageBox.Show("Please enter a valid fee value");
                return;
            }

            _ApplicationType.ApplicationTypeTitle = textBox2.Text.Trim();
            _ApplicationType.ApplicationFees = fees;

            if (_ApplicationType.Save())
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
using Business;
using Common;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class NewLocalDrivingLicenseApplications : Form
    {
        private PeopleBusiness _SelectedPerson;

        public NewLocalDrivingLicenseApplications()
        {
            InitializeComponent();

            btnSearch.Click += btnSearch_Click;
            btmAddNew.Click += btmAddNew_Click;
            btnNext.Click += btnNext_Click;
            btnSave.Click += btnSave_Click;
            btnClose.Click += btnClose_Click;

            this.Load += NewLocalDrivingLicenseApplications_Load;
        }

        private void NewLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _FillFindByComboBox();
            _FillLicenseClassComboBox();
            btnNext.Enabled = false;
        }

        private void _FillFindByComboBox()
        {
            cbFindBy.Items.Clear();
            cbFindBy.Items.Add("Person ID");
            cbFindBy.Items.Add("National No.");
            cbFindBy.SelectedIndex = 0;
        }

        private void _FillLicenseClassComboBox()
        {
            var dt = LicenseClassBusiness.GetAllLicenseClasses();
            cbLicenseClass.DataSource = dt;
            cbLicenseClass.DisplayMember = "ClassName";
            cbLicenseClass.ValueMember = "LicenseClassID";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchValue = txtFindValue.Text.Trim();
            if (string.IsNullOrEmpty(searchValue))
            {
                MessageBox.Show("Please enter a search value");
                return;
            }

            PeopleBusiness person = null;

            if (cbFindBy.SelectedItem?.ToString() == "Person ID")
            {
                if (!int.TryParse(searchValue, out int personId))
                {
                    MessageBox.Show("Please enter a valid number");
                    return;
                }
                person = PeopleBusiness.Find(personId);
            }
            else
            {
                person = PeopleBusiness.FindByNationalNo(searchValue);
            }

            if (person == null)
            {
                MessageBox.Show("No person found with this data");
                return;
            }

            _SelectedPerson = person;
            personInformation1.LoadPerson(person);
            btnNext.Enabled = true;
        }

        private void btmAddNew_Click(object sender, EventArgs e)
        {
            AddEditPeople addEditPeople = new AddEditPeople(-1);
            addEditPeople.PersonSaved += AddEditPeople_PersonSaved;
            addEditPeople.ShowDialog();
        }

        private void AddEditPeople_PersonSaved(PeopleBusiness newPerson)
        {
            _SelectedPerson = newPerson;
            personInformation1.LoadPerson(newPerson);
            btnNext.Enabled = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_SelectedPerson == null)
            {
                MessageBox.Show("Please select or add a person first");
                return;
            }

            _FillApplicationInfoTab();
            tabControl1.SelectedTab = tapApplicationInfo;
        }

        private void _FillApplicationInfoTab()
        {
            lblApplicationID.Text = "[???]";
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblCreatedBy.Text = UserSession.Username;

            if (cbLicenseClass.Items.Count > 0)
                cbLicenseClass.SelectedIndex = 0;

            _UpdateFeesLabel();
            cbLicenseClass.SelectedIndexChanged += (s, e) => _UpdateFeesLabel();
        }

        private void _UpdateFeesLabel()
        {
            var appType = ApplicationTypeBusiness.Find(LocalDrivingLicenseApplicationBusiness.NEW_LOCAL_DL_APPLICATION_TYPE_ID);
            lblApplicationFees.Text = appType != null ? appType.ApplicationFees.ToString() : "0";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_SelectedPerson == null)
            {
                MessageBox.Show("Please select a person first");
                return;
            }

            if (cbLicenseClass.SelectedValue == null)
            {
                MessageBox.Show("Please select a license class");
                return;
            }

            int licenseClassId = (int)cbLicenseClass.SelectedValue;
            decimal fees = decimal.TryParse(lblApplicationFees.Text, out decimal f) ? f : 0;

            int newAppId = LocalDrivingLicenseApplicationBusiness.AddNewLocalDrivingLicenseApplication(
                _SelectedPerson.ID,
                licenseClassId,
                fees,
                UserSession.UserId,
                out string errorMessage);

            if (newAppId <= 0)
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Application created successfully");
            lblApplicationID.Text = newAppId.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
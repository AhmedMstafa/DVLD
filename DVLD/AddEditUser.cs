using Business;
using Common;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class AddEditUser : Form
    {
        public enum enMode { AddNew = 0, Edit = 1 }
        private enMode _Mode;
        private int _UserID;
        private UserBusiness _User;
        private PeopleBusiness _SelectedPerson;

        public AddEditUser(int UserID = -1)
        {
            InitializeComponent();
            _UserID = UserID;
            _Mode = (UserID == -1) ? enMode.AddNew : enMode.Edit;

            btnSearch.Click += btnSearch_Click;
            btnAddNewUser.Click += btnAddNewUser_Click;
            btnNext.Click += btnNext_Click;
            btnSave.Click += btnSave_Click;
            btnClose.Click += btnClose_Click;
        }

        private void AddEditUser_Load(object sender, EventArgs e)
        {
            _FillFindByComboBox();

            if (_Mode == enMode.AddNew)
            {
                _User = new UserBusiness();
                label2.Text = "Add New User";
                btnNext.Enabled = false;
            }
            else
            {
                _User = UserBusiness.Find(_UserID);

                if (_User == null)
                {
                    MessageBox.Show("User not found");
                    this.Close();
                    return;
                }

                label2.Text = "Edit User";

                _SelectedPerson = PeopleBusiness.Find(_User.PersonID);
                if (_SelectedPerson != null)
                {
                    personInformation1.LoadPerson(_SelectedPerson);
                }

                _FillLoginInfo();
                btnNext.Enabled = true;
            }
        }

        private void _FillFindByComboBox()
        {
            cbFindBy.Items.Clear();
            cbFindBy.Items.Add("Person ID");
            cbFindBy.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtFindValue.Text.Trim(), out int personId))
            {
                MessageBox.Show("Please enter a valid number");
                return;
            }

            PeopleBusiness person = PeopleBusiness.Find(personId);

            if (person == null)
            {
                MessageBox.Show("No person found with this ID");
                return;
            }

            _SelectedPerson = person;
            personInformation1.LoadPerson(person);
            btnNext.Enabled = true;
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
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

            _FillLoginInfo();
            tabLoginInfo.SelectedTab = tabPage2;
        }

        private void _FillLoginInfo()
        {
            label1.Text = "User ID : " + (_User != null && _User.UserID > 0 ? _User.UserID.ToString() : "???");

            if (_User != null)
            {
                txtUserName.Text = _User.UserName;
                txtPassword.Text = _User.Password;
                txtConfirmPassword.Text = _User.Password;
                chkIsActive.Checked = _User.IsActive;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_SelectedPerson == null)
            {
                MessageBox.Show("Please select a person first");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill in all fields");
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Password does not match");
                return;
            }

            if (_User == null)
                _User = new UserBusiness();

            _User.PersonID = _SelectedPerson.ID;
            _User.UserName = txtUserName.Text.Trim();
            _User.Password = txtPassword.Text;
            _User.IsActive = chkIsActive.Checked;

            if (_User.Save())
            {
                MessageBox.Show("Saved successfully");
                this.DialogResult = DialogResult.OK;
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
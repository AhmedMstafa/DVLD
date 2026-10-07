using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace DVLD
{
    public partial class AddEditPeople : Form
    {
        public enum enMode { AddNew = 0, Edit = 1 };
        private enMode _Mode;
        int _ID;

        PeopleBusiness _Person;

        public event Action<PeopleBusiness> PersonSaved;

        private readonly string _ImagesFolder = @"C:\DVLD\Images";

        public AddEditPeople(int ID)
        {
            InitializeComponent();
            _ID = ID;

            if (ID == -1)
            {
                _Mode = enMode.AddNew;
            }
            else
            {
                _Mode = enMode.Edit;
            }
        }

        private int _GetSelectedGender()
        {
            return rdMail.Checked ? 0 : 1;
        }

        private void _LoadData()
        {
            _FillCountiesComboBox();
            comboBox1.SelectedIndex = 0;

            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Person";
                _Person = new PeopleBusiness();
                return;
            }
            _Person = PeopleBusiness.Find(_ID);

            if (_Person == null)
            {
                MessageBox.Show("Person not found");
                this.Close();
                return;
            }

            lblMode.Text = "Edit Person ID : " + _ID;
            lblContactID.Text = "Contact ID : " + _ID;
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalNo.Text = _Person.NationalNo;
            txtEmail.Text = _Person.Email;
            txtPhone.Text = _Person.Phone;
            txtAddress.Text = _Person.Address;
            dtpDateOfBirth.Value = _Person.DateOfBirth;

            if (_Person.Gender == 0)
                rdMail.Checked = true;
            else
                rdFemale.Checked = true;

            if (!string.IsNullOrEmpty(_Person.ImagePath) && File.Exists(_Person.ImagePath))
            {
                pictureBox1.Load(_Person.ImagePath);
            }

            var currentCountry = CountryBusiness.Find((int)_Person.NationalityCountryID);
            if (currentCountry != null)
            {
                comboBox1.SelectedIndex = comboBox1.FindString(currentCountry.CountryName);
            }
        }

        private string _SaveImageToDisk(string sourceFilePath)
        {
            try
            {
                if (!Directory.Exists(_ImagesFolder))
                {
                    Directory.CreateDirectory(_ImagesFolder);
                }

                if (!string.IsNullOrEmpty(_Person.ImagePath) && File.Exists(_Person.ImagePath))
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Warning: Could not delete old image.\n" + ex.Message);
                    }
                }

                string extension = Path.GetExtension(sourceFilePath);
                string newFileName = Guid.NewGuid().ToString() + extension;
                string destinationPath = Path.Combine(_ImagesFolder, newFileName);

                File.Copy(sourceFilePath, destinationPath, true);

                return destinationPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving image: " + ex.Message);
                return "";
            }
        }

        private bool _ValidateForm()
        {
            errorProvider1.Clear();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                errorProvider1.SetError(txtFirstName, "First name is required");
                isValid = false;
            }
            else if (txtFirstName.Text.Trim().Length < 2)
            {
                errorProvider1.SetError(txtFirstName, "First name must be at least 2 characters");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtSecondName.Text))
            {
                errorProvider1.SetError(txtSecondName, "Second name is required");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                errorProvider1.SetError(txtLastName, "Last name is required");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtNationalNo.Text))
            {
                errorProvider1.SetError(txtNationalNo, "National number is required");
                isValid = false;
            }
            else if (!Regex.IsMatch(txtNationalNo.Text.Trim(), @"^\d{14}$"))
            {
                errorProvider1.SetError(txtNationalNo, "National number must be 14 digits");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Email is required");
                isValid = false;
            }
            else if (!Regex.IsMatch(txtEmail.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errorProvider1.SetError(txtEmail, "Invalid email format");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                errorProvider1.SetError(txtPhone, "Phone number is required");
                isValid = false;
            }
            else if (!Regex.IsMatch(txtPhone.Text.Trim(), @"^01[0-2,5]{1}[0-9]{8}$"))
            {
                errorProvider1.SetError(txtPhone, "Invalid phone number format");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                errorProvider1.SetError(txtAddress, "Address is required");
                isValid = false;
            }

            if (dtpDateOfBirth.Value.Date > DateTime.Now.Date)
            {
                errorProvider1.SetError(dtpDateOfBirth, "Date of birth cannot be in the future");
                isValid = false;
            }
            else
            {
                int age = DateTime.Now.Year - dtpDateOfBirth.Value.Year;
                if (dtpDateOfBirth.Value.Date > DateTime.Now.AddYears(-age)) age--;

                if (age < 18)
                {
                    errorProvider1.SetError(dtpDateOfBirth, "Person must be at least 18 years old");
                    isValid = false;
                }
            }

            if (comboBox1.SelectedItem == null)
            {
                errorProvider1.SetError(comboBox1, "Please select a country");
                isValid = false;
            }

            return isValid;
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
        }

        private void AddEditPeople_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _FillCountiesComboBox()
        {
            DataTable dtCountries = CountryBusiness.GetAllCountries();

            foreach (DataRow dr in dtCountries.Rows)
            {
                comboBox1.Items.Add(dr["CountryName"]);
            }
        }

        private void bntSave_Click(object sender, EventArgs e)
        {
            if (!_ValidateForm())
            {
                MessageBox.Show("Please fix the errors before saving.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var country = CountryBusiness.Find(comboBox1.SelectedItem.ToString());
            if (country == null)
            {
                MessageBox.Show("Selected country not found");
                return;
            }

            int NationalityCountryID = country.CountryID;

            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.NationalNo = txtNationalNo.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.NationalityCountryID = NationalityCountryID;
            _Person.Gender = _GetSelectedGender();

            

            if (_Person.Save())
            {
                MessageBox.Show("Person saved successfully");

                PersonSaved?.Invoke(_Person);

                this.Close();
            }
            else
            {
                MessageBox.Show("Error saving person");
                this.Close();
            }

            _Mode = enMode.Edit;
            lblMode.Text = "Edit Person ID : " + _Person.ID;
            lblContactID.Text = "Contact ID : " + _Person.ID;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;

                string savedPath = _SaveImageToDisk(selectedFilePath);

                if (!string.IsNullOrEmpty(savedPath))
                {
                    pictureBox1.Load(savedPath);
                    _Person.ImagePath = savedPath;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Business;

namespace DVLD
{
    public partial class PersonInformation : UserControl
    {
        private PeopleBusiness _Person;
        public PeopleBusiness CurrentPerson => _Person;
        public PersonInformation()
        {
            InitializeComponent();
        }

        public PersonInformation(PeopleBusiness Person) : this()
        {
            _Person = Person;
            _LoadPersonData();
        }

        public void LoadPerson(PeopleBusiness Person)
        {
            _Person = Person;
            _LoadPersonData();
        }

        private void _LoadPersonData()
        {
            if (_Person == null) return;

            txtPersonID.Text = _Person.ID.ToString();
            txtNationalNo.Text = _Person.NationalNo;
            txtName.Text = $"{_Person.FirstName} {_Person.SecondName} {_Person.ThirdName} {_Person.LastName}".Trim();
            txtDateOfBith.Text = _Person.DateOfBirth.ToString("dd/MM/yyyy");
            txtGender.Text = _Person.Gender == 0 ? "Male" : "Female";
            txtAddress.Text = _Person.Address;
            txtPhone.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;

            var country = CountryBusiness.Find((int)_Person.NationalityCountryID);
            txtContry.Text = country != null ? country.CountryName : "N/A";

            if (!string.IsNullOrEmpty(_Person.ImagePath) && File.Exists(_Person.ImagePath))
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(_Person.ImagePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}");
                }
            }
        }

        private void PersonDetails_Load(object sender, EventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddEditPeople addEditPeople = new AddEditPeople((int)_Person.ID);
            addEditPeople.ShowDialog();
        }
    }
}
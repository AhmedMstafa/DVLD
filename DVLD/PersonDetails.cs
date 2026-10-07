using Business;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class PersonDetails : Form
    {
        private int _PersonID;

        public PersonDetails()
        {
            InitializeComponent();
        }

        public PersonDetails(int PersonID) : this()
        {
            _PersonID = PersonID;
        }

        private void PersonDetails_Load(object sender, EventArgs e)
        {
            PeopleBusiness selectedPerson = PeopleBusiness.Find(_PersonID);

            if (selectedPerson == null)
            {
                MessageBox.Show("Person not found");
                this.Close();
                return;
            }

            
            personInformationControl.LoadPerson(selectedPerson);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void personInformationControl_Load(object sender, EventArgs e)
        {

        }
    }
}
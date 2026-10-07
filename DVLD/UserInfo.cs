using Business;
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD
{
    public partial class UserInfo : Form
    {
        private int _PersonId;

        public UserInfo(int PersonId)
        {
            InitializeComponent();
            _PersonId = PersonId;
        }
        private void UserInfo_Load(object sender, EventArgs e)
        {
            PeopleBusiness selectedPerson = PeopleBusiness.Find(_PersonId);

            if (selectedPerson == null)
            {
                MessageBox.Show("Person not found");
                this.Close();
                return;
            }


            personInformation1.LoadPerson(selectedPerson);

            txtUserId.Text = UserSession.UserId.ToString();
            txtUserName.Text = UserSession.Username.ToString();
            txtIsActive.Text = UserSession.IsActive ? "Yes" : "No";
        }

        private void txtUserId_Click(object sender, EventArgs e)
        {

        }

        private void personInformation1_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserInfo_Load_1(object sender, EventArgs e)
        {

        }
    }
}

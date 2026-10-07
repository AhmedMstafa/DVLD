using Common;
using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DVLD
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

            var saved = RememberMeHelper.Load();
            if (saved.HasValue)
            {
                txtUsername.Text = saved.Value.username;
                txtPassword.Text = saved.Value.password;
                chkRememberMe.Checked = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool success = UserBusiness.Login(txtUsername.Text.Trim(), txtPassword.Text, out string errorMessage);

            if (!success)
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (chkRememberMe.Checked)
                RememberMeHelper.Save(txtUsername.Text.Trim(), txtPassword.Text);
            else
                RememberMeHelper.Clear();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

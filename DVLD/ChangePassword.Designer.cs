namespace DVLD
{
    partial class ChangePassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            personInformation1 = new PersonInformation();
            txtOldPassword = new TextBox();
            txtConfirmNewPassword = new TextBox();
            txtNewPassword = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // personInformation1
            // 
            personInformation1.Location = new Point(1, 3);
            personInformation1.Name = "personInformation1";
            personInformation1.Size = new Size(819, 295);
            personInformation1.TabIndex = 0;
            // 
            // txtOldPassword
            // 
            txtOldPassword.Location = new Point(23, 331);
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.PlaceholderText = "Old Password";
            txtOldPassword.Size = new Size(220, 23);
            txtOldPassword.TabIndex = 1;
            // 
            // txtConfirmNewPassword
            // 
            txtConfirmNewPassword.Location = new Point(23, 433);
            txtConfirmNewPassword.Name = "txtConfirmNewPassword";
            txtConfirmNewPassword.PlaceholderText = "Confirm New Password";
            txtConfirmNewPassword.Size = new Size(220, 23);
            txtConfirmNewPassword.TabIndex = 2;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(23, 378);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PlaceholderText = "New Password";
            txtNewPassword.Size = new Size(220, 23);
            txtNewPassword.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(281, 433);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(693, 432);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Close";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // ChangePassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(819, 492);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtNewPassword);
            Controls.Add(txtConfirmNewPassword);
            Controls.Add(txtOldPassword);
            Controls.Add(personInformation1);
            Name = "ChangePassword";
            Text = "ChangePassword";
            Load += ChangePassword_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PersonInformation personInformation1;
        private TextBox txtOldPassword;
        private TextBox txtConfirmNewPassword;
        private TextBox txtNewPassword;
        private Button btnSave;
        private Button btnCancel;
    }
}
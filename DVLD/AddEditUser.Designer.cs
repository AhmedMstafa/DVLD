namespace DVLD
{
    partial class AddEditUser
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
            label2 = new Label();
            tabLoginInfo = new TabControl();
            tabPersonalInfo = new TabPage();
            btnNext = new Button();
            btnAddNewUser = new Button();
            groupBox1 = new GroupBox();
            btnSearch = new Button();
            txtFindValue = new TextBox();
            cbFindBy = new ComboBox();
            label3 = new Label();
            personInformation1 = new PersonInformation();
            tabPage2 = new TabPage();
            chkIsActive = new CheckBox();
            txtConfirmPassword = new TextBox();
            txtPassword = new TextBox();
            txtUserName = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            btnClose = new Button();
            btnSave = new Button();
            tabLoginInfo.SuspendLayout();
            tabPersonalInfo.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(317, 19);
            label2.Name = "label2";
            label2.Size = new Size(200, 37);
            label2.TabIndex = 1;
            label2.Text = "Add New User";
            // 
            // tabLoginInfo
            // 
            tabLoginInfo.Controls.Add(tabPersonalInfo);
            tabLoginInfo.Controls.Add(tabPage2);
            tabLoginInfo.Location = new Point(0, 70);
            tabLoginInfo.Name = "tabLoginInfo";
            tabLoginInfo.SelectedIndex = 0;
            tabLoginInfo.Size = new Size(834, 482);
            tabLoginInfo.TabIndex = 2;
            // 
            // tabPersonalInfo
            // 
            tabPersonalInfo.Controls.Add(btnNext);
            tabPersonalInfo.Controls.Add(btnAddNewUser);
            tabPersonalInfo.Controls.Add(groupBox1);
            tabPersonalInfo.Controls.Add(personInformation1);
            tabPersonalInfo.Location = new Point(4, 24);
            tabPersonalInfo.Name = "tabPersonalInfo";
            tabPersonalInfo.Padding = new Padding(3);
            tabPersonalInfo.Size = new Size(826, 454);
            tabPersonalInfo.TabIndex = 0;
            tabPersonalInfo.Text = "Person Info";
            tabPersonalInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(739, 425);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(75, 23);
            btnNext.TabIndex = 5;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            // 
            // btnAddNewUser
            // 
            btnAddNewUser.Location = new Point(739, 43);
            btnAddNewUser.Name = "btnAddNewUser";
            btnAddNewUser.Size = new Size(75, 23);
            btnAddNewUser.TabIndex = 4;
            btnAddNewUser.Text = "Add New";
            btnAddNewUser.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(txtFindValue);
            groupBox1.Controls.Add(cbFindBy);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(6, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(601, 81);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filter";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(506, 37);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtFindValue
            // 
            txtFindValue.Location = new Point(269, 36);
            txtFindValue.Name = "txtFindValue";
            txtFindValue.Size = new Size(206, 23);
            txtFindValue.TabIndex = 2;
            // 
            // cbFindBy
            // 
            cbFindBy.FormattingEnabled = true;
            cbFindBy.Location = new Point(79, 36);
            cbFindBy.Name = "cbFindBy";
            cbFindBy.Size = new Size(167, 23);
            cbFindBy.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 37);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 0;
            label3.Text = "Filter By :";
            // 
            // personInformation1
            // 
            personInformation1.Location = new Point(0, 93);
            personInformation1.Name = "personInformation1";
            personInformation1.Size = new Size(814, 301);
            personInformation1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(chkIsActive);
            tabPage2.Controls.Add(txtConfirmPassword);
            tabPage2.Controls.Add(txtPassword);
            tabPage2.Controls.Add(txtUserName);
            tabPage2.Controls.Add(label6);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(826, 454);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Login Info";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.CheckAlign = ContentAlignment.MiddleRight;
            chkIsActive.Location = new Point(39, 249);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(160, 19);
            chkIsActive.TabIndex = 7;
            chkIsActive.Text = "Is Active :                            ";
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(186, 189);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(100, 23);
            txtConfirmPassword.TabIndex = 6;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(186, 138);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 5;
            txtPassword.TextChanged += textBox2_TextChanged;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(186, 93);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(100, 23);
            txtUserName.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(39, 197);
            label6.Name = "label6";
            label6.Size = new Size(110, 15);
            label6.TabIndex = 3;
            label6.Text = "Confirm Password :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(39, 141);
            label5.Name = "label5";
            label5.Size = new Size(66, 15);
            label5.TabIndex = 2;
            label5.Text = "Password : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(39, 96);
            label4.Name = "label4";
            label4.Size = new Size(71, 15);
            label4.TabIndex = 1;
            label4.Text = "User Name :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 54);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 0;
            label1.Text = "User ID : ";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(643, 558);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(749, 558);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // AddEditUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(836, 591);
            Controls.Add(btnSave);
            Controls.Add(btnClose);
            Controls.Add(tabLoginInfo);
            Controls.Add(label2);
            Name = "AddEditUser";
            Text = "AddEditUser";
            Load += AddEditUser_Load;
            tabLoginInfo.ResumeLayout(false);
            tabPersonalInfo.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TabControl tabLoginInfo;
        private TabPage tabPersonalInfo;
        private TabPage tabPage2;
        private GroupBox groupBox1;
        private ComboBox cbFindBy;
        private Label label3;
        private PersonInformation personInformation1;
        private Button btnAddNewUser;
        private Button btnSearch;
        private TextBox txtFindValue;
        private Button btnNext;
        private TextBox txtConfirmPassword;
        private TextBox txtPassword;
        private TextBox txtUserName;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label1;
        private Button btnClose;
        private Button btnSave;
        private CheckBox chkIsActive;
    }
}
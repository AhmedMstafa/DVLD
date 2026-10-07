namespace DVLD
{
    partial class NewLocalDrivingLicenseApplications
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
            label1 = new Label();
            tabControl1 = new TabControl();
            tapPersonInfo = new TabPage();
            btmAddNew = new Button();
            groupBox1 = new GroupBox();
            btnSearch = new Button();
            txtFindValue = new TextBox();
            cbFindBy = new ComboBox();
            label3 = new Label();
            btnNext = new Button();
            personInformation1 = new PersonInformation();
            tapApplicationInfo = new TabPage();
            cbLicenseClass = new ComboBox();
            lblCreatedBy = new Label();
            lblApplicationFees = new Label();
            lblApplicationDate = new Label();
            lblApplicationID = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            btnClose = new Button();
            btnSave = new Button();
            tabControl1.SuspendLayout();
            tapPersonInfo.SuspendLayout();
            groupBox1.SuspendLayout();
            tapApplicationInfo.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(143, 34);
            label1.Name = "label1";
            label1.Size = new Size(540, 40);
            label1.TabIndex = 0;
            label1.Text = "New Local Driving License Application";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tapPersonInfo);
            tabControl1.Controls.Add(tapApplicationInfo);
            tabControl1.Location = new Point(0, 89);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(834, 450);
            tabControl1.TabIndex = 1;
            // 
            // tapPersonInfo
            // 
            tapPersonInfo.Controls.Add(btmAddNew);
            tapPersonInfo.Controls.Add(groupBox1);
            tapPersonInfo.Controls.Add(btnNext);
            tapPersonInfo.Controls.Add(personInformation1);
            tapPersonInfo.Location = new Point(4, 24);
            tapPersonInfo.Name = "tapPersonInfo";
            tapPersonInfo.Padding = new Padding(3);
            tapPersonInfo.Size = new Size(826, 422);
            tapPersonInfo.TabIndex = 0;
            tapPersonInfo.Text = "Person Info";
            tapPersonInfo.UseVisualStyleBackColor = true;
            // 
            // btmAddNew
            // 
            btmAddNew.Location = new Point(734, 30);
            btmAddNew.Name = "btmAddNew";
            btmAddNew.Size = new Size(75, 23);
            btmAddNew.TabIndex = 3;
            btmAddNew.Text = "Add New";
            btmAddNew.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(txtFindValue);
            groupBox1.Controls.Add(cbFindBy);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(8, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(601, 65);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filter";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(507, 28);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtFindValue
            // 
            txtFindValue.Location = new Point(270, 27);
            txtFindValue.Name = "txtFindValue";
            txtFindValue.Size = new Size(206, 23);
            txtFindValue.TabIndex = 2;
            // 
            // cbFindBy
            // 
            cbFindBy.FormattingEnabled = true;
            cbFindBy.Location = new Point(80, 27);
            cbFindBy.Name = "cbFindBy";
            cbFindBy.Size = new Size(167, 23);
            cbFindBy.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 28);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 0;
            label3.Text = "Filter By :";
            // 
            // btnNext
            // 
            btnNext.Location = new Point(745, 393);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(75, 23);
            btnNext.TabIndex = 1;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            // 
            // personInformation1
            // 
            personInformation1.Location = new Point(6, 72);
            personInformation1.Name = "personInformation1";
            personInformation1.Size = new Size(814, 317);
            personInformation1.TabIndex = 0;
            // 
            // tapApplicationInfo
            // 
            tapApplicationInfo.Controls.Add(cbLicenseClass);
            tapApplicationInfo.Controls.Add(lblCreatedBy);
            tapApplicationInfo.Controls.Add(lblApplicationFees);
            tapApplicationInfo.Controls.Add(lblApplicationDate);
            tapApplicationInfo.Controls.Add(lblApplicationID);
            tapApplicationInfo.Controls.Add(label7);
            tapApplicationInfo.Controls.Add(label6);
            tapApplicationInfo.Controls.Add(label5);
            tapApplicationInfo.Controls.Add(label4);
            tapApplicationInfo.Controls.Add(label2);
            tapApplicationInfo.Location = new Point(4, 24);
            tapApplicationInfo.Name = "tapApplicationInfo";
            tapApplicationInfo.Padding = new Padding(3);
            tapApplicationInfo.Size = new Size(826, 422);
            tapApplicationInfo.TabIndex = 1;
            tapApplicationInfo.Text = "Application Info";
            tapApplicationInfo.UseVisualStyleBackColor = true;
            // 
            // cbLicenseClass
            // 
            cbLicenseClass.FormattingEnabled = true;
            cbLicenseClass.Location = new Point(169, 122);
            cbLicenseClass.Name = "cbLicenseClass";
            cbLicenseClass.Size = new Size(213, 23);
            cbLicenseClass.TabIndex = 10;
            // 
            // lblCreatedBy
            // 
            lblCreatedBy.AutoSize = true;
            lblCreatedBy.Location = new Point(169, 213);
            lblCreatedBy.Name = "lblCreatedBy";
            lblCreatedBy.Size = new Size(30, 15);
            lblCreatedBy.TabIndex = 9;
            lblCreatedBy.Text = "[???]";
            // 
            // lblApplicationFees
            // 
            lblApplicationFees.AutoSize = true;
            lblApplicationFees.Location = new Point(169, 172);
            lblApplicationFees.Name = "lblApplicationFees";
            lblApplicationFees.Size = new Size(30, 15);
            lblApplicationFees.TabIndex = 8;
            lblApplicationFees.Text = "[???]";
            // 
            // lblApplicationDate
            // 
            lblApplicationDate.AutoSize = true;
            lblApplicationDate.Location = new Point(169, 84);
            lblApplicationDate.Name = "lblApplicationDate";
            lblApplicationDate.Size = new Size(30, 15);
            lblApplicationDate.TabIndex = 6;
            lblApplicationDate.Text = "[???]";
            // 
            // lblApplicationID
            // 
            lblApplicationID.AutoSize = true;
            lblApplicationID.Location = new Point(169, 45);
            lblApplicationID.Name = "lblApplicationID";
            lblApplicationID.Size = new Size(30, 15);
            lblApplicationID.TabIndex = 5;
            lblApplicationID.Text = "[???]";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label7.Location = new Point(37, 213);
            label7.Name = "label7";
            label7.Size = new Size(72, 15);
            label7.TabIndex = 4;
            label7.Text = "Created By : ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label6.Location = new Point(41, 172);
            label6.Name = "label6";
            label6.Size = new Size(103, 15);
            label6.TabIndex = 3;
            label6.Text = "Application Fees : ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label5.Location = new Point(41, 130);
            label5.Name = "label5";
            label5.Size = new Size(84, 15);
            label5.TabIndex = 2;
            label5.Text = "License Class : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label4.Location = new Point(37, 84);
            label4.Name = "label4";
            label4.Size = new Size(105, 15);
            label4.TabIndex = 1;
            label4.Text = "Application Date : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label2.Location = new Point(37, 45);
            label2.Name = "label2";
            label2.Size = new Size(110, 15);
            label2.TabIndex = 0;
            label2.Text = "D.L Application ID :";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(646, 555);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(760, 555);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // NewLocalDrivingLicenseApplications
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 590);
            Controls.Add(btnSave);
            Controls.Add(btnClose);
            Controls.Add(tabControl1);
            Controls.Add(label1);
            Name = "NewLocalDrivingLicenseApplications";
            Text = "NewLocalDrivingLicenseApplications";
            Load += NewLocalDrivingLicenseApplications_Load;
            tabControl1.ResumeLayout(false);
            tapPersonInfo.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tapApplicationInfo.ResumeLayout(false);
            tapApplicationInfo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TabControl tabControl1;
        private TabPage tapPersonInfo;
        private TabPage tapApplicationInfo;
        private Button btnClose;
        private Button btnSave;
        private Button btnNext;
        private PersonInformation personInformation1;
        private GroupBox groupBox1;
        private Button btnSearch;
        private TextBox txtFindValue;
        private ComboBox cbFindBy;
        private Label label3;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label2;
        private ComboBox cbLicenseClass;
        private Label lblCreatedBy;
        private Label lblApplicationFees;
        private Label lblApplicationDate;
        private Label lblApplicationID;
        private Button btmAddNew;
    }
}
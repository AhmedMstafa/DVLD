namespace DVLD
{
    partial class MainScreen
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
            components = new System.ComponentModel.Container();
            btnApplications = new Button();
            ctxApplications = new ContextMenuStrip(components);
            appToolStripMenuItem = new ToolStripMenuItem();
            newDrivengLicenseToolStripMenuItem = new ToolStripMenuItem();
            localLicenseToolStripMenuItem = new ToolStripMenuItem();
            internationalLicenseToolStripMenuItem = new ToolStripMenuItem();
            renewDrivengLicenseToolStripMenuItem = new ToolStripMenuItem();
            relacmentForToolStripMenuItem = new ToolStripMenuItem();
            releaseDentintDrivingLicenseToolStripMenuItem = new ToolStripMenuItem();
            retakeTestToolStripMenuItem = new ToolStripMenuItem();
            manageApplicationsToolStripMenuItem = new ToolStripMenuItem();
            localDrivingLicenseApplicationsToolStripMenuItem = new ToolStripMenuItem();
            internationalDrivingLicenseApplicationsToolStripMenuItem = new ToolStripMenuItem();
            detalnLicenesesToolStripMenuItem = new ToolStripMenuItem();
            manageDetaindLicenseToolStripMenuItem = new ToolStripMenuItem();
            detainLicenseToolStripMenuItem = new ToolStripMenuItem();
            releaseLicenseToolStripMenuItem = new ToolStripMenuItem();
            manaeApplicationTypesToolStripMenuItem = new ToolStripMenuItem();
            manageTestTypesToolStripMenuItem = new ToolStripMenuItem();
            btnPoeple = new Button();
            ctxPeople = new ContextMenuStrip(components);
            btnDrivers = new Button();
            ctxDrivers = new ContextMenuStrip(components);
            btnUsers = new Button();
            btnAccountSettings = new Button();
            ctxAccountSettings = new ContextMenuStrip(components);
            currentToolStripMenuItem = new ToolStripMenuItem();
            changePasswordToolStripMenuItem = new ToolStripMenuItem();
            signOutToolStripMenuItem = new ToolStripMenuItem();
            ctxUsers = new ContextMenuStrip(components);
            ctxApplications.SuspendLayout();
            ctxAccountSettings.SuspendLayout();
            SuspendLayout();
            // 
            // btnApplications
            // 
            btnApplications.ContextMenuStrip = ctxApplications;
            btnApplications.FlatStyle = FlatStyle.Popup;
            btnApplications.Location = new Point(1, 1);
            btnApplications.Name = "btnApplications";
            btnApplications.Size = new Size(92, 24);
            btnApplications.TabIndex = 0;
            btnApplications.Text = "Applications";
            btnApplications.UseVisualStyleBackColor = true;
            btnApplications.Click += button1_Click;
            // 
            // ctxApplications
            // 
            ctxApplications.Items.AddRange(new ToolStripItem[] { appToolStripMenuItem, manageApplicationsToolStripMenuItem, detalnLicenesesToolStripMenuItem, manaeApplicationTypesToolStripMenuItem, manageTestTypesToolStripMenuItem });
            ctxApplications.Name = "ctxApplications";
            ctxApplications.Size = new Size(207, 114);
            ctxApplications.Text = "Applications";
            // 
            // appToolStripMenuItem
            // 
            appToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newDrivengLicenseToolStripMenuItem, renewDrivengLicenseToolStripMenuItem, relacmentForToolStripMenuItem, releaseDentintDrivingLicenseToolStripMenuItem, retakeTestToolStripMenuItem });
            appToolStripMenuItem.Name = "appToolStripMenuItem";
            appToolStripMenuItem.Size = new Size(206, 22);
            appToolStripMenuItem.Text = "Driving Licenses Services";
            // 
            // newDrivengLicenseToolStripMenuItem
            // 
            newDrivengLicenseToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { localLicenseToolStripMenuItem, internationalLicenseToolStripMenuItem });
            newDrivengLicenseToolStripMenuItem.Name = "newDrivengLicenseToolStripMenuItem";
            newDrivengLicenseToolStripMenuItem.Size = new Size(334, 22);
            newDrivengLicenseToolStripMenuItem.Text = "New Driveng License";
            // 
            // localLicenseToolStripMenuItem
            // 
            localLicenseToolStripMenuItem.Name = "localLicenseToolStripMenuItem";
            localLicenseToolStripMenuItem.Size = new Size(183, 22);
            localLicenseToolStripMenuItem.Text = "Local License";
            localLicenseToolStripMenuItem.Click += localLicenseToolStripMenuItem_Click;
            // 
            // internationalLicenseToolStripMenuItem
            // 
            internationalLicenseToolStripMenuItem.Name = "internationalLicenseToolStripMenuItem";
            internationalLicenseToolStripMenuItem.Size = new Size(183, 22);
            internationalLicenseToolStripMenuItem.Text = "International License";
            internationalLicenseToolStripMenuItem.Click += internationalLicenseToolStripMenuItem_Click;
            // 
            // renewDrivengLicenseToolStripMenuItem
            // 
            renewDrivengLicenseToolStripMenuItem.Name = "renewDrivengLicenseToolStripMenuItem";
            renewDrivengLicenseToolStripMenuItem.Size = new Size(334, 22);
            renewDrivengLicenseToolStripMenuItem.Text = "Renew Driveng License";
            renewDrivengLicenseToolStripMenuItem.Click += renewDrivengLicenseToolStripMenuItem_Click;
            // 
            // relacmentForToolStripMenuItem
            // 
            relacmentForToolStripMenuItem.Name = "relacmentForToolStripMenuItem";
            relacmentForToolStripMenuItem.Size = new Size(334, 22);
            relacmentForToolStripMenuItem.Text = "Replacement For Damege Or Lost Driving License";
            relacmentForToolStripMenuItem.Click += relacmentForToolStripMenuItem_Click;
            // 
            // releaseDentintDrivingLicenseToolStripMenuItem
            // 
            releaseDentintDrivingLicenseToolStripMenuItem.Name = "releaseDentintDrivingLicenseToolStripMenuItem";
            releaseDentintDrivingLicenseToolStripMenuItem.Size = new Size(334, 22);
            releaseDentintDrivingLicenseToolStripMenuItem.Text = "Release Dentained Driving License";
            // 
            // retakeTestToolStripMenuItem
            // 
            retakeTestToolStripMenuItem.Name = "retakeTestToolStripMenuItem";
            retakeTestToolStripMenuItem.Size = new Size(334, 22);
            retakeTestToolStripMenuItem.Text = "Retake Test";
            // 
            // manageApplicationsToolStripMenuItem
            // 
            manageApplicationsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { localDrivingLicenseApplicationsToolStripMenuItem, internationalDrivingLicenseApplicationsToolStripMenuItem });
            manageApplicationsToolStripMenuItem.Name = "manageApplicationsToolStripMenuItem";
            manageApplicationsToolStripMenuItem.Size = new Size(206, 22);
            manageApplicationsToolStripMenuItem.Text = "Manage Applications";
            // 
            // localDrivingLicenseApplicationsToolStripMenuItem
            // 
            localDrivingLicenseApplicationsToolStripMenuItem.Name = "localDrivingLicenseApplicationsToolStripMenuItem";
            localDrivingLicenseApplicationsToolStripMenuItem.Size = new Size(293, 22);
            localDrivingLicenseApplicationsToolStripMenuItem.Text = "Local Driving License Applications";
            localDrivingLicenseApplicationsToolStripMenuItem.Click += localDrivingLicenseApplicationsToolStripMenuItem_Click;
            // 
            // internationalDrivingLicenseApplicationsToolStripMenuItem
            // 
            internationalDrivingLicenseApplicationsToolStripMenuItem.Name = "internationalDrivingLicenseApplicationsToolStripMenuItem";
            internationalDrivingLicenseApplicationsToolStripMenuItem.Size = new Size(293, 22);
            internationalDrivingLicenseApplicationsToolStripMenuItem.Text = "International Driving License Applications";
            internationalDrivingLicenseApplicationsToolStripMenuItem.Click += internationalDrivingLicenseApplicationsToolStripMenuItem_Click;
            // 
            // detalnLicenesesToolStripMenuItem
            // 
            detalnLicenesesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { manageDetaindLicenseToolStripMenuItem, detainLicenseToolStripMenuItem, releaseLicenseToolStripMenuItem });
            detalnLicenesesToolStripMenuItem.Name = "detalnLicenesesToolStripMenuItem";
            detalnLicenesesToolStripMenuItem.Size = new Size(206, 22);
            detalnLicenesesToolStripMenuItem.Text = "Detaln Liceneses";
            // 
            // manageDetaindLicenseToolStripMenuItem
            // 
            manageDetaindLicenseToolStripMenuItem.Name = "manageDetaindLicenseToolStripMenuItem";
            manageDetaindLicenseToolStripMenuItem.Size = new Size(203, 22);
            manageDetaindLicenseToolStripMenuItem.Text = "Manage Detaind License";
            manageDetaindLicenseToolStripMenuItem.Click += manageDetaindLicenseToolStripMenuItem_Click;
            // 
            // detainLicenseToolStripMenuItem
            // 
            detainLicenseToolStripMenuItem.Name = "detainLicenseToolStripMenuItem";
            detainLicenseToolStripMenuItem.Size = new Size(203, 22);
            detainLicenseToolStripMenuItem.Text = "Detain License";
            detainLicenseToolStripMenuItem.Click += detainLicenseToolStripMenuItem_Click;
            // 
            // releaseLicenseToolStripMenuItem
            // 
            releaseLicenseToolStripMenuItem.Name = "releaseLicenseToolStripMenuItem";
            releaseLicenseToolStripMenuItem.Size = new Size(203, 22);
            releaseLicenseToolStripMenuItem.Text = "Release License";
            releaseLicenseToolStripMenuItem.Click += releaseLicenseToolStripMenuItem_Click;
            // 
            // manaeApplicationTypesToolStripMenuItem
            // 
            manaeApplicationTypesToolStripMenuItem.Name = "manaeApplicationTypesToolStripMenuItem";
            manaeApplicationTypesToolStripMenuItem.Size = new Size(206, 22);
            manaeApplicationTypesToolStripMenuItem.Text = "Manae Application Types";
            manaeApplicationTypesToolStripMenuItem.Click += manaeApplicationTypesToolStripMenuItem_Click;
            // 
            // manageTestTypesToolStripMenuItem
            // 
            manageTestTypesToolStripMenuItem.Name = "manageTestTypesToolStripMenuItem";
            manageTestTypesToolStripMenuItem.Size = new Size(206, 22);
            manageTestTypesToolStripMenuItem.Text = "Manage Test Types";
            manageTestTypesToolStripMenuItem.Click += manageTestTypesToolStripMenuItem_Click;
            // 
            // btnPoeple
            // 
            btnPoeple.ContextMenuStrip = ctxPeople;
            btnPoeple.FlatStyle = FlatStyle.Popup;
            btnPoeple.Location = new Point(117, 1);
            btnPoeple.Name = "btnPoeple";
            btnPoeple.Size = new Size(92, 24);
            btnPoeple.TabIndex = 1;
            btnPoeple.Text = "People";
            btnPoeple.UseVisualStyleBackColor = true;
            btnPoeple.Click += btnPoeple_Click;
            // 
            // ctxPeople
            // 
            ctxPeople.Name = "ctxPeople";
            ctxPeople.Size = new Size(61, 4);
            // 
            // btnDrivers
            // 
            btnDrivers.ContextMenuStrip = ctxDrivers;
            btnDrivers.FlatStyle = FlatStyle.Popup;
            btnDrivers.Location = new Point(233, 1);
            btnDrivers.Name = "btnDrivers";
            btnDrivers.Size = new Size(92, 24);
            btnDrivers.TabIndex = 2;
            btnDrivers.Text = "Drivers";
            btnDrivers.UseVisualStyleBackColor = true;
            btnDrivers.Click += btnDrivers_Click;
            // 
            // ctxDrivers
            // 
            ctxDrivers.Name = "ctxDrivers";
            ctxDrivers.Size = new Size(61, 4);
            // 
            // btnUsers
            // 
            btnUsers.ContextMenuStrip = ctxPeople;
            btnUsers.FlatStyle = FlatStyle.Popup;
            btnUsers.Location = new Point(350, 1);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(92, 24);
            btnUsers.TabIndex = 3;
            btnUsers.Text = "Users";
            btnUsers.UseVisualStyleBackColor = true;
            btnUsers.Click += btnUsers_Click;
            // 
            // btnAccountSettings
            // 
            btnAccountSettings.ContextMenuStrip = ctxAccountSettings;
            btnAccountSettings.FlatStyle = FlatStyle.Popup;
            btnAccountSettings.Location = new Point(467, 1);
            btnAccountSettings.Name = "btnAccountSettings";
            btnAccountSettings.Size = new Size(121, 24);
            btnAccountSettings.TabIndex = 4;
            btnAccountSettings.Text = "Account Settings";
            btnAccountSettings.UseVisualStyleBackColor = true;
            btnAccountSettings.Click += btnAccountSettings_Click;
            // 
            // ctxAccountSettings
            // 
            ctxAccountSettings.Items.AddRange(new ToolStripItem[] { currentToolStripMenuItem, changePasswordToolStripMenuItem, signOutToolStripMenuItem });
            ctxAccountSettings.Name = "ctxAccountSettings";
            ctxAccountSettings.Size = new Size(169, 70);
            // 
            // currentToolStripMenuItem
            // 
            currentToolStripMenuItem.Name = "currentToolStripMenuItem";
            currentToolStripMenuItem.Size = new Size(168, 22);
            currentToolStripMenuItem.Text = "Current User Info";
            currentToolStripMenuItem.Click += currentToolStripMenuItem_Click;
            // 
            // changePasswordToolStripMenuItem
            // 
            changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            changePasswordToolStripMenuItem.Size = new Size(168, 22);
            changePasswordToolStripMenuItem.Text = "Change Password";
            changePasswordToolStripMenuItem.Click += changePasswordToolStripMenuItem_Click_1;
            // 
            // signOutToolStripMenuItem
            // 
            signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            signOutToolStripMenuItem.Size = new Size(168, 22);
            signOutToolStripMenuItem.Text = "Sign Out";
            signOutToolStripMenuItem.Click += signOutToolStripMenuItem_Click;
            // 
            // ctxUsers
            // 
            ctxUsers.Name = "ctxUsers";
            ctxUsers.Size = new Size(61, 4);
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAccountSettings);
            Controls.Add(btnUsers);
            Controls.Add(btnDrivers);
            Controls.Add(btnPoeple);
            Controls.Add(btnApplications);
            ForeColor = SystemColors.ControlText;
            Name = "MainScreen";
            Text = "MainScreen";
            Load += MainScreen_Load;
            ctxApplications.ResumeLayout(false);
            ctxAccountSettings.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnApplications;
        private ContextMenuStrip ctxApplications;
        private ToolStripMenuItem appToolStripMenuItem;
        private Button btnPoeple;
        private Button btnDrivers;
        private Button btnUsers;
        private Button btnAccountSettings;
        private ContextMenuStrip ctxPeople;
        private ContextMenuStrip ctxDrivers;
        private ContextMenuStrip ctxAccountSettings;
        private ContextMenuStrip ctxUsers;
        private ToolStripMenuItem currentToolStripMenuItem;
        private ToolStripMenuItem changePasswordToolStripMenuItem;
        private ToolStripMenuItem signOutToolStripMenuItem;
        private ToolStripMenuItem manageApplicationsToolStripMenuItem;
        private ToolStripMenuItem detalnLicenesesToolStripMenuItem;
        private ToolStripMenuItem manaeApplicationTypesToolStripMenuItem;
        private ToolStripMenuItem manageTestTypesToolStripMenuItem;
        private ToolStripMenuItem newDrivengLicenseToolStripMenuItem;
        private ToolStripMenuItem renewDrivengLicenseToolStripMenuItem;
        private ToolStripMenuItem relacmentForToolStripMenuItem;
        private ToolStripMenuItem localLicenseToolStripMenuItem;
        private ToolStripMenuItem internationalLicenseToolStripMenuItem;
        private ToolStripMenuItem releaseDentintDrivingLicenseToolStripMenuItem;
        private ToolStripMenuItem retakeTestToolStripMenuItem;
        private ToolStripMenuItem localDrivingLicenseApplicationsToolStripMenuItem;
        private ToolStripMenuItem internationalDrivingLicenseApplicationsToolStripMenuItem;
        private ToolStripMenuItem manageDetaindLicenseToolStripMenuItem;
        private ToolStripMenuItem detainLicenseToolStripMenuItem;
        private ToolStripMenuItem releaseLicenseToolStripMenuItem;
    }
}
namespace DVLD
{
    partial class InternationalDriverLicense
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
            llShowLicenseHistory = new LinkLabel();
            llShowLicenseInfo = new LinkLabel();
            drivingLicenseInfo1 = new DrivingLicenseInfo();
            btnClose = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(192, 20);
            label1.Name = "label1";
            label1.Size = new Size(397, 40);
            label1.TabIndex = 0;
            label1.Text = "International Driver License";
            // 
            // llShowLicenseHistory
            // 
            llShowLicenseHistory.AutoSize = true;
            llShowLicenseHistory.Location = new Point(12, 664);
            llShowLicenseHistory.Name = "llShowLicenseHistory";
            llShowLicenseHistory.Size = new Size(119, 15);
            llShowLicenseHistory.TabIndex = 2;
            llShowLicenseHistory.TabStop = true;
            llShowLicenseHistory.Text = "Show License History";
            // 
            // llShowLicenseInfo
            // 
            llShowLicenseInfo.AutoSize = true;
            llShowLicenseInfo.Location = new Point(171, 664);
            llShowLicenseInfo.Name = "llShowLicenseInfo";
            llShowLicenseInfo.Size = new Size(102, 15);
            llShowLicenseInfo.TabIndex = 3;
            llShowLicenseInfo.TabStop = true;
            llShowLicenseInfo.Text = "Show License Info";
            // 
            // drivingLicenseInfo1
            // 
            drivingLicenseInfo1.Location = new Point(12, 63);
            drivingLicenseInfo1.Name = "drivingLicenseInfo1";
            drivingLicenseInfo1.Size = new Size(686, 582);
            drivingLicenseInfo1.TabIndex = 4;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(524, 664);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 5;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(623, 664);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click_1;
            // 
            // InternationalDriverLicense
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(705, 703);
            Controls.Add(btnSave);
            Controls.Add(btnClose);
            Controls.Add(drivingLicenseInfo1);
            Controls.Add(llShowLicenseInfo);
            Controls.Add(llShowLicenseHistory);
            Controls.Add(label1);
            Name = "InternationalDriverLicense";
            Text = "InternationalDriverLicense";
            Load += InternationalDriverLicense_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DrivingLicenseInfo internationalDrivingLicenseInfo1;
        private LinkLabel llShowLicenseHistory;
        private LinkLabel llShowLicenseInfo;
        private DrivingLicenseInfo drivingLicenseInfo1;
        private Button btnClose;
        private Button btnSave;
    }
}
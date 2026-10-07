namespace DVLD
{
    partial class InternationalDriverInfo
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
            driverInteranationalLicenseInfo1 = new DriverInteranationalLicenseInfo();
            label1 = new Label();
            btnClose = new Button();
            SuspendLayout();
            // 
            // driverInteranationalLicenseInfo1
            // 
            driverInteranationalLicenseInfo1.Location = new Point(10, 66);
            driverInteranationalLicenseInfo1.Name = "driverInteranationalLicenseInfo1";
            driverInteranationalLicenseInfo1.Size = new Size(715, 264);
            driverInteranationalLicenseInfo1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(147, 9);
            label1.Name = "label1";
            label1.Size = new Size(461, 40);
            label1.TabIndex = 1;
            label1.Text = "International Driver License Info";
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Microsoft Sans Serif", 8.25F);
            btnClose.Location = new Point(645, 337);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // InternationalDriverInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(732, 372);
            Controls.Add(btnClose);
            Controls.Add(label1);
            Controls.Add(driverInteranationalLicenseInfo1);
            Name = "InternationalDriverInfo";
            Text = "InternationalDriverInfo";
            Load += InternationalDriverInfo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DriverInteranationalLicenseInfo driverInteranationalLicenseInfo1;
        private Label label1;
        private Button btnClose;
    }
}
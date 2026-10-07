namespace DVLD
{
    partial class IssueDriverLicenseForFirstTime
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
            textBox1 = new TextBox();
            btnSave = new Button();
            btnClose = new Button();
            applicationInfo1 = new ApplicationInfo();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 413);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 1;
            label1.Text = "Notes : ";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(87, 413);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(534, 75);
            textBox1.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(546, 511);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(435, 511);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 4;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // applicationInfo1
            // 
            applicationInfo1.Location = new Point(5, 12);
            applicationInfo1.Name = "applicationInfo1";
            applicationInfo1.Size = new Size(644, 387);
            applicationInfo1.TabIndex = 5;
            // 
            // IssueDriverLicenseForFirstTime
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(661, 544);
            Controls.Add(applicationInfo1);
            Controls.Add(btnClose);
            Controls.Add(btnSave);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "IssueDriverLicenseForFirstTime";
            Text = "IssueDriverLicenseForFirstTime";
            Load += IssueDriverLicenseForFirstTime_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button btnSave;
        private Button btnClose;
        private ApplicationInfo applicationInfo1;
    }
}
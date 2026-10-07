namespace DVLD
{
    partial class LicenseHistory
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
            personInformation1 = new PersonInformation();
            tabControl1 = new TabControl();
            tb = new TabPage();
            tabPage2 = new TabPage();
            dtInternationalLicense = new DataGridView();
            dtLocalLicense = new DataGridView();
            btnClose = new Button();
            tabControl1.SuspendLayout();
            tb.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtInternationalLicense).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtLocalLicense).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(297, 27);
            label1.Name = "label1";
            label1.Size = new Size(226, 40);
            label1.TabIndex = 0;
            label1.Text = "License History";
            // 
            // personInformation1
            // 
            personInformation1.Location = new Point(11, 89);
            personInformation1.Name = "personInformation1";
            personInformation1.Size = new Size(814, 317);
            personInformation1.TabIndex = 1;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tb);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 429);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(813, 169);
            tabControl1.TabIndex = 2;
            // 
            // tb
            // 
            tb.Controls.Add(dtLocalLicense);
            tb.Location = new Point(4, 24);
            tb.Name = "tb";
            tb.Padding = new Padding(3);
            tb.Size = new Size(805, 141);
            tb.TabIndex = 0;
            tb.Text = "Local";
            tb.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dtInternationalLicense);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(805, 141);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "International";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dtInternationalLicense
            // 
            dtInternationalLicense.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtInternationalLicense.Location = new Point(6, 10);
            dtInternationalLicense.Name = "dtInternationalLicense";
            dtInternationalLicense.Size = new Size(793, 125);
            dtInternationalLicense.TabIndex = 0;
            // 
            // dtLocalLicense
            // 
            dtLocalLicense.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtLocalLicense.Location = new Point(8, 9);
            dtLocalLicense.Name = "dtLocalLicense";
            dtLocalLicense.Size = new Size(791, 126);
            dtLocalLicense.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(746, 610);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // LicenseHistory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(846, 645);
            Controls.Add(btnClose);
            Controls.Add(tabControl1);
            Controls.Add(personInformation1);
            Controls.Add(label1);
            Name = "LicenseHistory";
            Text = "LicenseHistory";
            Load += LicenseHistory_Load;
            tabControl1.ResumeLayout(false);
            tb.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dtInternationalLicense).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtLocalLicense).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PersonInformation personInformation1;
        private TabControl tabControl1;
        private TabPage tb;
        private TabPage tabPage2;
        private DataGridView dtLocalLicense;
        private DataGridView dtInternationalLicense;
        private Button btnClose;
    }
}
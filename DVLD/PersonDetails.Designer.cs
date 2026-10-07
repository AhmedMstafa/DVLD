namespace DVLD
{
    partial class PersonDetails
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
            personInformationControl = new PersonInformation();
            btnClose = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // personInformationControl
            // 
            personInformationControl.Location = new Point(3, 39);
            personInformationControl.Name = "personInformationControl";
            personInformationControl.Size = new Size(863, 292);
            personInformationControl.TabIndex = 2;
            personInformationControl.Load += personInformationControl_Load;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(778, 337);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(88, 33);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.Popup;
            label2.Font = new Font("Sitka Small", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Crimson;
            label2.Location = new Point(277, -1);
            label2.Name = "label2";
            label2.Size = new Size(300, 48);
            label2.TabIndex = 4;
            label2.Text = "Personal Details";
            // 
            // PersonDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(867, 374);
            Controls.Add(label2);
            Controls.Add(btnClose);
            Controls.Add(personInformationControl);
            Name = "PersonDetails";
            Text = "PersonDetails";
            Load += PersonDetails_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private PersonInformation personInformationControl;
        private Button btnClose;
        private Label label2;
    }
}
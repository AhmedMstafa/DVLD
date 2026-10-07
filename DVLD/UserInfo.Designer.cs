namespace DVLD
{
    partial class UserInfo
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
            groupBox1 = new GroupBox();
            txtIsActive = new Label();
            txtUserName = new Label();
            txtUserId = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnCancel = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // personInformation1
            // 
            personInformation1.Location = new Point(3, 3);
            personInformation1.Name = "personInformation1";
            personInformation1.Size = new Size(814, 296);
            personInformation1.TabIndex = 0;
            personInformation1.Load += personInformation1_Load;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtIsActive);
            groupBox1.Controls.Add(txtUserName);
            groupBox1.Controls.Add(txtUserId);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(3, 326);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(814, 61);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Login Information";
            // 
            // txtIsActive
            // 
            txtIsActive.AutoSize = true;
            txtIsActive.Location = new Point(719, 25);
            txtIsActive.Name = "txtIsActive";
            txtIsActive.Size = new Size(19, 15);
            txtIsActive.TabIndex = 5;
            txtIsActive.Text = "....";
            // 
            // txtUserName
            // 
            txtUserName.AutoSize = true;
            txtUserName.Location = new Point(442, 25);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(19, 15);
            txtUserName.TabIndex = 4;
            txtUserName.Text = "....";
            // 
            // txtUserId
            // 
            txtUserId.AutoSize = true;
            txtUserId.Location = new Point(203, 25);
            txtUserId.Name = "txtUserId";
            txtUserId.Size = new Size(19, 15);
            txtUserId.TabIndex = 3;
            txtUserId.Text = "....";
            txtUserId.Click += txtUserId_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(362, 25);
            label3.Name = "label3";
            label3.Size = new Size(74, 15);
            label3.TabIndex = 2;
            label3.Text = "User Name : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(653, 25);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 1;
            label2.Text = "Is Active : ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(144, 25);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 0;
            label1.Text = "User ID : ";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(719, 408);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Close";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // UserInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(821, 450);
            Controls.Add(btnCancel);
            Controls.Add(groupBox1);
            Controls.Add(personInformation1);
            Name = "UserInfo";
            Text = "UserInfo";
            Load += UserInfo_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PersonInformation personInformation1;
        private GroupBox groupBox1;
        private Label txtUserId;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label txtIsActive;
        private Label txtUserName;
        private Button btnCancel;
    }
}
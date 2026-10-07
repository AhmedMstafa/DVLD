namespace DVLD
{
    partial class EditTestTypes
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtID = new TextBox();
            txtTitle = new TextBox();
            txtDescription = new TextBox();
            txtFees = new TextBox();
            btnClose = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(128, 25);
            label1.Name = "label1";
            label1.Size = new Size(205, 40);
            label1.TabIndex = 0;
            label1.Text = "Edit Test Type";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 8.25F);
            label2.Location = new Point(47, 142);
            label2.Name = "label2";
            label2.Size = new Size(36, 13);
            label2.TabIndex = 1;
            label2.Text = "Title : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 8.25F);
            label3.Location = new Point(44, 189);
            label3.Name = "label3";
            label3.Size = new Size(69, 13);
            label3.TabIndex = 2;
            label3.Text = "Description : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 8.25F);
            label4.Location = new Point(44, 258);
            label4.Name = "label4";
            label4.Size = new Size(39, 13);
            label4.TabIndex = 3;
            label4.Text = "Fees : ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 8.25F);
            label5.Location = new Point(47, 96);
            label5.Name = "label5";
            label5.Size = new Size(27, 13);
            label5.TabIndex = 4;
            label5.Text = "ID : ";
            // 
            // txtID
            // 
            txtID.Location = new Point(142, 92);
            txtID.Name = "txtID";
            txtID.Size = new Size(191, 23);
            txtID.TabIndex = 5;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(142, 132);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(191, 23);
            txtTitle.TabIndex = 6;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(142, 185);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(191, 49);
            txtDescription.TabIndex = 7;
            // 
            // txtFees
            // 
            txtFees.Location = new Point(142, 254);
            txtFees.Name = "txtFees";
            txtFees.Size = new Size(191, 23);
            txtFees.TabIndex = 8;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(142, 342);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 9;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(258, 342);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // EditTestTypes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 390);
            Controls.Add(btnSave);
            Controls.Add(btnClose);
            Controls.Add(txtFees);
            Controls.Add(txtDescription);
            Controls.Add(txtTitle);
            Controls.Add(txtID);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "EditTestTypes";
            Text = "EditTestTypes";
            Load += EditTestTypes_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtID;
        private TextBox txtTitle;
        private TextBox txtDescription;
        private TextBox txtFees;
        private Button btnClose;
        private Button btnSave;
    }
}
namespace DVLD
{
    partial class ManageDrivers
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
            txtSearch = new TextBox();
            cbFilter = new ComboBox();
            label2 = new Label();
            dgvDriversList = new DataGridView();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDriversList).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(262, 20);
            label1.Name = "label1";
            label1.Size = new Size(235, 40);
            label1.TabIndex = 0;
            label1.Text = "Manage Drivers";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(211, 82);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(100, 23);
            txtSearch.TabIndex = 10;
            // 
            // cbFilter
            // 
            cbFilter.FormattingEnabled = true;
            cbFilter.Location = new Point(84, 82);
            cbFilter.Name = "cbFilter";
            cbFilter.Size = new Size(121, 23);
            cbFilter.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 88);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 8;
            label2.Text = "Filter By : ";
            // 
            // dgvDriversList
            // 
            dgvDriversList.AllowUserToAddRows = false;
            dgvDriversList.AllowUserToDeleteRows = false;
            dgvDriversList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDriversList.Location = new Point(12, 111);
            dgvDriversList.Name = "dgvDriversList";
            dgvDriversList.ReadOnly = true;
            dgvDriversList.Size = new Size(668, 268);
            dgvDriversList.TabIndex = 6;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(602, 398);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 11;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // ManageDrivers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(689, 434);
            Controls.Add(btnClose);
            Controls.Add(txtSearch);
            Controls.Add(cbFilter);
            Controls.Add(label2);
            Controls.Add(dgvDriversList);
            Controls.Add(label1);
            Name = "ManageDrivers";
            Text = "ManageDrivers";
            Load += ManageDrivers_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDriversList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSearch;
        private ComboBox cbFilter;
        private Label label2;
        protected DataGridView dgvDriversList;
        private Button btnClose;
    }
}
namespace DVLD
{
    partial class InternationalLicenseApplicatinos
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
            label1 = new Label();
            txtSearch = new TextBox();
            cbFilter = new ComboBox();
            label2 = new Label();
            btnAddNew = new Button();
            dgvInternationalLicenseList = new DataGridView();
            btnClose = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            showPersonDetailsToolStripMenuItem = new ToolStripMenuItem();
            showLicenseDetailsToolStripMenuItem = new ToolStripMenuItem();
            showPersonLicenseHistoryToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgvInternationalLicenseList).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(159, 20);
            label1.Name = "label1";
            label1.Size = new Size(482, 40);
            label1.TabIndex = 0;
            label1.Text = "International License Applications";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(201, 74);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(100, 23);
            txtSearch.TabIndex = 10;
            // 
            // cbFilter
            // 
            cbFilter.FormattingEnabled = true;
            cbFilter.Location = new Point(74, 74);
            cbFilter.Name = "cbFilter";
            cbFilter.Size = new Size(121, 23);
            cbFilter.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 80);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 8;
            label2.Text = "Filter By : ";
            // 
            // btnAddNew
            // 
            btnAddNew.Location = new Point(672, 74);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.Size = new Size(116, 23);
            btnAddNew.TabIndex = 7;
            btnAddNew.Text = "Add";
            btnAddNew.UseVisualStyleBackColor = true;
            // 
            // dgvInternationalLicenseList
            // 
            dgvInternationalLicenseList.AllowUserToAddRows = false;
            dgvInternationalLicenseList.AllowUserToDeleteRows = false;
            dgvInternationalLicenseList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInternationalLicenseList.ContextMenuStrip = contextMenuStrip1;
            dgvInternationalLicenseList.Location = new Point(2, 103);
            dgvInternationalLicenseList.Name = "dgvInternationalLicenseList";
            dgvInternationalLicenseList.ReadOnly = true;
            dgvInternationalLicenseList.Size = new Size(786, 269);
            dgvInternationalLicenseList.TabIndex = 6;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(713, 378);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 11;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { showPersonDetailsToolStripMenuItem, showLicenseDetailsToolStripMenuItem, showPersonLicenseHistoryToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(226, 70);
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            showPersonDetailsToolStripMenuItem.Size = new Size(225, 22);
            showPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            // 
            // showLicenseDetailsToolStripMenuItem
            // 
            showLicenseDetailsToolStripMenuItem.Name = "showLicenseDetailsToolStripMenuItem";
            showLicenseDetailsToolStripMenuItem.Size = new Size(225, 22);
            showLicenseDetailsToolStripMenuItem.Text = "Show License Details";
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            showPersonLicenseHistoryToolStripMenuItem.Size = new Size(225, 22);
            showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            // 
            // InternationalLicenseApplicatinos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(792, 406);
            Controls.Add(btnClose);
            Controls.Add(txtSearch);
            Controls.Add(cbFilter);
            Controls.Add(label2);
            Controls.Add(btnAddNew);
            Controls.Add(dgvInternationalLicenseList);
            Controls.Add(label1);
            Name = "InternationalLicenseApplicatinos";
            Text = "InternationalLicenseApplicatinos";
            Load += InternationalLicenseApplicatinos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInternationalLicenseList).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSearch;
        private ComboBox cbFilter;
        private Label label2;
        private Button btnAddNew;
        protected DataGridView dgvInternationalLicenseList;
        private Button btnClose;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private ToolStripMenuItem showLicenseDetailsToolStripMenuItem;
        private ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
    }
}
namespace DVLD
{
    partial class ListDetainLicenses
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
            button1 = new Button();
            label1 = new Label();
            txtSearch = new TextBox();
            cbFilter = new ComboBox();
            dgvUsersList = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            showLicenseDetailsToolStripMenuItem = new ToolStripMenuItem();
            showPersonDetailsToolStripMenuItem = new ToolStripMenuItem();
            showToolStripMenuItem = new ToolStripMenuItem();
            lblMangeUsers = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvUsersList).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(713, 350);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 15;
            button1.Text = "Close";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 136);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 14;
            label1.Text = "Filter By :";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(203, 133);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(100, 23);
            txtSearch.TabIndex = 13;
            // 
            // cbFilter
            // 
            cbFilter.FormattingEnabled = true;
            cbFilter.Location = new Point(72, 133);
            cbFilter.Name = "cbFilter";
            cbFilter.Size = new Size(121, 23);
            cbFilter.TabIndex = 12;
            // 
            // dgvUsersList
            // 
            dgvUsersList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsersList.ContextMenuStrip = contextMenuStrip1;
            dgvUsersList.Location = new Point(3, 162);
            dgvUsersList.Name = "dgvUsersList";
            dgvUsersList.Size = new Size(794, 177);
            dgvUsersList.TabIndex = 10;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { showLicenseDetailsToolStripMenuItem, showPersonDetailsToolStripMenuItem, showToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(184, 70);
            // 
            // showLicenseDetailsToolStripMenuItem
            // 
            showLicenseDetailsToolStripMenuItem.Name = "showLicenseDetailsToolStripMenuItem";
            showLicenseDetailsToolStripMenuItem.Size = new Size(183, 22);
            showLicenseDetailsToolStripMenuItem.Text = "Show License Details";
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            showPersonDetailsToolStripMenuItem.Size = new Size(183, 22);
            showPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            showPersonDetailsToolStripMenuItem.Click += showPersonDetailsToolStripMenuItem_Click;
            // 
            // showToolStripMenuItem
            // 
            showToolStripMenuItem.Name = "showToolStripMenuItem";
            showToolStripMenuItem.Size = new Size(183, 22);
            showToolStripMenuItem.Text = "Show History Details";
            showToolStripMenuItem.Click += showToolStripMenuItem_Click;
            // 
            // lblMangeUsers
            // 
            lblMangeUsers.AutoSize = true;
            lblMangeUsers.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMangeUsers.Location = new Point(248, 37);
            lblMangeUsers.Name = "lblMangeUsers";
            lblMangeUsers.Size = new Size(304, 40);
            lblMangeUsers.TabIndex = 9;
            lblMangeUsers.Text = "List License Detained";
            // 
            // ListDetainLicenses
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 385);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(txtSearch);
            Controls.Add(cbFilter);
            Controls.Add(dgvUsersList);
            Controls.Add(lblMangeUsers);
            Name = "ListDetainLicenses";
            Text = "ListDetainLicenses";
            Load += ListDetainLicenses_Load;
            Click += showLicenseDetailsToolStripMenuItem_Click;
            ((System.ComponentModel.ISupportInitialize)dgvUsersList).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox txtSearch;
        private ComboBox cbFilter;
        private DataGridView dgvUsersList;
        private Label lblMangeUsers;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem showLicenseDetailsToolStripMenuItem;
        private ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private ToolStripMenuItem showToolStripMenuItem;
    }
}
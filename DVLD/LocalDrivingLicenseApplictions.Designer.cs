namespace DVLD
{
    partial class LocalDrivingLicenseApplictions
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
            txtFindValue = new TextBox();
            cbFindBy = new ComboBox();
            label3 = new Label();
            btnNewApplication = new Button();
            dgvApplications = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            showApplicationDetailsToolStripMenuItem = new ToolStripMenuItem();
            editApplicationToolStripMenuItem = new ToolStripMenuItem();
            deleteApplicationToolStripMenuItem = new ToolStripMenuItem();
            cancelApplicationToolStripMenuItem = new ToolStripMenuItem();
            scadualTestToolStripMenuItem = new ToolStripMenuItem();
            sechdulVisionTestToolStripMenuItem = new ToolStripMenuItem();
            sechdulWrittenTestToolStripMenuItem = new ToolStripMenuItem();
            schedulStreetTestToolStripMenuItem = new ToolStripMenuItem();
            issueDrivingLicenseFirstTimeToolStripMenuItem = new ToolStripMenuItem();
            showLicenseToolStripMenuItem = new ToolStripMenuItem();
            showPersonHistoryLToolStripMenuItem = new ToolStripMenuItem();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvApplications).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(168, 30);
            label1.Name = "label1";
            label1.Size = new Size(483, 40);
            label1.TabIndex = 0;
            label1.Text = "Local Driving License Applications";
            // 
            // txtFindValue
            // 
            txtFindValue.Location = new Point(277, 116);
            txtFindValue.Name = "txtFindValue";
            txtFindValue.Size = new Size(206, 23);
            txtFindValue.TabIndex = 5;
            txtFindValue.TextChanged += txtFindValue_TextChanged;
            // 
            // cbFindBy
            // 
            cbFindBy.FormattingEnabled = true;
            cbFindBy.Location = new Point(87, 116);
            cbFindBy.Name = "cbFindBy";
            cbFindBy.Size = new Size(167, 23);
            cbFindBy.TabIndex = 4;
            cbFindBy.SelectedIndexChanged += cbFindBy_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 117);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 3;
            label3.Text = "Filter By :";
            // 
            // btnNewApplication
            // 
            btnNewApplication.Location = new Point(671, 115);
            btnNewApplication.Name = "btnNewApplication";
            btnNewApplication.Size = new Size(117, 23);
            btnNewApplication.TabIndex = 6;
            btnNewApplication.Text = "New Application";
            btnNewApplication.UseVisualStyleBackColor = true;
            btnNewApplication.Click += btnNewApplication_Click;
            // 
            // dgvApplications
            // 
            dgvApplications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvApplications.ContextMenuStrip = contextMenuStrip1;
            dgvApplications.Location = new Point(2, 174);
            dgvApplications.Name = "dgvApplications";
            dgvApplications.Size = new Size(796, 216);
            dgvApplications.TabIndex = 7;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { showApplicationDetailsToolStripMenuItem, editApplicationToolStripMenuItem, deleteApplicationToolStripMenuItem, cancelApplicationToolStripMenuItem, scadualTestToolStripMenuItem, issueDrivingLicenseFirstTimeToolStripMenuItem, showLicenseToolStripMenuItem, showPersonHistoryLToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(246, 202);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            showApplicationDetailsToolStripMenuItem.Size = new Size(245, 22);
            showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            // 
            // editApplicationToolStripMenuItem
            // 
            editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            editApplicationToolStripMenuItem.Size = new Size(245, 22);
            editApplicationToolStripMenuItem.Text = "Edit Application";
            // 
            // deleteApplicationToolStripMenuItem
            // 
            deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            deleteApplicationToolStripMenuItem.Size = new Size(245, 22);
            deleteApplicationToolStripMenuItem.Text = "Delete Application";
            // 
            // cancelApplicationToolStripMenuItem
            // 
            cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            cancelApplicationToolStripMenuItem.Size = new Size(245, 22);
            cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            // 
            // scadualTestToolStripMenuItem
            // 
            scadualTestToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sechdulVisionTestToolStripMenuItem, sechdulWrittenTestToolStripMenuItem, schedulStreetTestToolStripMenuItem });
            scadualTestToolStripMenuItem.Name = "scadualTestToolStripMenuItem";
            scadualTestToolStripMenuItem.Size = new Size(245, 22);
            scadualTestToolStripMenuItem.Text = "Schedul Test";
            // 
            // sechdulVisionTestToolStripMenuItem
            // 
            sechdulVisionTestToolStripMenuItem.Name = "sechdulVisionTestToolStripMenuItem";
            sechdulVisionTestToolStripMenuItem.Size = new Size(181, 22);
            sechdulVisionTestToolStripMenuItem.Text = "Schedul Vision Test";
            sechdulVisionTestToolStripMenuItem.Click += scheduleVisionTestToolStripMenuItem_Click;
            // 
            // sechdulWrittenTestToolStripMenuItem
            // 
            sechdulWrittenTestToolStripMenuItem.Name = "sechdulWrittenTestToolStripMenuItem";
            sechdulWrittenTestToolStripMenuItem.Size = new Size(181, 22);
            sechdulWrittenTestToolStripMenuItem.Text = "Schedul Written Test";
            sechdulWrittenTestToolStripMenuItem.Click += scheduleWrittenTestToolStripMenuItem_Click;
            // 
            // schedulStreetTestToolStripMenuItem
            // 
            schedulStreetTestToolStripMenuItem.Name = "schedulStreetTestToolStripMenuItem";
            schedulStreetTestToolStripMenuItem.Size = new Size(181, 22);
            schedulStreetTestToolStripMenuItem.Text = "Schedul Street Test";
            schedulStreetTestToolStripMenuItem.Click += scheduleStreetTestToolStripMenuItem_Click;
            // 
            // issueDrivingLicenseFirstTimeToolStripMenuItem
            // 
            issueDrivingLicenseFirstTimeToolStripMenuItem.Name = "issueDrivingLicenseFirstTimeToolStripMenuItem";
            issueDrivingLicenseFirstTimeToolStripMenuItem.Size = new Size(245, 22);
            issueDrivingLicenseFirstTimeToolStripMenuItem.Text = "Issue Driving License (First Time)";
            issueDrivingLicenseFirstTimeToolStripMenuItem.Click += issueDrivingLicenseFirstTimeToolStripMenuItem_Click;
            // 
            // showLicenseToolStripMenuItem
            // 
            showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            showLicenseToolStripMenuItem.Size = new Size(245, 22);
            showLicenseToolStripMenuItem.Text = "Show License";
            showLicenseToolStripMenuItem.Click += showLicenseToolStripMenuItem_Click;
            // 
            // showPersonHistoryLToolStripMenuItem
            // 
            showPersonHistoryLToolStripMenuItem.Name = "showPersonHistoryLToolStripMenuItem";
            showPersonHistoryLToolStripMenuItem.Size = new Size(245, 22);
            showPersonHistoryLToolStripMenuItem.Text = "Show Person License History";
            showPersonHistoryLToolStripMenuItem.Click += showPersonHistoryLToolStripMenuItem_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(713, 396);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 8;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // LocalDrivingLicenseApplictions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 424);
            Controls.Add(btnClose);
            Controls.Add(dgvApplications);
            Controls.Add(btnNewApplication);
            Controls.Add(txtFindValue);
            Controls.Add(cbFindBy);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "LocalDrivingLicenseApplictions";
            Text = "LocalDrivingLicenseApplictions";
            Load += LocalDrivingLicenseApplictions_Load;
            ((System.ComponentModel.ISupportInitialize)dgvApplications).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtFindValue;
        private ComboBox cbFindBy;
        private Label label3;
        private Button btnNewApplication;
        private DataGridView dgvApplications;
        private Button btnClose;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private ToolStripMenuItem editApplicationToolStripMenuItem;
        private ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private ToolStripMenuItem scadualTestToolStripMenuItem;
        private ToolStripMenuItem sechdulVisionTestToolStripMenuItem;
        private ToolStripMenuItem sechdulWrittenTestToolStripMenuItem;
        private ToolStripMenuItem schedulStreetTestToolStripMenuItem;
        private ToolStripMenuItem issueDrivingLicenseFirstTimeToolStripMenuItem;
        private ToolStripMenuItem showLicenseToolStripMenuItem;
        private ToolStripMenuItem showPersonHistoryLToolStripMenuItem;
    }
}
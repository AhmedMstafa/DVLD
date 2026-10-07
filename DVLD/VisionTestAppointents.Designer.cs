namespace DVLD
{
    partial class VisionTestAppointents
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
            applicationInfo1 = new ApplicationInfo();
            label2 = new Label();
            btnAddAppointment = new Button();
            btnClose = new Button();
            dtAppointments = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            editToolStripMenuItem = new ToolStripMenuItem();
            tackeToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dtAppointments).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(151, 24);
            label1.Name = "label1";
            label1.Size = new Size(340, 40);
            label1.TabIndex = 0;
            label1.Text = "Vision Test Appointents";
            // 
            // applicationInfo1
            // 
            applicationInfo1.Location = new Point(12, 88);
            applicationInfo1.Name = "applicationInfo1";
            applicationInfo1.Size = new Size(642, 387);
            applicationInfo1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 500);
            label2.Name = "label2";
            label2.Size = new Size(92, 15);
            label2.TabIndex = 2;
            label2.Text = "Appointments : ";
            // 
            // btnAddAppointment
            // 
            btnAddAppointment.Location = new Point(553, 492);
            btnAddAppointment.Name = "btnAddAppointment";
            btnAddAppointment.Size = new Size(75, 23);
            btnAddAppointment.TabIndex = 3;
            btnAddAppointment.Text = "Add ";
            btnAddAppointment.UseVisualStyleBackColor = true;
            btnAddAppointment.Click += btnAddAppointment_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(553, 714);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 5;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // dtAppointments
            // 
            dtAppointments.AllowUserToAddRows = false;
            dtAppointments.AllowUserToDeleteRows = false;
            dtAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtAppointments.ContextMenuStrip = contextMenuStrip1;
            dtAppointments.Location = new Point(44, 521);
            dtAppointments.Name = "dtAppointments";
            dtAppointments.ReadOnly = true;
            dtAppointments.Size = new Size(584, 166);
            dtAppointments.TabIndex = 6;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem, tackeToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(181, 70);
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(180, 22);
            editToolStripMenuItem.Text = "Edit";
            editToolStripMenuItem.Click += editToolStripMenuItem1_Click;
            // 
            // tackeToolStripMenuItem
            // 
            tackeToolStripMenuItem.Name = "tackeToolStripMenuItem";
            tackeToolStripMenuItem.Size = new Size(180, 22);
            tackeToolStripMenuItem.Text = "Tacke Test";
            tackeToolStripMenuItem.Click += tackTestToolStripMenuItem_Click;
            // 
            // VisionTestAppointents
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(668, 749);
            Controls.Add(dtAppointments);
            Controls.Add(btnClose);
            Controls.Add(btnAddAppointment);
            Controls.Add(label2);
            Controls.Add(applicationInfo1);
            Controls.Add(label1);
            Name = "VisionTestAppointents";
            Text = "VisionTestAppointents";
            Load += VisionTestAppointents_Load;
            ((System.ComponentModel.ISupportInitialize)dtAppointments).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ApplicationInfo applicationInfo1;
        private Label label2;
        private Button btnAddAppointment;
        private Button btnClose;
        private DataGridView dtAppointments;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem tackeToolStripMenuItem;
    }
}
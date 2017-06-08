namespace Assignment3_Voting_System
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.votesGridView = new System.Windows.Forms.DataGridView();
            this.votesTableBox = new System.Windows.Forms.GroupBox();
            this.newCandidaetBox = new System.Windows.Forms.GroupBox();
            this.addCandidate = new System.Windows.Forms.Button();
            this.candidateTextBox = new System.Windows.Forms.TextBox();
            this.firstPreferencesGroupBox = new System.Windows.Forms.GroupBox();
            this.firstPreferencesGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.votesGridView)).BeginInit();
            this.votesTableBox.SuspendLayout();
            this.newCandidaetBox.SuspendLayout();
            this.firstPreferencesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.firstPreferencesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(851, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importMenuItem,
            this.exportMenuItem,
            this.exitMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importMenuItem
            // 
            this.importMenuItem.Name = "importMenuItem";
            this.importMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.importMenuItem.Size = new System.Drawing.Size(147, 22);
            this.importMenuItem.Text = "&Import";
            this.importMenuItem.Click += new System.EventHandler(this.importMenuItem_Click);
            // 
            // exportMenuItem
            // 
            this.exportMenuItem.Name = "exportMenuItem";
            this.exportMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exportMenuItem.Size = new System.Drawing.Size(147, 22);
            this.exportMenuItem.Text = "&Export";
            this.exportMenuItem.Click += new System.EventHandler(this.exportMenuItem_Click);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitMenuItem.Size = new System.Drawing.Size(147, 22);
            this.exitMenuItem.Text = "E&xit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // votesGridView
            // 
            this.votesGridView.AllowUserToResizeColumns = false;
            this.votesGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.votesGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.votesGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.votesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.votesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.votesGridView.EnableHeadersVisualStyles = false;
            this.votesGridView.Location = new System.Drawing.Point(6, 19);
            this.votesGridView.Name = "votesGridView";
            this.votesGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.votesGridView.ShowEditingIcon = false;
            this.votesGridView.Size = new System.Drawing.Size(560, 481);
            this.votesGridView.TabIndex = 1;
            this.votesGridView.CurrentCellChanged += new System.EventHandler(this.votesGridView_CurrentCellChanged);
            this.votesGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.votesGridView_RowsAdded);
            this.votesGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.votesGridView_RowsRemoved);
            // 
            // votesTableBox
            // 
            this.votesTableBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.votesTableBox.Controls.Add(this.votesGridView);
            this.votesTableBox.Location = new System.Drawing.Point(12, 27);
            this.votesTableBox.Name = "votesTableBox";
            this.votesTableBox.Size = new System.Drawing.Size(572, 506);
            this.votesTableBox.TabIndex = 2;
            this.votesTableBox.TabStop = false;
            this.votesTableBox.Text = "Votes Overview";
            // 
            // newCandidaetBox
            // 
            this.newCandidaetBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newCandidaetBox.Controls.Add(this.addCandidate);
            this.newCandidaetBox.Controls.Add(this.candidateTextBox);
            this.newCandidaetBox.Location = new System.Drawing.Point(597, 28);
            this.newCandidaetBox.Name = "newCandidaetBox";
            this.newCandidaetBox.Size = new System.Drawing.Size(252, 49);
            this.newCandidaetBox.TabIndex = 3;
            this.newCandidaetBox.TabStop = false;
            this.newCandidaetBox.Text = "Add New Candidate";
            // 
            // addCandidate
            // 
            this.addCandidate.Enabled = false;
            this.addCandidate.Location = new System.Drawing.Point(166, 18);
            this.addCandidate.Name = "addCandidate";
            this.addCandidate.Size = new System.Drawing.Size(76, 23);
            this.addCandidate.TabIndex = 1;
            this.addCandidate.Text = "Add";
            this.addCandidate.UseVisualStyleBackColor = true;
            this.addCandidate.Click += new System.EventHandler(this.addCandidate_Click);
            // 
            // candidateTextBox
            // 
            this.candidateTextBox.Location = new System.Drawing.Point(6, 20);
            this.candidateTextBox.Name = "candidateTextBox";
            this.candidateTextBox.Size = new System.Drawing.Size(154, 20);
            this.candidateTextBox.TabIndex = 0;
            this.candidateTextBox.TextChanged += new System.EventHandler(this.candidateTextBox_TextChanged);
            // 
            // firstPreferencesGroupBox
            // 
            this.firstPreferencesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.firstPreferencesGroupBox.Controls.Add(this.firstPreferencesGridView);
            this.firstPreferencesGroupBox.Location = new System.Drawing.Point(590, 84);
            this.firstPreferencesGroupBox.Name = "firstPreferencesGroupBox";
            this.firstPreferencesGroupBox.Size = new System.Drawing.Size(259, 449);
            this.firstPreferencesGroupBox.TabIndex = 4;
            this.firstPreferencesGroupBox.TabStop = false;
            this.firstPreferencesGroupBox.Text = "First Preferences";
            // 
            // firstPreferencesGridView
            // 
            this.firstPreferencesGridView.AllowUserToAddRows = false;
            this.firstPreferencesGridView.AllowUserToDeleteRows = false;
            this.firstPreferencesGridView.AllowUserToResizeColumns = false;
            this.firstPreferencesGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.firstPreferencesGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.firstPreferencesGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.firstPreferencesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.firstPreferencesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.firstPreferencesGridView.Location = new System.Drawing.Point(7, 20);
            this.firstPreferencesGridView.Name = "firstPreferencesGridView";
            this.firstPreferencesGridView.ReadOnly = true;
            this.firstPreferencesGridView.RowHeadersVisible = false;
            this.firstPreferencesGridView.Size = new System.Drawing.Size(242, 423);
            this.firstPreferencesGridView.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 545);
            this.Controls.Add(this.firstPreferencesGroupBox);
            this.Controls.Add(this.newCandidaetBox);
            this.Controls.Add(this.votesTableBox);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Voting System";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.votesGridView)).EndInit();
            this.votesTableBox.ResumeLayout(false);
            this.newCandidaetBox.ResumeLayout(false);
            this.newCandidaetBox.PerformLayout();
            this.firstPreferencesGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.firstPreferencesGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.DataGridView votesGridView;
        private System.Windows.Forms.GroupBox votesTableBox;
        private System.Windows.Forms.GroupBox newCandidaetBox;
        private System.Windows.Forms.Button addCandidate;
        private System.Windows.Forms.TextBox candidateTextBox;
        private System.Windows.Forms.GroupBox firstPreferencesGroupBox;
        private System.Windows.Forms.DataGridView firstPreferencesGridView;
    }
}


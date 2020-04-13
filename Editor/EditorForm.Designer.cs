namespace Editor
{
    partial class EditorForm
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
            this.cmbActiveFile = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEditChoice = new System.Windows.Forms.Button();
            this.btnRemoveChoice = new System.Windows.Forms.Button();
            this.btnAddChoice = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lvChoices = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tePrompt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.teDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNewFile = new System.Windows.Forms.Button();
            this.browseBaseFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRename = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbActiveFile
            // 
            this.cmbActiveFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActiveFile.FormattingEnabled = true;
            this.cmbActiveFile.Location = new System.Drawing.Point(152, 62);
            this.cmbActiveFile.Name = "cmbActiveFile";
            this.cmbActiveFile.Size = new System.Drawing.Size(495, 33);
            this.cmbActiveFile.TabIndex = 1;
            this.cmbActiveFile.SelectionChangeCommitted += new System.EventHandler(this.cmbActiveFile_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Active Room:";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(940, 54);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(183, 47);
            this.btnPrevious.TabIndex = 4;
            this.btnPrevious.Text = "Go to Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnEditChoice);
            this.groupBox1.Controls.Add(this.btnRemoveChoice);
            this.groupBox1.Controls.Add(this.btnAddChoice);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lvChoices);
            this.groupBox1.Controls.Add(this.tePrompt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.teDescription);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(33, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1535, 826);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Room Data";
            // 
            // btnEditChoice
            // 
            this.btnEditChoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditChoice.Location = new System.Drawing.Point(1059, 770);
            this.btnEditChoice.Name = "btnEditChoice";
            this.btnEditChoice.Size = new System.Drawing.Size(129, 50);
            this.btnEditChoice.TabIndex = 6;
            this.btnEditChoice.Text = "Edit";
            this.btnEditChoice.UseVisualStyleBackColor = true;
            this.btnEditChoice.Click += new System.EventHandler(this.btnEditChoice_Click);
            // 
            // btnRemoveChoice
            // 
            this.btnRemoveChoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveChoice.Location = new System.Drawing.Point(1390, 770);
            this.btnRemoveChoice.Name = "btnRemoveChoice";
            this.btnRemoveChoice.Size = new System.Drawing.Size(129, 50);
            this.btnRemoveChoice.TabIndex = 8;
            this.btnRemoveChoice.Text = "Remove";
            this.btnRemoveChoice.UseVisualStyleBackColor = true;
            this.btnRemoveChoice.Click += new System.EventHandler(this.btnRemoveChoice_Click);
            // 
            // btnAddChoice
            // 
            this.btnAddChoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddChoice.Location = new System.Drawing.Point(1255, 770);
            this.btnAddChoice.Name = "btnAddChoice";
            this.btnAddChoice.Size = new System.Drawing.Size(129, 50);
            this.btnAddChoice.TabIndex = 7;
            this.btnAddChoice.Text = "Add";
            this.btnAddChoice.UseVisualStyleBackColor = true;
            this.btnAddChoice.Click += new System.EventHandler(this.btnAddChoice_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 462);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Choices";
            // 
            // lvChoices
            // 
            this.lvChoices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvChoices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvChoices.FullRowSelect = true;
            this.lvChoices.GridLines = true;
            this.lvChoices.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvChoices.HideSelection = false;
            this.lvChoices.Location = new System.Drawing.Point(27, 490);
            this.lvChoices.MultiSelect = false;
            this.lvChoices.Name = "lvChoices";
            this.lvChoices.ShowGroups = false;
            this.lvChoices.Size = new System.Drawing.Size(1492, 262);
            this.lvChoices.TabIndex = 5;
            this.lvChoices.UseCompatibleStateImageBehavior = false;
            this.lvChoices.View = System.Windows.Forms.View.Details;
            this.lvChoices.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvChoices_AfterLabelEdit);
            this.lvChoices.ItemActivate += new System.EventHandler(this.lvChoices_ItemActivate);
            this.lvChoices.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvChoices_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Description";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Link";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 202;
            // 
            // tePrompt
            // 
            this.tePrompt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tePrompt.Location = new System.Drawing.Point(27, 390);
            this.tePrompt.Multiline = true;
            this.tePrompt.Name = "tePrompt";
            this.tePrompt.Size = new System.Drawing.Size(1492, 53);
            this.tePrompt.TabIndex = 3;
            this.tePrompt.TextChanged += new System.EventHandler(this.tePrompt_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 362);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Choice Prompt:";
            // 
            // teDescription
            // 
            this.teDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teDescription.Location = new System.Drawing.Point(23, 87);
            this.teDescription.Multiline = true;
            this.teDescription.Name = "teDescription";
            this.teDescription.Size = new System.Drawing.Size(1496, 265);
            this.teDescription.TabIndex = 1;
            this.teDescription.TextChanged += new System.EventHandler(this.teDescription_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Description:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(803, 54);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(131, 47);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNewFile
            // 
            this.btnNewFile.Location = new System.Drawing.Point(1229, 52);
            this.btnNewFile.Name = "btnNewFile";
            this.btnNewFile.Size = new System.Drawing.Size(131, 49);
            this.btnNewFile.TabIndex = 5;
            this.btnNewFile.Text = "New";
            this.btnNewFile.UseVisualStyleBackColor = true;
            this.btnNewFile.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // browseBaseFolder
            // 
            this.browseBaseFolder.Description = "Select the Base Folder";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1580, 40);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.openProjectToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(72, 36);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(288, 44);
            this.newProjectToolStripMenuItem.Text = "New Project";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(288, 44);
            this.openProjectToolStripMenuItem.Text = "Open Project";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+S";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(288, 44);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(285, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeyDisplayString = "Alt+F4";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(288, 44);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(666, 55);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(131, 47);
            this.btnRename.TabIndex = 2;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1580, 968);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.btnNewFile);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbActiveFile);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EditorForm";
            this.Text = "Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditorForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbActiveFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRemoveChoice;
        private System.Windows.Forms.Button btnAddChoice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView lvChoices;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox tePrompt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox teDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNewFile;
        private System.Windows.Forms.FolderBrowserDialog browseBaseFolder;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnEditChoice;
    }
}


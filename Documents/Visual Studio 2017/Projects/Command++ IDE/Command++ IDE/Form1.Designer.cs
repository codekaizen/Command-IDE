namespace Command___IDE
{
    partial class mainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainWindow));
            this.codeBox = new System.Windows.Forms.RichTextBox();
            this.codeEditorStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CurEditCom = new System.Windows.Forms.Label();
            this.lnNumbers = new System.Windows.Forms.RichTextBox();
            this.updateTime = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openRecentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseNotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileList = new System.Windows.Forms.ImageList(this.components);
            this.errorView = new System.Windows.Forms.DataGridView();
            this.ComErrors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeAutoComplete = new AutocompleteMenuNS.AutocompleteMenu();
            this.autocompleteList = new System.Windows.Forms.ImageList(this.components);
            this.findTextBox = new System.Windows.Forms.TextBox();
            this.findBox = new System.Windows.Forms.GroupBox();
            this.findCancelButton = new System.Windows.Forms.Button();
            this.findNextSearchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.codeEditorStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorView)).BeginInit();
            this.findBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // codeBox
            // 
            this.codeBox.AcceptsTab = true;
            this.codeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.codeAutoComplete.SetAutocompleteMenu(this.codeBox, this.codeAutoComplete);
            this.codeBox.ContextMenuStrip = this.codeEditorStrip;
            this.codeBox.DetectUrls = false;
            this.codeBox.Font = new System.Drawing.Font("Lucida Console", 10F);
            this.codeBox.Location = new System.Drawing.Point(33, 27);
            this.codeBox.Name = "codeBox";
            this.codeBox.Size = new System.Drawing.Size(945, 502);
            this.codeBox.TabIndex = 0;
            this.codeBox.Text = "";
            this.codeBox.WordWrap = false;
            this.codeBox.SelectionChanged += new System.EventHandler(this.codeBox_CursorChanged);
            this.codeBox.TextChanged += new System.EventHandler(this.codeBox_TextChanged);
            this.codeBox.Enter += new System.EventHandler(this.codeBox_Enter);
            this.codeBox.Leave += new System.EventHandler(this.codeBox_Leave);
            // 
            // codeEditorStrip
            // 
            this.codeEditorStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem1,
            this.copyToolStripMenuItem1,
            this.pasteToolStripMenuItem1});
            this.codeEditorStrip.Name = "contextMenuStrip1";
            this.codeEditorStrip.Size = new System.Drawing.Size(103, 70);
            // 
            // cutToolStripMenuItem1
            // 
            this.cutToolStripMenuItem1.Name = "cutToolStripMenuItem1";
            this.cutToolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.cutToolStripMenuItem1.Text = "Cut";
            this.cutToolStripMenuItem1.Click += new System.EventHandler(this.cutToolStripMenuItem1_Click);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.copyToolStripMenuItem1.Text = "Copy";
            this.copyToolStripMenuItem1.Click += new System.EventHandler(this.copyToolStripMenuItem1_Click);
            // 
            // pasteToolStripMenuItem1
            // 
            this.pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            this.pasteToolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.pasteToolStripMenuItem1.Text = "Paste";
            this.pasteToolStripMenuItem1.Click += new System.EventHandler(this.pasteToolStripMenuItem1_Click);
            // 
            // CurEditCom
            // 
            this.CurEditCom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CurEditCom.AutoSize = true;
            this.CurEditCom.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurEditCom.Location = new System.Drawing.Point(30, 539);
            this.CurEditCom.Name = "CurEditCom";
            this.CurEditCom.Size = new System.Drawing.Size(0, 12);
            this.CurEditCom.TabIndex = 1;
            // 
            // lnNumbers
            // 
            this.lnNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.codeAutoComplete.SetAutocompleteMenu(this.lnNumbers, null);
            this.lnNumbers.BackColor = System.Drawing.SystemColors.Control;
            this.lnNumbers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lnNumbers.Enabled = false;
            this.lnNumbers.Font = new System.Drawing.Font("Lucida Console", 10F);
            this.lnNumbers.Location = new System.Drawing.Point(1, 27);
            this.lnNumbers.Name = "lnNumbers";
            this.lnNumbers.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.lnNumbers.Size = new System.Drawing.Size(32, 502);
            this.lnNumbers.TabIndex = 2;
            this.lnNumbers.Text = "1.";
            this.lnNumbers.WordWrap = false;
            // 
            // updateTime
            // 
            this.updateTime.Enabled = true;
            this.updateTime.Interval = 200;
            this.updateTime.Tick += new System.EventHandler(this.updateTime_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(991, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripMenuItem1,
            this.openToolStripMenuItem,
            this.openRecentToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(159, 22);
            this.toolStripMenuItem1.Text = "New Window";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click_1);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openRecentToolStripMenuItem
            // 
            this.openRecentToolStripMenuItem.Name = "openRecentToolStripMenuItem";
            this.openRecentToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.openRecentToolStripMenuItem.Text = "Open Recent";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(156, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.saveToolStripMenuItem.Text = "Save File";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.saveAsToolStripMenuItem.Text = "Save File As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(156, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator3,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator4,
            this.findToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(141, 6);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.findToolStripMenuItem.Text = "Find";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.findToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionInformationToolStripMenuItem,
            this.releaseNotesToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // versionInformationToolStripMenuItem
            // 
            this.versionInformationToolStripMenuItem.Name = "versionInformationToolStripMenuItem";
            this.versionInformationToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.versionInformationToolStripMenuItem.Text = "Version Information";
            this.versionInformationToolStripMenuItem.Click += new System.EventHandler(this.versionInformationToolStripMenuItem_Click);
            // 
            // releaseNotesToolStripMenuItem
            // 
            this.releaseNotesToolStripMenuItem.Name = "releaseNotesToolStripMenuItem";
            this.releaseNotesToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.releaseNotesToolStripMenuItem.Text = "Release Notes";
            this.releaseNotesToolStripMenuItem.Click += new System.EventHandler(this.releaseNotesToolStripMenuItem_Click);
            // 
            // fileList
            // 
            this.fileList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("fileList.ImageStream")));
            this.fileList.TransparentColor = System.Drawing.Color.Transparent;
            this.fileList.Images.SetKeyName(0, "Impulse_Command_Block.ico");
            this.fileList.Images.SetKeyName(1, "commandblock_lrg.ico");
            this.fileList.Images.SetKeyName(2, "Chain_Command_Block.png");
            // 
            // errorView
            // 
            this.errorView.AllowUserToAddRows = false;
            this.errorView.AllowUserToDeleteRows = false;
            this.errorView.AllowUserToResizeColumns = false;
            this.errorView.AllowUserToResizeRows = false;
            this.errorView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.errorView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.errorView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.errorView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ComErrors});
            this.errorView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.errorView.Location = new System.Drawing.Point(779, 493);
            this.errorView.MultiSelect = false;
            this.errorView.Name = "errorView";
            this.errorView.ReadOnly = true;
            this.errorView.RowHeadersVisible = false;
            this.errorView.Size = new System.Drawing.Size(199, 35);
            this.errorView.TabIndex = 5;
            this.errorView.Visible = false;
            // 
            // ComErrors
            // 
            this.ComErrors.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ComErrors.HeaderText = "Command Errors";
            this.ComErrors.Name = "ComErrors";
            this.ComErrors.ReadOnly = true;
            this.ComErrors.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ComErrors.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // codeAutoComplete
            // 
            this.codeAutoComplete.AllowsTabKey = true;
            this.codeAutoComplete.AppearInterval = 100;
            this.codeAutoComplete.Colors = ((AutocompleteMenuNS.Colors)(resources.GetObject("codeAutoComplete.Colors")));
            this.codeAutoComplete.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeAutoComplete.ImageList = this.autocompleteList;
            this.codeAutoComplete.Items = new string[0];
            this.codeAutoComplete.MaximumSize = new System.Drawing.Size(180, 250);
            this.codeAutoComplete.MinFragmentLength = 1;
            this.codeAutoComplete.SearchPattern = "[\\S\\.]";
            this.codeAutoComplete.TargetControlWrapper = null;
            // 
            // autocompleteList
            // 
            this.autocompleteList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("autocompleteList.ImageStream")));
            this.autocompleteList.TransparentColor = System.Drawing.Color.Transparent;
            this.autocompleteList.Images.SetKeyName(0, "Impulse_Command_Block.png");
            this.autocompleteList.Images.SetKeyName(1, "Head.png");
            this.autocompleteList.Images.SetKeyName(2, "Arrow.png");
            this.autocompleteList.Images.SetKeyName(3, "Grass.png");
            this.autocompleteList.Images.SetKeyName(4, "Chain_Command_Block.png");
            this.autocompleteList.Images.SetKeyName(5, "redstonetorch_icon32.png");
            this.autocompleteList.Images.SetKeyName(6, "Oak_Wood.png");
            // 
            // findTextBox
            // 
            this.codeAutoComplete.SetAutocompleteMenu(this.findTextBox, null);
            this.findTextBox.Location = new System.Drawing.Point(69, 14);
            this.findTextBox.Name = "findTextBox";
            this.findTextBox.Size = new System.Drawing.Size(119, 20);
            this.findTextBox.TabIndex = 1;
            // 
            // findBox
            // 
            this.findBox.Controls.Add(this.findCancelButton);
            this.findBox.Controls.Add(this.findNextSearchButton);
            this.findBox.Controls.Add(this.findTextBox);
            this.findBox.Controls.Add(this.label1);
            this.findBox.Location = new System.Drawing.Point(784, 12);
            this.findBox.Name = "findBox";
            this.findBox.Size = new System.Drawing.Size(194, 67);
            this.findBox.TabIndex = 6;
            this.findBox.TabStop = false;
            this.findBox.Text = "Find";
            this.findBox.Visible = false;
            // 
            // findCancelButton
            // 
            this.findCancelButton.Location = new System.Drawing.Point(100, 38);
            this.findCancelButton.Name = "findCancelButton";
            this.findCancelButton.Size = new System.Drawing.Size(88, 23);
            this.findCancelButton.TabIndex = 3;
            this.findCancelButton.Text = "Cancel";
            this.findCancelButton.UseVisualStyleBackColor = true;
            this.findCancelButton.Click += new System.EventHandler(this.findCancelButton_Click);
            // 
            // findNextSearchButton
            // 
            this.findNextSearchButton.Location = new System.Drawing.Point(6, 38);
            this.findNextSearchButton.Name = "findNextSearchButton";
            this.findNextSearchButton.Size = new System.Drawing.Size(88, 23);
            this.findNextSearchButton.TabIndex = 2;
            this.findNextSearchButton.Text = "Find Next";
            this.findNextSearchButton.UseVisualStyleBackColor = true;
            this.findNextSearchButton.Click += new System.EventHandler(this.findNextSearchButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search For:";
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 561);
            this.Controls.Add(this.findBox);
            this.Controls.Add(this.errorView);
            this.Controls.Add(this.lnNumbers);
            this.Controls.Add(this.CurEditCom);
            this.Controls.Add(this.codeBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "mainWindow";
            this.Text = "Command++ IDE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainWindow_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainWindow_FormClosed);
            this.Load += new System.EventHandler(this.mainWindow_Load);
            this.Shown += new System.EventHandler(this.mainWindow_Shown);
            this.codeEditorStrip.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorView)).EndInit();
            this.findBox.ResumeLayout(false);
            this.findBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox codeBox;
        private System.Windows.Forms.Label CurEditCom;
        private System.Windows.Forms.RichTextBox lnNumbers;
        private System.Windows.Forms.Timer updateTime;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openRecentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ImageList fileList;
        private System.Windows.Forms.DataGridView errorView;
        private System.Windows.Forms.ContextMenuStrip codeEditorStrip;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem1;
        private AutocompleteMenuNS.AutocompleteMenu codeAutoComplete;
        private System.Windows.Forms.ImageList autocompleteList;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComErrors;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseNotesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.GroupBox findBox;
        private System.Windows.Forms.TextBox findTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button findCancelButton;
        private System.Windows.Forms.Button findNextSearchButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
    }
}


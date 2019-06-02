namespace AlbeFly.BoardControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tpMain = new System.Windows.Forms.TabPage();
            this.btnSetAllBoards = new System.Windows.Forms.Button();
            this.btnSetBoard = new System.Windows.Forms.Button();
            this.grpControlBits = new System.Windows.Forms.GroupBox();
            this.dgvControlBits = new System.Windows.Forms.DataGridView();
            this.clmnCBitPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnCBitDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnCBitValue = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.grpParams = new System.Windows.Forms.GroupBox();
            this.dgvParams = new System.Windows.Forms.DataGridView();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAddBoard = new System.Windows.Forms.ToolStripMenuItem();
            this.mniRemoveBoard = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mniEnableBoard = new System.Windows.Forms.ToolStripMenuItem();
            this.mniDisableBoard = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mniSetBoard = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSetAllBoards = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mniExit = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.lblLog = new System.Windows.Forms.Label();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.tlStripMain = new System.Windows.Forms.ToolStrip();
            this.tsbEnableBoard = new System.Windows.Forms.ToolStripButton();
            this.tsbDisableBoard = new System.Windows.Forms.ToolStripButton();
            this.tsbSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSetBoard = new System.Windows.Forms.ToolStripButton();
            this.tsbSetAllBoards = new System.Windows.Forms.ToolStripButton();
            this.grpBoardSelector = new System.Windows.Forms.GroupBox();
            this.lstBoardSelector = new System.Windows.Forms.ListBox();
            this.tmrLog = new System.Windows.Forms.Timer(this.components);
            this.clmnParamPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnParamDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnParamValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabMain.SuspendLayout();
            this.tpMain.SuspendLayout();
            this.grpControlBits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvControlBits)).BeginInit();
            this.grpParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParams)).BeginInit();
            this.mnuMain.SuspendLayout();
            this.tlStripMain.SuspendLayout();
            this.grpBoardSelector.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tpMain);
            this.tabMain.Controls.Add(this.tpSettings);
            this.tabMain.Location = new System.Drawing.Point(138, 61);
            this.tabMain.Margin = new System.Windows.Forms.Padding(2);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(608, 371);
            this.tabMain.TabIndex = 0;
            // 
            // tpMain
            // 
            this.tpMain.Controls.Add(this.btnSetAllBoards);
            this.tpMain.Controls.Add(this.btnSetBoard);
            this.tpMain.Controls.Add(this.grpControlBits);
            this.tpMain.Controls.Add(this.grpParams);
            this.tpMain.Location = new System.Drawing.Point(4, 22);
            this.tpMain.Margin = new System.Windows.Forms.Padding(2);
            this.tpMain.Name = "tpMain";
            this.tpMain.Padding = new System.Windows.Forms.Padding(2);
            this.tpMain.Size = new System.Drawing.Size(600, 345);
            this.tpMain.TabIndex = 0;
            this.tpMain.Text = " Main ";
            this.tpMain.UseVisualStyleBackColor = true;
            // 
            // btnSetAllBoards
            // 
            this.btnSetAllBoards.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetAllBoards.Location = new System.Drawing.Point(492, 312);
            this.btnSetAllBoards.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetAllBoards.Name = "btnSetAllBoards";
            this.btnSetAllBoards.Size = new System.Drawing.Size(101, 28);
            this.btnSetAllBoards.TabIndex = 52;
            this.btnSetAllBoards.Text = "Set All Boards";
            this.btnSetAllBoards.UseVisualStyleBackColor = true;
            // 
            // btnSetBoard
            // 
            this.btnSetBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetBoard.Location = new System.Drawing.Point(492, 280);
            this.btnSetBoard.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetBoard.Name = "btnSetBoard";
            this.btnSetBoard.Size = new System.Drawing.Size(101, 28);
            this.btnSetBoard.TabIndex = 51;
            this.btnSetBoard.Text = "Set Board";
            this.btnSetBoard.UseVisualStyleBackColor = true;
            // 
            // grpControlBits
            // 
            this.grpControlBits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpControlBits.Controls.Add(this.dgvControlBits);
            this.grpControlBits.Location = new System.Drawing.Point(4, 5);
            this.grpControlBits.Margin = new System.Windows.Forms.Padding(2);
            this.grpControlBits.Name = "grpControlBits";
            this.grpControlBits.Padding = new System.Windows.Forms.Padding(2);
            this.grpControlBits.Size = new System.Drawing.Size(322, 340);
            this.grpControlBits.TabIndex = 50;
            this.grpControlBits.TabStop = false;
            this.grpControlBits.Text = "Control Bits";
            // 
            // dgvControlBits
            // 
            this.dgvControlBits.AllowUserToAddRows = false;
            this.dgvControlBits.AllowUserToDeleteRows = false;
            this.dgvControlBits.AllowUserToResizeRows = false;
            this.dgvControlBits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvControlBits.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvControlBits.ColumnHeadersHeight = 30;
            this.dgvControlBits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvControlBits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnCBitPosition,
            this.clmnCBitDescription,
            this.clmnCBitValue});
            this.dgvControlBits.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvControlBits.Location = new System.Drawing.Point(8, 17);
            this.dgvControlBits.Margin = new System.Windows.Forms.Padding(2);
            this.dgvControlBits.MultiSelect = false;
            this.dgvControlBits.Name = "dgvControlBits";
            this.dgvControlBits.RowHeadersVisible = false;
            this.dgvControlBits.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvControlBits.RowTemplate.Height = 24;
            this.dgvControlBits.ShowCellErrors = false;
            this.dgvControlBits.ShowCellToolTips = false;
            this.dgvControlBits.ShowRowErrors = false;
            this.dgvControlBits.Size = new System.Drawing.Size(307, 312);
            this.dgvControlBits.TabIndex = 0;
            // 
            // clmnCBitPosition
            // 
            this.clmnCBitPosition.HeaderText = "Bit #";
            this.clmnCBitPosition.MinimumWidth = 50;
            this.clmnCBitPosition.Name = "clmnCBitPosition";
            this.clmnCBitPosition.ReadOnly = true;
            this.clmnCBitPosition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmnCBitPosition.Width = 50;
            // 
            // clmnCBitDescription
            // 
            this.clmnCBitDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnCBitDescription.HeaderText = "Description";
            this.clmnCBitDescription.Name = "clmnCBitDescription";
            this.clmnCBitDescription.ReadOnly = true;
            this.clmnCBitDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmnCBitValue
            // 
            this.clmnCBitValue.HeaderText = "Value";
            this.clmnCBitValue.Name = "clmnCBitValue";
            this.clmnCBitValue.Width = 130;
            // 
            // grpParams
            // 
            this.grpParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpParams.Controls.Add(this.dgvParams);
            this.grpParams.Location = new System.Drawing.Point(331, 5);
            this.grpParams.Margin = new System.Windows.Forms.Padding(2);
            this.grpParams.Name = "grpParams";
            this.grpParams.Padding = new System.Windows.Forms.Padding(2);
            this.grpParams.Size = new System.Drawing.Size(267, 270);
            this.grpParams.TabIndex = 49;
            this.grpParams.TabStop = false;
            this.grpParams.Text = "Params";
            // 
            // dgvParams
            // 
            this.dgvParams.AllowUserToAddRows = false;
            this.dgvParams.AllowUserToDeleteRows = false;
            this.dgvParams.AllowUserToResizeRows = false;
            this.dgvParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvParams.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvParams.ColumnHeadersHeight = 30;
            this.dgvParams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvParams.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnParamPosition,
            this.clmnParamDescription,
            this.clmnParamValue});
            this.dgvParams.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvParams.Location = new System.Drawing.Point(9, 17);
            this.dgvParams.Margin = new System.Windows.Forms.Padding(2);
            this.dgvParams.MultiSelect = false;
            this.dgvParams.Name = "dgvParams";
            this.dgvParams.RowHeadersVisible = false;
            this.dgvParams.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvParams.RowTemplate.Height = 24;
            this.dgvParams.ShowCellErrors = false;
            this.dgvParams.ShowCellToolTips = false;
            this.dgvParams.ShowRowErrors = false;
            this.dgvParams.Size = new System.Drawing.Size(249, 241);
            this.dgvParams.TabIndex = 1;
            // 
            // tpSettings
            // 
            this.tpSettings.Location = new System.Drawing.Point(4, 22);
            this.tpSettings.Margin = new System.Windows.Forms.Padding(2);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(2);
            this.tpSettings.Size = new System.Drawing.Size(600, 345);
            this.tpSettings.TabIndex = 1;
            this.tpSettings.Text = " Settings ";
            this.tpSettings.UseVisualStyleBackColor = true;
            // 
            // mnuMain
            // 
            this.mnuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.mnuMain.Size = new System.Drawing.Size(754, 24);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAddBoard,
            this.mniRemoveBoard,
            this.mniSeparator2,
            this.mniEnableBoard,
            this.mniDisableBoard,
            this.mniSeparator3,
            this.mniSetBoard,
            this.mniSetAllBoards,
            this.mniSeparator1,
            this.mniExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mniAddBoard
            // 
            this.mniAddBoard.Name = "mniAddBoard";
            this.mniAddBoard.Size = new System.Drawing.Size(151, 22);
            this.mniAddBoard.Text = "Add Board";
            // 
            // mniRemoveBoard
            // 
            this.mniRemoveBoard.Name = "mniRemoveBoard";
            this.mniRemoveBoard.Size = new System.Drawing.Size(151, 22);
            this.mniRemoveBoard.Text = "Remove Board";
            // 
            // mniSeparator2
            // 
            this.mniSeparator2.Name = "mniSeparator2";
            this.mniSeparator2.Size = new System.Drawing.Size(148, 6);
            // 
            // mniEnableBoard
            // 
            this.mniEnableBoard.Name = "mniEnableBoard";
            this.mniEnableBoard.Size = new System.Drawing.Size(151, 22);
            this.mniEnableBoard.Text = "Enable Board";
            // 
            // mniDisableBoard
            // 
            this.mniDisableBoard.Name = "mniDisableBoard";
            this.mniDisableBoard.Size = new System.Drawing.Size(151, 22);
            this.mniDisableBoard.Text = "Disable Board";
            // 
            // mniSeparator3
            // 
            this.mniSeparator3.Name = "mniSeparator3";
            this.mniSeparator3.Size = new System.Drawing.Size(148, 6);
            // 
            // mniSetBoard
            // 
            this.mniSetBoard.Name = "mniSetBoard";
            this.mniSetBoard.Size = new System.Drawing.Size(151, 22);
            this.mniSetBoard.Text = "Set Board";
            // 
            // mniSetAllBoards
            // 
            this.mniSetAllBoards.Name = "mniSetAllBoards";
            this.mniSetAllBoards.Size = new System.Drawing.Size(151, 22);
            this.mniSetAllBoards.Text = "Set All Boards";
            // 
            // mniSeparator1
            // 
            this.mniSeparator1.Name = "mniSeparator1";
            this.mniSeparator1.Size = new System.Drawing.Size(148, 6);
            // 
            // mniExit
            // 
            this.mniExit.Name = "mniExit";
            this.mniExit.Size = new System.Drawing.Size(151, 22);
            this.mniExit.Text = "Exit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // mniAbout
            // 
            this.mniAbout.Name = "mniAbout";
            this.mniAbout.Size = new System.Drawing.Size(107, 22);
            this.mniAbout.Text = "About";
            // 
            // lblLog
            // 
            this.lblLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(4, 418);
            this.lblLog.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(25, 13);
            this.lblLog.TabIndex = 14;
            this.lblLog.Text = "Log";
            // 
            // lstLog
            // 
            this.lstLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLog.HorizontalScrollbar = true;
            this.lstLog.ItemHeight = 14;
            this.lstLog.Location = new System.Drawing.Point(7, 441);
            this.lstLog.Margin = new System.Windows.Forms.Padding(2);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(740, 116);
            this.lstLog.TabIndex = 13;
            // 
            // tlStripMain
            // 
            this.tlStripMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tlStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbEnableBoard,
            this.tsbDisableBoard,
            this.tsbSeparator1,
            this.tsbSetBoard,
            this.tsbSetAllBoards});
            this.tlStripMain.Location = new System.Drawing.Point(0, 24);
            this.tlStripMain.Name = "tlStripMain";
            this.tlStripMain.Size = new System.Drawing.Size(754, 31);
            this.tlStripMain.TabIndex = 15;
            this.tlStripMain.Text = "toolStrip1";
            // 
            // tsbEnableBoard
            // 
            this.tsbEnableBoard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEnableBoard.Image = ((System.Drawing.Image)(resources.GetObject("tsbEnableBoard.Image")));
            this.tsbEnableBoard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEnableBoard.Name = "tsbEnableBoard";
            this.tsbEnableBoard.Size = new System.Drawing.Size(28, 28);
            this.tsbEnableBoard.Text = "Enable Board";
            // 
            // tsbDisableBoard
            // 
            this.tsbDisableBoard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDisableBoard.Image = ((System.Drawing.Image)(resources.GetObject("tsbDisableBoard.Image")));
            this.tsbDisableBoard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDisableBoard.Name = "tsbDisableBoard";
            this.tsbDisableBoard.Size = new System.Drawing.Size(28, 28);
            this.tsbDisableBoard.Text = "Disable Board";
            // 
            // tsbSeparator1
            // 
            this.tsbSeparator1.Name = "tsbSeparator1";
            this.tsbSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // tsbSetBoard
            // 
            this.tsbSetBoard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSetBoard.Image = ((System.Drawing.Image)(resources.GetObject("tsbSetBoard.Image")));
            this.tsbSetBoard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSetBoard.Name = "tsbSetBoard";
            this.tsbSetBoard.Size = new System.Drawing.Size(28, 28);
            this.tsbSetBoard.Text = "Set Board";
            // 
            // tsbSetAllBoards
            // 
            this.tsbSetAllBoards.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSetAllBoards.Image = ((System.Drawing.Image)(resources.GetObject("tsbSetAllBoards.Image")));
            this.tsbSetAllBoards.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSetAllBoards.Name = "tsbSetAllBoards";
            this.tsbSetAllBoards.Size = new System.Drawing.Size(28, 28);
            this.tsbSetAllBoards.Text = "Set All Boards";
            // 
            // grpBoardSelector
            // 
            this.grpBoardSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpBoardSelector.Controls.Add(this.lstBoardSelector);
            this.grpBoardSelector.Location = new System.Drawing.Point(9, 78);
            this.grpBoardSelector.Margin = new System.Windows.Forms.Padding(2);
            this.grpBoardSelector.Name = "grpBoardSelector";
            this.grpBoardSelector.Padding = new System.Windows.Forms.Padding(2);
            this.grpBoardSelector.Size = new System.Drawing.Size(124, 328);
            this.grpBoardSelector.TabIndex = 16;
            this.grpBoardSelector.TabStop = false;
            this.grpBoardSelector.Text = "Board Selector";
            // 
            // lstBoardSelector
            // 
            this.lstBoardSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstBoardSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBoardSelector.FormattingEnabled = true;
            this.lstBoardSelector.ItemHeight = 16;
            this.lstBoardSelector.Items.AddRange(new object[] {
            "(1) Primary",
            "(2) Secondary"});
            this.lstBoardSelector.Location = new System.Drawing.Point(4, 20);
            this.lstBoardSelector.Margin = new System.Windows.Forms.Padding(2);
            this.lstBoardSelector.Name = "lstBoardSelector";
            this.lstBoardSelector.Size = new System.Drawing.Size(116, 292);
            this.lstBoardSelector.TabIndex = 3;
            this.lstBoardSelector.SelectedIndexChanged += new System.EventHandler(this.lstBoardSelector_SelectedIndexChanged);
            // 
            // tmrLog
            // 
            this.tmrLog.Enabled = true;
            this.tmrLog.Interval = 300;
            this.tmrLog.Tick += new System.EventHandler(this.tmrLog_Tick);
            // 
            // clmnParamPosition
            // 
            this.clmnParamPosition.HeaderText = "Param #";
            this.clmnParamPosition.MinimumWidth = 50;
            this.clmnParamPosition.Name = "clmnParamPosition";
            this.clmnParamPosition.ReadOnly = true;
            this.clmnParamPosition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmnParamPosition.Width = 50;
            // 
            // clmnParamDescription
            // 
            this.clmnParamDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmnParamDescription.HeaderText = "Description";
            this.clmnParamDescription.Name = "clmnParamDescription";
            this.clmnParamDescription.ReadOnly = true;
            this.clmnParamDescription.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmnParamValue
            // 
            this.clmnParamValue.HeaderText = "Value";
            this.clmnParamValue.MinimumWidth = 75;
            this.clmnParamValue.Name = "clmnParamValue";
            this.clmnParamValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmnParamValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmnParamValue.Width = 75;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 573);
            this.Controls.Add(this.grpBoardSelector);
            this.Controls.Add(this.tlStripMain);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = this.mnuMain;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(772, 657);
            this.MinimumSize = new System.Drawing.Size(604, 495);
            this.Name = "MainForm";
            this.Text = "Board Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.tabMain.ResumeLayout(false);
            this.tpMain.ResumeLayout(false);
            this.grpControlBits.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvControlBits)).EndInit();
            this.grpParams.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParams)).EndInit();
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.tlStripMain.ResumeLayout(false);
            this.tlStripMain.PerformLayout();
            this.grpBoardSelector.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tpMain;
        private System.Windows.Forms.TabPage tpSettings;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mniAbout;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.GroupBox grpControlBits;
        private System.Windows.Forms.GroupBox grpParams;
        private System.Windows.Forms.DataGridView dgvControlBits;
        private System.Windows.Forms.DataGridView dgvParams;
        private System.Windows.Forms.ToolStrip tlStripMain;
        private System.Windows.Forms.GroupBox grpBoardSelector;
        private System.Windows.Forms.ListBox lstBoardSelector;
        private System.Windows.Forms.ToolStripButton tsbEnableBoard;
        private System.Windows.Forms.ToolStripButton tsbDisableBoard;
        private System.Windows.Forms.ToolStripSeparator tsbSeparator1;
        private System.Windows.Forms.ToolStripButton tsbSetBoard;
        private System.Windows.Forms.ToolStripButton tsbSetAllBoards;
        private System.Windows.Forms.Button btnSetAllBoards;
        private System.Windows.Forms.Button btnSetBoard;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mniSetBoard;
        private System.Windows.Forms.ToolStripMenuItem mniSetAllBoards;
        private System.Windows.Forms.ToolStripSeparator mniSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mniAddBoard;
        private System.Windows.Forms.ToolStripMenuItem mniRemoveBoard;
        private System.Windows.Forms.ToolStripSeparator mniSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mniEnableBoard;
        private System.Windows.Forms.ToolStripMenuItem mniDisableBoard;
        private System.Windows.Forms.ToolStripSeparator mniSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mniExit;
        private System.Windows.Forms.Timer tmrLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnCBitPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnCBitDescription;
        private System.Windows.Forms.DataGridViewComboBoxColumn clmnCBitValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnParamPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnParamDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnParamValue;
    }
}


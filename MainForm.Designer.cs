namespace AnimizerTool {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.animDataGridView = new System.Windows.Forms.DataGridView();
            this.addAnimBtn = new System.Windows.Forms.Button();
            this.animPreviewPicture = new System.Windows.Forms.PictureBox();
            this.mainMainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuFile = new System.Windows.Forms.MenuItem();
            this.menuFileNew = new System.Windows.Forms.MenuItem();
            this.menuFileOpen = new System.Windows.Forms.MenuItem();
            this.menuDiv1 = new System.Windows.Forms.MenuItem();
            this.menuSaveAnim = new System.Windows.Forms.MenuItem();
            this.menuSaveAsAnim = new System.Windows.Forms.MenuItem();
            this.menuDiv2 = new System.Windows.Forms.MenuItem();
            this.menuExit = new System.Windows.Forms.MenuItem();
            this.menuEdit = new System.Windows.Forms.MenuItem();
            this.menuChangeBoxColor = new System.Windows.Forms.MenuItem();
            this.menuHelp = new System.Windows.Forms.MenuItem();
            this.menuHelpAbout = new System.Windows.Forms.MenuItem();
            this.saveAnimFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.animNameLabel = new System.Windows.Forms.Label();
            this.animFrameLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.timeFrameCntTextBox = new System.Windows.Forms.TextBox();
            this.timeFrameRateTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.timeSecsLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.centerYTextBox = new System.Windows.Forms.TextBox();
            this.centerXTextBox = new System.Windows.Forms.TextBox();
            this.nextAnimBtn = new System.Windows.Forms.Button();
            this.prevAnimBtn = new System.Windows.Forms.Button();
            this.playAnimBtn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.sizeYTextBox = new System.Windows.Forms.TextBox();
            this.sizeXTextBox = new System.Windows.Forms.TextBox();
            this.removeAnimBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.loadAnimFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.animFrameImageTextBox = new System.Windows.Forms.TextBox();
            this.animFrameImageBtn = new System.Windows.Forms.Button();
            this.loadImageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.radioTopLeft = new System.Windows.Forms.RadioButton();
            this.radioCenter = new System.Windows.Forms.RadioButton();
            this.radioBottomLeft = new System.Windows.Forms.RadioButton();
            this.removeAnimFrameBtn = new System.Windows.Forms.Button();
            this.addAnimFrameBtn = new System.Windows.Forms.Button();
            this.boxColorDialog = new System.Windows.Forms.ColorDialog();
            this.scaleTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AnimID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.animDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.animPreviewPicture)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // animDataGridView
            // 
            this.animDataGridView.AllowUserToAddRows = false;
            this.animDataGridView.AllowUserToDeleteRows = false;
            this.animDataGridView.AllowUserToResizeColumns = false;
            this.animDataGridView.AllowUserToResizeRows = false;
            this.animDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.animDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.animDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AnimID});
            this.animDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.animDataGridView.Location = new System.Drawing.Point(9, 9);
            this.animDataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.animDataGridView.MultiSelect = false;
            this.animDataGridView.Name = "animDataGridView";
            this.animDataGridView.RowHeadersVisible = false;
            this.animDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.animDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.animDataGridView.ShowCellErrors = false;
            this.animDataGridView.ShowCellToolTips = false;
            this.animDataGridView.ShowEditingIcon = false;
            this.animDataGridView.ShowRowErrors = false;
            this.animDataGridView.Size = new System.Drawing.Size(167, 272);
            this.animDataGridView.StandardTab = true;
            this.animDataGridView.TabIndex = 1;
            this.animDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.animDataGridView_CellBeginEdit);
            this.animDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.animDataGridView_CellEndEdit);
            this.animDataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.animDataGridView_CellMouseDoubleClick);
            this.animDataGridView.CurrentCellChanged += new System.EventHandler(this.animDataGridView_CurrentCellChanged);
            // 
            // addAnimBtn
            // 
            this.addAnimBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAnimBtn.Location = new System.Drawing.Point(9, 284);
            this.addAnimBtn.Name = "addAnimBtn";
            this.addAnimBtn.Size = new System.Drawing.Size(75, 50);
            this.addAnimBtn.TabIndex = 2;
            this.addAnimBtn.Text = "+";
            this.addAnimBtn.UseVisualStyleBackColor = true;
            this.addAnimBtn.Click += new System.EventHandler(this.addAnimBtn_Click);
            // 
            // animPreviewPicture
            // 
            this.animPreviewPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.animPreviewPicture.Location = new System.Drawing.Point(231, 10);
            this.animPreviewPicture.Name = "animPreviewPicture";
            this.animPreviewPicture.Padding = new System.Windows.Forms.Padding(64, 64, 0, 0);
            this.animPreviewPicture.Size = new System.Drawing.Size(128, 128);
            this.animPreviewPicture.TabIndex = 6;
            this.animPreviewPicture.TabStop = false;
            // 
            // mainMainMenu
            // 
            this.mainMainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFile,
            this.menuEdit,
            this.menuHelp});
            // 
            // menuFile
            // 
            this.menuFile.Index = 0;
            this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFileNew,
            this.menuFileOpen,
            this.menuDiv1,
            this.menuSaveAnim,
            this.menuSaveAsAnim,
            this.menuDiv2,
            this.menuExit});
            this.menuFile.Text = "File";
            // 
            // menuFileNew
            // 
            this.menuFileNew.Index = 0;
            this.menuFileNew.Text = "New AnimSet";
            this.menuFileNew.Click += new System.EventHandler(this.menuFileNew_Click);
            // 
            // menuFileOpen
            // 
            this.menuFileOpen.Index = 1;
            this.menuFileOpen.Text = "Open...";
            this.menuFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
            // 
            // menuDiv1
            // 
            this.menuDiv1.Index = 2;
            this.menuDiv1.Text = "-";
            // 
            // menuSaveAnim
            // 
            this.menuSaveAnim.Index = 3;
            this.menuSaveAnim.Text = "Save";
            this.menuSaveAnim.Click += new System.EventHandler(this.menuSaveAnim_Click);
            // 
            // menuSaveAsAnim
            // 
            this.menuSaveAsAnim.Index = 4;
            this.menuSaveAsAnim.Text = "Save As...";
            this.menuSaveAsAnim.Click += new System.EventHandler(this.menuSaveAsAnim_Click);
            // 
            // menuDiv2
            // 
            this.menuDiv2.Index = 5;
            this.menuDiv2.Text = "-";
            // 
            // menuExit
            // 
            this.menuExit.Index = 6;
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuEdit
            // 
            this.menuEdit.Index = 1;
            this.menuEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuChangeBoxColor});
            this.menuEdit.Text = "Edit";
            // 
            // menuChangeBoxColor
            // 
            this.menuChangeBoxColor.Index = 0;
            this.menuChangeBoxColor.Text = "Change Box Color...";
            this.menuChangeBoxColor.Click += new System.EventHandler(this.menuChangeBoxColor_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.Index = 2;
            this.menuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuHelpAbout});
            this.menuHelp.Text = "Help";
            // 
            // menuHelpAbout
            // 
            this.menuHelpAbout.Index = 0;
            this.menuHelpAbout.Text = "About...";
            this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
            // 
            // saveAnimFileDialog
            // 
            this.saveAnimFileDialog.DefaultExt = "animset";
            this.saveAnimFileDialog.Filter = "AnimSets|*.animset|All files|*.*";
            // 
            // animNameLabel
            // 
            this.animNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.animNameLabel.AutoSize = true;
            this.animNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.animNameLabel.Location = new System.Drawing.Point(78, 0);
            this.animNameLabel.Name = "animNameLabel";
            this.animNameLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.animNameLabel.Size = new System.Drawing.Size(55, 15);
            this.animNameLabel.TabIndex = 0;
            this.animNameLabel.Text = "Name: \"\"";
            // 
            // animFrameLabel
            // 
            this.animFrameLabel.AutoSize = true;
            this.animFrameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.animFrameLabel.Location = new System.Drawing.Point(139, 0);
            this.animFrameLabel.Name = "animFrameLabel";
            this.animFrameLabel.Size = new System.Drawing.Size(63, 15);
            this.animFrameLabel.TabIndex = 0;
            this.animFrameLabel.Text = "Frame n/a";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Center";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Size";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(310, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Time";
            // 
            // timeFrameCntTextBox
            // 
            this.timeFrameCntTextBox.Enabled = false;
            this.timeFrameCntTextBox.Location = new System.Drawing.Point(278, 291);
            this.timeFrameCntTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.timeFrameCntTextBox.MaxLength = 3;
            this.timeFrameCntTextBox.Name = "timeFrameCntTextBox";
            this.timeFrameCntTextBox.Size = new System.Drawing.Size(30, 20);
            this.timeFrameCntTextBox.TabIndex = 22;
            this.timeFrameCntTextBox.TextChanged += new System.EventHandler(this.timeFrameCntTextBox_TextChanged);
            // 
            // timeFrameRateTextBox
            // 
            this.timeFrameRateTextBox.Enabled = false;
            this.timeFrameRateTextBox.Location = new System.Drawing.Point(326, 291);
            this.timeFrameRateTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.timeFrameRateTextBox.MaxLength = 3;
            this.timeFrameRateTextBox.Name = "timeFrameRateTextBox";
            this.timeFrameRateTextBox.Size = new System.Drawing.Size(30, 20);
            this.timeFrameRateTextBox.TabIndex = 23;
            this.timeFrameRateTextBox.TextChanged += new System.EventHandler(this.timeFrameRateTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(310, 294);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "/";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(359, 294);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "secs";
            // 
            // timeSecsLabel
            // 
            this.timeSecsLabel.AutoSize = true;
            this.timeSecsLabel.Location = new System.Drawing.Point(299, 311);
            this.timeSecsLabel.Name = "timeSecsLabel";
            this.timeSecsLabel.Size = new System.Drawing.Size(47, 13);
            this.timeSecsLabel.TabIndex = 0;
            this.timeSecsLabel.Text = "= 0 secs";
            this.timeSecsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(52, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = ": X";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // centerYTextBox
            // 
            this.centerYTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.centerYTextBox.Enabled = false;
            this.centerYTextBox.Location = new System.Drawing.Point(78, 18);
            this.centerYTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.centerYTextBox.MaxLength = 5;
            this.centerYTextBox.Name = "centerYTextBox";
            this.centerYTextBox.Size = new System.Drawing.Size(40, 20);
            this.centerYTextBox.TabIndex = 19;
            this.centerYTextBox.TextChanged += new System.EventHandler(this.centerYTextBox_TextChanged);
            // 
            // centerXTextBox
            // 
            this.centerXTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.centerXTextBox.Enabled = false;
            this.centerXTextBox.Location = new System.Drawing.Point(9, 18);
            this.centerXTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.centerXTextBox.MaxLength = 5;
            this.centerXTextBox.Name = "centerXTextBox";
            this.centerXTextBox.Size = new System.Drawing.Size(40, 20);
            this.centerXTextBox.TabIndex = 18;
            this.centerXTextBox.TextChanged += new System.EventHandler(this.centerXTextBox_TextChanged);
            // 
            // nextAnimBtn
            // 
            this.nextAnimBtn.Enabled = false;
            this.nextAnimBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextAnimBtn.Location = new System.Drawing.Point(329, 166);
            this.nextAnimBtn.Margin = new System.Windows.Forms.Padding(1);
            this.nextAnimBtn.Name = "nextAnimBtn";
            this.nextAnimBtn.Size = new System.Drawing.Size(30, 25);
            this.nextAnimBtn.TabIndex = 15;
            this.nextAnimBtn.Text = ">";
            this.nextAnimBtn.UseVisualStyleBackColor = true;
            this.nextAnimBtn.Click += new System.EventHandler(this.nextAnimBtn_Click);
            // 
            // prevAnimBtn
            // 
            this.prevAnimBtn.Enabled = false;
            this.prevAnimBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prevAnimBtn.Location = new System.Drawing.Point(297, 166);
            this.prevAnimBtn.Margin = new System.Windows.Forms.Padding(1);
            this.prevAnimBtn.Name = "prevAnimBtn";
            this.prevAnimBtn.Size = new System.Drawing.Size(30, 25);
            this.prevAnimBtn.TabIndex = 14;
            this.prevAnimBtn.Text = "<";
            this.prevAnimBtn.UseVisualStyleBackColor = true;
            this.prevAnimBtn.Click += new System.EventHandler(this.prevAnimBtn_Click);
            // 
            // playAnimBtn
            // 
            this.playAnimBtn.Enabled = false;
            this.playAnimBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.playAnimBtn.Location = new System.Drawing.Point(231, 166);
            this.playAnimBtn.Margin = new System.Windows.Forms.Padding(1);
            this.playAnimBtn.Name = "playAnimBtn";
            this.playAnimBtn.Size = new System.Drawing.Size(50, 30);
            this.playAnimBtn.TabIndex = 13;
            this.playAnimBtn.Text = "▶";
            this.playAnimBtn.UseVisualStyleBackColor = true;
            this.playAnimBtn.Click += new System.EventHandler(this.playAnimBtn_Click);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(117, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = ": Y";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(118, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = ": Y";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(54, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = ": X";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sizeYTextBox
            // 
            this.sizeYTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sizeYTextBox.Enabled = false;
            this.sizeYTextBox.Location = new System.Drawing.Point(80, 18);
            this.sizeYTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.sizeYTextBox.MaxLength = 5;
            this.sizeYTextBox.Name = "sizeYTextBox";
            this.sizeYTextBox.Size = new System.Drawing.Size(40, 20);
            this.sizeYTextBox.TabIndex = 21;
            this.sizeYTextBox.TextChanged += new System.EventHandler(this.sizeYTextBox_TextChanged);
            // 
            // sizeXTextBox
            // 
            this.sizeXTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sizeXTextBox.Enabled = false;
            this.sizeXTextBox.Location = new System.Drawing.Point(11, 18);
            this.sizeXTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.sizeXTextBox.MaxLength = 5;
            this.sizeXTextBox.Name = "sizeXTextBox";
            this.sizeXTextBox.Size = new System.Drawing.Size(40, 20);
            this.sizeXTextBox.TabIndex = 20;
            this.sizeXTextBox.TextChanged += new System.EventHandler(this.sizeXTextBox_TextChanged);
            // 
            // removeAnimBtn
            // 
            this.removeAnimBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeAnimBtn.Location = new System.Drawing.Point(101, 284);
            this.removeAnimBtn.Name = "removeAnimBtn";
            this.removeAnimBtn.Size = new System.Drawing.Size(75, 50);
            this.removeAnimBtn.TabIndex = 3;
            this.removeAnimBtn.Text = "-";
            this.removeAnimBtn.UseVisualStyleBackColor = true;
            this.removeAnimBtn.Click += new System.EventHandler(this.removeAnimBtn_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.animNameLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.animFrameLabel, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(179, 144);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(273, 18);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.centerXTextBox);
            this.panel2.Controls.Add(this.centerYTextBox);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Location = new System.Drawing.Point(179, 226);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(145, 47);
            this.panel2.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.sizeXTextBox);
            this.panel3.Controls.Add(this.sizeYTextBox);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Location = new System.Drawing.Point(323, 226);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(145, 47);
            this.panel3.TabIndex = 11;
            // 
            // loadAnimFileDialog
            // 
            this.loadAnimFileDialog.Filter = "AnimSets|*.animset|All files|*.*";
            // 
            // animFrameImageTextBox
            // 
            this.animFrameImageTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.animFrameImageTextBox.Location = new System.Drawing.Point(179, 200);
            this.animFrameImageTextBox.Name = "animFrameImageTextBox";
            this.animFrameImageTextBox.ReadOnly = true;
            this.animFrameImageTextBox.Size = new System.Drawing.Size(257, 20);
            this.animFrameImageTextBox.TabIndex = 16;
            // 
            // animFrameImageBtn
            // 
            this.animFrameImageBtn.Enabled = false;
            this.animFrameImageBtn.Location = new System.Drawing.Point(442, 198);
            this.animFrameImageBtn.Name = "animFrameImageBtn";
            this.animFrameImageBtn.Size = new System.Drawing.Size(26, 23);
            this.animFrameImageBtn.TabIndex = 17;
            this.animFrameImageBtn.Text = "...";
            this.animFrameImageBtn.UseVisualStyleBackColor = true;
            this.animFrameImageBtn.Click += new System.EventHandler(this.animFrameImageBtn_Click);
            // 
            // loadImageFileDialog
            // 
            this.loadImageFileDialog.Filter = "Image (.bmp, .gif, .jpeg, .png, .tiff)| *.bmp; *.gif; *.jpeg; *.png; *.tiff;";
            // 
            // radioTopLeft
            // 
            this.radioTopLeft.AutoSize = true;
            this.radioTopLeft.Location = new System.Drawing.Point(365, 97);
            this.radioTopLeft.Name = "radioTopLeft";
            this.radioTopLeft.Size = new System.Drawing.Size(65, 17);
            this.radioTopLeft.TabIndex = 9;
            this.radioTopLeft.TabStop = true;
            this.radioTopLeft.Text = "Top Left";
            this.radioTopLeft.UseVisualStyleBackColor = true;
            this.radioTopLeft.CheckedChanged += new System.EventHandler(this.radioTopLeft_CheckedChanged);
            // 
            // radioCenter
            // 
            this.radioCenter.AutoSize = true;
            this.radioCenter.Checked = true;
            this.radioCenter.Location = new System.Drawing.Point(365, 74);
            this.radioCenter.Name = "radioCenter";
            this.radioCenter.Size = new System.Drawing.Size(56, 17);
            this.radioCenter.TabIndex = 8;
            this.radioCenter.TabStop = true;
            this.radioCenter.Text = "Center";
            this.radioCenter.UseVisualStyleBackColor = true;
            this.radioCenter.CheckedChanged += new System.EventHandler(this.radioCenter_CheckedChanged);
            // 
            // radioBottomLeft
            // 
            this.radioBottomLeft.AutoSize = true;
            this.radioBottomLeft.Location = new System.Drawing.Point(365, 120);
            this.radioBottomLeft.Name = "radioBottomLeft";
            this.radioBottomLeft.Size = new System.Drawing.Size(79, 17);
            this.radioBottomLeft.TabIndex = 11;
            this.radioBottomLeft.TabStop = true;
            this.radioBottomLeft.Text = "Bottom Left";
            this.radioBottomLeft.UseVisualStyleBackColor = true;
            this.radioBottomLeft.CheckedChanged += new System.EventHandler(this.radioBottomLeft_CheckedChanged);
            // 
            // removeAnimFrameBtn
            // 
            this.removeAnimFrameBtn.Enabled = false;
            this.removeAnimFrameBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeAnimFrameBtn.Location = new System.Drawing.Point(393, 166);
            this.removeAnimFrameBtn.Margin = new System.Windows.Forms.Padding(1);
            this.removeAnimFrameBtn.Name = "removeAnimFrameBtn";
            this.removeAnimFrameBtn.Size = new System.Drawing.Size(30, 25);
            this.removeAnimFrameBtn.TabIndex = 24;
            this.removeAnimFrameBtn.Text = "-";
            this.removeAnimFrameBtn.UseVisualStyleBackColor = true;
            this.removeAnimFrameBtn.Click += new System.EventHandler(this.removeAnimFrameBtn_Click);
            // 
            // addAnimFrameBtn
            // 
            this.addAnimFrameBtn.Enabled = false;
            this.addAnimFrameBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAnimFrameBtn.Location = new System.Drawing.Point(361, 166);
            this.addAnimFrameBtn.Margin = new System.Windows.Forms.Padding(1);
            this.addAnimFrameBtn.Name = "addAnimFrameBtn";
            this.addAnimFrameBtn.Size = new System.Drawing.Size(30, 25);
            this.addAnimFrameBtn.TabIndex = 25;
            this.addAnimFrameBtn.Text = "+";
            this.addAnimFrameBtn.UseVisualStyleBackColor = true;
            this.addAnimFrameBtn.Click += new System.EventHandler(this.addAnimFrameBtn_Click);
            // 
            // scaleTextBox
            // 
            this.scaleTextBox.Location = new System.Drawing.Point(375, 35);
            this.scaleTextBox.MaxLength = 4;
            this.scaleTextBox.Name = "scaleTextBox";
            this.scaleTextBox.Size = new System.Drawing.Size(31, 20);
            this.scaleTextBox.TabIndex = 26;
            this.scaleTextBox.Text = "1";
            this.scaleTextBox.TextChanged += new System.EventHandler(this.scaleTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(374, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scale";
            // 
            // AnimID
            // 
            this.AnimID.HeaderText = "Anim ID";
            this.AnimID.Name = "AnimID";
            this.AnimID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AnimID.Width = 164;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 344);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scaleTextBox);
            this.Controls.Add(this.addAnimFrameBtn);
            this.Controls.Add(this.removeAnimFrameBtn);
            this.Controls.Add(this.radioCenter);
            this.Controls.Add(this.radioBottomLeft);
            this.Controls.Add(this.radioTopLeft);
            this.Controls.Add(this.animFrameImageBtn);
            this.Controls.Add(this.animFrameImageTextBox);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.removeAnimBtn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.animDataGridView);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.addAnimBtn);
            this.Controls.Add(this.timeSecsLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.animPreviewPicture);
            this.Controls.Add(this.timeFrameRateTextBox);
            this.Controls.Add(this.playAnimBtn);
            this.Controls.Add(this.timeFrameCntTextBox);
            this.Controls.Add(this.prevAnimBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nextAnimBtn);
            this.Controls.Add(this.label5);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Menu = this.mainMainMenu;
            this.Name = "MainForm";
            this.Text = "Untitled - Animizer Tool";
            ((System.ComponentModel.ISupportInitialize)(this.animDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.animPreviewPicture)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView animDataGridView;
        private System.Windows.Forms.Button addAnimBtn;
        private System.Windows.Forms.PictureBox animPreviewPicture;
        private System.Windows.Forms.MainMenu mainMainMenu;
        private System.Windows.Forms.MenuItem menuFile;
        private System.Windows.Forms.MenuItem menuFileNew;
        private System.Windows.Forms.MenuItem menuFileOpen;
        private System.Windows.Forms.MenuItem menuExit;
        private System.Windows.Forms.MenuItem menuEdit;
        private System.Windows.Forms.MenuItem menuChangeBoxColor;
        private System.Windows.Forms.MenuItem menuHelp;
        private System.Windows.Forms.MenuItem menuHelpAbout;
        private System.Windows.Forms.SaveFileDialog saveAnimFileDialog;
        private System.Windows.Forms.MenuItem menuDiv1;
        private System.Windows.Forms.MenuItem menuSaveAnim;
        private System.Windows.Forms.MenuItem menuSaveAsAnim;
        private System.Windows.Forms.MenuItem menuDiv2;
        private System.Windows.Forms.Label animFrameLabel;
        private System.Windows.Forms.Label animNameLabel;
        private System.Windows.Forms.Button nextAnimBtn;
        private System.Windows.Forms.Button prevAnimBtn;
        private System.Windows.Forms.Button playAnimBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox timeFrameCntTextBox;
        private System.Windows.Forms.TextBox timeFrameRateTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label timeSecsLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox centerYTextBox;
        private System.Windows.Forms.TextBox centerXTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox sizeYTextBox;
        private System.Windows.Forms.TextBox sizeXTextBox;
        private System.Windows.Forms.Button removeAnimBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.OpenFileDialog loadAnimFileDialog;
        private System.Windows.Forms.TextBox animFrameImageTextBox;
        private System.Windows.Forms.Button animFrameImageBtn;
        private System.Windows.Forms.OpenFileDialog loadImageFileDialog;
        private System.Windows.Forms.RadioButton radioTopLeft;
        private System.Windows.Forms.RadioButton radioCenter;
        private System.Windows.Forms.RadioButton radioBottomLeft;
        private System.Windows.Forms.Button removeAnimFrameBtn;
        private System.Windows.Forms.Button addAnimFrameBtn;
        private System.Windows.Forms.ColorDialog boxColorDialog;
        private System.Windows.Forms.TextBox scaleTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnimID;
    }
}


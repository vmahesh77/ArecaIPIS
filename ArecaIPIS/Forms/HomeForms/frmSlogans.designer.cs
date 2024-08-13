
namespace ArecaIPIS.Forms.HomeForms
{
    partial class frmSlogans
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblNormalMessages = new System.Windows.Forms.Label();
            this.pnlSlogan = new System.Windows.Forms.Panel();
            this.lblNoDataToDisplay = new System.Windows.Forms.Label();
            this.btnAddSloganMessage = new System.Windows.Forms.Button();
            this.btnDropdown = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtBoardId = new System.Windows.Forms.TextBox();
            this.lblBoardId = new System.Windows.Forms.Label();
            this.cmbBoardType = new System.Windows.Forms.ComboBox();
            this.lblBoardType = new System.Windows.Forms.Label();
            this.btnCross = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvSlogan = new System.Windows.Forms.DataGridView();
            this.Column = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlFormShow = new System.Windows.Forms.Panel();
            this.lblMessageValidation = new System.Windows.Forms.Label();
            this.pbTickFile = new System.Windows.Forms.PictureBox();
            this.pbCross = new System.Windows.Forms.PictureBox();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.btnKeyboard = new System.Windows.Forms.Button();
            this.lblShowingAudio = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAudioFile = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCreateMessage = new System.Windows.Forms.Label();
            this.pbTick = new System.Windows.Forms.PictureBox();
            this.pnlMessageAnnouncement = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nupMessage = new System.Windows.Forms.NumericUpDown();
            this.btnStopMessage = new System.Windows.Forms.Button();
            this.btnPauseMessage = new System.Windows.Forms.Button();
            this.btnPlayMessage = new System.Windows.Forms.Button();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.toolTipSlogan = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialogs = new System.Windows.Forms.OpenFileDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlSlogan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSlogan)).BeginInit();
            this.pnlFormShow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTickFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCross)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTick)).BeginInit();
            this.pnlMessageAnnouncement.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNormalMessages
            // 
            this.lblNormalMessages.AutoSize = true;
            this.lblNormalMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNormalMessages.ForeColor = System.Drawing.Color.Red;
            this.lblNormalMessages.Location = new System.Drawing.Point(64, -4);
            this.lblNormalMessages.Name = "lblNormalMessages";
            this.lblNormalMessages.Size = new System.Drawing.Size(247, 31);
            this.lblNormalMessages.TabIndex = 0;
            this.lblNormalMessages.Text = "Normal Messages";
            // 
            // pnlSlogan
            // 
            this.pnlSlogan.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlSlogan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSlogan.Controls.Add(this.lblNoDataToDisplay);
            this.pnlSlogan.Controls.Add(this.btnAddSloganMessage);
            this.pnlSlogan.Controls.Add(this.btnDropdown);
            this.pnlSlogan.Controls.Add(this.txtSearch);
            this.pnlSlogan.Controls.Add(this.txtBoardId);
            this.pnlSlogan.Controls.Add(this.lblBoardId);
            this.pnlSlogan.Controls.Add(this.cmbBoardType);
            this.pnlSlogan.Controls.Add(this.lblBoardType);
            this.pnlSlogan.Controls.Add(this.btnCross);
            this.pnlSlogan.Controls.Add(this.btnSearch);
            this.pnlSlogan.Controls.Add(this.dgvSlogan);
            this.pnlSlogan.Location = new System.Drawing.Point(97, 33);
            this.pnlSlogan.Name = "pnlSlogan";
            this.pnlSlogan.Size = new System.Drawing.Size(1068, 256);
            this.pnlSlogan.TabIndex = 1;
            // 
            // lblNoDataToDisplay
            // 
            this.lblNoDataToDisplay.AutoSize = true;
            this.lblNoDataToDisplay.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblNoDataToDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoDataToDisplay.ForeColor = System.Drawing.Color.Black;
            this.lblNoDataToDisplay.Location = new System.Drawing.Point(419, 170);
            this.lblNoDataToDisplay.Name = "lblNoDataToDisplay";
            this.lblNoDataToDisplay.Size = new System.Drawing.Size(216, 25);
            this.lblNoDataToDisplay.TabIndex = 0;
            this.lblNoDataToDisplay.Text = "No Data To Display";
            // 
            // btnAddSloganMessage
            // 
            this.btnAddSloganMessage.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnAddSloganMessage.FlatAppearance.BorderSize = 0;
            this.btnAddSloganMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSloganMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSloganMessage.ForeColor = System.Drawing.Color.Black;
            this.btnAddSloganMessage.Location = new System.Drawing.Point(3, 56);
            this.btnAddSloganMessage.Name = "btnAddSloganMessage";
            this.btnAddSloganMessage.Size = new System.Drawing.Size(40, 31);
            this.btnAddSloganMessage.TabIndex = 23;
            this.btnAddSloganMessage.Text = "+";
            this.btnAddSloganMessage.UseVisualStyleBackColor = false;
            this.btnAddSloganMessage.Click += new System.EventHandler(this.btnAddSloganMessage_Click);
            // 
            // btnDropdown
            // 
            this.btnDropdown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDropdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDropdown.Image = global::ArecaIPIS.Properties.Resources.descending_down;
            this.btnDropdown.Location = new System.Drawing.Point(1004, 14);
            this.btnDropdown.Name = "btnDropdown";
            this.btnDropdown.Size = new System.Drawing.Size(46, 31);
            this.btnDropdown.TabIndex = 22;
            this.btnDropdown.UseVisualStyleBackColor = false;
            this.btnDropdown.Click += new System.EventHandler(this.btnDropdown_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(824, 21);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(140, 20);
            this.txtSearch.TabIndex = 19;
            this.txtSearch.Text = "Search Here";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            // 
            // txtBoardId
            // 
            this.txtBoardId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoardId.Location = new System.Drawing.Point(603, 17);
            this.txtBoardId.Name = "txtBoardId";
            this.txtBoardId.Size = new System.Drawing.Size(148, 20);
            this.txtBoardId.TabIndex = 4;
            // 
            // lblBoardId
            // 
            this.lblBoardId.AutoSize = true;
            this.lblBoardId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoardId.ForeColor = System.Drawing.Color.Black;
            this.lblBoardId.Location = new System.Drawing.Point(515, 18);
            this.lblBoardId.Name = "lblBoardId";
            this.lblBoardId.Size = new System.Drawing.Size(71, 16);
            this.lblBoardId.TabIndex = 3;
            this.lblBoardId.Text = "Board Id:";
            // 
            // cmbBoardType
            // 
            this.cmbBoardType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBoardType.FormattingEnabled = true;
            this.cmbBoardType.Location = new System.Drawing.Point(304, 15);
            this.cmbBoardType.Name = "cmbBoardType";
            this.cmbBoardType.Size = new System.Drawing.Size(145, 21);
            this.cmbBoardType.TabIndex = 2;
            // 
            // lblBoardType
            // 
            this.lblBoardType.AutoSize = true;
            this.lblBoardType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoardType.ForeColor = System.Drawing.Color.Black;
            this.lblBoardType.Location = new System.Drawing.Point(185, 19);
            this.lblBoardType.Name = "lblBoardType";
            this.lblBoardType.Size = new System.Drawing.Size(94, 16);
            this.lblBoardType.TabIndex = 1;
            this.lblBoardType.Text = "Board Type:";
            // 
            // btnCross
            // 
            this.btnCross.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCross.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCross.Image = global::ArecaIPIS.Properties.Resources._4879885_close_cross_delete_remove_icon;
            this.btnCross.Location = new System.Drawing.Point(961, 14);
            this.btnCross.Name = "btnCross";
            this.btnCross.Size = new System.Drawing.Size(46, 31);
            this.btnCross.TabIndex = 21;
            this.btnCross.UseVisualStyleBackColor = false;
            this.btnCross.Click += new System.EventHandler(this.btnCross_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::ArecaIPIS.Properties.Resources._352091_search_icon;
            this.btnSearch.Location = new System.Drawing.Point(961, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(46, 31);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvSlogan
            // 
            this.dgvSlogan.AllowUserToResizeColumns = false;
            this.dgvSlogan.AllowUserToResizeRows = false;
            this.dgvSlogan.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSlogan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvSlogan.ColumnHeadersHeight = 40;
            this.dgvSlogan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSlogan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column,
            this.Message,
            this.Select,
            this.Delete});
            this.dgvSlogan.Location = new System.Drawing.Point(-1, 52);
            this.dgvSlogan.Name = "dgvSlogan";
            this.dgvSlogan.RowHeadersVisible = false;
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            this.dgvSlogan.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvSlogan.RowTemplate.Height = 40;
            this.dgvSlogan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSlogan.Size = new System.Drawing.Size(1068, 203);
            this.dgvSlogan.TabIndex = 0;
            this.dgvSlogan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSlogan_CellClick);
            this.dgvSlogan.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvSlogan_CellPainting);
            // 
            // Column
            // 
            this.Column.HeaderText = "";
            this.Column.Name = "Column";
            // 
            // Message
            // 
            this.Message.HeaderText = "Message";
            this.Message.Name = "Message";
            this.Message.Width = 650;
            // 
            // Select
            // 
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            this.Select.Width = 160;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Width = 155;
            // 
            // pnlFormShow
            // 
            this.pnlFormShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFormShow.Controls.Add(this.lblMessageValidation);
            this.pnlFormShow.Controls.Add(this.pbTickFile);
            this.pnlFormShow.Controls.Add(this.pbCross);
            this.pnlFormShow.Controls.Add(this.cmbLanguage);
            this.pnlFormShow.Controls.Add(this.btnKeyboard);
            this.pnlFormShow.Controls.Add(this.lblShowingAudio);
            this.pnlFormShow.Controls.Add(this.lblFile);
            this.pnlFormShow.Controls.Add(this.btnAddFile);
            this.pnlFormShow.Controls.Add(this.txtMessage);
            this.pnlFormShow.Controls.Add(this.btnClose);
            this.pnlFormShow.Controls.Add(this.btnSave);
            this.pnlFormShow.Controls.Add(this.label6);
            this.pnlFormShow.Controls.Add(this.lblAudioFile);
            this.pnlFormShow.Controls.Add(this.lblLanguage);
            this.pnlFormShow.Controls.Add(this.lblMessage);
            this.pnlFormShow.Controls.Add(this.panel1);
            this.pnlFormShow.Controls.Add(this.pbTick);
            this.pnlFormShow.Location = new System.Drawing.Point(163, 311);
            this.pnlFormShow.Name = "pnlFormShow";
            this.pnlFormShow.Size = new System.Drawing.Size(887, 151);
            this.pnlFormShow.TabIndex = 3;
            // 
            // lblMessageValidation
            // 
            this.lblMessageValidation.AutoSize = true;
            this.lblMessageValidation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMessageValidation.Location = new System.Drawing.Point(145, 77);
            this.lblMessageValidation.Name = "lblMessageValidation";
            this.lblMessageValidation.Size = new System.Drawing.Size(19, 13);
            this.lblMessageValidation.TabIndex = 97;
            this.lblMessageValidation.Text = "ee";
            // 
            // pbTickFile
            // 
           // this.pbTickFile.Image = global::ArecaIPIS.Properties.Resources._1398911_correct_mark_success_tick_valid_icon;
            this.pbTickFile.ImageLocation = "";
            this.pbTickFile.Location = new System.Drawing.Point(458, 99);
            this.pbTickFile.Name = "pbTickFile";
            this.pbTickFile.Size = new System.Drawing.Size(25, 20);
            this.pbTickFile.TabIndex = 96;
            this.pbTickFile.TabStop = false;
            // 
            // pbCross
            // 
            this.pbCross.Image = global::ArecaIPIS.Properties.Resources._282471_cross_remove_delete_icon;
            this.pbCross.ImageLocation = "";
            this.pbCross.Location = new System.Drawing.Point(458, 55);
            this.pbCross.Name = "pbCross";
            this.pbCross.Size = new System.Drawing.Size(25, 20);
            this.pbCross.TabIndex = 94;
            this.pbCross.TabStop = false;
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.DisplayMember = "6";
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(634, 55);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(92, 21);
            this.cmbLanguage.TabIndex = 93;
            // 
            // btnKeyboard
            // 
            this.btnKeyboard.FlatAppearance.BorderSize = 0;
            this.btnKeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKeyboard.Image = global::ArecaIPIS.Properties.Resources._3671786_keyboard_icon__1_;
            this.btnKeyboard.Location = new System.Drawing.Point(424, 55);
            this.btnKeyboard.Name = "btnKeyboard";
            this.btnKeyboard.Size = new System.Drawing.Size(23, 19);
            this.btnKeyboard.TabIndex = 92;
            this.btnKeyboard.UseVisualStyleBackColor = true;
            // 
            // lblShowingAudio
            // 
            this.lblShowingAudio.AutoSize = true;
            this.lblShowingAudio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblShowingAudio.Location = new System.Drawing.Point(145, 119);
            this.lblShowingAudio.Name = "lblShowingAudio";
            this.lblShowingAudio.Size = new System.Drawing.Size(13, 13);
            this.lblShowingAudio.TabIndex = 91;
            this.lblShowingAudio.Text = "rr";
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.ForeColor = System.Drawing.Color.Black;
            this.lblFile.Location = new System.Drawing.Point(243, 99);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(75, 13);
            this.lblFile.TabIndex = 90;
            this.lblFile.Text = "No file chosen";
            this.lblFile.TextChanged += new System.EventHandler(this.lblFile_TextChanged);
            // 
            // btnAddFile
            // 
            this.btnAddFile.ForeColor = System.Drawing.Color.Black;
            this.btnAddFile.Location = new System.Drawing.Point(145, 94);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(92, 23);
            this.btnAddFile.TabIndex = 89;
            this.btnAddFile.Text = "Choose File";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(148, 54);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(268, 20);
            this.txtMessage.TabIndex = 88;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            this.txtMessage.Leave += new System.EventHandler(this.txtMessage_Leave);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::ArecaIPIS.Properties.Resources._9104213_close_cross_remove_delete_icon;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(703, 90);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 29);
            this.btnClose.TabIndex = 87;
            this.btnClose.Text = "  Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::ArecaIPIS.Properties.Resources._1564499_accept_added_check_complite_yes_icon;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(622, 90);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 29);
            this.btnSave.TabIndex = 86;
            this.btnSave.Text = "  Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(67, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(349, 13);
            this.label6.TabIndex = 85;
            this.label6.Text = "* Note: Please Upload Wav/Mp3 files, File size should be less than 2Mb.";
            // 
            // lblAudioFile
            // 
            this.lblAudioFile.AutoSize = true;
            this.lblAudioFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAudioFile.ForeColor = System.Drawing.Color.Black;
            this.lblAudioFile.Location = new System.Drawing.Point(22, 98);
            this.lblAudioFile.Name = "lblAudioFile";
            this.lblAudioFile.Size = new System.Drawing.Size(78, 13);
            this.lblAudioFile.TabIndex = 84;
            this.lblAudioFile.Text = "Audio File Path";
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLanguage.ForeColor = System.Drawing.Color.Black;
            this.lblLanguage.Location = new System.Drawing.Point(508, 58);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(59, 13);
            this.lblLanguage.TabIndex = 83;
            this.lblLanguage.Text = "*Language";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Black;
            this.lblMessage.Location = new System.Drawing.Point(22, 57);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(54, 13);
            this.lblMessage.TabIndex = 82;
            this.lblMessage.Text = "*Message";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Firebrick;
            this.panel1.Controls.Add(this.lblCreateMessage);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1068, 39);
            this.panel1.TabIndex = 81;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblCreateMessage
            // 
            this.lblCreateMessage.AutoSize = true;
            this.lblCreateMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateMessage.ForeColor = System.Drawing.Color.Black;
            this.lblCreateMessage.Location = new System.Drawing.Point(3, 8);
            this.lblCreateMessage.Name = "lblCreateMessage";
            this.lblCreateMessage.Size = new System.Drawing.Size(204, 29);
            this.lblCreateMessage.TabIndex = 0;
            this.lblCreateMessage.Text = "Create Message";
            // 
            // pbTick
            // 
          //  this.pbTick.Image = global::ArecaIPIS.Properties.Resources._1398911_correct_mark_success_tick_valid_icon;
            this.pbTick.ImageLocation = "";
            this.pbTick.Location = new System.Drawing.Point(458, 55);
            this.pbTick.Name = "pbTick";
            this.pbTick.Size = new System.Drawing.Size(25, 20);
            this.pbTick.TabIndex = 95;
            this.pbTick.TabStop = false;
            // 
            // pnlMessageAnnouncement
            // 
            this.pnlMessageAnnouncement.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlMessageAnnouncement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMessageAnnouncement.Controls.Add(this.groupBox1);
            this.pnlMessageAnnouncement.Controls.Add(this.btnSendMessage);
            this.pnlMessageAnnouncement.Location = new System.Drawing.Point(170, 311);
            this.pnlMessageAnnouncement.Name = "pnlMessageAnnouncement";
            this.pnlMessageAnnouncement.Size = new System.Drawing.Size(880, 122);
            this.pnlMessageAnnouncement.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox1.Controls.Add(this.nupMessage);
            this.groupBox1.Controls.Add(this.btnStopMessage);
            this.groupBox1.Controls.Add(this.btnPauseMessage);
            this.groupBox1.Controls.Add(this.btnPlayMessage);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(220, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(469, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Message Announcement";
            // 
            // nupMessage
            // 
            this.nupMessage.Location = new System.Drawing.Point(18, 44);
            this.nupMessage.Name = "nupMessage";
            this.nupMessage.Size = new System.Drawing.Size(88, 26);
            this.nupMessage.TabIndex = 29;
            this.nupMessage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnStopMessage
            // 
            this.btnStopMessage.BackColor = System.Drawing.Color.Red;
            this.btnStopMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnStopMessage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnStopMessage.Image = global::ArecaIPIS.Properties.Resources._9035124_stop_icon;
            this.btnStopMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStopMessage.Location = new System.Drawing.Point(231, 38);
            this.btnStopMessage.Name = "btnStopMessage";
            this.btnStopMessage.Size = new System.Drawing.Size(96, 36);
            this.btnStopMessage.TabIndex = 28;
            this.btnStopMessage.Text = "STOP";
            this.btnStopMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStopMessage.UseVisualStyleBackColor = false;
            // 
            // btnPauseMessage
            // 
            this.btnPauseMessage.BackColor = System.Drawing.Color.Aqua;
            this.btnPauseMessage.FlatAppearance.BorderSize = 0;
            this.btnPauseMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPauseMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnPauseMessage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPauseMessage.Image = global::ArecaIPIS.Properties.Resources._9224396_pause_stop_music_multimedia_break_icon;
            this.btnPauseMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPauseMessage.Location = new System.Drawing.Point(342, 38);
            this.btnPauseMessage.Name = "btnPauseMessage";
            this.btnPauseMessage.Size = new System.Drawing.Size(103, 36);
            this.btnPauseMessage.TabIndex = 27;
            this.btnPauseMessage.Text = "PAUSE";
            this.btnPauseMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPauseMessage.UseVisualStyleBackColor = false;
            // 
            // btnPlayMessage
            // 
            this.btnPlayMessage.BackColor = System.Drawing.Color.LawnGreen;
            this.btnPlayMessage.FlatAppearance.BorderSize = 0;
            this.btnPlayMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayMessage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPlayMessage.Image = global::ArecaIPIS.Properties.Resources._352072_arrow_play_icon__1_;
            this.btnPlayMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlayMessage.Location = new System.Drawing.Point(116, 38);
            this.btnPlayMessage.Name = "btnPlayMessage";
            this.btnPlayMessage.Size = new System.Drawing.Size(100, 36);
            this.btnPlayMessage.TabIndex = 26;
            this.btnPlayMessage.Text = "PLAY";
            this.btnPlayMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPlayMessage.UseVisualStyleBackColor = false;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnSendMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendMessage.ForeColor = System.Drawing.Color.Black;
            this.btnSendMessage.Image = global::ArecaIPIS.Properties.Resources._9042711_page_icon;
            this.btnSendMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSendMessage.Location = new System.Drawing.Point(81, 37);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(114, 58);
            this.btnSendMessage.TabIndex = 0;
            this.btnSendMessage.Text = "Send Message";
            this.btnSendMessage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSendMessage.UseVisualStyleBackColor = false;
            // 
            // openFileDialogs
            // 
            this.openFileDialogs.FileName = "openFileDialogs";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(97, 289);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1068, 20);
            this.panel2.TabIndex = 4;
            // 
            // frmSlogans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 461);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlSlogan);
            this.Controls.Add(this.lblNormalMessages);
            this.Controls.Add(this.pnlFormShow);
            this.Controls.Add(this.pnlMessageAnnouncement);
            this.Name = "frmSlogans";
            this.Text = "frmSlogans";
            this.Load += new System.EventHandler(this.frmSlogans_Load);
            this.pnlSlogan.ResumeLayout(false);
            this.pnlSlogan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSlogan)).EndInit();
            this.pnlFormShow.ResumeLayout(false);
            this.pnlFormShow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTickFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCross)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTick)).EndInit();
            this.pnlMessageAnnouncement.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nupMessage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNormalMessages;
        private System.Windows.Forms.Panel pnlSlogan;
        private System.Windows.Forms.Panel pnlMessageAnnouncement;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.Button btnStopMessage;
        private System.Windows.Forms.Button btnPauseMessage;
        private System.Windows.Forms.Button btnPlayMessage;
        private System.Windows.Forms.NumericUpDown nupMessage;
        private System.Windows.Forms.TextBox txtBoardId;
        private System.Windows.Forms.Label lblBoardId;
        private System.Windows.Forms.ComboBox cmbBoardType;
        private System.Windows.Forms.Label lblBoardType;
        private System.Windows.Forms.DataGridView dgvSlogan;
        private System.Windows.Forms.Button btnDropdown;
        private System.Windows.Forms.Button btnCross;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddSloganMessage;
        private System.Windows.Forms.Label lblNoDataToDisplay;
        private System.Windows.Forms.Panel pnlFormShow;
        private System.Windows.Forms.DataGridViewButtonColumn Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.ToolTip toolTipSlogan;
        private System.Windows.Forms.Label lblMessageValidation;
        private System.Windows.Forms.PictureBox pbTickFile;
        private System.Windows.Forms.PictureBox pbCross;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Button btnKeyboard;
        private System.Windows.Forms.Label lblShowingAudio;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAudioFile;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCreateMessage;
        private System.Windows.Forms.PictureBox pbTick;
        private System.Windows.Forms.OpenFileDialog openFileDialogs;
        private System.Windows.Forms.Panel panel2;
    }
}

namespace ArecaIPIS.Forms.ViewForms
{
    partial class frmRegionalLanguageStatus
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblRegionalLanguageStatus = new System.Windows.Forms.Label();
            this.dgvLanguageSettingsTable = new System.Windows.Forms.DataGridView();
            this.Column = new System.Windows.Forms.DataGridViewImageColumn();
            this.English = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hindi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegionalLanguage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDropdown = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnCross = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlPagination = new System.Windows.Forms.Panel();
            this.pnlCreateLanguageStatus = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.pnlCreateCoach = new System.Windows.Forms.Panel();
            this.lblCreateCoach = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNoteDef2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRegionalName = new System.Windows.Forms.Label();
            this.lblHindiCoach = new System.Windows.Forms.Label();
            this.lblEnglishCoach = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtRLanguage = new System.Windows.Forms.TextBox();
            this.lblBitmap = new System.Windows.Forms.Label();
            this.txtHindi = new System.Windows.Forms.TextBox();
            this.lblReq3 = new System.Windows.Forms.Label();
            this.lblHindi = new System.Windows.Forms.Label();
            this.txtEnglish = new System.Windows.Forms.TextBox();
            this.lblEnglish = new System.Windows.Forms.Label();
            this.pbCross = new System.Windows.Forms.PictureBox();
            this.pbTick = new System.Windows.Forms.PictureBox();
            this.pbCrossHindi = new System.Windows.Forms.PictureBox();
            this.pbTickHindi = new System.Windows.Forms.PictureBox();
            this.pbCrossRegional = new System.Windows.Forms.PictureBox();
            this.pbTickBitmap = new System.Windows.Forms.PictureBox();
            this.lblNoDataToDisplay = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLanguageSettingsTable)).BeginInit();
            this.pnlCreateLanguageStatus.SuspendLayout();
            this.pnlCreateCoach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCross)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrossHindi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTickHindi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrossRegional)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTickBitmap)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRegionalLanguageStatus
            // 
            this.lblRegionalLanguageStatus.AutoSize = true;
            this.lblRegionalLanguageStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegionalLanguageStatus.ForeColor = System.Drawing.Color.Red;
            this.lblRegionalLanguageStatus.Location = new System.Drawing.Point(15, 6);
            this.lblRegionalLanguageStatus.Name = "lblRegionalLanguageStatus";
            this.lblRegionalLanguageStatus.Size = new System.Drawing.Size(254, 24);
            this.lblRegionalLanguageStatus.TabIndex = 0;
            this.lblRegionalLanguageStatus.Text = "Regional Language Status";
            // 
            // dgvLanguageSettingsTable
            // 
            this.dgvLanguageSettingsTable.AllowUserToAddRows = false;
            this.dgvLanguageSettingsTable.AllowUserToResizeColumns = false;
            this.dgvLanguageSettingsTable.AllowUserToResizeRows = false;
            this.dgvLanguageSettingsTable.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLanguageSettingsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLanguageSettingsTable.ColumnHeadersHeight = 35;
            this.dgvLanguageSettingsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column,
            this.English,
            this.Hindi,
            this.RegionalLanguage});
            this.dgvLanguageSettingsTable.Location = new System.Drawing.Point(16, 40);
            this.dgvLanguageSettingsTable.Name = "dgvLanguageSettingsTable";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLanguageSettingsTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvLanguageSettingsTable.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.dgvLanguageSettingsTable.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvLanguageSettingsTable.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.PowderBlue;
            this.dgvLanguageSettingsTable.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLanguageSettingsTable.RowTemplate.Height = 25;
            this.dgvLanguageSettingsTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvLanguageSettingsTable.Size = new System.Drawing.Size(1243, 187);
            this.dgvLanguageSettingsTable.TabIndex = 1;
            this.dgvLanguageSettingsTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLanguageSettingsTable_CellClick);
            // 
            // Column
            // 
            this.Column.HeaderText = "";
            this.Column.Image = global::ArecaIPIS.Properties.Resources.edit;
            this.Column.Name = "Column";
            // 
            // English
            // 
            this.English.HeaderText = "English";
            this.English.Name = "English";
            this.English.Width = 380;
            // 
            // Hindi
            // 
            this.Hindi.HeaderText = "Hindi";
            this.Hindi.Name = "Hindi";
            this.Hindi.Width = 380;
            // 
            // RegionalLanguage
            // 
            this.RegionalLanguage.HeaderText = "Regional Language";
            this.RegionalLanguage.Name = "RegionalLanguage";
            this.RegionalLanguage.Width = 390;
            // 
            // btnDropdown
            // 
            this.btnDropdown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDropdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDropdown.Image = global::ArecaIPIS.Properties.Resources.descending_down;
            this.btnDropdown.Location = new System.Drawing.Point(1202, 4);
            this.btnDropdown.Name = "btnDropdown";
            this.btnDropdown.Size = new System.Drawing.Size(46, 31);
            this.btnDropdown.TabIndex = 30;
            this.btnDropdown.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(1022, 11);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(140, 20);
            this.txtSearch.TabIndex = 27;
            this.txtSearch.Text = "Search Here";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            // 
            // btnCross
            // 
            this.btnCross.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCross.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCross.Image = global::ArecaIPIS.Properties.Resources._4879885_close_cross_delete_remove_icon;
            this.btnCross.Location = new System.Drawing.Point(1159, 4);
            this.btnCross.Name = "btnCross";
            this.btnCross.Size = new System.Drawing.Size(46, 31);
            this.btnCross.TabIndex = 29;
            this.btnCross.UseVisualStyleBackColor = false;
            this.btnCross.Click += new System.EventHandler(this.btnCross_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::ArecaIPIS.Properties.Resources._352091_search_icon;
            this.btnSearch.Location = new System.Drawing.Point(1159, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(46, 31);
            this.btnSearch.TabIndex = 28;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlPagination
            // 
            this.pnlPagination.BackColor = System.Drawing.Color.Green;
            this.pnlPagination.Location = new System.Drawing.Point(16, 227);
            this.pnlPagination.Name = "pnlPagination";
            this.pnlPagination.Size = new System.Drawing.Size(1243, 66);
            this.pnlPagination.TabIndex = 31;
            // 
            // pnlCreateLanguageStatus
            // 
            this.pnlCreateLanguageStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCreateLanguageStatus.Controls.Add(this.button2);
            this.pnlCreateLanguageStatus.Controls.Add(this.pnlCreateCoach);
            this.pnlCreateLanguageStatus.Controls.Add(this.label2);
            this.pnlCreateLanguageStatus.Controls.Add(this.lblNoteDef2);
            this.pnlCreateLanguageStatus.Controls.Add(this.label4);
            this.pnlCreateLanguageStatus.Controls.Add(this.label3);
            this.pnlCreateLanguageStatus.Controls.Add(this.lblRegionalName);
            this.pnlCreateLanguageStatus.Controls.Add(this.lblHindiCoach);
            this.pnlCreateLanguageStatus.Controls.Add(this.lblEnglishCoach);
            this.pnlCreateLanguageStatus.Controls.Add(this.button1);
            this.pnlCreateLanguageStatus.Controls.Add(this.btnClose);
            this.pnlCreateLanguageStatus.Controls.Add(this.btnSave);
            this.pnlCreateLanguageStatus.Controls.Add(this.txtRLanguage);
            this.pnlCreateLanguageStatus.Controls.Add(this.lblBitmap);
            this.pnlCreateLanguageStatus.Controls.Add(this.txtHindi);
            this.pnlCreateLanguageStatus.Controls.Add(this.lblReq3);
            this.pnlCreateLanguageStatus.Controls.Add(this.lblHindi);
            this.pnlCreateLanguageStatus.Controls.Add(this.txtEnglish);
            this.pnlCreateLanguageStatus.Controls.Add(this.lblEnglish);
            this.pnlCreateLanguageStatus.Controls.Add(this.pbCross);
            this.pnlCreateLanguageStatus.Controls.Add(this.pbTick);
            this.pnlCreateLanguageStatus.Controls.Add(this.pbCrossHindi);
            this.pnlCreateLanguageStatus.Controls.Add(this.pbTickHindi);
            this.pnlCreateLanguageStatus.Controls.Add(this.pbCrossRegional);
            this.pnlCreateLanguageStatus.Controls.Add(this.pbTickBitmap);
            this.pnlCreateLanguageStatus.Location = new System.Drawing.Point(19, 294);
            this.pnlCreateLanguageStatus.Name = "pnlCreateLanguageStatus";
            this.pnlCreateLanguageStatus.Size = new System.Drawing.Size(1243, 165);
            this.pnlCreateLanguageStatus.TabIndex = 32;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::ArecaIPIS.Properties.Resources._3671786_keyboard_icon__1_;
            this.button2.Location = new System.Drawing.Point(450, 100);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(23, 19);
            this.button2.TabIndex = 111;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // pnlCreateCoach
            // 
            this.pnlCreateCoach.BackColor = System.Drawing.Color.MediumAquamarine;
            this.pnlCreateCoach.Controls.Add(this.lblCreateCoach);
            this.pnlCreateCoach.Location = new System.Drawing.Point(0, 0);
            this.pnlCreateCoach.Name = "pnlCreateCoach";
            this.pnlCreateCoach.Size = new System.Drawing.Size(1244, 37);
            this.pnlCreateCoach.TabIndex = 108;
            // 
            // lblCreateCoach
            // 
            this.lblCreateCoach.AutoSize = true;
            this.lblCreateCoach.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateCoach.ForeColor = System.Drawing.Color.Black;
            this.lblCreateCoach.Location = new System.Drawing.Point(15, 4);
            this.lblCreateCoach.Name = "lblCreateCoach";
            this.lblCreateCoach.Size = new System.Drawing.Size(213, 24);
            this.lblCreateCoach.TabIndex = 0;
            this.lblCreateCoach.Text = "Edit Language Status ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(74, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 110;
            this.label2.Text = "Asterisk (";
            // 
            // lblNoteDef2
            // 
            this.lblNoteDef2.AutoSize = true;
            this.lblNoteDef2.ForeColor = System.Drawing.Color.Black;
            this.lblNoteDef2.Location = new System.Drawing.Point(154, 146);
            this.lblNoteDef2.Name = "lblNoteDef2";
            this.lblNoteDef2.Size = new System.Drawing.Size(105, 13);
            this.lblNoteDef2.TabIndex = 109;
            this.lblNoteDef2.Text = ") Fields Are Required";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(130, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 24);
            this.label4.TabIndex = 108;
            this.label4.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(28, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 24);
            this.label3.TabIndex = 107;
            this.label3.Text = "*";
            // 
            // lblRegionalName
            // 
            this.lblRegionalName.AutoSize = true;
            this.lblRegionalName.ForeColor = System.Drawing.Color.Black;
            this.lblRegionalName.Location = new System.Drawing.Point(171, 122);
            this.lblRegionalName.Name = "lblRegionalName";
            this.lblRegionalName.Size = new System.Drawing.Size(207, 13);
            this.lblRegionalName.TabIndex = 106;
            this.lblRegionalName.Text = "Please Enter Status in Regional Language";
            // 
            // lblHindiCoach
            // 
            this.lblHindiCoach.AutoSize = true;
            this.lblHindiCoach.ForeColor = System.Drawing.Color.Black;
            this.lblHindiCoach.Location = new System.Drawing.Point(687, 81);
            this.lblHindiCoach.Name = "lblHindiCoach";
            this.lblHindiCoach.Size = new System.Drawing.Size(138, 13);
            this.lblHindiCoach.TabIndex = 105;
            this.lblHindiCoach.Text = "Please Enter Status in Hindi";
            // 
            // lblEnglishCoach
            // 
            this.lblEnglishCoach.AutoSize = true;
            this.lblEnglishCoach.ForeColor = System.Drawing.Color.Black;
            this.lblEnglishCoach.Location = new System.Drawing.Point(174, 80);
            this.lblEnglishCoach.Name = "lblEnglishCoach";
            this.lblEnglishCoach.Size = new System.Drawing.Size(148, 13);
            this.lblEnglishCoach.TabIndex = 104;
            this.lblEnglishCoach.Text = "Please Enter Status in English";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::ArecaIPIS.Properties.Resources._3671786_keyboard_icon__1_;
            this.button1.Location = new System.Drawing.Point(966, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 19);
            this.button1.TabIndex = 97;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = global::ArecaIPIS.Properties.Resources._4879885_close_cross_delete_remove_icon;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(808, 113);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 32);
            this.btnClose.TabIndex = 96;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = global::ArecaIPIS.Properties.Resources._1564499_accept_added_check_complite_yes_icon;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(721, 113);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 32);
            this.btnSave.TabIndex = 95;
            this.btnSave.Text = "Update";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtRLanguage
            // 
            this.txtRLanguage.Location = new System.Drawing.Point(174, 99);
            this.txtRLanguage.Name = "txtRLanguage";
            this.txtRLanguage.Size = new System.Drawing.Size(270, 20);
            this.txtRLanguage.TabIndex = 92;
            // 
            // lblBitmap
            // 
            this.lblBitmap.AutoSize = true;
            this.lblBitmap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBitmap.ForeColor = System.Drawing.Color.Black;
            this.lblBitmap.Location = new System.Drawing.Point(23, 99);
            this.lblBitmap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBitmap.Name = "lblBitmap";
            this.lblBitmap.Size = new System.Drawing.Size(144, 16);
            this.lblBitmap.TabIndex = 91;
            this.lblBitmap.Text = "Regional Language";
            // 
            // txtHindi
            // 
            this.txtHindi.Location = new System.Drawing.Point(690, 55);
            this.txtHindi.Name = "txtHindi";
            this.txtHindi.Size = new System.Drawing.Size(270, 20);
            this.txtHindi.TabIndex = 90;
            // 
            // lblReq3
            // 
            this.lblReq3.AutoSize = true;
            this.lblReq3.BackColor = System.Drawing.Color.White;
            this.lblReq3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReq3.ForeColor = System.Drawing.Color.Red;
            this.lblReq3.Location = new System.Drawing.Point(539, 52);
            this.lblReq3.Name = "lblReq3";
            this.lblReq3.Size = new System.Drawing.Size(18, 24);
            this.lblReq3.TabIndex = 89;
            this.lblReq3.Text = "*";
            // 
            // lblHindi
            // 
            this.lblHindi.AutoSize = true;
            this.lblHindi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHindi.ForeColor = System.Drawing.Color.Black;
            this.lblHindi.Location = new System.Drawing.Point(559, 55);
            this.lblHindi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHindi.Name = "lblHindi";
            this.lblHindi.Size = new System.Drawing.Size(44, 16);
            this.lblHindi.TabIndex = 88;
            this.lblHindi.Text = "Hindi";
            // 
            // txtEnglish
            // 
            this.txtEnglish.Location = new System.Drawing.Point(174, 54);
            this.txtEnglish.Name = "txtEnglish";
            this.txtEnglish.Size = new System.Drawing.Size(270, 20);
            this.txtEnglish.TabIndex = 87;
            // 
            // lblEnglish
            // 
            this.lblEnglish.AutoSize = true;
            this.lblEnglish.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnglish.ForeColor = System.Drawing.Color.Black;
            this.lblEnglish.Location = new System.Drawing.Point(43, 52);
            this.lblEnglish.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnglish.Name = "lblEnglish";
            this.lblEnglish.Size = new System.Drawing.Size(59, 16);
            this.lblEnglish.TabIndex = 86;
            this.lblEnglish.Text = "English";
            // 
            // pbCross
            // 
            this.pbCross.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pbCross.Image = global::ArecaIPIS.Properties.Resources._282471_cross_remove_delete_icon;
            this.pbCross.ImageLocation = "";
            this.pbCross.Location = new System.Drawing.Point(483, 55);
            this.pbCross.Name = "pbCross";
            this.pbCross.Size = new System.Drawing.Size(25, 20);
            this.pbCross.TabIndex = 98;
            this.pbCross.TabStop = false;
            // 
            // pbTick
            // 
          //  this.pbTick.Image = global::ArecaIPIS.Properties.Resources._1398911_correct_mark_success_tick_valid_icon;
            this.pbTick.ImageLocation = "";
            this.pbTick.Location = new System.Drawing.Point(483, 55);
            this.pbTick.Name = "pbTick";
            this.pbTick.Size = new System.Drawing.Size(25, 20);
            this.pbTick.TabIndex = 99;
            this.pbTick.TabStop = false;
            // 
            // pbCrossHindi
            // 
            this.pbCrossHindi.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pbCrossHindi.Image = global::ArecaIPIS.Properties.Resources._282471_cross_remove_delete_icon;
            this.pbCrossHindi.ImageLocation = "";
            this.pbCrossHindi.Location = new System.Drawing.Point(995, 54);
            this.pbCrossHindi.Name = "pbCrossHindi";
            this.pbCrossHindi.Size = new System.Drawing.Size(25, 20);
            this.pbCrossHindi.TabIndex = 102;
            this.pbCrossHindi.TabStop = false;
            // 
            // pbTickHindi
            // 
           // this.pbTickHindi.Image = global::ArecaIPIS.Properties.Resources._1398911_correct_mark_success_tick_valid_icon;
            this.pbTickHindi.ImageLocation = "";
            this.pbTickHindi.Location = new System.Drawing.Point(995, 54);
            this.pbTickHindi.Name = "pbTickHindi";
            this.pbTickHindi.Size = new System.Drawing.Size(25, 20);
            this.pbTickHindi.TabIndex = 103;
            this.pbTickHindi.TabStop = false;
            // 
            // pbCrossRegional
            // 
            this.pbCrossRegional.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pbCrossRegional.Image = global::ArecaIPIS.Properties.Resources._282471_cross_remove_delete_icon;
            this.pbCrossRegional.ImageLocation = "";
            this.pbCrossRegional.Location = new System.Drawing.Point(483, 99);
            this.pbCrossRegional.Name = "pbCrossRegional";
            this.pbCrossRegional.Size = new System.Drawing.Size(25, 20);
            this.pbCrossRegional.TabIndex = 100;
            this.pbCrossRegional.TabStop = false;
            // 
            // pbTickBitmap
            // 
         //   this.pbTickBitmap.Image = global::ArecaIPIS.Properties.Resources._1398911_correct_mark_success_tick_valid_icon;
            this.pbTickBitmap.ImageLocation = "";
            this.pbTickBitmap.Location = new System.Drawing.Point(483, 99);
            this.pbTickBitmap.Name = "pbTickBitmap";
            this.pbTickBitmap.Size = new System.Drawing.Size(25, 20);
            this.pbTickBitmap.TabIndex = 101;
            this.pbTickBitmap.TabStop = false;
            // 
            // lblNoDataToDisplay
            // 
            this.lblNoDataToDisplay.AutoSize = true;
            this.lblNoDataToDisplay.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lblNoDataToDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoDataToDisplay.ForeColor = System.Drawing.Color.Black;
            this.lblNoDataToDisplay.Location = new System.Drawing.Point(415, 112);
            this.lblNoDataToDisplay.Name = "lblNoDataToDisplay";
            this.lblNoDataToDisplay.Size = new System.Drawing.Size(216, 25);
            this.lblNoDataToDisplay.TabIndex = 109;
            this.lblNoDataToDisplay.Text = "No Data To Display";
            // 
            // frmRegionalLanguageStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 461);
            this.Controls.Add(this.lblNoDataToDisplay);
            this.Controls.Add(this.pnlCreateLanguageStatus);
            this.Controls.Add(this.pnlPagination);
            this.Controls.Add(this.btnDropdown);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvLanguageSettingsTable);
            this.Controls.Add(this.lblRegionalLanguageStatus);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnCross);
            this.Name = "frmRegionalLanguageStatus";
            this.Text = "frmRegionalLanguageStatus";
            this.Load += new System.EventHandler(this.frmRegionalLanguageStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLanguageSettingsTable)).EndInit();
            this.pnlCreateLanguageStatus.ResumeLayout(false);
            this.pnlCreateLanguageStatus.PerformLayout();
            this.pnlCreateCoach.ResumeLayout(false);
            this.pnlCreateCoach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCross)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrossHindi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTickHindi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCrossRegional)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTickBitmap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRegionalLanguageStatus;
        private System.Windows.Forms.DataGridView dgvLanguageSettingsTable;
        private System.Windows.Forms.Button btnDropdown;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnCross;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlPagination;
        private System.Windows.Forms.DataGridViewImageColumn Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn English;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hindi;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegionalLanguage;
        private System.Windows.Forms.Panel pnlCreateLanguageStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRegionalName;
        private System.Windows.Forms.Label lblHindiCoach;
        private System.Windows.Forms.Label lblEnglishCoach;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtRLanguage;
        private System.Windows.Forms.Label lblBitmap;
        private System.Windows.Forms.TextBox txtHindi;
        private System.Windows.Forms.Label lblReq3;
        private System.Windows.Forms.Label lblHindi;
        private System.Windows.Forms.TextBox txtEnglish;
        private System.Windows.Forms.Label lblEnglish;
        private System.Windows.Forms.PictureBox pbCross;
        private System.Windows.Forms.PictureBox pbTick;
        private System.Windows.Forms.PictureBox pbCrossHindi;
        private System.Windows.Forms.PictureBox pbTickHindi;
        private System.Windows.Forms.PictureBox pbCrossRegional;
        private System.Windows.Forms.PictureBox pbTickBitmap;
        private System.Windows.Forms.Panel pnlCreateCoach;
        private System.Windows.Forms.Label lblCreateCoach;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNoteDef2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblNoDataToDisplay;
    }
}
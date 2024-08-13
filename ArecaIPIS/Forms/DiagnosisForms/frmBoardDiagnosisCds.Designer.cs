
namespace ArecaIPIS.Forms
{
    partial class frmBoardDiagnosisCds
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
            this.dgvCommunication = new System.Windows.Forms.DataGridView();
            this.lblCommunication = new System.Windows.Forms.Label();
            this.panCommunication = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbErrorData = new System.Windows.Forms.ComboBox();
            this.btnErrorData = new System.Windows.Forms.Button();
            this.btnDeleteData = new System.Windows.Forms.Button();
            this.btnSetConfiguration = new System.Windows.Forms.Button();
            this.btnSoftReset = new System.Windows.Forms.Button();
            this.btnGetConfiguration = new System.Windows.Forms.Button();
            this.btnLinkCheckAll = new System.Windows.Forms.Button();
            this.btnLinkCheck = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgvcheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvPDCName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPortNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPdcIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPlatformNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTemperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvConfiguration = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommunication)).BeginInit();
            this.panCommunication.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCommunication
            // 
            this.dgvCommunication.AllowUserToAddRows = false;
            this.dgvCommunication.AllowUserToResizeColumns = false;
            this.dgvCommunication.AllowUserToResizeRows = false;
            this.dgvCommunication.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCommunication.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCommunication.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Turquoise;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCommunication.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCommunication.ColumnHeadersHeight = 35;
            this.dgvCommunication.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCommunication.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcheckBox,
            this.dgvPDCName,
            this.dgvPortNo,
            this.dgvPdcIp,
            this.dgvPlatformNo,
            this.dgvTemperature,
            this.dgvConfiguration});
            this.dgvCommunication.EnableHeadersVisualStyles = false;
            this.dgvCommunication.Location = new System.Drawing.Point(4, 34);
            this.dgvCommunication.Name = "dgvCommunication";
            this.dgvCommunication.RowHeadersVisible = false;
            this.dgvCommunication.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCommunication.Size = new System.Drawing.Size(975, 285);
            this.dgvCommunication.TabIndex = 4;
            this.dgvCommunication.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCommunication_CellFormatting);
            this.dgvCommunication.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCommunication_CellValueChanged);
            this.dgvCommunication.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvCommunication_CurrentCellDirtyStateChanged);
            // 
            // lblCommunication
            // 
            this.lblCommunication.AutoSize = true;
            this.lblCommunication.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommunication.ForeColor = System.Drawing.Color.Ivory;
            this.lblCommunication.Location = new System.Drawing.Point(3, 4);
            this.lblCommunication.Name = "lblCommunication";
            this.lblCommunication.Size = new System.Drawing.Size(306, 24);
            this.lblCommunication.TabIndex = 0;
            this.lblCommunication.Text = "Communication Hub Link Status";
            // 
            // panCommunication
            // 
            this.panCommunication.BackColor = System.Drawing.Color.OliveDrab;
            this.panCommunication.Controls.Add(this.lblCommunication);
            this.panCommunication.ForeColor = System.Drawing.Color.OliveDrab;
            this.panCommunication.Location = new System.Drawing.Point(1, 4);
            this.panCommunication.Name = "panCommunication";
            this.panCommunication.Size = new System.Drawing.Size(975, 28);
            this.panCommunication.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbErrorData);
            this.panel1.Controls.Add(this.btnErrorData);
            this.panel1.Controls.Add(this.btnDeleteData);
            this.panel1.Controls.Add(this.btnSetConfiguration);
            this.panel1.Controls.Add(this.btnSoftReset);
            this.panel1.Controls.Add(this.btnGetConfiguration);
            this.panel1.Controls.Add(this.btnLinkCheckAll);
            this.panel1.Controls.Add(this.btnLinkCheck);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(-3, 368);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(985, 38);
            this.panel1.TabIndex = 8;
            // 
            // cmbErrorData
            // 
            this.cmbErrorData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cmbErrorData.FormattingEnabled = true;
            this.cmbErrorData.Items.AddRange(new object[] {
            "Crc Fail",
            "Invalid Des Add",
            "Invalid Src Add",
            "Invalid Fc ",
            "Invalid Data"});
            this.cmbErrorData.Location = new System.Drawing.Point(775, 4);
            this.cmbErrorData.Name = "cmbErrorData";
            this.cmbErrorData.Size = new System.Drawing.Size(95, 24);
            this.cmbErrorData.TabIndex = 10;
            this.cmbErrorData.Text = "Crc Fail";
            // 
            // btnErrorData
            // 
            this.btnErrorData.BackColor = System.Drawing.Color.Cyan;
            this.btnErrorData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnErrorData.Location = new System.Drawing.Point(871, -1);
            this.btnErrorData.Name = "btnErrorData";
            this.btnErrorData.Size = new System.Drawing.Size(110, 32);
            this.btnErrorData.TabIndex = 9;
            this.btnErrorData.Text = "ERROR DATA";
            this.btnErrorData.UseVisualStyleBackColor = false;
            // 
            // btnDeleteData
            // 
            this.btnDeleteData.BackColor = System.Drawing.Color.Cyan;
            this.btnDeleteData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnDeleteData.Location = new System.Drawing.Point(540, -1);
            this.btnDeleteData.Name = "btnDeleteData";
            this.btnDeleteData.Size = new System.Drawing.Size(114, 32);
            this.btnDeleteData.TabIndex = 8;
            this.btnDeleteData.Text = "DELETE DATA";
            this.btnDeleteData.UseVisualStyleBackColor = false;
            // 
            // btnSetConfiguration
            // 
            this.btnSetConfiguration.BackColor = System.Drawing.Color.Cyan;
            this.btnSetConfiguration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnSetConfiguration.Location = new System.Drawing.Point(376, -1);
            this.btnSetConfiguration.Name = "btnSetConfiguration";
            this.btnSetConfiguration.Size = new System.Drawing.Size(167, 32);
            this.btnSetConfiguration.TabIndex = 7;
            this.btnSetConfiguration.Text = "SET CONFIGURATION";
            this.btnSetConfiguration.UseVisualStyleBackColor = false;
            // 
            // btnSoftReset
            // 
            this.btnSoftReset.BackColor = System.Drawing.Color.Cyan;
            this.btnSoftReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnSoftReset.Location = new System.Drawing.Point(111, -1);
            this.btnSoftReset.Name = "btnSoftReset";
            this.btnSoftReset.Size = new System.Drawing.Size(106, 32);
            this.btnSoftReset.TabIndex = 3;
            this.btnSoftReset.Text = "SOFT RESET";
            this.btnSoftReset.UseVisualStyleBackColor = false;
            // 
            // btnGetConfiguration
            // 
            this.btnGetConfiguration.BackColor = System.Drawing.Color.Cyan;
            this.btnGetConfiguration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnGetConfiguration.Location = new System.Drawing.Point(217, -1);
            this.btnGetConfiguration.Name = "btnGetConfiguration";
            this.btnGetConfiguration.Size = new System.Drawing.Size(160, 32);
            this.btnGetConfiguration.TabIndex = 2;
            this.btnGetConfiguration.Text = "GET CONFIGURATION";
            this.btnGetConfiguration.UseVisualStyleBackColor = false;
            // 
            // btnLinkCheckAll
            // 
            this.btnLinkCheckAll.BackColor = System.Drawing.Color.Cyan;
            this.btnLinkCheckAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnLinkCheckAll.Location = new System.Drawing.Point(655, -1);
            this.btnLinkCheckAll.Name = "btnLinkCheckAll";
            this.btnLinkCheckAll.Size = new System.Drawing.Size(120, 32);
            this.btnLinkCheckAll.TabIndex = 1;
            this.btnLinkCheckAll.Text = "LINK CHECK ALL";
            this.btnLinkCheckAll.UseVisualStyleBackColor = false;
            // 
            // btnLinkCheck
            // 
            this.btnLinkCheck.BackColor = System.Drawing.Color.Cyan;
            this.btnLinkCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLinkCheck.Location = new System.Drawing.Point(6, -1);
            this.btnLinkCheck.Name = "btnLinkCheck";
            this.btnLinkCheck.Size = new System.Drawing.Size(107, 32);
            this.btnLinkCheck.TabIndex = 0;
            this.btnLinkCheck.Text = "LINK  STATUS";
            this.btnLinkCheck.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox1.Enabled = false;
            this.textBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox1.Location = new System.Drawing.Point(0, 342);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(986, 20);
            this.textBox1.TabIndex = 7;
            // 
            // dgvcheckBox
            // 
            this.dgvcheckBox.FillWeight = 35.53299F;
            this.dgvcheckBox.HeaderText = "";
            this.dgvcheckBox.Name = "dgvcheckBox";
            // 
            // dgvPDCName
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.dgvPDCName.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPDCName.FillWeight = 110.7445F;
            this.dgvPDCName.HeaderText = "PDC Name";
            this.dgvPDCName.Name = "dgvPDCName";
            // 
            // dgvPortNo
            // 
            this.dgvPortNo.FillWeight = 110.7445F;
            this.dgvPortNo.HeaderText = "PORT No";
            this.dgvPortNo.Name = "dgvPortNo";
            // 
            // dgvPdcIp
            // 
            this.dgvPdcIp.FillWeight = 110.7445F;
            this.dgvPdcIp.HeaderText = "PDC IP";
            this.dgvPdcIp.Name = "dgvPdcIp";
            // 
            // dgvPlatformNo
            // 
            this.dgvPlatformNo.FillWeight = 110.7445F;
            this.dgvPlatformNo.HeaderText = "Platform No";
            this.dgvPlatformNo.Name = "dgvPlatformNo";
            // 
            // dgvTemperature
            // 
            this.dgvTemperature.FillWeight = 110.7445F;
            this.dgvTemperature.HeaderText = "Temperature";
            this.dgvTemperature.Name = "dgvTemperature";
            this.dgvTemperature.ReadOnly = true;
            // 
            // dgvConfiguration
            // 
            this.dgvConfiguration.FillWeight = 110.7445F;
            this.dgvConfiguration.HeaderText = "Configuration";
            this.dgvConfiguration.Name = "dgvConfiguration";
            this.dgvConfiguration.ReadOnly = true;
            this.dgvConfiguration.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConfiguration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // frmBoardDiagnosisCds
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1031, 418);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dgvCommunication);
            this.Controls.Add(this.panCommunication);
            this.Name = "frmBoardDiagnosisCds";
            this.Text = "frmBoardDiagnosisCds";
            this.Load += new System.EventHandler(this.frmBoardDiagnosisCds_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommunication)).EndInit();
            this.panCommunication.ResumeLayout(false);
            this.panCommunication.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCommunication;
        private System.Windows.Forms.Label lblCommunication;
        private System.Windows.Forms.Panel panCommunication;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbErrorData;
        private System.Windows.Forms.Button btnErrorData;
        private System.Windows.Forms.Button btnDeleteData;
        private System.Windows.Forms.Button btnSetConfiguration;
        private System.Windows.Forms.Button btnSoftReset;
        private System.Windows.Forms.Button btnGetConfiguration;
        private System.Windows.Forms.Button btnLinkCheckAll;
        private System.Windows.Forms.Button btnLinkCheck;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvcheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPDCName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPortNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPdcIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPlatformNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTemperature;
        private System.Windows.Forms.DataGridViewButtonColumn dgvConfiguration;
    }
}
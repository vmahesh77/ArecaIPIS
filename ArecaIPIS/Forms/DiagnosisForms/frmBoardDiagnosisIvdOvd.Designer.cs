
namespace ArecaIPIS.Forms
{
    partial class frmBoardDiagnosisIvdOvd
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
            this.lblIvdOvd = new System.Windows.Forms.Label();
            this.dgvIVDOVD = new System.Windows.Forms.DataGridView();
            this.checkbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BoardName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoardLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lines = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PortNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoardIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Temperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Configuration = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panCommunication = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvIVDOVD)).BeginInit();
            this.panCommunication.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblIvdOvd
            // 
            this.lblIvdOvd.AutoSize = true;
            this.lblIvdOvd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIvdOvd.ForeColor = System.Drawing.Color.Ivory;
            this.lblIvdOvd.Location = new System.Drawing.Point(3, 4);
            this.lblIvdOvd.Name = "lblIvdOvd";
            this.lblIvdOvd.Size = new System.Drawing.Size(340, 25);
            this.lblIvdOvd.TabIndex = 0;
            this.lblIvdOvd.Text = "IVD /OVD Display Boards Links";
            // 
            // dgvIVDOVD
            // 
            this.dgvIVDOVD.AllowUserToAddRows = false;
            this.dgvIVDOVD.AllowUserToDeleteRows = false;
            this.dgvIVDOVD.AllowUserToResizeColumns = false;
            this.dgvIVDOVD.AllowUserToResizeRows = false;
            this.dgvIVDOVD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIVDOVD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Turquoise;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIVDOVD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIVDOVD.ColumnHeadersHeight = 42;
            this.dgvIVDOVD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvIVDOVD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkbox,
            this.BoardName,
            this.BoardLocation,
            this.Lines,
            this.PortNo,
            this.ID,
            this.BoardIP,
            this.Temperature,
            this.Configuration});
            this.dgvIVDOVD.EnableHeadersVisualStyles = false;
            this.dgvIVDOVD.Location = new System.Drawing.Point(17, 35);
            this.dgvIVDOVD.Name = "dgvIVDOVD";
            this.dgvIVDOVD.RowHeadersVisible = false;
            this.dgvIVDOVD.Size = new System.Drawing.Size(1007, 305);
            this.dgvIVDOVD.TabIndex = 8;
            // 
            // checkbox
            // 
            this.checkbox.HeaderText = "";
            this.checkbox.Name = "checkbox";
            // 
            // BoardName
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Turquoise;
            this.BoardName.DefaultCellStyle = dataGridViewCellStyle2;
            this.BoardName.HeaderText = "Board Name";
            this.BoardName.Name = "BoardName";
            // 
            // BoardLocation
            // 
            this.BoardLocation.HeaderText = "Board Location";
            this.BoardLocation.Name = "BoardLocation";
            this.BoardLocation.ReadOnly = true;
            // 
            // Lines
            // 
            this.Lines.HeaderText = "Lines";
            this.Lines.Name = "Lines";
            // 
            // PortNo
            // 
            this.PortNo.HeaderText = "PORT No";
            this.PortNo.Name = "PortNo";
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // BoardIP
            // 
            this.BoardIP.HeaderText = "Board IP";
            this.BoardIP.Name = "BoardIP";
            // 
            // Temperature
            // 
            this.Temperature.HeaderText = "Temperature";
            this.Temperature.Name = "Temperature";
            this.Temperature.ReadOnly = true;
            // 
            // Configuration
            // 
            this.Configuration.HeaderText = "Configuration";
            this.Configuration.Name = "Configuration";
            this.Configuration.ReadOnly = true;
            this.Configuration.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Configuration.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // panCommunication
            // 
            this.panCommunication.BackColor = System.Drawing.Color.OliveDrab;
            this.panCommunication.Controls.Add(this.lblIvdOvd);
            this.panCommunication.ForeColor = System.Drawing.Color.OliveDrab;
            this.panCommunication.Location = new System.Drawing.Point(12, 3);
            this.panCommunication.Name = "panCommunication";
            this.panCommunication.Size = new System.Drawing.Size(1007, 26);
            this.panCommunication.TabIndex = 7;
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
            this.panel1.Location = new System.Drawing.Point(17, 372);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(985, 37);
            this.panel1.TabIndex = 12;
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
            this.cmbErrorData.Location = new System.Drawing.Point(775, 8);
            this.cmbErrorData.Name = "cmbErrorData";
            this.cmbErrorData.Size = new System.Drawing.Size(95, 24);
            this.cmbErrorData.TabIndex = 10;
            this.cmbErrorData.Text = "Crc Fail";
            // 
            // btnErrorData
            // 
            this.btnErrorData.BackColor = System.Drawing.Color.Cyan;
            this.btnErrorData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnErrorData.Location = new System.Drawing.Point(871, 3);
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
            this.btnDeleteData.Location = new System.Drawing.Point(542, 3);
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
            this.btnSetConfiguration.Location = new System.Drawing.Point(380, 3);
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
            this.btnSoftReset.Location = new System.Drawing.Point(108, 3);
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
            this.btnGetConfiguration.Location = new System.Drawing.Point(221, 3);
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
            this.btnLinkCheckAll.Location = new System.Drawing.Point(653, 3);
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
            this.btnLinkCheck.Location = new System.Drawing.Point(3, 3);
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
            this.textBox1.Location = new System.Drawing.Point(20, 346);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(986, 20);
            this.textBox1.TabIndex = 11;
            // 
            // frmBoardDiagnosisIvdOvd
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1031, 418);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dgvIVDOVD);
            this.Controls.Add(this.panCommunication);
            this.Name = "frmBoardDiagnosisIvdOvd";
            this.Text = "frmBoardDiagnosisIvdOvd";
            ((System.ComponentModel.ISupportInitialize)(this.dgvIVDOVD)).EndInit();
            this.panCommunication.ResumeLayout(false);
            this.panCommunication.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIvdOvd;
        private System.Windows.Forms.DataGridView dgvIVDOVD;
        private System.Windows.Forms.Panel panCommunication;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoardName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoardLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lines;
        private System.Windows.Forms.DataGridViewTextBoxColumn PortNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoardIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Temperature;
        private System.Windows.Forms.DataGridViewButtonColumn Configuration;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
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
    }
}
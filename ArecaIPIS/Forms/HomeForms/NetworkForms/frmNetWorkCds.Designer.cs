
namespace ArecaIPIS.Forms
{
    partial class frmNetWorkCds
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
            this.lblCommunication = new System.Windows.Forms.Label();
            this.panCommunication = new System.Windows.Forms.Panel();
            this.dgvCommunication = new System.Windows.Forms.DataGridView();
            this.PDCName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PortNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PdcIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlatformNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Temperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Configuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panCommunication.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommunication)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCommunication
            // 
            this.lblCommunication.AutoSize = true;
            this.lblCommunication.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommunication.ForeColor = System.Drawing.Color.Ivory;
            this.lblCommunication.Location = new System.Drawing.Point(3, 7);
            this.lblCommunication.Name = "lblCommunication";
            this.lblCommunication.Size = new System.Drawing.Size(347, 25);
            this.lblCommunication.TabIndex = 0;
            this.lblCommunication.Text = "Communication Hub Link Status";
            this.lblCommunication.Click += new System.EventHandler(this.lblCommunication_Click);
            // 
            // panCommunication
            // 
            this.panCommunication.BackColor = System.Drawing.Color.OliveDrab;
            this.panCommunication.Controls.Add(this.lblCommunication);
            this.panCommunication.ForeColor = System.Drawing.Color.OliveDrab;
            this.panCommunication.Location = new System.Drawing.Point(2, 2);
            this.panCommunication.Name = "panCommunication";
            this.panCommunication.Size = new System.Drawing.Size(1238, 37);
            this.panCommunication.TabIndex = 1;
            this.panCommunication.Paint += new System.Windows.Forms.PaintEventHandler(this.panCommunication_Paint);
            // 
            // dgvCommunication
            // 
            this.dgvCommunication.AllowUserToAddRows = false;
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
            this.dgvCommunication.ColumnHeadersHeight = 53;
            this.dgvCommunication.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PDCName,
            this.PortNo,
            this.PdcIp,
            this.PlatformNo,
            this.Temperature,
            this.Configuration});
            this.dgvCommunication.EnableHeadersVisualStyles = false;
            this.dgvCommunication.Location = new System.Drawing.Point(2, 45);
            this.dgvCommunication.Name = "dgvCommunication";
            this.dgvCommunication.RowHeadersVisible = false;
            this.dgvCommunication.Size = new System.Drawing.Size(1238, 546);
            this.dgvCommunication.TabIndex = 2;
            this.dgvCommunication.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCommunication_CellContentClick);
            // 
            // PDCName
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Turquoise;
            this.PDCName.DefaultCellStyle = dataGridViewCellStyle2;
            this.PDCName.HeaderText = "PDC Name";
            this.PDCName.Name = "PDCName";
            // 
            // PortNo
            // 
            this.PortNo.HeaderText = "PORT No";
            this.PortNo.Name = "PortNo";
            // 
            // PdcIp
            // 
            this.PdcIp.HeaderText = "PDC IP";
            this.PdcIp.Name = "PdcIp";
            // 
            // PlatformNo
            // 
            this.PlatformNo.HeaderText = "Platform No";
            this.PlatformNo.Name = "PlatformNo";
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
            // 
            // frmNetWorkCds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 645);
            this.Controls.Add(this.dgvCommunication);
            this.Controls.Add(this.panCommunication);
            this.Name = "frmNetWorkCds";
            this.Text = "frmCds";
            this.panCommunication.ResumeLayout(false);
            this.panCommunication.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommunication)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCommunication;
        private System.Windows.Forms.Panel panCommunication;
        private System.Windows.Forms.DataGridView dgvCommunication;
        private System.Windows.Forms.DataGridViewTextBoxColumn PDCName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PortNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PdcIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlatformNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Temperature;
        private System.Windows.Forms.DataGridViewTextBoxColumn Configuration;
    }
}
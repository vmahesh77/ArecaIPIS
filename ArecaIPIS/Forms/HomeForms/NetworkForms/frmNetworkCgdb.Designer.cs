
namespace ArecaIPIS.Forms
{
    partial class frmNetworkCgdb
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
            this.lblCoachGuidance = new System.Windows.Forms.Label();
            this.dgvCommunication = new System.Windows.Forms.DataGridView();
            this.panCommunication = new System.Windows.Forms.Panel();
            this.PortNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoachId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HubId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PdcIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Temperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Configuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommunication)).BeginInit();
            this.panCommunication.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCoachGuidance
            // 
            this.lblCoachGuidance.AutoSize = true;
            this.lblCoachGuidance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoachGuidance.ForeColor = System.Drawing.Color.Ivory;
            this.lblCoachGuidance.Location = new System.Drawing.Point(3, 7);
            this.lblCoachGuidance.Name = "lblCoachGuidance";
            this.lblCoachGuidance.Size = new System.Drawing.Size(403, 25);
            this.lblCoachGuidance.TabIndex = 0;
            this.lblCoachGuidance.Text = "Coach Guidance Display Board Links";
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
            this.PortNo,
            this.CoachId,
            this.HubId,
            this.PdcIp,
            this.Temperature,
            this.Configuration});
            this.dgvCommunication.EnableHeadersVisualStyles = false;
            this.dgvCommunication.Location = new System.Drawing.Point(2, 46);
            this.dgvCommunication.Name = "dgvCommunication";
            this.dgvCommunication.RowHeadersVisible = false;
            this.dgvCommunication.Size = new System.Drawing.Size(1238, 546);
            this.dgvCommunication.TabIndex = 4;
            // 
            // panCommunication
            // 
            this.panCommunication.BackColor = System.Drawing.Color.OliveDrab;
            this.panCommunication.Controls.Add(this.lblCoachGuidance);
            this.panCommunication.ForeColor = System.Drawing.Color.OliveDrab;
            this.panCommunication.Location = new System.Drawing.Point(2, 3);
            this.panCommunication.Name = "panCommunication";
            this.panCommunication.Size = new System.Drawing.Size(1238, 37);
            this.panCommunication.TabIndex = 3;
            // 
            // PortNo
            // 
            this.PortNo.HeaderText = "PORT No";
            this.PortNo.Name = "PortNo";
            // 
            // CoachId
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Turquoise;
            this.CoachId.DefaultCellStyle = dataGridViewCellStyle2;
            this.CoachId.HeaderText = "Coach ID";
            this.CoachId.Name = "CoachId";
            // 
            // HubId
            // 
            this.HubId.HeaderText = "Hub ID";
            this.HubId.Name = "HubId";
            // 
            // PdcIp
            // 
            this.PdcIp.HeaderText = "PDC IP";
            this.PdcIp.Name = "PdcIp";
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
            // frmNetworkCgdb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 645);
            this.Controls.Add(this.dgvCommunication);
            this.Controls.Add(this.panCommunication);
            this.Name = "frmNetworkCgdb";
            this.Text = "frmNetworkCgdb";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommunication)).EndInit();
            this.panCommunication.ResumeLayout(false);
            this.panCommunication.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCoachGuidance;
        private System.Windows.Forms.DataGridView dgvCommunication;
        private System.Windows.Forms.Panel panCommunication;
        private System.Windows.Forms.DataGridViewTextBoxColumn PortNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoachId;
        private System.Windows.Forms.DataGridViewTextBoxColumn HubId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PdcIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Temperature;
        private System.Windows.Forms.DataGridViewTextBoxColumn Configuration;
    }
}
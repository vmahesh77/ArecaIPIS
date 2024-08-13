
namespace ArecaIPIS.Forms
{
    partial class frmNetworkTadb
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
            this.lblTrainArrival = new System.Windows.Forms.Label();
            this.dgvCommunication = new System.Windows.Forms.DataGridView();
            this.panCommunication = new System.Windows.Forms.Panel();
            this.BoardName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoardLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lines = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PortNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoardIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Temperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Configuration = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommunication)).BeginInit();
            this.panCommunication.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTrainArrival
            // 
            this.lblTrainArrival.AutoSize = true;
            this.lblTrainArrival.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrainArrival.ForeColor = System.Drawing.Color.Ivory;
            this.lblTrainArrival.Location = new System.Drawing.Point(3, 7);
            this.lblTrainArrival.Name = "lblTrainArrival";
            this.lblTrainArrival.Size = new System.Drawing.Size(481, 25);
            this.lblTrainArrival.TabIndex = 0;
            this.lblTrainArrival.Text = "Train Arrival Departure Display Boards Links";
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
            this.dgvCommunication.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommunication.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BoardName,
            this.BoardLocation,
            this.Lines,
            this.PortNo,
            this.ID,
            this.BoardIP,
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
            this.panCommunication.Controls.Add(this.lblTrainArrival);
            this.panCommunication.ForeColor = System.Drawing.Color.OliveDrab;
            this.panCommunication.Location = new System.Drawing.Point(0, 3);
            this.panCommunication.Name = "panCommunication";
            this.panCommunication.Size = new System.Drawing.Size(1238, 37);
            this.panCommunication.TabIndex = 3;
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
            // frmNetworkTadb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 645);
            this.Controls.Add(this.dgvCommunication);
            this.Controls.Add(this.panCommunication);
            this.Name = "frmNetworkTadb";
            this.Text = "frmNetworkTadb";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommunication)).EndInit();
            this.panCommunication.ResumeLayout(false);
            this.panCommunication.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTrainArrival;
        private System.Windows.Forms.DataGridView dgvCommunication;
        private System.Windows.Forms.Panel panCommunication;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoardName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoardLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lines;
        private System.Windows.Forms.DataGridViewTextBoxColumn PortNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoardIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Temperature;
        private System.Windows.Forms.DataGridViewButtonColumn Configuration;
    }
}
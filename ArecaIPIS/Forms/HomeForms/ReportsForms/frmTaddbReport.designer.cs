
namespace ArecaIPIS.Forms
{
    partial class frmTaddbReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTo = new System.Windows.Forms.Label();
            this.dGVTADDBReport = new System.Windows.Forms.DataGridView();
            this.SNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrainNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrainName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArrDeptTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AorD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PFNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtToDate = new System.Windows.Forms.TextBox();
            this.txtFromdate = new System.Windows.Forms.TextBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.cmbExport = new System.Windows.Forms.ComboBox();
            this.lblExport = new System.Windows.Forms.Label();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.cmbTrainStatus = new System.Windows.Forms.ComboBox();
            this.lblTrainStatus = new System.Windows.Forms.Label();
            this.lblNoData = new System.Windows.Forms.Label();
            this.pnlNoDisplay = new System.Windows.Forms.Panel();
            this.pnlMenuOption = new System.Windows.Forms.Panel();
            this.lblFrom = new System.Windows.Forms.Label();
            this.pnlTADDBReport = new System.Windows.Forms.Panel();
            this.pnlPagination = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btndropdown = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dGVTADDBReport)).BeginInit();
            this.pnlNoDisplay.SuspendLayout();
            this.pnlMenuOption.SuspendLayout();
            this.pnlTADDBReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(303, 22);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(31, 20);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "To:";
            // 
            // dGVTADDBReport
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Green;
            this.dGVTADDBReport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVTADDBReport.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVTADDBReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dGVTADDBReport.ColumnHeadersHeight = 30;
            this.dGVTADDBReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SNo,
            this.TrainNo,
            this.TrainName,
            this.ArrDeptTime,
            this.LateTime,
            this.AorD,
            this.Status,
            this.PFNo,
            this.DateTime});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVTADDBReport.DefaultCellStyle = dataGridViewCellStyle3;
            this.dGVTADDBReport.Location = new System.Drawing.Point(3, 94);
            this.dGVTADDBReport.Name = "dGVTADDBReport";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            this.dGVTADDBReport.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dGVTADDBReport.Size = new System.Drawing.Size(1352, 410);
            this.dGVTADDBReport.TabIndex = 5;
            // 
            // SNo
            // 
            this.SNo.HeaderText = "S.No";
            this.SNo.Name = "SNo";
            this.SNo.Width = 120;
            // 
            // TrainNo
            // 
            this.TrainNo.HeaderText = "Train No.";
            this.TrainNo.Name = "TrainNo";
            this.TrainNo.Width = 170;
            // 
            // TrainName
            // 
            this.TrainName.HeaderText = "Train Name";
            this.TrainName.Name = "TrainName";
            this.TrainName.Width = 200;
            // 
            // ArrDeptTime
            // 
            this.ArrDeptTime.HeaderText = "Arr/Dept Time";
            this.ArrDeptTime.Name = "ArrDeptTime";
            this.ArrDeptTime.Width = 160;
            // 
            // LateTime
            // 
            this.LateTime.HeaderText = "Late Time";
            this.LateTime.Name = "LateTime";
            this.LateTime.Width = 130;
            // 
            // AorD
            // 
            this.AorD.HeaderText = "A/D";
            this.AorD.Name = "AorD";
            this.AorD.Width = 120;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.Width = 120;
            // 
            // PFNo
            // 
            this.PFNo.HeaderText = "PF No.";
            this.PFNo.Name = "PFNo";
            this.PFNo.Width = 120;
            // 
            // DateTime
            // 
            this.DateTime.HeaderText = "Date & Time";
            this.DateTime.Name = "DateTime";
            this.DateTime.Width = 170;
            // 
            // txtToDate
            // 
            this.txtToDate.Location = new System.Drawing.Point(340, 22);
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.Size = new System.Drawing.Size(169, 20);
            this.txtToDate.TabIndex = 12;
            // 
            // txtFromdate
            // 
            this.txtFromdate.Location = new System.Drawing.Point(80, 22);
            this.txtFromdate.Name = "txtFromdate";
            this.txtFromdate.Size = new System.Drawing.Size(169, 20);
            this.txtFromdate.TabIndex = 11;
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(505, 22);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(20, 20);
            this.dtpTo.TabIndex = 10;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "";
            this.dtpFrom.Location = new System.Drawing.Point(246, 22);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(20, 20);
            this.dtpFrom.TabIndex = 9;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // cmbExport
            // 
            this.cmbExport.BackColor = System.Drawing.Color.FloralWhite;
            this.cmbExport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExport.FormattingEnabled = true;
            this.cmbExport.Items.AddRange(new object[] {
            "-Select-",
            "XLS",
            "XLXS",
            "PDF"});
            this.cmbExport.Location = new System.Drawing.Point(1123, 22);
            this.cmbExport.Name = "cmbExport";
            this.cmbExport.Size = new System.Drawing.Size(65, 21);
            this.cmbExport.TabIndex = 8;
            // 
            // lblExport
            // 
            this.lblExport.AutoSize = true;
            this.lblExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExport.Location = new System.Drawing.Point(1058, 22);
            this.lblExport.Name = "lblExport";
            this.lblExport.Size = new System.Drawing.Size(59, 20);
            this.lblExport.TabIndex = 7;
            this.lblExport.Text = "Export:";
            // 
            // btnViewReport
            // 
            this.btnViewReport.BackColor = System.Drawing.Color.DarkOrange;
            this.btnViewReport.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnViewReport.FlatAppearance.BorderSize = 0;
            this.btnViewReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewReport.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnViewReport.Location = new System.Drawing.Point(871, 3);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(102, 40);
            this.btnViewReport.TabIndex = 6;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.UseVisualStyleBackColor = false;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // cmbTrainStatus
            // 
            this.cmbTrainStatus.BackColor = System.Drawing.Color.FloralWhite;
            this.cmbTrainStatus.FormattingEnabled = true;
            this.cmbTrainStatus.Location = new System.Drawing.Point(688, 22);
            this.cmbTrainStatus.Name = "cmbTrainStatus";
            this.cmbTrainStatus.Size = new System.Drawing.Size(124, 21);
            this.cmbTrainStatus.TabIndex = 5;
            // 
            // lblTrainStatus
            // 
            this.lblTrainStatus.AutoSize = true;
            this.lblTrainStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrainStatus.Location = new System.Drawing.Point(581, 22);
            this.lblTrainStatus.Name = "lblTrainStatus";
            this.lblTrainStatus.Size = new System.Drawing.Size(99, 20);
            this.lblTrainStatus.TabIndex = 4;
            this.lblTrainStatus.Text = "Train Status:";
            // 
            // lblNoData
            // 
            this.lblNoData.AutoSize = true;
            this.lblNoData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoData.Location = new System.Drawing.Point(626, 13);
            this.lblNoData.Name = "lblNoData";
            this.lblNoData.Size = new System.Drawing.Size(110, 16);
            this.lblNoData.TabIndex = 0;
            this.lblNoData.Text = "No Data Display.";
            // 
            // pnlNoDisplay
            // 
            this.pnlNoDisplay.BackColor = System.Drawing.Color.FloralWhite;
            this.pnlNoDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlNoDisplay.Controls.Add(this.lblNoData);
            this.pnlNoDisplay.Location = new System.Drawing.Point(0, 45);
            this.pnlNoDisplay.Name = "pnlNoDisplay";
            this.pnlNoDisplay.Size = new System.Drawing.Size(1352, 43);
            this.pnlNoDisplay.TabIndex = 1;
            // 
            // pnlMenuOption
            // 
            this.pnlMenuOption.BackColor = System.Drawing.SystemColors.Highlight;
            this.pnlMenuOption.Controls.Add(this.txtToDate);
            this.pnlMenuOption.Controls.Add(this.txtFromdate);
            this.pnlMenuOption.Controls.Add(this.dtpTo);
            this.pnlMenuOption.Controls.Add(this.dtpFrom);
            this.pnlMenuOption.Controls.Add(this.cmbExport);
            this.pnlMenuOption.Controls.Add(this.lblExport);
            this.pnlMenuOption.Controls.Add(this.btnViewReport);
            this.pnlMenuOption.Controls.Add(this.cmbTrainStatus);
            this.pnlMenuOption.Controls.Add(this.lblTrainStatus);
            this.pnlMenuOption.Controls.Add(this.lblTo);
            this.pnlMenuOption.Controls.Add(this.lblFrom);
            this.pnlMenuOption.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuOption.Name = "pnlMenuOption";
            this.pnlMenuOption.Size = new System.Drawing.Size(1352, 46);
            this.pnlMenuOption.TabIndex = 0;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(23, 22);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(50, 20);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From:";
            // 
            // pnlTADDBReport
            // 
            this.pnlTADDBReport.Controls.Add(this.pnlPagination);
            this.pnlTADDBReport.Controls.Add(this.dGVTADDBReport);
            this.pnlTADDBReport.Controls.Add(this.btnSearch);
            this.pnlTADDBReport.Controls.Add(this.btndropdown);
            this.pnlTADDBReport.Controls.Add(this.pnlMenuOption);
            this.pnlTADDBReport.Controls.Add(this.txtSearch);
            this.pnlTADDBReport.Controls.Add(this.pnlNoDisplay);
            this.pnlTADDBReport.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlTADDBReport.Location = new System.Drawing.Point(0, 2);
            this.pnlTADDBReport.Name = "pnlTADDBReport";
            this.pnlTADDBReport.Size = new System.Drawing.Size(1355, 587);
            this.pnlTADDBReport.TabIndex = 3;
            // 
            // pnlPagination
            // 
            this.pnlPagination.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pnlPagination.Location = new System.Drawing.Point(0, 503);
            this.pnlPagination.Name = "pnlPagination";
            this.pnlPagination.Size = new System.Drawing.Size(1355, 46);
            this.pnlPagination.TabIndex = 11;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::ArecaIPIS.Properties.Resources._352091_search_icon;
            this.btnSearch.Location = new System.Drawing.Point(1238, 52);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(46, 31);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // btndropdown
            // 
            this.btndropdown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btndropdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndropdown.Image = global::ArecaIPIS.Properties.Resources.descending_down;
            this.btndropdown.Location = new System.Drawing.Point(1283, 52);
            this.btndropdown.Name = "btndropdown";
            this.btndropdown.Size = new System.Drawing.Size(46, 31);
            this.btndropdown.TabIndex = 3;
            this.btndropdown.UseVisualStyleBackColor = false;
            this.btndropdown.Click += new System.EventHandler(this.btndropdown_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(1101, 59);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(140, 20);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.Text = "Search Here";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // frmTaddbReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 548);
            this.Controls.Add(this.pnlTADDBReport);
            this.Name = "frmTaddbReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTaddbReport";
            ((System.ComponentModel.ISupportInitialize)(this.dGVTADDBReport)).EndInit();
            this.pnlNoDisplay.ResumeLayout(false);
            this.pnlNoDisplay.PerformLayout();
            this.pnlMenuOption.ResumeLayout(false);
            this.pnlMenuOption.PerformLayout();
            this.pnlTADDBReport.ResumeLayout(false);
            this.pnlTADDBReport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btndropdown;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DataGridView dGVTADDBReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn SNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrainNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrainName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArrDeptTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn LateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn AorD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn PFNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTime;
        private System.Windows.Forms.TextBox txtToDate;
        private System.Windows.Forms.TextBox txtFromdate;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.ComboBox cmbExport;
        private System.Windows.Forms.Label lblExport;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.ComboBox cmbTrainStatus;
        private System.Windows.Forms.Label lblTrainStatus;
        private System.Windows.Forms.Label lblNoData;
        private System.Windows.Forms.Panel pnlNoDisplay;
        private System.Windows.Forms.Panel pnlMenuOption;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Panel pnlTADDBReport;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlPagination;
    }
}
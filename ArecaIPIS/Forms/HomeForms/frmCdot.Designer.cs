
namespace ArecaIPIS.Forms.HomeForms
{
    partial class frmCdot
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
            this.lblCdot = new System.Windows.Forms.Label();
            this.dgvCdot = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AlertMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Urgency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Severity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Certainty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AudioAvailability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCdot)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCdot
            // 
            this.lblCdot.AutoSize = true;
            this.lblCdot.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCdot.ForeColor = System.Drawing.Color.Red;
            this.lblCdot.Location = new System.Drawing.Point(25, 19);
            this.lblCdot.Name = "lblCdot";
            this.lblCdot.Size = new System.Drawing.Size(76, 31);
            this.lblCdot.TabIndex = 0;
            this.lblCdot.Text = "Cdot";
            // 
            // dgvCdot
            // 
            this.dgvCdot.AllowUserToAddRows = false;
            this.dgvCdot.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCdot.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCdot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCdot.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.AlertMessage,
            this.Urgency,
            this.Severity,
            this.Certainty,
            this.StartTime,
            this.EndTime,
            this.AudioAvailability});
            this.dgvCdot.EnableHeadersVisualStyles = false;
            this.dgvCdot.Location = new System.Drawing.Point(12, 66);
            this.dgvCdot.Name = "dgvCdot";
            this.dgvCdot.RowHeadersVisible = false;
            this.dgvCdot.Size = new System.Drawing.Size(1485, 276);
            this.dgvCdot.TabIndex = 1;
            // 
            // Select
            // 
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            // 
            // AlertMessage
            // 
            this.AlertMessage.HeaderText = "AlertMessage";
            this.AlertMessage.Name = "AlertMessage";
            this.AlertMessage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AlertMessage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Urgency
            // 
            this.Urgency.HeaderText = "Urgency";
            this.Urgency.Name = "Urgency";
            // 
            // Severity
            // 
            this.Severity.HeaderText = "Severity";
            this.Severity.Name = "Severity";
            // 
            // Certainty
            // 
            this.Certainty.HeaderText = "Certainty";
            this.Certainty.Name = "Certainty";
            // 
            // StartTime
            // 
            this.StartTime.HeaderText = "StartTime";
            this.StartTime.Name = "StartTime";
            // 
            // EndTime
            // 
            this.EndTime.HeaderText = "EndTime";
            this.EndTime.Name = "EndTime";
            // 
            // AudioAvailability
            // 
            this.AudioAvailability.HeaderText = "AudioAvailability";
            this.AudioAvailability.Name = "AudioAvailability";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(22, 388);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 124);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cdot Message";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Aqua;
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(33, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Data";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Aqua;
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(179, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 37);
            this.button2.TabIndex = 1;
            this.button2.Text = "Audio";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // frmCdot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1509, 812);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvCdot);
            this.Controls.Add(this.lblCdot);
            this.Name = "frmCdot";
            this.Text = "frmCdot";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCdot)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCdot;
        private System.Windows.Forms.DataGridView dgvCdot;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlertMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Urgency;
        private System.Windows.Forms.DataGridViewTextBoxColumn Severity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Certainty;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn AudioAvailability;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}
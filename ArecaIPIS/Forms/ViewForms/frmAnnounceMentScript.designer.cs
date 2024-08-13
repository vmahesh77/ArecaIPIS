
namespace ArecaIPIS.Forms.ViewForms
{
    partial class frmAnnounceMentScript
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
            this.lblAnnouncementScript = new System.Windows.Forms.Label();
            this.lblTrainStatus = new System.Windows.Forms.Label();
            this.lblPlatform = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.cbmTrainStatus = new System.Windows.Forms.ComboBox();
            this.cmbTrainLanguage = new System.Windows.Forms.ComboBox();
            this.cmbPlatform = new System.Windows.Forms.ComboBox();
            this.dgvAnnScriptTable = new System.Windows.Forms.DataGridView();
            this.btnAddAudioScript = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnnScriptTable)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAnnouncementScript
            // 
            this.lblAnnouncementScript.AutoSize = true;
            this.lblAnnouncementScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnnouncementScript.ForeColor = System.Drawing.Color.Red;
            this.lblAnnouncementScript.Location = new System.Drawing.Point(22, 34);
            this.lblAnnouncementScript.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAnnouncementScript.Name = "lblAnnouncementScript";
            this.lblAnnouncementScript.Size = new System.Drawing.Size(212, 24);
            this.lblAnnouncementScript.TabIndex = 2;
            this.lblAnnouncementScript.Text = "Announcement Script";
            // 
            // lblTrainStatus
            // 
            this.lblTrainStatus.AutoSize = true;
            this.lblTrainStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrainStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTrainStatus.Location = new System.Drawing.Point(32, 97);
            this.lblTrainStatus.Name = "lblTrainStatus";
            this.lblTrainStatus.Size = new System.Drawing.Size(107, 20);
            this.lblTrainStatus.TabIndex = 3;
            this.lblTrainStatus.Text = "Train Status  :";
            // 
            // lblPlatform
            // 
            this.lblPlatform.AutoSize = true;
            this.lblPlatform.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlatform.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPlatform.Location = new System.Drawing.Point(628, 97);
            this.lblPlatform.Name = "lblPlatform";
            this.lblPlatform.Size = new System.Drawing.Size(76, 20);
            this.lblPlatform.TabIndex = 4;
            this.lblPlatform.Text = "Platform :";
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLanguage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblLanguage.Location = new System.Drawing.Point(336, 94);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(89, 20);
            this.lblLanguage.TabIndex = 5;
            this.lblLanguage.Text = "Language :";
            // 
            // cbmTrainStatus
            // 
            this.cbmTrainStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbmTrainStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbmTrainStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cbmTrainStatus.FormattingEnabled = true;
            this.cbmTrainStatus.Location = new System.Drawing.Point(145, 94);
            this.cbmTrainStatus.Name = "cbmTrainStatus";
            this.cbmTrainStatus.Size = new System.Drawing.Size(159, 28);
            this.cbmTrainStatus.TabIndex = 6;
            this.cbmTrainStatus.Text = "Select";
            // 
            // cmbTrainLanguage
            // 
            this.cmbTrainLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTrainLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTrainLanguage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmbTrainLanguage.FormattingEnabled = true;
            this.cmbTrainLanguage.Location = new System.Drawing.Point(431, 91);
            this.cmbTrainLanguage.Name = "cmbTrainLanguage";
            this.cmbTrainLanguage.Size = new System.Drawing.Size(146, 28);
            this.cmbTrainLanguage.TabIndex = 7;
            this.cmbTrainLanguage.Text = "Select";
            // 
            // cmbPlatform
            // 
            this.cmbPlatform.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPlatform.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPlatform.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cmbPlatform.FormattingEnabled = true;
            this.cmbPlatform.Location = new System.Drawing.Point(710, 94);
            this.cmbPlatform.Name = "cmbPlatform";
            this.cmbPlatform.Size = new System.Drawing.Size(137, 28);
            this.cmbPlatform.TabIndex = 8;
            this.cmbPlatform.Text = "Select";
            // 
            // dgvAnnScriptTable
            // 
            this.dgvAnnScriptTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnnScriptTable.Location = new System.Drawing.Point(36, 175);
            this.dgvAnnScriptTable.Name = "dgvAnnScriptTable";
            this.dgvAnnScriptTable.Size = new System.Drawing.Size(847, 150);
            this.dgvAnnScriptTable.TabIndex = 9;
            // 
            // btnAddAudioScript
            // 
            this.btnAddAudioScript.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnAddAudioScript.FlatAppearance.BorderSize = 0;
            this.btnAddAudioScript.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAudioScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAudioScript.Location = new System.Drawing.Point(909, 94);
            this.btnAddAudioScript.Name = "btnAddAudioScript";
            this.btnAddAudioScript.Size = new System.Drawing.Size(101, 34);
            this.btnAddAudioScript.TabIndex = 10;
            this.btnAddAudioScript.Text = "Add";
            this.btnAddAudioScript.UseVisualStyleBackColor = false;
            this.btnAddAudioScript.Click += new System.EventHandler(this.btnAddAudioScript_Click);
            // 
            // frmAnnounceMentScript
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 450);
            this.Controls.Add(this.btnAddAudioScript);
            this.Controls.Add(this.dgvAnnScriptTable);
            this.Controls.Add(this.cmbPlatform);
            this.Controls.Add(this.cmbTrainLanguage);
            this.Controls.Add(this.cbmTrainStatus);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.lblPlatform);
            this.Controls.Add(this.lblTrainStatus);
            this.Controls.Add(this.lblAnnouncementScript);
            this.Name = "frmAnnounceMentScript";
            this.Text = "frmAnnounceMentScript";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnnScriptTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAnnouncementScript;
        private System.Windows.Forms.Label lblTrainStatus;
        private System.Windows.Forms.Label lblPlatform;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ComboBox cbmTrainStatus;
        private System.Windows.Forms.ComboBox cmbTrainLanguage;
        private System.Windows.Forms.ComboBox cmbPlatform;
        private System.Windows.Forms.DataGridView dgvAnnScriptTable;
        private System.Windows.Forms.Button btnAddAudioScript;
    }
}
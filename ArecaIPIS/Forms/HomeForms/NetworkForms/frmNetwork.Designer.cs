
namespace ArecaIPIS.Forms
{
    partial class frmNetwork
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
            this.panBoardforms = new System.Windows.Forms.Panel();
            this.panButtons = new System.Windows.Forms.Panel();
            this.btnivdovd = new System.Windows.Forms.Button();
            this.btnCgdb = new System.Windows.Forms.Button();
            this.btnTADB = new System.Windows.Forms.Button();
            this.btnCds = new System.Windows.Forms.Button();
            this.panButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panBoardforms
            // 
            this.panBoardforms.Location = new System.Drawing.Point(239, 0);
            this.panBoardforms.Name = "panBoardforms";
            this.panBoardforms.Size = new System.Drawing.Size(1258, 699);
            this.panBoardforms.TabIndex = 0;
            // 
            // panButtons
            // 
            this.panButtons.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panButtons.Controls.Add(this.btnivdovd);
            this.panButtons.Controls.Add(this.btnCgdb);
            this.panButtons.Controls.Add(this.btnTADB);
            this.panButtons.Controls.Add(this.btnCds);
            this.panButtons.Location = new System.Drawing.Point(5, 0);
            this.panButtons.Name = "panButtons";
            this.panButtons.Size = new System.Drawing.Size(231, 491);
            this.panButtons.TabIndex = 1;
            // 
            // btnivdovd
            // 
            this.btnivdovd.BackColor = System.Drawing.Color.Green;
            this.btnivdovd.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.btnivdovd.ForeColor = System.Drawing.Color.Honeydew;
            this.btnivdovd.Image = global::ArecaIPIS.Properties.Resources._9081024_layout_board_icon;
            this.btnivdovd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnivdovd.Location = new System.Drawing.Point(3, 369);
            this.btnivdovd.Name = "btnivdovd";
            this.btnivdovd.Size = new System.Drawing.Size(225, 116);
            this.btnivdovd.TabIndex = 3;
            this.btnivdovd.Text = "IVD/OVD";
            this.btnivdovd.UseVisualStyleBackColor = false;
            this.btnivdovd.Click += new System.EventHandler(this.btnivdovd_Click);
            // 
            // btnCgdb
            // 
            this.btnCgdb.BackColor = System.Drawing.Color.Green;
            this.btnCgdb.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.btnCgdb.ForeColor = System.Drawing.Color.Honeydew;
            this.btnCgdb.Image = global::ArecaIPIS.Properties.Resources._9081024_layout_board_icon;
            this.btnCgdb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCgdb.Location = new System.Drawing.Point(3, 247);
            this.btnCgdb.Name = "btnCgdb";
            this.btnCgdb.Size = new System.Drawing.Size(225, 116);
            this.btnCgdb.TabIndex = 2;
            this.btnCgdb.Text = "CGDB";
            this.btnCgdb.UseVisualStyleBackColor = false;
            this.btnCgdb.Click += new System.EventHandler(this.btnCgdb_Click);
            // 
            // btnTADB
            // 
            this.btnTADB.BackColor = System.Drawing.Color.Green;
            this.btnTADB.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.btnTADB.ForeColor = System.Drawing.Color.Honeydew;
            this.btnTADB.Image = global::ArecaIPIS.Properties.Resources._9081024_layout_board_icon;
            this.btnTADB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTADB.Location = new System.Drawing.Point(3, 125);
            this.btnTADB.Name = "btnTADB";
            this.btnTADB.Size = new System.Drawing.Size(225, 116);
            this.btnTADB.TabIndex = 1;
            this.btnTADB.Text = "TADB";
            this.btnTADB.UseVisualStyleBackColor = false;
            this.btnTADB.Click += new System.EventHandler(this.btnTADB_Click);
            // 
            // btnCds
            // 
            this.btnCds.BackColor = System.Drawing.Color.Green;
            this.btnCds.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCds.ForeColor = System.Drawing.Color.Honeydew;
            this.btnCds.Image = global::ArecaIPIS.Properties.Resources.settings;
            this.btnCds.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCds.Location = new System.Drawing.Point(3, 3);
            this.btnCds.Name = "btnCds";
            this.btnCds.Size = new System.Drawing.Size(225, 116);
            this.btnCds.TabIndex = 0;
            this.btnCds.Text = "CDS";
            this.btnCds.UseVisualStyleBackColor = false;
            this.btnCds.Click += new System.EventHandler(this.btnCds_Click);
            // 
            // frmNetwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1509, 746);
            this.Controls.Add(this.panButtons);
            this.Controls.Add(this.panBoardforms);
            this.Name = "frmNetwork";
            this.Text = "frmNetwork";
            this.panButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panBoardforms;
        private System.Windows.Forms.Panel panButtons;
        private System.Windows.Forms.Button btnivdovd;
        private System.Windows.Forms.Button btnCgdb;
        private System.Windows.Forms.Button btnTADB;
        private System.Windows.Forms.Button btnCds;
    }
}
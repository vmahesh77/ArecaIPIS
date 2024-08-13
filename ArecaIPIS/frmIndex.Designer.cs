
namespace ArecaIPIS
{
    partial class frmIndex
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
            this.panHeader = new System.Windows.Forms.Panel();
            this.panForms = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panHeader
            // 
            this.panHeader.Location = new System.Drawing.Point(2, 1);
            this.panHeader.Name = "panHeader";
            this.panHeader.Size = new System.Drawing.Size(1321, 179);
            this.panHeader.TabIndex = 0;
            // 
            // panForms
            // 
            this.panForms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panForms.AutoScroll = true;
            this.panForms.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panForms.Location = new System.Drawing.Point(6, 180);
            this.panForms.Name = "panForms";
            this.panForms.Size = new System.Drawing.Size(1317, 481);
            this.panForms.TabIndex = 2;
            this.panForms.Paint += new System.Windows.Forms.PaintEventHandler(this.panForms_Paint);
            // 
            // frmIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 662);
            this.Controls.Add(this.panForms);
            this.Controls.Add(this.panHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmIndex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmIndex";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmIndex_FormClosing);
            this.Load += new System.EventHandler(this.frmIndex_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panHeader;
        private System.Windows.Forms.Panel panForms;
    }
}

namespace ArecaIPIS.Forms.settingsForms
{
    partial class frmRedundencyPc
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
            this.lblRedundencyPc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblRedundencyPc
            // 
            this.lblRedundencyPc.AutoSize = true;
            this.lblRedundencyPc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRedundencyPc.ForeColor = System.Drawing.Color.Red;
            this.lblRedundencyPc.Location = new System.Drawing.Point(35, 25);
            this.lblRedundencyPc.Name = "lblRedundencyPc";
            this.lblRedundencyPc.Size = new System.Drawing.Size(219, 31);
            this.lblRedundencyPc.TabIndex = 0;
            this.lblRedundencyPc.Text = "Redundency Pc";
            // 
            // frmRedundencyPc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblRedundencyPc);
            this.Name = "frmRedundencyPc";
            this.Text = "frmRedundencyPc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRedundencyPc;
    }
}
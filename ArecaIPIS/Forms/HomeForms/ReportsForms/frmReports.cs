using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ArecaIPIS.Forms
{
    public partial class frmReports : Form
    {
        private frmHome parentForm;
        public frmReports(frmHome parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;

        }
        public frmReports()
        {
            InitializeComponent();


            btnTaddb.ForeColor = Color.White;
            btnTaddb.FlatAppearance.BorderSize = 1;
            btnCdot.ForeColor = Color.White;
            btnCdot.FlatAppearance.BorderSize = 1;
            btnIVD.ForeColor = Color.White;
            btnIVD.FlatAppearance.BorderSize = 1;
            btnOVD.ForeColor = Color.White;
            btnOVD.FlatAppearance.BorderSize = 1;
            btnCGDB.ForeColor = Color.White;
            btnCGDB.FlatAppearance.BorderSize = 1;
            btnAnnouncement.ForeColor = Color.White;
            btnAnnouncement.FlatAppearance.BorderSize = 1;
            btnAGDB.ForeColor = Color.White;
            btnAGDB.FlatAppearance.BorderSize = 1;
            btnAppStatus.ForeColor = Color.White;
            btnAppStatus.FlatAppearance.BorderSize = 1;
            btnPDC.ForeColor = Color.White;
            btnPDC.FlatAppearance.BorderSize = 1;
            btnDataLog.ForeColor = Color.White;
            btnDataLog.FlatAppearance.BorderSize = 1;
            btnErrorLog.ForeColor = Color.White;
            btnErrorLog.FlatAppearance.BorderSize = 1;
            btnLinkCheckLog.ForeColor = Color.White;
            btnLinkCheckLog.FlatAppearance.BorderSize = 1;
            btnPlatformChange.ForeColor = Color.White;
            btnPlatformChange.FlatAppearance.BorderSize = 1;

            int arcSize = 15;
            frmReports.ApplyRoundedCorners(btnTaddb, arcSize);
            frmReports.ApplyRoundedCorners(btnCdot, arcSize);
            frmReports.ApplyRoundedCorners(btnIVD, arcSize);
            frmReports.ApplyRoundedCorners(btnOVD, arcSize);
            frmReports.ApplyRoundedCorners(btnCGDB, arcSize);
            frmReports.ApplyRoundedCorners(btnAnnouncement, arcSize);
            frmReports.ApplyRoundedCorners(btnAGDB, arcSize);
            frmReports.ApplyRoundedCorners(btnAppStatus, arcSize);
            frmReports.ApplyRoundedCorners(btnPDC, arcSize);
            frmReports.ApplyRoundedCorners(btnDataLog, arcSize);
            frmReports.ApplyRoundedCorners(btnErrorLog, arcSize);
            frmReports.ApplyRoundedCorners(btnLinkCheckLog, arcSize);
            frmReports.ApplyRoundedCorners(btnPlatformChange, arcSize);
        }
        public static void ApplyRoundedCorners(Button button, int arcSize)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, arcSize * 2, arcSize * 2, 180, 90);
            path.AddArc(button.Width - arcSize * 2, 0, arcSize * 2, arcSize * 2, 270, 90);
            path.AddArc(button.Width - arcSize * 2, button.Height - arcSize * 2, arcSize * 2, arcSize * 2, 0, 90);
            path.AddArc(0, button.Height - arcSize * 2, arcSize * 2, arcSize * 2, 90, 90);
            path.CloseAllFigures();
            button.Region = new Region(path);

        }

        private void btnTaddb_MouseHover(object sender, EventArgs e)
        {
            btnTaddb.BackColor = Color.LightGray;
            btnTaddb.ForeColor = Color.Black;
        }

        private void btnTaddb_MouseLeave(object sender, EventArgs e)
        {
            btnTaddb.BackColor = Color.DodgerBlue;
            btnTaddb.ForeColor = Color.White;
        }

        private void btnCdot_MouseHover(object sender, EventArgs e)
        {
            btnCdot.BackColor = Color.LightGray;
            btnCdot.ForeColor = Color.Black;
        }

        private void btnCdot_MouseLeave(object sender, EventArgs e)
        {
            btnCdot.BackColor = Color.DodgerBlue;
            btnCdot.ForeColor = Color.White;
        }

        private void btnIVD_MouseHover(object sender, EventArgs e)
        {
            btnIVD.BackColor = Color.LightGray;
            btnIVD.ForeColor = Color.Black;
        }

        private void btnIVD_MouseLeave(object sender, EventArgs e)
        {
            btnIVD.BackColor = Color.DodgerBlue;
            btnIVD.ForeColor = Color.White;
        }

        private void btnOVD_MouseHover(object sender, EventArgs e)
        {
            btnOVD.BackColor = Color.LightGray;
            btnOVD.ForeColor = Color.Black;
        }

        private void btnOVD_MouseLeave(object sender, EventArgs e)
        {
            btnOVD.BackColor = Color.DodgerBlue;
            btnOVD.ForeColor = Color.White;
        }

        private void btnCGDB_MouseHover(object sender, EventArgs e)
        {
            btnCGDB.BackColor = Color.LightGray;
            btnCGDB.ForeColor = Color.Black;
        }

        private void btnCGDB_MouseLeave(object sender, EventArgs e)
        {
            btnCGDB.BackColor = Color.DodgerBlue;
            btnCGDB.ForeColor = Color.White;
        }

        private void btnAnnouncement_MouseHover(object sender, EventArgs e)
        {
            btnAnnouncement.BackColor = Color.LightGray;
            btnAnnouncement.ForeColor = Color.Black;
        }

        private void btnAnnouncement_MouseLeave(object sender, EventArgs e)
        {
            btnAnnouncement.BackColor = Color.DodgerBlue;
            btnAnnouncement.ForeColor = Color.White;
        }

        private void btnAGDB_MouseHover(object sender, EventArgs e)
        {
            btnAGDB.BackColor = Color.LightGray;
            btnAGDB.ForeColor = Color.Black;
        }

        private void btnAGDB_MouseLeave(object sender, EventArgs e)
        {
            btnAGDB.BackColor = Color.DodgerBlue;
            btnAGDB.ForeColor = Color.White;
        }

        private void btnAppStatus_MouseHover(object sender, EventArgs e)
        {
            btnAppStatus.BackColor = Color.LightGray;
            btnAppStatus.ForeColor = Color.Black;
        }

        private void btnAppStatus_MouseLeave(object sender, EventArgs e)
        {
            btnAppStatus.BackColor = Color.DodgerBlue;
            btnAppStatus.ForeColor = Color.White;
        }

        private void btnPDC_MouseHover(object sender, EventArgs e)
        {
            btnPDC.BackColor = Color.LightGray;
            btnPDC.ForeColor = Color.Black;
        }

        private void btnPDC_MouseLeave(object sender, EventArgs e)
        {
            btnPDC.BackColor = Color.DodgerBlue;
            btnPDC.ForeColor = Color.White;
        }

        private void btnDataLog_MouseHover(object sender, EventArgs e)
        {
            btnDataLog.BackColor = Color.LightGray;
            btnDataLog.ForeColor = Color.Black;
        }

        private void btnDataLog_MouseLeave(object sender, EventArgs e)
        {
            btnDataLog.BackColor = Color.DodgerBlue;
            btnDataLog.ForeColor = Color.White;
        }

        private void btnErrorLog_MouseHover(object sender, EventArgs e)
        {
            btnErrorLog.BackColor = Color.LightGray;
            btnErrorLog.ForeColor = Color.Black;
        }

        private void btnErrorLog_MouseLeave(object sender, EventArgs e)
        {
            btnErrorLog.BackColor = Color.DodgerBlue;
            btnErrorLog.ForeColor = Color.White;
        }

        private void btnLinkCheckLog_MouseHover(object sender, EventArgs e)
        {
            btnLinkCheckLog.BackColor = Color.LightGray;
            btnLinkCheckLog.ForeColor = Color.Black;
        }

        private void btnLinkCheckLog_MouseLeave(object sender, EventArgs e)
        {
            btnLinkCheckLog.BackColor = Color.DodgerBlue;
            btnLinkCheckLog.ForeColor = Color.White;
        }

        private void btnPlatformChange_MouseHover(object sender, EventArgs e)
        {
            btnPlatformChange.BackColor = Color.LightGray;
            btnPlatformChange.ForeColor = Color.Black;
        }

        private void btnPlatformChange_MouseLeave(object sender, EventArgs e)
        {
            btnPlatformChange.BackColor = Color.DodgerBlue;
            btnPlatformChange.ForeColor = Color.White;
        }
        private Form currentForm;
        private void OpenFormInPanel(Form form)
        {
            if (currentForm != null)
            {
                currentForm.Close();
                currentForm.Dispose();
            }

            currentForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            pnlMainReport.Controls.Add(form);
            form.Show();

        }
        private void btnTaddb_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmTaddbReport());
        }

        private void btnCdot_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmCDOTReport());
        }

        private void btnIVD_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmIVDReport());
        }

        private void btnOVD_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmOVDReport());
        }

        private void btnCGDB_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmCGDBReport());
        }

        private void btnAnnouncement_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmAnnouncementReport());
        }

        private void btnAGDB_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmAGDBReport());
        }

        private void btnAppStatus_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmAppStatusReport());
        }

        private void btnPDC_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmPDCReport());
        }

        private void btnDataLog_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmDataLogReport());
        }

        private void btnErrorLog_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmErrorLogReport());
        }

        private void btnLinkCheckLog_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmLinkCheckLogReport());
        }

        private void btnPlatformChange_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmPlatformChangeReport());
        }
    }
}

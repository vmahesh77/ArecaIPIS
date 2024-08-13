using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    public partial class frmCDOTReport : Form
    {
        ToolStripDropDown dropDown;
        public frmCDOTReport()
        {
            InitializeComponent();


            cmbExport.SelectedIndex = 0;
            txtSearch.Visible = false;
            btnSearch.Visible = false;
            btndropdown.Visible = false;
            dGVCDOTReport.Visible = false;
            pnlPagination.Visible = false;
            dGVCDOTReport.EnableHeadersVisualStyles = false;
            dGVCDOTReport.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;


            CheckedListBox checkedListBox = new CheckedListBox();
            checkedListBox.Items.AddRange(new object[] { "S.No", "Train No.", "Train Name", "Arr / Dept Time", "Late Time", "A / D", "Status", "PF No.", "Date & Time" });

            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemChecked(i, true);
                checkedListBox.BackColor = Color.LightSalmon;
            }

            dropDown = new ToolStripDropDown();
            //dropDown.Padding = new Padding(5);
            ToolStripControlHost host = new ToolStripControlHost(checkedListBox);
            host.Padding = Padding.Empty;
            dropDown.Items.Add(host);
            dtpFrom.CustomFormat = " ";
            dtpTo.CustomFormat = " ";
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            if (txtFromdate.Text == "" || txtToDate.Text == "")
            {
                MessageBox.Show("Please Select from and to Date");
            }
            else
            {
                pnlNoDisplay.Visible = false;
                txtSearch.Visible = true;
                btnSearch.Visible = true;
                btndropdown.Visible = true;
                dGVCDOTReport.Visible = true;
                pnlPagination.Visible = true;
            }

        }
        private bool ClearTextBox = true;
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (ClearTextBox)
            {
                txtSearch.Clear();
                ClearTextBox = false;
            }
        }
        private void btndropdown_Click(object sender, EventArgs e)
        {
            dropDown.Show(btndropdown, new System.Drawing.Point(0, btndropdown.Height));
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = dtpTo.Value;
            txtToDate.Text = dt.ToString("dd-MMM-yy HH:mm:ss");
        
        }
        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = dtpFrom.Value;
            txtFromdate.Text = dt.ToString("dd-MMM-yy HH:mm:ss");
        }
    }
}

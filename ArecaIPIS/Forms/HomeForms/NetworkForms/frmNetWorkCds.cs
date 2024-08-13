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
    public partial class frmNetWorkCds : Form
    {
        private frmHome parentForm;
        public frmNetWorkCds()
        {
            InitializeComponent();
        }
        public frmNetWorkCds(frmHome parentForm) : this()
        {
            this.parentForm = parentForm;
        }

        private void dgvCommunication_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panCommunication_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblCommunication_Click(object sender, EventArgs e)
        {

        }
    }
}

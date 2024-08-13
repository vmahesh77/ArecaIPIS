using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArecaIPIS.Forms.ViewForms
{
    public partial class frmDefectiveLinesTaddb : Form
    {
        public frmDefectiveLinesTaddb()
        {
            InitializeComponent();
        }
        private frmHome parentForm;
        public frmDefectiveLinesTaddb(frmHome parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;

        }
        private void lblAdress_Click(object sender, EventArgs e)
        {

        }
    }
}

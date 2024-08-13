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
    public partial class frmNetworkCgdb : Form
    {
        public frmNetworkCgdb()
        {
            InitializeComponent();
        }
        private frmHome parentForm;

        public frmNetworkCgdb(frmHome parentForm) : this()
        {
            this.parentForm = parentForm;
        }
    }
}

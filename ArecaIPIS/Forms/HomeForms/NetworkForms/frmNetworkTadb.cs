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
    public partial class frmNetworkTadb : Form
    {
        public frmNetworkTadb()
        {
            InitializeComponent();
        }
        private frmHome parentForm;
        
        public frmNetworkTadb(frmHome parentForm) : this()
        {
            this.parentForm = parentForm;
        }
    }
}

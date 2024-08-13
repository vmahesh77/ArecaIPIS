using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArecaIPIS.Forms.settingsForms
{
    public partial class frmRedundencyPc : Form
    {
        public frmRedundencyPc()
        {
            InitializeComponent();
        }

        private frmHome parentForm;

        public frmRedundencyPc(frmHome parentForm) : this()
        {
            this.parentForm = parentForm;
        }
    }
}

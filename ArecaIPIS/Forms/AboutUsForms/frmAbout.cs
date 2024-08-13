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
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }
        private frmHome parentForm;

        public frmAbout(frmHome parentForm) : this()
        {
            this.parentForm = parentForm;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArecaIPIS.Forms.HomeForms
{
    public partial class frmCdot : Form
    {
        public frmCdot()
        {
            InitializeComponent();
        }

        private frmHome parentForm;

        public frmCdot(frmHome parentForm) : this()
        {
            this.parentForm = parentForm;
        }
    }
}

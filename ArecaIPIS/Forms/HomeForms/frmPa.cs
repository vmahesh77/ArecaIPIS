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
    public partial class frmPa : Form
    {
        public frmPa()
        {
            InitializeComponent();
        }

        private frmHome parentForm;
        public frmPa(frmHome parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;

        }
    }
}

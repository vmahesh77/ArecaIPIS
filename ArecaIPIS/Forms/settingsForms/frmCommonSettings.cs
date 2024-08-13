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
    public partial class frmCommonSettings : Form
    {
        public frmCommonSettings()
        {
            InitializeComponent();
        }
        private frmHome parentForm;
        public frmCommonSettings(frmHome parentForm) : this()
        {
            this.parentForm = parentForm;
        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}

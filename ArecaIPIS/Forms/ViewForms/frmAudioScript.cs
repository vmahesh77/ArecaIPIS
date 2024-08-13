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
    public partial class frmAudioScript : Form
    {
        public frmAudioScript()
        {
            InitializeComponent();
        }
        private frmHome parentForm;
        public frmAudioScript(frmHome parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;

        }
        private void lblCreateStation_Click(object sender, EventArgs e)
        {

        }

        private void lblNoteDef1_Click(object sender, EventArgs e)
        {

        }
    }
}

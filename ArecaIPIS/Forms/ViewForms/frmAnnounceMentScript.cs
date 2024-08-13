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
    public partial class frmAnnounceMentScript : Form
    {
        public frmAnnounceMentScript()
        {
            InitializeComponent();
        }
        private frmHome parentForm;
        public frmAnnounceMentScript(frmHome parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;

        }
        private void btnAddAudioScript_Click(object sender, EventArgs e)
        {
            frmAudioScript audioscript = new frmAudioScript();
            audioscript.Show();
        }
    }
}

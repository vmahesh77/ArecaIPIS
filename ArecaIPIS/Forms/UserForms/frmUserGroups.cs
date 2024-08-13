using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArecaIPIS.Forms.UserForms
{
    public partial class frmUserGroups : Form
    {
        public frmUserGroups()
        {
            InitializeComponent();
        }

        private void frmUserGroups_Load(object sender, EventArgs e)
        {

        }
        private frmHome parentForm;

        public frmUserGroups(frmHome parentForm) : this()
        {
            this.parentForm = parentForm;
        }
    }
}

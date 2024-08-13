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
    public partial class frmInterface : Form
    {
        public frmInterface()
        {
            InitializeComponent();
        }

        private void frmInterface_Load(object sender, EventArgs e)
        {
            
        }
        private frmHome parentForm;
        public frmInterface(frmHome parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNtes_Click(object sender, EventArgs e)
        {
            btnNtes.BackColor = Color.DarkGreen;
            btnCdot.BackColor = Color.SteelBlue;
            panCdot.Visible = false;
            panNtes.Visible = true;
        }

        private void btnCdot_Click(object sender, EventArgs e)
        {
            btnNtes.BackColor = Color.SteelBlue;
            btnCdot.BackColor = Color.DarkGreen;
            panCdot.Visible = true;
            panNtes.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

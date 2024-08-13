using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ArecaIPIS.Forms.AboutUsForms;
using ArecaIPIS.Forms.HomeForms;
using ArecaIPIS.Forms.settingsForms;
using ArecaIPIS.Forms.UserForms;
using ArecaIPIS.Forms.ViewForms;
using ArecaIPIS.DAL;
using ArecaIPIS.Forms;
using ArecaIPIS.Classes;

namespace ArecaIPIS
{
    public partial class frmIndex : Form
    {
        private Form headerCurrentForm;
        private Form currentForm;
        public frmIndex()
        {
            InitializeComponent();
        }

        private frmIndex parentForm;
        public frmIndex(frmIndex parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;

        }
        private void frmIndex_Load(object sender, EventArgs e)
        {
            // Server server = new Server();
            Server.StartServer();
            BaseClass.GetIndexForm();
            laodForms();
            BaseClass.RecallBoards();
        }
        public void laodForms()
        {
            OpenFormInHeaderPanel(new frmHome(this));
        }

        public void OpenFormInHeaderPanel(Form form)
        {
            if (headerCurrentForm != null)
            {
                headerCurrentForm.Close();
                headerCurrentForm.Dispose();
            }

            headerCurrentForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panHeader.Controls.Add(form);
            form.Show();

        }
        public void OpenFormInPanel(Form form)
         {
            
            if (currentForm != null)
            {
                currentForm.Close();
                currentForm.Dispose();
            }

            currentForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panForms.Controls.Add(form);
            form.Show();

        }

        private void panForms_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmIndex_FormClosing(object sender, FormClosingEventArgs e)
        {
            Server.StopServer();
        }
    }
}

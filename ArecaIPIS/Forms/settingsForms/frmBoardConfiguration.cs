using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArecaIPIS.DAL;

namespace ArecaIPIS.Forms
{
    public partial class frmBoardConfiguration : Form
    {
        public frmBoardConfiguration()
        {
            InitializeComponent();
        }

        private frmHome parentForm;

        public frmBoardConfiguration(frmHome parentForm) : this()
        {
            this.parentForm = parentForm;
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmBoardConfiguration_Load(object sender, EventArgs e)
        {
            List<string> formatTypesList =BoardConfigurationDb.GetFormatType();
            SetFormatTypes(formatTypesList);

        }

        private void SetFormatTypes(List<String> formatTypesList)
        {
            // Clear existing items in the ComboBox
            cmbFormatType.Items.Clear();

            // Add the default item "--Select--"
            cmbFormatType.Items.Add("--Select--");

            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Type in formatTypesList)
            {
                // Trim the platform name
                string trimmedType = Type.Trim();

                // Add the trimmed platform name to the ComboBox
                cmbFormatType.Items.Add(trimmedType);
            }

            // Select the default item "--Select--"
            cmbFormatType.SelectedIndex = 0;
        }
    }
}

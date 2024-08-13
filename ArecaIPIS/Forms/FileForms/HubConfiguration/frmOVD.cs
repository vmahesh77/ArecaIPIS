using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArecaIPIS
{
    public partial class frmOVD : Form
    {
        public frmOVD()
        {
            InitializeComponent();
        }
        public string dynamicPortNo { get; set; }
        public void SetPassedValue(Button button)
        {
            // Extract the numerical part from the button's name
            string buttonName = button.Name;
            string numericPart = new string(buttonName.Where(char.IsDigit).ToArray());

            // Convert the numeric part to an integer

            dynamicPortNo = numericPart;

            // Optionally, use the value immediately or update some controls with this value
            txtOVDEthernetportno.Text = dynamicPortNo; // Assuming you have a textbox to display the value



        }
        private void btnOVDCommonSettings_Click(object sender, EventArgs e)
        {
            panelOVDCommonSettings.Visible = true;
            panelOVDmediasettings.Hide();
            panelOVDBoardSettings.Hide();
            btnOVDCommonSettings.BackColor = Color.Green;
            btnOVDBoardSettings.BackColor = Color.Black;
            btnovdmediasettings.BackColor = Color.Black;
        }

        private void btnOVDBoardSettings_Click(object sender, EventArgs e)
        {
            panelOVDBoardSettings.Visible = true;
            panelOVDmediasettings.Hide();
            panelOVDCommonSettings.Hide();
            btnOVDBoardSettings.BackColor = Color.Green;
            btnOVDCommonSettings.BackColor = Color.Black;
            btnovdmediasettings.BackColor = Color.Black;
        }

        private void btnovdmediasettings_Click(object sender, EventArgs e)
        {
            panelOVDmediasettings.Visible = true;
            panelOVDCommonSettings.Hide();
            panelOVDBoardSettings.Hide();
            btnovdmediasettings.BackColor = Color.Green;
            btnOVDBoardSettings.BackColor = Color.Black;
            btnOVDCommonSettings.BackColor = Color.Black;
        }

        private void OVD_Load(object sender, EventArgs e)
        {
            panelOVDCommonSettings.Visible = true;
            panelOVDmediasettings.Hide();
            panelOVDBoardSettings.Hide();
            btnOVDCommonSettings.BackColor = Color.Green;
            btnovdmediasettings.BackColor = Color.Black;
            btnOVDBoardSettings.BackColor = Color.Black;
            SetDisplayEffects();
            SetLetterSpeed();
            SetFormatType();
            SetLetterGap();
            SetFontSize();
            SetInfoDisplay();
        }

        private void SetDisplayEffects()
        {
            // Clear existing items in the ComboBox
            CmbOVDDisplayeffect.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Effects in BaseClass.DisplayEffects)
            {
                // Trim the platform name
                string trimmedEffects = Effects.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbOVDDisplayeffect.Items.Add(trimmedEffects);
            }
            // Select the default item "--Select--"
            CmbOVDDisplayeffect.SelectedIndex = 0;
        }
        private void SetInfoDisplay()
        {
            // Clear existing items in the ComboBox
            CmbOVDinfoDisplayed.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var infoDisplay in BaseClass.infoDisplayList)
            {
                // Trim the platform name
                string trimmedinfoDisplay = infoDisplay.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbOVDinfoDisplayed.Items.Add(trimmedinfoDisplay);
            }
            // Select the default item "--Select--"
            CmbOVDinfoDisplayed.SelectedIndex = 0;
        }
        private void SetLetterGap()
        {
            // Clear existing items in the ComboBox
            CmbOVDlettergap.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var LetterGap in BaseClass.LetterGapList)
            {
                // Trim the platform name
                string trimmedLetterGap = LetterGap.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbOVDlettergap.Items.Add(trimmedLetterGap);
            }
            // Select the default item "--Select--"
            CmbOVDlettergap.SelectedIndex = 0;
        }
        private void SetLetterSpeed()
        {
            // Clear existing items in the ComboBox
            CmbOVDLetterSpeed.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Speed in BaseClass.LetterSpeedlist)
            {
                // Trim the platform name
                string trimmedSpeed = Speed.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbOVDLetterSpeed.Items.Add(trimmedSpeed);
            }
            // Select the default item "--Select--"
            CmbOVDLetterSpeed.SelectedIndex = 0;
        }
        private void SetFormatType()
        {
            // Clear existing items in the ComboBox
            CmbOVDFormattype.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var FormatType in BaseClass.FormatsList)
            {
                // Trim the platform name
                string trimmedFormatType = FormatType.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbOVDFormattype.Items.Add(trimmedFormatType);
            }
            // Select the default item "--Select--"
            CmbOVDFormattype.SelectedIndex = 0;
        }
        private void SetFontSize()
        {
            // Clear existing items in the ComboBox
            CmbOVDfontSize.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Font in BaseClass.FontSizeList)
            {
                // Trim the platform name
                string trimmedFont = Font.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbOVDfontSize.Items.Add(trimmedFont);
            }
            // Select the default item "--Select--"
            CmbOVDfontSize.SelectedIndex = 0;
        }

        private void panelMLDBCommonSettings_Paint(object sender, PaintEventArgs e)
        {

        }

     

        private void lblOVDSec_Click(object sender, EventArgs e)
        {

        }

        private void checkboxOVDAutoerasing_CheckedChanged(object sender, EventArgs e)
        {
            // Check if the checkbox is checked
            if (checkboxOVDAutoerasing.Checked)
            {
                // If checked, enable the panel
                txtOVDErasetime.Enabled = true;
            }
            else
            {
                // If unchecked, disable the panel
                txtOVDErasetime.Enabled = false;
            }
        }
    }
}

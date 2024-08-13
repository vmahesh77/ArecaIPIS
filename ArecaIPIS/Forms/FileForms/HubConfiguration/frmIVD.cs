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
    public partial class frmIVD : Form
    {
        public frmIVD()
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
            txtIVDEthernetportno.Text = dynamicPortNo; // Assuming you have a textbox to display the value



        }
        private void btnIVDCommonSettings_Click(object sender, EventArgs e)
        {
            panelIVDCommonSettings.Visible = true;
            panelIVDBoardSettings.Hide();
            panelIVDmediasettings.Hide();
            btnIVDCommonSettings.BackColor = Color.Green;
            btnIVDBoardSettings.BackColor = Color.Black;
            btnIVDmediasettings.BackColor = Color.Black;
        }

        private void btnIVDBoardSettings_Click(object sender, EventArgs e)
        {
            panelIVDBoardSettings.Visible = true;
            panelIVDCommonSettings.Hide();          
            panelIVDmediasettings.Hide();          
            btnIVDBoardSettings.BackColor = Color.Green;
            btnIVDCommonSettings.BackColor = Color.Black;
            btnIVDmediasettings.BackColor = Color.Black;
        }

        private void btnIVDmediasettings_Click(object sender, EventArgs e)
        {
            panelIVDmediasettings.Visible = true;
            panelIVDCommonSettings.Hide();
            panelIVDBoardSettings.Hide();
            btnIVDmediasettings.BackColor = Color.Green;
            btnIVDCommonSettings.BackColor = Color.Black;
            btnIVDBoardSettings.BackColor = Color.Black;
           
        }

        private void IVD_Load(object sender, EventArgs e)
        {
            panelIVDCommonSettings.Visible = true;
            panelIVDBoardSettings.Hide();
            panelIVDmediasettings.Hide();
            btnIVDCommonSettings.BackColor = Color.Green;
            btnIVDBoardSettings.BackColor = Color.Black;
            btnIVDmediasettings.BackColor = Color.Black;
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
            CmbIVDDisplayeffect.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Effects in BaseClass.DisplayEffects)
            {
                // Trim the platform name
                string trimmedEffects = Effects.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbIVDDisplayeffect.Items.Add(trimmedEffects);
            }
            // Select the default item "--Select--"
            CmbIVDDisplayeffect.SelectedIndex = 0;
        }
        private void SetInfoDisplay()
        {
            // Clear existing items in the ComboBox
            CmbIVDinfoDisplayed.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var infoDisplay in BaseClass.infoDisplayList)
            {
                // Trim the platform name
                string trimmedinfoDisplay = infoDisplay.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbIVDinfoDisplayed.Items.Add(trimmedinfoDisplay);
            }
            // Select the default item "--Select--"
            CmbIVDinfoDisplayed.SelectedIndex = 0;
        }
        private void SetLetterGap()
        {
            // Clear existing items in the ComboBox
            CmbIVDlettergap.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var LetterGap in BaseClass.LetterGapList)
            {
                // Trim the platform name
                string trimmedLetterGap = LetterGap.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbIVDlettergap.Items.Add(trimmedLetterGap);
            }
            // Select the default item "--Select--"
            CmbIVDlettergap.SelectedIndex = 0;
        }
        private void SetLetterSpeed()
        {
            // Clear existing items in the ComboBox
            CmbIVDLetterSpeed.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Speed in BaseClass.LetterSpeedlist)
            {
                // Trim the platform name
                string trimmedSpeed = Speed.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbIVDLetterSpeed.Items.Add(trimmedSpeed);
            }
            // Select the default item "--Select--"
            CmbIVDLetterSpeed.SelectedIndex = 0;
        }
        private void SetFormatType()
        {
            // Clear existing items in the ComboBox
            CmbIVDFormattype.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var FormatType in BaseClass.FormatsList)
            {
                // Trim the platform name
                string trimmedFormatType = FormatType.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbIVDFormattype.Items.Add(trimmedFormatType);
            }
            // Select the default item "--Select--"
            CmbIVDFormattype.SelectedIndex = 0;
        }
        private void SetFontSize()
        {
            // Clear existing items in the ComboBox
            CmbIVDfontSize.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Font in BaseClass.FontSizeList)
            {
                // Trim the platform name
                string trimmedFont = Font.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbIVDfontSize.Items.Add(trimmedFont);
            }
            // Select the default item "--Select--"
            CmbIVDfontSize.SelectedIndex = 0;
        }

        private void panelMLDBCommonSettings_Paint(object sender, PaintEventArgs e)
        {

        }

       
        private void checkboxIVDAutoerasing_CheckedChanged(object sender, EventArgs e)
        {
            // Check if the checkbox is checked
            if (checkboxIVDAutoerasing.Checked)
            {
                // If checked, enable the panel
                txtIVDErasetime.Enabled = true;
            }
            else
            {
                // If unchecked, disable the panel
                txtIVDErasetime.Enabled = false;
            }
        }
    }
}

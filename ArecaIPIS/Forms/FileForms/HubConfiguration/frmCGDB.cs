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
    public partial class frmCGDB : Form
    {
        public frmCGDB()
        {
            InitializeComponent();
        }

        private void txtCGDBnoofcoaches_MouseLeave(object sender, EventArgs e)
        {
           
            ClearTextBoxes();

           
            CreateTextBoxes();
        }
        public void SetPassedValue(Button button)
        {
            // Extract the numerical part from the button's name
            string buttonName = button.Name;
            string numericPart = new string(buttonName.Where(char.IsDigit).ToArray());

        }
        private void CreateTextBoxes()
        {
           
            int numberOfTextBoxes;
            if (!int.TryParse(txtCGDBnoofcoaches.Text, out numberOfTextBoxes))
            {
                return; 
            }

            
            for (int i = 0; i < numberOfTextBoxes; i++)
            {
                Label serialNumberHeaderLabel = new Label();
                serialNumberHeaderLabel.Name = "labelDynamicHeader_" + i ;
                serialNumberHeaderLabel.Text = "S.No"; // Set header text
                serialNumberHeaderLabel.Location = new Point(10, 10); // Adjust location as needed
                serialNumberHeaderLabel.Size = new Size(50, 20);
                serialNumberHeaderLabel.BackColor = Color.LightGray;
                serialNumberHeaderLabel.Font = new Font(serialNumberHeaderLabel.Font.FontFamily, 10, FontStyle.Bold);
                panelCGDBnoofcoaches.Controls.Add(serialNumberHeaderLabel);

                Label BoardsIdsHeaderLabel1 = new Label();
                BoardsIdsHeaderLabel1.Name = "labelDynamicHeader1_" + i;
                BoardsIdsHeaderLabel1.Text = "Board Ids"; // Set header text
                BoardsIdsHeaderLabel1.Location = new Point(70, 10); // Adjust location as needed
                BoardsIdsHeaderLabel1.Size = new Size(100, 20);
                BoardsIdsHeaderLabel1.BackColor = Color.LightGray;
                BoardsIdsHeaderLabel1.Font = new Font(serialNumberHeaderLabel.Font.FontFamily, 10, FontStyle.Bold);
                panelCGDBnoofcoaches.Controls.Add(BoardsIdsHeaderLabel1);

                // Create text box for serial number
                TextBox serialNumberTextBox = new TextBox();
                serialNumberTextBox.Name = "textBoxDynamic1_" + i;
                serialNumberTextBox.Location = new Point(10, 40 + i * 30);
                serialNumberTextBox.Size = new Size(50, 20);
                serialNumberTextBox.ReadOnly = true;
                serialNumberTextBox.BorderStyle = BorderStyle.FixedSingle;
                serialNumberTextBox.Font = new Font(serialNumberTextBox.Font.FontFamily, 10, FontStyle.Bold);
                serialNumberTextBox.Text = (i + 1).ToString();
                panelCGDBnoofcoaches.Controls.Add(serialNumberTextBox);

                // Create text box for other data
                TextBox textBox2 = new TextBox();
                textBox2.Name = "textBoxDynamic2_" + i;
                textBox2.Location = new Point(70, 40 + i * 30);
                textBox2.Size = new Size(100, 20); // Adjust the size if needed
                textBox2.Text = "192.168.1." + (i + 2).ToString();
                textBox2.BorderStyle = BorderStyle.FixedSingle;
                textBox2.Font = new Font(textBox2.Font.FontFamily, 10, FontStyle.Bold);
                textBox2.ReadOnly = true;
                panelCGDBnoofcoaches.Controls.Add(textBox2);

               
            }
        }
        private void SetDisplayEffects()
        {
            // Clear existing items in the ComboBox
            CmbCGDBDisplayeffect.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Effects in BaseClass.DisplayEffects)
            {
                // Trim the platform name
                string trimmedEffects = Effects.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbCGDBDisplayeffect.Items.Add(trimmedEffects);
            }
            // Select the default item "--Select--"
            CmbCGDBDisplayeffect.SelectedIndex = 0;
        }
        
        private void SetLetterGap()
        {
            // Clear existing items in the ComboBox
            CmbCGDBlettergap.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var LetterGap in BaseClass.LetterGapList)
            {
                // Trim the platform name
                string trimmedLetterGap = LetterGap.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbCGDBlettergap.Items.Add(trimmedLetterGap);
            }
            // Select the default item "--Select--"
            CmbCGDBlettergap.SelectedIndex = 0;
        }
        private void SetLetterSpeed()
        {
            // Clear existing items in the ComboBox
            CmbCGDBLetterSpeed.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Speed in BaseClass.LetterSpeedlist)
            {
                // Trim the platform name
                string trimmedSpeed = Speed.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbCGDBLetterSpeed.Items.Add(trimmedSpeed);
            }
            // Select the default item "--Select--"
            CmbCGDBLetterSpeed.SelectedIndex = 0;
        }
        private void SetFormatType()
        {
            // Clear existing items in the ComboBox
            CmbCGDBFormattype.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var FormatType in BaseClass.FormatsList)
            {
                // Trim the platform name
                string trimmedFormatType = FormatType.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbCGDBFormattype.Items.Add(trimmedFormatType);
            }
            // Select the default item "--Select--"
            CmbCGDBFormattype.SelectedIndex = 0;
        }
        private void SetFontSize()
        {
            // Clear existing items in the ComboBox
            CmbCGDBfontSize.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Font in BaseClass.FontSizeList)
            {
                // Trim the platform name
                string trimmedFont = Font.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbCGDBfontSize.Items.Add(trimmedFont);
            }
            // Select the default item "--Select--"
            CmbCGDBfontSize.SelectedIndex = 0;
        }

        private void panelMLDBCommonSettings_Paint(object sender, PaintEventArgs e)
        {

        }

      


        private void ClearTextBoxes()
        {
            panelCGDBnoofcoaches.Controls.Clear();
        }

        private void checkboxCGDBAutoerasing_CheckedChanged(object sender, EventArgs e)
        {
            // Check if the checkbox is checked
            if (checkboxCGDBAutoerasing.Checked)
            {
                // If checked, enable the panel
                txtCGDBErasetime.Enabled = true;
            }
            else
            {
                // If unchecked, disable the panel
                txtCGDBErasetime.Enabled = false;
            }
        }

        private void frmCGDB_Load(object sender, EventArgs e)
        {
            SetDisplayEffects();
            SetLetterSpeed();
            SetFormatType();
            SetLetterGap();
            SetFontSize();
        }

        private void CmbCGDBfontSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
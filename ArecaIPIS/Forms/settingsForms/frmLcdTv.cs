using System;
using System.Windows.Forms;
using System.Drawing;
using ArecaIPIS.DAL;
using System.Data;

namespace ArecaIPIS.Forms
{
    public partial class frmLcdTv : Form
    {
        private frmHome parentForm;

        public frmLcdTv()
        {
            InitializeComponent();
        }
        LcdTvDb lcdTvDb = new LcdTvDb();

        public frmLcdTv(frmHome parentForm) : this()
        {
            this.parentForm = parentForm;
        }

        // Override the OnPaint method to draw a horizontal line when the form is painted
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Create a Graphics object from the PaintEventArgs
            Graphics g = e.Graphics;

            // Create a Pen for drawing the line
            Pen pen = new Pen(Color.Black, 3);

            // Calculate the start and end points for the horizontal line
            int startX =0; // Starting X-coordinate
            int endX = 1530;  // Ending X-coordinate
            int y = 145;     // Y-coordinate (the same for start and end)

            // Draw the horizontal line
            g.DrawLine(pen, startX, y, endX, y);

            // Dispose of the Pen object to free resources
            pen.Dispose();
        }

        private void frmLcdTv_Load(object sender, EventArgs e)
        {
  
            setCctvsettings();
                        
        }
        private void setCctvsettings()
        {
            try
            {
                // Call the method to get CCTV settings and store the result in a DataTable
                DataTable cctv = LcdTvDb.GetCctvSettings();

                // Check if the DataTable is not null
                if (cctv != null)
                {
                    // Check if the DataTable has any rows
                    if (cctv.Rows.Count > 0)
                    {
                        // Process the data as needed
                        foreach (DataRow row in cctv.Rows)
                        {
                            bool coachInfoChecked = (bool)row["CoachInfoChk"];
                            cbCoachInfoDisplay.Checked = coachInfoChecked;

                            bool messageChecked = (bool)row["MessageChk"];
                            cbMessageDisplay.Checked = messageChecked;

                            bool videoChecked = (bool)row["VideoChk"];
                            cbVideoDisplay.Checked = videoChecked;

                            bool windowChecked = (bool)row["SameWindow"];
                            cbSameWindow.Checked = windowChecked;

                            txtboxDefaultMessage.Text = row["DefaultMsg"].ToString();


                            //if(row["DateFormat"].ToString().Length == 0)
                            //{
                            //    cmbDateFormat.Text = "DD/MM/YY";
                            //}
                            //else
                            //{
                            //    cmbDateFormat.Text = row["DateFormat"].ToString();

                            //}

                            if (string.IsNullOrEmpty(row["DateFormat"].ToString()))
                            {
                                cmbDateFormat.Text = "DD/MM/YY";
                            }
                            else if(row["DateFormat"].ToString() == "1")
                            {
                                cmbDateFormat.SelectedIndex = 0;
                            }
                            else if (row["DateFormat"].ToString() == "2")
                            {
                                cmbDateFormat.SelectedIndex = 1;
                            }


                            int scrollingSpeed = (int)row["ScrollingSpeed1"];

                            if (scrollingSpeed == 300)
                            {
                                cmbScrollingSpeed.Text = "Very Fast";
                            }
                            else if (scrollingSpeed == 250)
                            {
                                cmbScrollingSpeed.Text = "Fast";
                            }
                            else if (scrollingSpeed == 200)
                            {
                                cmbScrollingSpeed.Text = "Normal";
                            }
                            else if (scrollingSpeed == 100)
                            {
                                cmbScrollingSpeed.Text = "Slow";
                            }
                            else if (scrollingSpeed == 50)
                            {
                                cmbScrollingSpeed.Text = "Very Slow";
                            }
                            else
                            {
                                // Default value or error handling if the selected item is not recognized
                                cmbScrollingSpeed.Text = "Default speed"; // Or any other default value
                            }


                            //HEADER

                            txtHeaderBackClr.Text = row["HBGColor"].ToString();
                            string colorString = row["HBGColor"].ToString();
                            txtHeaderBackClr.BackColor = ColorTranslator.FromHtml(colorString);

                            txtHeaderForeClr.Text = row["HFGColor"].ToString();
                            string colorString1 = row["HFGColor"].ToString();
                            txtHeaderForeClr.ForeColor = ColorTranslator.FromHtml(colorString1);

                            cmbHeaderFont.Text = row["Hfont"].ToString();

                            cmbHeaderFontSize.Text = row["HfontSize"].ToString();


                            //TRAIN DISPLAY

                            txtTrainDisplayBackClr.Text = row["TBFGColor"].ToString();
                            string colorString9 = row["TBFGColor"].ToString();
                            txtTrainDisplayBackClr.BackColor = ColorTranslator.FromHtml(colorString9);

                            txtTrainDisplayForeClr.Text = row["TFGColor"].ToString();
                            string colorString2 = row["TFGColor"].ToString();
                            txtTrainDisplayForeClr.ForeColor = ColorTranslator.FromHtml(colorString2);

                            cmbTrainDisplayFont.Text = row["Tfont"].ToString();

                            cmbTrainDisplayFontSize.Text = row["TfontSize"].ToString();

                            //TRAIN DETAILS

                            txtTrainDetailsForeClr.Text = row["TDFGColor"].ToString();
                            string colorString3 = row["TFGColor"].ToString();
                            txtTrainDetailsForeClr.ForeColor = ColorTranslator.FromHtml(colorString3);

                            txtTrainDetailsBackClr.Text = row["TBDFGColor"].ToString();
                            string colorString10 = row["TBDFGColor"].ToString();
                            txtTrainDetailsBackClr.BackColor = ColorTranslator.FromHtml(colorString10);

                            cmbTrainDetailsFont.Text = row["TDfont"].ToString();

                            cmbTrainDetailsFontSize.Text = row["TDfontSize"].ToString();

                            //GENERAL MESSAGE

                            txtGeneralMessageBackClr.Text = row["MBGColor"].ToString();
                            string colorString4 = row["MBGColor"].ToString();
                            txtGeneralMessageBackClr.BackColor = ColorTranslator.FromHtml(colorString4);

                            txtGeneralMessageForeClr.Text = row["MFGColor"].ToString();
                            string colorString5 = row["MFGColor"].ToString();
                            txtGeneralMessageForeClr.ForeColor = ColorTranslator.FromHtml(colorString5);

                            cmbGeneralMessageFont.Text = row["Mfgfont"].ToString();

                            cmbGeneralMessageFontSize.Text = row["MfontSize"].ToString();

                            //COACH SETTINGS

                            txtCoachSettingsBackClr.Text = row["CBGColor"].ToString();
                            string colorString6 = row["CBGColor"].ToString();
                            txtCoachSettingsBackClr.BackColor = ColorTranslator.FromHtml(colorString6);

                            txtCoachSettingsForeClr.Text = row["CFGColor"].ToString();
                            string colorString7 = row["CFGColor"].ToString();
                            txtCoachSettingsForeClr.ForeColor = ColorTranslator.FromHtml(colorString7);

                            cmbCoachSettingsFont.Text = row["Cfont"].ToString();

                            cmbCoachSettingsFontSize.Text = row["CfontSize"].ToString();


                            //FOOTER

                            txtFooterSettingsBackClr.Text = row["FBGColor"].ToString();
                            string colorString8 = row["FBGColor"].ToString();
                            txtFooterSettingsBackClr.BackColor = ColorTranslator.FromHtml(colorString8);

                            txtFooterSettingsForeClr.Text = row["FFGColor"].ToString();
                            string colorString11 = row["FFGColor"].ToString();
                            txtFooterSettingsForeClr.ForeColor = ColorTranslator.FromHtml(colorString11);

                            cmbFooterSettingsFont.Text = row["Ffont"].ToString();

                            cmbFooterSettingsFontSize.Text = row["FfontSize"].ToString();

                        }
                        // Optionally, update UI or perform other operations
                    }
                    else
                    {
                        MessageBox.Show("No CCTV settings found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to retrieve CCTV settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtHeaderBackClr_MouseClick(object sender, MouseEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtHeaderBackClr.BackColor = colorDialog.Color;
                Color selectedColor = colorDialog.Color;
                // txtHeaderBackClr.Text = ColorTranslator.ToHtml(colorDialog.Color); // Display color as hexadecimal value
                string hexValue = "#" + selectedColor.R.ToString("X2") + selectedColor.G.ToString("X2") + selectedColor.B.ToString("X2");
                txtHeaderBackClr.Text = hexValue;
            }
        }

        private void txtHeaderForeClr_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtHeaderForeClr.BackColor = colorDialog.Color;
                Color selectedColor = colorDialog.Color;
                // txtHeaderBackClr.Text = ColorTranslator.ToHtml(colorDialog.Color); // Display color as hexadecimal value
                string hexValue = "#" + selectedColor.R.ToString("X2") + selectedColor.G.ToString("X2") + selectedColor.B.ToString("X2");
                txtHeaderForeClr.Text = hexValue;
            }
        }

        private void txtTrainDisplayBackClr_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtTrainDisplayBackClr.BackColor = colorDialog.Color;
                Color selectedColor = colorDialog.Color;
                // txtHeaderBackClr.Text = ColorTranslator.ToHtml(colorDialog.Color); // Display color as hexadecimal value
                string hexValue = "#" + selectedColor.R.ToString("X2") + selectedColor.G.ToString("X2") + selectedColor.B.ToString("X2");
                txtTrainDisplayBackClr.Text = hexValue;
            }
        }

        private void txtTrainDisplayForeClr_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtTrainDisplayForeClr.BackColor = colorDialog.Color;
                Color selectedColor = colorDialog.Color;
                // txtHeaderBackClr.Text = ColorTranslator.ToHtml(colorDialog.Color); // Display color as hexadecimal value
                string hexValue = "#" + selectedColor.R.ToString("X2") + selectedColor.G.ToString("X2") + selectedColor.B.ToString("X2");
                txtTrainDisplayForeClr.Text = hexValue;
            }
        }

        private void txtTrainDetailsBackClr_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtTrainDetailsBackClr.BackColor = colorDialog.Color;
                Color selectedColor = colorDialog.Color;
                // txtHeaderBackClr.Text = ColorTranslator.ToHtml(colorDialog.Color); // Display color as hexadecimal value
                string hexValue = "#" + selectedColor.R.ToString("X2") + selectedColor.G.ToString("X2") + selectedColor.B.ToString("X2");
                txtTrainDetailsBackClr.Text = hexValue;
            }
        }

        private void txtTrainDetailsForeClr_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtTrainDetailsForeClr.BackColor = colorDialog.Color;
                Color selectedColor = colorDialog.Color;
                // txtHeaderBackClr.Text = ColorTranslator.ToHtml(colorDialog.Color); // Display color as hexadecimal value
                string hexValue = "#" + selectedColor.R.ToString("X2") + selectedColor.G.ToString("X2") + selectedColor.B.ToString("X2");
                txtTrainDetailsForeClr.Text = hexValue;
            }
        }

        private void txtFooterSettingsBackClr_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtFooterSettingsBackClr.BackColor = colorDialog.Color;
                Color selectedColor = colorDialog.Color;
                // txtHeaderBackClr.Text = ColorTranslator.ToHtml(colorDialog.Color); // Display color as hexadecimal value
                string hexValue = "#" + selectedColor.R.ToString("X2") + selectedColor.G.ToString("X2") + selectedColor.B.ToString("X2");
                txtFooterSettingsBackClr.Text = hexValue;
            }
        }

        private void txtFooterSettingsForeClr_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtFooterSettingsForeClr.BackColor = colorDialog.Color;
                Color selectedColor = colorDialog.Color;
                // txtHeaderBackClr.Text = ColorTranslator.ToHtml(colorDialog.Color); // Display color as hexadecimal value
                string hexValue = "#" + selectedColor.R.ToString("X2") + selectedColor.G.ToString("X2") + selectedColor.B.ToString("X2");
                txtFooterSettingsForeClr.Text = hexValue;
            }
        }

        private void txtCoachSettingsBackClr_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtCoachSettingsBackClr.BackColor = colorDialog.Color;
                Color selectedColor = colorDialog.Color;
                // txtHeaderBackClr.Text = ColorTranslator.ToHtml(colorDialog.Color); // Display color as hexadecimal value
                string hexValue = "#" + selectedColor.R.ToString("X2") + selectedColor.G.ToString("X2") + selectedColor.B.ToString("X2");
                txtCoachSettingsBackClr.Text = hexValue;
            }
        }

        private void txtCoachSettingsForeClr_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtCoachSettingsForeClr.BackColor = colorDialog.Color;
                Color selectedColor = colorDialog.Color;
                // txtHeaderBackClr.Text = ColorTranslator.ToHtml(colorDialog.Color); // Display color as hexadecimal value
                string hexValue = "#" + selectedColor.R.ToString("X2") + selectedColor.G.ToString("X2") + selectedColor.B.ToString("X2");
                txtCoachSettingsForeClr.Text = hexValue;
            }
        }

        private void txtGeneralMessageBackClr_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtGeneralMessageBackClr.BackColor = colorDialog.Color;
                Color selectedColor = colorDialog.Color;
                // txtHeaderBackClr.Text = ColorTranslator.ToHtml(colorDialog.Color); // Display color as hexadecimal value
                string hexValue = "#" + selectedColor.R.ToString("X2") + selectedColor.G.ToString("X2") + selectedColor.B.ToString("X2");
                txtGeneralMessageBackClr.Text = hexValue;
            }
        }

        private void txtGeneralMessageForeClr_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                txtGeneralMessageForeClr.BackColor = colorDialog.Color;
                Color selectedColor = colorDialog.Color;
                // txtHeaderBackClr.Text = ColorTranslator.ToHtml(colorDialog.Color); // Display color as hexadecimal value
                string hexValue = "#" + selectedColor.R.ToString("X2") + selectedColor.G.ToString("X2") + selectedColor.B.ToString("X2");
                txtGeneralMessageForeClr.Text = hexValue;
            }
        }

        private void cmbGeneralMessageFont_Click(object sender, EventArgs e)
        {
            PopulateFontComboBox(cmbGeneralMessageFont);
        }
        private void PopulateFontComboBox(ComboBox comboBox)
        {
            // Clear the ComboBox before populating it
            comboBox.Items.Clear();

            // Get all available font families installed on the system
            foreach (FontFamily fontFamily in FontFamily.Families)
            {
                // Add the font name to the ComboBox
                comboBox.Items.Add(fontFamily.Name);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtboxDefaultMessage.Text))
            {
                //normalValues
                bool coachInfoChk = cbCoachInfoDisplay.Checked;
                bool VideoDisplayChk = cbVideoDisplay.Checked;
                bool MessageDisplayChk = cbMessageDisplay.Checked;
                bool SameWindowChk = cbSameWindow.Checked;
                string DefaultMessage = txtboxDefaultMessage.Text;
                int DateFormatvalue = 0;

                // Check the selected index of the ComboBox
                if (cmbDateFormat.SelectedIndex == -1)
                {
                    DateFormatvalue = 1; // Assign value 1 if the combo box is empty
                }
                // Check if the first item is selected
                else if (cmbDateFormat.SelectedIndex == 0)
                {
                    DateFormatvalue = 1; // Assign value 1 if index 0 is selected
                }
                // Check if the second item is selected
                else if (cmbDateFormat.SelectedIndex == 1)
                {
                    DateFormatvalue = 2; // Assign value 2 if index 1 is selected
                }

                int scrollingSpeed;

                string selectedSpeed = cmbScrollingSpeed.SelectedItem.ToString();

                if (selectedSpeed == "Very Slow")
                {
                    scrollingSpeed = 50;
                }
                else if (selectedSpeed == "Slow")
                {
                    scrollingSpeed = 100;
                }
                else if (selectedSpeed == "Normal")
                {
                    scrollingSpeed = 200;
                }
                else if (selectedSpeed == "Fast")
                {
                    scrollingSpeed = 250;
                }
                else if (selectedSpeed == "Very Fast")
                {
                    scrollingSpeed = 300;
                }
                else
                {
                    // Default value or error handling if the selected item is not recognized
                    scrollingSpeed = 150; // Or any other default value
                }

                string filepath = txtboxFilePath.Text;

                //Header Settings
                string HeaderBackColor = txtHeaderBackClr.Text;
                string HeaderForeColor = txtHeaderForeClr.Text;
                string HeaderFont = cmbHeaderFont.Text;
                int HeaderFontSize = int.Parse(cmbHeaderFontSize.Text);

                //Train DisplayHeaders
                string DisplayHeadersBackColor = txtTrainDisplayBackClr.Text;
                string DisplayHeadersForeColor = txtTrainDisplayForeClr.Text;
                string DisplayHeadersFont = cmbTrainDisplayFont.Text;
                int DisplayHeadersFontSize = int.Parse(cmbTrainDisplayFontSize.Text);

                //TrainDetailsSettings
                string TrainDetailsBackColor = txtTrainDetailsBackClr.Text;
                string TrainDetailsForeColor = txtTrainDetailsForeClr.Text;
                string TrainDetailsFont = cmbTrainDetailsFont.Text;
                int TrainDetailsFontSize = int.Parse(cmbTrainDetailsFontSize.Text);

                //GeneralMessageDisplaySettings
                string GeneralMessageBackColor = txtGeneralMessageBackClr.Text;
                string GeneralMessageForeColor = txtGeneralMessageForeClr.Text;
                string GeneralMessageFont = cmbGeneralMessageFont.Text;
                int GeneralMessageFontSize = int.Parse(cmbGeneralMessageFontSize.Text);

                //CoachSettings
                string CoachBackColor = txtCoachSettingsBackClr.Text;
                string CoachForeColor = txtCoachSettingsForeClr.Text;
                string CoachFont = cmbCoachSettingsFont.Text;
                int CoachFontSize = int.Parse(cmbCoachSettingsFontSize.Text);


                //FooterSettings
                string FooterBackColor = txtFooterSettingsBackClr.Text;
                string FooterForeColor = txtFooterSettingsForeClr.Text;
                string FooterFont = cmbFooterSettingsFont.Text;
                int FooterFontSize = int.Parse(cmbFooterSettingsFontSize.Text);

                // Call the insert function and pass the retrieved values
                //lcdTvDb.InsertcctvSettings(coachInfoChk, VideoDisplay, MessageDisplay, DefaultMessage, DateFormatvalue, scrollingSpeed, filepath,
                //               HeaderBackColor, HeaderForeColor, HeaderFont, HeaderFontSize,
                //               DisplayHeadersBackColor, DisplayHeadersForeColor, DisplayHeadersFont, DisplayHeadersFontSize,
                //               TrainDetailsBackColor, TrainDetailsForeColor, TrainDetailsFont, TrainDetailsFontSize,
                //               GeneralMessageBackColor, GeneralMessageForeColor, GeneralMessageFont, GeneralMessageFontSize,
                //               CoachBackColor, CoachForeColor, CoachFont, CoachFontSize,
                //               FooterBackColor, FooterForeColor, FooterFont, FooterFontSize);

                int affectedrows = lcdTvDb.updatecctvSettings(1, coachInfoChk, VideoDisplayChk, MessageDisplayChk, DefaultMessage, DateFormatvalue, scrollingSpeed, filepath,
                    HeaderBackColor, HeaderForeColor, HeaderFont, HeaderFontSize,
                    DisplayHeadersBackColor, DisplayHeadersForeColor, DisplayHeadersFont, DisplayHeadersFontSize,
                    TrainDetailsBackColor, TrainDetailsForeColor, TrainDetailsFont, TrainDetailsFontSize,
                    GeneralMessageBackColor, GeneralMessageForeColor, GeneralMessageFont, GeneralMessageFontSize,
                    CoachBackColor, CoachForeColor, CoachFont, CoachFontSize,
                    FooterBackColor, FooterForeColor, FooterFont, FooterFontSize, SameWindowChk);

                if (affectedrows > 0)
                {
                    // Show success message for 10 seconds
                    lblStatus.Text = "Station configuration saved successfully!";
                    lblStatus.ForeColor = Color.Green;
                }
                else
                {
                    // Show failure message for 10 seconds
                    lblStatus.Text = "Failed to save station configuration.";
                    lblStatus.ForeColor = Color.Red;
                }

                // Make the label visible
                lblStatus.Visible = true;

                // Start a timer to clear the label after 10 seconds
                Timer timer = new Timer();
                timer.Interval = 5000; // 5 seconds
                timer.Tick += (s, _) =>
                {
                    // Clear the label text and hide the label
                    lblStatus.Text = "";
                    lblStatus.Visible = false;

                    // Stop and dispose the timer
                    timer.Stop();
                    timer.Dispose();
                };
                timer.Start(); // Start the timer
            }
            else
            {
                txtboxDefaultMessage.Text = "Welcome";
            }


        }
        void InsertSettings(bool coachInfoChk, bool VideoDisplay, bool MessageDisplay,bool SameWindow, string DefaultMessage, int DateFormat, int scrollingSpeed, string filepath,
                    string HeaderBackColor, string HeaderForeColor, string HeaderFont, int HeaderFontSize,
                    string DisplayHeadersBackColor, string DisplayHeadersForeColor, string DisplayHeadersFont, int DisplayHeadersFontSize,
                    string TrainDetailsBackColor, string TrainDetailsForeColor, string TrainDetailsFont, int TrainDetailsFontSize,
                    string GeneralMessageBackColor, string GeneralMessageForeColor, string GeneralMessageFont, int GeneralMessageFontSize,
                    string CoachBackColor, string CoachForeColor, string CoachFont, int CoachFontSize,
                    string FooterBackColor, string FooterForeColor, string FooterFont, int FooterFontSize)
        {
           
        }

        private void txtCoachSettingsBackClr_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGeneralMessageForeClr_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblSameWindow_Click(object sender, EventArgs e)
        {

        }
    }
}

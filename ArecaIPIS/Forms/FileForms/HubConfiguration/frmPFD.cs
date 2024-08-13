using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArecaIPIS
{
    public partial class frmPFD : Form
    {
        public frmPFD()
        {
            InitializeComponent();
        }
        public string dynamicPortNo { get; set; }
        public int ethernetPortNo { get; set; }
        public int PkNumber { get; set; }
        public int PdcPortNo { get; set; }
        Button board;
        int ID;
        public void SetPassedValue(Button button)
        {
            // Extract the numerical part from the button's name
            board = button;
            string buttonName = button.Name;
            string numericPart = new string(buttonName.Where(char.IsDigit).ToArray());

            // Convert the numeric part to an integer

            ethernetPortNo = Convert.ToInt32(numericPart);

            // Optionally, use the value immediately or update some controls with this value
            txtPFDEthernetportno.Text = ethernetPortNo.ToString(); // Assuming you have a textbox to display the value

        }

        public void SetPkHubValue(int pkvalue)
        {
            PkNumber = pkvalue;

        }
        public void SetPassedValue(Button button, int PortNo)
        {
            // Extract the numerical part from the button's name
            board = button;
            string buttonName = button.Name;
            string numericPart = new string(buttonName.Where(char.IsDigit).ToArray());

            // Convert the numeric part to an integer

            PdcPortNo = Convert.ToInt32(numericPart);

            // Optionally, use the value immediately or update some controls with this value
            txtPFDEthernetportno.Text = PortNo.ToString(); // Assuming you have a textbox to display the value

        }
        private void PFD_Load(object sender, EventArgs e)
        {
            panelPFDCommonSettings.Visible = true;
            panelPFDBoardSettings.Hide();
            btnPFDCommonSettings.BackColor = Color.Green;
            btnPFDBoardSettings.BackColor = Color.Black;
            cmbPFDVideoType.SelectedIndex = 0;
            CmbPFDDelaytime.SelectedIndex = 0;
            SetDisplayEffects();
            SetLetterSpeed();
            SetIPAddress();
            SetFormatType();
            SetLetterGap();
            SetFontSize();
            SetInfoDisplay();
            SetDisplaySequence();
            createPlatforms();
            GetDetailsByPk();

        }

        private void btnPFDCommonSettings_Click(object sender, EventArgs e)
        {
            panelPFDCommonSettings.Visible = true;
            panelPFDBoardSettings.Hide();
            btnPFDCommonSettings.BackColor = Color.Green;
            btnPFDBoardSettings.BackColor = Color.Black;
        }

        private void btnPFDBoardSettings_Click(object sender, EventArgs e)
        {
            panelPFDCommonSettings.Hide();
            panelPFDBoardSettings.Visible = true;
            btnPFDCommonSettings.BackColor = Color.Black;
            btnPFDBoardSettings.BackColor = Color.Green;
        }
        private void GetDetailsByPk()
        {
            if (PkNumber != 0)
            {
                DataTable boarddetailybyPk = new DataTable();
                foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                {
                    if (BaseClass.EthernetPorts.Columns.Contains("PkeyMasterhub") && int.TryParse(row["PkeyMasterhub"].ToString(), out int PkMasterHub))
                    {
                        if (PkMasterHub == PkNumber)
                        {
                            boarddetailybyPk = HubConfigurationDb.GetBoardDetails(PkMasterHub);
                            ipAddressMldb.Text = row["IPAddress"].ToString();
                            txtPFDLocation.Text = row["Location"].ToString();
                            txtPFDEthernetportno.Text = row["EthernetPort"].ToString();
                            ethernetPortNo = Convert.ToInt32(row["EthernetPort"]);

                            PdcPortNo = Convert.ToInt32(row["PdcPortNo"]);

                            //foreach (DataRow rows in BaseClass.EthernetPorts.Rows)
                            //{
                            //    if (BaseClass.EthernetPorts.Columns.Contains("PortNo") && int.TryParse(rows["PortNo"].ToString(), out int port))
                            //    {
                            //        if (port == ethernetPortNo)
                            //        {
                            //            ID = Convert.ToInt32(rows["PkeyMasterhub"]);

                            //        }

                            //    }
                            //}

                        }
                    }
                }

                foreach (DataRow row in boarddetailybyPk.Rows)
                {
                    if (boarddetailybyPk.Columns.Contains("FkeyofMasterHub") && int.TryParse(row["FkeyofMasterHub"].ToString(), out int PkMasterHub))
                    {
                        if (PkMasterHub == PkNumber)
                        {
                            txtPFDBoardid.Text = row["BoardID"].ToString();
                            txtPFDNooflines.Text = row["NoofLines"].ToString();
                            int Videovalue = Convert.ToInt32(row["VideoType"].ToString());
                            if (Videovalue == 0)
                            {
                                cmbPFDVideoType.Text = "Normal";
                            }
                            else
                            {
                                cmbPFDVideoType.Text = "Reverse";
                            }

                            CmbPFDLetterSpeed.Text = BaseClass.GetLetterSpeed(Convert.ToInt32(row["LetterSpeed"]));
                            CmbPFDFormattype.Text = BaseClass.GetFormattype(Convert.ToInt32(row["FormatType"]));
                            CmbPFDlettergap.Text = BaseClass.GetLetterGap(Convert.ToInt32(row["LetterGap"]));
                            CmbPFDDelaytime.Text = row["DelayTime"].ToString();
                            CmbPFDDisplayeffect.Text = BaseClass.GetDisplayeffect(Convert.ToInt32(row["DisplayEffect"]));
                            CmbPFDfontSize.Text = BaseClass.GetFontSize(Convert.ToInt32(row["FontSize"]));
                            txtPFDErasetime.Text = row["EraseTime"].ToString();

                            CmbPFDinfoDisplayed.Text = BaseClass.GetinfoDisplayed(Convert.ToInt32(row["InfoDisplayed"]));
                            txtMLDBEnglish.Text = row["LanEnglish"].ToString();
                            txtPfdRegional.Text = row["LanRegional"].ToString();
                            txtMLDBHindi.Text = row["LanHindi"].ToString();
                            checkPFDBoxShowMessages.Checked = (bool)row["MessagesEnble"];
                            Boolean value = (bool)row["BoardRunning"];
                            if (value)
                            {
                                rdbnPFDWorking.Checked = true;
                            }
                            else
                            {
                                rdbnPFDNotWorking.Checked = true;
                            }
                            ID = Convert.ToInt32(row["FkeyofMasterHub"]);
                            string checkedPlatforms = row["Checkedplatforms"].ToString(); ;
                            setPlatforms(checkedPlatforms);
                            string languages = row["DisplaySequence"].ToString(); ;
                            setDisplayLanguages(dgvLanguage, languages);

                        }
                    }
                }


            }
            else
            {

                ID = -1;



            }
        }
        private void setPlatforms(string Platforms)
        {
            var checkedPlatforms = Platforms.Split(',')
                                                      .Select(p => p.Trim())
                                                      .ToList();

            foreach (Control control in grupPFDPlatforms.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    if (checkedPlatforms.Contains(checkBox.Text.Trim()))
                    {
                        checkBox.Checked = true;
                    }
                    else
                    {
                        checkBox.Checked = false; // Optionally uncheck if not in the list
                    }
                }
            }
        }



        private void createPlatforms()
        {
            // Clear existing controls in the GroupBox
            grupPFDPlatforms.Controls.Clear();

            int xMargin = 10; // Margin from left
            int yMargin = 20; // Margin from top
            int checkBoxWidth = 40; // Width of each checkbox
            int checkBoxHeight = 20; // Height of each checkbox
            int xSpacing = 20; // Horizontal spacing between checkboxes
            int ySpacing = 10; // Vertical spacing between rows
            int maxColumns = 4; // Maximum number of checkboxes in a row

            int x = xMargin;
            int y = yMargin;

            // Loop through each value in the list
            foreach (string value in BaseClass.Platforms)
            {
                // Create a new CheckBox
                CheckBox checkBox = new CheckBox();

                // Set CheckBox properties
                checkBox.Text = value;
                checkBox.Font = new Font("Arial", 10);
                checkBox.AutoSize = true;

                // Set the location of the CheckBox
                checkBox.Location = new Point(x, y);

                // Add CheckBox to the GroupBox
                grupPFDPlatforms.Controls.Add(checkBox);

                // Adjust x and y coordinates for the next checkbox
                x += checkBoxWidth + xSpacing;

                // Start a new row if the maximum number of columns is reached
                if (grupPFDPlatforms.Controls.Count % maxColumns == 0)
                {
                    x = xMargin; // Reset x position
                    y += checkBoxHeight + ySpacing; // Move to the next row
                }
            }
        }

        private string ShowCheckedPlatforms()
        {
            // Retrieve the checked values
            List<string> checkedPlatforms = GetCheckedPlatforms();

            // Convert the list of values to a string for display
            string checkedValues = string.Join(",", checkedPlatforms);

            // Display the values in a message box
            return checkedValues;
        }

        private List<string> GetCheckedPlatforms()
        {
            List<string> checkedPlatforms = new List<string>();

            // Loop through each control in the GroupBox
            foreach (Control control in grupPFDPlatforms.Controls)
            {
                // Check if the control is a CheckBox and if it is checked
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    // Add the text of the checked CheckBox to the list
                    checkedPlatforms.Add(checkBox.Text);
                }
            }

            return checkedPlatforms;
        }
        public static void setDisplayLanguages(DataGridView dgvLanguage, string Languages)
        {
            // Clear the DataGridView rows
            dgvLanguage.Rows.Clear();

            // Split the input string into a list of languages, trimming any leading/trailing spaces
            List<string> displayLanguages = Languages.Split(',')
                                                     .Select(p => p.Trim())
                                                     .ToList();

            // Add each language as a new row in the DataGridView
            foreach (string language in displayLanguages)
            {
                dgvLanguage.Rows.Add(language);
            }
        }

        private void SetDisplaySequence()
        {
            dgvLanguage.Rows.Clear();
            foreach (string value in BaseClass.Languages)
            {

                dgvLanguage.Rows.Add(value);
                if (value != "English" && value != "Hindi")
                {
                    lblPfdRegional.Visible = true;
                    txtPfdRegional.Visible = true;
                    lblPfdRegional.Text = value; // Replace "Some text" with your desired text
                }
            }


            //lblMLDBRegional.Text = BaseClass.Languages[2];

        }
        private void SetDisplayEffects()
        {
            // Clear existing items in the ComboBox
            CmbPFDDisplayeffect.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Effects in BaseClass.DisplayEffects)
            {
                // Trim the platform name
                string trimmedEffects = Effects.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbPFDDisplayeffect.Items.Add(trimmedEffects);
            }
            // Select the default item "--Select--"
            CmbPFDDisplayeffect.SelectedIndex = 0;
        }
        private void SetInfoDisplay()
        {
            // Clear existing items in the ComboBox
            CmbPFDinfoDisplayed.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var infoDisplay in BaseClass.infoDisplayList)
            {
                // Trim the platform name
                string trimmedinfoDisplay = infoDisplay.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbPFDinfoDisplayed.Items.Add(trimmedinfoDisplay);
            }
            // Select the default item "--Select--"
            CmbPFDinfoDisplayed.SelectedIndex = 0;
        }
        private void SetLetterGap()
        {
            // Clear existing items in the ComboBox
            CmbPFDlettergap.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var LetterGap in BaseClass.LetterGapList)
            {
                // Trim the platform name
                string trimmedLetterGap = LetterGap.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbPFDlettergap.Items.Add(trimmedLetterGap);
            }
            // Select the default item "--Select--"
            CmbPFDlettergap.SelectedIndex = 0;
        }
        private void SetLetterSpeed()
        {
            // Clear existing items in the ComboBox
            CmbPFDLetterSpeed.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Speed in BaseClass.LetterSpeedlist)
            {
                // Trim the platform name
                string trimmedSpeed = Speed.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbPFDLetterSpeed.Items.Add(trimmedSpeed);
            }
            // Select the default item "--Select--"
            CmbPFDLetterSpeed.SelectedIndex = 0;
        }
        private void SetFormatType()
        {
            // Clear existing items in the ComboBox
            CmbPFDFormattype.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var FormatType in BaseClass.FormatsList)
            {
                // Trim the platform name
                string trimmedFormatType = FormatType.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbPFDFormattype.Items.Add(trimmedFormatType);
            }
            // Select the default item "--Select--"
            CmbPFDFormattype.SelectedIndex = 0;
        }
        private void SetFontSize()
        {
            // Clear existing items in the ComboBox
            CmbPFDfontSize.Items.Clear();
            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var Font in BaseClass.FontSizeList)
            {
                // Trim the platform name
                string trimmedFont = Font.Trim();

                // Add the trimmed platform name to the ComboBox
                CmbPFDfontSize.Items.Add(trimmedFont);
            }
            // Select the default item "--Select--"
            CmbPFDfontSize.SelectedIndex = 0;
        }
        private void SetIPAddress()
        {
            if (PkNumber == 0)
            {


                foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                {
                    if (BaseClass.EthernetPorts.Columns.Contains("EthernetPort") && int.TryParse(row["EthernetPort"].ToString(), out int PkMasterHub))
                    {
                        int ethernetvalue = Convert.ToInt32(txtPFDEthernetportno.Text);
                        if (PkMasterHub == ethernetvalue)
                        {
                            string ipaddress = ipAddressMldb.Text;

                            // Split the IP address into its octets
                            string[] octets = ipaddress.Split('.');

                            if (octets.Length == 4)
                            {
                                // Update the octets as required
                                octets[0] = "192";
                                octets[1] = "168";
                                octets[2] = row["Platform"].ToString().Trim();
                                octets[3] = ""; // Or any appropriate value

                                // Combine the octets back into a single string
                                string updatedIPAddress = string.Join(".", octets);

                                // Assign the updated IP address back to the text box
                                ipAddressMldb.Text = updatedIPAddress;
                            }
                            else
                            {
                                // Handle error: invalid IP address format
                                MessageBox.Show("Invalid IP address format.");
                            }

                            // Since platform matched and IP is updated, we can break the loop
                            break;
                        }
                    }
                }
            }
        }
        private bool ChecktheError(IPAddressControlLib.IPAddressControl ipControl)
        {
            if (string.IsNullOrWhiteSpace(ipControl.Text))
            {
                ipControl.BackColor = Color.Red; // Change background color to red to indicate error
                return true; // Indicate that this control has an error
            }
            else
            {
                ipControl.BackColor = SystemColors.Window; // Reset background color
                return false; // No error for this control
            }
        }
        private bool ChecktheIpError()
        {
            if (lblIpExist.Visible)
            {
                return true;
            }
            return false;
        }


        private bool CheckAndHighlightEmptyField(TextBox TextBox)
        {

            if (string.IsNullOrWhiteSpace(TextBox.Text))
            {
                TextBox.BackColor = Color.Red; // Change background color to red to indicate error
                return true; // Indicate that this text box has an error
            }
            else
            {
                TextBox.BackColor = SystemColors.Window; // Reset background color
                return false; // No error for this text box
            }
        }

        private void checkboxPFDAutoerasing_CheckedChanged(object sender, EventArgs e)
        {
            // Check if the checkbox is checked
            if (checkboxPFDAutoerasing.Checked)
            {
                // If checked, enable the panel
                txtPFDErasetime.Enabled = true;
            }
            else
            {
                // If unchecked, disable the panel
                txtPFDErasetime.Enabled = false;
            }
        }

        private void btnMLDBSave_Click(object sender, EventArgs e)
        {
            bool hasError = false; // Flag to track if there's any error

            // Check and highlight each required text box
            hasError |= CheckAndHighlightEmptyField(txtPFDBoardid);
            hasError |= ChecktheError(ipAddressMldb);
            hasError |= ChecktheIpError();
            hasError |= CheckAndHighlightEmptyField(txtPFDLocation);
            hasError |= CheckAndHighlightEmptyField(txtPFDEthernetportno);
            hasError |= CheckAndHighlightEmptyField(txtPFDNooflines);
            hasError |= CheckAndHighlightEmptyField(txtMLDBEnglish);
            hasError |= CheckAndHighlightEmptyField(txtMLDBHindi);
           // hasError |= CheckAndHighlightEmptyField(txtPfdRegional);

            // If any error is found, display error message and exit the method
            if (hasError)
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {

                int pdcPort = PdcPortNo;
                int packetidentifier = 3;
                int BoardId = Convert.ToInt32(txtPFDBoardid.Text.Trim());
                string location = txtPFDLocation.Text.Trim();
                int EthernetPort = Convert.ToInt32(txtPFDEthernetportno.Text.Trim());

                string ipaddress = ipAddressMldb.Text.Trim();
                string platformNo = GetPlatformbyIp(ipaddress).ToString();

                int noofLines = Convert.ToInt32(txtPFDNooflines.Text.Trim());
                bool message = checkPFDBoxShowMessages.Checked;
                bool boardRunning = CheckWhichRadioButtonIsChecked();
                string DisplaySequence = ShowColumnValues("dgvLanguages");
                string CheckedPlatforms = ShowCheckedPlatforms();
                string videoType = GetVideoType();
                string letterSpeed = GetletterSpeed();
                string FormatType = GetFormatType();
                string lettergap = Getlettergap();
                string DisplayEffect = GetDisplayeffect();
                int fontsize = GetFontSize();
                string infoDisplayed = GetinfoDisplayed();
                int DelayTime = Convert.ToInt32(CmbPFDDelaytime.Text.Trim());

                int EraseTime;
                if (int.TryParse(txtPFDErasetime.Text, out EraseTime))
                {

                }
                else
                {
                    // Handle the error, e.g., set a default value or show a message to the user
                    EraseTime = 60; // or any other default value// Optionally, you can inform the user about the incorrect input


                }
                string defaultEnglish = txtMLDBEnglish.Text.Trim();
                string defaultRegional = txtPfdRegional.Text.Trim();
                string defaultHindi = txtMLDBHindi.Text.Trim();
                int PortNo = GetPortNo(ethernetPortNo, PdcPortNo);

                // Show confirmation dialog
                DialogResult result = MessageBox.Show("Do you want to save the changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // If the user clicks Yes, proceed with saving the data
                if (result == DialogResult.Yes)
                {
                    int rows = HubConfigurationDb.SaveTadbBoard(
                               ID, pdcPort, BoardId, location, EthernetPort, ipaddress, platformNo, noofLines,
                              message, boardRunning, DisplaySequence, CheckedPlatforms, videoType, letterSpeed,
                               FormatType, lettergap, DisplayEffect, fontsize, infoDisplayed, DelayTime,
                              EraseTime, defaultEnglish, defaultRegional, defaultHindi, PortNo, packetidentifier);

                    if (rows > 0)
                    {
                        // Show success message for 10 seconds
                        lblStatus.Text = "Board Configuration saved successfully!";
                        lblStatus.ForeColor = Color.Green;
                        //board.Text = location;
                        BaseClass.RecallBoards();

                        byte[] LinkCheckPacket   =  frmHubConfiguration.PfdDefaultPacket(ipaddress, packetidentifier, letterSpeed,  noofLines, videoType, DisplayEffect, fontsize, lettergap, DelayTime, defaultEnglish, defaultRegional, defaultHindi,DisplaySequence);

                        Server.SendMessageToClient(ipaddress, LinkCheckPacket);
                    }
                    else
                    {
                        // Show failure message for 10 seconds
                        lblStatus.Text = "Failed to save Board configuration.";
                        lblStatus.ForeColor = Color.Red;
                    }

                    // Make the label visible
                    lblStatus.Visible = true;

                    // Start a timer to clear the label after 10 seconds
                    Timer timer = new Timer();
                    timer.Interval = 2000; // 5 seconds
                    timer.Tick += (s, _) =>
                    {
                        // Clear the label text and hide the label
                        lblStatus.Text = "";
                        lblStatus.Visible = false;

                        // Stop and dispose the timer
                        timer.Stop();
                        timer.Dispose();
                        this.Close();

                    };
                    timer.Start(); // Start the timer

                }



            }

        }

        private bool CheckWhichRadioButtonIsChecked()
        {
            if (rdbnPFDWorking.Checked)
            {
                return true; // rdbnMLDBWorking is checked
            }
            else if (rdbnPFDNotWorking.Checked)
            {
                return false; // rdbnMLDBNotWorking is checked
            }
            else
            {
                // Handle the case where neither radio button is checked
                // Return a default value or throw an exception if appropriate
                throw new InvalidOperationException("Neither radio button is checked.");
                // Alternatively, you could return a default value:
                // return false; // or true, depending on your logic
            }
        }


        private string GetinfoDisplayed()
        {
            // Get the selected speed from the ComboBox
            string info = CmbPFDinfoDisplayed.Text.Trim();

            // Iterate through each row in the DataTable
            foreach (DataRow row in BaseClass.infoDisplayDt.Rows)
            {
                // Check if the current row's LetterSpeed column matches the selected speed
                if (row["Info_Displayed"].ToString().Trim() == info.Trim())
                {
                    // Return the corresponding Pkey_LetterSpeed value
                    return row["Pk_Info_Displayed"].ToString();
                }
            }

            // Return a default value or handle the case where no match is found
            return "ID not found";
        }
        private int GetPortNo(int ethernetPortNo, int PdcPortNo)
        {
            int portno;
            if (PdcPortNo == 0)
            {
                portno = ethernetPortNo;
            }
            else
            {
                portno = 0;
            }


            return portno;
        }
        private int GetFontSize()
        {
            // Get the selected font size from the ComboBox
            string selectedFontSize = CmbPFDfontSize.Text.Trim();

            // Iterate through each row in the DataTable
            foreach (DataRow row in BaseClass.FontSizeDt.Rows)
            {
                // Check if the current row's Size column matches the selected font size
                if (row["Size"].ToString() == selectedFontSize)
                {
                    // Return the corresponding Pkey_Fonts value after casting it to int
                    return Convert.ToInt32(row["Pkey_Fonts"]);
                }
            }

            // Return a default value or handle the case where no match is found
            return -1;
        }

        private string Getlettergap()
        {
            // Get the selected speed from the ComboBox
            string lettergap = CmbPFDlettergap.Text.Trim();

            // Iterate through each row in the DataTable
            foreach (DataRow row in BaseClass.LetterGapDt.Rows)
            {
                // Check if the current row's LetterSpeed column matches the selected speed
                if (row["LetterGap"].ToString() == lettergap)
                {
                    // Return the corresponding Pkey_LetterSpeed value
                    return row["Pkey_LetterGap"].ToString();
                }
            }

            // Return a default value or handle the case where no match is found
            return "ID not found";
        }
        private string GetDisplayeffect()
        {
            // Get the selected speed from the ComboBox
            string DisplayEffect = CmbPFDDisplayeffect.Text.Trim();

            // Iterate through each row in the DataTable
            foreach (DataRow row in BaseClass.DisplayEffectsDt.Rows)
            {
                // Check if the current row's LetterSpeed column matches the selected speed
                if (row["Name"].ToString() == DisplayEffect)
                {
                    // Return the corresponding Pkey_LetterSpeed value
                    return row["Pkey_DisplayEffect"].ToString();
                }
            }

            // Return a default value or handle the case where no match is found
            return "ID not found";
        }
        private string GetFormatType()
        {
            // Get the selected speed from the ComboBox
            string format = CmbPFDFormattype.Text.Trim();

            // Iterate through each row in the DataTable
            foreach (DataRow row in BaseClass.FormatsDt.Rows)
            {
                // Check if the current row's LetterSpeed column matches the selected speed
                if (row["Format"].ToString() == format)
                {
                    // Return the corresponding Pkey_LetterSpeed value
                    return row["Pkey_FormatName"].ToString();
                }
            }

            // Return a default value or handle the case where no match is found
            return "ID not found";
        }
        private string GetletterSpeed()
        {
            // Get the selected speed from the ComboBox
            string speed = CmbPFDLetterSpeed.Text.Trim();

            // Iterate through each row in the DataTable
            foreach (DataRow row in BaseClass.LetterSpeedDt.Rows)
            {
                // Check if the current row's LetterSpeed column matches the selected speed
                if (row["LetterSpeed"].ToString() == speed)
                {
                    // Return the corresponding Pkey_LetterSpeed value
                    return row["Pkey_LetterSpeed"].ToString();
                }
            }

            // Return a default value or handle the case where no match is found
            return "ID not found";
        }

        private string GetVideoType()
        {
            string videotype = "";
            string video = cmbPFDVideoType.Text.Trim();
            if (video.Equals("Normal"))
            {
                videotype = "0";
            }
            else
            {
                videotype = "1";
            }
            return videotype;
        }
        private void MoveRowUp(int rowIndex)
        {
            // Ensure the row is not already at the top
            if (rowIndex > 0)
            {
                // Get the row to move and the row above it
                DataGridViewRow rowToMove = dgvLanguage.Rows[rowIndex];
                DataGridViewRow rowAbove = dgvLanguage.Rows[rowIndex - 1];

                // Swap the rows
                dgvLanguage.Rows.RemoveAt(rowIndex);
                dgvLanguage.Rows.Insert(rowIndex - 1, rowToMove);

                // Adjust the selection to reflect the move
                dgvLanguage.ClearSelection();
                dgvLanguage.Rows[rowIndex - 1].Selected = true;
            }
        }


        private void MoveRowDown(int rowIndex)
        {
            // Ensure the row is not already at the bottom
            if (rowIndex < dgvLanguage.Rows.Count - 1)
            {
                // Get the row to move and the row below it
                DataGridViewRow rowToMove = dgvLanguage.Rows[rowIndex];
                dgvLanguage.Rows.RemoveAt(rowIndex);
                dgvLanguage.Rows.Insert(rowIndex + 1, rowToMove);

                // Adjust the selection to reflect the move
                dgvLanguage.ClearSelection();
                dgvLanguage.Rows[rowIndex + 1].Selected = true;
            }
        }
        private List<object> GetColumnValues(string columnName)
        {
            List<object> columnValues = new List<object>();

            // Check if the column exists
            if (dgvLanguage.Columns.Contains(columnName))
            {
                // Loop through each row in the DataGridView
                foreach (DataGridViewRow row in dgvLanguage.Rows)
                {
                    // Get the cell in the specified column
                    DataGridViewCell cell = row.Cells[columnName];

                    // Ensure the cell is not null and not a new row placeholder
                    if (cell != null && !row.IsNewRow)
                    {
                        // Add the cell value to the list
                        columnValues.Add(cell.Value);
                    }
                }
            }

            return columnValues;
        }
        private string ShowColumnValues(string columnName)
        {
            // Retrieve the values from the specified column
            List<object> columnValues = GetColumnValues(columnName);

            // Convert the list of values to a string for display
            string valuesString = string.Join(", ", columnValues);


            return valuesString;
        }
        private (bool, int) IsLastOctetInRangeMLDB(string ipAddressMLDB, int startRange, int endRange)
        {
            // Validate that the input is a proper IP address
            if (IPAddress.TryParse(ipAddressMLDB, out IPAddress parsedIpAddress))
            {
                // Split the IP address into its octets
                string[] octets = ipAddressMLDB.Split('.');

                // Ensure there are exactly 4 octets
                if (octets.Length == 4)
                {
                    // Try to parse the last octet
                    if (int.TryParse(octets[3], out int lastOctet))
                    {
                        // Check if the last octet is within the specified range
                        bool isInRange = lastOctet >= startRange && lastOctet <= endRange;
                        return (isInRange, lastOctet);
                    }
                }
            }
            // Return false and -1 if the IP address is not valid or other parsing issues occurred
            return (false, -1);
        }
        private int GetPlatformbyIp(string ipAddressMLDB)
        {
            // Validate that the input is a proper IP address
            if (IPAddress.TryParse(ipAddressMLDB, out IPAddress parsedIpAddress))
            {
                // Split the IP address into its octets
                string[] octets = ipAddressMLDB.Split('.');

                // Ensure there are exactly 4 octets
                if (octets.Length == 4)
                {
                    // Try to parse the third octet
                    if (int.TryParse(octets[2], out int thirdOctet))
                    {
                        return thirdOctet;
                    }
                }
            }
            // Return -1 if the IP address is not valid or other parsing issues occurred
            return -1;
        }

        private void frmPFD_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmHubConfiguration frmhub;
            Form mainForm = Application.OpenForms["frmHubConfiguration"];

            if (mainForm != null)
            {
                frmhub = (frmHubConfiguration)mainForm;
                frmhub.ClearPanel();


            }

        }

        private void ipAddressMldb_TextChanged(object sender, EventArgs e)
        {
            // Get the selected platform from the ComboBox
            string iptext = ipAddressMldb.Text.Trim();
            string ExistedIp = "";
            foreach (DataRow row in BaseClass.EthernetPorts.Rows)
            {
                if (BaseClass.EthernetPorts.Columns.Contains("PkeyMasterhub") && int.TryParse(row["PkeyMasterhub"].ToString(), out int PkMasterHub))
                {
                    if (PkMasterHub == PkNumber)
                    {
                        ExistedIp = row["IPAddress"].ToString();
                    }

                }
            }
            foreach (DataRow row in BaseClass.EthernetPorts.Rows)
            {
                if (BaseClass.EthernetPorts.Columns.Contains("IPAddress"))
                {
                    string Ipaddress = row["IPAddress"].ToString();

                    if (iptext == Ipaddress && iptext != ExistedIp)
                    {
                        lblIpExist.Visible = true;
                        return;
                    }
                    else
                    {
                        lblIpExist.Visible = false;
                    }
                }
            }

        }

        private void ipAddressMldb_Leave(object sender, EventArgs e)
        {
            string ipAddress = ipAddressMldb.Text.Trim();

            // Get the result tuple from the method
            var result = IsLastOctetInRangeMLDB(ipAddress, 161, 190);
            bool isInRange = result.Item1;
            int lastOctet = result.Item2;

            if (!isInRange)
            {
                // Display error icon and message
                errorProviderPfdb.SetError(ipAddressMldb, "The last octet of the IP address must be between 161 and 190.");
                lblPFDBErrorMessage.Visible = true;
            }
            else
            {
                // Clear any previous error
                errorProviderPfdb.SetError(ipAddressMldb, "");
                lblPFDBErrorMessage.Visible = false;

                // Use the last octet value if needed
                txtPFDBoardid.Text = lastOctet.ToString();
            }
        }

        private void txtPFDErasetime_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the key pressed is a digit or a control key
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not a digit or control key, handle the event (prevent the character from being entered)
                e.Handled = true;
            }
        }

        private void txtPFDNooflines_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the key pressed is a digit or a control key
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not a digit or control key, handle the event (prevent the character from being entered)
                e.Handled = true;
            }
        }

        private void dgvLanguage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the current cell is in the up button column and it is not a header cell
            if (e.ColumnIndex == dgvLanguage.Columns["dgvUpButton"].Index && e.RowIndex >= 0)
            {
                MoveRowUp(e.RowIndex);
            }

            // Check if the current cell is in the down button column and it is not a header cell
            if (e.ColumnIndex == dgvLanguage.Columns["DgvDown"].Index && e.RowIndex >= 0)
            {
                MoveRowDown(e.RowIndex);
            }
        }

        private void txtMLDBEnglish_Enter(object sender, EventArgs e)
        {
            txtMLDBEnglish.BackColor = SystemColors.Window;
        }

        private void txtMLDBRegional_Enter(object sender, EventArgs e)
        {
            txtPfdRegional.BackColor = SystemColors.Window;
        }

        private void txtMLDBHindi_Enter(object sender, EventArgs e)
        {
            txtMLDBHindi.BackColor = SystemColors.Window;
        }

        private void ipAddressMldb_Enter(object sender, EventArgs e)
        {
            ipAddressMldb.BackColor = SystemColors.Window;
            txtPFDBoardid.BackColor = SystemColors.Window;
        }

        private void txtPFDLocation_Enter(object sender, EventArgs e)
        {
            txtPFDLocation.BackColor = SystemColors.Window;
        }

        private void txtPFDNooflines_Enter(object sender, EventArgs e)
        {
            txtPFDNooflines.BackColor = SystemColors.Window;
        }
    }
}

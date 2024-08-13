using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArecaIPIS.DAL;


namespace ArecaIPIS.Forms
{
    public partial class frmStationDetails : Form
    {
        public frmStationDetails()
        {
            InitializeComponent();

            KeyPressEventArgs();

        }
        StationConfigurationDb stationConfigurationDb = new StationConfigurationDb();

        private frmIndex parentForm;
        public frmStationDetails(frmIndex parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;

        }


        private void KeyPressEventArgs()
        {
            foreach (Control control in panPlatforms.Controls)
            {
                if (control is RichTextBox richTextBox)
                {
                    // Assign the KeyPress event handler to each RichTextBox
                    richTextBox.KeyPress += RichTextBox_KeyPress;
                }
            }
        }
        private void RichTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is not a letter or a digit
            if (!char.IsLetterOrDigit(e.KeyChar))
            {
                // Cancel the key press
                e.Handled = true;
            }
        }

        private void btnRightArrow_Click(object sender, EventArgs e)
        {
            // Check if adding the selected items will exceed the limit of four items in the destination list box
            if (listbSelectedLanguages.Items.Count + listbSelectLanguages.SelectedItems.Count > 4)
            {
                // Display a message box informing the user
                MessageBox.Show("You can only choose up to four languages.", "Limit Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method without performing the addition
            }

            // Add selected items to listbSelectedLanguages
            foreach (object item in listbSelectLanguages.SelectedItems)
            {
                listbSelectedLanguages.Items.Add(item);
            }

            // Remove selected items from listbSelectLanguages
            while (listbSelectLanguages.SelectedItems.Count > 0)
            {
                listbSelectLanguages.Items.Remove(listbSelectLanguages.SelectedItems[0]);
            }
        }



        private void btnLeftArrow_Click(object sender, EventArgs e)
        {
            // Create a list to store items to be removed
            List<object> itemsToRemove = new List<object>();

            foreach (object item in listbSelectedLanguages.SelectedItems)
            {
                if (item.ToString() == "English" || item.ToString() == "Hindi")
                {
                    MessageBox.Show(item.ToString() + " is mandatory");
                    // You might want to handle what happens when English or Hindi is mandatory.
                    // For example, you could prevent adding it to the list or take other actions.
                }
                else
                {
                    listbSelectLanguages.Items.Add(item);
                    itemsToRemove.Add(item); // Add the item to the list of items to be removed
                }
            }

            // Remove selected items from listbSelectedLanguages except "English" and "Hindi"
            foreach (object item in itemsToRemove)
            {
                listbSelectedLanguages.Items.Remove(item);
            }
        }


        static string GetLocalIPv4()
        {
            string ipAddress = "";

            // Get all network interfaces on the computer
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            // Loop through each network interface
            foreach (NetworkInterface networkInterface in networkInterfaces)
            {
                // Filter out loopback and non-operational interfaces
                if (networkInterface.OperationalStatus == OperationalStatus.Up &&
                    networkInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    // Get the IP properties for the selected network interface
                    IPInterfaceProperties ipProps = networkInterface.GetIPProperties();

                    // Loop through each unicast address
                    foreach (UnicastIPAddressInformation ipInfo in ipProps.UnicastAddresses)
                    {
                        // Check if it's an IPv4 address and not a loopback address
                        if (ipInfo.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork &&
                            !IPAddress.IsLoopback(ipInfo.Address))
                        {
                            ipAddress = ipInfo.Address.ToString();
                            return ipAddress;
                        }
                    }
                }
            }

            return ipAddress;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnSave.Visible = true;
            panStationDetails.Enabled = true;
            panPlatforms.Enabled = true;
            panSelectedLanguages.Enabled = true;
            panSelectLanguages.Enabled = true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool StationName = validateStationName();
            bool StationCode = validateStationCode();
            bool UPStationCode = validateUPStationCode();
            bool DOWNStationCode = validateDOWNStationCode();
            bool DivisionCode = validateDivisionCode();
            bool NoOfPlatforms = validateNoOfPlatforms();
            bool PortNo = validatePortNo();
            bool NoOfRowsTODisplay = validateNoOfRowsTODisplay();
            bool IpAddress = ValidateIpAddress();
            bool PlatformPanel = CheckRichTextBoxColors();
          
            // Check if all validations pass
            if (StationName && StationCode && UPStationCode && DOWNStationCode && DivisionCode &&
                NoOfPlatforms && PortNo && NoOfRowsTODisplay && IpAddress && PlatformPanel)
            {
                string GetPlatforms = GetEnabledRichTextBoxValues();
                List<string> platformsList = GetPlatforms.Split(',').ToList();


                if (string.IsNullOrEmpty(GetPlatforms))
                {
                    MessageBox.Show("The platform already exists.", "Platform Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    string StationNameTxt = rtxtStationName.Text;               // Captures text from rtxtStationName
                    string StationCodeTxt = rtxtStationCode.Text;               // Captures text from rtxtStationCode
                    string UPStationCodeTxt = rtxtUpStationCode.Text;           // Captures text from rtxtUpStationCode
                    string DOWNStationCodeTxt = rtxtDownStationCode.Text;       // Captures text from rtxtDownStationCode
                    string DivisionCodeTxt = rtxtDivisionCode.Text;             // Captures text from rtxtDivisionCode
                    string NoOfPlatformsTxt = rtxtNoOfPlatforms.Text;           // Captures text from rtxtNoOfPlatforms
                    string PortNoTxt = rtxtPortNo.Text;                         // Captures text from rtxtPortNo
                    string NoOfRowsTODisplayTxt = cmbNoOfRows.Text;             // Captures text from cmbNoOfRows
                    string IpAddressTxt = ipAddressControl1.Text;               // Captures text from ipAddressControl1
                    int b = listbSelectedLanguages.Items.Count;
                    int MainScreenDisplay = checkBoxMainScreen.Checked ? 1 : 0;

                    List<string> RegionalLanguages = selectedRegionalLanguages(listbSelectedLanguages);

                    // Call your method to get the DataTable of regional languages
                    DataTable languagesdt = BaseClass.SelectionRegionalLanguagesDt;

                    // Extract the values of the primary key column for matched languages and append them to a string
                    StringBuilder primaryKeyValues = new StringBuilder();
                    foreach (DataRow row in languagesdt.Rows)
                    {
                        // Assuming "Pkey_Language" is the name of your primary key column for languages
                        string language = row["LanguageName"].ToString();
                        string languagePK = row["Pkey_Language"].ToString();
                        // Check if the language is selected
                        if (RegionalLanguages.Contains(language))
                        {
                            primaryKeyValues.Append(languagePK).Append(", ");
                        }
                    }

                    // Remove the trailing comma and space, if any
                    if (primaryKeyValues.Length > 0)
                    {
                        primaryKeyValues.Remove(primaryKeyValues.Length - 2, 2);
                    }

                    // Now, primaryKeyValues.ToString() contains the concatenated primary key values separated by commas
                    string languages = primaryKeyValues.ToString();


                    DataTable dt = new DataTable();
                    dt.Columns.Add("PlatformPosition", typeof(Int32));
                    dt.Columns.Add("PlatformName", typeof(string));
                    for (int i = 0; i < platformsList.Count; i++)
                    {
                        int z = i + 1;
                        dt.Rows.Add(z, platformsList[i]);
                    }

                    // stationConfigurationDb.SaveStationConfiguration(StationNameTxt, StationCodeTxt, UPStationCodeTxt, DOWNStationCodeTxt, DivisionCodeTxt, int.Parse(NoOfPlatformsTxt), int.Parse(PortNoTxt), int.Parse(NoOfRowsTODisplayTxt), IpAddressTxt, RegionalLanguages,MainScreenDisplay);

                    //  int affectedrows = stationConfigurationDb.UpdateStationConfiguration( StationNameTxt, StationCodeTxt, UPStationCodeTxt, DOWNStationCodeTxt, DivisionCodeTxt, int.Parse(NoOfPlatformsTxt), int.Parse(PortNoTxt), int.Parse(NoOfRowsTODisplayTxt), IpAddressTxt, RegionalLanguages, MainScreenDisplay);
                    int affectedrows = stationConfigurationDb.InsertUpdateStationConfiguration(StationNameTxt, StationCodeTxt, UPStationCodeTxt, DOWNStationCodeTxt, DivisionCodeTxt, int.Parse(NoOfPlatformsTxt), int.Parse(PortNoTxt), int.Parse(NoOfRowsTODisplayTxt), IpAddressTxt, languages, MainScreenDisplay, dt);

                    if (affectedrows > 0)
                    {
                        // Show success message for 10 seconds
                        lblStatus.Text = "Station configuration saved successfully!";
                        lblStatus.ForeColor = Color.Green;
                      
                        btnSave.Visible = false;
                        panStationDetails.Enabled = false;
                        panPlatforms.Enabled = false;
                        panSelectedLanguages.Enabled = false;
                        panSelectLanguages.Enabled = false;
                        StationConfigurationDb.GetStationDetails();
                        BaseClass.setLanguages();
                        BaseClass.Platforms= StationConfigurationDb.GetPlatforms();
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


            }
            else
            {
                // At least one validation failed, show a message or take appropriate action
                MessageBox.Show("Please fill in all details correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            // Optionally, you can also perform other actions after the operation
            // For example:
            //panStationDetails.Enabled = false;
            //panPlatforms.Enabled = false;
            //btnSave.Visible = false;

        }

        public List<string> selectedRegionalLanguages(ListBox listBox)
        {
            List<string> selectedItems = new List<string>();

            foreach (var item in listBox.Items)
            {
                selectedItems.Add(item.ToString());
            }

            return selectedItems;
        }


        private void ValidatePlatformPanel()
        {
            platformsEnable();
            foreach (Control control in panPlatforms.Controls)
            {
                if (control is RichTextBox richTextBox && richTextBox.Enabled)
                {
                   
                    if (richTextBox.Enabled && string.IsNullOrWhiteSpace(richTextBox.Text))
                    {
                        richTextBox.BackColor = Color.Red; // Set background color to red
                    }
                    else
                    {
                        richTextBox.BackColor = SystemColors.Window; // Reset background color to default
                    }
                }
               
            }

            List<(string Name, Color BackColor)> richTextBoxDataList = new List<(string, Color)>();

            foreach (Control control in panPlatforms.Controls)
            {
                if (control is RichTextBox richTextBox && richTextBox.Enabled)
                {
                    richTextBoxDataList.Add((richTextBox.Name, richTextBox.BackColor));
                }
            }


        }

        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
            RichTextBox richTextBox = (RichTextBox)sender;

            // Check if the RichTextBox is enabled and its text is empty
            if (richTextBox.Enabled && string.IsNullOrWhiteSpace(richTextBox.Text))
            {
                richTextBox.BackColor = Color.Red; // Set background color to red
            }
            else
            {
                richTextBox.BackColor = SystemColors.Window; // Reset background color to default
            }
        }


        private bool CheckRichTextBoxColors()
        {
            ValidatePlatformPanel();

            foreach (Control control in panPlatforms.Controls)
            {
                if (control is RichTextBox richTextBox && richTextBox.Enabled)
                {
                    if (richTextBox.BackColor == Color.Red)
                    {
                        // Show a message box indicating the name of the RichTextBox with a red background color
               //         MessageBox.Show($"RichTextBox '{richTextBox.Name}' has a red background color.", "Red Background Color", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
            }



            return true;
        }

        private bool ValidateIpAddress()
        {
            string ipAddressString = ipAddressControl1.Text;

            IPAddress ipAddress;
            bool isValidIpAddress = IPAddress.TryParse(ipAddressString, out ipAddress);

            if (!isValidIpAddress)
            {
                // Show red color if the IP address is not valid
                ipAddressControl1.BackColor = Color.Red;
                return false;
            }
            else
            {
                // Reset the background color to its default value
                ipAddressControl1.BackColor = SystemColors.Window;
                return true;
            }
        }

        private bool validateStationCode()
        {
            string stationCode = rtxtStationCode.Text.Trim(); // Remove leading and trailing whitespace
            int textLength = stationCode.Length;

            // Validate station code length
            if (textLength < 1 || textLength > 4)
            {
               
                rtxtStationCode.BackColor = Color.Red;
                return false; 
            }
            else
            {
                
                rtxtStationCode.BackColor = SystemColors.Window;
                // Reset the border style to the default style
                rtxtStationCode.BorderStyle = BorderStyle.Fixed3D;

             
                return true;
                
            }
        }
        private bool validateUPStationCode()
        {
            string stationCode = rtxtUpStationCode.Text.Trim(); // Remove leading and trailing whitespace
            int textLength = stationCode.Length;

            // Validate station code length
            if (textLength < 1 || textLength > 4)
            {

                rtxtUpStationCode.BackColor = Color.Red;
                return false;
            }
            else
            {

                rtxtUpStationCode.BackColor = SystemColors.Window;
                // Reset the border style to the default style
                rtxtUpStationCode.BorderStyle = BorderStyle.Fixed3D;


                return true;

            }
        }
        private bool validateDOWNStationCode()
        {
            string stationCode = rtxtDownStationCode.Text.Trim(); // Remove leading and trailing whitespace
            int textLength = stationCode.Length;

            // Validate station code length
            if (textLength < 2 || textLength > 4)
            {

                rtxtDownStationCode.BackColor = Color.Red;
                return false;
            }
            else
            {

                rtxtDownStationCode.BackColor = SystemColors.Window;
                // Reset the border style to the default style
                rtxtDownStationCode.BorderStyle = BorderStyle.Fixed3D;


                return true;

            }
        }
        private bool validateDivisionCode()
        {
            string stationCode = rtxtDivisionCode.Text.Trim(); // Remove leading and trailing whitespace
            int textLength = stationCode.Length;

            // Validate station code length
            if (textLength < 2 || textLength > 4)
            {

                rtxtDivisionCode.BackColor = Color.Red;
                return false;
            }
            else
            {

                rtxtDivisionCode.BackColor = SystemColors.Window;
                
                rtxtDivisionCode.BorderStyle = BorderStyle.Fixed3D;


                return true;

            }
        }

        private bool validateStationName()
        {
            if (string.IsNullOrWhiteSpace(rtxtStationName.Text))
            {
                rtxtStationName.BackColor = Color.Red; // Set background color to red
                return false; // Return false if station name is empty or whitespace
            }
            else
            {
                rtxtStationName.BackColor = SystemColors.Window; // Reset background color
                return true; // Return true if station name is not empty or whitespace
            }
        }

        private bool validateNoOfPlatforms()
        {
            if (string.IsNullOrWhiteSpace(rtxtNoOfPlatforms.Text))
            {
                rtxtNoOfPlatforms.BackColor = Color.Red; // Set background color to red
                return false; // Return false if station name is empty or whitespace
            }
            else
            {
                rtxtNoOfPlatforms.BackColor = SystemColors.Window; // Reset background color
                return true; // Return true if station name is not empty or whitespace
            }
        }
        private bool validatePortNo()
        {
            if (string.IsNullOrWhiteSpace(rtxtPortNo.Text))
            {
                rtxtPortNo.BackColor = Color.Red; // Set background color to red
                return false; // Return false if station name is empty or whitespace
            }
            else
            {
                rtxtPortNo.BackColor = SystemColors.Window; // Reset background color
                return true; // Return true if station name is not empty or whitespace
            }
        }
        private bool validateNoOfRowsTODisplay()
        {
            if (string.IsNullOrWhiteSpace(cmbNoOfRows.Text))
            {
                cmbNoOfRows.BackColor = Color.Red; // Set background color to red
                return false; // Return false if station name is empty or whitespace
            }
            else
            {
                cmbNoOfRows.BackColor = SystemColors.Window; // Reset background color
                return true; // Return true if station name is not empty or whitespace
            }
        }




        private void frmStationDetails_Load(object sender, EventArgs e)
        {
            string ipAddress = GetLocalIPv4();
            GetRegionalLanguages();
            SetStationDetailsFromBaseClass();
            SetSelectedLanguages();
           // BaseClass.Platforms = StationConfigurationDb.GetPlatforms();
            SetPlatforms();
            
        }
        private void SetPlatforms()
        {
            for (int i = 1; i <= BaseClass.NoOfPlatforms; i++)
            {
                string richTextBoxName = "rtxtplatformNo" + i;

                // Find the RichTextBox control by its name
                RichTextBox richTextBox = Controls.Find(richTextBoxName, true).FirstOrDefault() as RichTextBox;

                // Check if the RichTextBox control was found
               
                    // Set the text for the RichTextBox control
                    richTextBox.Text = BaseClass.Platforms[i-1];
               
            }
        }


        private void SetStationDetailsFromBaseClass()
        {
            try
            {
                // Assign values from BaseClass properties to UI controls
                rtxtStationName.Text = BaseClass.StationName;
                rtxtStationCode.Text = BaseClass.StationCode;
                rtxtUpStationCode.Text = BaseClass.UpStationCode;
                rtxtDownStationCode.Text = BaseClass.DownStationCode;
                rtxtDivisionCode.Text = BaseClass.DivisionCode;
                rtxtNoOfPlatforms.Text = BaseClass.NoOfPlatforms.ToString();
                rtxtPortNo.Text = BaseClass.PortNo.ToString();
                cmbNoOfRows.Text = BaseClass.OnlineRows.ToString();
                //ipAddressControl1.Text = BaseClass.IpAddress;
                checkBoxMainScreen.Checked = BaseClass.MainsCoachDisplay == 1;

            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetSelectedLanguages()
        {
            listbSelectedLanguages.Items.Clear();

            // Add languages from BaseClass.Languages to the ComboBox
            foreach (string language in BaseClass.Languages)
            {
                listbSelectedLanguages.Items.Add(language);
            }
        }

        private void GetRegionalLanguages()
        {
            try
            {
                // Call your method to get the DataTable of regional languages
                DataTable languagesdt = BaseClass.SelectionRegionalLanguagesDt;

                // Clear the ListBox before adding new items
                listbSelectLanguages.Items.Clear();

                // Check if the DataTable is not null and contains data
                if (languagesdt != null && languagesdt.Rows.Count > 0)
                {
                    // Iterate through the rows of the DataTable
                    foreach (DataRow row in languagesdt.Rows)
                    {
                        string languageName = row["LanguageName"].ToString();

                        // Check if the languageName is not already present in listbSelectedLanguages
                        if (!listbSelectedLanguages.Items.Contains(languageName))
                        {
                            // Add the LanguageName from each row to the ListBox
                            listbSelectLanguages.Items.Add(languageName);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No regional languages found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private string GetEnabledRichTextBoxValues()
        {
            StringBuilder valuesBuilder = new StringBuilder();

            int numberOfPlatforms;
            if (int.TryParse(rtxtNoOfPlatforms.Text, out numberOfPlatforms))
            {
                bool firstValueAppended = false; // Flag to track if the first value is appended

                // Loop through the enabled RichTextBox controls
                for (int i = 1; i <= numberOfPlatforms; i++)
                {
                    string richTextBoxName = "rtxtplatformNo" + i;
                    Control[] richTextBoxes = this.Controls.Find(richTextBoxName, true);
                    if (richTextBoxes.Length > 0 && richTextBoxes[0] is RichTextBox richTextBox )
                    {
                        // Check if the value already exists in the string
                        if (valuesBuilder.ToString().Split(new string[] { ", " }, StringSplitOptions.None).Any(value => value.Equals(richTextBox.Text)))
                        {
                            // MessageBox.Show("The platform already exists.", "Platform Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return string.Empty;
                            // Return empty string if platform exists
                        }


                        // Append comma if not the first value
                        if (firstValueAppended)
                        {
                            valuesBuilder.Append(", ");
                        }

                        // Append the value of the enabled RichTextBox to the string
                        valuesBuilder.Append(richTextBox.Text);

                        // Update flag to indicate that the first value is appended
                        firstValueAppended = true;
                    }
                }
            }
          
            return valuesBuilder.ToString();
        }

    

       


        private void listbSelectedLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cast sender back to ListBox
            ListBox listBox = sender as ListBox;

            // Check if the number of selected items exceeds four
            if (listBox.SelectedItems.Count > 4)
            {
                // Display a message box informing the user
                MessageBox.Show("You can only choose up to four languages.", "Limit Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Deselect the last selected item
                listBox.SetSelected(listBox.SelectedIndex, false);
            }
        }

        private void listbSelectedLanguages_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void panStationDetails_Validating(object sender, CancelEventArgs e)
        {

        }

        private void rtxtStationName_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void rtxtStationName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a letter, space, or a control key
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && !char.IsControl(e.KeyChar))
            {
                // If it's not a letter, space, or a control key, suppress the key press
                e.Handled = true;
            }
        }

        private void rtxtStationCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the length is 4 characters
            if (rtxtStationCode.Text.Length >= 4)
            {
                // Allow only letters and control keys
                if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                    rtxtStationCode.BackColor = Color.Red; // Change textbox background color to red
                    rtxtStationCode.BorderStyle = BorderStyle.FixedSingle; // Set border style to show a red border
                    return;
                }
            }

            // Check if the pressed key is a letter or a control key
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                rtxtStationCode.BackColor = Color.Red; // Change textbox background color to red
                rtxtStationCode.BorderStyle = BorderStyle.FixedSingle; // Set border style to show a red border
            }
            else
            {
                // Check if the length is between 2 to 4 characters
                string text = rtxtStationCode.Text + e.KeyChar;
                if (text.Length < 2 || text.Length > 4)
                {
                    rtxtStationCode.BackColor = Color.Red; // Change textbox background color to red
                    rtxtStationCode.BorderStyle = BorderStyle.FixedSingle; // Set border style to show a red border
                }
                else
                {
                    rtxtStationCode.BackColor = SystemColors.Window; // Change textbox background color to default
                    rtxtStationCode.BorderStyle = BorderStyle.Fixed3D; // Set border style to show a default border
                }
            }
        }

        private void rtxtStationCode_MouseLeave(object sender, EventArgs e)
        {
            int textLength = rtxtStationCode.Text.Length;

            if (textLength < 2)
            {
                // Set the background color to red
                rtxtStationCode.BackColor = Color.Red;
            }
            else if (textLength >= 2 && textLength <= 4)
            {
                // Set the background color to the default color
                rtxtStationCode.BackColor = SystemColors.Window;
                // Reset the border style to the default style
                rtxtStationCode.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        private void rtxtDivisionCode_MouseLeave(object sender, EventArgs e)
        {
            int textLength = rtxtDivisionCode.Text.Length;

            if (textLength < 2)
            {
                // Set the background color to red
                rtxtDivisionCode.BackColor = Color.Red;
            }
            else if (textLength >= 2 && textLength <= 4)
            {
                // Set the background color to the default color
                rtxtDivisionCode.BackColor = SystemColors.Window;
                // Reset the border style to the default style
                rtxtDivisionCode.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        private void rtxtDivisionCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rtxtDivisionCode.Text.Length >= 5)
            {
                // Allow only letters and control keys
                if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                    rtxtDivisionCode.BackColor = Color.Red; // Change textbox background color to red
                    rtxtDivisionCode.BorderStyle = BorderStyle.FixedSingle; // Set border style to show a red border
                    return;
                }
            }

            // Check if the pressed key is a letter or a control key
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                rtxtDivisionCode.BackColor = Color.Red; // Change textbox background color to red
                rtxtDivisionCode.BorderStyle = BorderStyle.FixedSingle; // Set border style to show a red border
            }
            else
            {
                // Check if the length is between 2 to 4 characters
                string text = rtxtDivisionCode.Text + e.KeyChar;
                if (text.Length < 2 || text.Length >=5)
                {
                    rtxtDivisionCode.BackColor = Color.Red; // Change textbox background color to red
                    rtxtDivisionCode.BorderStyle = BorderStyle.FixedSingle; // Set border style to show a red border
                }
                else
                {
                    rtxtDivisionCode.BackColor = SystemColors.Window; // Change textbox background color to default
                    rtxtDivisionCode.BorderStyle = BorderStyle.Fixed3D; // Set border style to show a default border
                }
            }
        }

        private void rtxtPortNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a digit or a control key
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not a digit or a control key, suppress the key press
                e.Handled = true;
            }
        }

        private void rtxtNoOfPlatforms_KeyPress(object sender, KeyPressEventArgs e)
        {
            
                // Check if the pressed key is a digit or a control key
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    // If it's not a digit or a control key, suppress the key press
                    e.Handled = true;
                }
            

        }

        private void rtxtUpStationCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rtxtUpStationCode.Text.Length >= 4)
            {
                // Allow only letters and control keys
                if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                    rtxtUpStationCode.BackColor = Color.Red; // Change textbox background color to red
                    rtxtUpStationCode.BorderStyle = BorderStyle.FixedSingle; // Set border style to show a red border
                    return;
                }
            }

            // Check if the pressed key is a letter or a control key
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                rtxtUpStationCode.BackColor = Color.Red; // Change textbox background color to red
                rtxtUpStationCode.BorderStyle = BorderStyle.FixedSingle; // Set border style to show a red border
            }
            else
            {
                // Check if the length is between 2 to 4 characters
                string text = rtxtUpStationCode.Text + e.KeyChar;
                if (text.Length < 2 || text.Length > 4)
                {
                    rtxtUpStationCode.BackColor = Color.Red; // Change textbox background color to red
                    rtxtUpStationCode.BorderStyle = BorderStyle.FixedSingle; // Set border style to show a red border
                }
                else
                {
                    rtxtUpStationCode.BackColor = SystemColors.Window; // Change textbox background color to default
                    rtxtUpStationCode.BorderStyle = BorderStyle.Fixed3D; // Set border style to show a default border
                }
            }
        }

        private void rtxtUpStationCode_MouseLeave(object sender, EventArgs e)
        {
            int textLength = rtxtUpStationCode.Text.Length;

            if (textLength < 2)
            {
                // Set the background color to red
                rtxtUpStationCode.BackColor = Color.Red;
            }
            else if (textLength >= 2 && textLength <= 4)
            {
                // Set the background color to the default color
                rtxtUpStationCode.BackColor = SystemColors.Window;
                // Reset the border style to the default style
                rtxtUpStationCode.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        private void rtxtDownStationCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rtxtDownStationCode.Text.Length >= 4)
            {
                // Allow only letters and control keys
                if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                    rtxtDownStationCode.BackColor = Color.Red; // Change textbox background color to red
                    rtxtDownStationCode.BorderStyle = BorderStyle.FixedSingle; // Set border style to show a red border
                    return;
                }
            }

            // Check if the pressed key is a letter or a control key
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                rtxtDownStationCode.BackColor = Color.Red; // Change textbox background color to red
                rtxtDownStationCode.BorderStyle = BorderStyle.FixedSingle; // Set border style to show a red border
            }
            else
            {
                // Check if the length is between 2 to 4 characters
                string text = rtxtDownStationCode.Text + e.KeyChar;
                if (text.Length < 2 || text.Length > 4)
                {
                    rtxtDownStationCode.BackColor = Color.Red; // Change textbox background color to red
                    rtxtDownStationCode.BorderStyle = BorderStyle.FixedSingle; // Set border style to show a red border
                }
                else
                {
                    rtxtDownStationCode.BackColor = SystemColors.Window; // Change textbox background color to default
                    rtxtDownStationCode.BorderStyle = BorderStyle.Fixed3D; // Set border style to show a default border
                }
            }
        }

        private void rtxtDownStationCode_MouseLeave(object sender, EventArgs e)
        {
            int textLength = rtxtDownStationCode.Text.Length;

            if (textLength < 2)
            {
                // Set the background color to red
                rtxtDownStationCode.BackColor = Color.Red;
            }
            else if (textLength >= 2 && textLength <= 4)
            {
                // Set the background color to the default color
                rtxtDownStationCode.BackColor = SystemColors.Window;
                // Reset the border style to the default style
                rtxtDownStationCode.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        private void panPlatforms_Enter(object sender, EventArgs e)
        {
            // Loop through all RichTextBox controls within the panel
            foreach (Control control in panPlatforms.Controls)
            {
                if (control is RichTextBox richTextBox)
                {
                    // Assign the KeyPress event handler to each RichTextBox
                    richTextBox.KeyPress += RichTextBox_KeyPress;
                }
            }
            foreach (Control control in panPlatforms.Controls)
            {
                if (control is RichTextBox richTextBox && richTextBox.Enabled)
                {
                    // Attach TextChanged event handler to each enabled RichTextBox
                    richTextBox.TextChanged += RichTextBox_TextChanged;
                }
            }

        }

       
        

        private void rtxtStationCode_MouseDown(object sender, MouseEventArgs e)
        {
            int textLength = rtxtDownStationCode.Text.Length;

            if (textLength < 2)
            {
                // Set the background color to red
                rtxtDownStationCode.BackColor = Color.Red;
            }
            else if (textLength >= 2 && textLength <= 4)
            {
                // Set the background color to the default color
                rtxtDownStationCode.BackColor = SystemColors.Window;
                // Reset the border style to the default style
                rtxtDownStationCode.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        private void rtxtNoOfPlatforms_TextChanged(object sender, EventArgs e)
        {
           platformsEnable();
        }

        private void platformsEnable()
        {
            // Parse the number of platforms entered in rtxtNoOfPlatforms
            rtxtNoOfPlatforms.BackColor = SystemColors.Window;
            int numberOfPlatforms;
            if (int.TryParse(rtxtNoOfPlatforms.Text, out numberOfPlatforms))
            {
                // Enable RichTextBox controls up to the specified number of platforms
                for (int i = 1; i <= numberOfPlatforms; i++)
                {
                    string richTextBoxName = "rtxtplatformNo" + i;
                    Control[] richTextBoxes = panPlatforms.Controls.Find(richTextBoxName, true);
                    if (richTextBoxes.Length > 0 && richTextBoxes[0] is RichTextBox)
                 {
                        RichTextBox richTextBox = (RichTextBox)richTextBoxes[0];
                        richTextBox.Enabled = true;
                    }
                }
                // Disable RichTextBox controls beyond the specified number of platforms
                for (int i = numberOfPlatforms + 1; ; i++)
                {
                    string richTextBoxName = "rtxtplatformNo" + i;
                    Control[] richTextBoxes = panPlatforms.Controls.Find(richTextBoxName, true);
                    if (richTextBoxes.Length > 0 && richTextBoxes[0] is RichTextBox)
                    {
                        RichTextBox richTextBox = (RichTextBox)richTextBoxes[0];
                        richTextBox.Enabled = false;
                        richTextBox.Text = "";
                    }
                    else
                    {
                        break; // Exit the loop when no more RichTextBox controls are found
                    }
                }
            }
            else
            {
                // Handle invalid input (non-numeric or empty text)
                // You may want to show a message or take other actions here
            }
        }

        private void ipAddressControl1_TextChanged(object sender, EventArgs e)
        {
            ipAddressControl1.BackColor = SystemColors.Window;
        }

        private void rtxtStationCode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

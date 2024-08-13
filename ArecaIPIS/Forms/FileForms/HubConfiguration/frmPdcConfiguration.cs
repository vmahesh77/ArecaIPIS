using ArecaIPIS.DAL;
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
    public partial class frmPdcConfiguration : Form
    {
        public string dynamicPortNo { get; set; }
        public int PkNumber { get; set; }
        int ID ;
        public frmPdcConfiguration()
        {
            InitializeComponent();

            
        }
        public void SetPkHubValue(int pkvalue)
        {
            PkNumber = pkvalue;
        }
        private void PdcConfiguration_Load(object sender, EventArgs e)
        {
            cmbNoofports.SelectedIndex = 0;
            SetPlatforms();
            GetDetailsByPk();

        }
        private void GetDetailsByPk()
        {
            if (PkNumber != 0)
            {

                foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                {
                    if (BaseClass.EthernetPorts.Columns.Contains("PkeyMasterhub") && int.TryParse(row["PkeyMasterhub"].ToString(), out int PkMasterHub))
                    {
                        if (PkMasterHub == PkNumber)
                        {
                            cmbSelectPfno.Text= row["Platform"].ToString();
                            cmbNoofports.Text= row["NoofPorts"].ToString();
                            ipAddressControlplatform.Text= row["IPAddress"].ToString();
                            txtLocation.Text= row["Location"].ToString();
                            txtportno.Text = row["EthernetPort"].ToString();
                            ID = PkNumber;
                        }
                    }
                }
            }
            else
            {
                ID = -1;
            }
        }
        private void txtLocation_TextChanged(object sender, EventArgs e)
        {

        }
        public void SetPassedValue(Button button)
        {
            // Extract the numerical part from the button's name
            string buttonName = button.Name;
            string numericPart = new string(buttonName.Where(char.IsDigit).ToArray());

            // Convert the numeric part to an integer
            
                dynamicPortNo = numericPart;

                // Optionally, use the value immediately or update some controls with this value
                txtportno.Text = dynamicPortNo; // Assuming you have a textbox to display the value
           
                
            
        }

        private void SetPlatforms()
        {
            // Clear existing items in the ComboBox
            cmbSelectPfno.Items.Clear();

            // Add the default item "--Select--"
            cmbSelectPfno.Items.Add("--Select--");

            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var platform in BaseClass.Platforms)
            {
                // Trim the platform name
                string trimmedPlatform = platform.Trim();

                // Add the trimmed platform name to the ComboBox
                cmbSelectPfno.Items.Add(trimmedPlatform);
            }

            // Select the default item "--Select--"
            cmbSelectPfno.SelectedIndex = 0;
        }

        private void cmbSelectPfno_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected platform from the ComboBox
            string platform = cmbSelectPfno.Text.Trim();

            




            // Check if the selected item is not the default "--Select--"
            if (platform != "--Select--")
                {
                    // Extract the platform number
                    // Assuming the platform number is an integer and the platform string can be directly used
                    if (int.TryParse(platform, out int platformNumber))
                    {
                        // Create the IP address using the platform number
                        string ipAddress = $"192.168.{platformNumber}.251";

                        // Display or use the IP address as needed
                        // For example, displaying in a label or a textbox
                        ipAddressControlplatform.Text = ipAddress;
                    }
                    else
                    {
                        // Handle the case where the platform is not a valid number
                        MessageBox.Show("Invalid platform number selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Handle the case where the default item "--Select--" is selected
                    ipAddressControlplatform.Text = string.Empty; // Clear the IP address field
                }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string PlatformNo = cmbSelectPfno.Text;
            string noOfPorts = cmbNoofports.Text;
            string ipAddress = ipAddressControlplatform.Text;
            string Location = txtLocation.Text;
            int packetidentifier = 1;
            const string defaultSelection = "--Select--";
          
            // Check for null, empty, or default selection fields
            if (string.IsNullOrEmpty(PlatformNo) || PlatformNo == defaultSelection || lblPlatformError.Visible==true)
            {
                MessageBox.Show("Please select a valid platform number.");
                return;
            }

            if (string.IsNullOrEmpty(txtportno.Text))
            {
                MessageBox.Show("Please enter a port number.");
                return;
            }

            int pdcPortNo;
            if (!int.TryParse(txtportno.Text, out pdcPortNo))
            {
                MessageBox.Show("Please enter a valid port number.");
                return;
            }

            if (string.IsNullOrEmpty(noOfPorts) || noOfPorts == defaultSelection)
            {
                MessageBox.Show("Please select the number of ports.");
                return;
            }

            if (string.IsNullOrEmpty(ipAddress))
            {
                MessageBox.Show("Please enter an IP address.");
                return;
            }

            if (string.IsNullOrEmpty(Location))
            {
                MessageBox.Show("Please enter a location.");
                return;
            }

            // Show confirmation dialog
            DialogResult result = MessageBox.Show("Do you want to save the changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // If the user clicks Yes, proceed with saving the data
            if (result == DialogResult.Yes)
            {
             int rows=  HubConfigurationDb.SavePdcData(ID, PlatformNo, pdcPortNo, noOfPorts, ipAddress, Location, pdcPortNo, packetidentifier);

                if (rows > 0)
                {
                    BaseClass.RecallBoards();
                    this.Close();
                }
                else
                {
                    
                }
            }


        }

      


        


        private void cmbNoofports_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmPdcConfiguration_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmHubConfiguration frmhub;
            Form mainForm = Application.OpenForms["frmHubConfiguration"];

            if (mainForm != null)
            {
                frmhub = (frmHubConfiguration)mainForm;
                frmhub.ClearPanel();


            }

        }

        private void ipAddressControlplatform_TextChanged(object sender, EventArgs e)
        {
            // Get the selected platform from the ComboBox
            string iptext = ipAddressControlplatform.Text.Trim();
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
                        lblPlatformError.Visible = true;
                        return;
                    }
                    else
                    {
                        lblPlatformError.Visible = false;
                    }
                }
            }

        }
    }
}


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using ArecaIPIS;
using ArecaIPIS.Forms;
using System.Data;
using ArecaIPIS.DAL;
using ArecaIPIS.Classes;
using System.Text;
using System.Globalization;

namespace ArecaIPIS
{
    public partial class frmHubConfiguration : Form
    {
        // List to keep track of dynamically created buttons
        private List<Button> BoardButtons = new List<Button>();
        private List<Button> pdcBoardButtons = new List<Button>();

        private List<Button> buttonportslist = new List<Button>();
        private List<Button> imageButtonslist = new List<Button>();

        private string[] BoardLabels = { "PDC", "MLDB", "PFDB", "AGDB", "OVD", "IVD", "CCTV", "DELETE" };
        private string[] PdcBoardLabels = {"MLDB", "PFDB", "AGDB",  "IVD","CGDB", "DELETE" };
        Boolean PanelButtons = false;
        
        public frmHubConfiguration()
        {
            InitializeComponent();
            panHubConfiguration.Dock = DockStyle.Fill;
            panHubConfiguration.AutoScroll = true;
            panHubConfiguration.MouseClick += Panel_Click;
        }
        private frmIndex parentForm;
        public frmHubConfiguration(frmIndex parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;

        }



        private void btnEthernetports_Click(object sender, EventArgs e)
        {
            if (PanelButtons)
            {
                ClearPanel();
                PanelButtons = false;
            }
            else
            {
                PanelButtons = true;
                CreatePorts();
                SetPorts();
                CreateADDImageButton();
               
            }

            

        }
        public  void ClearPanel()
        {
            ClearEthernetPorts();
            ClearBoardButtons();
            
            ClearPdcBoardButtons();
            panPdcPorts.Visible = false;
        }


        private void SetPorts()
        {
           // DataTable ethernetports = HubConfigurationDb.GetEthernetPorts();


            // Loop through each button in the list of BoardButtons
            foreach (Button button in buttonportslist) 
            {
                String buttonName = button.Name;
                int portnumber = ExtractNumericPart(buttonName);

                foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                {
                    if (BaseClass.EthernetPorts.Columns.Contains("PortNo") && int.TryParse(row["PortNo"].ToString(), out int port))
                    {
                        if (portnumber == port)
                        {
                            button.Text = row["Location"].ToString();
                        }
                    }
                }

            }


        }


        private void CreatePorts()
        {
            // Assuming you have a panel named `panelHubConfiguration` to add the buttons to

    
            for (int i = 1; i <= 35; i++)
            {
                // Create a new button
                Button portButton = new Button
                {
                    Size = new Size(120, 25),
                    Location = new Point(30, 5 + (i - 1) * 30),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ImageAlign = ContentAlignment.MiddleLeft,
                    Text = "PORT " + i,
                    BackColor = Color.LightYellow,
                    ForeColor = Color.Red,
                    Font = new Font("Arial", 10),
                    Name = "PORT" + i
                };

                // Add MouseDown event handler
               
                portButton.MouseClick += PortButton_MouseClick;
                portButton.MouseDown += PortButton_MouseDown;
                portButton.Click += PortButton_Click;
                // Add the button to the panel
                panHubConfiguration.Controls.Add(portButton);
                buttonportslist.Add(portButton);
            }
        }
        private void PortButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            portClickEvent(clickedButton);

        }
        private void portClickEvent(Button clickedButton)
        {
            clickedButton.BackColor = Color.GreenYellow;
            ChangebackgroundColorPort(clickedButton);
            if (panPdcPorts.Visible == true)
            {

                panPdcPorts.Visible = false;
            }

           
            string buttonName = clickedButton.Name;
            int portnumber = ExtractNumericPart(buttonName);

            foreach (DataRow row in BaseClass.EthernetPorts.Rows)
            {
                if (BaseClass.EthernetPorts.Columns.Contains("PortNo") && int.TryParse(row["PortNo"].ToString(), out int port))
                {
                    if (portnumber == port)
                    {
                        if (int.TryParse(row["PacketIdentifier"].ToString(), out int packetIdentifier))
                        {
                            string BoardType = GetPacketname(packetIdentifier).Trim();

                            if (int.TryParse(row["PkeyMasterhub"].ToString(), out int HubPk))
                            {
                                OpenSelectedBoard(BoardType, HubPk);
                            }


                        }
                    }
                }
            }
            ChangebackgroundColorImagePorts();
        }

        private string GetPacketname(int packetIdentifier)
        {
            foreach (DataRow row in BaseClass.PacketIdentifier.Rows)
            {
                if (BaseClass.PacketIdentifier.Columns.Contains("pk") && int.TryParse(row["pk"].ToString(), out int packetno))
                {
                    if (packetno == packetIdentifier)
                    {
                        return row["Packet_name"].ToString();
                    }
                }
            }
            return null;
        }


        // Event handler for MouseDown event
        private void PortButton_MouseDown(object sender, MouseEventArgs e)
        {
            Button clickedButton = sender as Button;
            clickedButton.BackColor = Color.GreenYellow;
            ChangebackgroundColorPort(clickedButton);
            if (e.Button == MouseButtons.Right)
            {
                ClearBoardButtons();
                ClearPdcBoardButtons();
                ShowBoards(clickedButton);
                if (panPdcPorts.Visible == true)
                {
                    ClearDynamicButtons();
                    panPdcPorts.Visible = false;
                }
                
            }
             else if (e.Button == MouseButtons.Left)
            {

                portClickEvent(clickedButton);

            }

        }
        private void PortButton_MouseClick(object sender, MouseEventArgs e)
        {

            ClearBoardButtons();
            ClearPdcBoardButtons();
        }

        private void ChangebackgroundColorPort(Button button)
        {
            foreach (var btn in buttonportslist)
            {
                if (btn.Name != button.Name)
                {
                    btn.BackColor = Color.LightYellow; // Set the color to whatever you prefer
                }
                else
                {
                    btn.BackColor = Color.GreenYellow;
                }
            }
        }

        private void ChangebackgroundColorimage(Button button)
        {
            foreach (var btn in imageButtonslist)
            {
                if (btn.Name != button.Name)
                {
                    btn.BackColor = Color.LightYellow; // Set the color to whatever you prefer
                }
                else
                {
                    btn.BackColor = Color.GreenYellow;
                }
            }
        }
        private void ClearDynamicButtons()
        {
        //    foreach (Button button in dynamicButtons)
        //    {
        //        panHubConfiguration.Controls.Remove(button);
        //        button.Dispose();
        //    }
        //    dynamicButtons.Clear();

        }
        private void ClearBoardButtons()
        {

            foreach (Button button in BoardButtons)
            {
                panHubConfiguration.Controls.Remove(button);
                button.Dispose();
            }
            BoardButtons.Clear();
        }
        private void ClearEthernetPorts()
        {

            foreach (Button button in imageButtonslist)
            {
                panHubConfiguration.Controls.Remove(button);
                button.Dispose();
            }
            imageButtonslist.Clear();

            foreach (Button button in buttonportslist)
            {
                panHubConfiguration.Controls.Remove(button);
                button.Dispose();
            }
            buttonportslist.Clear();

        }
        private void ClearPdcBoardButtons()
        {

            foreach (Button button in pdcBoardButtons)
            {
                panHubConfiguration.Controls.Remove(button);
                button.Dispose();
            }
            pdcBoardButtons.Clear();
        }

        private void ClearimageButton(Button button)
        {
            // Loop through each control in the panel's controls collection
            foreach (Control control in panHubConfiguration.Controls)
            {
                // Check if the control is a Button and its name contains the name of the provided button concatenated with "image"
                if (control is Button imageButton && imageButton.Name.Contains(button.Name + "image"))
                {
                    // Remove the button from the panel
                    panHubConfiguration.Controls.Remove(imageButton);

                    // Dispose of the button
                    imageButton.Dispose();

                    // Exit the loop after deleting the first matching button
                    break;
                }
            }
        }




        
       
        private void Panel_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
              
            }
        }

       

        private void ShowBoards(Button buttonPort)
        {


            for (int i = 0; i < BoardLabels.Length; i++)
            {
                Button btnBoards = new Button();
                btnBoards.Size = new Size(80, 30);
                btnBoards.Location = new Point(buttonPort.Location.X+buttonPort.Width , buttonPort.Location.Y  + i * 30);
                btnBoards.Text = BoardLabels[i];
                btnBoards.BackColor = Color.Blue;
                btnBoards.ForeColor = Color.White;
                btnBoards.Font =new Font("Arial", 8);
                BoardButtons.Add(btnBoards);
                // btnBoards.MouseClick += btnBoards_MouseClick;
                btnBoards.MouseClick += (sender, e) => btnBoards_MouseClick(sender, e, buttonPort);
                panHubConfiguration.Controls.Add(btnBoards);
            }
        }

        private void OpenForm(Form form)
        {
            form.ShowDialog();
        }
        private void btnBoards_MouseClick(object sender, MouseEventArgs e,Button btnPort)
        {
            Button clickedButton = sender as Button;
            String name = btnPort.Name;
            if (clickedButton != null)
            {
                string buttonText = clickedButton.Text;
                //clickedButton.BackColor = Color.Yellow;

                switch (buttonText)
                {
                    case "PDC":
                        panelshowwindowsall.Controls.Clear();
                        frmPdcConfiguration pdcForm = new frmPdcConfiguration();
                        pdcForm.TopLevel = false;
                        pdcForm.FormBorderStyle = FormBorderStyle.None;
                        pdcForm.Dock = DockStyle.Fill;
                        panelshowwindowsall.Controls.Add(pdcForm);
                        pdcForm.Show();
                        pdcForm.SetPassedValue(btnPort);
                        btnPort.Text = buttonText;

                        ClearBoardButtons();
                      //  CreateAddButton(btnPort);
                        break;

                    case "MLDB":
                        panelshowwindowsall.Controls.Clear();
                        frmMLDB mldbForm = new frmMLDB();
                        mldbForm.TopLevel = false;
                        mldbForm.FormBorderStyle = FormBorderStyle.None;
                        mldbForm.Dock = DockStyle.Fill;
                        panelshowwindowsall.Controls.Add(mldbForm);
                        mldbForm.SetPassedValue(btnPort);
                        mldbForm.Show();
                        btnPort.Text = buttonText;
                        ClearBoardButtons();
                        //ClearimageButton(btnPort);
                        break;

                    case "PFDB":

                        panelshowwindowsall.Controls.Clear();
                        frmPFD pfdForm = new frmPFD();
                        pfdForm.TopLevel = false;
                        pfdForm.FormBorderStyle = FormBorderStyle.None;
                        pfdForm.Dock = DockStyle.Fill;
                        panelshowwindowsall.Controls.Add(pfdForm);
                        pfdForm.SetPassedValue(btnPort);
                        pfdForm.Show();
                        btnPort.Text = buttonText;
                        ClearBoardButtons();
                        break;

                    case "AGDB":
                        panelshowwindowsall.Controls.Clear();
                        frmAGDB agdbForm = new frmAGDB();
                        agdbForm.TopLevel = false;
                        agdbForm.FormBorderStyle = FormBorderStyle.None;
                        agdbForm.Dock = DockStyle.Fill;
                        panelshowwindowsall.Controls.Add(agdbForm);
                        agdbForm.SetPassedValue(btnPort);
                        agdbForm.Show();
                        btnPort.Text = buttonText;
                        ClearBoardButtons();
                        break;

                    case "OVD":
                        panelshowwindowsall.Controls.Clear();
                        frmOVD ovdForm = new frmOVD();
                        ovdForm.TopLevel = false;
                        ovdForm.FormBorderStyle = FormBorderStyle.None;
                        ovdForm.Dock = DockStyle.Fill;
                        panelshowwindowsall.Controls.Add(ovdForm);
                        ovdForm.SetPassedValue(btnPort);
                        ovdForm.Show();
                        btnPort.Text = buttonText;
                        ClearBoardButtons();
                        break;

                    case "IVD":
                        panelshowwindowsall.Controls.Clear();
                        frmIVD ivdForm = new frmIVD();
                        ivdForm.TopLevel = false;
                        ivdForm.FormBorderStyle = FormBorderStyle.None;
                        ivdForm.Dock = DockStyle.Fill;
                        panelshowwindowsall.Controls.Add(ivdForm);
                        ivdForm.SetPassedValue(btnPort);
                        ivdForm.Show();
                        btnPort.Text = buttonText;
                        ClearBoardButtons();
                        break;

                    case "CCTV":
                        panelshowwindowsall.Controls.Clear();
                        frmCCTV cctvForm = new frmCCTV();
                        cctvForm.TopLevel = false;
                        cctvForm.FormBorderStyle = FormBorderStyle.None;
                        cctvForm.Dock = DockStyle.Fill;
                        panelshowwindowsall.Controls.Add(cctvForm);
                      //  cctvForm.SetPassedValue(btnPort);
                        cctvForm.Show();
                        btnPort.Text = buttonText;
                        ClearBoardButtons();
                        break;
                    case "DELETE":
                        panelshowwindowsall.Controls.Clear();
                        DeletePort(btnPort);
                        break;


                    default:

                        break;
                }


            }

        }

        private void DeletePort(Button btnPort)
        {
            // Extract the name of the button
            string name = btnPort.Name;

            // Extract the numeric part from the name
            int portNumber = ExtractNumericPart(name);

            // Iterate through the rows in the EthernetPorts DataTable
            foreach (DataRow row in BaseClass.EthernetPorts.Rows)
            {
                // Check if the "PortNo" column exists and the port number matches
                if (BaseClass.EthernetPorts.Columns.Contains("PortNo") &&
                    int.TryParse(row["PortNo"].ToString(), out int port) &&
                    portNumber == port)
                {
                    // Check if the "PkeyMasterhub" column exists and can be parsed
                    if (BaseClass.EthernetPorts.Columns.Contains("EthernetPort") &&
                        int.TryParse(row["EthernetPort"].ToString(), out int ethernetPort))
                    {

                         int rowseffected = HubConfigurationDb.DeletePort(ethernetPort);
                        if (rowseffected > 0)
                        {
                            ClearPanel();
                            BaseClass.RecallBoards();
                        }
                        break; // Exit the loop after deleting the matching row
                    }
                }
            }

            // Accept changes to finalize row deletion
            BaseClass.EthernetPorts.AcceptChanges();
        }
        private void DeletePDCPort(Button btnpdcPort, int MainPort)
        {
            // Extract the name of the button
            string name = btnpdcPort.Name;

            // Extract the numeric part from the name
            int PdcportNumber = ExtractNumericPart(name);

            // Iterate through the rows in the EthernetPorts DataTable
            foreach (DataRow row in BaseClass.EthernetPorts.Rows)
            {
                // Check if all necessary columns exist and parse them
                if (BaseClass.EthernetPorts.Columns.Contains("EthernetPort") &&
                    BaseClass.EthernetPorts.Columns.Contains("PdcPortNo") &&
                    BaseClass.EthernetPorts.Columns.Contains("PkeyMasterhub"))
                {
                    if (int.TryParse(row["EthernetPort"].ToString(), out int port) &&
                        MainPort == port &&
                        int.TryParse(row["PdcPortNo"].ToString(), out int pdcport) &&
                        pdcport == PdcportNumber &&
                        int.TryParse(row["PkeyMasterhub"].ToString(), out int pkKey))
                    {
                        // Delete the port from the database
                        int rowsAffected = HubConfigurationDb.DeletePdcPort(pkKey);
                        if (rowsAffected > 0)
                        {
                            ClearPanel();
                            BaseClass.RecallBoards();
                        }

                        // Exit the loop after deleting the matching row
                        break;
                    }
                }
            }

            // Accept changes to finalize row deletion
            BaseClass.EthernetPorts.AcceptChanges();
        }


        private void pdcbtnBoards_MouseClick(object sender, MouseEventArgs e, Button btnPort,int MainPort)
        {
            Button clickedButton = sender as Button;
            String name = btnPort.Name;
            if (clickedButton != null)
            {
                string buttonText = clickedButton.Text;
                //clickedButton.BackColor = Color.Yellow;

                switch (buttonText)
                {
                    
                    case "MLDB":
                        panelshowwindowsall.Controls.Clear();
                        frmMLDB mldbForm = new frmMLDB();
                        mldbForm.TopLevel = false;
                        mldbForm.FormBorderStyle = FormBorderStyle.None;
                        mldbForm.Dock = DockStyle.Fill;
                        panelshowwindowsall.Controls.Add(mldbForm);
                        mldbForm.SetPassedValue(btnPort, MainPort);
                        mldbForm.Show();
                        btnPort.Text = buttonText;
                        ClearBoardButtons();
                        ClearPdcBoardButtons();
                       // ClearimageButton(btnPort);
                        break;

                    case "PFDB":
                        panelshowwindowsall.Controls.Clear();
                        frmPFD pfdForm = new frmPFD();
                        pfdForm.TopLevel = false;
                        pfdForm.FormBorderStyle = FormBorderStyle.None;
                        pfdForm.Dock = DockStyle.Fill;
                        panelshowwindowsall.Controls.Add(pfdForm);
                        pfdForm.SetPassedValue(btnPort, MainPort);
                        pfdForm.Show();
                        btnPort.Text = buttonText;
                        ClearBoardButtons();
                        ClearPdcBoardButtons();
                        break;

                    case "AGDB":
                        panelshowwindowsall.Controls.Clear();
                        frmAGDB agdbForm = new frmAGDB();
                        agdbForm.TopLevel = false;
                        agdbForm.FormBorderStyle = FormBorderStyle.None;
                        agdbForm.Dock = DockStyle.Fill;
                        panelshowwindowsall.Controls.Add(agdbForm);
                        agdbForm.SetPassedValue(btnPort);
                        agdbForm.Show();
                        btnPort.Text = buttonText;
                        ClearBoardButtons();
                        ClearPdcBoardButtons();
                        ClearimageButton(btnPort);
                        break;                   

                    case "IVD":
                        panelshowwindowsall.Controls.Clear();
                        frmIVD ivdForm = new frmIVD();
                        ivdForm.TopLevel = false;
                        ivdForm.FormBorderStyle = FormBorderStyle.None;
                        ivdForm.Dock = DockStyle.Fill;
                        panelshowwindowsall.Controls.Add(ivdForm);
                        ivdForm.SetPassedValue(btnPort);
                        ivdForm.Show();
                        btnPort.Text = buttonText;
                        ClearBoardButtons();
                        ClearPdcBoardButtons();
                        ClearimageButton(btnPort);
                        break;

                    case "CGDB":
                        panelshowwindowsall.Controls.Clear();
                        frmCGDB cgdbForm = new frmCGDB();
                        cgdbForm.TopLevel = false;
                        cgdbForm.FormBorderStyle = FormBorderStyle.None;
                        cgdbForm.Dock = DockStyle.Fill;
                        panelshowwindowsall.Controls.Add(cgdbForm);
                        cgdbForm.SetPassedValue(btnPort);
                        cgdbForm.Show();
                        btnPort.Text = buttonText;
                        ClearBoardButtons();
                        ClearPdcBoardButtons();
                        ClearimageButton(btnPort);
                        break;
                    case "DELETE":
                        panelshowwindowsall.Controls.Clear();
                        DeletePDCPort(btnPort, MainPort);
                        break;

                    default:

                        break;
                }


            }

        }

        private void CreateADDImageButton()
        {
            for (int i = 1; i <= 35; i++)
            {
                // Create a new button
                Button imageButton = new Button
                {
                    Size = new Size(18, 18),
                    Location = new Point(5, 10 + (i - 1) * 30),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ImageAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.LightYellow,
                    ForeColor = Color.Red,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    Name = $"PORT{i}image",
                    FlatStyle = FlatStyle.Flat,
                    Image = Properties.Resources._134224_add_plus_new_icon
                };

                imageButton.FlatAppearance.BorderSize = 0;

                // Add event handlers
                // imageButton.MouseClick += ImageButton_Click;
                imageButton.MouseDown += ImageButton_MouseDown;
                imageButton.Click += ImageButton_Click;

                // Add the button to the panel
                panHubConfiguration.Controls.Add(imageButton);
                imageButtonslist.Add(imageButton);
            }
        }
        private void ImageButton_MouseDown(object sender, EventArgs e)
        {
           ClearBoardButtons();
            Button clickedButton = sender as Button;
            clickEvent(clickedButton);
        }

            //private void CreateAddButton(Button btnport)
            //{
            //    // Create a new Button control
            //    Button imageButton = new Button();

            //    // Set the size of the button
            //    imageButton.Size = new Size(30, 30); // Adjust the size as needed

            //    // Calculate the new button's location to be beside the passed button
            //    // For example, placing it to the right of btnport with a small gap
            //    int newButtonX = btnport.Location.X - imageButton.Width - 10; // 10 is the gap between buttons
            //    int newButtonY = btnport.Location.Y;
            //    imageButton.Location = new Point(newButtonX, newButtonY);

            //    // Set the image for the button from the resources
            //    imageButton.Image = Properties.Resources._134224_add_plus_new_icon;


            //    // Set the button's properties to display only the image
            //    string name = btnport.Name;
            //    imageButton.Name = name+"image" ;
            //   // imageButton.Name = $"image{i + 1}";
            //    imageButton.FlatStyle = FlatStyle.Flat;
            //    imageButton.FlatAppearance.BorderSize = 0;
            //    imageButton.ImageAlign = ContentAlignment.MiddleCenter;

            //    // Add the button to the panel (assuming this method is in the form class)
            //    panHubConfiguration.Controls.Add(imageButton);
            //    imageButtonslist.Add(imageButton);
            //    // Optionally, you can add a click event handler for the button
            //    imageButton.Click += new EventHandler(ImageButton_Click);
            //}

            // Event handler for the button click event
            private void ImageButton_Click(object sender, EventArgs e)
        {

            Button clickedButton = sender as Button;

            clickEvent(clickedButton);
        }

        private void clickEvent(Button clickedButton)
        {
            ClearPdcBoardButtons();
            if (panPdcPorts.Visible)
            {
                ClearBoardButtons();
                panPdcPorts.Visible = false;
                
                OpenImageButton(clickedButton);
            }
            else
            {

              
                OpenImageButton(clickedButton);

            }

            clickedButton.BackColor = Color.GreenYellow;
            string clickedbuttonname = clickedButton.Name;
            int portNumber = ExtractNumericPart(clickedbuttonname);
            Button portButton = new Button
            {

                Name = "PORT" + portNumber
                // Set additional properties as needed
            };
            ChangebackgroundColorPort(portButton);
            ChangebackgroundColorimage(clickedButton);

            //ChangebackgroundColorPorts();
        }

        private void OpenImageButton(Button clickedButton)
        {
            if (clickedButton == null) return; // Ensure the sender is a Button

            string buttonName = clickedButton.Name;
            int portNumber = ExtractNumericPart(buttonName);

            foreach (DataRow row in BaseClass.EthernetPorts.Rows)
            {
                if (BaseClass.EthernetPorts.Columns.Contains("PortNo") &&
                    int.TryParse(row["PortNo"].ToString(), out int port) &&
                    portNumber == port)
                {
                    if (int.TryParse(row["PacketIdentifier"].ToString(), out int packetIdentifier) &&
                        packetIdentifier == 1)
                    {
                        if (int.TryParse(row["NoofPorts"].ToString(), out int noOfPorts))
                        {
                            // Set the location of panPdcPorts based on the location of clickedButton
                            panPdcPorts.Location = new Point(clickedButton.Location.X+15 + clickedButton.Width+110, clickedButton.Location.Y+5);

                            CreateSubEthernetPorts(noOfPorts, portNumber);
                            SetSubEthernetPorts(portNumber);

                        }
                    }
                }
            }
        }
        private void SetSubEthernetPorts(int portNumber)
        {
            foreach (Control control in panPdcPorts.Controls)
            {
                if (control is Button button)
                {


                    int EthernetNumber = ExtractNumericPart(button.Name);
                    foreach (DataRow row in BaseClass.EthernetPorts.Rows)
                    {
                        if (BaseClass.EthernetPorts.Columns.Contains("EthernetPort") &&
                              int.TryParse(row["EthernetPort"].ToString(), out int ethernetport) &&
                               ethernetport == portNumber && BaseClass.EthernetPorts.Columns.Contains("PdcPortNo") &&
                               int.TryParse(row["PdcPortNo"].ToString(), out int pdcPortnumber)&& pdcPortnumber == EthernetNumber)
                            {

                            button.Text = row["Location"].ToString();

                        }



                        
                    }
                }
            }
        }


        private void OpenSelectedBoard(string BoardType,int HubPk)
        {
            switch (BoardType)
            {
                case "PDC":
                    panelshowwindowsall.Controls.Clear();
                    frmPdcConfiguration pdcForm = new frmPdcConfiguration();
                    pdcForm.TopLevel = false;
                    pdcForm.FormBorderStyle = FormBorderStyle.None;
                    pdcForm.Dock = DockStyle.Fill;
                    panelshowwindowsall.Controls.Add(pdcForm);
                    pdcForm.SetPkHubValue(HubPk);
                    pdcForm.Show();
                    
                    ClearBoardButtons();
                   

                    break;
                case "MLDB":
                    panelshowwindowsall.Controls.Clear();
                    frmMLDB mldbForm = new frmMLDB();
                    mldbForm.TopLevel = false;
                    mldbForm.FormBorderStyle = FormBorderStyle.None;
                    mldbForm.Dock = DockStyle.Fill;
                    panelshowwindowsall.Controls.Add(mldbForm);
                    mldbForm.SetPkHubValue(HubPk);
                   
                    mldbForm.Show();
                   
                  
                    ClearPdcBoardButtons();
                   
                    break;

                case "PFDB":
                    panelshowwindowsall.Controls.Clear();
                    frmPFD pfdForm = new frmPFD();
                    pfdForm.TopLevel = false;
                    pfdForm.FormBorderStyle = FormBorderStyle.None;
                    pfdForm.Dock = DockStyle.Fill;
                    panelshowwindowsall.Controls.Add(pfdForm);
                    pfdForm.SetPkHubValue(HubPk);

                    pfdForm.Show();


                    ClearPdcBoardButtons();
                    break;

                case "AGDB":
                    panelshowwindowsall.Controls.Clear();
                    frmAGDB agdbForm = new frmAGDB();
                    agdbForm.TopLevel = false;
                    agdbForm.FormBorderStyle = FormBorderStyle.None;
                    agdbForm.Dock = DockStyle.Fill;
                    panelshowwindowsall.Controls.Add(agdbForm);
                    agdbForm.SetPkHubValue(HubPk);

                    agdbForm.Show();


                    ClearPdcBoardButtons();
                    break;

                //case "IVD":
                //    panelshowwindowsall.Controls.Clear();
                //    frmIVD ivdForm = new frmIVD();
                //    ivdForm.TopLevel = false;
                //    ivdForm.FormBorderStyle = FormBorderStyle.None;
                //    ivdForm.Dock = DockStyle.Fill;
                //    panelshowwindowsall.Controls.Add(ivdForm);
                //    ivdForm.SetPassedValue(btnPort);
                //    ivdForm.Show();
                //    btnPort.Text = buttonText;
                //    ClearBoardButtons();
                //    ClearPdcBoardButtons();
                //    ClearimageButton(btnPort);
                //    break;

                //case "CGDB":
                //    panelshowwindowsall.Controls.Clear();
                //    frmCGDB cgdbForm = new frmCGDB();
                //    cgdbForm.TopLevel = false;
                //    cgdbForm.FormBorderStyle = FormBorderStyle.None;
                //    cgdbForm.Dock = DockStyle.Fill;
                //    panelshowwindowsall.Controls.Add(cgdbForm);
                //    cgdbForm.SetPassedValue(btnPort);
                //    cgdbForm.Show();
                //    btnPort.Text = buttonText;
                //    ClearBoardButtons();
                //    ClearPdcBoardButtons();
                //    ClearimageButton(btnPort);
                //    break;


                default:

                    break;
            }


        }

        private void CreateSubEthernetPorts(int noOfPorts,int pdcportno)
        {
            // Clear existing controls
            panPdcPorts.Controls.Clear();
            panPdcPorts.Visible = true;
           
            // Initial y-coordinate and total height
            int yPos = 10;
            int totalHeight = 0;

            for (int i = 0; i < noOfPorts; i++)
            {
                // Create a new button
                Button EthernetportButton = new Button();
                EthernetportButton.Text = $"EthernetPort{i + 1}";
                EthernetportButton.Name = $"EthernetPort{i + 1}";
                EthernetportButton.Size = new Size(100, 30);
                EthernetportButton.BackColor = Color.CornflowerBlue;
                // Set the location of the button based on yPos
                EthernetportButton.Location = new Point(10, yPos);

                // Increment yPos for the next button
                yPos += EthernetportButton.Height + 5; // Add button height and some spacing

                EthernetportButton.MouseDown += (sender, e) =>
                {
                    // Access the button that triggered the event
                    Button button = sender as Button;

                    // Call the method with the button, event args, and additional value
                    EthernetPortButton_MouseDown(button, e, pdcportno);
                };
                EthernetportButton.Click += (sender, e) =>
                {
                    EthernetPortButton_Click(sender, e, pdcportno);
                };


                // Add the button to the panel
                panPdcPorts.Controls.Add(EthernetportButton);

                // Update total height
                totalHeight += EthernetportButton.Height + 5; // Add button height and spacing
            }

            // Adjust panel height
            panPdcPorts.Height = totalHeight + 5; // Add some extra space at the bottom
        }

        private void EthernetPortButton_Click(object sender, EventArgs e, int MainPort)
        {
            Button button=sender as Button;
            int EthernetNumber = ExtractNumericPart(button.Name);
            foreach (DataRow row in BaseClass.EthernetPorts.Rows)
            {
                if (BaseClass.EthernetPorts.Columns.Contains("EthernetPort") &&
                      int.TryParse(row["EthernetPort"].ToString(), out int ethernetport) &&
                       ethernetport == MainPort && BaseClass.EthernetPorts.Columns.Contains("PdcPortNo") &&
                       int.TryParse(row["PdcPortNo"].ToString(), out int pdcPortnumber) && pdcPortnumber == EthernetNumber)
                {

                    if (int.TryParse(row["PacketIdentifier"].ToString(), out int packetIdentifier))
                    {
                        string BoardType = GetPacketname(packetIdentifier).Trim();

                        if (int.TryParse(row["PkeyMasterhub"].ToString(), out int HubPk))
                        {
                            OpenSelectedBoard(BoardType, HubPk);
                        }


                    }

                }

            }

        }
            private void EthernetPortButton_MouseDown(object sender, MouseEventArgs e,int pdcportno)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button clickedButton = sender as Button;
                ClearPdcBoardButtons();

                 PdcUnderBoards(clickedButton, pdcportno);
            }
        }
        public int ExtractNumericPart(string buttonName)
        {
            // Initialize an empty string to store the numeric part
            string numericPart = "";

            // Iterate through each character in the button name
            foreach (char c in buttonName)
            {
                // Check if the character is a digit
                if (char.IsDigit(c))
                {
                    // If it's a digit, append it to the numeric part string
                    numericPart += c;
                }
            }

            // Convert the numeric part string to an integer and return it
            return int.Parse(numericPart);
        }

        private void PdcUnderBoards(Button buttonPort,int pdcvalue)
        {

            for (int i = 0; i < PdcBoardLabels.Length; i++)
            {
                Button pdcbtnBoards = new Button();
                pdcbtnBoards.Size = new Size(80, 30);
                // pdcbtnBoards.Location = new Point(270, 100 + i * 50);
                pdcbtnBoards.Location = new Point(panPdcPorts.Location.X +panPdcPorts.Width ,panPdcPorts.Location.Y +  i * 30);
                pdcbtnBoards.Text = PdcBoardLabels[i];
                pdcbtnBoards.BackColor = Color.Blue;
                pdcbtnBoards.ForeColor = Color.White;
                pdcbtnBoards.Font =  new Font("Arial", 10);
                pdcBoardButtons.Add(pdcbtnBoards);
               // dynamicButtons.Add(pdcbtnBoards);
                // btnBoards.MouseClick += btnBoards_MouseClick;
                pdcbtnBoards.MouseClick += (sender, e) => pdcbtnBoards_MouseClick(sender, e, buttonPort,pdcvalue);
                panHubConfiguration.Controls.Add(pdcbtnBoards);
            }
        }
       

        private void btnEthernetports_MouseDown(object sender, MouseEventArgs e)
        {
            //// Check if the right mouse button was clicked
            //if (e.Button == MouseButtons.Right)
            //{
            //    // Handle the right-click event
            //    MessageBox.Show("Right-click detected!");
            //}
        }
        private void ChangebackgroundColorPorts()
        {
            foreach (var btn in buttonportslist)
            {
               
                    btn.BackColor = Color.LightYellow; // Set the color to whatever you prefer
                
            }
        }

        private void ChangebackgroundColorImagePorts()
        {
            foreach (var btn in imageButtonslist)
            {

                btn.BackColor = Color.LightYellow; // Set the color to whatever you prefer

            }
        }

        private void frmHubConfiguration_Load(object sender, EventArgs e)
        {
          BaseClass.EthernetPorts=HubConfigurationDb.GetEthernetPorts();
        }
        public static byte[] CommonBytes(string boardIp, int packet)
        {
            string ipaddress = Server.ipAdress;
            string[] SystemIPArr = ipaddress.Split('.');
            string[] BoardIPAdress = boardIp.Split('.');

            //int thirdOctet = GetOctetbyIp(ipaddress, 3);
            //int FourthOctet = GetOctetbyIp(ipaddress, 4);

            Byte[] sendbyte = new Byte[10];   //creating an array
            sendbyte[0] = 170;    //AA
            sendbyte[1] = 204;    //CC
          //  Array.Resize(ref sendbyte, sendbyte.Length + 3);
            sendbyte[2] = (byte)packet;  //startPacket
            sendbyte[3] = 0;   //length
            sendbyte[4] = 0;     //length
           // Array.Resize(ref sendbyte, sendbyte.Length + 9);
            sendbyte[5] = Convert.ToByte(BoardIPAdress[2]);    //3rd octet of destination
            sendbyte[6] = Convert.ToByte(BoardIPAdress[3]);     //4th octet of destination
            sendbyte[7] = Convert.ToByte(SystemIPArr[2]);          //3rd octet of source
            sendbyte[8] = Convert.ToByte(SystemIPArr[3]);          //4th octet of  source
            sendbyte[9] = BaseClass.GetSerialNumber();    //serialNumber

          

            return sendbyte;
        }

        public static  byte[] PfdDefaultPacket(string ipaddress, int packetidentifier, string letterSpeed, int noofLines, string videoType,
                                string DisplayEffect, int fontsize, string lettergap, int DelayTime,
                                string defaultEnglish, string defaultRegional, string defaultHindi,string DisplaySequence)
        {
            Byte[] sendbyte = CommonBytes(ipaddress, packetidentifier);
            Array.Resize(ref sendbyte, sendbyte.Length + 2);
            int sodDataType = 2; //sod and defult and window
            sendbyte[10] = (byte)ArecaIPIS.Classes.Board.DefaultData;  //packet Type
            sendbyte[11] = 2;  //Sod
           
            int WindowsCount = 0;
            List<string> languageSequence = new List<string>(DisplaySequence.Split(','));
            List<int> languageSequencepk = new List<int>();

            foreach (string language in languageSequence)
            {
                string trimmedLanguage = language.Trim();
                var result = BaseClass.SelectionRegionalLanguagesDt.AsEnumerable()
                    .Where(row => row.Field<string>("LanguageName") == trimmedLanguage)
                    .Select(row => row.Field<int>("Pkey_Language"))
                    .FirstOrDefault();

                if (result != 0)
                {
                    languageSequencepk.Add(result);
                }
            }

           


            if (string.IsNullOrEmpty(defaultRegional))
            {
                WindowsCount = 2;
              
            }
            else
            {
                WindowsCount = 3;
                 
            }

            int WindowsLength = WindowsCount * 14;
            

            byte[] EnglishWindow = WindowFormation(packetidentifier, letterSpeed, noofLines, videoType,
                               DisplayEffect, fontsize, lettergap, DelayTime,
                                defaultEnglish, defaultRegional, defaultHindi);
            byte[] HindiWindow = WindowFormation(packetidentifier, letterSpeed, noofLines, videoType,
                               DisplayEffect, fontsize, "0", DelayTime,
                                defaultEnglish, defaultRegional, defaultHindi);
            byte[] RegionalWindow = new byte[0];
            if (WindowsCount == 3)
            {
                RegionalWindow = WindowFormation(packetidentifier, letterSpeed, noofLines, videoType,
                                   DisplayEffect, fontsize, lettergap, DelayTime,
                                    defaultEnglish, defaultRegional, defaultHindi);

            }
          
           




            int len = WindowsLength + 2;//window and first termination bytes 2

            Array.Resize(ref sendbyte, sendbyte.Length + len);

            
            int x = 12;
            int number = 1;
         

            foreach (int language in languageSequencepk)
            {
                  if (language == 6)//English
                    {
                       
                        for (int i = 0; i < EnglishWindow.Length ; i++)
                        {
                            sendbyte[x] = EnglishWindow[i];
                            x++;
                        }
                    }
                    else if (language == 16)//Hindi
                    {
                        for (int i = 0; i < HindiWindow.Length ; i++)
                        {
                            sendbyte[x] = HindiWindow[i];
                            x++;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < RegionalWindow.Length ; i++)
                        {
                            sendbyte[x] = RegionalWindow[i];
                            x++;
                        }
                    }
                
                    
                
            }




            Byte[] tb = GetTerminationBytes();
            sendbyte[sendbyte.Length - 2] = tb[0];
            sendbyte[sendbyte.Length - 1] = tb[1];
            int windowStartNumber = sendbyte.Length;

        
            

            byte[] EnglishDataBytes = GetEnglishBytes(defaultEnglish, fontsize);
            byte[] HindiDataBytes = GetHindiBytes(defaultHindi, fontsize);
            byte[] RegionalDataBytes = new byte[0];
            if (WindowsCount == 3)
            {
                RegionalDataBytes = GetRegionalBytes(defaultRegional, fontsize);

            }
            int dataBytesLength = EnglishDataBytes.Length + HindiDataBytes.Length + RegionalDataBytes.Length;
            Array.Resize(ref sendbyte, sendbyte.Length + dataBytesLength);
            int z = windowStartNumber;
            int k = windowStartNumber - 12;
            List<int> windowStrtPostions = new List<int>();

            foreach (int language in languageSequencepk)
            {
                windowStrtPostions.Add(k);

                       if (language == 6)//English
                       {
                        for (int i = 0; i < EnglishDataBytes.Length; i++)
                        {
                            sendbyte[z] = EnglishDataBytes[i];
                            z++;
                            k++;
                        }
                    }
                       else if (language == 16)//Hindi
                      {
                        for (int i = 0; i < HindiDataBytes.Length; i++)
                        {
                            sendbyte[z] = HindiDataBytes[i];
                            z++;
                            k++;
                        }
                    }
                    // Assuming the default behavior if the language is neither "English" nor "Hindi" when WindowsCount <= 2
                    else
                    {
                        for (int i = 0; i < RegionalDataBytes.Length; i++)
                        {
                            sendbyte[z] = RegionalDataBytes[i];
                            z++;
                            k++;
                        }
                    }
                
            }
             
                   



            byte[] firstwindowPostion = GetTwoBytesFromInt(windowStrtPostions[0]);
            sendbyte[12+14 - 2] = firstwindowPostion[0];
            sendbyte[12 + 14 - 1] = firstwindowPostion[1];


            byte[] SecondwindowPostion = GetTwoBytesFromInt(windowStrtPostions[1]);
            sendbyte[12 + 14+14 - 2] = SecondwindowPostion[0];
            sendbyte[12 + 14+14 - 1] = SecondwindowPostion[1];
            if (WindowsCount > 2)
            {
                byte[] ThirdwindowPostion = GetTwoBytesFromInt(windowStrtPostions[2]);
                sendbyte[12 + 14 + 14 + 14 - 2] = ThirdwindowPostion[0];
                sendbyte[12 + 14 + 14 + 14 - 1] = ThirdwindowPostion[1];

            }

           
          
            Array.Resize(ref sendbyte, sendbyte.Length + 4);
          
           

          
            sendbyte[sendbyte.Length - 4] = 3;
            sendbyte[sendbyte.Length - 3] = 0;
            sendbyte[sendbyte.Length - 2] = 0;          
            sendbyte[sendbyte.Length - 1] = 4;

            int packetLength = sendbyte.Length - 6;
            byte[] packetLengthBytes = GetTwoBytesFromInt(packetLength);
            sendbyte[3] = packetLengthBytes[0];
            sendbyte[4] = packetLengthBytes[1];
           
            Byte[] finalPacket = new Byte[sendbyte.Length + 12];   //final packet
            Array.Copy(sendbyte, 0, finalPacket, 6, sendbyte.Length);
            Byte[] value = Server.CheckSum(finalPacket);
            finalPacket[finalPacket.Length-9] = value[0];   //crc msb
            finalPacket[finalPacket.Length - 8] = value[1];    //crc lsb

          
            return finalPacket;

        }
        public static byte[] WindowFormation(
                          int packetidentifier, string letterSpeed, int noofLines, string videoType,
                     string DisplayEffect, int fontsize, string lettergap, int DelayTime,
                         string defaultEnglish, string defaultRegional, string defaultHindi)
        {
            
            byte[] byte1and2 = GetTwoBytesFromInt(1);
            byte[] byte3and4 = GetTwoBytesFromInt(336);
            byte[] byte5and6 = GetTwoBytesFromInt(16);
            byte[] byte7and8 = GetTwoBytesFromInt(1);
            byte byte9 = GetNineByte(videoType, letterSpeed);
            byte byte10 = GetTenthByte(DisplayEffect);
            byte byte11 = GetEleventhByte(lettergap, fontsize);
            byte byte12 = GetTwelvethByte(DelayTime);
           

            Byte[] sendbyte = new Byte[14];

            Array.Copy(byte1and2, 0, sendbyte, 0, 2);
            Array.Copy(byte3and4, 0, sendbyte, 2, 2);
            Array.Copy(byte5and6, 0, sendbyte, 4, 2);
            Array.Copy(byte7and8, 0, sendbyte, 6, 2);
            sendbyte[8] = byte9;
            sendbyte[9] = byte10;
            sendbyte[10] = byte11;
            sendbyte[11] = byte12;



            // Copy the Unicode bytes into the result array


            return sendbyte;
        }





        public static byte[] GetRegionalBytes(string RegionalText, int fontsize)
        {
            // Initialize englishUnicodeBytes with the values from CharacterString()
            byte[] initialBytes = characterString();
            byte[] gapCodeBytes = GapCodeRegional(RegionalText, fontsize, 336);
            // byte[] Extrabyte = new byte[1];
            // Extrabyte[0] = 0;

            // Convert the English text to Unicode byte array
            //  byte[] englishTextBytes = Encoding.Unicode.GetBytes(EnglishText);

            byte[] englishTextBytes = Encoding.BigEndianUnicode.GetBytes(RegionalText);


            // Get the termination bytes
            byte[] terminationBytes = GetTerminationBytes();

            // Create a new array to hold the initial bytes, the gap code bytes, the text bytes, and the termination bytes
            byte[] resultBytes = new byte[initialBytes.Length + gapCodeBytes.Length + englishTextBytes.Length + terminationBytes.Length];

            // Copy the initial bytes to the new array
            Array.Copy(initialBytes, 0, resultBytes, 0, initialBytes.Length);

            // Copy the gap code bytes to the new array
            Array.Copy(gapCodeBytes, 0, resultBytes, initialBytes.Length, gapCodeBytes.Length);


            // Copy the English text bytes to the new arra
            Array.Copy(englishTextBytes, 0, resultBytes, initialBytes.Length + gapCodeBytes.Length, englishTextBytes.Length);

            // Copy the termination bytes to the end of the new array
            Array.Copy(terminationBytes, 0, resultBytes, initialBytes.Length + gapCodeBytes.Length + englishTextBytes.Length, terminationBytes.Length);

            return resultBytes;
        }

        public static byte[] GetEnglishBytes(string EnglishText, int fontsize)
        {
            // Initialize englishUnicodeBytes with the values from CharacterString()
            byte[] initialBytes = characterString();
            byte[] gapCodeBytes = GapCode(EnglishText,  fontsize,336);
           // byte[] Extrabyte = new byte[1];
           // Extrabyte[0] = 0;

            // Convert the English text to Unicode byte array
          //  byte[] englishTextBytes = Encoding.Unicode.GetBytes(EnglishText);

            byte[] englishTextBytes = Encoding.BigEndianUnicode.GetBytes(EnglishText);

          
            // Get the termination bytes
            byte[] terminationBytes = GetTerminationBytes();

            // Create a new array to hold the initial bytes, the gap code bytes, the text bytes, and the termination bytes
            byte[] resultBytes = new byte[initialBytes.Length + gapCodeBytes.Length + englishTextBytes.Length + terminationBytes.Length ];

            // Copy the initial bytes to the new array
            Array.Copy(initialBytes, 0, resultBytes, 0, initialBytes.Length);
            
            // Copy the gap code bytes to the new array
            Array.Copy(gapCodeBytes, 0, resultBytes, initialBytes.Length, gapCodeBytes.Length);

         
            // Copy the English text bytes to the new arra
            Array.Copy(englishTextBytes, 0, resultBytes, initialBytes.Length + gapCodeBytes.Length , englishTextBytes.Length);

            // Copy the termination bytes to the end of the new array
            Array.Copy(terminationBytes, 0, resultBytes, initialBytes.Length + gapCodeBytes.Length + englishTextBytes.Length  , terminationBytes.Length);

            return resultBytes;
        }

        public static byte[] GetHindiBytes(string HindiText, int fontsize)
        {
            // Initialize hindiUnicodeBytes with the values from CharacterString()
            byte[] initialBytes = characterString();
            byte[] gapCodeBytes = GapCodeHindi(HindiText, fontsize, 336);

            // Convert the Hindi text to Unicode byte array (using BigEndianUnicode)
             byte[] hindiTextBytes = Encoding.BigEndianUnicode.GetBytes(HindiText);
          //  byte[] hindiTextBytes= GetUnicodeByteArrayWithZeroes(HindiText);

            //string hexString = Server.ByteArrayToHexString(hindiTextBytes);
            // Get the termination bytes
            byte[] terminationBytes = GetTerminationBytes();

            // Create a new array to hold the initial bytes, the gap code bytes, the text bytes, and the termination bytes
           byte[] resultBytes = new byte[initialBytes.Length + gapCodeBytes.Length + hindiTextBytes.Length + terminationBytes.Length];

            // Copy the initial bytes to the new array
            Array.Copy(initialBytes, 0, resultBytes, 0, initialBytes.Length);

            // Copy the gap code bytes to the new array
            Array.Copy(gapCodeBytes, 0, resultBytes, initialBytes.Length, gapCodeBytes.Length);

            // Copy the Hindi text bytes to the new array
            Array.Copy(hindiTextBytes, 0, resultBytes, initialBytes.Length + gapCodeBytes.Length, hindiTextBytes.Length);

            // Copy the termination bytes to the end of the new array
             Array.Copy(terminationBytes, 0, resultBytes, initialBytes.Length + gapCodeBytes.Length + hindiTextBytes.Length, terminationBytes.Length);

            return resultBytes;
        }

 

        public static string[] ConvertToUnicodeStrings(string englishText)
        {
            string[] unicodeStrings = new string[englishText.Length];

            for (int i = 0; i < englishText.Length; i++)
            {
                // Convert each character to its corresponding Unicode value
                int unicodeValue = char.ConvertToUtf32(englishText, i);

                // Convert the Unicode value to a hexadecimal string
                unicodeStrings[i] = $"{unicodeValue:X2}";
            }

            return unicodeStrings;
        }

        public static string[] ConvertToHindiUnicodeStrings(string HindiText)
        {
            string[] unicodeStrings = new string[HindiText.Length];

            for (int i = 0; i < HindiText.Length; i++)
            {
                // Convert each character to its corresponding Unicode value
                int unicodeValue = char.ConvertToUtf32(HindiText, i);

                // Convert the Unicode value to a hexadecimal string
                unicodeStrings[i] = $"{unicodeValue:X2}";
            }

            return unicodeStrings;
        }
        static List<string> GetUnicodeCombinationsList(string inputString)
        {
            StringInfo stringInfo = new StringInfo(inputString);
            var combinationsList = new List<string>();

            for (int i = 0; i < stringInfo.LengthInTextElements; i++)
            {
                string textElement = stringInfo.SubstringByTextElements(i, 1);
                List<string> unicodeBytesList = new List<string>();

                for (int j = 0; j < textElement.Length; j++)
                {
                    char character = textElement[j];
                    byte unicodeByte = (byte)character;
                    unicodeBytesList.Add($"{unicodeByte:X2}");
                }

                // Join the Unicode bytes with a comma if there are multiple bytes
                string combinedBytes = string.Join(",", unicodeBytesList);
                combinationsList.Add(combinedBytes);
            }

            return combinationsList;
        }

        public static int GetEnglishBitmapLength(string EnglishText, int fontSize)
        {
            int len = 0;
        
            string[] unicodeStrings = ConvertToUnicodeStrings(EnglishText);
            // Get the DataTable with English Unicode data based on font size
            DataTable EnglishUnicodes = HubConfigurationDb.GetEnglishBitMap(fontSize);

            // Check if the DataTable contains the necessary column
            if (EnglishUnicodes.Columns.Contains("Unicodes"))
            {
                // Iterate through each character in the English text
                foreach (string c in unicodeStrings)
                {
                    // Iterate through each row in the DataTable
                    foreach (DataRow row in EnglishUnicodes.Rows)
                    {
                        // Get the Unicode value from the current row
                        string unicodeValue = row["Unicodes"].ToString();

                        // Check if the current Unicode value matches the character
                        if (c == unicodeValue)
                        {
                            // Get the length of the Unicode character from the DataTable and add it to the total length
                            int bitLength;
                            if (int.TryParse(row["BitmapLength"].ToString(), out bitLength))
                            {
                                len += bitLength;
                            }
                            break; // Exit the inner loop once the match is found
                        }
                    }
                }
            }
            else
            {
                // Handle the case where the necessary column is not found in the DataTable
                // You may want to log or handle this situation differently based on your requirements
                Console.WriteLine("DataTable does not contain the 'Unicode' column.");
            }

            return len;
        }
        public static int GetHindiBitmapLength(string HindiText, int fontSize)
        {
            int len = 0;

            List<string> unicodeStrings = GetUnicodeCombinationsList(HindiText);
            // Get the DataTable with Hindi Unicode data based on font size
            DataTable HindiUnicodes = HubConfigurationDb.GetHindiBitMap(fontSize);

            // Check if the DataTable contains the necessary column
            if (HindiUnicodes.Columns.Contains("Unicodes"))
            {
                // Iterate through each Unicode string
                foreach (string unicodeString in unicodeStrings)
                {
                    // Iterate through each row in the DataTable
                    foreach (DataRow row in HindiUnicodes.Rows)
                    {
                        // Get the Unicode value from the current row
                        string unicodeValue = row["Unicodes"].ToString();

                        // Check if the current Unicode value matches the Unicode string
                        if (unicodeString == unicodeValue)
                        {
                            // Get the length of the Unicode character from the DataTable and add it to the total length
                            if (int.TryParse(row["BitmapLength"].ToString(), out int bitLength))
                            {
                                len += bitLength;
                            }
                            break; // Exit the inner loop once the match is found
                        }
                    }
                }
            }
            else
            {
                // Handle the case where the necessary column is not found in the DataTable
                Console.WriteLine("DataTable does not contain the 'Unicodes' column.");
            }

            return len;
        }
        public static int GetRegionalBitmapLength(string RegionalText, int fontSize)
        {
            int len = 0;

            List<string> unicodeStrings = GetUnicodeCombinationsList(RegionalText);
            // Get the DataTable with Hindi Unicode data based on font size
            DataTable HindiUnicodes = HubConfigurationDb.GetRegionalBitMap(fontSize);

            // Check if the DataTable contains the necessary column
            if (HindiUnicodes.Columns.Contains("Unicodes"))
            {
                // Iterate through each Unicode string
                foreach (string unicodeString in unicodeStrings)
                {
                    // Iterate through each row in the DataTable
                    foreach (DataRow row in HindiUnicodes.Rows)
                    {
                        // Get the Unicode value from the current row
                        string unicodeValue = row["Unicodes"].ToString();

                        // Check if the current Unicode value matches the Unicode string
                        if (unicodeString == unicodeValue)
                        {
                            // Get the length of the Unicode character from the DataTable and add it to the total length
                            if (int.TryParse(row["BitmapLength"].ToString(), out int bitLength))
                            {
                                len += bitLength;
                            }
                            break; // Exit the inner loop once the match is found
                        }
                    }
                }
            }
            else
            {
                // Handle the case where the necessary column is not found in the DataTable
                Console.WriteLine("DataTable does not contain the 'Unicodes' column.");
            }

            return len;
        }


        public static byte[] GetTerminationBytes()
        {
            byte[] terminationBytes = { (byte)0xFF, (byte)0xFF };
            return terminationBytes;
        }

        public static byte[] characterString()
        {
            byte[] characterString = { 0x00, 0x00, 0x00, 0x00, 0x01 };
            return characterString;
        }

        public static byte[] GapCodeHindi(string HindiText, int fontsize, int BoardWidth)
        {

            //byte[] GapCode = new byte[] { 0xE7, 0x00, 0x00, 0x03 };
            int length = GetHindiBitmapLength(HindiText, fontsize);
            int startpostion = GetStartPosition(length, BoardWidth);
            byte[] byte2and3 = GetTwoBytesFromInt(startpostion);
            byte[] GapCode = new byte[] { 0xE7, 0x00 };
            Array.Resize(ref GapCode, GapCode.Length + 2);
            GapCode[2] = byte2and3[0];
            GapCode[3] = byte2and3[1];
            return GapCode;
        }
        public static byte[] GapCodeRegional(string RegionalText, int fontsize, int BoardWidth)
        {

            // byte[] GapCode = new byte[] { 0xE7, 0x00, 0x00, 0x03 };
            int length = GetRegionalBitmapLength(RegionalText, fontsize);
            int startpostion = GetStartPosition(length, BoardWidth);
            byte[] byte2and3 = GetTwoBytesFromInt(startpostion);
            byte[] GapCode = new byte[] { 0xE7, 0x00 };
            Array.Resize(ref GapCode, GapCode.Length + 2);
            GapCode[2] = byte2and3[0];
            GapCode[3] = byte2and3[1];

            return GapCode;
        }


        public static byte[] GapCode(string EnglishText, int fontsize ,int BoardWidth)
        {
           int length =GetEnglishBitmapLength( EnglishText, fontsize);
                 int startpostion=   GetStartPosition(length, BoardWidth);
            byte[] byte2and3 =   GetTwoBytesFromInt(startpostion);
            byte[] GapCode = new byte[] { 0xE7, 0x00 };
            Array.Resize(ref GapCode, GapCode.Length + 2);
            GapCode[2] = byte2and3[0];
            GapCode[3] = byte2and3[1];
            return GapCode;
        }
        public static int GetStartPosition(int bitlength, int boardWidth)
        {
            int actualbitLength = bitlength / 2;//two bits contain one line
            int startPostion = 0;
            if (actualbitLength >= boardWidth)
            {
                startPostion = 1;
            }
            else
            {
                int halfBWidth = boardWidth / 2;
                int halfbitlength = actualbitLength / 2;
                startPostion = halfBWidth - halfbitlength;
            }
             

          
            return startPostion;
        }

        public static byte[] GetTwoBytesFromInt(int input)
        {
            // Ensure the input is within the range that can be represented by two bytes
            if (input < 0 || input > 65535)
            {
                throw new ArgumentOutOfRangeException(nameof(input), "Input must be between 0 and 65535.");
            }

            // Create a byte array to hold the result
            byte[] resultBytes = new byte[2];

            // Store the higher byte in the first position
            resultBytes[0] = (byte)((input >> 8) & 0xFF);

            // Store the lower byte in the second position
            resultBytes[1] = (byte)(input & 0xFF);

            return resultBytes;
        }

        private static string GetUnicodeString(byte[] unicodeBytes)
        {
            // Convert the byte array to a string using Unicode encoding
            string unicodeString = Encoding.Unicode.GetString(unicodeBytes);
            return unicodeString;
        }
        private static byte GetTenthByte(string displayEffect)
        {
            // Convert the displayEffect string to an integer
            int DEffect = Convert.ToInt32(displayEffect);

            // Convert the integer to an 8-bit binary string
            string DEffectBinary = ConvertDecimalToBinary(DEffect);

            // Convert the 8-bit binary string to a byte
            byte resultByte = Convert.ToByte(DEffectBinary, 2);

            return resultByte;
        }
        private static byte GetTwelvethByte(int DelayTime)
        {
            // Convert the displayEffect string to an integer
            int DTime = Convert.ToInt32(DelayTime);

            // Convert the integer to an 8-bit binary string
            string DTimeBinary = ConvertDecimalToBinary(DTime);

            // Convert the 8-bit binary string to a byte
            byte resultByte = Convert.ToByte(DTimeBinary, 2);

            return resultByte;
        }

        private static string ConvertDecimalToBinary(int decimalValue)
        {
            string binaryValue = Convert.ToString(decimalValue, 2); // Convert decimal to binary
            string paddedBinaryValue = binaryValue.PadLeft(8, '0'); // Ensure the binary string is 8 bits
            return paddedBinaryValue;
        }

        private static byte GetNineByte(string videotype, string letterSpeed)
        {
            string originalBinary = "00000000";

            // Convert the videotype to an integer and set the first bit to '1'
            int VType = Convert.ToInt32(videotype);
            originalBinary = "00000000";

            // Convert letterSpeed to binary
            int speed = Convert.ToInt32(letterSpeed);
            string speedBinary = ByteFormation.convertDecimalToBinary(speed);

            // Append speedBinary to originalBinary starting at position 0
            int positionSpeed = 0;
            originalBinary = ByteFormation.AppendBinaryValueRightToLeft(originalBinary, speedBinary, positionSpeed);

            // Convert the final binary string to a byte
            byte resultByte = Convert.ToByte(originalBinary, 2);

            return resultByte;
        }
        private static byte GetEleventhByte(string lettergap, int fontsize)
        {
            string originalBinary = "00000000";

         
            // Convert letterSpeed to binary
            int Gap = Convert.ToInt32(lettergap);
            string GapBinary = ByteFormation.convertDecimalToBinary(Gap);

            // Append speedBinary to originalBinary starting at position 0
            int positionGap = 0;
            originalBinary = ByteFormation.AppendBinaryValueRightToLeft(originalBinary, GapBinary, positionGap);

            string fontsizeBinary = ByteFormation.convertDecimalToBinary(fontsize);

            // Append speedBinary to originalBinary starting at position 0
            int positionfontsizeBinary = 3;
            originalBinary = ByteFormation.AppendBinaryValueRightToLeft(originalBinary, fontsizeBinary, positionfontsizeBinary);


            // Convert the final binary string to a byte
            byte resultByte = Convert.ToByte(originalBinary, 2);

            return resultByte;
        }

    }
}

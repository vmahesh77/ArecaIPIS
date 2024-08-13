using ArecaIPIS.Classes;
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

namespace ArecaIPIS.Forms
{
    public partial class frmBoardDiagnosis : Form
    {
        public frmBoardDiagnosis()
        {
            InitializeComponent();
        }
        private Form currentForm = null;

        private frmIndex parentForm;
        public frmBoardDiagnosis(frmIndex parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;

        }

        private void ActivateButton(object sender)
        {
            // Change the background color of all buttons
            foreach (var button in new[] { btnCds, btnTADB, btnCgdb, btnivdovd })
            {
                button.BackColor = Color.Green;
            }

            // Change the background color of the clicked button
            var clickedButton = (Button)sender;
            clickedButton.BackColor = Color.DeepSkyBlue;
        }

        private void OpenFormInPanel(Form form)
        {
            // Close and dispose of the current form if it exists
            if (currentForm != null)
            {
                currentForm.Close();
                currentForm.Dispose();
            }

            // Set the new form as the current form
            currentForm = form;

            // Configure the new form
            form.TopLevel = false; // Make it a child form
            form.FormBorderStyle = FormBorderStyle.None; // Remove border
            form.Dock = DockStyle.Fill; // Dock to fill the panel

            // Add the form to the panel's controls and show it
            panBoardforms.Controls.Add(form);
            panBoardforms.Tag = form; // Optional: Keep a reference to the form in the panel's Tag property
            form.BringToFront(); // Bring the form to the front
            form.Show();
        }
        private void btnCds_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenFormInPanel(new frmBoardDiagnosisCds());
        }

        private void btnTADB_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenFormInPanel(new frmBoardDiagnosisTadb());
        }

        private void btnCgdb_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenFormInPanel(new frmBoardDiagnosisCgdb());
        }

        private void btnivdovd_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenFormInPanel(new frmBoardDiagnosisIvdOvd());
        }

        public static byte[] LinkCheckPacket(string boardIp,int packet)
        {
            string ipaddress = Server.ipAdress;
            string[] SystemIPArr = ipaddress.Split('.');          
            string[] BoardIPAdress = boardIp.Split('.');

            //int thirdOctet = GetOctetbyIp(ipaddress, 3);
            //int FourthOctet = GetOctetbyIp(ipaddress, 4);

            Byte[] sendbyte = new Byte[2];   //creating an array
            sendbyte[0] = 170;    //AA
            sendbyte[1] = 204;    //CC
            Array.Resize(ref sendbyte, sendbyte.Length + 3);
            sendbyte[2] = (byte)packet;  //startPacket
            sendbyte[3] = 0;   //length
            sendbyte[4] = 8;     //length
            Array.Resize(ref sendbyte, sendbyte.Length + 9);
            sendbyte[5] = Convert.ToByte(BoardIPAdress[2]);    //3rd octet of destination
            sendbyte[6] = Convert.ToByte(BoardIPAdress[3]);     //4th octet of destination
            sendbyte[7] = Convert.ToByte(SystemIPArr[2]);          //3rd octet of source
            sendbyte[8] = Convert.ToByte(SystemIPArr[3]);          //4th octet of  source
            sendbyte[9] = (byte)Server.SerialNumber;    //serialNumber
            sendbyte[10] = 128;   //packet Type

            sendbyte[13] = 4;  //end of data
            Byte[] finalPacket = new Byte[sendbyte.Length + 12];   //final packet
            Array.Copy(sendbyte, 0, finalPacket, 6, sendbyte.Length);
            Byte[] value = Server.CheckSum(finalPacket);
            finalPacket[17] = value[0];   //crc msb
            finalPacket[18] = value[1];    //crc lsb
           
            Server.SerialNumber++;
            if (Server.SerialNumber > 255)
            {
                Server.SerialNumber = 0;
            }

            return finalPacket;

        }
        public static byte[] SoftResetPacket(string boardIp, int packet)
        {
            string ipaddress = Server.ipAdress;
            string[] SystemIPArr = ipaddress.Split('.');
            string[] BoardIPAdress = boardIp.Split('.');

            //int thirdOctet = GetOctetbyIp(ipaddress, 3);
            //int FourthOctet = GetOctetbyIp(ipaddress, 4);

            Byte[] sendbyte = new Byte[2];   //creating an array
            sendbyte[0] = 170;    //AA
            sendbyte[1] = 204;    //CC
            Array.Resize(ref sendbyte, sendbyte.Length + 3);
            sendbyte[2] = (byte)packet;  //startPacket
            sendbyte[3] = 0;   //length
            sendbyte[4] = 8;     //length
            Array.Resize(ref sendbyte, sendbyte.Length + 9);
            sendbyte[5] = Convert.ToByte(BoardIPAdress[2]);    //3rd octet of destination
            sendbyte[6] = Convert.ToByte(BoardIPAdress[3]);     //4th octet of destination
            sendbyte[7] = Convert.ToByte(SystemIPArr[2]);          //3rd octet of source
            sendbyte[8] = Convert.ToByte(SystemIPArr[3]);          //4th octet of  source
            sendbyte[9] = (byte)Server.SerialNumber;    //serialNumber
            sendbyte[10] = (byte)Board.SoftReset;   //packet Type

            sendbyte[13] = 4;  //end of data
            Byte[] finalPacket = new Byte[sendbyte.Length + 12];   //final packet
            Array.Copy(sendbyte, 0, finalPacket, 6, sendbyte.Length);
            Byte[] value = Server.CheckSum(finalPacket);
            finalPacket[17] = value[0];   //crc msb
            finalPacket[18] = value[1];    //crc lsb

            Server.SerialNumber++;
            if (Server.SerialNumber > 255)
            {
                Server.SerialNumber = 0;
            }

            return finalPacket;

        }
        public static byte[] GetConfiguration(string boardIp, int packet)
        {
            string ipaddress = Server.ipAdress;
            string[] SystemIPArr = ipaddress.Split('.');
            string[] BoardIPAdress = boardIp.Split('.');

            //int thirdOctet = GetOctetbyIp(ipaddress, 3);
            //int FourthOctet = GetOctetbyIp(ipaddress, 4);

            Byte[] sendbyte = new Byte[2];   //creating an array
            sendbyte[0] = 170;    //AA
            sendbyte[1] = 204;    //CC
            Array.Resize(ref sendbyte, sendbyte.Length + 3);
            sendbyte[2] = (byte)packet;  //startPacket
            sendbyte[3] = 0;   //length
            sendbyte[4] = 8;     //length
            Array.Resize(ref sendbyte, sendbyte.Length + 9);
            sendbyte[5] = Convert.ToByte(BoardIPAdress[2]);    //3rd octet of destination
            sendbyte[6] = Convert.ToByte(BoardIPAdress[3]);     //4th octet of destination
            sendbyte[7] = Convert.ToByte(SystemIPArr[2]);          //3rd octet of source
            sendbyte[8] = Convert.ToByte(SystemIPArr[3]);          //4th octet of  source
            sendbyte[9] = (byte)Server.SerialNumber;    //serialNumber
            sendbyte[10] = (byte)Board.GetConfiguration;   //packet Type

            sendbyte[13] = 4;  //end of data
            Byte[] finalPacket = new Byte[sendbyte.Length + 12];   //final packet
            Array.Copy(sendbyte, 0, finalPacket, 6, sendbyte.Length);
            Byte[] value = Server.CheckSum(finalPacket);
            finalPacket[17] = value[0];   //crc msb
            finalPacket[18] = value[1];    //crc lsb

            Server.SerialNumber++;
            if (Server.SerialNumber > 255)
            {
                Server.SerialNumber = 0;
            }

            return finalPacket;

        }
        public static byte[] SetConfiguration(string boardIp, int packet)
        {
            string ipaddress = Server.ipAdress;
            string[] SystemIPArr = ipaddress.Split('.');
            string[] BoardIPAdress = boardIp.Split('.');

            //int thirdOctet = GetOctetbyIp(ipaddress, 3);
            //int FourthOctet = GetOctetbyIp(ipaddress, 4);

            Byte[] sendbyte = new Byte[2];   //creating an array
            sendbyte[0] = 170;    //AA
            sendbyte[1] = 204;    //CC
            Array.Resize(ref sendbyte, sendbyte.Length + 3);
            sendbyte[2] = (byte)packet;  //startPacket
            sendbyte[3] = 0;   //length
            sendbyte[4] = 12;     //length
            Array.Resize(ref sendbyte, sendbyte.Length + 13);
            sendbyte[5] = Convert.ToByte(BoardIPAdress[2]);    //3rd octet of destination
            sendbyte[6] = Convert.ToByte(BoardIPAdress[3]);     //4th octet of destination
            sendbyte[7] = Convert.ToByte(SystemIPArr[2]);          //3rd octet of source
            sendbyte[8] = Convert.ToByte(SystemIPArr[3]);          //4th octet of  source
            sendbyte[9] = (byte)Server.SerialNumber;    //serialNumber
            sendbyte[10] = (byte)Board.SetConfiguration;   //packet Type
            sendbyte[11] = 02;    //sod
            sendbyte[12] = 4;   //intensity
            sendbyte[13] = 28;    //datatimeout
            sendbyte[14] = 3;    //Eod
            sendbyte[17] = 4;  //end of data
            Byte[] finalPacket = new Byte[sendbyte.Length + 12];   //final packet
            Array.Copy(sendbyte, 0, finalPacket, 6, sendbyte.Length);
            Byte[] value = Server.CheckSum(finalPacket);
            finalPacket[21] = value[0];   //crc ms
            finalPacket[22] = value[1];    //crc lsb

            Server.SerialNumber++;
            if (Server.SerialNumber > 255)
            {
                Server.SerialNumber = 0;
            }

            return finalPacket;

        }
        public static byte[] DeleteData(string boardIp, int packet)
        {
            string ipaddress = Server.ipAdress;
            string[] SystemIPArr = ipaddress.Split('.');
            string[] BoardIPAdress = boardIp.Split('.');

            //int thirdOctet = GetOctetbyIp(ipaddress, 3);
            //int FourthOctet = GetOctetbyIp(ipaddress, 4);

            Byte[] sendbyte = new Byte[2];   //creating an array
            sendbyte[0] = 170;    //AA
            sendbyte[1] = 204;    //CC
            Array.Resize(ref sendbyte, sendbyte.Length + 3);
            sendbyte[2] = (byte)packet;  //startPacket
            sendbyte[3] = 0;   //length
            sendbyte[4] = 8;     //length
            Array.Resize(ref sendbyte, sendbyte.Length + 9);
            sendbyte[5] = Convert.ToByte(BoardIPAdress[2]);    //3rd octet of destination
            sendbyte[6] = Convert.ToByte(BoardIPAdress[3]);     //4th octet of destination
            sendbyte[7] = Convert.ToByte(SystemIPArr[2]);          //3rd octet of source
            sendbyte[8] = Convert.ToByte(SystemIPArr[3]);          //4th octet of  source
            sendbyte[9] = (byte)Server.SerialNumber;    //serialNumber
            sendbyte[10] = (byte)Board.DeleteData;   //packet Type

            sendbyte[13] = 4;  //end of data
            Byte[] finalPacket = new Byte[sendbyte.Length + 12];   //final packet
            Array.Copy(sendbyte, 0, finalPacket, 6, sendbyte.Length);
            Byte[] value = Server.CheckSum(finalPacket);
            finalPacket[17] = value[0];   //crc msb
            finalPacket[18] = value[1];    //crc lsb

            Server.SerialNumber++;
            if (Server.SerialNumber > 255)
            {
                Server.SerialNumber = 0;
            }

            return finalPacket;

        }
        public static int GetOctetbyIp(string ipaddress, int value)
        {
            // Validate that the input is a proper IP address
            if (IPAddress.TryParse(ipaddress, out IPAddress parsedIpAddress))
            {
                // Split the IP address into its octets
                string[] octets = ipaddress.Split('.');

                // Ensure there are exactly 4 octets
                if (octets.Length == 4)
                {
                    // Try to parse the third octet
                    if (int.TryParse(octets[value - 1], out int Octetno))
                    {
                        return Octetno;
                    }
                }
            }
            // Return -1 if the IP address is not valid or other parsing issues occurred
            return -1;
        }

       
        public static string GetIntensity(byte intensityByte)
        {
            // Implement logic to convert intensity byte to a meaningful string
            switch (intensityByte)
            {
                case 0:
                    return "25%";
                case 1:
                    return "50%";
                case 2:
                    return "75%";
                default:
                    return "100%";
            }
        }

        public static string GetDataTimeout(byte timeoutByte)
        {
            // Implement logic to convert timeout byte to a meaningful string
            return $"{timeoutByte} Minutes";
        }
    }
}

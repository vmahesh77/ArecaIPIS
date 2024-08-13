using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    public partial class frmBoardDiagnosisTadb : Form
    {
        public frmBoardDiagnosisTadb()
        {
            InitializeComponent();
            dgvCommunication.CellPainting += dgvCommunication_CellPainting;
        }
        private frmHome parentForm;

        public frmBoardDiagnosisTadb(frmHome parentForm) : this()
        {
            this.parentForm = parentForm;
        }

        private void frmBoardDiagnosisTadb_Load(object sender, EventArgs e)
        {
            try
            {
                List<int> packetIdentifiers = new List<int> { 3,4,5};

                // Fetch data from the database
                DataTable boards = BoardDiagnosisDb.GetDiagnosisBoards(packetIdentifiers);

                // Clear existing rows in the DataGridView
                dgvCommunication.Rows.Clear();

                // Import the data from the original DataTable to the new DataTable
                foreach (DataRow row in boards.Rows)
                {
                    DataGridViewRow dgvRow = new DataGridViewRow();
                    dgvRow.CreateCells(dgvCommunication);

                    dgvRow.Cells[dgvCommunication.Columns["dgvBoardIP"].Index].Value = row["IPAddress"];
                    dgvRow.Cells[dgvCommunication.Columns["dgvBoardLocation"].Index].Value = row["Location"];
                    dgvRow.Cells[dgvCommunication.Columns["dgvPortNo"].Index].Value = row["EthernetPort"];
                  //  dgvRow.Cells[dgvCommunication.Columns["dgvPlatformNo"].Index].Value = row["Platform"];
                    dgvRow.Cells[dgvCommunication.Columns["dgvTemperature"].Index].Value = row["Temperature"];
                 
                   //dgvRow.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Value = row["LinkStatus"];
                   // if (row["LinkStatus"].ToString().Trim() == "True")
                   // {
                   //     dgvRow.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Value = "Active";
                   //     dgvRow.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Style.BackColor = Color.Green;
                   // }
                   // else
                   // {
                   //     dgvRow.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Value = "InActive";
                   //     dgvRow.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Style.BackColor = Color.Orange;
                   // }
                    string ipadress = row["IPAddress"].ToString();

                    if (Server._connectedClients.TryGetValue(ipadress, out TcpClient client))
                    {
                        dgvRow.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Value = "Active";
                        dgvRow.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        dgvRow.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Value = "InActive";
                        dgvRow.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Style.BackColor = Color.Orange;
                    }

                            dgvCommunication.Rows.Add(dgvRow);
                }

               // dgvCommunication.ClearSelection();
                dgvCommunication.CurrentCell = null;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"Null reference error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}");
            }
        }

      

        private void dgvCommunication_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dgvCommunication.Columns["dgvConfiguration"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                // Retrieve the value of the cell
                string status = dgvCommunication.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                // Determine the background color based on the cell value
                Color buttonColor = status == "Active" ? Color.Green : Color.Orange;

                // Calculate the smaller button bounds
                int buttonWidth = e.CellBounds.Width / 2;
                int buttonHeight = e.CellBounds.Height - 6;
                int buttonX = e.CellBounds.X + (e.CellBounds.Width - buttonWidth) / 2;
                int buttonY = e.CellBounds.Y + 2;

                Rectangle buttonBounds = new Rectangle(buttonX, buttonY, buttonWidth, buttonHeight);

                // Draw the button background
                using (Brush brush = new SolidBrush(buttonColor))
                {
                    e.Graphics.FillRectangle(brush, buttonBounds);
                }

                // Draw the button text
                TextRenderer.DrawText(e.Graphics, status, e.CellStyle.Font, buttonBounds, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                // Draw the button border
                e.Graphics.DrawRectangle(Pens.Gray, buttonBounds);

                // Prevent the default painting
                e.Handled = true;
            }
        }

        private void dgvCommunication_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvCommunication_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

           
        }
        // Method to clear the byte array
        private void btnLinkCheck_Click(object sender, EventArgs e)
        {
            try
            {
                (bool hasBoard, string BoardIp, int packet) = GetBoardIpAndPacket();

                if (hasBoard)
                {
                    // Create and send the LinkCheckPacket
                    byte[] LinkCheckPacket = frmBoardDiagnosis.LinkCheckPacket(BoardIp, packet);
                    Server.SendMessageToClient(BoardIp, LinkCheckPacket);

                    System.Threading.Thread.Sleep(3000);
                    // Get the received bytes from the server
                    byte[] serverReceivedBytes = Server.GetReceivedBytes; // Temporarily store the received bytes
                 
                    // Check if received bytes are empty
                    if (serverReceivedBytes.Length <= 19 )
                    {
                        MessageBox.Show("Link check failed", "Link Check Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DeActivateLinkCheck(BoardIp);
                    }
                    else
                    {
                        byte[] trimmedserverReceivedBytes = RemoveFirstAndLast6(serverReceivedBytes);
                        byte[] trimmedLinkCheckPacket = RemoveFirstAndLast6(LinkCheckPacket);

                        bool linkSucess = validateLinkCheck(trimmedserverReceivedBytes, trimmedLinkCheckPacket);

                        
                        if (!linkSucess)
                        {
                            MessageBox.Show("Link check failed", "Link Check Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            DeActivateLinkCheck(BoardIp);
                        }
                        else
                        {
                            // Initialize receivedBytes with the same length as serverReceivedBytes
                            byte[] receivedBytes = new byte[trimmedserverReceivedBytes.Length];

                            // Copy data from serverReceivedBytes to receivedBytes
                            Array.Copy(trimmedserverReceivedBytes, receivedBytes, trimmedserverReceivedBytes.Length);

                            // Convert received bytes to a string for displaying in a message box
                            string receivedData = Encoding.ASCII.GetString(receivedBytes);

                            // Convert received bytes to a hexadecimal string for displaying
                            string receivedHex = BitConverter.ToString(receivedBytes).Replace("-", " ");
                            string intensity = frmBoardDiagnosis.GetIntensity(receivedBytes[12]);
                            string dataTimeout = frmBoardDiagnosis.GetDataTimeout(receivedBytes[13]);
                            // Show the received data in a message box
                            
                            MessageBox.Show("" + receivedHex+"\nIntensity:  "+intensity+"\nData Timeout: "+ dataTimeout, "lINK CHECK SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);



                            ActivateLinkCheck(BoardIp);





                            // MessageBox.Show(""+ receivedHex);
                            // MessageBox.Show($"Received data from {BoardIp}:\nASCII: {receivedData}\nHex: {receivedHex}", "Received Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }

                    // Clear the static byte array after processing
                    ClearReceivedBytes();
                }
                else
                {
                    MessageBox.Show(BoardIp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void ActivateLinkCheck(string targetIpAddress)
        {
            foreach (DataGridViewRow row in dgvCommunication.Rows)
            {
                // Ensure the row is not a new row
                if (!row.IsNewRow)
                {
                    string ipAddress = row.Cells[dgvCommunication.Columns["dgvBoardIP"].Index].Value?.ToString();

                    if (ipAddress == targetIpAddress)
                    {
                        // Update the cell value in the "dgvConfiguration" column
                        row.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Value = "Active";

                        // Change the cell's background color to green
                        row.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Style.BackColor = Color.Green;
                    }
                }
            }
        }
        private void DeActivateLinkCheck(string targetIpAddress)
        {
            foreach (DataGridViewRow row in dgvCommunication.Rows)
            {
                // Ensure the row is not a new row
                if (!row.IsNewRow)
                {
                    string ipAddress = row.Cells[dgvCommunication.Columns["dgvBoardIP"].Index].Value?.ToString();

                    if (ipAddress == targetIpAddress)
                    {
                        // Update the cell value in the "dgvConfiguration" column
                        row.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Value = "InActive";

                        // Change the cell's background color to green
                        row.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Style.BackColor = Color.Orange;
                    }
                }
            }
        }
        public bool  validateLinkCheck(byte[] serverReceivedBytes, byte[] LinkCheckPacket)
        {
            if(
                serverReceivedBytes[0]== 170 &&
                serverReceivedBytes[1] == 204 &&
                 //serverReceivedBytes[2] == 170 &&
                serverReceivedBytes[3] == 0 &&
                //serverReceivedBytes[4]==8 && 
                serverReceivedBytes[5] == LinkCheckPacket[7] && 
                serverReceivedBytes[6] == LinkCheckPacket[8] &&
                serverReceivedBytes[7] == LinkCheckPacket[5] &&
                serverReceivedBytes[8] == LinkCheckPacket[6] &&
                  serverReceivedBytes[9] == LinkCheckPacket[9] &&
                 serverReceivedBytes[10] == 192 &&
                serverReceivedBytes[11] == 2 &&
                  serverReceivedBytes[serverReceivedBytes.Length-2] == 4  )
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool validateGetConfiguration(byte[] serverReceivedBytes, byte[] LinkCheckPacket)
        {
            if (
                serverReceivedBytes[0] == 170 &&
                serverReceivedBytes[1] == 204 &&
                //serverReceivedBytes[2] == 170 &&
                serverReceivedBytes[3] == 0 &&
                //serverReceivedBytes[4]==8 && 
                serverReceivedBytes[5] == LinkCheckPacket[7] &&
                serverReceivedBytes[6] == LinkCheckPacket[8] &&
                serverReceivedBytes[7] == LinkCheckPacket[5] &&
                serverReceivedBytes[8] == LinkCheckPacket[6] &&
                  serverReceivedBytes[9] == LinkCheckPacket[9] &&
                 serverReceivedBytes[10] == 197 &&
                serverReceivedBytes[11] == 2 &&
                  serverReceivedBytes[serverReceivedBytes.Length - 2] == 4)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool validateDeleteData(byte[] serverReceivedBytes, byte[] LinkCheckPacket)
        {
            if (
                serverReceivedBytes[0] == 170 &&
                serverReceivedBytes[1] == 204 &&
                //serverReceivedBytes[2] == 170 &&
                serverReceivedBytes[3] == 0 &&
                //serverReceivedBytes[4]==8 && 
                serverReceivedBytes[5] == LinkCheckPacket[7] &&
                serverReceivedBytes[6] == LinkCheckPacket[8] &&
                serverReceivedBytes[7] == LinkCheckPacket[5] &&
                serverReceivedBytes[8] == LinkCheckPacket[6] &&
                  serverReceivedBytes[9] == LinkCheckPacket[9] &&
                 serverReceivedBytes[10] == 201 &&
                
                  serverReceivedBytes[serverReceivedBytes.Length - 2] == 4)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool validateSetConfiguration(byte[] serverReceivedBytes, byte[] LinkCheckPacket)
        {
            if (
                serverReceivedBytes[0] == 170 &&
                serverReceivedBytes[1] == 204 &&
                //serverReceivedBytes[2] == 170 &&
                serverReceivedBytes[3] == 0 &&
                //serverReceivedBytes[4]==8 && 
                serverReceivedBytes[5] == LinkCheckPacket[7] &&
                serverReceivedBytes[6] == LinkCheckPacket[8] &&
                serverReceivedBytes[7] == LinkCheckPacket[5] &&
                serverReceivedBytes[8] == LinkCheckPacket[6] &&
                  serverReceivedBytes[9] == LinkCheckPacket[9] &&
                 serverReceivedBytes[10] == 196 &&
                //serverReceivedBytes[11] == 2 &&
                  serverReceivedBytes[serverReceivedBytes.Length - 2] == 4)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static byte[] RemoveFirstAndLast6(byte[] inputArray)
        {
            // Ensure the array has at least 13 elements
            if (inputArray == null || inputArray.Length <= 12)
            {
                throw new ArgumentException("Array must have more than 12 elements.");
            }

            // Calculate the length of the new array
            int newLength = inputArray.Length - 12;

            // Create the new array
            byte[] resultArray = new byte[newLength];

            // Copy the middle portion of the original array to the new array
            Array.Copy(inputArray, 6, resultArray, 0, newLength);

            return resultArray;
        }
        // Method to clear the byte array
        public static void ClearReceivedBytes()
        {
           Server. GetReceivedBytes = new byte[0];
        }




        private (bool, string, int) GetBoardIpAndPacket()
        {
            foreach (DataGridViewRow row in dgvCommunication.Rows)
            {
                if (row.Cells["dgvcheckBox"] is DataGridViewCheckBoxCell checkBoxCell && checkBoxCell.Value != null)
                {
                    bool isChecked = (bool)checkBoxCell.Value;
                    if (isChecked)
                    {
                        var cell = row.Cells["dgvBoardIP"];
                        if (cell != null && cell.Value != null)
                        {
                            var boardIp = cell.Value.ToString().Trim();
                            int packet = GetPacketIdentifier(boardIp);
                            return (true, boardIp, packet);
                        }
                    }
                }
            }
            return (false, "No board selected.", -1);
        }


        public int GetPacketIdentifier(string BoardIp)
        {
            foreach (DataRow row in BaseClass.EthernetPorts.Rows)
            {
                if (BaseClass.EthernetPorts.Columns.Contains("IPAddress"))
                {
                    // Compare the IP address as a string
                    if (row["IPAddress"].ToString() == BoardIp)
                    {
                        // Try to get the PacketIdentifier as an integer
                        if (int.TryParse(row["PacketIdentifier"].ToString(), out int packet))
                        {
                            return packet;
                        }
                    }
                }
            }

            // Return a default value or throw an exception if the BoardIp is not found
            throw new Exception("PacketIdentifier not found for the provided BoardIp.");
        }

        private void dgvCommunication_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the checkbox column and not the header
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && dgvCommunication.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                DataGridViewCheckBoxCell clickedCell = dgvCommunication.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;

                // Uncheck all other checkboxes in the same column
                foreach (DataGridViewRow row in dgvCommunication.Rows)
                {
                    if (row.Index != e.RowIndex) // Skip the clicked row
                    {
                        DataGridViewCheckBoxCell cell = row.Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;
                        cell.Value = false;
                    }
                }

                // Ensure the clicked checkbox is checked
                clickedCell.Value = true;
            }
        }

        private void btnSoftReset_Click(object sender, EventArgs e)
        {
            try
            {
                (bool hasBoard, string BoardIp, int packet) = GetBoardIpAndPacket();

                if (hasBoard)
                {
                    byte[] SoftResetPacket = frmBoardDiagnosis.SoftResetPacket(BoardIp, packet);
                    Server.SendMessageToClient(BoardIp, SoftResetPacket);
                    System.Threading.Thread.Sleep(3000);
                    // Get the received bytes from the server
                    byte[] serverReceivedBytes = Server.GetReceivedBytes; // Temporarily store the received bytes

                    // Check if received bytes are empty
                   
                        


                          
                            // Show the received data in a message box
                            MessageBox.Show("" + "Command Excuted Sucessfully", "SOFT RESET", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // MessageBox.Show(""+ receivedHex);
                            // MessageBox.Show($"Received data from {BoardIp}:\nASCII: {receivedData}\nHex: {receivedHex}", "Received Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        

                    

                    // Clear the static byte array after processing
                    ClearReceivedBytes();
                }
                else
                {
                    MessageBox.Show(BoardIp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void btnGetConfiguration_Click(object sender, EventArgs e)
        {
            try
            {
                (bool hasBoard, string BoardIp, int packet) = GetBoardIpAndPacket();

                if (hasBoard)
                {
                    byte[] LinkCheckPacket = frmBoardDiagnosis.GetConfiguration(BoardIp, packet);
                    Server.SendMessageToClient(BoardIp, LinkCheckPacket);
                    System.Threading.Thread.Sleep(3000);
                    // Get the received bytes from the server
                    byte[] serverReceivedBytes = Server.GetReceivedBytes; // Temporarily store the received bytes

                    // Check if received bytes are empty
                    if (serverReceivedBytes.Length <= 19)
                    {
                        MessageBox.Show("Get configuration failed", "Get Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        byte[] trimmedserverReceivedBytes = RemoveFirstAndLast6(serverReceivedBytes);
                        byte[] trimmedLinkCheckPacket = RemoveFirstAndLast6(LinkCheckPacket);

                        bool linkSucess = validateGetConfiguration(trimmedserverReceivedBytes, trimmedLinkCheckPacket);


                        if (!linkSucess)
                        {
                            MessageBox.Show("Get configuration failed", "Get Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // Initialize receivedBytes with the same length as serverReceivedBytes
                            byte[] receivedBytes = new byte[trimmedserverReceivedBytes.Length];

                            // Copy data from serverReceivedBytes to receivedBytes
                            Array.Copy(trimmedserverReceivedBytes, receivedBytes, trimmedserverReceivedBytes.Length);

                            // Convert received bytes to a string for displaying in a message box
                            string receivedData = Encoding.ASCII.GetString(receivedBytes);

                            // Convert received bytes to a hexadecimal string for displaying
                            string receivedHex = BitConverter.ToString(receivedBytes).Replace("-", " ");
                            string intensity = frmBoardDiagnosis.GetIntensity(receivedBytes[12]);
                            string dataTimeout = frmBoardDiagnosis.GetDataTimeout(receivedBytes[13]);
                            // Show the received data in a message box
                            MessageBox.Show("" + receivedHex + "\nIntensity:  " + intensity + "\nData Timeout: " + dataTimeout, "Get Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // MessageBox.Show(""+ receivedHex);
                            // MessageBox.Show($"Received data from {BoardIp}:\nASCII: {receivedData}\nHex: {receivedHex}", "Received Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }

                    // Clear the static byte array after processing
                    ClearReceivedBytes();
                }
                else
                {
                    MessageBox.Show(BoardIp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void btnSetConfiguration_Click(object sender, EventArgs e)
        {

            try
            {
                (bool hasBoard, string BoardIp, int packet) = GetBoardIpAndPacket();

                if (hasBoard)
                {
                    byte[] SetConfiguration = frmBoardDiagnosis.SetConfiguration(BoardIp, packet);
                    Server.SendMessageToClient(BoardIp, SetConfiguration);
                    System.Threading.Thread.Sleep(3000);
                    // Get the received bytes from the server
                    byte[] serverReceivedBytes = Server.GetReceivedBytes; // Temporarily store the received bytes

                    // Check if received bytes are empty
                    if (serverReceivedBytes.Length <= 19)
                    {
                        MessageBox.Show("SET CONFIGURATION failed", "SET CONFIGURATION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        byte[] trimmedserverReceivedBytes = RemoveFirstAndLast6(serverReceivedBytes);
                        byte[] trimmedLinkCheckPacket = RemoveFirstAndLast6(SetConfiguration);

                        bool linkSucess = validateSetConfiguration(trimmedserverReceivedBytes, trimmedLinkCheckPacket);


                        if (!linkSucess)
                        {
                            MessageBox.Show("SET CONFIGURATION failed", "SET CONFIGURATION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // Initialize receivedBytes with the same length as serverReceivedBytes
                            byte[] receivedBytes = new byte[trimmedserverReceivedBytes.Length];

                            // Copy data from serverReceivedBytes to receivedBytes
                            Array.Copy(trimmedserverReceivedBytes, receivedBytes, trimmedserverReceivedBytes.Length);

                            // Convert received bytes to a string for displaying in a message box
                            string receivedData = Encoding.ASCII.GetString(receivedBytes);

                            // Convert received bytes to a hexadecimal string for displaying
                            string receivedHex = BitConverter.ToString(receivedBytes).Replace("-", " ");
                            
                            // Show the received data in a message box
                            MessageBox.Show(""+"Response  :" + receivedHex + "\nCommand: Set Configuration Excuted Sucessfully", "SET CONFIGURATION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // MessageBox.Show(""+ receivedHex);
                            // MessageBox.Show($"Received data from {BoardIp}:\nASCII: {receivedData}\nHex: {receivedHex}", "Received Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }

                    // Clear the static byte array after processing
                    ClearReceivedBytes();
                }
                else
                {
                    MessageBox.Show(BoardIp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void btnDeleteData_Click(object sender, EventArgs e)
        {
            try
            {
                (bool hasBoard, string BoardIp, int packet) = GetBoardIpAndPacket();

                if (hasBoard)
                {
                    byte[] LinkCheckPacket = frmBoardDiagnosis.DeleteData(BoardIp, packet);
                    Server.SendMessageToClient(BoardIp, LinkCheckPacket);
                    System.Threading.Thread.Sleep(3000);
                    // Get the received bytes from the server
                    byte[] serverReceivedBytes = Server.GetReceivedBytes; // Temporarily store the received bytes

                    // Check if received bytes are empty
                    if (serverReceivedBytes.Length <= 19)
                    {
                        MessageBox.Show("Delete Data failed", "Delete Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        byte[] trimmedserverReceivedBytes = RemoveFirstAndLast6(serverReceivedBytes);
                        byte[] trimmedLinkCheckPacket = RemoveFirstAndLast6(LinkCheckPacket);

                        bool linkSucess = validateDeleteData(trimmedserverReceivedBytes, trimmedLinkCheckPacket);


                        if (!linkSucess)
                        {
                            MessageBox.Show("Delete Data failed", "Delete Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // Initialize receivedBytes with the same length as serverReceivedBytes
                            byte[] receivedBytes = new byte[trimmedserverReceivedBytes.Length];

                            // Copy data from serverReceivedBytes to receivedBytes
                            Array.Copy(trimmedserverReceivedBytes, receivedBytes, trimmedserverReceivedBytes.Length);

                            // Convert received bytes to a string for displaying in a message box
                            string receivedData = Encoding.ASCII.GetString(receivedBytes);

                            // Convert received bytes to a hexadecimal string for displaying
                            string receivedHex = BitConverter.ToString(receivedBytes).Replace("-", " ");
                            
                            // Show the received data in a message box
                            MessageBox.Show("" + "Response :"+receivedHex +"\nCommand :Delete Data Excuted Sucessfully ", "Delete Data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // MessageBox.Show(""+ receivedHex);
                            // MessageBox.Show($"Received data from {BoardIp}:\nASCII: {receivedData}\nHex: {receivedHex}", "Received Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }

                    // Clear the static byte array after processing
                    ClearReceivedBytes();
                }
                else
                {
                    MessageBox.Show(BoardIp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using ArecaIPIS.Server_Classes;

namespace ArecaIPIS.Forms.HomeForms
{
    public partial class frmOnlineTrains : Form
    {
        private List<Dictionary<string, object>> selectedRowsData;



        public frmOnlineTrains()
        {
            selectedRowsData = new List<Dictionary<string, object>>();
            //  dgvOnlineTrains.CellContentClick += storeTaddbData;
            InitializeComponent();
        }
        private frmIndex parentForm;
        public frmOnlineTrains(frmIndex parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;

        }

        private void frmOnlineTrains_Load(object sender, EventArgs e)
        {
            DataTable ArrivalAndDepartureStatuses = OnlineTrainsDao.GetArrivalAndDepartureStatus();

            BaseClass.arrivalStatus.Clear();
            BaseClass.DepatureStatus.Clear();
            for (int i = 0; i < ArrivalAndDepartureStatuses.Rows.Count; i++)
            {

                BaseClass.arrivalStatus.Add(ArrivalAndDepartureStatuses.Rows[i][0].ToString());

                BaseClass.DepatureStatus.Add(ArrivalAndDepartureStatuses.Rows[i][1].ToString());
            }


            fillRunningTrains();



        }

        public void refreshOnlineTrains()
        {
            fillRunningTrains();
        }

        public void resetArrivalStatus(DataGridViewCell cell)
        {
            try
            {
                DataTable onlineTrainsDt = OnlineTrainsDao.GetTopScheduledTaddbRecords();

                DataGridViewComboBoxCell comboBoxCell = dgvOnlineTrains.Rows[cell.RowIndex].Cells["dgvTrainStatusColumn"] as DataGridViewComboBoxCell;
                comboBoxCell.Items.Clear();

                foreach (string status in BaseClass.arrivalStatus)
                {
                    comboBoxCell.Items.Add(status);
                }

                comboBoxCell.Value = "Will Arrive Shortly";

            }
            catch (Exception e)
            {
                e.ToString();
            }

        }


        public void resetDepatureStatus(DataGridViewCell cell)
        {
            try
            {
                DataTable onlineTrainsDt = OnlineTrainsDao.GetTopScheduledTaddbRecords();
                DataGridViewComboBoxCell comboBoxCell = dgvOnlineTrains.Rows[cell.RowIndex].Cells["dgvTrainStatusColumn"] as DataGridViewComboBoxCell;
                comboBoxCell.Items.Clear();

                foreach (string status in BaseClass.DepatureStatus)
                {
                    comboBoxCell.Items.Add(status);
                }
                comboBoxCell.Value = "Running Right Time";
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }



        public void fillRunningTrains()
        {
            DataTable onlineTrainsDt = OnlineTrainsDao.GetTopScheduledTaddbRecords();

            dgvOnlineTrains.Rows.Clear();



            foreach (DataRow row in onlineTrainsDt.Rows)
            {

                int rowIndex = dgvOnlineTrains.Rows.Add();

                dgvOnlineTrains.Rows[rowIndex].Cells["dgvSnoColumn"].Value = "" + (rowIndex + 1);
                dgvOnlineTrains.Rows[rowIndex].Cells["dgvTrNoColumn"].Value = row["TrainNo"].ToString();
                dgvOnlineTrains.Rows[rowIndex].Cells["dgvTrainNameColumn"].Value = row["Name"].ToString();
                dgvOnlineTrains.Rows[rowIndex].Cells["dgvHindiTrainNameColumn"].Value = row["LNational_Lang"].ToString();
                dgvOnlineTrains.Rows[rowIndex].Cells["dgvRegionalLangColumn"].Value = row["LRegional1_Lang"].ToString();

                dgvOnlineTrains.Rows[rowIndex].Cells["dgvStaColumn"].Value = row["RArrivalTime"].ToString();
                dgvOnlineTrains.Rows[rowIndex].Cells["dgvSTDColumn"].Value = row["RDepartureTime"].ToString();
                string ad= row["ArrivingStatus"].ToString();
                dgvOnlineTrains.Rows[rowIndex].Cells["dgvAdColumn"].Value = row["ArrivingStatus"].ToString();

                dgvOnlineTrains.Rows[rowIndex].Cells["dgvLateColumn"].Value = row["LateBy"].ToString();
                dgvOnlineTrains.Rows[rowIndex].Cells["dgvEtaColumn"].Value = row["LArrivalTime"].ToString();
                dgvOnlineTrains.Rows[rowIndex].Cells["dgvETDColumn"].Value = row["LDepartureTime"].ToString();

                DataGridViewComboBoxCell comboBoxPF = dgvOnlineTrains.Rows[rowIndex].Cells["dgvPFColumn"] as DataGridViewComboBoxCell;
                comboBoxPF.Items.Clear();
                foreach (string pf in BaseClass.Platforms)
                {
                    comboBoxPF.Items.Add(pf);
                }





                DataGridViewComboBoxCell comboBoxCell = dgvOnlineTrains.Rows[rowIndex].Cells["dgvTrainStatusColumn"] as DataGridViewComboBoxCell;
                comboBoxCell.Items.Clear();
                if (ad == "A")
                {
                    foreach (string status in BaseClass.arrivalStatus)
                    {
                        comboBoxCell.Items.Add(status);
                    }

                    comboBoxCell.Value = row["StatusName"].ToString();
                }
                else
                {
                    foreach (string status in BaseClass.DepatureStatus)
                    {
                        comboBoxCell.Items.Add(status);
                    }

                    comboBoxCell.Value = row["StatusName"].ToString();
                }

            }

            dgvOnlineTrains.Rows.Add();



        }
        //   static List<DataGridViewRow> selectedRows = new List<DataGridViewRow>();
        //private void storeTaddbData(object sender, DataGridViewCellEventArgs e)
        //{ // Check if the clicked cell is in the dgvTdbColumn
        //    if (e.ColumnIndex == dgvOnlineTrains.Columns["dgvTdbColumn"].Index && e.RowIndex >= 0)
        //    {
        //        // Check if the clicked cell's value is a checkbox
        //        if (dgvOnlineTrains.Rows.Count > e.RowIndex &&
        //            dgvOnlineTrains.Rows[e.RowIndex].Cells.Count > e.ColumnIndex &&
        //            dgvOnlineTrains.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewCheckBoxCell)
        //        {
        //            // Get the value of the checkbox
        //            bool isChecked = false;
        //            if(dgvOnlineTrains.Rows[e.RowIndex].Cells[e.ColumnIndex].Value!=null)
        //            {
        //                isChecked = (bool)dgvOnlineTrains.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        //            }

        //            DataGridViewRow row = dgvOnlineTrains.Rows[e.RowIndex];

        //            string trainName = row.Cells["dgvTrainNameColumn"].Value.ToString();
        //            // Continue retrieving data from other columns as needed...

        //            // Now you have access to the row's data, do whatever you need with it
        //            // Example: Print the train name if the checkbox is checked
        //            if (isChecked)
        //            {
        //                Console.WriteLine("Train Name: " + trainName);
        //            }
        //        }
        //    }
        //}

        private void dgvOnlineTrains_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex >= 0 && dgvOnlineTrains.Columns[e.ColumnIndex].Name == "dgvTrNoColumn") && e.RowIndex <= dgvOnlineTrains.Rows.Count - 2)
            {

                DataGridViewRow row = dgvOnlineTrains.Rows[e.RowIndex];
                string trainNumber = row.Cells["dgvTrNoColumn"].Value.ToString();
                DataTable coachPositionsdt = OnlineTrainsDao.getCoachPositionsByTrainNumber(trainNumber);


                foreach (DataRow coachRow in coachPositionsdt.Rows)
                {
                    string coachpositions = coachRow["coachPositions"].ToString();
                    string[] coachValues = coachpositions.Split(',');


                    txtCoach1.Text = coachValues.Length > 0 ? coachValues[0] : string.Empty;
                    txtCoach2.Text = coachValues.Length > 1 ? coachValues[1] : string.Empty;
                    txtCoach3.Text = coachValues.Length > 2 ? coachValues[2] : string.Empty;
                    txtCoach4.Text = coachValues.Length > 3 ? coachValues[3] : string.Empty;
                    txtCoach5.Text = coachValues.Length > 4 ? coachValues[4] : string.Empty;
                    txtCoach6.Text = coachValues.Length > 5 ? coachValues[5] : string.Empty;
                    txtCoach7.Text = coachValues.Length > 6 ? coachValues[6] : string.Empty;
                    txtCoach8.Text = coachValues.Length > 7 ? coachValues[7] : string.Empty;
                    txtCoach9.Text = coachValues.Length > 8 ? coachValues[8] : string.Empty;
                    txtCoach10.Text = coachValues.Length > 9 ? coachValues[9] : string.Empty;
                    txtCoach11.Text = coachValues.Length > 10 ? coachValues[10] : string.Empty;
                    txtCoach12.Text = coachValues.Length > 11 ? coachValues[11] : string.Empty;
                    txtCoach13.Text = coachValues.Length > 12 ? coachValues[12] : string.Empty;
                    txtCoach14.Text = coachValues.Length > 13 ? coachValues[13] : string.Empty;
                    txtCoach15.Text = coachValues.Length > 14 ? coachValues[14] : string.Empty;
                    txtCoach16.Text = coachValues.Length > 15 ? coachValues[15] : string.Empty;
                    txtCoach17.Text = coachValues.Length > 16 ? coachValues[16] : string.Empty;
                    txtCoach18.Text = coachValues.Length > 17 ? coachValues[17] : string.Empty;
                    txtCoach19.Text = coachValues.Length > 18 ? coachValues[18] : string.Empty;
                    txtCoach20.Text = coachValues.Length > 19 ? coachValues[19] : string.Empty;
                    txtCoach21.Text = coachValues.Length > 20 ? coachValues[20] : string.Empty;
                    txtCoach22.Text = coachValues.Length > 21 ? coachValues[21] : string.Empty;
                    txtCoach23.Text = coachValues.Length > 22 ? coachValues[22] : string.Empty;
                    txtCoach24.Text = coachValues.Length > 23 ? coachValues[23] : string.Empty;
                    txtCoach25.Text = coachValues.Length > 24 ? coachValues[24] : string.Empty;
                    txtCoach26.Text = coachValues.Length > 25 ? coachValues[25] : string.Empty;
                    txtCoach27.Text = coachValues.Length > 26 ? coachValues[26] : string.Empty;
                    txtCoach28.Text = coachValues.Length > 27 ? coachValues[27] : string.Empty;

                }

            }
            // Check if the clicked cell is in the last row
            if (e.RowIndex == dgvOnlineTrains.Rows.Count - 1)
            {
                BaseClass.selectTrainsDatabase = "ScheduledTrains";
                //frmScheduledTrains frmSch = new frmScheduledTrains();
                //frmSch.Show();
                frmScheduledTrains frmscheduled;

                Form mainForm = Application.OpenForms["frmScheduledTrains"];

                if (mainForm != null)
                {
                    frmscheduled = (frmScheduledTrains)mainForm;
                    frmscheduled.Show();
                }
                else
                {
                    frmscheduled = new frmScheduledTrains();
                    frmscheduled.Show();
                }
                frmscheduled.BringToFront();


            }
            if (dgvOnlineTrains.Columns[e.ColumnIndex].Name == "dgvDeleteColumn")
            {
                DataGridViewRow row = dgvOnlineTrains.Rows[e.RowIndex];
                string trainNumber = row.Cells["dgvTrNoColumn"].Value.ToString();

                OnlineTrainsDao.DeleteTrainFromRunningTrains(trainNumber);

                Form mainForm = Application.OpenForms["frmOnlineTrains"];

                if (mainForm != null)
                {
                    frmOnlineTrains frmonline = (frmOnlineTrains)mainForm;

                    frmonline.fillRunningTrains();
                }
            }
            if (dgvOnlineTrains.Columns[e.ColumnIndex].Name == "dgvAdColumn")
            {
                DataGridViewCell cell = dgvOnlineTrains.Rows[e.RowIndex].Cells[e.ColumnIndex];

                DataGridViewCell statuscell = dgvOnlineTrains.Rows[e.RowIndex].Cells[e.ColumnIndex + 1];


                // Check if the clicked cell is the column you want to change
                if (dgvOnlineTrains.Columns[e.ColumnIndex].Name == "dgvAdColumn")
                {
                    // Check if the cell is initialized and not null
                    if (cell != null && cell.Value != null)
                    {
                        string currentValue = cell.Value.ToString();

                        // Change text
                        if (currentValue == "A")
                        {
                            cell.Value = "D";
                            resetDepatureStatus(statuscell);

                        }
                        else if (currentValue == "D")
                        {
                            cell.Value = "A";
                            resetArrivalStatus(statuscell);
                        }

                    }

                }

            }
        }



        private void frmOnlineTrains_Leave(object sender, EventArgs e)
        {
            Form mainForm = Application.OpenForms["frmScheduledTrains"];
            if (mainForm != null)
            {
                frmScheduledTrains frmScheduled = (frmScheduledTrains)mainForm;
                frmScheduled.Close();
            }
        }

        private void frmOnlineTrains_MouseClick(object sender, MouseEventArgs e)
        {
            Form mainForm = Application.OpenForms["frmScheduledTrains"];
            if (mainForm != null)
            {
                frmScheduledTrains frmScheduled = (frmScheduledTrains)mainForm;
                frmScheduled.Close();
            }
        }
        public void activateOrDeactivateButtons(bool trueOrFalse)
        {
            btnRight.Enabled = trueOrFalse;
            btnInsert.Enabled = trueOrFalse;
            btnLeft.Enabled = trueOrFalse;
            btnReverse.Enabled = trueOrFalse;
            btnRemove.Enabled = trueOrFalse;
            btnCancel.Enabled = trueOrFalse;
            btnTrainRevesal.Enabled = trueOrFalse;
            btnSingleRemoval.Enabled = trueOrFalse;
            btnSave.Enabled = trueOrFalse;
            pnlCoachPositions.Enabled = trueOrFalse;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            activateOrDeactivateButtons(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            activateOrDeactivateButtons(false);
        }



        public void fillCoaches(string a)
        {
            //  string a = "ENG,GEN,S1,S2,S3,S4,S5,A1,A2,A3,A4,B1,B2,B1,C1,C2,C3,B2,B2,B2,S5,A1,A2,A3,GEN,GEN,GEN,PWR";
            string[] parts = a.Split(',');

            // Ensure we do not exceed the array bounds
            TextBox[] textBoxes = {
            txtCoach1, txtCoach2, txtCoach3, txtCoach4, txtCoach5,
            txtCoach6, txtCoach7, txtCoach8, txtCoach9, txtCoach10,
            txtCoach11, txtCoach12, txtCoach13, txtCoach14, txtCoach15,
            txtCoach16, txtCoach17, txtCoach18, txtCoach19, txtCoach20,
             txtCoach21, txtCoach22, txtCoach23, txtCoach24, txtCoach25,
            txtCoach26, txtCoach27, txtCoach28,
        };

            for (int i = 0; i < textBoxes.Length && i < parts.Length; i++)
            {
                textBoxes[i].Text = parts[i];
            }
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            // Define the array of TextBoxes
            TextBox[] textBoxes = {
                txtCoach1, txtCoach2, txtCoach3, txtCoach4, txtCoach5,
                txtCoach6, txtCoach7, txtCoach8, txtCoach9, txtCoach10,
                txtCoach11, txtCoach12, txtCoach13, txtCoach14, txtCoach15,
                txtCoach16, txtCoach17, txtCoach18, txtCoach19, txtCoach20,
                txtCoach21, txtCoach22, txtCoach23, txtCoach24, txtCoach25,
                txtCoach26, txtCoach27, txtCoach28
            };

            // Swap the values in the TextBoxes
            int leftIndex = 0;
            int rightIndex = textBoxes.Length - 1;
            while (leftIndex < rightIndex)
            {
                // Swap text
                string temp = textBoxes[leftIndex].Text;
                textBoxes[leftIndex].Text = textBoxes[rightIndex].Text;
                textBoxes[rightIndex].Text = temp;

                // Move indices towards the center
                leftIndex++;
                rightIndex--;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ClearTextBoxesInPanel(pnlCoachPositions);
        }
        private void ClearTextBoxesInPanel(Panel panel)
        {
            // Iterate through all controls within the panel
            foreach (Control control in panel.Controls)
            {
                // Check if the control is a TextBox
                if (control is TextBox textBox)
                {
                    // Clear the text of the TextBox
                    textBox.Clear();
                }
            }
        }
        private int currentTextBoxIndex = 0;
        private void btnSingleRemoval_Click(object sender, EventArgs e)
        {
            ClearNextTextBox();
        }

        private void ClearNextTextBox()
        {
            TextBox[] textBoxes = {txtCoach1, txtCoach2, txtCoach3, txtCoach4, txtCoach5,txtCoach6, txtCoach7, txtCoach8, txtCoach9, txtCoach10,
            txtCoach11, txtCoach12, txtCoach13, txtCoach14, txtCoach15,txtCoach16, txtCoach17, txtCoach18, txtCoach19, txtCoach20,
            txtCoach21, txtCoach22, txtCoach23, txtCoach24, txtCoach25,txtCoach26, txtCoach27, txtCoach28 };

            // Check if there are TextBoxes left to clear
            if (currentTextBoxIndex < textBoxes.Length - 1)
            {
                // Iterate over each TextBox from the current index to the second last one
                for (int i = currentTextBoxIndex; i < textBoxes.Length - 1; i++)
                {
                    // Assign the text of the next TextBox to the current TextBox
                    textBoxes[i].Text = textBoxes[i + 1].Text;
                }

                // Clear the text of the last TextBox
                textBoxes[textBoxes.Length - 1].Clear();

                // Reset the currentTextBoxIndex to 0 to start from the beginning
                currentTextBoxIndex = 0;
            }
            else
            {
                // Clear the text of the last TextBox if all TextBoxes have been cleared
                textBoxes[textBoxes.Length - 1].Clear();

                MessageBox.Show("All text boxes have been cleared.");
            }
        }
        private void btnSingleRemoval_Leave(object sender, EventArgs e)
        {
            currentTextBoxIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            activateOrDeactivateButtons(false);
        }
        public static List<DataGridViewRow> checkedRows = new List<DataGridViewRow>();
        private bool CheckCheckedRows()
        {
            bool b = false;
            
            checkedRows.Clear();
            foreach (DataGridViewRow row in dgvOnlineTrains.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (Convert.ToBoolean(row.Cells["dgvTdbColumn"].EditedFormattedValue))
                    {
                        checkedRows.Add(row);
                    }
                }
            }
            BaseClass.SelectedTDBRows = checkedRows.Count;
            if (checkedRows.Count > 0)
            {
                b = true;
                foreach (var row in checkedRows)
                {
                    if (row.Cells["dgvPFColumn"].Value == null)
                    {
                        b = false;
                    }
                }
                if (b)
                {                    
                                
                }
                else
                {
                    MessageBox.Show("please Select PlatForm");
                }
            }
            else
            {
                MessageBox.Show("please Select Atlesat one Train");
            }
            BaseClass.TaddbRows = checkedRows;
            return b;
        }

        public static void sendData()
        {
            foreach (string ip in Server.PfdbIpAdress)
            {
                BaseClass.boardType = "PFDB";
                PacketController.DataPacket(checkedRows, ip);
                byte[] finalPacket = PfdbController.getTaddbFullPacket(Board.PFDB, Server.ipAdress, ip, BaseClass.GetSerialNumber(), Board.DataTransfer);
                Server.SendMessageToClient(ip, finalPacket);
            }
            foreach (string ip in Server.AgdbIpAdress)
            {
                BaseClass.boardType = "AGDB";
                PacketController.DataPacket(checkedRows, ip);
                byte[] finalPacket = AgdbController.getAgdbFullPacket(Board.AGDB, Server.ipAdress, ip, BaseClass.GetSerialNumber(), Board.DataTransfer);
                Server.SendMessageToClient(ip, finalPacket);
            }                    
            foreach (string ip in Server.MldbIpAdress)
            {
                BaseClass.boardType = "MLDB";
                PacketController.DataPacket(checkedRows, ip);
                byte[] finalPacket = MldbController.getMldbFullPacket(Board.MLDB, Server.ipAdress, ip, BaseClass.GetSerialNumber(), Board.DataTransfer);
                Server.SendMessageToClient(ip, finalPacket);
                string a = PfdbController.ByteArrayToString(finalPacket);
            }
            foreach (string ip in Server.OvdIpAdress)
            {
                BaseClass.boardType = "OVD";
                PacketController.DataPacket(checkedRows, ip);
                byte[] finalPacket = MldbController.getMldbFullPacket(Board.OVD, Server.ipAdress, ip, BaseClass.GetSerialNumber(), Board.DataTransfer);
                Server.SendMessageToClient(ip, finalPacket);
                string a = PfdbController.ByteArrayToString(finalPacket);
            }
            foreach (string ip in Server.IvdIpAdress)
            {
                BaseClass.boardType = "MLDB";
                PacketController.DataPacket(checkedRows, ip);
                byte[] finalPacket = MldbController.getMldbFullPacket(Board.IVD, Server.ipAdress, ip, BaseClass.GetSerialNumber(), Board.DataTransfer);
                Server.SendMessageToClient(ip, finalPacket);
            }
        }


        private void btnTdb_Click(object sender, EventArgs e)
        {
            Server.getBoardsIpAdress();
            bool check = CheckCheckedRows();
            if (check)
            {
 
                if (Server._connectedClients.Count > 0)
                {
                    sendData();             
                }    
                else
                {
                    MessageBox.Show("wait boards are connecting");
                }
                //byte[] hexValues = PfdbController.ConvertHexStringToByteArray(PfdbController.hexString);
                //byte[] TaddbDta = PfdbController.ConvertHexToByteArray(hexValues);                
               }
        }

        private void dgvOnlineTrains_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

            
        }

        private void dgvOnlineTrains_AlternatingRowsDefaultCellStyleChanged(object sender, EventArgs e)
        {

        }
        private void dgvOnlineTrains_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = e.Control as TextBox;
            if (tb != null)
            {
                tb.KeyPress -= Tb_KeyPress;
                tb.KeyPress += Tb_KeyPress;

            }
            if (e.Control is ComboBox comboBox)
            {
                // Remove any existing event handlers
                comboBox.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;

                // Add the SelectedIndexChanged event handler
                comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            }
        }
        private void Tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow digits and control characters (backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvOnlineTrains_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgvOnlineTrains.Columns["dgvLateColumn"].Index)
            {
                string input = e.FormattedValue.ToString();

                if (input.Length != 4 || !int.TryParse(input, out _))
                {
                    ResetCellToDefault(e.RowIndex, e.ColumnIndex);
                }
                else
                {
                    int hours = int.Parse(input.Substring(0, 2));
                    int minutes = int.Parse(input.Substring(2, 2));

                    if (hours < 0 || hours > 23 || minutes < 0 || minutes > 59)
                    {
                        ResetCellToDefault(e.RowIndex, e.ColumnIndex);
                    }
                }
            }
        }

        private void dgvOnlineTrains_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvOnlineTrains.Columns["dgvLateColumn"].Index)
            {
                string input = dgvOnlineTrains.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (input.Length == 4 && int.TryParse(input, out _))
                {
                    int hours = int.Parse(input.Substring(0, 2));
                    int minutes = int.Parse(input.Substring(2, 2));

                    if (hours >= 0 && hours <= 23 && minutes >= 0 && minutes <= 59)
                    {
                        string formattedTime = $"{input.Substring(0, 2)}:{input.Substring(2, 2)}";
                        dgvOnlineTrains.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = formattedTime;
                    }
                    else
                    {
                        MessageBox.Show("please eneter valid value");
                        ResetCellToDefault(e.RowIndex, e.ColumnIndex);
                    }
                }
                else
                {
                    MessageBox.Show("please eneter valid value");
                    ResetCellToDefault(e.RowIndex, e.ColumnIndex);
                }
            }
        }


       
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
               BaseClass.currentdatgridRow= dgvOnlineTrains.CurrentRow;
                
                var currentCell = dgvOnlineTrains.CurrentCell;
                if (currentCell != null && currentCell.OwningColumn.Name == "dgvTrainStatusColumn")
                {
                    string selectedValue = comboBox.SelectedItem.ToString();

                    if (selectedValue== "Terminated"||selectedValue== "Diverted" || selectedValue == "Change of Source")
                    {
                        frmStations frmstations;
                        Form mainForm = Application.OpenForms["frmStations"];

                        if (mainForm != null)
                        {
                            frmstations = (frmStations)mainForm;
                            frmstations.Show();
                        }
                        else
                        {
                            frmstations = new frmStations();
                            frmstations.Show();
                        }
                        frmstations.BringToFront();
                    }
                
                }
            }
        }
        private void ResetCellToDefault(int rowIndex, int columnIndex)
        {        
            dgvOnlineTrains.Rows[rowIndex].Cells[columnIndex].Value = "00:00";
        } 
        public static void ChangeCity(DataGridViewRow currentRow, List<DataGridViewRow> stationRows)
        {
            String engStationNames = "";
            String hinStationNames = "";
            String regStationNames = "";
            if (stationRows.Count>0)
            {
                foreach (DataGridViewRow row in stationRows)
                {
                    if (row.Cells["dgvEnglishcolumn"].Value != null)
                    {
                        engStationNames += row.Cells["dgvEnglishcolumn"].Value.ToString() + ",";
                        hinStationNames += row.Cells["dgvHindiColumn"].Value.ToString() + ",";
                        regStationNames += row.Cells["dgvRegional"].Value.ToString() + ",";

                    }
                }
                // Optionally, remove the trailing comma
                if (engStationNames.EndsWith(","))
                {
                    engStationNames = engStationNames.TrimEnd(',');
                    hinStationNames = hinStationNames.TrimEnd(',');
                    regStationNames = regStationNames.TrimEnd(',');
                }
            }
            if (currentRow != null)
            {
                
                currentRow.Cells["dgvCityColumn"].Value = engStationNames;
                currentRow.Cells["dgvHindiCityName"].Value = hinStationNames;
                currentRow.Cells["dgvRegCityName"].Value = regStationNames;
            }

        }

        private void btnCdb_Click(object sender, EventArgs e)
        {

        }

        private void dgvOnlineTrains_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


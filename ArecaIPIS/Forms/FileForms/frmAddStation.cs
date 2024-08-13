using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArecaIPIS.DAL;

namespace ArecaIPIS.Forms
{
    public partial class frmAddStation : Form
    {
        private string initialText;
        ToolStripDropDown dropDown;
        AddStationDb addstationDb = new AddStationDb();
        public frmAddStation()
        {
            InitializeComponent();

            dgvAddStation.EnableHeadersVisualStyles = false;
            dgvAddStation.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;
            dgvAddStation.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvAddStation.AllowUserToResizeRows = false;

            pnlCreateStation.Visible = false;
            pnlSCreate.Visible = false;

            CheckedListBox checkedListBox = new CheckedListBox();
            checkedListBox.Items.AddRange(new object[] { "Station Code", "English", "Hindi", "Regional language" });

            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemChecked(i, true);
                checkedListBox.BackColor = Color.LightSalmon;
            }

            dropDown = new ToolStripDropDown();
            ToolStripControlHost host = new ToolStripControlHost(checkedListBox);
            host.Padding = Padding.Empty;
            dropDown.Items.Add(host);
            btnCross.Visible = false;
            initialText = txtSearch.Text;
            lblNoDataToDisplay.Visible = false;

            toolTip.SetToolTip(btnAddMessage, "Add New Message");
            dgvAddStation.CellToolTipTextNeeded += new DataGridViewCellToolTipTextNeededEventHandler(dgvAddStation_CellToolTipTextNeeded);
            btnDropdown.Visible = false;
        }
        private void dgvAddStation_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                if (dgvAddStation.Columns[e.ColumnIndex] is DataGridViewImageColumn)
                {
                    e.ToolTipText = "Edit";
                }
            }
            
        }


        private frmHome parentForm;

        public frmAddStation(frmHome parentForm) : this()
        {
            this.parentForm = parentForm;
        }
        int pagesize = 8;
        private void frmStationDeatils_Load(object sender, EventArgs e)
        {
            dgvAddStation.RowTemplate.Height = 36;
            showData(1, pagesize);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddStations_Click(object sender, EventArgs e)
        {
            frmCreateStation crtStation = new frmCreateStation();
            crtStation.Show();

        }

        public void showData(int pageIndex, int pagesize)
        {
            (DataTable stationName, int recordCount) = addstationDb.GetAllStationNames(pageIndex, pagesize);

            if (stationName != null)
            {

                 dgvAddStation.DataSource = stationName;
                //dgvAddStation.Columns["StationCode"].HeaderText = "Station Code";
                //dgvAddStation.Columns["stationeng"].HeaderText = "English";
                //dgvAddStation.Columns["stationhind"].HeaderText = "Hindi";
                //dgvAddStation.Columns["stationreg1"].HeaderText = "Regional";


                dgvAddStation.Columns["StationCode"].DataPropertyName = "StationCode";
                dgvAddStation.Columns["English"].DataPropertyName = "stationeng";
                dgvAddStation.Columns["Hindi"].DataPropertyName = "stationhind";
                dgvAddStation.Columns["RegionalLanguage"].DataPropertyName = "stationreg1";

                if (!dgvAddStation.Columns.Contains("Pkey_stationnames"))
                {
                    DataGridViewTextBoxColumn pkeyColumn = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Pkey_stationnames",
                        HeaderText = "Pkey_stationnames",
                        Name = "Pkey_stationnames",
                        Visible = false
                    };
                    dgvAddStation.Columns.Add(pkeyColumn);
                }
                else
                {
                    dgvAddStation.Columns["Pkey_stationnames"].DataPropertyName = "Pkey_stationnames";
                    dgvAddStation.Columns["Pkey_stationnames"].Visible = false;
                }

                //dgvAddStation.AllowUserToResizeRows = false;
                //int totalHeight = dgvAddStation.ColumnHeadersHeight;
                //foreach (DataGridViewRow row in dgvAddStation.Rows)
                //{
                //    totalHeight += row.Height;
                //}

                //dgvAddStation.Height = totalHeight;

                PaginationClass pagination = new PaginationClass();
                pagination.Populate(recordCount, pageIndex, pagesize, pnlPagination, this, showData);
 
            }

            else
            {

                MessageBox.Show("Failed to retrieve Station Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //dgvAddStation.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        //int paginationTop = dgvAddStation.Bottom + 8;
        //pnlPagination.Location = new Point(pnlPagination.Location.X, paginationTop);

       
        private bool validateEnglishStationName()
        {
            if (string.IsNullOrWhiteSpace(txtEnglishName.Text))
            {
                txtEnglishName.BackColor = Color.Red;
                return false;
            }
            else
            {
                txtEnglishName.BackColor = SystemColors.Window; 
                return true;
            }
        }

        private bool validateHindiStationName()
        {
            if (string.IsNullOrWhiteSpace(txtHindiName.Text))
            {
                txtHindiName.BackColor = Color.Red; 
                return false; 
            }
            else
            {
                txtHindiName.BackColor = SystemColors.Window; 
                return true; 
            }
        }

        private bool validateRegionalStationName()
        {
            if (string.IsNullOrWhiteSpace(txtRegionalName.Text))
            {
                txtRegionalName.BackColor = Color.Red; 
                return false;
            }
            else
            {
                txtRegionalName.BackColor = SystemColors.Window; 
                return true; 
            }
        }

        private bool validateStationCode()
        {
            string stationCode = txtStationCode.Text.Trim();
            int textLength = stationCode.Length;

            if (textLength < 2 || textLength > 4)
            {

                txtStationCode.BackColor = Color.Red;
                return false;
            }
            else
            {

                txtStationCode.BackColor = SystemColors.Window;
                txtStationCode.BorderStyle = BorderStyle.Fixed3D;


                return true;

            }
        }

        private bool ValidateFilePath()
        {

            string filePath = lblNoFileChoosen.Text.Trim();


            if (string.IsNullOrEmpty(filePath))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void txtStationCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                txtStationCode.BackColor = Color.Red; 
                txtStationCode.BorderStyle = BorderStyle.FixedSingle; 
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool isValidStationCode = validateStationCode();
                bool isValidEnglishStationName = validateEnglishStationName();
                bool isValidHindiStationName = validateHindiStationName();
                bool isValidRegionalStationName = validateRegionalStationName();
                bool isValidFilePath = ValidateFilePath();

                if (isValidStationCode && isValidEnglishStationName && isValidHindiStationName && isValidRegionalStationName && isValidFilePath)
                {
                    string stationCode = txtStationCode.Text;
                    string englishStationName = txtEnglishName.Text;
                    string hindiStationName = txtHindiName.Text;
                    string regionalStationName = txtRegionalName.Text;
                    string regional2 ="";
                    string filePath = lblNoFileChoosen.Text;
                    int pk = pkey;

                    bool result = addstationDb.InsertOrUpdateStationNames(pk, stationCode, englishStationName, hindiStationName, regionalStationName, regional2, filePath);

                    if (result)
                    {
                        MessageBox.Show("Data saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Optionally reset form fields here if needed
                        // txtStationCode.Text = "";
                        // txtEnglishName.Text = "";
                        // txtHindiName.Text = "";
                        // txtRegionalName.Text = "";
                        // lblNoFileChoosen.Text = "No file chosen";
                    }
                    else
                    {
                        MessageBox.Show("An error occurred while saving the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
        }

        private void btnAudioPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set properties of the OpenFileDialog
            openFileDialog.Title = "Choose Audio File";
            openFileDialog.Filter = "Audio Files|*.wav;*.mp3;*.ogg|All Files|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Multiselect = false;

            // Show the OpenFileDialog and get the result
            DialogResult result = openFileDialog.ShowDialog();

            // Check if the user selected a file
            if (result == DialogResult.OK)
            {
                // Get the selected file's path
                string filePath = openFileDialog.FileName;

                // Use the filePath as needed (e.g., display it in a textbox)
                lblNoFileChoosen.Text = filePath;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlCreateStation.Visible = false;
            pnlSCreate.Visible = false;
        }

        private void btnAddMessage_Click(object sender, EventArgs e)
        {
            txtStationCode.Text = "";
            txtStationCode.BackColor = SystemColors.Window;
            txtEnglishName.Text = "";
            txtEnglishName.BackColor = SystemColors.Window;
            txtHindiName.Text = "";
            txtHindiName.BackColor = SystemColors.Window;
            txtRegionalName.Text = "";
            txtRegionalName.BackColor = SystemColors.Window;
            lblNoFileChoosen.Text = "No File Chosen";
            pnlCreateStation.Visible = true;
            lblCreateStation.Text = "Create Station";
            btnSave.Text = "    Save";
            pnlSCreate.Visible = true;
        }

        private void txtStationCode_TextChanged(object sender, EventArgs e)
        {
            string stationCode = txtStationCode.Text.Trim();
            int textLength = stationCode.Length;

            if (textLength < 2 || textLength > 4)
            {

                txtStationCode.BackColor = Color.Red;
                txtStationCode.ForeColor = SystemColors.WindowText;
            }
            else
            {

                txtStationCode.BackColor = SystemColors.Window;
                txtStationCode.BorderStyle = BorderStyle.Fixed3D;
                txtStationCode.ForeColor = Color.Green;
            }
        }

        private void txtEnglishName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEnglishName.Text))
            {
                txtEnglishName.BackColor = Color.Red;
                txtEnglishName.ForeColor = SystemColors.WindowText;

            }
            else
            {
                txtEnglishName.BackColor = SystemColors.Window;
                txtEnglishName.BorderStyle = BorderStyle.Fixed3D;
                txtEnglishName.ForeColor = Color.Green;
            }
        }

        private void txtHindiName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHindiName.Text))
            {
                txtHindiName.BackColor = Color.Red;
                txtHindiName.ForeColor = SystemColors.WindowText;

            }
            else
            {
                txtHindiName.BackColor = SystemColors.Window;
                txtHindiName.BorderStyle = BorderStyle.Fixed3D;
                txtHindiName.ForeColor = Color.Green;
            }
        }

        private void txtRegionalName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegionalName.Text))
            {
                txtRegionalName.BackColor = Color.Red;
                txtRegionalName.ForeColor = SystemColors.WindowText;

            }
            else
            {
                txtRegionalName.BackColor = SystemColors.Window;
                txtRegionalName.BorderStyle = BorderStyle.Fixed3D;
                txtRegionalName.ForeColor = Color.Green;
            }
        }
        int pkey;
        private void dgvAddStation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                try
                {
                    int pkeyValue = Convert.ToInt32(dgvAddStation.Rows[e.RowIndex].Cells["Pkey_stationnames"].Value);
                    DataTable Message = addstationDb.GetStationNameByRow(pkeyValue);

                    if (Message != null && Message.Rows.Count > 0)
                    {
                        pkey = pkeyValue;
                        string SCode = Message.Rows[0]["StationCode"].ToString();
                        string english = Message.Rows[0]["stationeng"].ToString();
                        string Hindi = Message.Rows[0]["stationhind"].ToString();
                        string regional = Message.Rows[0]["stationreg1"].ToString();
                        string file = Message.Rows[0]["AudoFile"].ToString();

                        //frmCreateMessage fcm = new frmCreateMessage();
                        //fcm.SetMessageDetails(pkey, englishMessage, nationalMessage, regionalMessage, file);
                        ////fcm.Show();
                        //fcm.FormClosedEvent += new EventHandler(frmCreateMessage_FormClosed);
                        //OpenFormInPanel(fcm);
                        //pnlSendMessage.Visible = false;
                        //pnlSpecialMsgs.Visible = false;
                        //txtSpecialMsgAnnounce.Visible = false;

                          pnlCreateStation.Visible = true;
                        pnlSCreate.Visible = true;
                        lblCreateStation.Text = "Edit Station";
                        btnSave.Text = "    Update";
                        txtStationCode.Text = SCode;
                        txtEnglishName.Text = english;
                        txtHindiName.Text = Hindi;
                        txtRegionalName.Text = regional;
                        lblNoFileChoosen.Text = file;

                    }
                    else
                    {
                        MessageBox.Show("No data retrieved from the database.");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDropdown_Click(object sender, EventArgs e)
        {
            dropDown.Show(btnDropdown, new System.Drawing.Point(0, btnDropdown.Height));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnCross.Visible = true;
            btnSearch.Visible = false;
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            txtSearch.Text = initialText;
            showData(1, pagesize);
            btnSearch.Visible = true;
            btnCross.Visible = false;
            //dGVMessages.ScrollBars = ScrollBars.None;
            lblNoDataToDisplay.Visible = false;
        }
        private string previousSearchText = string.Empty;
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            if (searchText.Length < previousSearchText.Length)
            {
                lblNoDataToDisplay.Visible = false;
                btnCross.Visible = false;
                btnSearch.Visible = true;

                //if (string.IsNullOrEmpty(searchText))
                //{
                //    dGVMessages.ScrollBars = ScrollBars.None;
                //}

                FilterData(1, pagesize, searchText);
            }
            else
            {
                FilterData(1, pagesize, searchText);
                btnCross.Visible = true;
                btnSearch.Visible = false;
            }

            previousSearchText = searchText;
        }
        public void FilterData(int pageIndex, int pageSize, string searchQuery)
        {
            try
            {
                (DataTable stationName, int recordCount) = addstationDb.GetSearchStation(pageIndex, pageSize, searchQuery);

                if (stationName != null && stationName.Rows.Count > 0)
                {
                    dgvAddStation.AutoGenerateColumns = false;


                    dgvAddStation.Columns["StationCode"].DataPropertyName = "StationCode";
                    dgvAddStation.Columns["English"].DataPropertyName = "stationeng";
                    dgvAddStation.Columns["Hindi"].DataPropertyName = "stationhind";
                    dgvAddStation.Columns["RegionalLanguage"].DataPropertyName = "stationreg1";

                    if (!dgvAddStation.Columns.Contains("Pkey_stationnames"))
                    {
                        DataGridViewTextBoxColumn pkeyColumn = new DataGridViewTextBoxColumn
                        {
                            DataPropertyName = "Pkey_stationnames",
                            HeaderText = "Pkey_stationnames",
                            Name = "Pkey_stationnames",
                            Visible = false
                        };
                        dgvAddStation.Columns.Add(pkeyColumn);
                    }
                    else
                    {
                        dgvAddStation.Columns["Pkey_stationnames"].DataPropertyName = "Pkey_stationnames";
                        dgvAddStation.Columns["Pkey_stationnames"].Visible = false;
                    }

                    dgvAddStation.DataSource = stationName;

                    //dgvAddStation.Columns["English"].Width = 370;
                    //dgvAddStation.Columns["Hindi"].Width = 370;
                    //dgvAddStation.Columns["RegionalLanguage"].Width = 370;

                    //dgvAddStation.AllowUserToAddRows = false;
                    //int totalHeight = dgvAddStation.ColumnHeadersHeight;
                    //foreach (DataGridViewRow row in dgvAddStation.Rows)
                    //{
                    //    totalHeight += row.Height;
                    //}

                    //dgvAddStation.Height = totalHeight;


                    dgvAddStation.ScrollBars = ScrollBars.Vertical;

                    lblNoDataToDisplay.Visible = false;
                }
                else
                {
                    dgvAddStation.DataSource = null;
                    lblNoDataToDisplay.Visible = true;
                }

                // Update pagination
                PaginationClass pagination = new PaginationClass();
                pagination.Populate(recordCount, pageIndex, pageSize, pnlPagination, this, (pageIdx, size) => FilterData(pageIdx, size, searchQuery));
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == initialText)
            {
                txtSearch.Clear();
            }
        }
    }
}

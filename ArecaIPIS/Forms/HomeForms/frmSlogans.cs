using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArecaIPIS.DAL;

namespace ArecaIPIS.Forms.HomeForms
{
 
    public partial class frmSlogans : Form
    {
        ToolStripDropDown dropDown;
        SloganDb sloganDb = new SloganDb();
        private string initialText;
        public frmSlogans()
        {
            InitializeComponent();
            dgvSlogan.EnableHeadersVisualStyles = false;
            dgvSlogan.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
            dgvSlogan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvSlogan.AllowUserToResizeRows = false;

            foreach (DataGridViewColumn column in dgvSlogan.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            foreach (DataGridViewRow row in dgvSlogan.Rows)
            {
                row.Height = 40;
            }

            CheckedListBox checkedListBox = new CheckedListBox();
            checkedListBox.Items.AddRange(new object[] { "Message", "Select",  "Delete"});

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
            pnlFormShow.Visible = false;

            lblShowingAudio.Visible = false;
            lblMessageValidation.Visible = false;
            pbTick.Visible = false;
            pbTickFile.Visible = false;
            pbCross.Visible = false;
            cmbLanguage.DisplayMember = "Text";
            cmbLanguage.ValueMember = "Value";

            var languages = new[] {
        new { Text = "English", Value = 6 },
        new { Text = "Hindi", Value = 16 },
        new { Text = "RegionalLanguage", Value = 1 }
    };
            cmbLanguage.DataSource = languages;
            cmbLanguage.SelectedIndex = 0;


            toolTipSlogan.SetToolTip(btnAddSloganMessage, "Add New Message");
            toolTipSlogan.SetToolTip(btnSendMessage, "Send Selected Messages");
            toolTipSlogan.SetToolTip(btnPlayMessage, "Play");
            toolTipSlogan.SetToolTip(btnStopMessage, "Stop");
            toolTipSlogan.SetToolTip(btnPauseMessage, "Pause");
            //toolTipSlogan.IsBalloon = true;
            dgvSlogan.CellToolTipTextNeeded += new DataGridViewCellToolTipTextNeededEventHandler(dgvSlogan_CellToolTipTextNeeded);
        }

        private void dgvSlogan_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                if (dgvSlogan.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    e.ToolTipText = "Edit";
                }
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == 3)
            {
                if (dgvSlogan.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    e.ToolTipText = "Delete";
                }
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == 2)
            {
                if (dgvSlogan.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {
                    e.ToolTipText = "Select";
                }
            }
        }
        private frmHome parentForm;

        public frmSlogans(frmHome parentForm) : this()
        {
            this.parentForm = parentForm;
        }
       


        private void dgvSlogan_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                if (dgvSlogan.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.Value == null)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                    e.Graphics.DrawImage(Properties.Resources.edit, e.CellBounds.Location);
                    e.Handled = true;
                   
                }
                
            }


            if (e.RowIndex >= 0 && e.ColumnIndex == 3)
            {
                if (dgvSlogan.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.Value == null)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                    int imageWidth = Properties.Resources.delete_remove_icon.Width;
                    int imageHeight = Properties.Resources.delete_remove_icon.Height;
                    int cellWidth = e.CellBounds.Width;
                    int cellHeight = e.CellBounds.Height;
                    int x = e.CellBounds.Left + (cellWidth - imageWidth) / 2;
                    int y = e.CellBounds.Top + (cellHeight - imageHeight) / 2;
                    Point location = new Point(x, y);

                    e.Graphics.DrawImage(Properties.Resources.delete_remove_icon, location);

                    e.Handled = true;
                }
            }
        }

        private void btnAddSloganMessage_Click(object sender, EventArgs e)
        {

            //frmCreateSloganMessage fCSM = new frmCreateSloganMessage();
            //fCSM.FormClosedEvent += new EventHandler(frmCreateSloganMessage_FormClosed);
            //OpenFormInPanel(fCSM);

            pnlFormShow.Visible = true;
            pnlMessageAnnouncement.Visible = false;
            txtMessage.Text = "";
            //cmbLanguage.Text = "";
            lblFile.Text = "";
            lblCreateMessage.Text = "Create Message";
            btnSave.Text = "    Save";
            pbCross.Visible = false;
            pbTickFile.Visible = false;
            lblShowingAudio.Visible = false;
            lblMessageValidation.Visible = false;
        }

        private void frmSlogans_Load(object sender, EventArgs e)
        {
            InitializeForm();
        }
        private void InitializeForm()
        {
            dgvSlogan.RowTemplate.Height = 50;

            DataTable specialMessages = sloganDb.GetSloganMessages();

            if (specialMessages != null)
            {
                dgvSlogan.AutoGenerateColumns = false;

                dgvSlogan.Columns["Message"].DataPropertyName = "Message";

                if (!dgvSlogan.Columns.Contains("Pkey_SpclMsgs"))
                {
                    DataGridViewTextBoxColumn pkeyColumn = new DataGridViewTextBoxColumn();
                    pkeyColumn.DataPropertyName = "Pkey_SpclMsgs";
                    pkeyColumn.HeaderText = "Pkey_SpclMsgs";
                    pkeyColumn.Name = "Pkey_SpclMsgs";
                    pkeyColumn.Visible = false; 
                    dgvSlogan.Columns.Add(pkeyColumn);
                }
                else
                {
                    dgvSlogan.Columns["Pkey_SpclMsgs"].DataPropertyName = "Pkey_SpclMsgs";
                    dgvSlogan.Columns["Pkey_SpclMsgs"].Visible = false; 
                }
                dgvSlogan.DataSource = specialMessages;
            }

            dgvSlogan.AllowUserToAddRows = false;

            int totalHeight = dgvSlogan.ColumnHeadersHeight;
            foreach (DataGridViewRow row in dgvSlogan.Rows)
            {
                totalHeight += row.Height;
            }
            dgvSlogan.Height = totalHeight;

        }

        int pkey;
        private void dgvSlogan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                try
                {
                    int pkeyValue = Convert.ToInt32(dgvSlogan.Rows[e.RowIndex].Cells["Pkey_SpclMsgs"].Value);
                    //MessageBox.Show(pkeyValue.ToString());
                    DataTable Slogan = sloganDb.GetSlogansByRow(pkeyValue);
                    
                    if (Slogan != null && Slogan.Rows.Count > 0)
                    {
                         pkey = pkeyValue;
                        string Message = Slogan.Rows[0]["Message"].ToString();
                        string Language = Slogan.Rows[0]["LanguageName"].ToString();
                        string file = Slogan.Rows[0]["AudioFilePath"].ToString();

                        //frmCreateSloganMessage fCSM = new frmCreateSloganMessage();
                        //fCSM.SetSloganDetails(pkey, Message, Language, file);
                        //fCSM.FormClosedEvent += new EventHandler(frmCreateSloganMessage_FormClosed);
                        //OpenFormInPanel(fCSM);
                        pnlFormShow.Visible = true;
                        txtMessage.Text = Message;
                        cmbLanguage.Text = Language;
                        lblFile.Text = file;
                        lblCreateMessage.Text = "Edit Message";
                        btnSave.Text = "    Update";
                        pnlMessageAnnouncement.Visible = false;
                        //fcsm.Show();
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

            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                try
                {
                    int pkeyValue = Convert.ToInt32(dgvSlogan.Rows[e.RowIndex].Cells["Pkey_SpclMsgs"].Value);

                    string statusMessage = sloganDb.DeleteSlogan(pkeyValue);

                    MessageBox.Show(statusMessage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void SearchData(string searchQuery)
        {
            try
            {
                DataTable specialSlogan = sloganDb.GetSearchSlogan(searchQuery);

                if (specialSlogan != null && specialSlogan.Rows.Count > 0)
                {
                    DataTable displayTable = new DataTable();
                    displayTable.Columns.Add("Message", typeof(string));
                    displayTable.Columns.Add("Pkey_SpclMsgs", typeof(int));

                    foreach (DataRow row in specialSlogan.Rows)
                    {
                        DataRow newRow = displayTable.Rows.Add(row["Message"]);
                        newRow["Pkey_SpclMsgs"] = row["Pkey_SpclMsgs"];
                    }

                    dgvSlogan.DataSource = displayTable;
                    dgvSlogan.AllowUserToAddRows = false;
                    dgvSlogan.Columns["Pkey_SpclMsgs"].Visible = false;

                    int totalHeight = dgvSlogan.ColumnHeadersHeight;
                    foreach (DataGridViewRow row in dgvSlogan.Rows)
                    {
                        totalHeight += row.Height;
                    }
                    dgvSlogan.Height = totalHeight;
                }
                else
                {
                    dgvSlogan.DataSource = null;
                    lblNoDataToDisplay.Visible = true;
                    //MessageBox.Show("No data to display.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string previousSearchText = string.Empty;
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //string searchText = txtSearch.Text.Trim();

            //if (string.IsNullOrEmpty(searchText))
            //{
            //    lblNoDataToDisplay.Visible = false;
            //    btnCross.Visible = false;
            //    btnSearch.Visible = true;
            //    SearchData(searchText);
            //}
            //else
            //{
            //    SearchData(searchText);
            //    btnCross.Visible = true;
            //    btnSearch.Visible = false;
            //}


            string searchText = txtSearch.Text.Trim();

            if (searchText.Length < previousSearchText.Length)
            {
                lblNoDataToDisplay.Visible = false;
                btnCross.Visible = false;
                btnSearch.Visible = true;
                SearchData(searchText);
            }
            else
             {
                SearchData(searchText);
                btnCross.Visible = true;
                btnSearch.Visible = false;
            }

            previousSearchText = searchText;

        }
        //lblNoDataToDisplay.Visible = false;
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
            InitializeForm();
            btnSearch.Visible = true;
            btnCross.Visible = false;
            lblNoDataToDisplay.Visible = false;
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == initialText)
            {
                txtSearch.Clear();
            }
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlFormShow.Visible = false;
            pnlMessageAnnouncement.Visible = true;
        }

        private void txtMessage_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                lblMessageValidation.Text = "Please Enter Message.";
                lblMessageValidation.Visible = true;
                pbCross.Visible = true;
                pbTick.Visible = false;
                //txtEnglish.Focus();
            }
            else
            {
                pbCross.Visible = false;
                lblMessageValidation.Text = "";
                lblMessageValidation.Visible = false;
            }
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                lblMessageValidation.Text = "Please Enter Message.";
                lblMessageValidation.Visible = true;
                pbTick.Visible = false;
                pbCross.Visible = true;

            }
            else
            {
                lblMessageValidation.Visible = false;
                pbTick.Visible = true;
                pbCross.Visible = false;
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            openFileDialogs.Filter = "Media Files(*.wav; *.mp3)|*.wav;*.mp3";
            openFileDialogs.Multiselect = false;

            try
            {
                if (openFileDialogs.ShowDialog() == DialogResult.OK)
                {
                    lblFile.Text = "";
                    foreach (string file in openFileDialogs.FileNames)
                    {
                        string fileName = Path.GetFileName(file);
                        lblFile.Text += file;
                    }
                    lblShowingAudio.Visible = false;
                    pbTickFile.Visible = true;
                }
                else
                {
                    lblShowingAudio.Text = "Please choose an audio file.";
                    lblShowingAudio.Visible = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occurred while selecting the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int pKey_SpecialMessage = pkey;
            string Msg = txtMessage.Text;
            string audioFilePath = lblFile.Text;
            int language = Convert.ToInt32(cmbLanguage.SelectedValue);
            //MessageBox.Show("Selected Language Value: " + language);

            try
            {
                if (!string.IsNullOrWhiteSpace(Msg) &&
                    !string.IsNullOrWhiteSpace(audioFilePath))
                {
                    if (!File.Exists(audioFilePath) || !IsValidAudioFile(audioFilePath))
                    {
                        lblShowingAudio.Text = "Please choose an audio file.";
                        lblShowingAudio.Visible = true;
                        return;
                    }

                    bool b = sloganDb.InsertOrUpdateSlogan(pKey_SpecialMessage, Msg, audioFilePath, language);

                    if (b)
                    {
                        MessageBox.Show("Data saved successfully");
                        pnlFormShow.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("An error occurred while saving the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(Msg))
                    {
                        lblMessageValidation.Text = "Please Enter Message .";
                        lblMessageValidation.Visible = true;
                    }


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidAudioFile(string filePath)
        {
            string extension = Path.GetExtension(filePath);
            return !string.IsNullOrEmpty(extension) && (extension.Equals(".wav", StringComparison.OrdinalIgnoreCase) || extension.Equals(".mp3", StringComparison.OrdinalIgnoreCase));
        }

        private void lblFile_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(lblFile.Text) || !IsValidAudioFile(lblFile.Text))
                {
                    lblShowingAudio.Text = "Please choose an audio file.";
                    lblShowingAudio.Visible = true;

                }
                else
                {
                    lblShowingAudio.Visible = false;
                    pbTickFile.Visible = true;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


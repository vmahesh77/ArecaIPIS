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

namespace ArecaIPIS.Forms.ViewForms
{
   
    public partial class frmMessageScript : Form
    {
        messageScriptDb messagescriptDb = new messageScriptDb();
        public frmMessageScript()
        {
            InitializeComponent();
          

        }


        private frmHome parentForm;
        public frmMessageScript(frmHome parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            dgvMessageScriptTable.EnableHeadersVisualStyles = false;
            dgvMessageScriptTable.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;
            cmbPlatform.Enabled = true;
            pnlMessageAudioScript.Visible = false;
            pnlCreateMessageAudioScript.Visible = false;
            pbTick.Visible = false;
            pbCross.Visible = false;
            pbCrossMessagePath.Visible = false;
            pbTickMessagePath.Visible = false;
            pbTickStatusMessage.Visible = false;
            pbCrossStatusMessage.Visible = false;
            pbTickSequence.Visible = false;
            pbCrossSequence.Visible = false;
            pbTickPosition.Visible = false;
            pbCrossPosition.Visible = false;
        }

        private void frmMessageScript_Load(object sender, EventArgs e)
        {
            LoadMessageStatus();
            LoadTrainPosition();
            LoadLanguage();
        }

        //private void LoadMessageStatus()
        //{
        //    DataTable messagesTable = messagescriptDb.GetAllMessageStatus();
        //    //cmbMessages.Items.Clear();
        //    if (messagesTable.Columns.Count >= 2)
        //    {

        //        cmbMessages.DataSource = messagesTable;
        //        cmbMessages.DisplayMember = messagesTable.Columns[1].ColumnName;
        //    }
        //    else
        //    {
        //        MessageBox.Show("The table does not have a second column.");
        //    }
        //}


        private void LoadMessageStatus()
        {
            DataTable messagesTable = messagescriptDb.GetAllMessageStatus();

            if (messagesTable.Columns.Count >= 2)
            {
                DataRow selectRow = messagesTable.NewRow();
                selectRow[0] = 0;
                selectRow[1] = "-Select-";
                messagesTable.Rows.InsertAt(selectRow, 0);

                cmbMessages.DataSource = messagesTable;
                cmbStatusMessage.DataSource = messagesTable;
                cmbStatusMessage.DisplayMember = messagesTable.Columns[1].ColumnName;
                cmbMessages.DisplayMember = messagesTable.Columns[1].ColumnName;
                cmbMessages.ValueMember = messagesTable.Columns[0].ColumnName; 
            }
            else
            {
                MessageBox.Show("The table does not have a second column.");
            }
        }


        //private void LoadTrainPosition()
        //{
        //    DataTable trainPosition = messagescriptDb.GetAllTrainPosition();
        //    //cmbPlatform.Items.Clear();

        //    if (trainPosition.Columns.Count >= 1)
        //    {

        //        cmbPlatform.DataSource = trainPosition;
        //        cmbPlatform.DisplayMember = trainPosition.Columns[1].ColumnName;
        //    }
        //    else
        //    {
        //        MessageBox.Show("The table does not have a second column.");
        //    }
        //}


        private void LoadTrainPosition()
        {
            DataTable trainPosition = messagescriptDb.GetAllTrainPosition();

            if (trainPosition.Columns.Count >= 1)
            {
                DataRow selectRow = trainPosition.NewRow();
                selectRow[0] = 0;
                selectRow[1] = "-Select-";

                trainPosition.Rows.InsertAt(selectRow, 0);

                cmbPlatform.DataSource = trainPosition;
                cmbPlatform.DisplayMember = trainPosition.Columns[1].ColumnName;


                cmbPosition.DataSource = trainPosition;
                cmbPosition.DisplayMember = trainPosition.Columns[1].ColumnName;
                //cmbPlatform.ValueMember = trainPosition.Columns[0].ColumnName;
            }
            else
            {
                MessageBox.Show("The table does not have a second column.");
            }
        }


        //private void LoadLanguage()
        //{
        //    DataTable Languge = messagescriptDb.GetLanguage();
        //    cmbTrainLanguage.Items.Clear();

        //    if (Languge.Columns.Count >= 1)
        //    {
        //        DataRow selectRow = Languge.NewRow();
        //        selectRow[0] = 0;
        //        selectRow[1] = "-Select-";

        //        Languge.Rows.InsertAt(selectRow, 0);

        //        cmbTrainLanguage.DataSource = Languge;
        //        cmbTrainLanguage.DisplayMember = Languge.Columns[2].ColumnName;
        //        cmbTrainLanguage.ValueMember = Languge.Columns[2].ColumnName;
        //    }
        //    else
        //    {
        //        MessageBox.Show("The table does not have a second column.");
        //    }
        //}

        private void LoadLanguage()
        {
            DataTable Languge = messagescriptDb.GetLanguage();
            cmbTrainLanguage.Items.Clear();

            if (Languge.Columns.Count >= 2)
            {
                cmbTrainLanguage.Items.Add("-Select-");
                cmbLanguageName.Items.Add("-Select-");
                foreach (DataRow row in Languge.Rows)
                {
                  
                    cmbTrainLanguage.Items.Add($"{row[2]}");
                    cmbLanguageName.Items.Add($"{row[2]}");
                }

                cmbTrainLanguage.SelectedIndex = 1; 
            }
            else
            {
                MessageBox.Show("The table does not have at least two columns.");
            }
        }


        private void cmbMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbMessages.SelectedItem != null && cmbMessages.SelectedIndex== 5)
            //{
            //    cmbPlatform.Enabled = true;
            //}
            //else
            //{
            //    cmbPlatform.Enabled = false;

            //}

            if (cmbMessages.SelectedIndex >= 0 && cmbMessages.SelectedIndex <= 4)
            {
                cmbPlatform.Enabled = false;
                //cmbPlatform.SelectedIndex = 0;
            }
            else if (cmbMessages.SelectedIndex == 5)
            {
                cmbPlatform.Enabled = true;
                cmbPlatform.SelectedIndex = 0;
            }
        }

        int pagesize = 7;
        private void btnView_Click(object sender, EventArgs e)
        {
            int selectedStatus = cmbMessages.SelectedIndex;
            int selectedLanguage = cmbTrainLanguage.SelectedIndex;
            int selectedPosition = cmbPlatform.SelectedIndex;
            showData(1, pagesize, selectedStatus, selectedLanguage, selectedPosition);
            lblNoDataToDisplay.Visible = false;
        }


        public void showData(int pageIndex, int pagesize, int selectedStatus, int selectedLanguage,int selectedPosition)
        {


            (DataTable messsageFormat, int recordCount) = messagescriptDb.GetMessageFormat(pageIndex, pagesize, selectedStatus, selectedLanguage, selectedPosition);

            if (messsageFormat != null)
            {

                dgvMessageScriptTable.DataSource = messsageFormat;

                dgvMessageScriptTable.Columns["MessagePath"].DataPropertyName = "MessagePath";
                dgvMessageScriptTable.Columns["MessageName"].DataPropertyName = "MessageName";
                dgvMessageScriptTable.Columns["Sequence"].DataPropertyName = "sequence";

                if (!dgvMessageScriptTable.Columns.Contains("Pkey_MessageFormat"))
                {
                    DataGridViewTextBoxColumn pkeyColumn = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Pkey_MessageFormat",
                        HeaderText = "Pkey_MessageFormat",
                        Name = "Pkey_MessageFormat",
                        Visible = false
                    };
                    dgvMessageScriptTable.Columns.Add(pkeyColumn);
                }
                else
                {
                    dgvMessageScriptTable.Columns["Pkey_MessageFormat"].DataPropertyName = "Pkey_MessageFormat";
                    dgvMessageScriptTable.Columns["Pkey_MessageFormat"].Visible = false;
                }

                //dgvAddStation.AllowUserToResizeRows = false;
                //int totalHeight = dgvAddStation.ColumnHeadersHeight;
                //foreach (DataGridViewRow row in dgvAddStation.Rows)
                //{
                //    totalHeight += row.Height;
                //}

                //dgvAddStation.Height = totalHeight;

                PaginationClass pagination = new PaginationClass();
                pagination.Populate(recordCount, pageIndex, pagesize, pnlPagination, this, (PageIndex, size) => showData(PageIndex, size, selectedStatus, selectedLanguage, selectedPosition));

            }

            else
            {

                MessageBox.Show("Failed to retrieve Coach Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAddMessage_Click(object sender, EventArgs e)
        {
            pnlMessageAudioScript.Visible = true;
            pnlCreateMessageAudioScript.Visible = true;
            lblCreateMessageAudioScript.Text = "Create New Message Audio Script";
            btnSave.Text = "    Save";
            cmbLanguageName.Text = "";
            lblNoFileChosen.Text = "";
            cmbMessageName.Text = "";
            nupSequence.Text = "";
            cmbStatusMessage.Text = "";
            cmbPosition.Text = "";
        }
        int pkey;
        private void dgvMessageScriptTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                try
                {
                    int pkeyValue = Convert.ToInt32(dgvMessageScriptTable.Rows[e.RowIndex].Cells["Pkey_MessageFormat"].Value);
                    DataTable Message = messagescriptDb.GetMessageFormatByRow(pkeyValue);

                    if (Message != null && Message.Rows.Count > 0)
                    {
                        pkey = pkeyValue;


                        string Language = Message.Rows[0]["LanguageId"].ToString();
                        string MessagePath = Message.Rows[0]["MessagePath"].ToString();
                        string MessageName = Message.Rows[0]["MessageName"].ToString();
                        string Sequence = Message.Rows[0]["sequence"].ToString();
                        string position = Message.Rows[0]["PfStatus"].ToString();
                        string StatusMessage = Message.Rows[0]["StatusMessage"].ToString();

                        pnlMessageAudioScript.Visible = true;
                        pnlCreateMessageAudioScript.Visible = true;
                        lblCreateMessageAudioScript.Text = "Edit New Message Audio Script";
                        btnSave.Text = "    Update";


                        int languageIndex = int.Parse(Language);
                        if (languageIndex >= 0 && languageIndex < cmbLanguageName.Items.Count)
                        {
                            cmbLanguageName.SelectedIndex = languageIndex;
                            cmbLanguageName.Text = cmbLanguageName.SelectedItem.ToString();
                        }

                        int StatusMessageIndex = int.Parse(StatusMessage);
                        if (StatusMessageIndex >= 0 && StatusMessageIndex < cmbStatusMessage.Items.Count)
                        {
                            cmbStatusMessage.SelectedIndex = StatusMessageIndex;
                            //cmbStatusMessage.Text = cmbStatusMessage.SelectedItem.ToString();

                            object selectedItem = cmbStatusMessage.SelectedItem;
                            if (selectedItem != null)
                            {
                                string displayedText = ((DataRowView)selectedItem).Row[1].ToString();
                                cmbStatusMessage.Text = displayedText;
                            }
                        }

                        lblNoFileChosen.Text = MessagePath;
                        cmbMessageName.Text=MessageName;
                        nupSequence.Text = Sequence;
                        cmbPosition.Text = position;                       
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlMessageAudioScript.Visible = false;
            pnlCreateMessageAudioScript.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int LanguageId = cmbLanguageName.SelectedIndex;
            string messagePath = lblNoFileChosen.Text;
            string MessageName = cmbMessageName.Text;
            decimal sequence = nupSequence.Value;
            int selectedstatus = cmbStatusMessage.SelectedIndex;
            int position = cmbPosition.SelectedIndex;


            try
            {
                if (!string.IsNullOrWhiteSpace(messagePath) &&
                    !string.IsNullOrWhiteSpace(MessageName))
                {
                    int pk = pkey;


                    bool b = messagescriptDb.InsertOrUpdateMessageScript(pk, LanguageId, messagePath, MessageName, sequence, selectedstatus, position);

                    if (b)
                    {
                        MessageBox.Show("Data saved successfully");
                        pnlMessageAudioScript.Visible = false;
                        pnlCreateMessageAudioScript.Visible = false;
                        cmbLanguageName.Text = "";
                        lblNoFileChosen.Text = "";
                        cmbMessageName.Text = "";
                        nupSequence.Text = "";
                        cmbStatusMessage.Text = "";
                        cmbPosition.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("An error occurred while saving the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(messagePath))
                    {

                       pbCrossMessagePath.Visible = true;
                    }
                    if (string.IsNullOrWhiteSpace(MessageName))
                    {

                        pbCross.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Choose Audio File";
            openFileDialog.Filter = "Audio Files|*.wav;*.mp3;*.ogg|All Files|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog.Multiselect = false;

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                lblNoFileChosen.Text = filePath;
            }
        }




    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArecaIPIS.DAL;
using NAudio.Wave;
using System.Collections.Concurrent;
using System.IO;
namespace ArecaIPIS.Forms
{
    public partial class frmMessages : Form
    {
        private static List<CancellationTokenSource> cancellationTokenSources = new List<CancellationTokenSource>();
        private PaginationHelperClass paginationHelper;
        private DataTable reportData;
        private static SoundPlayer player;

   
        private string initialText;
        MessagesDb messagesDb = new MessagesDb();
        private frmHome parentForm;

        public frmMessages(frmHome parentForm) : this()
        {
            this.parentForm = parentForm;

        }
        public frmMessages()
        {
            InitializeComponent();

            dgvMessages.EnableHeadersVisualStyles = false;
            dgvMessages.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
            dgvMessages.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvMessages.AllowUserToResizeRows = false;

            foreach (DataGridViewColumn column in dgvMessages.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            cmbPlatformNo.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            cmbPosition.SelectedIndex = 0;


            btnCross.Visible = false;



            toolTip.SetToolTip(btnAddMessage, "Add New Message");
            toolTip.SetToolTip(btnSendMessage, "Send Selected Messages");
            toolTip.SetToolTip(btnPlay, "Play");
            toolTip.SetToolTip(btnStop, "Stop");
            toolTip.SetToolTip(btnPause, "Pause");
            toolTip.SetToolTip(btnPlaySpecial, "Play");
            toolTip.SetToolTip(btnStopSpecial, "Stop");
            toolTip.SetToolTip(btnPauseSpecial, "Pause");

            dgvMessages.CellToolTipTextNeeded += new DataGridViewCellToolTipTextNeededEventHandler(dGVMessages_CellToolTipTextNeeded);
            initialText = txtSearch.Text;
            lblNoDataToDisplay.Visible = false;
            pnlShowForm.Visible = true;



            pnlCreateMessage.Visible = false;
            lblShowingAudio.Visible = false;
            pbCross.Visible = false;
            pbTick.Visible = false;
            pbCrossHindi.Visible = false;
            pbTickHindi.Visible = false;
            pbCrossRegional.Visible = false;
            pbTickRegional.Visible = false;
            pbTickFile.Visible = false;


            reportData = new DataTable();

        }

        private void dGVMessages_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                if (dgvMessages.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    e.ToolTipText = "Edit";
                }
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                if (dgvMessages.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {
                    e.ToolTipText = "Select";
                }
            }
        }



        private void btnAddMessage_Click(object sender, EventArgs e)
        {

            pnlCreateMessage.Visible = true;
            pnlShowForm.Visible = false;

            txtEnglish.Text = "";
            txtHindi.Text = "";
            txtRegional.Text = "";
            lblFile.Text = "No file chosen";
            lblShowingAudio.Visible = false;
            lblFile.Visible = true;
            pbCross.Visible = false;
            pbTick.Visible = false;
            pbCrossHindi.Visible = false;
            pbTickHindi.Visible = false;
            pbCrossRegional.Visible = false;
            pbTickRegional.Visible = false;
            pbTickFile.Visible = false;
            lblValidationEnglish.Visible = false;
            lblValidationHindi.Visible = false;
            lblValidationRegional.Visible = false;
            lblShowingAudio.Visible = false;
            lblCreateMessage.Text = "Create Message";
            btnSave.Text = "    Save";

        }


        int pkey;
        private void dGVMessages_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                try
                {
                    int pkeyValue = Convert.ToInt32(dgvMessages.Rows[e.RowIndex].Cells["Pkey_SpclMessages"].Value);
                    DataTable Message = messagesDb.GetMessagesByRow(pkeyValue);

                    if (Message != null && Message.Rows.Count > 0)
                    {
                        pkey = pkeyValue;
                        string englishMessage = Message.Rows[0]["Englishmsg"].ToString();
                        string nationalMessage = Message.Rows[0]["NationalMsg"].ToString();
                        string regionalMessage = Message.Rows[0]["RegionalMSg1"].ToString();
                        string file = Message.Rows[0]["AudioFilePath"].ToString();



                        pnlCreateMessage.Visible = true;
                        lblCreateMessage.Text = "Edit Message";
                        btnSave.Text = "    Update";
                        txtEnglish.Text = englishMessage;
                        txtHindi.Text = nationalMessage;
                        txtRegional.Text = regionalMessage;
                        lblFile.Text = file;
                        pnlShowForm.Visible = false;
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


        private void UpdateDataGridView()
        {
            DataTable currentPageData = paginationHelper.GetCurrentPageData();

            dgvMessages.AutoGenerateColumns = false;

            dgvMessages.Columns["English"].DataPropertyName = "Englishmsg";
            dgvMessages.Columns["Hindi"].DataPropertyName = "NationalMsg";
            dgvMessages.Columns["RegionalLanguage"].DataPropertyName = "RegionalMsg1";

            if (!dgvMessages.Columns.Contains("Pkey_SpclMessages"))
            {
                DataGridViewTextBoxColumn pkeyColumn = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Pkey_SpclMessages",
                    HeaderText = "Pkey_SpclMessages",
                    Name = "Pkey_SpclMessages",
                    Visible = false
                };
                dgvMessages.Columns.Add(pkeyColumn);
            }
            else
            {
                dgvMessages.Columns["Pkey_SpclMessages"].DataPropertyName = "Pkey_SpclMessages";
                dgvMessages.Columns["Pkey_SpclMessages"].Visible = false;
            }

            dgvMessages.DataSource = currentPageData;

            dgvMessages.Columns["English"].Width = 370;
            dgvMessages.Columns["Hindi"].Width = 370;
            dgvMessages.Columns["RegionalLanguage"].Width = 370;

            dgvMessages.AllowUserToAddRows = false;

            paginationHelper.UpdatePaginationControls(pnlPagination, OnPageChanged);


        }
        private void OnPageChanged(int page)
        {
            paginationHelper.LoadDataForPage(page);
            UpdateDataGridView();

        }


        private void frmMessages_Load(object sender, EventArgs e)
        {

            dgvMessages.RowTemplate.Height = 30;
            showData();
        }



        public void showData()
        {
            try
            {
                DataTable specialMessages = messagesDb.GetSpecialMessagesData();

                if (specialMessages != null && specialMessages.Rows.Count > 0)
                {
                    dgvMessages.AutoGenerateColumns = true;
                    reportData.Clear();
                    reportData.Columns.Clear();


                    reportData = specialMessages.Copy();

                    paginationHelper = new PaginationHelperClass(reportData, 8);
                    UpdateDataGridView();

                    lblNoDataToDisplay.Visible = false;
                    pnlPagination.Visible = true;
                }
                else
                {
                    dgvMessages.Columns.Clear();

                    dgvMessages.AutoGenerateColumns = false;

                    reportData = specialMessages.Copy();

                    DataGridViewTextBoxColumn englishColumn = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Englishmsg",
                        HeaderText = "English",
                        Name = "English",
                        Width = 370
                    };
                    dgvMessages.Columns.Add(englishColumn);

                    DataGridViewTextBoxColumn hindiColumn = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "NationalMsg",
                        HeaderText = "Hindi",
                        Name = "Hindi",
                        Width = 370
                    };
                    dgvMessages.Columns.Add(hindiColumn);

                    DataGridViewTextBoxColumn regionalColumn = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "RegionalMsg1",
                        HeaderText = "Regional Language",
                        Name = "RegionalLanguage",
                        Width = 370
                    };
                    dgvMessages.Columns.Add(regionalColumn);


                    if (!dgvMessages.Columns.Contains("Pkey_SpclMessages"))
                    {
                        DataGridViewTextBoxColumn pkeyColumn = new DataGridViewTextBoxColumn
                        {
                            DataPropertyName = "Pkey_SpclMessages",
                            HeaderText = "Pkey_SpclMessages",
                            Name = "Pkey_SpclMessages",
                            Visible = false
                        };
                        dgvMessages.Columns.Add(pkeyColumn);
                    }
                    else
                    {

                        dgvMessages.Columns["Pkey_SpclMessages"].DataPropertyName = "Pkey_SpclMessages";
                        dgvMessages.Columns["Pkey_SpclMessages"].Visible = false;
                    }


                    dgvMessages.DataSource = reportData;


                    dgvMessages.AllowUserToAddRows = false;


                    if (reportData == null || reportData.Rows.Count == 0)
                    {
                        lblNoDataToDisplay.Visible = true;
                    }


                }
                chkFilter.Items.Clear();
                int c = 0;
                foreach (DataColumn column in reportData.Columns)
                {

                    if (c > 0)
                    {
                        chkFilter.Items.Add(column.ColumnName);
                    }

                    c++;
                }

                for (int i = 0; i < chkFilter.Items.Count; i++)
                {
                    chkFilter.SetItemChecked(i, true);
                    chkFilter.BackColor = Color.LightSalmon;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool chkvisible = true;
        private void btndropdown_Click(object sender, EventArgs e)
        {
            if (chkvisible)
            {
                chkFilter.Visible = true;
                chkvisible = false;
            }
            else
            {
                chkFilter.Visible = false;
                chkvisible = true;
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnCross.Visible = true;
            btnSearch.Visible = false;
        }

        private void btnCross_Click(object sender, EventArgs e)
        {
            txtSearch.Text = initialText;
            //showData();


            paginationHelper = new PaginationHelperClass(reportData, 8);
            UpdateDataGridView();
            btnSearch.Visible = true;
            btnCross.Visible = false;

            lblNoDataToDisplay.Visible = false;

        }

        private List<string> selectedColumns = new List<string>();
        private void PerformSearchAndFilter(string searchText)
        {

            DataTable filteredDataTable = reportData.Clone();

            string searchLowerCase = searchText.ToLower();

            foreach (DataRow row in reportData.Rows)
            {
                bool matchFound = false;

                foreach (string column in selectedColumns)
                {
                    string cellValue = row[column].ToString().ToLower();

                    if (cellValue.Contains(searchLowerCase))
                    {
                        matchFound = true;
                        break;
                    }
                }

                if (matchFound)
                {
                    filteredDataTable.ImportRow(row);

                }
            }
            paginationHelper = new PaginationHelperClass(filteredDataTable, 9);
            UpdateDataGridView();

        }


        private string previousSearchText = string.Empty;
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            string searchText = txtSearch.Text.Trim();
            selectedColumns.Clear();

            foreach (var item in chkFilter.CheckedItems)
            {
                string columnName = item.ToString();

                if (!selectedColumns.Contains(columnName))
                {
                    selectedColumns.Add(columnName);
                }
            }

            if (searchText != previousSearchText)
            {
                PerformSearchAndFilter(searchText);
                previousSearchText = searchText;
            }


            bool matchFound = CheckIfDataMatchesSearch();
            lblNoDataToDisplay.Visible = !matchFound;


            btnCross.Visible = true;
            btnSearch.Visible = false;



            bool CheckIfDataMatchesSearch()
            {
                if (string.IsNullOrWhiteSpace(searchText))
                {
                    return true;
                }

                searchText = searchText.ToLower();

                foreach (DataRow row in reportData.Rows)
                {
                    foreach (string column in selectedColumns)
                    {
                        string cellValue = row[column].ToString().ToLower();

                        if (cellValue.Contains(searchText))
                        {
                            return true;
                        }
                    }
                }

                return false;
            }

        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == initialText)
            {
                txtSearch.Clear();
            }
        }

        private void txtTrainNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {

                e.Handled = true;
            }
        }

        private void txtTrainNo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTrainNo.Text))
            {
                lblValidateTrainNo.Text = "Enter a train number.";
                lblValidateTrainNo.Visible = true;
                txtTrainNo.Focus();
            }
            else
            {
                lblValidateTrainNo.Text = "";
                lblValidateTrainNo.Visible = false;
            }
        }

        private void dGVMessages_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                if (dgvMessages.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.Value == null)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                    e.Graphics.DrawImage(Properties.Resources.edit, e.CellBounds.Location);
                    e.Handled = true;
                }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlCreateMessage.Visible = false;
            pnlShowForm.Visible = true;
            txtEnglish.Text = "";
            txtHindi.Text = "";
            txtRegional.Text = "";
            lblFile.Text = "No file chosen";

        }

        private void txtEnglish_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEnglish.Text))
            {
                lblValidationEnglish.Text = "Please Enter Message in English.";
                lblValidationEnglish.Visible = true;
                pbCross.Visible = true;
                pbTick.Visible = false;
              
            }
            else
            {
                pbCross.Visible = false;
                lblValidationEnglish.Text = "";
                lblValidationEnglish.Visible = false;
            }
        }

        private void txtEnglish_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEnglish.Text))
            {
                lblValidationEnglish.Text = "Please Enter Message in English.";
                lblValidationEnglish.Visible = true;
                pbTick.Visible = false;
                pbCross.Visible = true;

            }
            else
            {
                lblValidationEnglish.Visible = false;
                pbTick.Visible = true;
                pbCross.Visible = false;
            }
        }


        private void txtHindi_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHindi.Text))
            {
                lblValidationHindi.Text = "Please Enter Message in Hindi.";
                lblValidationHindi.Visible = true;
                pbTickHindi.Visible = false;
                pbCrossHindi.Visible = true;

            }
            else
            {
                lblValidationHindi.Visible = false;
                pbTickHindi.Visible = true;
                pbCross.Visible = false;
            }
        }

        private void txtHindi_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHindi.Text))
            {
                lblValidationHindi.Text = "Please Enter Message in Hindi.";
                lblValidationHindi.Visible = true;
                pbCrossHindi.Visible = true;
                pbTickHindi.Visible = false;

            }
            else
            {
                pbCrossHindi.Visible = false;
                lblValidationHindi.Text = "";
                lblValidationHindi.Visible = false;
            }
        }

        private void txtRegional_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegional.Text))
            {
                lblValidationRegional.Text = "Please Enter Message in Regional Language.";
                lblValidationRegional.Visible = true;
                pbCrossRegional.Visible = true;
                pbTickRegional.Visible = false;

            }
            else
            {
                pbCrossRegional.Visible = false;
                lblValidationRegional.Text = "";
                lblValidationRegional.Visible = false;
            }
        }

        private void txtRegional_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRegional.Text))
            {
                lblValidationRegional.Text = "Please Enter Message in Regional Language.";
                lblValidationRegional.Visible = true;
                pbTickRegional.Visible = false;
                pbCrossRegional.Visible = true;

            }
            else
            {
                lblValidationRegional.Visible = false;
                pbTickRegional.Visible = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int pKey_SpecialMessage = pkey;
            string englishMsg = txtEnglish.Text;
            string nationalMsg = txtHindi.Text;
            string regionalMsg1 = txtRegional.Text;
            string regionalMsg2 = txtEnglish.Text;
            string audioFilePath = lblFile.Text;

            try
            {
                if (!string.IsNullOrWhiteSpace(englishMsg) &&
                    !string.IsNullOrWhiteSpace(nationalMsg) &&
                    !string.IsNullOrWhiteSpace(regionalMsg1) &&
                    !string.IsNullOrWhiteSpace(audioFilePath))
                {
                    if (!File.Exists(audioFilePath) || !IsValidAudioFile(audioFilePath))
                    {
                        lblShowingAudio.Text = "Please choose an audio file.";
                        lblShowingAudio.Visible = true;
                        return;
                    }

                    bool b = messagesDb.InsertOrUpdateMessage(pKey_SpecialMessage, englishMsg, nationalMsg, regionalMsg1, regionalMsg2, audioFilePath);

                    if (b)
                    {
                        MessageBox.Show("Data saved successfully");
                        pnlCreateMessage.Visible = false;
                        pnlShowForm.Visible = true;
                        txtEnglish.Text = "";
                        txtHindi.Text = "";
                        txtRegional.Text = "";
                        lblFile.Text = "No file chosen";
                    }
                    else
                    {
                        MessageBox.Show("An error occurred while saving the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(englishMsg))
                    {
                        lblValidationEnglish.Text = "Please Enter Message in English.";
                        lblValidationEnglish.Visible = true;
                        pbCross.Visible = true;
                    }
                    if (string.IsNullOrWhiteSpace(nationalMsg))
                    {
                        lblValidationHindi.Text = "Please Enter Message in Hindi.";
                        lblValidationHindi.Visible = true;
                        pbCrossHindi.Visible = true;
                    }
                    if (string.IsNullOrWhiteSpace(regionalMsg1))
                    {
                        lblValidationRegional.Text = "Please Enter Message in Regional Language.";
                        lblValidationRegional.Visible = true;
                        pbCrossRegional.Visible = true;
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


      
        private static List<SoundPlayer> soundPlayers = new List<SoundPlayer>();
        private static List<Task> tasks = new List<Task>();
       
       public static List<string> AudioPaths = new List<string>();

        private ConcurrentDictionary<string, WaveOutEvent> PausePlayers = new ConcurrentDictionary<string, WaveOutEvent>();

        private static ConcurrentDictionary<string, WaveOutEvent> activePlayers = new ConcurrentDictionary<string, WaveOutEvent>();
        private ConcurrentDictionary<string, AudioFileReader> activeAudioFiles = new ConcurrentDictionary<string, AudioFileReader>();
        // private CancellationTokenSource cts;
        //  private bool isPaused = false;

        private ConcurrentDictionary<string, TaskCompletionSource<bool>> pauseCompletionSources = new ConcurrentDictionary<string, TaskCompletionSource<bool>>();
        private HashSet<string> completedAudioFiles = new HashSet<string>();
        private ManualResetEventSlim pauseEvent = new ManualResetEventSlim(true);

        private static bool pauseStatus = false;
        private static bool isPaused = false;
        private int totalAudios;
        private List<string> GetIncompleteAudioFiles()
        {
            List<string> incompleteFiles = new List<string>();
            foreach (var filePath in audioPaths)
            {
                if (!IsAudioCompleted(filePath))
                {
                    incompleteFiles.Add(filePath);
                }
            }

            return incompleteFiles;
        }
        private bool IsAudioCompleted(string filePath)
        {
            return completedAudioFiles.Contains(filePath);
        }
        private List<string> audioPaths = new List<string>();
        private static CancellationTokenSource cts = new CancellationTokenSource();
        private static object lockObj = new object();
        public static TaskCompletionSource<bool> pauseCompletionSource = new TaskCompletionSource<bool>();
        public static int audioCountPause = 0;
        public static CancellationToken PausecancellationToken;
        //----------------------------code start here-----------------------------------------    


        private async void btnPlay_Click(object sender, EventArgs e)
        {
            try
            {
                btnPause.Text = "Pause";
                int nupMessageValue = (int)nupMessage.Value;
                List<string> selectedPrimaryKeys = new List<string>();

                foreach (DataGridViewRow row in dgvMessages.Rows)
                {
                    DataGridViewCheckBoxCell chk = row.Cells[1] as DataGridViewCheckBoxCell;

                    if (chk != null && Convert.ToBoolean(chk.Value))
                    {
                        string primaryKey = row.Cells["Pkey_SpclMessages"].Value.ToString();
                        selectedPrimaryKeys.Add(primaryKey);
                    }
                }

                if (selectedPrimaryKeys.Count == 0)
                {
                    MessageBox.Show("No items selected to play.");
                    return;
                }

                string primaryKeyString = string.Join(",", selectedPrimaryKeys);
                DataTable resultMessage = messagesDb.CallGetSplMessages1(primaryKeyString, nupMessageValue);

                if (resultMessage != null && resultMessage.Rows.Count > 0)
                {
                    audioPaths.Clear();
                    foreach (DataRow row in resultMessage.Rows)
                    {
                        foreach (DataColumn col in resultMessage.Columns)
                        {
                            if (col.DataType == typeof(string))
                            {
                                string stringValue = row.Field<string>(col);
                                audioPaths.Add(stringValue);
                            }
                        }
                    }

                    cts = new CancellationTokenSource();
                    await PlayAudioSet(audioPaths, nupMessageValue, cts.Token);
                }
                else
                {
                    MessageBox.Show("No data returned from the database");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        public async Task PlayAudioSet(List<string> audioPaths, int playCount, CancellationToken token)
        {
            try
            {
                int completedAudios = 0;
                for (int count = 0; count < playCount; count++)
                {
                    foreach (string filePath in audioPaths)
                    {
                        token.ThrowIfCancellationRequested();

                        if (File.Exists(filePath))
                        {
                            await PlaySingleAudio(filePath, token);
                            completedAudios++;
                        }
                        else
                        {
                            HandleAudioErrors(filePath);
                        }
                    }
                    await Task.Delay(100, token);
                }

                if (completedAudios == audioPaths.Count * playCount)
                {
                    UpdateAudioPlayStatus("Completed");
                }
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing audio set: {ex.Message}");
            }
        }

        public async Task PlaySingleAudio(string filePath, CancellationToken token)
        {
            try
            {
                using (var audioFile = new AudioFileReader(filePath))
                {
                    var player = new WaveOutEvent();
                    activePlayers[filePath] = player;

                    player.Init(audioFile);
                    player.Play();

                    while (player.PlaybackState == PlaybackState.Playing)
                    {
                        await Task.Delay(100, token);
                        if (isPaused)
                        {
                            await pauseCompletionSource.Task;
                        }
                        token.ThrowIfCancellationRequested();
                    }
                    player.PlaybackStopped += (sender, args) =>
                    {
                        activePlayers.TryRemove(filePath, out _);
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing audio from '{filePath}': {ex.Message}");
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (isPaused)
            {
                ResumeAllAudio();
            }
            else
            {
                PauseAllAudio();
            }
        }

        public void PauseAllAudio()
        {
            isPaused = true;
            foreach (var player in activePlayers.Values)
            {
                if (player.PlaybackState == PlaybackState.Playing)
                {
                    player.Pause();
                }
            }
            pauseCompletionSource = new TaskCompletionSource<bool>();
            if (btnPause != null)
            {
                btnPause.Text = "Resume";
            }
        }

        public void ResumeAllAudio()
        {
            isPaused = false;
            foreach (var player in activePlayers.Values)
            {
                if (player.PlaybackState == PlaybackState.Paused)
                {
                    player.Play();
                }
            }
            pauseCompletionSource.SetResult(true);
            if (btnPause != null)
            {
                btnPause.Text = "Pause";
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopAllAudio();
            UpdateAudioPlayStatus("Completed");
        }

        public void StopAllAudio()
        {
            if (cts != null)
            {
                cts.Cancel();
            }

            foreach (var player in activePlayers.Values)
            {
                player.Stop();
            }
            activePlayers.Clear();
        }

        private static void HandleAudioErrors(string filePath)
        {
            MessageBox.Show($"Error with audio file '{filePath}'", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        //-----------------------code end here------------------------------------------------

        private void UpdateAudioPlayStatus(string action)
        {
            try
            {
                bool successAction = messagesDb.UpdateAudioPlayStatus(action);

                if (successAction)
                {
                    //MessageBox.Show("Audio play status updated successfully.");
             
                }
                else
                {
                    MessageBox.Show("No rows affected. Audio play status may not have been updated.");
                 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating audio play status: {ex.Message}");
            }
        }

     

 

        public void UpdateStatus(string action)
        {
            try
            {
                DataTable status = messagesDb.getUpdatedStatus(action);

                if (status != null && status.Rows.Count > 0)
                {
                    string alertValue = status.Rows[0]["ALERT"].ToString();

                    if (alertValue == "PAUSE")
                    {
                        //PauseAudio();
                    }
                    else if (alertValue == "STOP")
                    {
                        StopAllAudio();
                    }
                    else if (alertValue == "INSERTED")
                    {
                        MessageBox.Show("Handling action: " + alertValue);
                       
                    }
                    else
                    {
                        MessageBox.Show("Unknown action: " + alertValue);
                    }
                }
                else
                {
                    MessageBox.Show("No data returned from database for action: " + action);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

    
    }
}



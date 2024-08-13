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
    public partial class frmRegionalLanguageStatus : Form
    {
        private string initialText;
        regionalLanguageStatusDb regionallanguageStatusDb = new regionalLanguageStatusDb();
        public frmRegionalLanguageStatus()
        {
            InitializeComponent();

        }
        private frmHome parentForm;
        public frmRegionalLanguageStatus(frmHome parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            dgvLanguageSettingsTable.EnableHeadersVisualStyles = false;
            dgvLanguageSettingsTable.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;
            lblEnglishCoach.Visible = false;
            lblHindiCoach.Visible = false;
            lblRegionalName.Visible = false;
            pbCross.Visible = false;
            pbTick.Visible = false;
            pbCrossHindi.Visible = false;
            pbTickHindi.Visible = false;
            pbCrossRegional.Visible = false;
            pbTickBitmap.Visible = false;
            initialText = txtSearch.Text;
            lblNoDataToDisplay.Visible = false;
            pnlCreateLanguageStatus.Visible = false;
            pnlCreateCoach.Visible = false;
        }
        int pagesize =7;
        private void frmRegionalLanguageStatus_Load(object sender, EventArgs e)
        {
            dgvLanguageSettingsTable.RowTemplate.Height = 36;
            showData(1, pagesize);
            btnDropdown.Visible = false;
        }

        public void showData(int pageIndex, int pagesize)
        {
            (DataTable regionalLanguageStatus, int recordCount) = regionallanguageStatusDb.GetRegionalLanguageStatus(pageIndex, pagesize);

            if (regionalLanguageStatus != null)
            {

                dgvLanguageSettingsTable.DataSource = regionalLanguageStatus;
                //dgvAddStation.Columns["StationCode"].HeaderText = "Station Code";
                //dgvAddStation.Columns["stationeng"].HeaderText = "English";
                //dgvAddStation.Columns["stationhind"].HeaderText = "Hindi";
                //dgvAddStation.Columns["stationreg1"].HeaderText = "Regional";

                dgvLanguageSettingsTable.Columns["English"].DataPropertyName = "StatusName";
                dgvLanguageSettingsTable.Columns["Hindi"].DataPropertyName = "HStatus";
                dgvLanguageSettingsTable.Columns["RegionalLanguage"].DataPropertyName = "RStatus";

                if (!dgvLanguageSettingsTable.Columns.Contains("Pkey_Status"))
                {
                    DataGridViewTextBoxColumn pkeyColumn = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Pkey_Status",
                        HeaderText = "Pkey_Status",
                        Name = "Pkey_Status",
                        Visible = false
                    };
                    dgvLanguageSettingsTable.Columns.Add(pkeyColumn);
                }
                else
                {
                    dgvLanguageSettingsTable.Columns["Pkey_Status"].DataPropertyName = "Pkey_Status";
                    dgvLanguageSettingsTable.Columns["Pkey_Status"].Visible = false;
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

                MessageBox.Show("Failed to retrieve Regional Language Status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        int pkey;
        private void dgvLanguageSettingsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                try
                {
                    int pkeyValue = Convert.ToInt32(dgvLanguageSettingsTable.Rows[e.RowIndex].Cells["Pkey_Status"].Value);
                    DataTable Message = regionallanguageStatusDb.GetLanguageStatusByRow(pkeyValue);

                    if (Message != null && Message.Rows.Count > 0)
                    {
                        pkey = pkeyValue;
                        string english = Message.Rows[0]["StatusName"].ToString();
                        string Hindi = Message.Rows[0]["HStatus"].ToString();
                        string RLanguage = Message.Rows[0]["RStatus"].ToString();

                        pnlCreateLanguageStatus.Visible = true;
                        pnlCreateCoach.Visible = true;
                        //lblCreateCoach.Text = "Edit Coach Data";
                        //btnSave.Text = "    Update";
                        txtEnglish.Text = english;
                        txtHindi.Text = Hindi;
                        txtRLanguage.Text = RLanguage;

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
            pnlCreateLanguageStatus.Visible = false;
            pnlCreateCoach.Visible = false;
            txtEnglish.Text = "";
            txtHindi.Text = "";
            txtRLanguage.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string english = txtEnglish.Text;
            string Hindi = txtHindi.Text;
            string RLanguage = txtRLanguage.Text;

            try
            {
                if (!string.IsNullOrWhiteSpace(english) &&
                    !string.IsNullOrWhiteSpace(Hindi) &&
                    !string.IsNullOrWhiteSpace(RLanguage))
                {
                    //int pk = pkey;


                    bool b = regionallanguageStatusDb.InsertOrUpdateMessage(english, Hindi, RLanguage);

                    if (b)
                    {
                        MessageBox.Show("Data saved successfully");
                        pnlCreateLanguageStatus.Visible = false;
                        pnlCreateCoach.Visible = false;
                        txtEnglish.Text = "";
                        txtHindi.Text = "";
                        txtRLanguage.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("An error occurred while saving the data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(english))
                    {
                        lblEnglishCoach.Visible = true;
                        pbCross.Visible = true;
                    }
                    if (string.IsNullOrWhiteSpace(Hindi))
                    {
                        lblHindiCoach.Visible = true;
                        pbCrossHindi.Visible = true;
                    }
                    if (string.IsNullOrWhiteSpace(RLanguage))
                    {
                        lblRegionalName.Visible = true;
                        pbCrossRegional.Visible = true;
                    }
                }
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

        private void btnCross_Click(object sender, EventArgs e)
        {
            txtSearch.Text = initialText;
            showData(1, pagesize);
            btnSearch.Visible = true;
            btnCross.Visible = false;

            lblNoDataToDisplay.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnCross.Visible = true;
            btnSearch.Visible = false;
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



                SearchData(1, pagesize, searchText);
            }
            else
            {
                SearchData(1, pagesize, searchText);
                btnCross.Visible = true;
                btnSearch.Visible = false;
            }

            previousSearchText = searchText;
        }

        public void SearchData(int pageIndex, int pageSize, string searchQuery)
        {
            try
            {
                (DataTable Status, int recordCount) = regionallanguageStatusDb.GetSearchStatus(pageIndex, pageSize, searchQuery);

                if (Status != null && Status.Rows.Count > 0)
                {
                    dgvLanguageSettingsTable.AutoGenerateColumns = false;


                    dgvLanguageSettingsTable.Columns["English"].DataPropertyName = "StatusName";
                    dgvLanguageSettingsTable.Columns["Hindi"].DataPropertyName = "HStatus";
                    dgvLanguageSettingsTable.Columns["RegionalLanguage"].DataPropertyName = "RStatus";

                    if (!dgvLanguageSettingsTable.Columns.Contains("Pkey_Status"))
                    {
                        DataGridViewTextBoxColumn pkeyColumn = new DataGridViewTextBoxColumn
                        {
                            DataPropertyName = "Pkey_Status",
                            HeaderText = "Pkey_Status",
                            Name = "Pkey_Status",
                            Visible = false
                        };
                        dgvLanguageSettingsTable.Columns.Add(pkeyColumn);
                    }
                    else
                    {
                        dgvLanguageSettingsTable.Columns["Pkey_Status"].DataPropertyName = "Pkey_Status";
                        dgvLanguageSettingsTable.Columns["Pkey_Status"].Visible = false;
                    }

                    dgvLanguageSettingsTable.DataSource = Status;

                    dgvLanguageSettingsTable.AllowUserToAddRows = false;
                    lblNoDataToDisplay.Visible = false;
                }
                else
                {
                    dgvLanguageSettingsTable.DataSource = null;
                    lblNoDataToDisplay.Visible = true;
                }

                // Update pagination
                PaginationClass pagination = new PaginationClass();
                pagination.Populate(recordCount, pageIndex, pageSize, pnlPagination, this, (pageIdx, size) => SearchData(pageIdx, size, searchQuery));
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}

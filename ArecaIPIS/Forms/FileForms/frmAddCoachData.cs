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
    public partial class frmAddCoachData : Form
    {
        ToolStripDropDown dropDown;
        addCoachDataDb addCoachDataDb = new addCoachDataDb();
        private string initialText;
        public frmAddCoachData()
        {
            InitializeComponent();
            dgvCoachData.EnableHeadersVisualStyles = false;
            dgvCoachData.ColumnHeadersDefaultCellStyle.BackColor = Color.Green;
            pnlCoachData.Visible = false;
            pnlCreateCoach.Visible = false;
            lblEnglishCoach.Visible = false;
            lblHindiCoach.Visible = false;
            lblBitmapName.Visible = false;
            pbCross.Visible = false;
            pbTick.Visible = false;
            pbCrossHindi.Visible = false;
            pbTickHindi.Visible = false;
            pbCrossBitmap.Visible = false;
            pbTickBitmap.Visible = false;
            initialText = txtSearch.Text;
            lblNoDataToDisplay.Visible = false;

            CheckedListBox checkedListBox = new CheckedListBox();
            checkedListBox.Items.AddRange(new object[] { "Coach Name", "Hindi Language", "Bitmap" });

            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemChecked(i, true);
                checkedListBox.BackColor = Color.LightSalmon;
            }

            dropDown = new ToolStripDropDown();
            ToolStripControlHost host = new ToolStripControlHost(checkedListBox);
            host.Padding = Padding.Empty;
            dropDown.Items.Add(host);

            toolTip.SetToolTip(btnAddMessage, "Add New Message");
            dgvCoachData.CellToolTipTextNeeded += new DataGridViewCellToolTipTextNeededEventHandler(dgvCoachData_CellToolTipTextNeeded);
            btnDropdown.Visible = false;
        }

        private void dgvCoachData_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                if (dgvCoachData.Columns[e.ColumnIndex] is DataGridViewImageColumn)
                {
                    e.ToolTipText = "Edit";
                }
            }
        }

        private frmHome parentForm;

        public frmAddCoachData(frmHome parentForm) : this()
        {
            this.parentForm = parentForm;
        }
        int pagesize = 9;
        private void frmAddCoachData_Load(object sender, EventArgs e)
        {
            dgvCoachData.RowTemplate.Height = 35;
            showData(1, pagesize);
        }

        public void showData(int pageIndex, int pagesize)
        {
            (DataTable CoachData, int recordCount) = addCoachDataDb.GetCoachData(pageIndex, pagesize);

            if (CoachData != null)
            {

                dgvCoachData.DataSource = CoachData;

                dgvCoachData.Columns["CoachName"].DataPropertyName = "EnglishCoachName";
                dgvCoachData.Columns["HindiLanguage"].DataPropertyName = "HindiCoachName";
                dgvCoachData.Columns["Bitmap"].DataPropertyName = "Bitmap";

                if (!dgvCoachData.Columns.Contains("Pkey_CoachBitmapid"))
                {
                    DataGridViewTextBoxColumn pkeyColumn = new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Pkey_CoachBitmapid",
                        HeaderText = "Pkey_CoachBitmapid",
                        Name = "Pkey_CoachBitmapid",
                        Visible = false
                    };
                    dgvCoachData.Columns.Add(pkeyColumn);
                }
                else
                {
                    dgvCoachData.Columns["Pkey_CoachBitmapid"].DataPropertyName = "Pkey_CoachBitmapid";
                    dgvCoachData.Columns["Pkey_CoachBitmapid"].Visible = false;
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

                MessageBox.Show("Failed to retrieve Coach Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAddMessage_Click(object sender, EventArgs e)
        {
            pnlCoachData.Visible = true;
            pnlCreateCoach.Visible = true;
            lblCreateCoach.Text = "Add Coach Data";
            btnSave.Text = "    Save";
            txtEnglish.Text = "";
            txtHindi.Text = "";
            txtBitmap.Text = "";
            lblBitmapName.Visible = false;
            lblEnglishCoach.Visible = false;
            lblHindiCoach.Visible = false;
            pbCross.Visible = false;
            pbCrossHindi.Visible = false;
            pbCrossBitmap.Visible = false;

        }
        int pkey;
        private void dgvCoachData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                try
                {
                    int pkeyValue = Convert.ToInt32(dgvCoachData.Rows[e.RowIndex].Cells["Pkey_CoachBitmapid"].Value);
                    DataTable Message = addCoachDataDb.GetCoachDataByRow(pkeyValue);

                    if (Message != null && Message.Rows.Count > 0)
                    {
                        pkey = pkeyValue;
                        string english = Message.Rows[0]["EnglishCoachName"].ToString();
                        string Hindi = Message.Rows[0]["HindiCoachName"].ToString();
                        string Bitmap = Message.Rows[0]["Bitmap"].ToString();

                        pnlCoachData.Visible = true;
                        pnlCreateCoach.Visible = true;
                        lblCreateCoach.Text = "Edit Coach Data";
                        btnSave.Text = "    Update";
                        txtEnglish.Text = english;
                        txtHindi.Text = Hindi;
                        txtBitmap.Text = Bitmap;

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
            pnlCoachData.Visible = false;
            pnlCreateCoach.Visible = false;
            txtEnglish.Text = "";
            txtHindi.Text = "";
            txtBitmap.Text = "";
         
        }

        private void txtEnglish_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEnglish.Text))
            {
                //lblValidationEnglish.Text = "Please Enter Message in English.";
                //lblEnglish.Visible = true;
                lblEnglishCoach.Visible = true;
                pbTick.Visible = false;
                pbCross.Visible = true;

            }
            else
            {
              
                lblEnglishCoach.Visible = false;
                pbTick.Visible = true;
                pbCross.Visible = false;
            }
        }

        private void txtHindi_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHindi.Text))
            {

                lblHindiCoach.Visible = true;
                pbTickHindi.Visible = false;
                pbCrossHindi.Visible = true;

            }
            else
            {

                lblHindiCoach.Visible = false;
                pbTickHindi.Visible = true;
                pbCrossHindi.Visible = false;
            }
        }

        private void txtBitmap_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBitmap.Text))
            {

                lblBitmapName.Visible = true;
                pbTickBitmap.Visible = false;
                pbCrossBitmap.Visible = true;

            }
            else
            {

                lblBitmapName.Visible = false;
                pbTickBitmap.Visible = true;
                pbCrossBitmap.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            string english = txtEnglish.Text;
            string Hindi = txtHindi.Text;
            string Bitmap = txtBitmap.Text;

            try
            {
                if (!string.IsNullOrWhiteSpace(english) &&
                    !string.IsNullOrWhiteSpace(Hindi) &&
                    !string.IsNullOrWhiteSpace(Bitmap))
                {
                    int pk = pkey;


                    bool b = addCoachDataDb.InsertOrUpdateMessage(pk, english, Hindi, Bitmap);

                    if (b)
                    {
                        MessageBox.Show("Data saved successfully");
                        pnlCoachData.Visible = false;
                        pnlCreateCoach.Visible = false;
                        txtEnglish.Text = "";
                        txtHindi.Text = "";
                        txtBitmap.Text = "";
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
                    if (string.IsNullOrWhiteSpace(Bitmap))
                    {
                        lblBitmapName.Visible = true;
                        pbCrossBitmap.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            showData(1, pagesize);
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
                (DataTable CoachData, int recordCount) = addCoachDataDb.GetSearchCoachdata(pageIndex, pageSize, searchQuery);

                if (CoachData != null && CoachData.Rows.Count > 0)
                {
                    dgvCoachData.AutoGenerateColumns = false;

                    dgvCoachData.Columns["CoachName"].DataPropertyName = "EnglishCoachName";
                    dgvCoachData.Columns["HindiLanguage"].DataPropertyName = "HindiCoachName";
                    dgvCoachData.Columns["Bitmap"].DataPropertyName = "Bitmap";

                    if (!dgvCoachData.Columns.Contains("Pkey_CoachBitmapid"))
                    {
                        DataGridViewTextBoxColumn pkeyColumn = new DataGridViewTextBoxColumn
                        {
                            DataPropertyName = "Pkey_CoachBitmapid",
                            HeaderText = "Pkey_CoachBitmapid",
                            Name = "Pkey_CoachBitmapid",
                            Visible = false
                        };
                        dgvCoachData.Columns.Add(pkeyColumn);
                    }
                    else
                    {
                        dgvCoachData.Columns["Pkey_CoachBitmapid"].DataPropertyName = "Pkey_CoachBitmapid";
                        dgvCoachData.Columns["Pkey_CoachBitmapid"].Visible = false;
                    }

                    dgvCoachData.DataSource = CoachData;

                    dgvCoachData.AllowUserToAddRows = false;
                    lblNoDataToDisplay.Visible = false;
                }
                else
                {
                    dgvCoachData.DataSource = null;
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

        private void btnDropdown_Click(object sender, EventArgs e)
        {
            dropDown.Show(btnDropdown, new System.Drawing.Point(0, btnDropdown.Height));
        }
    }
}

using ArecaIPIS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArecaIPIS.Forms
{
    public partial class frmBoardDiagnosisCds : Form
    {
        public frmBoardDiagnosisCds()
        {
            InitializeComponent();
            dgvCommunication.CellPainting += dgvCommunication_CellPainting;
        }

        private frmHome parentForm;
      
        public frmBoardDiagnosisCds(frmHome parentForm) : this()
        {
            this.parentForm = parentForm;
        }

        private void frmBoardDiagnosisCds_Load(object sender, EventArgs e)
        {
            try
            {
                List<int> packetIdentifiers = new List<int> { 1 };

                // Fetch data from the database
                DataTable boards = BoardDiagnosisDb.GetDiagnosisBoards(packetIdentifiers);

                // Clear existing rows in the DataGridView
                dgvCommunication.Rows.Clear();

                // Import the data from the original DataTable to the new DataTable
                foreach (DataRow row in boards.Rows)
                {
                    DataGridViewRow dgvRow = new DataGridViewRow();
                    dgvRow.CreateCells(dgvCommunication);

                    dgvRow.Cells[dgvCommunication.Columns["dgvPdcIp"].Index].Value = row["IPAddress"];
                    dgvRow.Cells[dgvCommunication.Columns["dgvPDCName"].Index].Value = row["Location"];
                    dgvRow.Cells[dgvCommunication.Columns["dgvPortNo"].Index].Value = row["EthernetPort"];
                    dgvRow.Cells[dgvCommunication.Columns["dgvPlatformNo"].Index].Value = row["Platform"];
                    dgvRow.Cells[dgvCommunication.Columns["dgvTemperature"].Index].Value = row["Temperature"];
                    dgvRow.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Value = row["LinkStatus"];
                   // dgvRow.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Value = row["LinkStatus"];
                    if (row["LinkStatus"].ToString().Trim() == "True")
                    {
                        dgvRow.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Value = "Active";
                        
                    }
                    else
                    {
                        dgvRow.Cells[dgvCommunication.Columns["dgvConfiguration"].Index].Value = "InActive";
                       
                    }

                    dgvCommunication.Rows.Add(dgvRow);
                }

               
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

        private void dgvCommunication_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

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
            if (e.ColumnIndex == dgvCommunication.Columns["dgvcheckBox"].Index && e.RowIndex >= 0)
            {
                // Get the value of the currently changed checkbox
                bool isChecked = (bool)dgvCommunication.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (isChecked)
                {
                    // Uncheck all other checkboxes in the column
                    foreach (DataGridViewRow row in dgvCommunication.Rows)
                    {
                        if (row.Index != e.RowIndex)
                        {
                            row.Cells["dgvcheckBox"].Value = false;
                        }
                    }
                }
            }
        }

        private void dgvCommunication_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

            if (dgvCommunication.IsCurrentCellDirty)
            {
                dgvCommunication.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}

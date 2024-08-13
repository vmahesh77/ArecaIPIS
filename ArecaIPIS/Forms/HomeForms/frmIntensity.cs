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
    public partial class frmIntensity : Form
    {
        public frmIntensity()
        {
            InitializeComponent();
         
        }
        private frmHome parentForm;

        public frmIntensity(frmHome parentForm) : this()
        {
            this.parentForm = parentForm;
        }

        private void frmIntensity_Load(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dGVIntensity.Rows)
            {
                row.Height = 50; 
            }
        }
        private TextBox currentTextBox = null;
        private Dictionary<int, Tuple<TrackBar, TextBox>> trackBarTextBoxMap = new Dictionary<int, Tuple<TrackBar, TextBox>>();
        private void dGVIntensity_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dGVIntensity.Columns["CurrentIntensity"].Index && e.RowIndex >= 0)
            {
                
                  
                    currentTextBox = new TextBox();
                    currentTextBox.Size = new Size(33, 32);
                    currentTextBox.BorderStyle = BorderStyle.FixedSingle;
                    //currentTextBox.TextChanged += TextBox_TextChanged;
                    currentTextBox.ReadOnly = true;
                   

                Rectangle rect = dGVIntensity.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                    int centerX = rect.X + (rect.Width - currentTextBox.Width) / 2;
                    int centerY = rect.Y + (rect.Height - currentTextBox.Height) / 2;

                    currentTextBox.Location = new Point(centerX, centerY);

                    // Add the TextBox to the DataGridView
                    dGVIntensity.Controls.Add(currentTextBox);
                    currentTextBox.BringToFront();

                   currentTextBox.Focus();

            }

            if (e.ColumnIndex == dGVIntensity.Columns["CurrentIntensity"].Index && e.RowIndex >= 0 && e.RowIndex < dGVIntensity.RowCount - 1)
            {

                e.AdvancedBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;
                e.Handled = true;
            }

            //if (e.ColumnIndex == dGVIntensity.Columns["UpdateIntensity"].Index && e.RowIndex >= 0)
            //{

            //    TrackBar trackBar = new TrackBar();
            //    trackBar.Minimum = 0;
            //    trackBar.Maximum = 100;
            //    trackBar.Width = 220;
            //    trackBar.Height = 10;
            //    trackBar.ValueChanged += TrackBar_ValueChanged;


            //    Rectangle rect = dGVIntensity.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            //    int centerX = rect.X + (rect.Width - trackBar.Width) / 2;
            //    int centerY = rect.Y + (rect.Height - trackBar.Height) / 2;


            //    trackBar.Location = new Point(centerX, centerY);


            //    int cellValue;
            //    if (dGVIntensity[e.ColumnIndex, e.RowIndex].Value != null &&
            //        int.TryParse(dGVIntensity[e.ColumnIndex, e.RowIndex].Value.ToString(), out cellValue))
            //    {
            //        trackBar.Value = cellValue;
            //    }


            //    dGVIntensity.Controls.Add(trackBar);
            //    trackBar.BringToFront();

            //}
            //if (e.ColumnIndex == dGVIntensity.Columns["UpdateIntensity"].Index && e.RowIndex >= 0 && e.RowIndex < dGVIntensity.RowCount - 1)
            //{
            //    e.AdvancedBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;
            //    e.Handled = true;
            //}



            //if (e.ColumnIndex == dGVIntensity.Columns["NewIntensity"].Index && e.RowIndex >= 0)
            //{

            //    textBox = new TextBox();
            //    textBox.Size = new Size(33, 32);
            //    textBox.BorderStyle = BorderStyle.FixedSingle;
            //    //currentTextBox.TextChanged += TextBox_TextChanged;
            //    textBox.ReadOnly = true;


            //    Rectangle rect = dGVIntensity.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            //    int centerX = rect.X + (rect.Width - textBox.Width) / 2;
            //    int centerY = rect.Y + (rect.Height - textBox.Height) / 2;

            //    textBox.Location = new Point(centerX, centerY);

            //    // Add the TextBox to the DataGridView
            //    dGVIntensity.Controls.Add(textBox);
            //    textBox.BringToFront();

            //    textBox.Focus();

            //}

            //if (e.ColumnIndex == dGVIntensity.Columns["NewIntensity"].Index && e.RowIndex >= 0 && e.RowIndex < dGVIntensity.RowCount - 1)
            //{

            //    e.AdvancedBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;
            //    e.Handled = true;
            //}

            if (e.ColumnIndex == dGVIntensity.Columns["UpdateIntensity"].Index && e.RowIndex >= 0)
            {
                if (!trackBarTextBoxMap.ContainsKey(e.RowIndex))
                {
                    // Create a TrackBar
                    TrackBar trackBar = new TrackBar();
                    trackBar.Minimum = 0;
                    trackBar.Maximum = 100;
                    trackBar.Width = 220;
                    trackBar.Height = 10;
                    trackBar.ValueChanged += TrackBar_ValueChanged;

                    // Create a TextBox
                    TextBox textBox = new TextBox();
                    textBox.Size = new Size(33, 32);
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    textBox.ReadOnly = true;

                    // Add the TrackBar and TextBox to the dictionary with the row index as the key
                    trackBarTextBoxMap.Add(e.RowIndex, new Tuple<TrackBar, TextBox>(trackBar, textBox));

                    // Get the center position of the cell in the "UpdateIntensity" column
                    Rectangle rectUpdateIntensity = dGVIntensity.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                    int centerXUpdateIntensity = rectUpdateIntensity.X + (rectUpdateIntensity.Width - trackBar.Width) / 2;
                    int centerYUpdateIntensity = rectUpdateIntensity.Y + (rectUpdateIntensity.Height - trackBar.Height) / 2;

                    Rectangle rectNewIntensity = dGVIntensity.GetCellDisplayRectangle(dGVIntensity.Columns["NewIntensity"].Index, e.RowIndex, false);
                    int centerXNewIntensity = rectNewIntensity.X + (rectNewIntensity.Width - textBox.Width) / 2;
                    int centerYNewIntensity = rectNewIntensity.Y + (rectNewIntensity.Height - textBox.Height) / 2;

                    // Set the location of the TrackBar to the center of the cell
                    trackBar.Location = new Point(centerXUpdateIntensity, centerYUpdateIntensity);
                    textBox.Location = new Point(centerXNewIntensity, centerYNewIntensity);
                    // Add the TrackBar to the DataGridView
                    dGVIntensity.Controls.Add(trackBar);
                    dGVIntensity.Controls.Add(textBox);
                }

                // Set focus to the TrackBar
                trackBarTextBoxMap[e.RowIndex].Item1.Focus();
            }

        }
        private void TrackBar_ValueChanged(object sender, EventArgs e)
        {
            TrackBar trackBar = sender as TrackBar;
            if (trackBar != null)
            {
                // Find the corresponding TextBox in the same row
                foreach (var kvp in trackBarTextBoxMap)
                {
                    if (kvp.Value.Item1 == trackBar)
                    {
                        // Set the value of the TextBox to the value of the TrackBar
                        kvp.Value.Item2.Text = trackBar.Value.ToString();
                        break;
                    }
                }
            }
            //textBox.Text = trackBar.Value.ToString();
        }
        private void dGVIntensity_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // When new rows are added, clear the dictionary to reset the association between rows and controls
            trackBarTextBoxMap.Clear();
        }
        private void dGVIntensity_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void tBIntensity_ValueChanged(object sender, EventArgs e)
        {
            txtNewIntensity.Text = tBIntensity.Value.ToString();
            //textBox.Text = tBIntensity.Value.ToString();

            int newValue = tBIntensity.Value;

       
            foreach (Control control in dGVIntensity.Controls)
            {
                if (control is TrackBar trackBar)
                {
                    DataGridViewCell cell = dGVIntensity.CurrentCell;
                    if (cell != null && cell.ColumnIndex == dGVIntensity.Columns["UpdateIntensity"].Index)
                    {
                       
                        trackBar.Value = newValue;
                    }
                }
            }
        }
    }
}

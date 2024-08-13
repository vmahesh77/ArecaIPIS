using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using ArecaIPIS.Forms.CommonForms;

namespace ArecaIPIS.Forms
{
    public partial class frmPlaylist : Form
    {

        private frmHome parentForm;
        public frmPlaylist(frmHome parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;

        }
        public frmPlaylist()
        {
            InitializeComponent();
            btnSave.Enabled = false;
            btnPlay.Enabled = false;
            btnUpArrow.Enabled = false;
            btnDownArrow.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Media Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png; *.mp4; *.avi; *.mkv)|*.jpg; *.jpeg; *.gif; *.bmp; *.png; *.mp4; *.avi; *.mkv";
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                lblAdd.Text = "";
                foreach (string file in openFileDialog.FileNames)
                {
                    string fileName = Path.GetFileName(file);
                    lsdAddFile.Items.Add(fileName);
                    lblAdd.Text += fileName + Environment.NewLine;
                }

            }
        }

        private void txtSelectColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {

                Color selectedColor = colorDialog.Color;
                string hexValue = ColorTranslator.ToHtml(selectedColor);
                txtSelectColor.BackColor = selectedColor;
                txtSelectColor.Text = $"{hexValue}";
                txtColor.BackColor = selectedColor;
            }
        }

        private void btnClear_MouseHover(object sender, EventArgs e)
        {
            btnClear.BackColor = Color.DarkBlue;
        }

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            btnClear.BackColor = Color.DodgerBlue;
        }

        private void btnSavePlaylist_MouseHover(object sender, EventArgs e)
        {
            btnSavePlaylist.BackColor = Color.DarkBlue;
        }

        private void btnSavePlaylist_MouseLeave(object sender, EventArgs e)
        {
            btnSavePlaylist.BackColor = Color.DodgerBlue;
        }

        private void btnEdit_MouseHover(object sender, EventArgs e)
        {
            btnEdit.BackColor = Color.DarkBlue;
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            btnEdit.BackColor = Color.DodgerBlue;
        }

        private void btnSave_MouseHover(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.DarkBlue;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.DodgerBlue;
        }

        private void btnPlay_MouseHover(object sender, EventArgs e)
        {
            btnPlay.BackColor = Color.DarkBlue;
        }

        private void btnPlay_MouseLeave(object sender, EventArgs e)
        {
            btnPlay.BackColor = Color.DodgerBlue;
        }

        private void btnDelete_MouseHover(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.DarkBlue;
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.DodgerBlue;
        }

        private void btnPreview_MouseHover(object sender, EventArgs e)
        {
            btnPreview.BackColor = Color.DarkBlue;
        }

        private void btnPreview_MouseLeave(object sender, EventArgs e)
        {
            btnPreview.BackColor = Color.DodgerBlue;
        }

        private void btnSend_MouseHover(object sender, EventArgs e)
        {
            btnSend.BackColor = Color.DarkBlue;
        }

        private void btnSend_MouseLeave(object sender, EventArgs e)
        {
            btnSend.BackColor = Color.DodgerBlue;
        }

        private void btnDisplay_MouseHover(object sender, EventArgs e)
        {
            btnDisplay.BackColor = Color.DarkBlue;
        }

        private void btnDisplay_MouseLeave(object sender, EventArgs e)
        {
            btnDisplay.BackColor = Color.DodgerBlue;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnSave.BackColor = Color.DodgerBlue;
            btnPlay.Enabled = true;
            btnPlay.BackColor = Color.DodgerBlue;
            btnUpArrow.Enabled = true;
            btnDownArrow.Enabled = true;
        }

        private void btnKeyboard_Click(object sender, EventArgs e)
        {
            Keyboard(700, 230);
        }
        public static Panel panel = new Panel();

        private void Keyboard(int x, int y)
        {
            // Create a new Panel
            // Panel panel = new Panel();

            // Set panel properties
            panel.BackColor = Color.Blue; // Set the background color to blue
            panel.BorderStyle = BorderStyle.FixedSingle; // Set the border style
            panel.Size = new Size(709, 450); // Set the size of the panel
            panel.AutoSize = true; // Adjust panel size automatically based on content
            panel.Visible = true;
            // Calculate the desired location for the panel relative to the button
            int offsetX = 0; // Offset from the left edge of the button
            int offsetY = btnKeyboard.Height; // Offset from the bottom edge of the button
            Point buttonLocation = btnKeyboard.PointToScreen(Point.Empty); // Get the location of the button
            Point desiredLocation = new Point(x, y);

            // Set the location of the panel below the button
            panel.Location = desiredLocation;

            // Create an instance of the keyboard form and pass the TextBox
            frmKeyBoard keyBoard = new frmKeyBoard(txtClearingEffects, panel); // Replace "textbox1" with your TextBox control



            // Show the keyboard form
            keyBoard.TopLevel = false; // Set the form as a child control
            keyBoard.FormBorderStyle = FormBorderStyle.None; // Remove form border
            panel.Controls.Add(keyBoard); // Add keyboard form to the panel
            keyBoard.Show(); // Show the keyboard form

            // Add the panel to the parent form
            this.Controls.Add(panel);

            // Bring the panel to the front so it is visible
            panel.BringToFront();
        }


        private void upButton(ListBox listBox)
        {
            if (listBox.SelectedIndex > 0)
            {
                int currentIndex = listBox.SelectedIndex;
                object currentItem = listBox.SelectedItem;

                listBox.Items.RemoveAt(currentIndex);
                listBox.Items.Insert(currentIndex - 1, currentItem);
                listBox.SelectedIndex = currentIndex - 1;
            }
        }
        private void downButton(ListBox listBox)
        {
            if (listBox.SelectedIndex < listBox.Items.Count - 1 && listBox.SelectedIndex >= 0)
            {
                int currentIndex = listBox.SelectedIndex;
                object currentItem = listBox.SelectedItem;

                listBox.Items.RemoveAt(currentIndex);
                listBox.Items.Insert(currentIndex + 1, currentItem);
                listBox.SelectedIndex = currentIndex + 1;
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            upButton(lsdAddFile);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            downButton(lsdAddFile);
        }

        private void btnUpArrow_Click(object sender, EventArgs e)
        {
            upButton(lsdAddFile);
        }

        private void btnDownArrow_Click(object sender, EventArgs e)
        {
            downButton(lsdAddFile);
        }
    }
}

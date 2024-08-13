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
using ArecaIPIS.DAL;
using ArecaIPIS.Forms.CommonForms;
using ArecaIPIS.Forms.HomeForms;
namespace ArecaIPIS.Forms
{

    public partial  class frmTrainInformation : Form
    {
        public static List<string> CoachDetailsList = new List<string>();
        public frmTrainInformation()
        {
            InitializeComponent();

        }

        private frmIndex parentForm;

        public frmTrainInformation(frmIndex parentForm) : this()
        {
            this.parentForm = parentForm;
        }


      




        private void btnCoachDetails_Click(object sender, EventArgs e)
        {
            panTrainDetails.Visible = false;
            panCoachDetails.Visible = true;
        }

        private void btnTrainDetails_Click(object sender, EventArgs e)
        {
            panTrainDetails.Visible = true;
            panCoachDetails.Visible = false;
        }

        private void frmTrainInformation_Load(object sender, EventArgs e)
        {
            countTextBoxValidations = 0;
                setWeekstable();
            SetTrainTypes();

            SetPlatforms();
        }
        private void SetPlatforms()
        {
            // Clear existing items in the ComboBox
            cmbPlatform.Items.Clear();

            // Add the default item "--Select--"
            cmbPlatform.Items.Add("--Select--");

            // Assuming BaseClass.Platforms is a collection of platform names
            foreach (var platform in BaseClass.Platforms)
            {
                 
                string trimmedPlatform = platform.Trim();

                // Add the trimmed platform name to the ComboBox
                cmbPlatform.Items.Add(trimmedPlatform);
            }

            // Select the default item "--Select--"
            cmbPlatform.SelectedIndex = 0;
        }




        public static Panel panel = new Panel();
        private void SetTrainTypes()
        {
            
            cmbTrainType.Items.Clear();
            cmbTrainType.Items.Add("--Select--");
            // Add languages from BaseClass.Languages to the ComboBox
            foreach (string language in BaseClass.TrainTypes)
            {
                cmbTrainType.Items.Add(language);
            }

            if (cmbTrainType.Items.Count > 0)
            {
                cmbTrainType.SelectedIndex = 0;
            }
            cmbCategory.SelectedIndex = 0;
        }

        private void setWeekstable()
        {
            // Prevent users from manually adding rows
            dataGridViewTrainInfo.AllowUserToAddRows = false;

            // Clear existing rows in the DataGridView
            dataGridViewTrainInfo.Rows.Clear();

            // Add rows with default values for the "Days" column
            string[] daysOfWeek = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            foreach (string day in daysOfWeek)
            {
                int rowIndex = dataGridViewTrainInfo.Rows.Add(false, day);
                // Set checkbox column value to false for each row
                dataGridViewTrainInfo.Rows[rowIndex].Cells["select"].Value = false;
            }

            // Adjust row height to fit entire grid
            int totalRowHeight = dataGridViewTrainInfo.ColumnHeadersHeight; // Include header height
            foreach (DataGridViewRow row in dataGridViewTrainInfo.Rows)
            {
                totalRowHeight += row.Height; // Add height of each row
            }
            dataGridViewTrainInfo.Height = totalRowHeight + 2; // Adjusting by a small margin
        }

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
            int offsetY = btnKeyBoardHindi.Height; // Offset from the bottom edge of the button
            Point buttonLocation = btnKeyBoardHindi.PointToScreen(Point.Empty); 
            Point desiredLocation = new Point(x, y);

            
            panel.Location = desiredLocation;

            
            frmKeyBoard keyBoard = new frmKeyBoard(txtHindi, panel);



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



        private void frmTrainInformation_MouseClick(object sender, MouseEventArgs e)
        {
            panel.Controls.Clear();
            panel.Visible = false;

            Form mainForm = Application.OpenForms["frmScheduledTrains"];

            if (mainForm != null)
            {
                frmScheduledTrains frmScheduled = (frmScheduledTrains)mainForm;
                frmScheduled.Close();
            }
        }

        private void btnKeyBoardHindi_Click(object sender, EventArgs e)
        {
            Keyboard(700, 230);
        }

        private void btnkeyboardRegional_Click(object sender, EventArgs e)
        {
            Keyboard(700, 230);
        }

        private void rctbTrainNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a digit or a control character (e.g., Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // If the pressed key is not a digit or a control character, suppress it
                e.Handled = true;
            }
        }

        private void rctbSource_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a letter
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not a letter or a control character (like backspace), suppress the key press
                e.Handled = true;
            }
        }

        private void rctbDestination_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a letter
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not a letter or a control character (like backspace), suppress the key press
                e.Handled = true;
            }
        }

        private void rctbVia_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a letter
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If it's not a letter or a control character (like backspace), suppress the key press
                e.Handled = true;
            }
        }

        private void rctbEnglish_Leave(object sender, EventArgs e)
        {
            // Check if the TextBox is empty
            if (string.IsNullOrWhiteSpace(rctbEnglish.Text))
            {
                // Set the border style to indicate a warning (you can choose different styles as per your UI design)
                rctbEnglish.BorderStyle = BorderStyle.FixedSingle;
                // Set the back color to red to further indicate a warning
                rctbEnglish.BackColor = Color.Red;
            }
            else
            {
                // Reset the border style to its default
                rctbEnglish.BorderStyle = BorderStyle.Fixed3D;
                // Reset the back color to its default
                rctbEnglish.BackColor = SystemColors.Window;
            }
        }

        private void rctbSource_Leave(object sender, EventArgs e)
        {
            // Check if the TextBox is empty
            if (string.IsNullOrWhiteSpace(rctbSource.Text))
            {
                // Set the border style to indicate a warning (you can choose different styles as per your UI design)
                rctbSource.BorderStyle = BorderStyle.FixedSingle;
                // Set the back color to red to further indicate a warning
                rctbSource.BackColor = Color.Red;
            }
            else
            {
                // Reset the border style to its default
                rctbSource.BorderStyle = BorderStyle.Fixed3D;
                // Reset the back color to its default
                rctbSource.BackColor = SystemColors.Window;
            }
        }

        private void rctbDestination_Leave(object sender, EventArgs e)
        {
            // Check if the TextBox is empty
            if (string.IsNullOrWhiteSpace(rctbDestination.Text))
            {
                // Set the border style to indicate a warning (you can choose different styles as per your UI design)
                rctbDestination.BorderStyle = BorderStyle.FixedSingle;
                // Set the back color to red to further indicate a warning
                rctbDestination.BackColor = Color.Red;
            }
            else
            {
                // Reset the border style to its default
                rctbDestination.BorderStyle = BorderStyle.Fixed3D;
                // Reset the back color to its default
                rctbDestination.BackColor = SystemColors.Window;
            }
        }

        private void rctbVia_Leave(object sender, EventArgs e)
        {
            // Check if the TextBox is empty
            if (string.IsNullOrWhiteSpace(rctbVia.Text))
            {
                // Set the border style to indicate a warning (you can choose different styles as per your UI design)
                rctbVia.BorderStyle = BorderStyle.FixedSingle;
                // Set the back color to red to further indicate a warning
                rctbVia.BackColor = Color.Red;
            }
            else
            {
                // Reset the border style to its default
                rctbVia.BorderStyle = BorderStyle.Fixed3D;
                // Reset the back color to its default
                rctbVia.BackColor = SystemColors.Window;
            }
        }

        private void txtHindi_Leave(object sender, EventArgs e)
        {
            // Check if the TextBox is empty
            if (string.IsNullOrWhiteSpace(txtHindi.Text))
            {
                // Set the border style to indicate a warning (you can choose different styles as per your UI design)
                txtHindi.BorderStyle = BorderStyle.FixedSingle;
                // Set the back color to red to further indicate a warning
                txtHindi.BackColor = Color.Red;
            }
            else
            {
                // Reset the border style to its default
                txtHindi.BorderStyle = BorderStyle.Fixed3D;
                // Reset the back color to its default
                txtHindi.BackColor = SystemColors.Window;
            }
        }


        private void txtRegional_Leave(object sender, EventArgs e)
        {
            // Check if the TextBox is empty
            if (string.IsNullOrWhiteSpace(txtRegional.Text))
            {
                // Set the border style to indicate a warning (you can choose different styles as per your UI design)
                txtRegional.BorderStyle = BorderStyle.FixedSingle;
                // Set the back color to red to further indicate a warning
                txtRegional.BackColor = Color.Red;
            }
            else
            {
                // Reset the border style to its default
                txtRegional.BorderStyle = BorderStyle.Fixed3D;
                // Reset the back color to its default
                txtRegional.BackColor = SystemColors.Window;
            }
        }

        private void rctbTrainNumber_Leave(object sender, EventArgs e)
        {
            // Check if the TextBox is empty
            if (string.IsNullOrWhiteSpace(rctbTrainNumber.Text))
            {
                // Set the border style to indicate a warning (you can choose different styles as per your UI design)
                rctbTrainNumber.BorderStyle = BorderStyle.FixedSingle;
                // Set the back color to red to further indicate a warning
                rctbTrainNumber.BackColor = Color.Red;
            }
            else
            {
                // Reset the border style to its default
                rctbTrainNumber.BorderStyle = BorderStyle.Fixed3D;
                // Reset the back color to its default
                rctbTrainNumber.BackColor = SystemColors.Window;
            }
        }

        private void chkCgdb_CheckedChanged(object sender, EventArgs e)
        {
            // Check if the checkbox is checked
            if (chkCgdb.Checked)
            {
                // If checked, enable the panel
                pnlCoachPositions.Enabled = true;
            }
            else
            {
                // If unchecked, disable the panel
                pnlCoachPositions.Enabled = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtArrivalTime_TextChanged(object sender, EventArgs e)
        {
            // Get the text from the TextBox
            string input = txtArrivalTime.Text;

            // Check if the input contains only digits
            if (Regex.IsMatch(input, @"^\d+$"))
            {
                // If the input length is 3 and the 3rd character is not a colon, insert a colon after the first two digits
                if (input.Length == 3 && input[2] != ':')
                {
                    txtArrivalTime.Text = input.Insert(2, ":");
                    txtArrivalTime.SelectionStart = txtArrivalTime.Text.Length; // Move the cursor to the end of the text
                }
            }

            // If the input length is greater than 5, truncate the input to 5 characters
            if (input.Length > 5)
            {
                txtArrivalTime.Text = input.Substring(0, 5);
                txtArrivalTime.SelectionStart = txtArrivalTime.Text.Length; // Move the cursor to the end of the truncated text
            }
            if (input.Length == 5)
            {
                validatetime(txtArrivalTime, lblArrivalError);
            }

        }

        private void txtArrivalTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allowing digits, backspace, and colon
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != ':')
            {
                // Prevent the character from being entered into the TextBox
                e.Handled = true;
            }
        }

        private void txtArrivalTime_Validating(object sender, CancelEventArgs e)
        {
            validatetime(txtArrivalTime, lblArrivalError);

            //// Get the text from the TextBox
            //string input = txtArrivalTime.Text;

            //// Check if the input matches the 24-hour time format (HH:mm)
            //if (!Regex.IsMatch(input, @"^([01]?[0-9]|2[0-3]):[0-5][0-9]$"))
            //{
            //    lblArrivalError.Visible = true;
            //    lblArrivalError.Text = "Please enter a valid time in 24-hour format (HH:mm).";
            //    // If the input doesn't match the format, show an error message
            //   // MessageBox.Show("Please enter a valid time in 24-hour format (HH:mm).", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //   // e.Cancel = true; // Cancel the event to prevent focus change
            //}
            //else
            //{
            //    lblArrivalError.Visible = false;
            //}
        }
        private void validatetime(TextBox textBox, Label label)
        {
            // Get the text from the TextBox
            string input = textBox.Text;

            // Check if the input matches the 24-hour time format (HH:mm)
            if (!Regex.IsMatch(input, @"^([01]?[0-9]|2[0-3]):[0-5][0-9]$"))
            {
                label.Visible = true;
                label.Text = "Please enter a valid time ";
                // If the input doesn't match the format, show an error message
                // MessageBox.Show("Please enter a valid time in 24-hour format (HH:mm).", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // e.Cancel = true; // Cancel the event to prevent focus change
            }
            else
            {
                label.Visible = false;
            }
        }

        private void txtDepatureTime_TextChanged(object sender, EventArgs e)
        {

            // Get the text from the TextBox
            string input = txtDepatureTime.Text;

            // Check if the input contains only digits
            if (Regex.IsMatch(input, @"^\d+$"))
            {
                // If the input length is 3 and the 3rd character is not a colon, insert a colon after the first two digits
                if (input.Length == 3 && input[2] != ':')
                {
                    txtDepatureTime.Text = input.Insert(2, ":");
                    txtDepatureTime.SelectionStart = txtDepatureTime.Text.Length; // Move the cursor to the end of the text
                }
            }

            // If the input length is greater than 5, truncate the input to 5 characters
            if (input.Length > 5)
            {
                txtDepatureTime.Text = input.Substring(0, 5);
                txtDepatureTime.SelectionStart = txtDepatureTime.Text.Length; // Move the cursor to the end of the truncated text
            }
            if (input.Length == 5)
            {
                validatetime(txtDepatureTime, lblDepatureError);
            }
        }

        private void txtDepatureTime_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Allowing digits, backspace, and colon
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != ':')
            {
                // Prevent the character from being entered into the TextBox
                e.Handled = true;
            }
        }

        private void txtArrivalTime_Leave(object sender, EventArgs e)
        {
            validateSametime();
        }
        private void validateSametime()
        {
            // Get the text from the Arrival Time TextBox
            string arrivalTime = txtArrivalTime.Text;

            // Get the text from the Departure Time TextBox
            string departureTime = txtDepatureTime.Text;

            // Check if both arrival and departure times are not empty and are the same
            if (arrivalTime == departureTime)
            {
                // Show an error message
                lblSameTimeError.Text = "Arrival and departure times cannot be the same.";
                lblSameTimeError.Visible = true;
            }
            else
            {
                // Hide the error label if the times are different or one of them is empty
                lblSameTimeError.Visible = false;
            }
        }
        public static DataTable ConvertDataGridViewToDataTable(DataGridView dataGridView)
        {
            DataTable dataTable = new DataTable();

            // Add columns to DataTable
           
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {

                dataTable.Columns.Add(column.Name, column.ValueType ?? typeof(string));
               
            }

           
            // Add rows to DataTable
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.IsNewRow) continue; // Skip the new row placeholder

                DataRow dataRow = dataTable.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dataRow[cell.OwningColumn.Name] = cell.Value ?? DBNull.Value;
                }
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }









       

        private void btnSave_Click(object sender, EventArgs e)
        {
            vaidateAllControls();
            if (countTextBoxValidations == 0)
            {
                bool checkTrainNumber = OnlineTrainsDao.CheckTrainExisted(rctbTrainNumber.Text);
                checkTrainNumber = false;
                if (!checkTrainNumber)
                {
                    AddCoachDetailsList();


                    DataTable RunningTrainDirections = ConvertDataGridViewToDataTable(dataGridViewTrainInfo);

                    bool sucess = OnlineTrainsDao.InsertUpdateTrainDetails(-1, rctbTrainNumber.Text, cmbTrainType.Text, cmbCategory.Text, rctbSource.Text, rctbDestination.Text,
                         rctbVia.Text, rctbEnglish.Text, txtHindi.Text, txtRegional.Text, txtArrivalTime.Text, txtDepatureTime.Text, cmbPlatform.Text,
                         CmbStatus.Text, RunningTrainDirections, CoachDetailsList);
                    if (sucess)
                    {
                        MessageBox.Show("data Saved");
                        clearAllControls();
                    }
                    else
                    {
                        MessageBox.Show("Failed to Insert Train!");
                    }
                }
                else
                {
                    MessageBox.Show("Train Number Already Existed");
                }
            }
            else
            {
                countTextBoxValidations = 0;
                MessageBox.Show("please fix the errors");
            }
        }

        public void AddCoachDetailsList()
        {

            CoachDetailsList.Clear();

            CoachDetailsList.Add(txtCoach1.Text);
            CoachDetailsList.Add(txtCoach2.Text);
            CoachDetailsList.Add(txtCoach3.Text);
            CoachDetailsList.Add(txtCoach4.Text);
            CoachDetailsList.Add(txtCoach5.Text);
            CoachDetailsList.Add(txtCoach6.Text);
            CoachDetailsList.Add(txtCoach7.Text);
            CoachDetailsList.Add(txtCoach8.Text);
            CoachDetailsList.Add(txtCoach9.Text);
            CoachDetailsList.Add(txtCoach10.Text);
            CoachDetailsList.Add(txtCoach11.Text);
            CoachDetailsList.Add(txtCoach12.Text);
            CoachDetailsList.Add(txtCoach13.Text);
            CoachDetailsList.Add(txtCoach14.Text);
            CoachDetailsList.Add(txtCoach15.Text);
            CoachDetailsList.Add(txtCoach16.Text);
            CoachDetailsList.Add(txtCoach17.Text);
            CoachDetailsList.Add(txtCoach18.Text);
            CoachDetailsList.Add(txtCoach19.Text);
            CoachDetailsList.Add(txtCoach20.Text);
            CoachDetailsList.Add(txtCoach21.Text);
            CoachDetailsList.Add(txtCoach22.Text);
            CoachDetailsList.Add(txtCoach23.Text);
            CoachDetailsList.Add(txtCoach24.Text);
            CoachDetailsList.Add(txtCoach25.Text);
            CoachDetailsList.Add(txtCoach26.Text);
            CoachDetailsList.Add(txtCoach27.Text);
            CoachDetailsList.Add(txtCoach28.Text);

        }

        private void rctbDestination_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                dataGridViewTrainInfo.Rows[i].Cells["Destination"].Value = rctbDestination.Text;
            }
        }

        private void rctbVia_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                dataGridViewTrainInfo.Rows[i].Cells["Via"].Value = rctbVia.Text;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           bool deleted= OnlineTrainsDao.DeleteTrainDetails(rctbTrainNumber.Text);
            if(deleted)
            {
                MessageBox.Show("deleted Sucessfully");
                clearAllControls();
            }
            else
            {
                MessageBox.Show("Failed !");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmScheduledTrains frmscheduled;
            BaseClass.selectTrainsDatabase = "AllTrains";
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


        public  void fillAllTextBoxes()            
        {
            rctbTrainNumber.Text = "e";

        }

        private void frmTrainInformation_Leave(object sender, EventArgs e)
        {
           

            Form mainForm = Application.OpenForms["frmScheduledTrains"];

            if (mainForm != null)
            {
                frmScheduledTrains frmScheduled = (frmScheduledTrains)mainForm;
                frmScheduled.Close();
            }
        }


        public static int countTextBoxValidations = 0;
        public void ValidatRichTextBox(RichTextBox text)
        {
            if (string.IsNullOrWhiteSpace(text.Text))
            {
                // Set the border style to indicate a warning (you can choose different styles as per your UI design)
                text.BorderStyle = BorderStyle.FixedSingle;
                // Set the back color to red to further indicate a warning
                text.BackColor = Color.Red;
                countTextBoxValidations++;
            }
            else
            {
                // Reset the border style to its default
                text.BorderStyle = BorderStyle.Fixed3D;
                // Reset the back color to its default
                text.BackColor = SystemColors.Window;
            }
        }

        public void ValidatTextBox(TextBox text)
        {
            if (string.IsNullOrWhiteSpace(text.Text))
            {
                text.BorderStyle = BorderStyle.FixedSingle;
                text.BackColor = Color.Red;
                countTextBoxValidations++;
            }
            else
            {               
                text.BorderStyle = BorderStyle.Fixed3D;          
                text.BackColor = SystemColors.Window;
            }
        }


        public void vaidateAllControls()
        {
            ValidatRichTextBox(rctbTrainNumber);
            ValidatRichTextBox(rctbSource);
            ValidatRichTextBox(rctbDestination);
            ValidatRichTextBox(rctbVia);
            ValidatRichTextBox(rctbEnglish);
            ValidatTextBox(txtHindi);
            ValidatTextBox(txtRegional);
            ValidatTextBox(txtArrivalTime);
            ValidatTextBox(txtDepatureTime);          
        }


        public void fillTrainInformation(string trainNumber)
        {
         DataTable Traindt=   OnlineTrainsDao.GetTrainByNumber(trainNumber);

            DataTable TrainDirctionsdt = OnlineTrainsDao.GetTrainByTrainDirtections(trainNumber);

            dataGridViewTrainInfo.Rows.Clear();
            foreach (DataRow row in TrainDirctionsdt.Rows)
            {
                int rowIndex = dataGridViewTrainInfo.Rows.Add();
                dataGridViewTrainInfo.Rows[rowIndex].Cells["select"].Value = (Boolean)row["Checked"];             
                dataGridViewTrainInfo.Rows[rowIndex].Cells["Days"].Value = row["Days"].ToString();
                dataGridViewTrainInfo.Rows[rowIndex].Cells["Via"].Value = row["Via"].ToString();
                dataGridViewTrainInfo.Rows[rowIndex].Cells["Destination"].Value = row["Destination"].ToString();
            }


            foreach (DataRow row in Traindt.Rows)
            {
                rctbTrainNumber.Text = row["TrainNumber"].ToString();
                cmbTrainType.Text = row["TrainType"].ToString();
                cmbCategory.Text= row["Category"].ToString();
                rctbSource.Text = row["Source"].ToString();
                rctbDestination.Text= row["Destination"].ToString();
                rctbVia.Text= row["Via"].ToString(); 
                rctbEnglish.Text= row["EnglishName"].ToString();
                txtHindi.Text = row["HindiName"].ToString();
                txtRegional.Text = row["RegionalName"].ToString();
                txtArrivalTime.Text= row["ArrivalTime"].ToString();
                txtDepatureTime.Text= row["DepartureTime"].ToString();
                cmbPlatform.Text= row["Platform"].ToString();
                CmbStatus.Text= row["Status"].ToString();
                chkCgdb.Checked = true;
                string coachpositions= row["coachPositions"].ToString();
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearAllControls();

        }


        public void clearAllControls()
        {
            rctbTrainNumber.Text = "";
            rctbTrainNumber.BackColor = SystemColors.Window;
            cmbTrainType.SelectedIndex = 0;
            cmbCategory.SelectedIndex = 0;
            rctbSource.Text = "";
            rctbSource.BackColor = SystemColors.Window;

            rctbDestination.Text = "";
            rctbDestination.BackColor = SystemColors.Window;

            rctbVia.Text = "";
            rctbVia.BackColor = SystemColors.Window;

            rctbEnglish.Text = "";
            rctbEnglish.BackColor = SystemColors.Window;

            txtHindi.Text = "";
            txtHindi.BackColor = SystemColors.Window;

            txtRegional.Text = "";
            txtRegional.BackColor = SystemColors.Window;


            txtArrivalTime.Text = "00:00";
            txtArrivalTime.BackColor = SystemColors.Window;

            txtDepatureTime.Text = "00:00";
            txtDepatureTime.BackColor = SystemColors.Window;

            
            cmbPlatform.SelectedIndex = 0;
            CmbStatus.SelectedIndex = 0;


            chkCgdb.Checked = false;
            txtCoach1.Text = "";
            txtCoach2.Text = "";
            txtCoach3.Text = "";
            txtCoach4.Text = "";
            txtCoach5.Text = "";
            txtCoach6.Text = "";
            txtCoach7.Text = "";
            txtCoach8.Text = "";
            txtCoach9.Text = "";
            txtCoach10.Text = "";
            txtCoach11.Text = "";
            txtCoach12.Text = "";
            txtCoach13.Text = "";
            txtCoach14.Text = "";
            txtCoach15.Text = "";
            txtCoach16.Text = "";
            txtCoach17.Text = "";
            txtCoach18.Text = "";
            txtCoach19.Text = "";
            txtCoach20.Text = "";
            txtCoach21.Text = "";
            txtCoach22.Text = "";
            txtCoach23.Text = "";
            txtCoach24.Text = "";
            txtCoach25.Text = "";
            txtCoach26.Text = "";
            txtCoach27.Text = "";
            txtCoach28.Text = "";

            setWeekstable();


        }
    }
}

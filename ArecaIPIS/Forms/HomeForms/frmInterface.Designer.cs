
namespace ArecaIPIS.Forms
{
    partial class frmInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnNtes = new System.Windows.Forms.Button();
            this.btnCdot = new System.Windows.Forms.Button();
            this.panNtes = new System.Windows.Forms.Panel();
            this.lblMins = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkAutoMode = new System.Windows.Forms.CheckBox();
            this.chkAudio = new System.Windows.Forms.CheckBox();
            this.txtNextMinutes = new System.Windows.Forms.TextBox();
            this.txtStationCode = new System.Windows.Forms.TextBox();
            this.cmbDataType = new System.Windows.Forms.ComboBox();
            this.chkNtesEnable = new System.Windows.Forms.CheckBox();
            this.lblDataType = new System.Windows.Forms.Label();
            this.lblStationCode = new System.Windows.Forms.Label();
            this.lblNextMinutes = new System.Windows.Forms.Label();
            this.lblAudio = new System.Windows.Forms.Label();
            this.lblAutoModeNtes = new System.Windows.Forms.Label();
            this.lblNtesEnable = new System.Windows.Forms.Label();
            this.lblWebService = new System.Windows.Forms.Label();
            this.panCdot = new System.Windows.Forms.Panel();
            this.lblMinsCdot = new System.Windows.Forms.Label();
            this.lblSec = new System.Windows.Forms.Label();
            this.txtAlertCount = new System.Windows.Forms.TextBox();
            this.lblAlertCount = new System.Windows.Forms.Label();
            this.cmbSpeed = new System.Windows.Forms.ComboBox();
            this.chkCdotEnable = new System.Windows.Forms.CheckBox();
            this.chkAutoModeCdot = new System.Windows.Forms.CheckBox();
            this.txtPollingTime = new System.Windows.Forms.TextBox();
            this.txtStationCodeCdot = new System.Windows.Forms.TextBox();
            this.txtUserPass = new System.Windows.Forms.TextBox();
            this.txtDissmentationurl = new System.Windows.Forms.TextBox();
            this.txtValidationStatus = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtCdotUrl = new System.Windows.Forms.TextBox();
            this.txtDelayTime = new System.Windows.Forms.TextBox();
            this.btnSaveCdot = new System.Windows.Forms.Button();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblCdotUrl = new System.Windows.Forms.Label();
            this.lblPassWord = new System.Windows.Forms.Label();
            this.lblDelayTime = new System.Windows.Forms.Label();
            this.lblAutoModeCdot = new System.Windows.Forms.Label();
            this.lblPolling = new System.Windows.Forms.Label();
            this.lblStationCodeCdot = new System.Windows.Forms.Label();
            this.lblUserPass = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblValidationStatusUrl = new System.Windows.Forms.Label();
            this.lblDissmentationUrl = new System.Windows.Forms.Label();
            this.lblCdotEnable = new System.Windows.Forms.Label();
            this.lblALert = new System.Windows.Forms.Label();
            this.lblCdot = new System.Windows.Forms.Label();
            this.dgvalertInfo = new System.Windows.Forms.DataGridView();
            this.alert = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panNtes.SuspendLayout();
            this.panCdot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvalertInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNtes
            // 
            this.btnNtes.BackColor = System.Drawing.Color.DarkGreen;
            this.btnNtes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNtes.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNtes.Location = new System.Drawing.Point(327, 12);
            this.btnNtes.Name = "btnNtes";
            this.btnNtes.Size = new System.Drawing.Size(205, 48);
            this.btnNtes.TabIndex = 0;
            this.btnNtes.Text = "NTES Web Service";
            this.btnNtes.UseVisualStyleBackColor = false;
            this.btnNtes.Click += new System.EventHandler(this.btnNtes_Click);
            // 
            // btnCdot
            // 
            this.btnCdot.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCdot.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCdot.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCdot.Location = new System.Drawing.Point(528, 12);
            this.btnCdot.Name = "btnCdot";
            this.btnCdot.Size = new System.Drawing.Size(191, 48);
            this.btnCdot.TabIndex = 1;
            this.btnCdot.Text = "CDOT";
            this.btnCdot.UseVisualStyleBackColor = false;
            this.btnCdot.Click += new System.EventHandler(this.btnCdot_Click);
            // 
            // panNtes
            // 
            this.panNtes.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panNtes.Controls.Add(this.lblMins);
            this.panNtes.Controls.Add(this.btnSave);
            this.panNtes.Controls.Add(this.chkAutoMode);
            this.panNtes.Controls.Add(this.chkAudio);
            this.panNtes.Controls.Add(this.txtNextMinutes);
            this.panNtes.Controls.Add(this.txtStationCode);
            this.panNtes.Controls.Add(this.cmbDataType);
            this.panNtes.Controls.Add(this.chkNtesEnable);
            this.panNtes.Controls.Add(this.lblDataType);
            this.panNtes.Controls.Add(this.lblStationCode);
            this.panNtes.Controls.Add(this.lblNextMinutes);
            this.panNtes.Controls.Add(this.lblAudio);
            this.panNtes.Controls.Add(this.lblAutoModeNtes);
            this.panNtes.Controls.Add(this.lblNtesEnable);
            this.panNtes.Controls.Add(this.lblWebService);
            this.panNtes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panNtes.Location = new System.Drawing.Point(117, 66);
            this.panNtes.Name = "panNtes";
            this.panNtes.Size = new System.Drawing.Size(415, 677);
            this.panNtes.TabIndex = 2;
            // 
            // lblMins
            // 
            this.lblMins.AutoSize = true;
            this.lblMins.Location = new System.Drawing.Point(294, 257);
            this.lblMins.Name = "lblMins";
            this.lblMins.Size = new System.Drawing.Size(42, 20);
            this.lblMins.TabIndex = 14;
            this.lblMins.Text = "Mins";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::ArecaIPIS.Properties.Resources._3688505_check_done_right_accept_ok_icon1;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(137, 428);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // chkAutoMode
            // 
            this.chkAutoMode.AutoSize = true;
            this.chkAutoMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoMode.Location = new System.Drawing.Point(167, 346);
            this.chkAutoMode.Name = "chkAutoMode";
            this.chkAutoMode.Size = new System.Drawing.Size(15, 14);
            this.chkAutoMode.TabIndex = 12;
            this.chkAutoMode.UseVisualStyleBackColor = true;
            // 
            // chkAudio
            // 
            this.chkAudio.AutoSize = true;
            this.chkAudio.Location = new System.Drawing.Point(167, 306);
            this.chkAudio.Name = "chkAudio";
            this.chkAudio.Size = new System.Drawing.Size(15, 14);
            this.chkAudio.TabIndex = 11;
            this.chkAudio.UseVisualStyleBackColor = true;
            // 
            // txtNextMinutes
            // 
            this.txtNextMinutes.Location = new System.Drawing.Point(167, 254);
            this.txtNextMinutes.Name = "txtNextMinutes";
            this.txtNextMinutes.Size = new System.Drawing.Size(121, 26);
            this.txtNextMinutes.TabIndex = 10;
            // 
            // txtStationCode
            // 
            this.txtStationCode.Location = new System.Drawing.Point(167, 204);
            this.txtStationCode.Name = "txtStationCode";
            this.txtStationCode.Size = new System.Drawing.Size(121, 26);
            this.txtStationCode.TabIndex = 9;
            // 
            // cmbDataType
            // 
            this.cmbDataType.FormattingEnabled = true;
            this.cmbDataType.Location = new System.Drawing.Point(167, 145);
            this.cmbDataType.Name = "cmbDataType";
            this.cmbDataType.Size = new System.Drawing.Size(121, 28);
            this.cmbDataType.TabIndex = 8;
            // 
            // chkNtesEnable
            // 
            this.chkNtesEnable.AutoSize = true;
            this.chkNtesEnable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chkNtesEnable.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkNtesEnable.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.chkNtesEnable.Location = new System.Drawing.Point(167, 116);
            this.chkNtesEnable.Margin = new System.Windows.Forms.Padding(0);
            this.chkNtesEnable.Name = "chkNtesEnable";
            this.chkNtesEnable.Size = new System.Drawing.Size(15, 14);
            this.chkNtesEnable.TabIndex = 7;
            this.chkNtesEnable.UseVisualStyleBackColor = true;
            // 
            // lblDataType
            // 
            this.lblDataType.AutoSize = true;
            this.lblDataType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataType.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDataType.Location = new System.Drawing.Point(43, 153);
            this.lblDataType.Name = "lblDataType";
            this.lblDataType.Size = new System.Drawing.Size(94, 20);
            this.lblDataType.TabIndex = 6;
            this.lblDataType.Text = "Data Type  :";
            // 
            // lblStationCode
            // 
            this.lblStationCode.AutoSize = true;
            this.lblStationCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStationCode.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblStationCode.Location = new System.Drawing.Point(23, 204);
            this.lblStationCode.Name = "lblStationCode";
            this.lblStationCode.Size = new System.Drawing.Size(114, 20);
            this.lblStationCode.TabIndex = 5;
            this.lblStationCode.Text = "Station Code  :";
            // 
            // lblNextMinutes
            // 
            this.lblNextMinutes.AutoSize = true;
            this.lblNextMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextMinutes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNextMinutes.Location = new System.Drawing.Point(24, 257);
            this.lblNextMinutes.Name = "lblNextMinutes";
            this.lblNextMinutes.Size = new System.Drawing.Size(113, 20);
            this.lblNextMinutes.TabIndex = 4;
            this.lblNextMinutes.Text = "Next Minutes  :";
            // 
            // lblAudio
            // 
            this.lblAudio.AutoSize = true;
            this.lblAudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAudio.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAudio.Location = new System.Drawing.Point(75, 300);
            this.lblAudio.Name = "lblAudio";
            this.lblAudio.Size = new System.Drawing.Size(62, 20);
            this.lblAudio.TabIndex = 3;
            this.lblAudio.Text = "Audio  :";
            // 
            // lblAutoModeNtes
            // 
            this.lblAutoModeNtes.AutoSize = true;
            this.lblAutoModeNtes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoModeNtes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAutoModeNtes.Location = new System.Drawing.Point(42, 340);
            this.lblAutoModeNtes.Name = "lblAutoModeNtes";
            this.lblAutoModeNtes.Size = new System.Drawing.Size(95, 20);
            this.lblAutoModeNtes.TabIndex = 2;
            this.lblAutoModeNtes.Text = "Auto Mode :";
            // 
            // lblNtesEnable
            // 
            this.lblNtesEnable.AutoSize = true;
            this.lblNtesEnable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNtesEnable.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNtesEnable.Location = new System.Drawing.Point(20, 110);
            this.lblNtesEnable.Name = "lblNtesEnable";
            this.lblNtesEnable.Size = new System.Drawing.Size(117, 20);
            this.lblNtesEnable.TabIndex = 1;
            this.lblNtesEnable.Text = "NTES Enable  :";
            // 
            // lblWebService
            // 
            this.lblWebService.AutoSize = true;
            this.lblWebService.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWebService.ForeColor = System.Drawing.Color.Blue;
            this.lblWebService.Location = new System.Drawing.Point(96, 25);
            this.lblWebService.Name = "lblWebService";
            this.lblWebService.Size = new System.Drawing.Size(178, 31);
            this.lblWebService.TabIndex = 0;
            this.lblWebService.Text = "Web Service";
            // 
            // panCdot
            // 
            this.panCdot.BackColor = System.Drawing.SystemColors.Info;
            this.panCdot.Controls.Add(this.dgvalertInfo);
            this.panCdot.Controls.Add(this.lblMinsCdot);
            this.panCdot.Controls.Add(this.lblSec);
            this.panCdot.Controls.Add(this.txtAlertCount);
            this.panCdot.Controls.Add(this.lblAlertCount);
            this.panCdot.Controls.Add(this.cmbSpeed);
            this.panCdot.Controls.Add(this.chkCdotEnable);
            this.panCdot.Controls.Add(this.chkAutoModeCdot);
            this.panCdot.Controls.Add(this.txtPollingTime);
            this.panCdot.Controls.Add(this.txtStationCodeCdot);
            this.panCdot.Controls.Add(this.txtUserPass);
            this.panCdot.Controls.Add(this.txtDissmentationurl);
            this.panCdot.Controls.Add(this.txtValidationStatus);
            this.panCdot.Controls.Add(this.txtPassword);
            this.panCdot.Controls.Add(this.txtUserName);
            this.panCdot.Controls.Add(this.txtCdotUrl);
            this.panCdot.Controls.Add(this.txtDelayTime);
            this.panCdot.Controls.Add(this.btnSaveCdot);
            this.panCdot.Controls.Add(this.lblSpeed);
            this.panCdot.Controls.Add(this.lblCdotUrl);
            this.panCdot.Controls.Add(this.lblPassWord);
            this.panCdot.Controls.Add(this.lblDelayTime);
            this.panCdot.Controls.Add(this.lblAutoModeCdot);
            this.panCdot.Controls.Add(this.lblPolling);
            this.panCdot.Controls.Add(this.lblStationCodeCdot);
            this.panCdot.Controls.Add(this.lblUserPass);
            this.panCdot.Controls.Add(this.lblUserName);
            this.panCdot.Controls.Add(this.lblValidationStatusUrl);
            this.panCdot.Controls.Add(this.lblDissmentationUrl);
            this.panCdot.Controls.Add(this.lblCdotEnable);
            this.panCdot.Controls.Add(this.lblALert);
            this.panCdot.Controls.Add(this.lblCdot);
            this.panCdot.Location = new System.Drawing.Point(538, 66);
            this.panCdot.Name = "panCdot";
            this.panCdot.Padding = new System.Windows.Forms.Padding(10);
            this.panCdot.Size = new System.Drawing.Size(969, 677);
            this.panCdot.TabIndex = 3;
            this.panCdot.Visible = false;
            // 
            // lblMinsCdot
            // 
            this.lblMinsCdot.AutoSize = true;
            this.lblMinsCdot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinsCdot.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMinsCdot.Location = new System.Drawing.Point(318, 253);
            this.lblMinsCdot.Name = "lblMinsCdot";
            this.lblMinsCdot.Size = new System.Drawing.Size(36, 16);
            this.lblMinsCdot.TabIndex = 31;
            this.lblMinsCdot.Text = "Mins";
            // 
            // lblSec
            // 
            this.lblSec.AutoSize = true;
            this.lblSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSec.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSec.Location = new System.Drawing.Point(318, 171);
            this.lblSec.Name = "lblSec";
            this.lblSec.Size = new System.Drawing.Size(32, 16);
            this.lblSec.TabIndex = 30;
            this.lblSec.Text = "Sec";
            // 
            // txtAlertCount
            // 
            this.txtAlertCount.Location = new System.Drawing.Point(713, 67);
            this.txtAlertCount.Name = "txtAlertCount";
            this.txtAlertCount.Size = new System.Drawing.Size(100, 20);
            this.txtAlertCount.TabIndex = 29;
            // 
            // lblAlertCount
            // 
            this.lblAlertCount.AutoSize = true;
            this.lblAlertCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblAlertCount.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblAlertCount.Location = new System.Drawing.Point(606, 65);
            this.lblAlertCount.Name = "lblAlertCount";
            this.lblAlertCount.Size = new System.Drawing.Size(101, 20);
            this.lblAlertCount.TabIndex = 28;
            this.lblAlertCount.Text = "Alert Count  :";
            // 
            // cmbSpeed
            // 
            this.cmbSpeed.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbSpeed.FormattingEnabled = true;
            this.cmbSpeed.Location = new System.Drawing.Point(202, 128);
            this.cmbSpeed.Name = "cmbSpeed";
            this.cmbSpeed.Size = new System.Drawing.Size(110, 21);
            this.cmbSpeed.TabIndex = 26;
            // 
            // chkCdotEnable
            // 
            this.chkCdotEnable.AutoSize = true;
            this.chkCdotEnable.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCdotEnable.Location = new System.Drawing.Point(202, 97);
            this.chkCdotEnable.Name = "chkCdotEnable";
            this.chkCdotEnable.Size = new System.Drawing.Size(15, 14);
            this.chkCdotEnable.TabIndex = 25;
            this.chkCdotEnable.UseVisualStyleBackColor = true;
            // 
            // chkAutoModeCdot
            // 
            this.chkAutoModeCdot.AutoSize = true;
            this.chkAutoModeCdot.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAutoModeCdot.Location = new System.Drawing.Point(202, 213);
            this.chkAutoModeCdot.Name = "chkAutoModeCdot";
            this.chkAutoModeCdot.Size = new System.Drawing.Size(15, 14);
            this.chkAutoModeCdot.TabIndex = 24;
            this.chkAutoModeCdot.UseVisualStyleBackColor = true;
            // 
            // txtPollingTime
            // 
            this.txtPollingTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPollingTime.Location = new System.Drawing.Point(202, 250);
            this.txtPollingTime.Name = "txtPollingTime";
            this.txtPollingTime.Size = new System.Drawing.Size(110, 20);
            this.txtPollingTime.TabIndex = 23;
            // 
            // txtStationCodeCdot
            // 
            this.txtStationCodeCdot.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtStationCodeCdot.Location = new System.Drawing.Point(202, 292);
            this.txtStationCodeCdot.Name = "txtStationCodeCdot";
            this.txtStationCodeCdot.Size = new System.Drawing.Size(168, 20);
            this.txtStationCodeCdot.TabIndex = 22;
            // 
            // txtUserPass
            // 
            this.txtUserPass.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtUserPass.Location = new System.Drawing.Point(202, 332);
            this.txtUserPass.Name = "txtUserPass";
            this.txtUserPass.Size = new System.Drawing.Size(168, 20);
            this.txtUserPass.TabIndex = 21;
            // 
            // txtDissmentationurl
            // 
            this.txtDissmentationurl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDissmentationurl.Location = new System.Drawing.Point(202, 551);
            this.txtDissmentationurl.Name = "txtDissmentationurl";
            this.txtDissmentationurl.Size = new System.Drawing.Size(168, 20);
            this.txtDissmentationurl.TabIndex = 20;
            // 
            // txtValidationStatus
            // 
            this.txtValidationStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtValidationStatus.Location = new System.Drawing.Point(202, 507);
            this.txtValidationStatus.Name = "txtValidationStatus";
            this.txtValidationStatus.Size = new System.Drawing.Size(168, 20);
            this.txtValidationStatus.TabIndex = 19;
            this.txtValidationStatus.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPassword.Location = new System.Drawing.Point(202, 466);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(168, 20);
            this.txtPassword.TabIndex = 18;
            // 
            // txtUserName
            // 
            this.txtUserName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtUserName.Location = new System.Drawing.Point(202, 421);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(168, 20);
            this.txtUserName.TabIndex = 17;
            // 
            // txtCdotUrl
            // 
            this.txtCdotUrl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCdotUrl.Location = new System.Drawing.Point(202, 373);
            this.txtCdotUrl.Name = "txtCdotUrl";
            this.txtCdotUrl.Size = new System.Drawing.Size(168, 20);
            this.txtCdotUrl.TabIndex = 16;
            // 
            // txtDelayTime
            // 
            this.txtDelayTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDelayTime.Location = new System.Drawing.Point(202, 167);
            this.txtDelayTime.Name = "txtDelayTime";
            this.txtDelayTime.Size = new System.Drawing.Size(110, 20);
            this.txtDelayTime.TabIndex = 15;
            // 
            // btnSaveCdot
            // 
            this.btnSaveCdot.BackColor = System.Drawing.Color.Green;
            this.btnSaveCdot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveCdot.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSaveCdot.Image = global::ArecaIPIS.Properties.Resources._3688505_check_done_right_accept_ok_icon1;
            this.btnSaveCdot.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveCdot.Location = new System.Drawing.Point(407, 605);
            this.btnSaveCdot.Name = "btnSaveCdot";
            this.btnSaveCdot.Size = new System.Drawing.Size(90, 40);
            this.btnSaveCdot.TabIndex = 14;
            this.btnSaveCdot.Text = "Save";
            this.btnSaveCdot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveCdot.UseVisualStyleBackColor = false;
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblSpeed.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSpeed.Location = new System.Drawing.Point(128, 128);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(68, 20);
            this.lblSpeed.TabIndex = 13;
            this.lblSpeed.Text = "Speed  :";
            // 
            // lblCdotUrl
            // 
            this.lblCdotUrl.AutoSize = true;
            this.lblCdotUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblCdotUrl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCdotUrl.Location = new System.Drawing.Point(117, 373);
            this.lblCdotUrl.Name = "lblCdotUrl";
            this.lblCdotUrl.Size = new System.Drawing.Size(79, 20);
            this.lblCdotUrl.TabIndex = 12;
            this.lblCdotUrl.Text = "Cdot Url  :";
            // 
            // lblPassWord
            // 
            this.lblPassWord.AutoSize = true;
            this.lblPassWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPassWord.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPassWord.Location = new System.Drawing.Point(102, 464);
            this.lblPassWord.Name = "lblPassWord";
            this.lblPassWord.Size = new System.Drawing.Size(94, 20);
            this.lblPassWord.TabIndex = 11;
            this.lblPassWord.Text = "PassWord  :";
            // 
            // lblDelayTime
            // 
            this.lblDelayTime.AutoSize = true;
            this.lblDelayTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblDelayTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDelayTime.Location = new System.Drawing.Point(101, 167);
            this.lblDelayTime.Name = "lblDelayTime";
            this.lblDelayTime.Size = new System.Drawing.Size(95, 20);
            this.lblDelayTime.TabIndex = 10;
            this.lblDelayTime.Text = "DelayTime  :";
            // 
            // lblAutoModeCdot
            // 
            this.lblAutoModeCdot.AutoSize = true;
            this.lblAutoModeCdot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblAutoModeCdot.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAutoModeCdot.Location = new System.Drawing.Point(97, 209);
            this.lblAutoModeCdot.Name = "lblAutoModeCdot";
            this.lblAutoModeCdot.Size = new System.Drawing.Size(99, 20);
            this.lblAutoModeCdot.TabIndex = 9;
            this.lblAutoModeCdot.Text = "Auto Mode  :";
            // 
            // lblPolling
            // 
            this.lblPolling.AutoSize = true;
            this.lblPolling.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPolling.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPolling.Location = new System.Drawing.Point(91, 250);
            this.lblPolling.Name = "lblPolling";
            this.lblPolling.Size = new System.Drawing.Size(105, 20);
            this.lblPolling.TabIndex = 8;
            this.lblPolling.Text = "Polling Time  :";
            // 
            // lblStationCodeCdot
            // 
            this.lblStationCodeCdot.AutoSize = true;
            this.lblStationCodeCdot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblStationCodeCdot.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStationCodeCdot.Location = new System.Drawing.Point(82, 292);
            this.lblStationCodeCdot.Name = "lblStationCodeCdot";
            this.lblStationCodeCdot.Size = new System.Drawing.Size(114, 20);
            this.lblStationCodeCdot.TabIndex = 7;
            this.lblStationCodeCdot.Text = "Station Code  :";
            // 
            // lblUserPass
            // 
            this.lblUserPass.AutoSize = true;
            this.lblUserPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblUserPass.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUserPass.Location = new System.Drawing.Point(102, 332);
            this.lblUserPass.Name = "lblUserPass";
            this.lblUserPass.Size = new System.Drawing.Size(94, 20);
            this.lblUserPass.TabIndex = 6;
            this.lblUserPass.Text = "User Pass  :";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblUserName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUserName.Location = new System.Drawing.Point(95, 419);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(101, 20);
            this.lblUserName.TabIndex = 5;
            this.lblUserName.Text = "User Name  :";
            // 
            // lblValidationStatusUrl
            // 
            this.lblValidationStatusUrl.AutoSize = true;
            this.lblValidationStatusUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblValidationStatusUrl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblValidationStatusUrl.Location = new System.Drawing.Point(38, 505);
            this.lblValidationStatusUrl.Name = "lblValidationStatusUrl";
            this.lblValidationStatusUrl.Size = new System.Drawing.Size(158, 20);
            this.lblValidationStatusUrl.TabIndex = 4;
            this.lblValidationStatusUrl.Text = "ValidationStatusUrl  :";
            // 
            // lblDissmentationUrl
            // 
            this.lblDissmentationUrl.AutoSize = true;
            this.lblDissmentationUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblDissmentationUrl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDissmentationUrl.Location = new System.Drawing.Point(53, 549);
            this.lblDissmentationUrl.Name = "lblDissmentationUrl";
            this.lblDissmentationUrl.Size = new System.Drawing.Size(143, 20);
            this.lblDissmentationUrl.TabIndex = 3;
            this.lblDissmentationUrl.Text = "DissmentationUrl  :";
            // 
            // lblCdotEnable
            // 
            this.lblCdotEnable.AutoSize = true;
            this.lblCdotEnable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblCdotEnable.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCdotEnable.Location = new System.Drawing.Point(87, 93);
            this.lblCdotEnable.Name = "lblCdotEnable";
            this.lblCdotEnable.Size = new System.Drawing.Size(109, 20);
            this.lblCdotEnable.TabIndex = 2;
            this.lblCdotEnable.Text = "Cdot Enable  :";
            // 
            // lblALert
            // 
            this.lblALert.AutoSize = true;
            this.lblALert.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblALert.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblALert.Location = new System.Drawing.Point(604, 10);
            this.lblALert.Name = "lblALert";
            this.lblALert.Size = new System.Drawing.Size(133, 31);
            this.lblALert.TabIndex = 1;
            this.lblALert.Text = "Alert Info";
            // 
            // lblCdot
            // 
            this.lblCdot.AutoSize = true;
            this.lblCdot.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCdot.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblCdot.Location = new System.Drawing.Point(127, 10);
            this.lblCdot.Name = "lblCdot";
            this.lblCdot.Size = new System.Drawing.Size(96, 31);
            this.lblCdot.TabIndex = 0;
            this.lblCdot.Text = "CDOT";
            // 
            // dgvalertInfo
            // 
            this.dgvalertInfo.AllowUserToAddRows = false;
            this.dgvalertInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvalertInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvalertInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.alert,
            this.url});
            this.dgvalertInfo.Location = new System.Drawing.Point(545, 110);
            this.dgvalertInfo.Name = "dgvalertInfo";
            this.dgvalertInfo.RowHeadersVisible = false;
            this.dgvalertInfo.Size = new System.Drawing.Size(377, 242);
            this.dgvalertInfo.TabIndex = 32;
            this.dgvalertInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // alert
            // 
            this.alert.HeaderText = "alert1";
            this.alert.Name = "alert";
            // 
            // url
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.url.DefaultCellStyle = dataGridViewCellStyle1;
            this.url.HeaderText = "";
            this.url.Name = "url";
            // 
            // frmInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1509, 812);
            this.Controls.Add(this.panCdot);
            this.Controls.Add(this.panNtes);
            this.Controls.Add(this.btnCdot);
            this.Controls.Add(this.btnNtes);
            this.Name = "frmInterface";
            this.Text = "frmInterface";
            this.Load += new System.EventHandler(this.frmInterface_Load);
            this.panNtes.ResumeLayout(false);
            this.panNtes.PerformLayout();
            this.panCdot.ResumeLayout(false);
            this.panCdot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvalertInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNtes;
        private System.Windows.Forms.Button btnCdot;
        private System.Windows.Forms.Panel panNtes;
        private System.Windows.Forms.Label lblWebService;
        private System.Windows.Forms.Panel panCdot;
        private System.Windows.Forms.CheckBox chkNtesEnable;
        private System.Windows.Forms.Label lblDataType;
        private System.Windows.Forms.Label lblStationCode;
        private System.Windows.Forms.Label lblNextMinutes;
        private System.Windows.Forms.Label lblAudio;
        private System.Windows.Forms.Label lblAutoModeNtes;
        private System.Windows.Forms.Label lblNtesEnable;
        private System.Windows.Forms.Label lblALert;
        private System.Windows.Forms.Label lblCdot;
        private System.Windows.Forms.CheckBox chkAutoMode;
        private System.Windows.Forms.CheckBox chkAudio;
        private System.Windows.Forms.TextBox txtNextMinutes;
        private System.Windows.Forms.TextBox txtStationCode;
        private System.Windows.Forms.ComboBox cmbDataType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblCdotUrl;
        private System.Windows.Forms.Label lblPassWord;
        private System.Windows.Forms.Label lblDelayTime;
        private System.Windows.Forms.Label lblAutoModeCdot;
        private System.Windows.Forms.Label lblPolling;
        private System.Windows.Forms.Label lblStationCodeCdot;
        private System.Windows.Forms.Label lblUserPass;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblValidationStatusUrl;
        private System.Windows.Forms.Label lblDissmentationUrl;
        private System.Windows.Forms.Label lblCdotEnable;
        private System.Windows.Forms.Label lblMins;
        private System.Windows.Forms.TextBox txtDissmentationurl;
        private System.Windows.Forms.TextBox txtValidationStatus;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtCdotUrl;
        private System.Windows.Forms.TextBox txtDelayTime;
        private System.Windows.Forms.Button btnSaveCdot;
        private System.Windows.Forms.TextBox txtAlertCount;
        private System.Windows.Forms.Label lblAlertCount;
        private System.Windows.Forms.ComboBox cmbSpeed;
        private System.Windows.Forms.CheckBox chkCdotEnable;
        private System.Windows.Forms.CheckBox chkAutoModeCdot;
        private System.Windows.Forms.TextBox txtPollingTime;
        private System.Windows.Forms.TextBox txtStationCodeCdot;
        private System.Windows.Forms.TextBox txtUserPass;
        private System.Windows.Forms.Label lblMinsCdot;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.DataGridView dgvalertInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn alert;
        private System.Windows.Forms.DataGridViewTextBoxColumn url;
    }
}
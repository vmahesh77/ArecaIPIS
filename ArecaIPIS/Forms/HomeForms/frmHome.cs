using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ArecaIPIS.Forms.AboutUsForms;
using ArecaIPIS.Forms.HomeForms;
using ArecaIPIS.Forms.settingsForms;
using ArecaIPIS.Forms.UserForms;
using ArecaIPIS.Forms.ViewForms;
using ArecaIPIS.DAL;
namespace ArecaIPIS.Forms
{
    public partial class frmHome : Form
    {
        private Form currentForm;
       
        public frmHome()
        {
            InitializeComponent();
           // OpenFormInPanel(new frmOnlineTrains(this));
           // panHeader.Dock = DockStyle.Fill;
        }
        private frmIndex parentForm;
        public frmHome(frmIndex parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;

        }
        private void OpenFormInPanel(Form form)
        {
            if (currentForm != null)
            {
                currentForm.Close();
                currentForm.Dispose();
            }

            currentForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panForms.Controls.Add(form);
            form.Show();

        }

        internal void ReplaceForm(Form newForm)
        {
            OpenFormInPanel(newForm);
        }
        private void btnFile_Click(object sender, EventArgs e)
        {
            // Show the context menu strip at the location of the button
            cmsFile.Show(btnFile, new Point(0, btnFile.Height));
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            cmsView.Show(btnView, new Point(0, btnFile.Height));
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            cmsSettings.Show(btnSettings, new Point(0, btnFile.Height));
        }

        private void btnDiagnosis_Click(object sender, EventArgs e)
        {
            cmsDiagnosis.Show(btnDiagnosis, new Point(0, btnDiagnosis.Height));
        }

        private void btnVdc_Click(object sender, EventArgs e)
        {
            cmsVDC.Show(btnDiagnosis, new Point(0, btnFile.Height));
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            cmsUser.Show(btnUser, new Point(0, btnFile.Height));
        }

        private void btnAboutUs_Click(object sender, EventArgs e)
        {
            cmsAboutUs.Show(btnAboutUs, new Point(0, btnFile.Height));
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            dateAndTimeTicker.Start();

            BaseClass.SelectionRegionalLanguagesDt = StationConfigurationDb.GetRegionalLanguages();
            StationConfigurationDb.GetStationDetails();
            BaseClass.Platforms = StationConfigurationDb.GetPlatforms();
            BaseClass.setLanguages();
            BaseClass.TrainTypes = TrainInformationDb.GetTrainTypes();
            BaseClass.setDisplayEffects();
            BaseClass.setLetterGap();
            //BaseClass.setEntryEffect();
            BaseClass.setFontSize();
            BaseClass.setinfoDisplay();
            BaseClass.setFormatType();
            BaseClass.setFormats();
            //BaseClass.setIVDOVDSpeed();
            BaseClass.setLetterSpeed();
            //BaseClass.setMessageCharacterGap();
            //BaseClass.setMessageFontSize();
            //BaseClass.setVolume();
            //BaseClass.setMediaType();
            BaseClass.PacketIdentifier = BaseClassDb.GetPacketIdentifier();

        }
        


        private void dateAndTimeTicker_Tick(object sender, EventArgs e)
        {
            lblDateAndTime.Text= DateTime.Now.ToString("MMMM dd, yyyy - HH:mm:ss");
        }

        private void btnOnlineTrains_Click(object sender, EventArgs e)
        {



           BaseClass.indexForm.OpenFormInPanel(new frmOnlineTrains(BaseClass.indexForm));
        }

        private void StationDetailsToolStrip_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmStationDetails(BaseClass.indexForm));
        }

        private void TrainInformationToolStrip_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmTrainInformation(BaseClass.indexForm));
        }

        private void toolStripBoardConfiguration_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmBoardConfiguration(this));
            
        }

        private void toolStripColorConfiguration_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmColorConfiguration(this));

        }

        private void toolStripCCTVSettings_Click(object sender, EventArgs e)
        {
            
                 OpenFormInPanel(new frmLcdTv(this));
        }

        private void btnLcdTV_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmLcdTv(this));
        }

        private void btnNetwork_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmNetwork(this));
           
        }

        private void btnInterface_Click(object sender, EventArgs e)
        {
             // OpenFormInPanel(new frmInterface(this));
          //  BaseClass.indexForm.OpenFormInPanel(new frmInterface(BaseClass.indexForm));
        }

        private void toolStripBoardDiagnosis_Click(object sender, EventArgs e)
        {
          //  OpenFormInPanel(new frmBoardDiagnosis(this));
            BaseClass.indexForm.OpenFormInPanel(new frmBoardDiagnosis(BaseClass.indexForm));
        }

        private void btnCdot_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmCdot(this));
        }

        private void toolStripCreateUser_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmCreateUser(this)); 
        }

        private void btnPA_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmPa(this)); 
        }

        private void toolStripUserGroups_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmUserGroups(this));
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmHelp(this));
        }

        private void toolStripAbout_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmAbout(this));
        }

        private void toolStripIPISHelp_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmHelp(this));
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmReports(this));
        }

        private void toolStripCommonSettings_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmCommonSettings(this));
        }

        private void toolStripRegionalLanguage_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmRegionalLanguageStatus(this));
        }

        private void toolStripDefectiveLines_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmDefectiveLinesTaddb(this));
        }

        private void toolStripAnnouncement_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmAnnounceMentScript(this));
        }

        private void toolStripMessageScript_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmMessageScript(this));
        }

        private void toolStripPlayListConfiguration_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmPlaylist(this));
        }

        private void addStationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmAddStation(this));
        }

        private void btnMessages_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmMessages(this));
        }

        private void btnIntensity_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmIntensity(this));
        }

        private void btnSlogans_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmSlogans(this));
        }

        private void toolStripLanguageSettings_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new FrmLanguageSettings(this));
        }

        private void toolStripRedundancyPc_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmRedundencyPc(this));
        }

        private void btnLink_Click(object sender, EventArgs e)
        {


            OpenFormInPanel(new frmLink(BaseClass.indexForm));
        }

        private void btnMedia_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmPlaylist(this));
        }

        private void addCoachDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmAddCoachData(this));
        }

        private void hubConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaseClass.indexForm.OpenFormInPanel(new frmHubConfiguration(BaseClass.indexForm));
           // OpenFormInPanel(new frmHubConfiguration(this));
        }

        private void panHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panControls_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmHome_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}

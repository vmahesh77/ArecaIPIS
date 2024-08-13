using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.OleDb;

namespace ArecaIPIS.Forms
{
    public partial class frmColorConfiguration : Form
    {
        public frmColorConfiguration()
        {
            InitializeComponent();
        }
        private frmHome parentForm;
        public frmColorConfiguration(frmHome parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;

        }

        private void lblTrainNumber_Click(object sender, EventArgs e)
        {

        }

        private void btnTrainNumber_Click(object sender, EventArgs e)
        {


            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = true;
            //pnltrainNumber.BackColor =  cd.Color;
            cd.FullOpen = true;
            cd.AnyColor = true;
            if(cd.ShowDialog()==DialogResult.OK)
            {
                //pnltrainNumber.BackColor=cd.Color;
            }

        }

        private void grbTrainInfo_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
          



           //string trainNumberColor = ColorTranslator.ToHtml(pnltrainNumber.BackColor);
           //string trainNameColor = ColorTranslator.ToHtml(pnlTrainName.BackColor);
           //string ExptArrivalColor = ColorTranslator.ToHtml(pnlExpectArrival.BackColor);
           //string ADColor = ColorTranslator.ToHtml(pnlAD.BackColor);
           //string Pf = ColorTranslator.ToHtml(pnlPf.BackColor);

           //string RescheduleColor = ColorTranslator.ToHtml(pnlRescheduled.BackColor);
           //string CancelColor = ColorTranslator.ToHtml(pnlCancelled.BackColor);
           //string divertedColor = ColorTranslator.ToHtml(pnlDiverted.BackColor);
           //string Terminatedcolor = ColorTranslator.ToHtml(pnlTerminated.BackColor);
           //string arrivedcolor = ColorTranslator.ToHtml(pnlArrived.BackColor);
           //string IndefiniteLate = ColorTranslator.ToHtml(pnlIndefiniteLate.BackColor);

           //string ScreenColor = ColorTranslator.ToHtml(pnlScreenColor.BackColor);
           //string LinesColor = ColorTranslator.ToHtml(pnlLinesColor.BackColor);
           //string coachColor = ColorTranslator.ToHtml(pnlCoachColor.BackColor);

           //TruecolorDAO.SaveColorsToDatabase(trainNumberColor,trainNameColor,ExptArrivalColor,ADColor,Pf,RescheduleColor,CancelColor,divertedColor,Terminatedcolor,arrivedcolor,IndefiniteLate,ScreenColor,LinesColor,coachColor);

           //enableControls(false);
        }


       


       

      


            
        
          
        
        private static bool IsNamedColor(string input)
        {
            // Check if the input is a named color
            foreach (KnownColor color in Enum.GetValues(typeof(KnownColor)))
            {
                if (string.Equals(color.ToString(), input, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsHexValue(string input)
        {
            // Check if the input is a hexadecimal value
            return Regex.IsMatch(input, "^#(?:[0-9a-fA-F]{3}){1,2}$");
        }

        public static Color ConvertToColor(string input)
        {
            // Check if the input is a named color
            if (IsNamedColor(input))
            {
                return Color.FromName(input);
            }
            // Check if the input is a hexadecimal value
            else if (IsHexValue(input))
            {
                return ColorTranslator.FromHtml(input);
            }
            else
            {
                // Default to black if the input is not recognized
                return Color.Black;
            }
        }

        public void setColorsToAgdb()
        {



            //string trainNumberColor = ColorTranslator.ToHtml(pnltrainNumber.BackColor);
            //string trainNameColor = ColorTranslator.ToHtml(pnlTrainName.BackColor);
            //string ExptArrivalColor = ColorTranslator.ToHtml(pnlExpectArrival.BackColor);
            //string ADColor = ColorTranslator.ToHtml(pnlAD.BackColor);
            //string Pf = ColorTranslator.ToHtml(pnlPf.BackColor);

            //string RescheduleColor = ColorTranslator.ToHtml(pnlRescheduled.BackColor);
            //string CancelColor = ColorTranslator.ToHtml(pnlCancelled.BackColor);
            //string divertedColor = ColorTranslator.ToHtml(pnlDiverted.BackColor);
            //string Terminatedcolor = ColorTranslator.ToHtml(pnlTerminated.BackColor);
            //string arrivedcolor = ColorTranslator.ToHtml(pnlArrived.BackColor);
            //string IndefiniteLate = ColorTranslator.ToHtml(pnlIndefiniteLate.BackColor);

            //string ScreenColor = ColorTranslator.ToHtml(pnlScreenColor.BackColor);
            //string LinesColor = ColorTranslator.ToHtml(pnlLinesColor.BackColor);
            //string coachColor = ColorTranslator.ToHtml(pnlCoachColor.BackColor);




            //DataSet ScreenColorSet = TruecolorDAO.GetAgdbColors();


            //pnltrainNumber.BackColor = ConvertToColor(ScreenColorSet.Tables[0].Rows[0]["trainNumberColor"].ToString());
            //pnlTrainName.BackColor = ConvertToColor(ScreenColorSet.Tables[0].Rows[0]["trainNameColor"].ToString());
            //pnlExpectArrival.BackColor = ConvertToColor(ScreenColorSet.Tables[0].Rows[0]["ExptArrivalColor"].ToString());
            //pnlAD.BackColor = ConvertToColor(ScreenColorSet.Tables[0].Rows[0]["ADColor"].ToString());
            //pnlPf.BackColor = ConvertToColor(ScreenColorSet.Tables[0].Rows[0]["PFColor"].ToString());

            //pnlRescheduled.BackColor = ConvertToColor(ScreenColorSet.Tables[0].Rows[0]["RescheduleColor"].ToString());
            //pnlCancelled.BackColor = ConvertToColor(ScreenColorSet.Tables[0].Rows[0]["CancelColor"].ToString());
            //pnlDiverted.BackColor = ConvertToColor(ScreenColorSet.Tables[0].Rows[0]["divertedColor"].ToString());
            //pnlTerminated.BackColor = ConvertToColor(ScreenColorSet.Tables[0].Rows[0]["Terminatedcolor"].ToString());
            //pnlArrived.BackColor = ConvertToColor(ScreenColorSet.Tables[0].Rows[0]["arrivedcolor"].ToString());
            //pnlScreenColor.BackColor = ConvertToColor(ScreenColorSet.Tables[0].Rows[0]["ScreenColor"].ToString());


            //pnlIndefiniteLate.BackColor = ConvertToColor(ScreenColorSet.Tables[0].Rows[0]["IndefiniteLate"].ToString());
            //pnlLinesColor.BackColor = ConvertToColor(ScreenColorSet.Tables[0].Rows[0]["LinesColor"].ToString());
            //pnlCoachColor.BackColor = ConvertToColor(ScreenColorSet.Tables[0].Rows[0]["CoachColor"].ToString());
    
        }


       

       




        public void ColorButton(Button btn,string _Color)
        {
           

            // Convert hexadecimal color value to Color object
            string hexValue = _Color; // Example hexadecimal color value (red)
            Color color = ColorTranslator.FromHtml(hexValue);

            // Set the background color of the button
            btn.BackColor = color;
            btn.Text = _Color;
        }

        public void CreateColorDialogBox(Button btn)
        {
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = true;
            btn.BackColor = cd.Color;
            cd.FullOpen = true;
            cd.AnyColor = true;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                btn.BackColor = cd.Color;
                string hexColorhex = ColorTranslator.ToHtml(Color.FromArgb(cd.Color.ToArgb()));
                btn.Text = hexColorhex;
               
            }
        }

        private void btnArrRRTTrainNumber_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRRTTrainNumber);
        }

        private void btnArrRRTTrainName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRRTTrainName);
        }

        private void btnArrRRTTrainTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRRTTrainTime);
        }

        private void btnlArrRRTTrainAD_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRRTTrainAD);
        }

        private void btnArrRRTTrainAD_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRRTTrainAD);
        }

        private void btnArrRRTTrainPF_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRRTTrainPF);
        }

        private void btnArrRRTCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRRTCpos);
        }

        private void btnArrWATrainNumber_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrWATrainNumber);
        }

        private void btnWATraiName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnWATraiName);
        }

        private void btnWATrainTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnWATrainTime);
        }

        private void btnWATrainAd_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnWATrainAd);
        }

        private void btnWATrainPf_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnWATrainPf);
        }

        private void btnWATrainCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnWATrainCpos);
        }

        private void btnArrIsArriveTraiNumber_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIsArriveTraiNumber);
        }

        private void btnArrIsArriveTrainName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIsArriveTrainName);
        }

        private void btnArrIsArriveTrainTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIsArriveTrainTime);
        }

        private void btnArrIsArriveTrainAd_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIsArriveTrainAd);
        }

        private void btnArrIsArriveCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIsArriveCpos);
        }

        private void btnArrIsArriveTrainPf_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIsArriveTrainPf);
        }

        private void btnArrHasArriveTrainNumber_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIsArriveTrainPf);
        }

        private void btnArrHasArriveTrainName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrHasArriveTrainName);
        }

        private void btnArrHasArriveTrainTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrHasArriveTrainTime);
        }

        private void btnArrHasArriveTrainAd_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrHasArriveTrainAd);
        }

        private void btnArrHasArriveTrainPf_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrHasArriveTrainPf);
        }

        private void btnArrHasArriveCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrHasArriveCpos);
        }

        private void btnArrRLTrainNumber_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRLTrainNumber);
        }

        private void btnArrRLTrainName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRLTrainName);
        }

        private void btnArrRLTrainTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRLTrainTime);
        }

        private void btnArrRLTrainAd_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRLTrainAd);
        }

        private void btnArrRLTrainPf_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRLTrainPf);
        }

        private void btnArrRLCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRLCpos);
        }

        private void btnArrCancelTrainNumber_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrCancelTrainNumber);
        }

        private void btnArrCancelTrainName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrCancelTrainName);
        }

        private void btnArrCancelTrainTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrCancelTrainTime);
        }

        private void btnArrCancelTrainAd_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrCancelTrainAd);
        }

        private void btnArrCancelTrainPf_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrCancelTrainPf);
        }

        private void btnArrCancelCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrCancelCpos);
        }

        private void btnArrIDFTrainNumber_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIDFTrainNumber);
        }

        private void btnArrIDFTrainName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIDFTrainName);
        }

        private void btnArrIDFTrainTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIDFTrainTime);
        }

        private void btnArrIDFTrainAd_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIDFTrainAd);
        }

        private void btnArrIDFTrainPf_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIDFTrainPf);
        }

        private void btnArrIDFCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrIDFCpos);
        }

        private void btnArrTerminTrainNumber_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrTerminTrainNumber);
        }

        private void btnArrTerminTrainName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrTerminTrainName);
        }

        private void btnArrTerminTrainTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrTerminTrainTime);
        }

        private void btnArrTerminTrainAd_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrTerminTrainAd);
        }

        private void btnArrTerminTrainPf_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrTerminTrainPf);
        }

        private void btnArrTerminCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrTerminCpos);
        }

        private void btnArrPlatformChangeTrainNumber_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrPlatformChangeTrainNumber);
        }

        private void btnArrPlatformChangeTrainName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrPlatformChangeTrainName);
        }

        private void btnArrPlatformChangeTrainTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrPlatformChangeTrainTime);
        }

        private void btnArrPlatformChangeTrainAd_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrPlatformChangeTrainAd);
        }

        private void btnArrPlatformChangeTrainPf_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrPlatformChangeTrainPf);
        }

        private void btnArrPlatformChangeCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrPlatformChangeCpos);
        }



        private void btnDRRTTNo_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDRRTTNo);
        }

        private void btnDRRTTName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDRRTTName);
        }

        private void btnDRRTTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDRRTTime);
        }

        private void btnDRRTAD_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDRRTAD);
        }

        private void btnDRRTPF_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDRRTPF);
        }

        private void btnDRRTCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDRRTCpos);
        }

        private void btnDCanTNo_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDCanTNo);
        }

        private void btnDCanTName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDCanTName);
        }

        private void btnDCanTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDCanTime);
        }

        private void btnDCanAD_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDCanAD);
        }

        private void btnDCanPF_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDCanPF);
        }

        private void btnDCanCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDCanCpos);
        }

        private void btnDReadyLeaveTNo_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDReadyLeaveTNo);
        }

        private void btnDReadyLeaveTName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDReadyLeaveTName);
        }

        private void btnDReadyLeaveTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDReadyLeaveTime);
        }

        private void btnDReadyLeaveAD_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDReadyLeaveAD);
        }

        private void btnDReadyLeavePF_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDReadyLeavePF);
        }

        private void btnDReadyLeaveCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDReadyLeaveCpos);
        }

        private void btnDIsonPFTNo_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDIsonPFTNo);
        }

        private void btnDIsonPFTName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDIsonPFTName);
        }

        private void btnDIsonPFTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDIsonPFTime);
        }

        private void btnDIsonPFAD_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDIsonPFAD);
        }

        private void btnDIsonPF_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDIsonPF);
        }

        private void btnDIsonPFCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDIsonPFCpos);
        }

        private void btnDDepTNo_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDepTNo);
        }

        private void btnDDepTName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDepTName);
        }

        private void btnDDepTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDepTime);
        }

        private void btnDDepTAD_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDepTAD);
        }

        private void btnDDepPF_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDepPF);
        }

        private void btnDDepCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDepCpos);
        }

        private void btnDResTNo_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDResTNo);
        }

        private void btnDResTName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDResTName);
        }

        private void btnDResTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDResTime);
        }

        private void btnDResAD_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDResAD);
        }

        private void btnDResPF_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDResPF);
        }

        private void btnDResCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDResCpos);

        }

        private void btnDDivTNo_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDivTNo);
        }

        private void btnDDivTName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDivTName);
        }

        private void btnDDivTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDivTime);
        }

        private void btnDDivTAD_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDivTAD);
        }

        private void btnDDivPF_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDivPF);
        }

        private void btnDDivCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDivCpos);
        }

        private void btnDDelayDepTNo_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDelayDepTNo);
        }

        private void btnDDelayDepTName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDelayDepTName);
        }

        private void btnDDelayDepTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDelayDepTime);
        }

        private void btnDDelayDepAD_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDelayDepAD);
        }

        private void btnDDelayDepPF_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDelayDepPF);
        }

        private void btnDDelayDepCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDDelayDepCpos);
        }

        private void btnDPFChangTNo_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDPFChangTNo);
        }

        private void btnDPFChangTName_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDPFChangTName);
        }

        private void btnDPFChangTime_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDPFChangTime);
        }

        private void btnDPFChangAD_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDPFChangAD);
        }

        private void btnDPFChangPF_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDPFChangPF);
        }

        private void btnDPFChangCpos_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnDPFChangCpos);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

           
            string Tno = "";
            string TName = "";
            string TExTime = "";
            string TAD = "";
            string TPF = "";
            string TCpos = "";
            int statusCode=0;
            //Status=1 AD=A
            statusCode = 1;
            Tno = btnArrRRTTrainNumber.Text;
            TName = btnArrRRTTrainName.Text;
            TExTime = btnArrRRTTrainTime.Text;
            TAD = btnArrRRTTrainAD.Text;
            TPF = btnArrRRTTrainPF.Text;
            TCpos = btnArrRRTCpos.Text;
            SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);
            //Status=2 AD=A
            statusCode = 2;
            Tno = btnArrWATrainNumber.Text;
            TName = btnWATraiName.Text;
            TExTime = btnWATrainTime .Text;
            TAD = btnWATrainAd.Text;
            TPF = btnWATrainPf.Text;
            TCpos = btnWATrainCpos.Text;
            SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);
            //Status=3 AD=A
            statusCode = 3;
            Tno = btnArrIsArriveTraiNumber.Text;
            TName = btnArrIsArriveTrainName.Text;
            TExTime = btnArrIsArriveTrainTime.Text;
            TAD = btnArrIsArriveTrainAd.Text;
            TPF = btnArrIsArriveTrainPf.Text;
            TCpos = btnArrIsArriveCpos.Text;
            SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);
            //Status=4 AD=A
            statusCode = 4;
            Tno = btnArrHasArriveTrainNumber.Text;
            TName = btnArrHasArriveTrainName.Text;
            TExTime = btnArrHasArriveTrainTime.Text;
            TAD = btnArrHasArriveTrainAd.Text;
            TPF = btnArrHasArriveTrainPf.Text;
            TCpos = btnArrHasArriveCpos.Text;
            SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);
            //Status=5 AD=A
            statusCode = 5;
            Tno = btnArrRLTrainNumber.Text;
            TName = btnArrRLTrainName.Text;
            TExTime = btnArrRLTrainTime.Text;
            TAD = btnArrRLTrainAd.Text;
            TPF = btnArrRLTrainPf.Text;
            TCpos = btnArrRLCpos.Text;
            SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);
            //Status=6 AD=A
            statusCode = 6;
            Tno = btnArrCancelTrainNumber.Text;
            TName = btnArrCancelTrainName.Text;
            TExTime = btnArrCancelTrainTime.Text;
            TAD = btnArrCancelTrainAd.Text;
            TPF = btnArrCancelTrainPf.Text;
            TCpos = btnArrCancelCpos.Text;
            SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);
            //Status=7 AD=A
            statusCode = 7;
            Tno = btnArrIDFTrainNumber.Text;
            TName = btnArrIDFTrainName.Text;
            TExTime = btnArrIDFTrainTime.Text;
            TAD = btnArrIDFTrainAd.Text;
            TPF = btnArrIDFTrainPf.Text;
            TCpos = btnArrIDFCpos.Text;
             SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);
            //Status=8 AD=A
             statusCode = 8;
            Tno = btnArrTerminTrainNumber.Text;
            TName = btnArrTerminTrainName.Text;
            TExTime = btnArrTerminTrainTime.Text;
            TAD = btnArrTerminTrainAd.Text;
            TPF = btnArrTerminTrainPf.Text;
            TCpos = btnArrTerminCpos.Text;
            SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);
            //Status=9 AD=A
            statusCode = 9;
            Tno = btnArrPlatformChangeTrainNumber.Text;
            TName = btnArrPlatformChangeTrainName.Text;
            TExTime = btnArrPlatformChangeTrainTime.Text;
            TAD = btnArrPlatformChangeTrainAd.Text;
            TPF = btnArrPlatformChangeTrainPf.Text;
            TCpos = btnArrPlatformChangeCpos.Text;
            SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);


            //D

            //Status=10 AD=D
            statusCode = 10;
            Tno = btnDRRTTNo.Text;
            TName = btnDRRTTName.Text;
            TExTime = btnDRRTTime.Text;
            TAD = btnDRRTAD.Text;
            TPF = btnDRRTPF.Text;
            TCpos = btnDRRTCpos.Text;
            SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);


            //Status=11 AD=D
            statusCode = 11;
            Tno = btnDCanTNo.Text;
            TName = btnDCanTName.Text;
            TExTime = btnDCanTime.Text;
            TAD = btnDCanAD.Text;
            TPF = btnDCanPF.Text;
            TCpos = btnDCanCpos.Text;
            SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);

            //Status=12 AD=D
            statusCode = 12;
            Tno = btnDReadyLeaveTNo.Text;
            TName = btnDReadyLeaveTName.Text;
            TExTime = btnDReadyLeaveTime.Text;
            TAD = btnDReadyLeaveAD.Text;
            TPF = btnDReadyLeavePF.Text;
            TCpos = btnDReadyLeaveCpos.Text;
            SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);


            //Status=13 AD=D
            statusCode = 13;
            Tno = btnDIsonPFTNo.Text;
            TName = btnDIsonPFTName.Text;
            TExTime = btnDIsonPFTime.Text;
            TAD = btnDIsonPFAD.Text;
            TPF = btnDIsonPF.Text;
            TCpos = btnDIsonPFCpos.Text;
            SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);


            //Status=14 AD=D
            statusCode = 14;
            Tno = btnDDepTNo.Text;
            TName = btnDDepTName.Text;
            TExTime = btnDDepTime.Text;
            TAD = btnDDepTAD.Text;
            TPF = btnDDepPF.Text;
            TCpos = btnDDepCpos.Text;
            SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);


            //Status=15 AD=D
            statusCode = 15;
            Tno = btnDResTNo.Text;
            TName = btnDResTName.Text;
            TExTime = btnDResTime.Text;
            TAD = btnDResAD.Text;
            TPF = btnDResPF.Text;
            TCpos = btnDResCpos.Text;
            SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);


            //Status=16 AD=D
            statusCode = 16;
            Tno = btnDDivTNo.Text;
            TName = btnDDivTName.Text;
            TExTime = btnDDivTime.Text;
            TAD = btnDDivTAD.Text;
            TPF = btnDDivPF.Text;
            TCpos = btnDDivCpos.Text;
            SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);


            //Status=17 AD=D
            statusCode = 17;
            Tno = btnDDelayDepTNo.Text;
            TName = btnDDelayDepTName.Text;
            TExTime = btnDDelayDepTime.Text;
            TAD = btnDDelayDepAD.Text;
            TPF = btnDDelayDepPF.Text;
            TCpos = btnDDelayDepCpos.Text;
            SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);

            //Status=18 AD=D
            statusCode = 18;
            Tno = btnDPFChangTNo.Text;
            TName = btnDPFChangTName.Text;
            TExTime = btnDPFChangTime.Text;
            TAD = btnDPFChangAD.Text;
            TPF = btnDPFChangPF.Text;
            TCpos = btnDPFChangCpos.Text;
            SaveConfigSettingsColor(statusCode, Tno, TName, TExTime, TAD, TPF, TCpos);

            string boardercolor = btnMessageLine.Text;
            string backcolor = btnColorBackground.Text;
            SaveBoarderLInes(boardercolor, backcolor);
            MessageBox.Show("Updated Successfully");
            }
            catch (Exception ex)
            {

                ex.ToString();
            }

          }


    
        public void SaveConfigSettingsColor(int StatusCode, string TNColor, string TNaColor, string TTmeColor, string TADColor, string TPFColor,string Cpos)
        {
            //DataSet ds = new DataSet();
            //OleDbConnection con = new OleDbConnection(cls.connstr);

            //string sql = "update ColorSettings set TrainNo = '" + TNColor + "',TrainName = '" + TNaColor + "',TrainTime = '" + TTmeColor + "',TrainAD = '" + TADColor + "',TrainPF ='" + TPFColor + "',Cpos='" + Cpos + "' where Status= " + StatusCode + "";
            //OleDbCommand cmd = new OleDbCommand(sql, con);
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();
        }

        public void SaveBoarderLInes( string BoarderColor, string Backgroundolcor)
        {
            //DataSet ds = new DataSet();
            //OleDbConnection con = new OleDbConnection(cls.connstr);

            //string sql = "update AGDBBoardColors set BorderColor = '" + BoarderColor + "',BackGroundColor = '" + Backgroundolcor + "'";
            //OleDbCommand cmd = new OleDbCommand(sql, con);
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();
        }



        //private void FillColorsettings()
        //{
        //    DataTable dt = GetAgdbColorSetting();
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {

        //        try
        //        {

              
        //        string Tno = "";
        //        string TName = "";
        //        string ExpTime = "";
        //        string AD = "";
        //        string PF = "";
        //        string Cpos = "";
        //        switch (i)
        //        {
        //            case 0:
                       
        //                Tno = dt.Rows[i]["TrainNo"].ToString();
        //                TName = dt.Rows[i]["TrainName"].ToString();
        //                ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                AD = dt.Rows[i]["TrainAD"].ToString();
        //                PF = dt.Rows[i]["TrainPF"].ToString();
        //                Cpos = dt.Rows[i]["Cpos"].ToString();

        //                ColorButton(btnArrRRTTrainNumber, Tno);
        //                ColorButton(btnArrRRTTrainName, TName);
        //                ColorButton(btnArrRRTTrainTime, ExpTime);
        //                ColorButton(btnArrRRTTrainAD, AD);
        //                ColorButton(btnArrRRTTrainPF, PF);
        //                ColorButton(btnArrRRTCpos, Cpos);

        //                  break;
        //            case 1:
        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();

        //                  ColorButton(btnArrWATrainNumber,Tno);
        //                  ColorButton(btnWATraiName,TName);
        //                  ColorButton(btnWATrainTime,ExpTime);
        //                  ColorButton(btnWATrainAd,AD);
        //                  ColorButton(btnWATrainPf,PF);
        //                  ColorButton(btnWATrainCpos,Cpos);
        //                  break;

        //            case 2:
        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();

        //                  ColorButton(btnArrIsArriveTraiNumber,Tno);
        //                  ColorButton(btnArrIsArriveTrainName,TName);
        //                  ColorButton(btnArrIsArriveTrainTime,ExpTime);
        //                  ColorButton(btnArrIsArriveTrainAd,AD);
        //                  ColorButton(btnArrIsArriveTrainPf,PF);
        //                  ColorButton(btnArrIsArriveCpos,Cpos);
        //                  break;
  
        //            case 3:
        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();
          
        //                  ColorButton(btnArrHasArriveTrainNumber, Tno);
        //                  ColorButton(btnArrHasArriveTrainName, TName);
        //                  ColorButton(btnArrHasArriveTrainTime, ExpTime);
        //                  ColorButton(btnArrHasArriveTrainAd, AD);
        //                  ColorButton(btnArrHasArriveTrainPf, PF);
        //                  ColorButton(btnArrHasArriveCpos, Cpos);
        //                  break;
        //            case 4:
        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();

        //                   ColorButton(btnArrRLTrainNumber, Tno);
        //                  ColorButton(btnArrRLTrainName, TName);
        //                  ColorButton(btnArrRLTrainTime, ExpTime);
        //                  ColorButton(btnArrRLTrainAd, AD);
        //                  ColorButton(btnArrRLTrainPf, PF);
        //                  ColorButton(btnArrRLCpos, Cpos);
        //                  break;
        //            case 5:
        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();
              

        //                  ColorButton(btnArrCancelTrainNumber, Tno);
        //                  ColorButton(btnArrCancelTrainName, TName);
        //                  ColorButton(btnArrCancelTrainTime, ExpTime);
        //                  ColorButton(btnArrCancelTrainAd, AD);
        //                  ColorButton(btnArrCancelTrainPf, PF);
        //                  ColorButton(btnArrCancelCpos, Cpos);
        //                  break;
        //            case 6:
                        
        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();

        //                  ColorButton(btnArrIDFTrainNumber, Tno);
        //                  ColorButton(btnArrIDFTrainName, TName);
        //                  ColorButton(btnArrIDFTrainTime, ExpTime);
        //                  ColorButton(btnArrIDFTrainAd, AD);
        //                  ColorButton(btnArrIDFTrainPf, PF);
        //                  ColorButton(btnArrIDFCpos, Cpos);
        //                  break;
        //            case 7:

        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();


        
        //                  ColorButton(btnArrTerminTrainNumber, Tno);
        //                  ColorButton(btnArrTerminTrainName, TName);
        //                  ColorButton(btnArrTerminTrainTime, ExpTime);
        //                  ColorButton(btnArrTerminTrainAd, AD);
        //                  ColorButton(btnArrTerminTrainPf, PF);
        //                  ColorButton(btnArrTerminCpos, Cpos);
        //                  break;
        //            case 8:

        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();

           

        //                  ColorButton(btnArrPlatformChangeTrainNumber, Tno);
        //                  ColorButton(btnArrPlatformChangeTrainName, TName);
        //                  ColorButton(btnArrPlatformChangeTrainTime, ExpTime);
        //                  ColorButton(btnArrPlatformChangeTrainAd, AD);
        //                  ColorButton(btnArrPlatformChangeTrainPf, PF);
        //                  ColorButton(btnArrPlatformChangeCpos, Cpos);
        //                  break;
        //            case 9:

        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();


        //                  ColorButton(btnDRRTTNo, Tno);
        //                  ColorButton(btnDRRTTName, TName);
        //                  ColorButton(btnDRRTTime, ExpTime);
        //                  ColorButton(btnDRRTAD, AD);
        //                  ColorButton(btnDRRTPF, PF);
        //                  ColorButton(btnDRRTCpos, Cpos);
        //                  break;
        //            case 10:

        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();

        //                  ColorButton(btnDCanTNo, Tno);
        //                  ColorButton(btnDCanTName, TName);
        //                  ColorButton(btnDCanTime, ExpTime);
        //                  ColorButton(btnDCanAD, AD);
        //                  ColorButton(btnDCanPF, PF);
        //                  ColorButton(btnDCanCpos, Cpos);
        //                  break;
        //            case 11:

        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();

        
        //                  ColorButton(btnDReadyLeaveTNo, Tno);
        //                  ColorButton(btnDReadyLeaveTName, TName);
        //                  ColorButton(btnDReadyLeaveTime, ExpTime);
        //                  ColorButton(btnDReadyLeaveAD, AD);
        //                  ColorButton(btnDReadyLeavePF, PF);
        //                  ColorButton(btnDReadyLeaveCpos, Cpos);
        //                  break;
        //            case 12:

        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();
   

        //                  ColorButton(btnDIsonPFTNo, Tno);
        //                  ColorButton(btnDIsonPFTName, TName);
        //                  ColorButton(btnDIsonPFTime, ExpTime);
        //                  ColorButton(btnDIsonPFAD, AD);
        //                  ColorButton(btnDIsonPF, PF);
        //                  ColorButton(btnDIsonPFCpos, Cpos);
        //                  break;
        //            case 13:

        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();

             
        //                  ColorButton(btnDDepTNo, Tno);
        //                  ColorButton(btnDDepTName, TName);
        //                  ColorButton(btnDDepTime, ExpTime);
        //                  ColorButton(btnDDepTAD, AD);
        //                  ColorButton(btnDDepPF, PF);
        //                  ColorButton(btnDDepCpos, Cpos);
        //                  break;
        //            case 14:

        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();
    

        //                  ColorButton(btnDResTNo, Tno);
        //                  ColorButton(btnDResTName, TName);
        //                  ColorButton(btnDResTime, ExpTime);
        //                  ColorButton(btnDResAD, AD);
        //                  ColorButton(btnDResPF, PF);
        //                  ColorButton(btnDResCpos, Cpos);
        //                  break;
        //            case 15:

        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();

          
        //                  ColorButton(btnDDivTNo, Tno);
        //                  ColorButton(btnDDivTName, TName);
        //                  ColorButton(btnDDivTime, ExpTime);
        //                  ColorButton(btnDDivTAD, AD);
        //                  ColorButton(btnDDivPF, PF);
        //                  ColorButton(btnDDivCpos, Cpos);
        //                  break;
        //            case 16:

        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();

        
        //                  ColorButton(btnDDelayDepTNo, Tno);
        //                  ColorButton(btnDDelayDepTName, TName);
        //                  ColorButton(btnDDelayDepTime, ExpTime);
        //                  ColorButton(btnDDelayDepAD, AD);
        //                  ColorButton(btnDDelayDepPF, PF);
        //                  ColorButton(btnDDelayDepCpos, Cpos);
        //                  break;
        //            case 17:

        //                  Tno = dt.Rows[i]["TrainNo"].ToString();
        //                  TName = dt.Rows[i]["TrainName"].ToString();
        //                  ExpTime = dt.Rows[i]["TrainTime"].ToString();
        //                  AD = dt.Rows[i]["TrainAD"].ToString();
        //                  PF = dt.Rows[i]["TrainPF"].ToString();
        //                  Cpos = dt.Rows[i]["Cpos"].ToString();
 

        //                  ColorButton(btnDPFChangTNo, Tno);
        //                  ColorButton(btnDPFChangTName, TName);
        //                  ColorButton(btnDPFChangTime, ExpTime);
        //                  ColorButton(btnDPFChangAD, AD);
        //                  ColorButton(btnDPFChangPF, PF);
        //                  ColorButton(btnDPFChangCpos, Cpos);
        //                  break;
                        

           
                        
        //        }

        //        }
        //        catch (Exception ex)
        //        {

        //            ex.ToString();
        //        } 
        //    }

        //        DataTable dtboarder = GetBorderDetails();
        //        if (dtboarder.Rows.Count>0)
        //        {
        //            string bordercolor=dtboarder.Rows[0]["BorderColor"].ToString();
        //           string backcolor= dtboarder.Rows[0]["BackGroundColor"].ToString();
        //           ColorButton(btnColorBackground, backcolor);
        //           ColorButton(btnBorderlInes, bordercolor);
                    
        //        }


            
        //}
        //public DataTable GetAgdbColorSetting()
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {

           
        //    DataSet ds = new DataSet();
        //    OleDbConnection con = new OleDbConnection(cls.connstr);
        //    string Sql = "select * from ColorSettings";
        //    OleDbDataAdapter da = new OleDbDataAdapter(Sql, con);
        //    da.Fill(dt);
        //    }
        //    catch (Exception ex)
        //    {

        //        ex.ToString();
        //    }
        //    return dt;
           
        //}

        //public DataTable GetBorderDetails()
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {


        //        DataSet ds = new DataSet();
        //        OleDbConnection con = new OleDbConnection(cls.connstr);
        //        string Sql = "select * from AGDBBoardColors";
        //        OleDbDataAdapter da = new OleDbDataAdapter(Sql, con);
        //        da.Fill(dt);
        //    }
        //    catch (Exception ex)
        //    {

        //        ex.ToString();
        //    }
        //    return dt;

        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnColorBackground_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnColorBackground);
        }

        private void btnBorderlInes_Click(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnMessageLine);
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblCPos_Click(object sender, EventArgs e)
        {

        }

        private void btnArrRRTTrainNumber_Click_1(object sender, EventArgs e)
        {
            CreateColorDialogBox(btnArrRRTTrainNumber);
        }
    }
}

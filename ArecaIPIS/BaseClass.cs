using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using ArecaIPIS.Server_Classes;

namespace ArecaIPIS
{
    class BaseClass
    {
       
        public static string boardType = "";
        public static int regionalGapCode =OnlineTrainsDao.GetTopRegGapCode();
        public static int gap = 10;
        public static int noOfLines = 1;

        public static int timeDelay = 10;
        public static string CurrentLang = "";
        public static int trainsCount = 0;
        public static string trainStatus = "";
        public static DataGridViewRow currentdatgridRow;
        public static List<byte> windowsDataPacket = new List<byte>();

        public static string currentTrainStatusName = "";
        public static string currentTrainName = "";
        public static string currentStatus = "";
        public static string currentCity = "";
        public static List<string> trainStatusNamesList = new List<string>();
        public static List<int> trainStatusPkeysList = new List<int>();
        public static string langSequence = "";
        public static List<int> NormalWindows = new List<int>();
        public static List<int> SpecialWindows = new List<int>();
        public static byte[] finalTaddbETX = new byte[] { 03, 00, 00, 04 };
        public static byte[] stratingBytes = new byte[] { 00, 00, 00, 00, 00, 00 };
        public static byte[] endingBytes = new byte[] { 255, 255 };
        public static byte[] emptyWindow = new byte[] { 255, 255, 255, 255 };
        public static byte[] characterString = new byte[] { 00, 00, 00, 00, 01 };
        public static byte[] Seperators = new byte[] { 231, 00};

        public static byte[] AgdbExptSeperators=PfdbController.ConvertDecimalNumberTOByteArray(67);
        public static byte[] AgdbAdSeperators = PfdbController.ConvertDecimalNumberTOByteArray(125);
        public static byte[] AgdbPfSeperators = PfdbController.ConvertDecimalNumberTOByteArray(154);
        public static byte[] AgdbEndBoardSeperators = PfdbController.ConvertDecimalNumberTOByteArray(192);


        public static List<string> specialStatusData = new List<string>();
        public static byte[] ExptTimeSeperators =PfdbController.ConvertDecimalNumberTOByteArray(250);
        public static byte[] ADSeperators = PfdbController.ConvertDecimalNumberTOByteArray(295);
        public static byte[] PFSeperators = PfdbController.ConvertDecimalNumberTOByteArray(310);
        public static string TaddbWindowsEightbit;
        public static string TaddbWindowsNinthbit;
        public static string TaddbWindowsTenthbit;
        public static string TaddbWindowsEleventhbit;
        public static int SelectedTDBRows = 0;
        public static List<byte> taddbDataPacket = new List<byte>();
        public static List<byte> hindiTaddbDataPacket = new List<byte>();
        public static List<DataGridViewRow> TaddbRows = new List<DataGridViewRow>();
        public static DataTable SelectionRegionalLanguagesDt = new DataTable();
        public static DataTable DisplayEffectsDt = new DataTable();
        public static DataTable LetterSpeedDt = new DataTable();
        public static DataTable FormatTypeDt = new DataTable();
        public static DataTable FormatsDt = new DataTable();
        public static DataTable FontSizeDt = new DataTable();
        public static DataTable LetterGapDt = new DataTable();
        public static DataTable infoDisplayDt = new DataTable();
        public static DataTable SpeedDt = new DataTable();
        public static DataTable MediaTypeDt = new DataTable();
        public static DataTable VolumeDt = new DataTable();
        public static DataTable EntryEffectDt = new DataTable();
        public static DataTable MessageFontSizeDt = new DataTable();
        public static DataTable MessageCharacterGapDt = new DataTable();
        public static DataTable EthernetPorts = new DataTable();
        public static DataTable PacketIdentifier = new DataTable();
        public static int StationPkId { get; set; }
        public static string StationName { get; set; }
        public static string StationCode { get; set; }
        public static string DivisionCode { get; set; }
        public static string RegionalLanguage1pk { get; set; }
        public static string UpStationCode { get; set; }
        public static string DownStationCode { get; set; }
        public static int OnlineRows { get; set; }
        public static int PortNo { get; set; }
        public static int MainsCoachDisplay { get; set; }
        public static int NoOfPlatforms { get; set; }

        public static List<string> Languages { get; set; } = new List<string>();
        public static List<string> Platforms { get; set; } = new List<string>();
        public static List<string> DisplayEffects { get; set; } = new List<string>();
        public static List<string> LetterSpeedlist { get; set; } = new List<string>();
        public static List<string> TrainTypes { get; set; } = new List<string>();
        public static List<string> FormatTypeList { get; set; } = new List<string>();

        public static List<string> FormatsList { get; set; } = new List<string>();
        public static List<string> infoDisplayList { get; set; } = new List<string>();
        public static List<string> FontSizeList { get; set; } = new List<string>();

        public static List<string> LetterGapList { get; set; } = new List<string>();

        public static List<string> SpeedList { get; set; } = new List<string>();
        public static List<string> MediaTypeList { get; set; } = new List<string>();

        public static List<string> VolumeList { get; set; } = new List<string>();
        public static List<string> EntryEffectList { get; set; } = new List<string>();
        public static List<string> MessageFontSizeList { get; set; } = new List<string>();

        public static List<string> MessageCharacterGapList { get; set; } = new List<string>();


        public static List<int> languageSequencepk = new List<int>();

        public static int CurrentTrainIndex = 0;
        static BaseClass()
        {
            // Initialize the Languages list here if needed
            // Example: Languages = new List<string>();
        }
        public static int convertBinaryToDecimal(string binaryValue)
        {


            int decimalValue = Convert.ToInt32(binaryValue, 2); // Convert binary to decimal

            return decimalValue;


        }
        public static string convertDecimalToBinary(int decimalValue)
        {

            string binaryValue = Convert.ToString(decimalValue, 2); // Convert decimal to binary

            // Ensure the binary string is at least 3 characters wide
            string paddedBinaryValue = binaryValue.PadLeft(3, '0');

            return paddedBinaryValue;


        }
        public static void GetIndexForm()
            {
            frmIndex frmIndex=null;
            Form form = Application.OpenForms["frmIndex"];

            if (form != null)
            {
                frmIndex = (frmIndex)form;
               
            }
            indexForm = frmIndex;
        }

        public static frmIndex indexForm=null;
        public static void setLanguages()
        {
            Languages.Clear();
            int[] regionalLanguageIds = RegionalLanguage1pk.Split(',').Select(int.Parse).ToArray();
            foreach (DataRow row in SelectionRegionalLanguagesDt.Rows)
            {
                // Assuming "Pkey_Language" is the name of your primary key column for languages
                int languagePK = Convert.ToInt32(row["Pkey_Language"]);

                // Check if the language primary key is present in the regionalLanguageIds array
                if (regionalLanguageIds.Contains(languagePK))
                {
                    string language = row["LanguageName"].ToString();
                    Languages.Add(language);
                }
            }
        }
        public static void setDisplayEffects()
        {
            DisplayEffects.Clear();
            DisplayEffectsDt = BaseClassDb.GetDisplayEffects();

            foreach (DataRow row in DisplayEffectsDt.Rows)
            {
                DisplayEffects.Add(row["Name"].ToString());
            }
        }
        public static void setLetterSpeed()
        {
            LetterSpeedlist.Clear();
            LetterSpeedDt = BaseClassDb.GetLetterSpeed();

            foreach (DataRow row in LetterSpeedDt.Rows)
            {
                LetterSpeedlist.Add(row["LetterSpeed"].ToString());
            }
        }
        public static void setinfoDisplay()
        {
            infoDisplayList.Clear();
            infoDisplayDt = BaseClassDb.GetinfoDisplay();

            foreach (DataRow row in infoDisplayDt.Rows)
            {
                infoDisplayList.Add(row["Info_Displayed"].ToString());
            }
        }
        //public static void setIVDOVDSpeed()
        //{
        //    LetterSpeedlist.Clear();
        //    LetterSpeedDt = BaseClassDb.GetIVDOVDSpeed();

        //    foreach (DataRow row in LetterSpeedDt.Rows)
        //    {
        //        LetterSpeedlist.Add(row["Name"].ToString());
        //    }
        //}
        public static void setFormatType()
        {
            FormatTypeList.Clear();
            FormatTypeDt = BaseClassDb.GetFormatType();

            foreach (DataRow row in FormatTypeDt.Rows)
            {
                FormatTypeList.Add(row["FormatType"].ToString());
            }
        }

        public static void setFormats()
        {
            FormatsList.Clear();
            FormatsDt = BaseClassDb.GetFormats();

            foreach (DataRow row in FormatsDt.Rows)
            {
                FormatsList.Add(row["Format"].ToString());
            }
        }
        public static void setFontSize()
        {
            FontSizeList.Clear();
            FontSizeDt = BaseClassDb.GetFontSize();

            foreach (DataRow row in FontSizeDt.Rows)
            {
                FontSizeList.Add(row["Size"].ToString());
            }
        }
        public static string GetFontSize(int fontPrimaryKey)
        {
            //DataTable FontSizeDt = BaseClassDb.GetFontSize();

            foreach (DataRow row in FontSizeDt.Rows)
            {
                // Assuming "Pkey_Fonts" is the name of your primary key column for fonts
                int PK = Convert.ToInt32(row["Pkey_Fonts"]);

                // Check if the primary key matches the provided key
                if (PK == fontPrimaryKey)
                {
                    string value = row["Size"].ToString();
                    return value;
                }
            }
            return null;
        }
        public static string GetLetterGap(int Key)
        {
           

            foreach (DataRow row in LetterGapDt.Rows)
            {
                // Assuming "Pkey_Fonts" is the name of your primary key column for fonts
                int PK = Convert.ToInt32(row["Pkey_LetterGap"]);

                // Check if the primary key matches the provided key
                if (PK == Key)
                {
                    string value = row["LetterGap"].ToString();
                    return value;
                }
            }
            return null;
        }

        public static string GetLetterSpeed(int Key)
        {


            foreach (DataRow row in LetterSpeedDt.Rows)
            {
                // Assuming "Pkey_Fonts" is the name of your primary key column for fonts
                int PK = Convert.ToInt32(row["Pkey_LetterSpeed"]);

                // Check if the primary key matches the provided key
                if (PK == Key)
                {
                    string value = row["LetterSpeed"].ToString();
                    return value;
                }
            }
            return null;
        }
        public static string GetFormattype(int Key)
        {


            foreach (DataRow row in FormatsDt.Rows)
            {
                // Assuming "Pkey_Fonts" is the name of your primary key column for fonts
                int PK = Convert.ToInt32(row["Pkey_FormatName"]);

                // Check if the primary key matches the provided key
                if (PK == Key)
                {
                    string value = row["Format"].ToString();
                    return value;
                }
            }
            return null;
        }

        public static string GetDisplayeffect(int Key)
        {


            foreach (DataRow row in DisplayEffectsDt.Rows)
            {
                // Assuming "Pkey_Fonts" is the name of your primary key column for fonts
                int PK = Convert.ToInt32(row["Pkey_DisplayEffect"]);

                // Check if the primary key matches the provided key
                if (PK == Key)
                {
                    string value = row["Name"].ToString();
                    return value;
                }
            }
            return null;
        }

        public static string GetinfoDisplayed(int Key)
        {


            foreach (DataRow row in infoDisplayDt.Rows)
            {
                // Assuming "Pkey_Fonts" is the name of your primary key column for fonts
                int PK = Convert.ToInt32(row["Pk_Info_Displayed"]);

                // Check if the primary key matches the provided key
                if (PK == Key)
                {
                    string value = row["Info_Displayed"].ToString();
                    return value;
                }
            }
            return null;
        }

        public static void RecallBoards()
        {
            EthernetPorts = HubConfigurationDb.GetEthernetPorts();
        }

            public static void setLetterGap()
        {
            LetterGapList.Clear();
            LetterGapDt = BaseClassDb.GetLetterGap();

            foreach (DataRow row in LetterGapDt.Rows)
            {
                LetterGapList.Add(row["LetterGap"].ToString());
            }
        }
        //public static void setMediaType()
        //{
        //    VolumeList.Clear();
        //    LetterSpeedDt = BaseClassDb.GetLetterSpeed();

        //    foreach (DataRow row in LetterSpeedDt.Rows)
        //    {
        //        MediaTypeList.Add(row["Name"].ToString());
        //    }
        //}
        //public static void setVolume()
        //{
        //    LetterSpeedlist.Clear();
        //    LetterSpeedDt = BaseClassDb.GetLetterSpeed();

        //    foreach (DataRow row in LetterSpeedDt.Rows)
        //    {
        //        VolumeList.Add(row["Name"].ToString());
        //    }
        //}
        //public static void setEntryEffect()
        //{
        //    EntryEffectList.Clear();
        //    LetterSpeedDt = BaseClassDb.GetLetterSpeed();

        //    foreach (DataRow row in LetterSpeedDt.Rows)
        //    {
        //        EntryEffectList.Add(row["Name"].ToString());
        //    }
        //}
        //public static void setMessageFontSize()
        //{
        //    MessageFontSizeList.Clear();
        //    LetterSpeedDt = BaseClassDb.GetLetterSpeed();

        //    foreach (DataRow row in LetterSpeedDt.Rows)
        //    {
        //        MessageFontSizeList.Add(row["Name"].ToString());
        //    }
        //}
        //public static void setMessageCharacterGap()
        //{
        //    MessageCharacterGapList.Clear();
        //    LetterSpeedDt = BaseClassDb.GetLetterSpeed();

        //    foreach (DataRow row in LetterSpeedDt.Rows)
        //    {
        //        MessageCharacterGapList.Add(row["Name"].ToString());
        //    }
        //}

       
        public static DataTable GetAllStatusDt = OnlineTrainsDao.GetAllStatus();

        public static string selectTrainsDatabase;
        public static List<string> arrivalStatus = new List<string>();
        public static List<string> DepatureStatus = new List<string>();




       
    

        public static string getStatusName(string lang, string AD, string status)
        {
            string langStatus="";
            string statusfor = "";
            string StatusNa = "";
            foreach (DataRow row in GetAllStatusDt.Rows)
            {
                statusfor = row["StatusFor"].ToString();
                StatusNa = row["StatusName"].ToString();
                if (statusfor==AD&&StatusNa==status)
                {
                    if (lang == "eng")
                    {
                        langStatus = row["StatusName"].ToString();
                    }
                    else if (lang == "hin")
                    {
                        langStatus = row["HStatus"].ToString();
                    }
                    else if (lang == "reg")
                    {
                        langStatus = row["RStatus"].ToString();
                    }


                }
            }
            return langStatus;
        }
        public static Byte GetSerialNumber()
        {
            int Sno = Server.SerialNumber;
            Server.SerialNumber++;
            if (Server.SerialNumber > 255)
            {
                Server.SerialNumber = 0;
            }
            return (byte)Sno;
        }

        


    

       

    }
}

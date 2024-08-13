using ArecaIPIS.Classes;
using ArecaIPIS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArecaIPIS.Server_Classes
{
    class PfdbController
    {


       

        public static byte[] ConvertHexStringToByteArray(string hexString)
        {
            // Split the string into individual hex values
            string[] hexValues = hexString.Split(' ');

            // Create a byte array to hold the converted values
            byte[] byteArray = new byte[hexValues.Length];

            // Convert each hex value to a byte and store it in the array
            for (int i = 0; i < hexValues.Length; i++)
            {
                // Ensure each hex value is two characters long
                string hexValue = hexValues[i].PadLeft(2, '0');
                byteArray[i] = Convert.ToByte(hexValue, 16);
            }

            return byteArray;
        }


        public static string hexString = "00 00 00 00 00 00 AA CC 04 04 6F 00 83 00 FD 02 81 02 00 01 00 C0 00 10 00 01 00 05 21 05 00 B8 00 01 00 C0 00 20 00 11 00 00 21 05 01 49 00 01 00 C0 00 20 00 11 00 00 01 05 01 78 00 01 00 2F 00 20 00 11 00 00 21 05 01 81 00 30 00 C0 00 20 00 19 00 00 01 05 01 96 00 30 00 C0 00 18 00 11 00 00 01 05 01 E3 00 01 00 C0 00 10 00 01 00 00 01 05 02 24 00 30 00 C0 00 10 00 09 00 00 01 05 02 2D 00 30 00 C0 00 08 00 01 00 00 01 05 02 70 00 01 00 C0 00 20 00 11 00 05 01 0F 02 B3 00 01 00 C0 00 10 00 01 00 05 21 0F 02 BC 00 01 00 C0 00 20 00 11 00 05 01 0F 03 79 00 01 00 C0 00 10 00 01 00 05 20 0F 03 82 FF FF 00 00 00 00 01 00 53 00 48 00 41 00 4C 00 49 00 4D 00 41 00 52 00 20 00 20 00 20 00 20 00 20 00 20 00 4C 00 4F 00 4B 00 41 00 4D 00 41 00 4E 00 59 00 41 00 20 00 20 00 20 00 54 00 49 00 4C 00 41 00 4B 00 20 00 20 00 20 00 54 00 45 00 52 00 4D 00 49 00 4E 00 55 00 53 00 20 00 20 00 20 00 53 00 41 00 4D 00 41 00 52 00 53 00 41 00 54 00 41 00 20 00 20 00 20 00 53 00 46 00 20 00 20 00 20 00 45 00 58 00 50 00 52 00 45 00 53 00 53 FF FF 00 00 00 00 01 00 31 00 32 00 31 00 35 00 32 E7 00 00 43 00 32 00 33 00 3A 00 33 00 34 E7 00 00 7B 00 41 E7 00 00 9A 00 31 E7 00 00 C0 FF FF 00 00 00 00 01 FF FF FF FF 00 00 00 00 01 00 31 00 32 00 31 00 35 00 32 E7 00 00 43 FF FF 00 00 00 00 01 00 45 00 4E 00 47 E7 00 00 43 00 53 00 31 00 33 E7 00 00 58 00 50 00 57 00 44 E7 00 00 6D 00 47 00 45 00 4E E7 00 00 82 00 47 00 45 00 4E E7 00 00 97 00 4C 00 41 00 44 E7 00 00 AC 00 53 00 31 00 32 E7 00 00 C1 FF FF 00 00 00 00 01 00 53 00 4C 00 52 E7 00 00 43 00 48 00 31 E7 00 00 58 00 41 00 33 E7 00 00 6D 00 41 00 32 E7 00 00 82 00 42 00 33 E7 00 00 97 00 42 00 32 E7 00 00 AC 00 42 00 31 E7 00 00 C1 FF FF 00 00 00 00 01 FF FF FF FF 00 00 00 00 01 00 50 00 43 E7 00 00 43 00 53 00 31 00 31 E7 00 00 58 00 53 00 31 00 30 E7 00 00 6D 00 53 00 39 E7 00 00 82 00 53 00 38 E7 00 00 97 00 53 00 37 E7 00 00 AC 00 53 00 36 E7 00 00 C1 FF FF 00 00 00 00 01 00 53 00 35 E7 00 00 43 00 53 00 34 E7 00 00 58 00 53 00 33 E7 00 00 6D 00 53 00 32 E7 00 00 82 00 53 00 31 E7 00 00 97 00 53 00 4C 00 52 E7 00 00 AC 00 47 00 52 00 44 E7 00 00 C1 FF FF 00 00 00 00 01 FF FF FF FF 00 00 00 00 01 00 53 00 74 00 72 00 6F 00 6E 00 67 00 20 00 20 00 20 00 57 00 69 00 6E 00 64 00 73 00 20 00 20 00 20 00 69 00 73 00 20 00 20 00 20 00 4C 00 69 00 6B 00 65 00 6C 00 79 00 20 00 20 00 20 00 74 00 6F 00 20 00 20 00 20 00 6F 00 63 00 63 00 75 00 72 00 20 00 20 00 20 00 6F 00 76 00 65 00 72 00 20 00 20 00 20 00 41 00 72 00 69 00 79 00 61 00 6C 00 75 00 72 00 20 00 20 00 20 00 64 00 69 00 73 00 74 00 72 00 69 00 63 00 74 00 20 00 20 00 20 00 6F 00 66 00 20 00 20 00 20 00 54 00 61 00 6D 00 69 00 6C 00 20 00 20 00 20 00 4E 00 61 00 64 00 75 00 2E FF FF 00 00 00 00 01 FF FF FF FF 00 00 00 00 01 09 24 09 2E 09 3F 09 32 09 28 09 3E 09 21 09 41 00 20 00 20 00 20 00 20 00 20 00 20 09 15 09 47 00 20 00 20 00 20 00 20 00 20 00 20 09 05 09 30 09 3F 09 2F 09 3E 09 32 09 41 09 30 00 20 00 20 00 20 00 20 00 20 00 20 09 1C 09 3F 09 32 09 47 00 20 00 20 00 20 00 20 00 20 00 20 09 2E 09 47 09 02 00 20 00 20 00 20 00 20 00 20 00 20 09 24 09 47 09 1C 09 3C 00 20 00 20 00 20 00 20 00 20 00 20 09 39 09 35 09 3E 09 0F 09 01 00 20 00 20 00 20 00 20 00 20 00 20 09 1A 09 32 09 28 09 47 00 20 00 20 00 20 00 20 00 20 00 20 09 15 09 40 00 20 00 20 00 20 00 20 00 20 00 20 09 38 09 02 09 2D 09 3E 09 35 09 28 09 3E 00 20 00 20 00 20 00 20 00 20 00 20 09 39 09 48 00 2E FF FF 03 2A 8C 04 00 00 00 00 00 00 ";
      //  public static string hexString = "00 00 00 00 00 00 AA CC 03 08 7B 00 A1 00 FD 2D 81 02 00 01 01 50 00 10 00 01 00 00 21 0A 01 60 00 01 00 3A 00 10 00 01 00 02 21 0A 01 69 00 3B 00 FA 00 10 00 01 00 05 21 0A 01 7A 00 FE 01 50 00 10 00 01 00 02 21 0A 01 C3 FF FF 00 00 00 00 01 FF FF FF FF 01 00 00 00 01 00 30 00 38 00 36 00 37 00 39 FF FF 01 00 00 00 01 00 4D 00 45 00 44 00 49 00 4E 00 49 00 50 00 55 00 52 00 20 00 20 00 20 00 41 00 44 00 52 00 41 00 20 00 20 00 20 00 4D 00 45 00 4D 00 55 00 20 00 20 00 20 00 53 00 50 00 45 00 43 00 49 00 41 00 4C FF FF 01 00 00 00 01 00 31 00 33 00 3A 00 32 00 33 E7 00 01 29 00 41 E7 00 01 35 00 31 FF FF 03 BB A9 04";
        public static byte[] ConvertHexToByteArray(byte[] hexValues)
        {
            byte[] byteArray = new byte[hexValues.Length];
            
               
            for (int i = 0; i < hexValues.Length; i++)
            {
                // Convert hex to byte
                byteArray[i] = Convert.ToByte(hexValues[i]);
            }
           
            return byteArray;
        }


        public static string ByteArrayToString(byte[] byteArray)
        {
            return BitConverter.ToString(byteArray).Replace("-", " ");
        }
        public static byte[] ConvertTextToHexWithSpaceToByteArray(string textInput)
        {
            List<byte> byteArray = new List<byte>();
            byteArray.Clear();


            foreach (char c in textInput)
            {
                int asciiValue = (int)c;
                byte byteValue = (byte)asciiValue;

               
                byteArray.Add(byteValue);
                byteArray.Add(0x00); // Add "00" between each byte
            }
            if (byteArray.Count >= 2)
            {
                byteArray.RemoveAt(byteArray.Count - 1);
            }

            byte[] data = byteArray.ToArray();
            byte[] finalArray = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                // Convert hex to byte
                finalArray[i] = Convert.ToByte(data[i]);
            }
            return finalArray;
            
        }


      

        public static byte[] firstPacketByte(int startPacket,string SourceipAdress,string destinationIpAdress,int packetSerialNumer,int packetType)
        {
            string[] sourceOctets = SourceipAdress.Split('.');
            string[] destinationOctets = destinationIpAdress.Split('.');
            byte[] b = new byte[12];
            b[0] = Convert.ToByte("AA", 16);
            b[1]= Convert.ToByte("CC", 16);           
            b[2] = Convert.ToByte(startPacket);
            b[3] = 0;
            b[4] = 0;
            b[5] = Convert.ToByte(destinationOctets[2]);
            b[6] = Convert.ToByte(destinationOctets[3]);
            b[7] = Convert.ToByte(sourceOctets[2]);
            b[8] = Convert.ToByte(sourceOctets[3]);
            b[9] = Convert.ToByte(packetSerialNumer);
            b[10] = Convert.ToByte(packetType);
            b[11] = Convert.ToByte(02);
            return b;
        }


        public static void taddbWindowsPacketFormation(string ipadress)
        {
            int reverseVedio = 0;
            int speed = 0;
            int effectCode = 0;
            int letterSize = 0;
            int gap = 0;
            int timeDelay = 0;
            
            DataTable boardConfigdt = BoardConfigurationDb.getBoardConfiguration(ipadress);
            foreach (DataRow row in boardConfigdt.Rows)
            {
                BaseClass.langSequence = row["DisplaySequence"].ToString();
                reverseVedio = Convert.ToInt32(row["VideoType"].ToString());
                speed = Convert.ToInt32(row["LetterSpeed"].ToString());
                effectCode = Convert.ToInt32(row["DisplayEffect"].ToString());
                letterSize = Convert.ToInt32(row["FontSize"].ToString());
                gap = Convert.ToInt32(row["LetterGap"].ToString());
                timeDelay = Convert.ToInt32(row["DelayTime"].ToString());
            }
            BaseClass.gap = gap;
            BaseClass.timeDelay = timeDelay;
            BaseClass.TaddbWindowsEightbit = reverseVedio + "0000" + BaseClass.convertDecimalToBinary(speed);
            BaseClass.TaddbWindowsNinthbit = "0000" + BaseClass.convertDecimalToBinary(effectCode);
         
            BaseClass.TaddbWindowsTenthbit = "00" + BaseClass.convertDecimalToBinary(letterSize) + BaseClass.convertDecimalToBinary(gap);
           
            BaseClass.TaddbWindowsEleventhbit = BaseClass.convertDecimalToBinary(BaseClass.timeDelay);
        }
        public static int index = 0;

        public static int checkSpecialStatusIndex = 0;
      public static bool RescheduleStatus=false;
        public static Byte[] taddbWindowsPacket()
        {
           
            List<byte> AllWindows = new List<byte>();
            AllWindows.Clear();
            int count = 0;
            int windows = 4;
            if (BaseClass.currentStatus == "Rescheduled"|| BaseClass.currentStatus == "Terminated" || BaseClass.currentStatus == "Diverted" || BaseClass.currentStatus == "Change of Source")
            {
                windows = 5;
            }
            taddbWindowsPacketFormation("192.168.0.161");           
            byte[] taddbWindows = new byte[14];
            for (int i = 0; i < windows; i++)
            {       
                
                if (count == 0)
                {
                    taddbWindows[0] = 00;
                    taddbWindows[1] = 01;
                    taddbWindows[2] = 01;
                    taddbWindows[3] = 80;                 
                }
                else if(count==1)
                {
                    taddbWindows[0] = 00;
                    taddbWindows[1] = 01;
                    taddbWindows[2] = 00;
                    taddbWindows[3] = 58;                  
                }
                else if (count == 2)
                {
                    taddbWindows[0] = 00;
                    taddbWindows[1] = 59;
                    taddbWindows[2] = 00;
                    taddbWindows[3] = 240;
                }
                else if (count == 3)
                {
                    taddbWindows[0] = 00;
                    taddbWindows[1] = 244;
                    taddbWindows[2] = 01;
                    taddbWindows[3] = 80;
                }
                taddbWindows[4] = 00;
                taddbWindows[5] = 16;
                taddbWindows[6] = 00;
                taddbWindows[7] = 01;
                taddbWindows[8] = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEightbit);
                taddbWindows[9] = changeScrolling(i);
                taddbWindows[10]=changeLetterGap(i);
                taddbWindows[11] = changeDelayTime(i);             
                count++;
                AllWindows.AddRange(taddbWindows);                                      
              
            }
            
         
            return AllWindows.ToArray();
        }


        public static byte changeScrolling(int i)
        {
            byte ninthBit ;
            if(i==2)
            {
                if (BaseClass.currentTrainName.Length > 24) //scrolling
                    ninthBit = 5;
                else
                    ninthBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsNinthbit);
            }
            else if (BaseClass.currentStatus == "Indefinite Late" || BaseClass.currentStatus == "Rescheduled")
            {
                if (i == 3 && BaseClass.currentTrainStatusName.Length > 10) //scrolling
                    ninthBit = 5;
                else
                    ninthBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsNinthbit);
            }
            else if (BaseClass.currentStatus == "Terminated")
            {
                if (BaseClass.CurrentLang == "eng"&& i==3)
                    ninthBit = 5;
                else if (i == 3 && BaseClass.currentTrainStatusName.Length > 10) // scrolling tabs
                    ninthBit = 5;
                else if (i == 4 && BaseClass.currentCity.Length>10)
                    ninthBit = 5;
                else
                    ninthBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsNinthbit);
            }
            else if (BaseClass.currentStatus == "Diverted" || BaseClass.currentStatus == "Change of Source")
            {
                if (i == 4 && BaseClass.currentCity.Length>10) //scrolling next tab
                    ninthBit = 5;
                else
                    ninthBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsNinthbit);
            }
            else
            {
                ninthBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsNinthbit);
            }

            return ninthBit;
        }
        public static byte changeDelayTime(int i)
        {
            byte tenthBit ;
            if ((i == 4 || i == 3) && (BaseClass.currentStatus == "Rescheduled" || BaseClass.currentStatus == "Terminated" || BaseClass.currentStatus == "Diverted" || BaseClass.currentStatus == "Change of Source"))
            {
            
                tenthBit = (byte)(BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit) / 2);
            }
            else
            {
                tenthBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit);

            }
            return tenthBit;
        }
        public static byte changeLetterGap(int i)
        {
            byte eleventhBit ;
            if(i==1) //train Number Letter gap in any status
            {
                BaseClass.TaddbWindowsTenthbit = BaseClass.TaddbWindowsTenthbit.Substring(0, BaseClass.TaddbWindowsTenthbit.Length - 3) + BaseClass.convertDecimalToBinary(BaseClass.gap);
                
            }
            else if(checkStatus(i)) //general statusses
            {
                BaseClass.TaddbWindowsTenthbit = BaseClass.TaddbWindowsTenthbit.Substring(0, BaseClass.TaddbWindowsTenthbit.Length - 3) + BaseClass.convertDecimalToBinary(BaseClass.gap);

              
            }
            else if(checkSpecialWindowStatuses(i))  //single window statusses and double except reschedule
            {
                if(BaseClass.CurrentLang=="eng")
                {
                    BaseClass.TaddbWindowsTenthbit = BaseClass.TaddbWindowsTenthbit.Substring(0, BaseClass.TaddbWindowsTenthbit.Length - 3) + BaseClass.convertDecimalToBinary(BaseClass.gap);

                }
                else if (BaseClass.CurrentLang == "hin")
                {
                    BaseClass.TaddbWindowsTenthbit = BaseClass.TaddbWindowsTenthbit.Substring(0, BaseClass.TaddbWindowsTenthbit.Length - 3) + BaseClass.convertDecimalToBinary(0);
                }
                else
                {
                    BaseClass.TaddbWindowsTenthbit = BaseClass.TaddbWindowsTenthbit.Substring(0, BaseClass.TaddbWindowsTenthbit.Length - 3) + BaseClass.convertDecimalToBinary(BaseClass.regionalGapCode);
                }              
            }
            else if (BaseClass.currentStatus == "Rescheduled") //only Rescheduled
            {

                if(i==2||i==3)
                {
                    if (BaseClass.CurrentLang == "eng")
                    {
                        BaseClass.TaddbWindowsTenthbit = BaseClass.TaddbWindowsTenthbit.Substring(0, BaseClass.TaddbWindowsTenthbit.Length - 3) + BaseClass.convertDecimalToBinary(BaseClass.gap);

                    }
                    else if (BaseClass.CurrentLang == "hin")
                    {
                        BaseClass.TaddbWindowsTenthbit = BaseClass.TaddbWindowsTenthbit.Substring(0, BaseClass.TaddbWindowsTenthbit.Length - 3) + BaseClass.convertDecimalToBinary(0);
                    }
                    else
                    {
                        BaseClass.TaddbWindowsTenthbit = BaseClass.TaddbWindowsTenthbit.Substring(0, BaseClass.TaddbWindowsTenthbit.Length - 3) + BaseClass.convertDecimalToBinary(BaseClass.regionalGapCode);
                    }
                }               
                else if(i==4)
                {
                    BaseClass.TaddbWindowsTenthbit = BaseClass.TaddbWindowsTenthbit.Substring(0, BaseClass.TaddbWindowsTenthbit.Length - 3) + BaseClass.convertDecimalToBinary(BaseClass.gap);

                }
            }

            eleventhBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsTenthbit);
            return eleventhBit;
        }

        public static bool checkStatus(int i)
        {
            if ((i == 3) && (BaseClass.currentStatus == "Running Right Time" 
                || BaseClass.currentStatus == "Will Arrive Shortly" || BaseClass.currentStatus == "Is Arriving On"
               || BaseClass.currentStatus == "Running Late" || BaseClass.currentStatus == "Is Ready to Leave"
               || BaseClass.currentStatus == "Platform Changed" || BaseClass.currentStatus == "Delay Depature"
               || BaseClass.currentStatus == "Is on Platform" || BaseClass.currentStatus == "Departed"
               || BaseClass.currentStatus == "Platform Changed" || BaseClass.currentStatus == "Regulated"))//running right time hindi letter gap
            {
                return true;
            }
            return false;
        }
        public static bool checkSpecialWindowStatuses(int i)
        {
            if ((i==2||i==3||i==4)&&(BaseClass.currentStatus != "Rescheduled"))
              
            {
                return true;
            }
            return false;
        }

   
        public static int convertBinaryToDecimal(string binaryValue)
        {
            int decimalValue = Convert.ToInt32(binaryValue, 2); // Convert binary to decimal
            return decimalValue;
        }
        public static void SpecialStatus(string lang)
        {
            int pkey=0;
            string statusEngName = "";
            string statusFor = "";
            string hStatus = "";
            string rStatus = "";
            string otherStatus = "";
            DataTable trainStatusdt = OnlineTrainsDao.GetStatusByName(BaseClass.trainStatus);
            foreach (DataRow row in trainStatusdt.Rows)
            {
                 pkey = Convert.ToInt32(row["Pkey_Status"]);
                 statusEngName = row["StatusName"].ToString();
                 statusFor = row["StatusFor"].ToString();
                 hStatus = row["HStatus"].ToString();
                 rStatus = row["RStatus"].ToString();
                 otherStatus = row["OtherStatus"].ToString();
            }
            byte[] statusEngNameBytes= Encoding.BigEndianUnicode.GetBytes(statusEngName);
            BaseClass.SpecialWindows.Add(BaseClass.taddbDataPacket.Count);
            BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
            BaseClass.taddbDataPacket.AddRange(statusEngNameBytes);
            BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
        }


 
        public static void TaddbEnglishDataPacket(List<DataGridViewRow> checkedRows)
        {
            string City = "";


            foreach (var checkedRow in checkedRows)
            {
            
                string trainStatus = checkedRow.Cells["dgvTrainStatusColumn"].Value.ToString();
                BaseClass.currentStatus = trainStatus;
                
                string trainNumber = checkedRow.Cells["dgvTrNoColumn"].Value.ToString();
                
                string engTrainName = checkedRow.Cells["dgvTrainNameColumn"].Value.ToString();
            
                string exptTime = checkedRow.Cells["dgvEtaColumn"].Value.ToString();
                string ad = checkedRow.Cells["dgvAdColumn"].Value.ToString();
                string pf = checkedRow.Cells["dgvPFColumn"].Value.ToString();
                if (checkedRow.Cells["dgvCityColumn"].Value != null)
                {
                    City = checkedRow.Cells["dgvCityColumn"].Value.ToString();
                    BaseClass.currentCity = City;
                }
 
                byte[] trainNumberBytes = Encoding.BigEndianUnicode.GetBytes(trainNumber);
                //byte[] trainEngNameBytes = Encoding.BigEndianUnicode.GetBytes(engTrainName);
                byte[] trainEngNameBytes = Encoding.BigEndianUnicode.GetBytes(engTrainName);
                byte[] exptTimeBytes = Encoding.BigEndianUnicode.GetBytes(exptTime);
                byte[] adBytes = Encoding.BigEndianUnicode.GetBytes(ad);
                byte[] pfBytes = Encoding.BigEndianUnicode.GetBytes(pf);
                byte[] trainStatusbytes= Encoding.BigEndianUnicode.GetBytes(trainStatus);

                BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                BaseClass.taddbDataPacket.AddRange(BaseClass.emptyWindow);
                BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                BaseClass.taddbDataPacket.AddRange(trainEngNameBytes);
                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                BaseClass.specialStatusData.Add(trainStatus);
             
                string name = BaseClass.getStatusName("eng", ad, trainStatus);
                BaseClass.currentTrainStatusName = new string(name.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());

                BaseClass.currentTrainName= new string(engTrainName.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());


                if (trainStatus == "Running Right Time" || trainStatus == "Will Arrive Shortly" ||
                    trainStatus == "Is Arriving On" || trainStatus == "Running Late" ||
                    trainStatus == "Platform Changed"|| trainStatus == "Is Ready to Leave"||
                    trainStatus == "Is on Platform" || trainStatus == "Departed" ||
                   trainStatus == "Delay Depature" || trainStatus == "Platform Change")
                {
                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(exptTimeBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.ADSeperators);
                    BaseClass.taddbDataPacket.AddRange(adBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.PFSeperators);
                    BaseClass.taddbDataPacket.AddRange(pfBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }
                else if (trainStatus == "Diverted")
                {
                 
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);
                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    ////  string name = BaseClass.getStatusName("eng", ad, trainStatus);
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(City);
                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                }
                else if (trainStatus == "Rescheduled")
                {

              //      
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);
                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);



                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(exptTimeBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.ADSeperators);
                    BaseClass.taddbDataPacket.AddRange(adBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.PFSeperators);
                    BaseClass.taddbDataPacket.AddRange(pfBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                }
                else if (trainStatus == "Cancelled" || trainStatus == "Indefinite Late")
                {
                   
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);
                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }
                else if (trainStatus == "Terminated")
                {
                   
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name+" At");
                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(City);

                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }
                else if (trainStatus == "Has Arrived on")
                {
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes("Arrived");
                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.PFSeperators);
                    BaseClass.taddbDataPacket.AddRange(pfBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }
                else if (trainStatus == "Change of Source")
                {
                   
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes("Start at");
                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(City);
                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }
                BaseClass.windowsDataPacket.AddRange(taddbWindowsPacket());
                BaseClass.CurrentTrainIndex++;
            }
           // SpecialStatus("eng");
        }
        public static void TaddbHindiDataPacket(List<DataGridViewRow> checkedRows)
        {


            foreach (var checkedRow in checkedRows)
            {
                string City = "";
                string trainStatus = checkedRow.Cells["dgvTrainStatusColumn"].Value.ToString();
                BaseClass.currentStatus = trainStatus;
                string trainNumber = checkedRow.Cells["dgvTrNoColumn"].Value.ToString();
                string hindiTrainName = checkedRow.Cells["dgvHindiTrainNameColumn"].Value.ToString();
                string exptTime = checkedRow.Cells["dgvEtaColumn"].Value.ToString();
                string ad = checkedRow.Cells["dgvAdColumn"].Value.ToString();
                string pf = checkedRow.Cells["dgvPFColumn"].Value.ToString();

                if (checkedRow.Cells["dgvHindiCityName"].Value != null)
                {
                    City = checkedRow.Cells["dgvHindiCityName"].Value.ToString();
                }

                byte[] trainNumberBytes = Encoding.BigEndianUnicode.GetBytes(trainNumber);
                byte[] trainHindiNameBytes = Encoding.BigEndianUnicode.GetBytes(hindiTrainName);
                byte[] exptTimeBytes = Encoding.BigEndianUnicode.GetBytes(exptTime);
                byte[] adBytes = Encoding.BigEndianUnicode.GetBytes(ad);
                byte[] pfBytes = Encoding.BigEndianUnicode.GetBytes(pf);
                byte[] trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(trainStatus);

                BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                BaseClass.taddbDataPacket.AddRange(BaseClass.emptyWindow);
                BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                BaseClass.taddbDataPacket.AddRange(trainHindiNameBytes);
                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);



                string name = BaseClass.getStatusName("hin", ad, trainStatus);
                BaseClass.currentTrainStatusName = new string(name.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
                BaseClass.currentTrainName = new string(hindiTrainName.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());


                if (trainStatus == "Running Right Time" || trainStatus == "Will Arrive Shortly" ||
                    trainStatus == "Is Arriving On" || trainStatus == "Running Late" ||
                    trainStatus == "Platform Changed" || trainStatus == "Is Ready to Leave" ||
                    trainStatus == "Is on Platform" || trainStatus == "Departed" ||
                   trainStatus == "Delay Depature" || trainStatus == "Platform Change")
                {
                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(exptTimeBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.ADSeperators);
                    BaseClass.taddbDataPacket.AddRange(adBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.PFSeperators);
                    BaseClass.taddbDataPacket.AddRange(pfBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }
                else if (trainStatus == "Diverted")
                {
                   
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);
                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(City);
                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }
                else if (trainStatus == "Rescheduled")
                {

                  
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);
                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(exptTimeBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.ADSeperators);
                    BaseClass.taddbDataPacket.AddRange(adBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.PFSeperators);
                    BaseClass.taddbDataPacket.AddRange(pfBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                }
                else if (trainStatus == "Cancelled" || trainStatus == "Indefinite Late")
                {
                   
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);
                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }


                else if (trainStatus == "Terminated")
                {

                   
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);
                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(City);
                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                }
                else if (trainStatus == "Has Arrived on")
                {
                   
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);

                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.PFSeperators);
                    BaseClass.taddbDataPacket.AddRange(pfBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }
                else if (trainStatus == "Change of Source")
                {

                   
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);
                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(City);
                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                }
                BaseClass.windowsDataPacket.AddRange(taddbWindowsPacket());
                BaseClass.CurrentTrainIndex++;
            }
        }
        public static void TaddbRegionalDataPacket(List<DataGridViewRow> checkedRows)
        {
            string City = "";
            foreach (var checkedRow in checkedRows)
            {
                string trainStatus = checkedRow.Cells["dgvTrainStatusColumn"].Value.ToString();
                BaseClass.currentStatus = trainStatus;
                string trainNumber = checkedRow.Cells["dgvTrNoColumn"].Value.ToString();
                //string engTrainName = checkedRow.Cells["dgvTrainNameColumn"].Value.ToString();
                string RegTrainName = checkedRow.Cells["dgvRegionalLangColumn"].Value.ToString();
                // string hindiTrainName = checkedRow.Cells["dgvTrainNameColumn"].Value.ToString();
                string exptTime = checkedRow.Cells["dgvEtaColumn"].Value.ToString();
                string ad = checkedRow.Cells["dgvAdColumn"].Value.ToString();
                string pf = checkedRow.Cells["dgvPFColumn"].Value.ToString();

                if (checkedRow.Cells["dgvRegCityName"].Value != null)
                {
                    City = checkedRow.Cells["dgvRegCityName"].Value.ToString();
                }

                byte[] trainNumberBytes = Encoding.BigEndianUnicode.GetBytes(trainNumber);
                //byte[] trainEngNameBytes = Encoding.BigEndianUnicode.GetBytes(engTrainName);
                byte[] trainEngNameBytes = Encoding.BigEndianUnicode.GetBytes(RegTrainName);
                byte[] exptTimeBytes = Encoding.BigEndianUnicode.GetBytes(exptTime);
                byte[] adBytes = Encoding.BigEndianUnicode.GetBytes(ad);
                byte[] pfBytes = Encoding.BigEndianUnicode.GetBytes(pf);
                byte[] trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(trainStatus);
                //   byte[] trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(trainStatus);

                BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                BaseClass.taddbDataPacket.AddRange(BaseClass.emptyWindow);

                BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                BaseClass.taddbDataPacket.AddRange(trainEngNameBytes);
                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);


                string name = BaseClass.getStatusName("reg", ad, trainStatus);
                BaseClass.currentTrainStatusName = new string(name.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
                BaseClass.currentTrainName = new string(RegTrainName.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());


                if (trainStatus == "Running Right Time" || trainStatus == "Will Arrive Shortly" ||
                    trainStatus == "Is Arriving On" || trainStatus == "Running Late" ||
                    trainStatus == "Platform Changed" || trainStatus == "Is Ready to Leave" ||
                    trainStatus == "Is on Platform" || trainStatus == "Departed" ||
                   trainStatus == "Delay Depature" || trainStatus == "Platform Change")
                {
                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(exptTimeBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.ADSeperators);
                    BaseClass.taddbDataPacket.AddRange(adBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.PFSeperators);
                    BaseClass.taddbDataPacket.AddRange(pfBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }

                else if (trainStatus == "Diverted")
                {
                    
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);
                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(City);
                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }
                else if (trainStatus == "Rescheduled")
                {

                 
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);
                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(exptTimeBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.ADSeperators);
                    BaseClass.taddbDataPacket.AddRange(adBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.PFSeperators);
                    BaseClass.taddbDataPacket.AddRange(pfBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                }
                else if (trainStatus == "Cancelled" || trainStatus == "Indefinite Late")
                {
                   
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);
                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }
               
              
                else if (trainStatus == "Terminated")
                {

                    
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);
                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(City);
                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }
                else if (trainStatus == "Has Arrived on")
                {
                   
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);

                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.PFSeperators);
                    BaseClass.taddbDataPacket.AddRange(pfBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }
                else if (trainStatus == "Change of Source")
                {

               
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);
                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(City);
                    BaseClass.NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }
                BaseClass.windowsDataPacket.AddRange(taddbWindowsPacket());
                BaseClass.CurrentTrainIndex++;
            }
        }
        public static byte[] taddbDataPacket(List<DataGridViewRow> checkedRows)
        {
            try
            {
                taddbWindowsPacketFormation("192.168.0.161");
                BaseClass.SpecialWindows.Clear();
                BaseClass.trainStatusNamesList.Clear();
                BaseClass.NormalWindows.Clear();
                BaseClass.taddbDataPacket.Clear();
                BaseClass.windowsDataPacket.Clear();
                BaseClass.languageSequencepk.Clear();
                BaseClass.specialStatusData.Clear();
                BaseClass.trainsCount = 0;

                int count = 0;
                List<string> languageSequence = new List<string>(BaseClass.langSequence.Split(','));

                foreach (string language in languageSequence)
                {
                    string trimmedLanguage = language.Trim();
                    var result = BaseClass.SelectionRegionalLanguagesDt.AsEnumerable()
                        .Where(row => row.Field<string>("LanguageName") == trimmedLanguage)
                        .Select(row => row.Field<int>("Pkey_Language"))
                        .FirstOrDefault();
                    if (result != 0)
                    {
                       BaseClass.languageSequencepk.Add(result);
                    }
                }
                foreach (int language in BaseClass.languageSequencepk)
                {
                    if (language == 6)//English
                    {
                        BaseClass.CurrentLang = "eng";
                        BaseClass.CurrentTrainIndex = 0;
                        TaddbEnglishDataPacket(checkedRows);
                    }
                    else if (language == 16)//Hindi
                    {
                        BaseClass.CurrentLang = "hin";
                        BaseClass.CurrentTrainIndex = 0;
                        TaddbHindiDataPacket(checkedRows);
                    }
                    else//Regional
                    {
                        BaseClass.CurrentLang = "reg";
                        BaseClass.CurrentTrainIndex = 0;
                        TaddbRegionalDataPacket(checkedRows);
                    }
                }
            }
            catch(Exception e)
            {
                e.ToString();
            }
            return (BaseClass.taddbDataPacket.ToArray());
        }
        public static List<byte> finalDataPacket = new List<byte>();
        public static byte[] getTaddbFullPacket(int packetIdentifier, string SourceipAdress, string destinationIpAdress, int packetSerialNumer, int packetType)
        {

            finalDataPacket.Clear();

            finalDataPacket.AddRange(BaseClass.stratingBytes);//statrting bytes
            byte[] b1 = PacketController.firstPacketByte(packetIdentifier, SourceipAdress, destinationIpAdress, packetSerialNumer, packetType);

            byte[] b3 = BaseClass.taddbDataPacket.ToArray();


            finalDataPacket.AddRange(b1);
            finalDataPacket.AddRange(BaseClass.windowsDataPacket.ToArray());

            finalDataPacket.AddRange(PacketController.endingBytes);
            finalDataPacket.AddRange(b3);
            for (int i = 0; i < (PacketController.NormalWindows.Count); i++)
            {
                int decimalValueOfCharctersting = PacketController.NormalWindows.Count * 14 + (2) + PacketController.NormalWindows[i];
                byte[] characterStringIndices = PacketController.ConvertDecimalNumberTOByteArray(decimalValueOfCharctersting);
                finalDataPacket[5 + 12 + (i + 1) * 13 + i] = characterStringIndices[0];
                finalDataPacket[5 + 12 + (i + 1) * 14] = characterStringIndices[1];
            }
            finalDataPacket.AddRange(PacketController.finalTaddbETX);
            finalDataPacket.AddRange(PacketController.stratingBytes);
            byte[] packetlengthbytes = PacketController.ConvertDecimalNumberTOByteArray(finalDataPacket.Count - (6 + 5 + 1 + 6));
            finalDataPacket[9] = packetlengthbytes[0];
            finalDataPacket[10] = packetlengthbytes[1];
            byte[] crc = Server.CheckSum(finalDataPacket.ToArray());
            finalDataPacket[finalDataPacket.Count - 2 - 6 - 1] = crc[0];
            finalDataPacket[finalDataPacket.Count - 1 - 6 - 1] = crc[1];
            string a = PacketController.ByteArrayToString(finalDataPacket.ToArray());
            return finalDataPacket.ToArray();
        }
        public static byte[] ConvertDecimalNumberTOByteArray(int decimalNumber)
        {       
            string hexString = decimalNumber.ToString("X4");          
            byte[] byteArray = new byte[2];            
            byteArray[0] = Convert.ToByte(hexString.Substring(0, 2), 16);
            byteArray[1] = Convert.ToByte(hexString.Substring(2, 2), 16);
            return byteArray;
        }
    }
}
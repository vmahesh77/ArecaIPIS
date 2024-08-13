using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArecaIPIS.DAL;

namespace ArecaIPIS.Server_Classes
{
    class PacketController
    {
        public static string currentIp = "";
        public static List<int> NormalWindows = new List<int>();
        public static string ByteArrayToString(byte[] byteArray)
        {
            return BitConverter.ToString(byteArray).Replace("-", " ");
        }
        public static byte[] ConvertDecimalNumberTOByteArray(int decimalNumber)
        {
            string hexString = decimalNumber.ToString("X4");
            byte[] byteArray = new byte[2];
            byteArray[0] = Convert.ToByte(hexString.Substring(0, 2), 16);
            byteArray[1] = Convert.ToByte(hexString.Substring(2, 2), 16);
            return byteArray;
        }

        public static byte[] finalTaddbETX = new byte[] { 03, 00, 00, 04 };
        public static byte[] stratingBytes = new byte[] { 00, 00, 00, 00, 00, 00 };
        public static byte[] endingBytes = new byte[] { 255, 255 };
        public static byte[] emptyWindow = new byte[] { 255, 255, 255, 255 };
        public static byte[] characterString = new byte[] { 01, 00, 00, 00, 01 };
        public static byte[] Seperators = new byte[] { 231, 00 };







        public static byte[] firstPacketByte(int startPacket, string SourceipAdress, string destinationIpAdress, int packetSerialNumer, int packetType)
        {
            string[] sourceOctets = SourceipAdress.Split('.');
            string[] destinationOctets = destinationIpAdress.Split('.');
            byte[] b = new byte[12];
            b[0] = Convert.ToByte("AA", 16);
            b[1] = Convert.ToByte("CC", 16);
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

        public static void WindowsPacketFormation(string ipadress)
        {
            int reverseVedio = 0;
            int speed = 0;
            int effectCode = 0;
            int letterSize = 0;
            int gap = 0;
            int timeDelay = 0;
            int noOfLines = 0;
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
                noOfLines = Convert.ToInt32(row["NoofLines"].ToString());
            }
            BaseClass.noOfLines = noOfLines;
            BaseClass.gap = gap;
            BaseClass.timeDelay = timeDelay;
            BaseClass.TaddbWindowsEightbit = reverseVedio + "0000" + BaseClass.convertDecimalToBinary(speed);
            BaseClass.TaddbWindowsNinthbit = "0000" + BaseClass.convertDecimalToBinary(effectCode);

            BaseClass.TaddbWindowsTenthbit = "00" + BaseClass.convertDecimalToBinary(letterSize) + BaseClass.convertDecimalToBinary(gap);

            BaseClass.TaddbWindowsEleventhbit = BaseClass.convertDecimalToBinary(BaseClass.timeDelay);
        }

        public static int top = 16;
        public static int bottom = 0;

        public static Byte[] AgdbWindowsPacket(int windows)
        {

            List<byte> AllWindows = new List<byte>();
            AllWindows.Clear();
            int count = 0;
            

           

            WindowsPacketFormation(currentIp);
            byte[] taddbWindows = new byte[14];
            for (int i = 0; i < windows; i++)
            {
               // count = count + 1;
                byte[] columns = windowsColumns(count);
                taddbWindows[0] = columns[0];
                taddbWindows[1] = columns[1];
                taddbWindows[2] = columns[2];
                taddbWindows[3] = columns[3];
                taddbWindows[4] = columns[4];
                taddbWindows[5] = columns[5];
                taddbWindows[6] = columns[6];
                taddbWindows[7] = columns[7];
               
               taddbWindows[8] = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEightbit);
               taddbWindows[9] = changeAgdbScrolling(i);
               taddbWindows[10] = AgdbChangeLetterGap(i);
               taddbWindows[11] = changeAgdbDelayTime(i);
                count++;
                AllWindows.AddRange(taddbWindows);
            }
                
                
            return AllWindows.ToArray();
        }
          
        
        public static Byte[] WindowsPacket()
        {

            List<byte> AllWindows = new List<byte>();
            AllWindows.Clear();
            int count = 0;
            int windows = 4;
            if (BaseClass.currentStatus == "Rescheduled" || BaseClass.currentStatus == "Terminated" || BaseClass.currentStatus == "Diverted" || BaseClass.currentStatus == "Change of Source")
            {
                windows = 5;
            }
            if (BaseClass.currentStatus == "EmptyWindow")
            {
                windows = 1;
            }

            WindowsPacketFormation(currentIp);
            byte[] taddbWindows = new byte[14];
            for (int i = 0; i < windows; i++)
            {
                byte[] columns = windowsColumns(count);
                taddbWindows[0] = columns[0];
                taddbWindows[1] = columns[1];
                taddbWindows[2] = columns[2];
                taddbWindows[3] = columns[3];

                taddbWindows[4] = columns[4];
                taddbWindows[5] = columns[5];
                taddbWindows[6] = columns[6];
                taddbWindows[7] = columns[7];

                taddbWindows[8] = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEightbit);
                taddbWindows[9] = changeScrolling(i);
                taddbWindows[10] = changeLetterGap(i);
                taddbWindows[11] = changeDelayTime(i);
                count++;
                AllWindows.AddRange(taddbWindows);

            }


            return AllWindows.ToArray();  
        }

        public static byte[] windowsColumns(int window)
        {

            int trainsCount = BaseClass.trainsCount;
            int trainIndex = BaseClass.CurrentTrainIndex;

            if (trainIndex >= BaseClass.noOfLines)
            {

                trainIndex = trainIndex % BaseClass.noOfLines;
            }

            byte[] taddbWindows = new byte[8];

            if (BaseClass.boardType == "AGDB")
            {
                
                if (BaseClass.currentStatus == "Terminated"|| BaseClass.currentStatus == "Diverted" || BaseClass.currentStatus == "Change of Source"|| BaseClass.currentStatus == "Rescheduled")
                {

                    if (window == 0 || window==3) //train name
                    {
                           
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    else if (window == 1 || window ==2)// status window
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 65;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    else if (window == 4)//train number second window
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    else if (window >= 5 && window < 7) //coach pos1,2 lines
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 72;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    else if (window == 7) //empty window
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    else if (window >= 8 && window < 10)//coach pos 3,4 lines
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] =72;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }




                    if (window == 3)//train number,ad,expt,pf
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }
                    else if(window <3)
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 32;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 17;
                    }

                    else if (window == 4)//train number
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 32;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 17;
                    }
                    else if (window == 5)//Coach pos1
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 32;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 25;
                    }
                    else if (window == 6) //Coach pos2
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 24;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 17;
                    }
                    else if (window == 7)//Full Window
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }
                    else if (window == 8)//Coach pos3
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 09;
                    }
                    else if (window == 9)//Coach pos4
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 08;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }




                    
                }
                else
                {
                    if (window >= 0 && window < 3) //running right time first window
                    {
                        //   byte[] b=  TaddbController.ConvertDecimalNumberTOByteArray(192);   
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                       taddbWindows[3] = 192;
                    }
                    else if (window == 3)//train number second window
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 47;
                    }
                    else if (window >= 4 && window < 6) //coach pos1,2 lines
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 50;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    else if (window == 6) //empty window
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 01;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    else if (window >= 7 && window < 9)//coach pos 3,4 lines
                    {
                        taddbWindows[0] = 00;
                        taddbWindows[1] = 50;
                        taddbWindows[2] = 00;
                        taddbWindows[3] = 192;
                    }
                    if (window == 0)//train number,ad,expt,pf
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }
                    else if (window == 1)//train name
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 32;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 17;
                    }
                    else if (window == 2)//full window
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 32;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 17;
                    }
                    else if (window == 3)//train number
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 32;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 17;
                    }
                    else if (window == 4)//Coach pos1
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 32;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 25;
                    }
                    else if (window == 5) //Coach pos2
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 24;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 17;
                    }
                    else if (window == 6)//Full Window
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }
                    else if (window == 7)//Coach pos3
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 16;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 09;
                    }
                    else if (window == 8)//Coach pos4
                    {
                        taddbWindows[4] = 00;
                        taddbWindows[5] = 08;
                        taddbWindows[6] = 00;
                        taddbWindows[7] = 01;
                    }
                }
            }
            else
            {
                if (window == 0)
                {
                    taddbWindows[0] = 00;
                    taddbWindows[1] = 01;
                    taddbWindows[2] = 01;
                    taddbWindows[3] = 80;
                }
                else if (window == 1)
                {
                    taddbWindows[0] = 00;
                    taddbWindows[1] = 01;
                    taddbWindows[2] = 00;
                    taddbWindows[3] = 58;
                }
                else if (window == 2)
                {
                    taddbWindows[0] = 00;
                    taddbWindows[1] = 59;
                    taddbWindows[2] = 00;
                    taddbWindows[3] = 240;
                }
                else if (window == 3 || window == 4)
                {
                    taddbWindows[0] = 00;
                    taddbWindows[1] = 244;
                    taddbWindows[2] = 01;
                    taddbWindows[3] = 80;
                }
            }
            if (BaseClass.boardType == "MLDB")
            {
                byte[] b1 = PfdbController.ConvertDecimalNumberTOByteArray((trainIndex) * 16);
                byte[] b2 = PfdbController.ConvertDecimalNumberTOByteArray(15 + (trainIndex) * 16);

                taddbWindows[4] = b1[0];
                taddbWindows[5] = b1[1];
                taddbWindows[6] = b2[0];
                taddbWindows[7] = b2[1];
            }
            else if (BaseClass.boardType == "PFDB")
            {
                taddbWindows[4] = 00;
                taddbWindows[5] = 16;
                taddbWindows[6] = 00;
                taddbWindows[7] = 01;
            }

            return taddbWindows;
        }

        public static byte AgdbChangeLetterGap(int i)
        {
            byte eleventhBit = 0;
            eleventhBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsTenthbit);
            if (checkNormalStatus() || BaseClass.currentStatus == "Has Arrived on")
            {
                if (i < 4)
                {
                    BaseClass.TaddbWindowsTenthbit = BaseClass.TaddbWindowsTenthbit.Substring(0, BaseClass.TaddbWindowsTenthbit.Length - 3) + BaseClass.convertDecimalToBinary(BaseClass.gap);
                    eleventhBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsTenthbit);
                }
                else
                {
                    eleventhBit = 01;
                }
            }
            else if (BaseClass.currentStatus == "Rescheduled") //only Rescheduled
            {
                if (i < 5)
                {
                    BaseClass.TaddbWindowsTenthbit = BaseClass.TaddbWindowsTenthbit.Substring(0, BaseClass.TaddbWindowsTenthbit.Length - 3) + BaseClass.convertDecimalToBinary(BaseClass.gap);
                    eleventhBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsTenthbit);
                }
                else
                {
                    eleventhBit = 01;
                }
            }



            return eleventhBit;
        }
        public static byte changeAgdbScrolling(int i)
        {
            byte ninthBit=0;

            ninthBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsNinthbit);
            if (checkNormalStatus() || BaseClass.currentStatus == "Cancelled" || BaseClass.currentStatus=="Has Arrived on"|| BaseClass.currentStatus== "Indefinite Late")
            {
                if (i == 0)
                {
                    if (BaseClass.currentTrainName.Length > 24) //scrolling
                        ninthBit = 5;
                }
                if (i == 6 || i == 2)//empty window
                {
                    ninthBit = 00;
                }
            }
            else
            {             
                    if (i == 3)
                    {
                        if (BaseClass.currentTrainName.Length > 24) //scrolling
                            ninthBit = 5;
                    }   
                    if(i==2)
                    {
                    if (BaseClass.currentCity.Length > 10&&BaseClass.currentStatus!= "Rescheduled") //scrolling
                        ninthBit = 5;
                    }
            }
           
            return ninthBit;
        }
        public static byte changeAgdbDelayTime(int i)
        {
            byte tenthBit;
            if (BaseClass.currentStatus != "Rescheduled")
            {
                if ((i == 1 || i == 2) && (BaseClass.currentStatus == "Rescheduled" || BaseClass.currentStatus == "Terminated" || BaseClass.currentStatus == "Diverted" || BaseClass.currentStatus == "Change of Source"))
                {

                    tenthBit = (byte)(BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit) / 2);
                }
                else
                {
                    tenthBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit);

                }
            }
            else
            {
                if ((i == 1 || i == 2 || i == 5 || i == 6 || i == 8 || i == 9) && (BaseClass.currentStatus == "Rescheduled" || BaseClass.currentStatus == "Terminated" || BaseClass.currentStatus == "Diverted" || BaseClass.currentStatus == "Change of Source"))
                {

                    tenthBit = (byte)(BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit) / 2);
                }
                else
                {
                    tenthBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsEleventhbit);

                }
            }
            return tenthBit;
        }





        public static byte changeScrolling(int i)
        {
            byte ninthBit;
            if (i == 2)
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
                if (BaseClass.CurrentLang == "eng" && i == 3)
                    ninthBit = 5;
                else if (i == 3 && BaseClass.currentTrainStatusName.Length > 10) // scrolling tabs
                    ninthBit = 5;
                else if (i == 4 && BaseClass.currentCity.Length > 10)
                    ninthBit = 5;
                else
                    ninthBit = (byte)BaseClass.convertBinaryToDecimal(BaseClass.TaddbWindowsNinthbit);
            }
            else if (BaseClass.currentStatus == "Diverted" || BaseClass.currentStatus == "Change of Source")
            {
                if (i == 4 && BaseClass.currentCity.Length > 10) //scrolling next tab
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
            byte tenthBit;
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
            byte eleventhBit;
            if (i == 1) //train Number Letter gap in any status
            {
                BaseClass.TaddbWindowsTenthbit = BaseClass.TaddbWindowsTenthbit.Substring(0, BaseClass.TaddbWindowsTenthbit.Length - 3) + BaseClass.convertDecimalToBinary(BaseClass.gap);

            }
            else if (checkStatus(i)) //general statusses
            {
                BaseClass.TaddbWindowsTenthbit = BaseClass.TaddbWindowsTenthbit.Substring(0, BaseClass.TaddbWindowsTenthbit.Length - 3) + BaseClass.convertDecimalToBinary(BaseClass.gap);


            }
            else if (checkSpecialWindowStatuses(i))  //single window statusses and double except reschedule
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
            else if (BaseClass.currentStatus == "Rescheduled") //only Rescheduled
            {

                if (i == 2 || i == 3)
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
                else if (i == 4)
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
            if ((i == 2 || i == 3 || i == 4) && (BaseClass.currentStatus != "Rescheduled"))

            {
                return true;
            }
            return false;
        }






        public static bool checkNormalStatus()
        {
            if ((BaseClass.currentStatus == "Running Right Time"
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

      
        public static byte[] DataPacket(List<DataGridViewRow> checkedRows, string ip)
        {
            try
            {
                currentIp = ip;
                WindowsPacketFormation(ip);
                BaseClass.SpecialWindows.Clear();
                BaseClass.trainStatusNamesList.Clear();
                NormalWindows.Clear();
                BaseClass.taddbDataPacket.Clear();
                BaseClass.windowsDataPacket.Clear();
                BaseClass.languageSequencepk.Clear();
                BaseClass.specialStatusData.Clear();
                BaseClass.trainsCount = 0;

                BaseClass.trainsCount = checkedRows.Count;

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

                if (BaseClass.boardType == "AGDB")
                {
                    getAgdbDataPacket(checkedRows, "eng");
                }
                else
                {
                    foreach (int language in BaseClass.languageSequencepk)
                    {


                        if (language == 6)//English
                        {
                            BaseClass.CurrentLang = "eng";
                            BaseClass.CurrentTrainIndex = 0;
                            if (BaseClass.boardType == "PFDB" || BaseClass.boardType == "MLDB")
                            {
                                PfdbMldbDataPacket(checkedRows, "eng");
                            }
                            else
                            {
                                getOvdIvdDataPacket(checkedRows, "eng");
                            }
                            
                        }
                        else if (language == 16)//Hindi
                        {
                            BaseClass.CurrentLang = "hin";
                            BaseClass.CurrentTrainIndex = 0;
                            if (BaseClass.boardType == "PFDB" || BaseClass.boardType == "MLDB")
                            {
                                PfdbMldbDataPacket(checkedRows, "hin");
                            }
                            else
                            {
                                getOvdIvdDataPacket(checkedRows, "hin");
                            }
                           
                        }
                        else//Regional
                        {
                            BaseClass.CurrentLang = "reg";
                            BaseClass.CurrentTrainIndex = 0;
                            if (BaseClass.boardType == "PFDB" || BaseClass.boardType == "MLDB")
                            {
                                PfdbMldbDataPacket(checkedRows, "reg");
                            }
                            else
                            {
                                getOvdIvdDataPacket(checkedRows, "reg");
                            }
                           
                        }

                    }
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return (BaseClass.taddbDataPacket.ToArray());
        }


        public static void PfdbMldbDataPacket(List<DataGridViewRow> checkedRows, string lang)
        {
            string City = "";
            string trainStatus = "";
            string TrainName = "";

            foreach (var checkedRow in checkedRows)
            {
                if (lang == "eng")
                {
                    TrainName = checkedRow.Cells["dgvTrainNameColumn"].Value.ToString();
                    if (checkedRow.Cells["dgvCityColumn"].Value != null)
                    {
                        City = checkedRow.Cells["dgvCityColumn"].Value.ToString();
                        BaseClass.currentCity = City;
                    }
                }
                else if (lang == "hin")
                {

                    if (checkedRow.Cells["dgvHindiCityName"].Value != null)
                    {
                        City = checkedRow.Cells["dgvHindiCityName"].Value.ToString();
                    }
                    TrainName = checkedRow.Cells["dgvHindiTrainNameColumn"].Value.ToString();

                }
                else
                {
                    if (checkedRow.Cells["dgvRegCityName"].Value != null)
                    {
                        City = checkedRow.Cells["dgvRegCityName"].Value.ToString();
                    }

                    TrainName = checkedRow.Cells["dgvRegionalLangColumn"].Value.ToString();
                }
                trainStatus = checkedRow.Cells["dgvTrainStatusColumn"].Value.ToString();
                BaseClass.currentStatus = trainStatus;

                string trainNumber = checkedRow.Cells["dgvTrNoColumn"].Value.ToString();

                string exptTime = checkedRow.Cells["dgvEtaColumn"].Value.ToString();
                string ad = checkedRow.Cells["dgvAdColumn"].Value.ToString();
                string pf = checkedRow.Cells["dgvPFColumn"].Value.ToString();


                byte[] trainNumberBytes = Encoding.BigEndianUnicode.GetBytes(trainNumber);
                //byte[] trainEngNameBytes = Encoding.BigEndianUnicode.GetBytes(engTrainName);
                byte[] trainNameBytes = Encoding.BigEndianUnicode.GetBytes(TrainName);
                byte[] exptTimeBytes = Encoding.BigEndianUnicode.GetBytes(exptTime);
                byte[] adBytes = Encoding.BigEndianUnicode.GetBytes(ad);
                byte[] pfBytes = Encoding.BigEndianUnicode.GetBytes(pf);
                byte[] trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(trainStatus);



                
                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.emptyWindow);
                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    BaseClass.specialStatusData.Add(trainStatus);

                    string name = BaseClass.getStatusName("eng", ad, trainStatus);
                    BaseClass.currentTrainStatusName = new string(name.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());

                    BaseClass.currentTrainName = new string(TrainName.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());


                    if (trainStatus == "Running Right Time" || trainStatus == "Will Arrive Shortly" ||
                        trainStatus == "Is Arriving On" || trainStatus == "Running Late" ||
                        trainStatus == "Platform Changed" || trainStatus == "Is Ready to Leave" ||
                        trainStatus == "Is on Platform" || trainStatus == "Departed" ||
                       trainStatus == "Delay Depature" || trainStatus == "Platform Change")
                    {
                        NormalWindows.Add(BaseClass.taddbDataPacket.Count);
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
                        NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                        BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                        ////  string name = BaseClass.getStatusName("eng", ad, trainStatus);
                        trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(City);
                        NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                        BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    }
                    else if (trainStatus == "Rescheduled")
                    {

                        //      
                        trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name);
                        NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                        BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);



                        NormalWindows.Add(BaseClass.taddbDataPacket.Count);
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
                        NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                        BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                    }
                    else if (trainStatus == "Terminated")
                    {

                        trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(name + " At");
                        NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                        BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                        trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(City);

                        NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                        BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                    }
                    else if (trainStatus == "Has Arrived on")
                    {
                        trainStatusbytes = Encoding.BigEndianUnicode.GetBytes("Arrived");
                        NormalWindows.Add(BaseClass.taddbDataPacket.Count);
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
                        NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                        BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                        trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(City);
                        NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                        BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                    }

                    BaseClass.windowsDataPacket.AddRange(WindowsPacket());
                    BaseClass.CurrentTrainIndex++;
                }
               CheckMLDBEmptyWindows(checkedRows);
        }      
        public static void getOvdIvdDataPacket(List<DataGridViewRow> checkedRows, string lang)
        {
            string City = "";
            string trainStatus = "";
            string TrainName = "";

            foreach (var checkedRow in checkedRows)
            {
                if (lang == "eng")
                {
                    TrainName = checkedRow.Cells["dgvTrainNameColumn"].Value.ToString();
                    if (checkedRow.Cells["dgvCityColumn"].Value != null)
                    {
                        City = checkedRow.Cells["dgvCityColumn"].Value.ToString();
                        BaseClass.currentCity = City;
                    }
                }
                else if (lang == "hin")
                {

                    if (checkedRow.Cells["dgvHindiCityName"].Value != null)
                    {
                        City = checkedRow.Cells["dgvHindiCityName"].Value.ToString();
                    }
                    TrainName = checkedRow.Cells["dgvHindiTrainNameColumn"].Value.ToString();

                }
                else
                {
                    if (checkedRow.Cells["dgvRegCityName"].Value != null)
                    {
                        City = checkedRow.Cells["dgvRegCityName"].Value.ToString();
                    }

                    TrainName = checkedRow.Cells["dgvRegionalLangColumn"].Value.ToString();
                }

                trainStatus = checkedRow.Cells["dgvTrainStatusColumn"].Value.ToString();
                BaseClass.currentStatus = trainStatus;
                string trainNumber = checkedRow.Cells["dgvTrNoColumn"].Value.ToString();
                string exptTime = checkedRow.Cells["dgvEtaColumn"].Value.ToString();
                string ad = checkedRow.Cells["dgvAdColumn"].Value.ToString();
                string pf = checkedRow.Cells["dgvPFColumn"].Value.ToString();
                byte[] trainNumberBytes = Encoding.BigEndianUnicode.GetBytes(trainNumber);
                //byte[] trainEngNameBytes = Encoding.BigEndianUnicode.GetBytes(engTrainName);
                byte[] trainNameBytes = Encoding.BigEndianUnicode.GetBytes(TrainName);
                byte[] exptTimeBytes = Encoding.BigEndianUnicode.GetBytes(exptTime);
                byte[] adBytes = Encoding.BigEndianUnicode.GetBytes(ad);
                byte[] pfBytes = Encoding.BigEndianUnicode.GetBytes(pf);
                byte[] trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(trainStatus);


                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                BaseClass.taddbDataPacket.AddRange(BaseClass.emptyWindow);
                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);




            }
        }

        public static void CheckOvdEmptyWindows(List<DataGridViewRow> checkedRows)
        {
            int n = 0;
            if ((checkedRows.Count % BaseClass.noOfLines != 0) && (BaseClass.boardType == "OVD"|| BaseClass.boardType == "IVD"))
            {
                BaseClass.currentStatus = "EmptyWindow";
                if (checkedRows.Count < BaseClass.noOfLines)
                {
                    n = BaseClass.noOfLines - checkedRows.Count;
                }
                else
                {
                    n = BaseClass.noOfLines - checkedRows.Count % BaseClass.noOfLines;
                }
                for (int i = 0; i < n; i++)
                {

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.emptyWindow);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                    BaseClass.windowsDataPacket.AddRange(WindowsPacket());
                    BaseClass.CurrentTrainIndex++;
                }
            }

        }


        public static void CheckMLDBEmptyWindows(List<DataGridViewRow> checkedRows)
        {
            int n = 0;
            if ((checkedRows.Count % BaseClass.noOfLines != 0) && BaseClass.boardType == "MLDB")
            {
                BaseClass.currentStatus = "EmptyWindow";
                if (checkedRows.Count < BaseClass.noOfLines)
                {
                    n = BaseClass.noOfLines - checkedRows.Count;
                }
                else
                {
                    n = BaseClass.noOfLines - checkedRows.Count % BaseClass.noOfLines;
                }
                for (int i = 0; i < n; i++)
                {

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.emptyWindow);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                    BaseClass.windowsDataPacket.AddRange(WindowsPacket());
                    BaseClass.CurrentTrainIndex++;
                }
            }

        }
        public static void getAgdbDataPacket(List<DataGridViewRow> checkedRows, string lang)
        {
            byte[] trainCityBytes = null;
            string City = "";
            foreach (var checkedRow in checkedRows)
            {
                string trainStatus = checkedRow.Cells["dgvTrainStatusColumn"].Value.ToString();
                BaseClass.currentStatus = trainStatus;
                string trainNumber = checkedRow.Cells["dgvTrNoColumn"].Value.ToString().Trim();
                string TrainName = "";
                if (lang == "eng")
                    TrainName = checkedRow.Cells["dgvTrainNameColumn"].Value.ToString();
                else if (lang == "hin")
                    TrainName = checkedRow.Cells["dgvHindiTrainNameColumn"].Value.ToString();
                else
                    TrainName = checkedRow.Cells["dgvRegionalLangColumn"].Value.ToString();
                string exptTime = checkedRow.Cells["dgvEtaColumn"].Value.ToString();
                string ad = checkedRow.Cells["dgvAdColumn"].Value.ToString().Trim();
                string pf = checkedRow.Cells["dgvPFColumn"].Value.ToString().Trim();
                if (checkedRow.Cells["dgvCityColumn"].Value != null)
                {
                    City = checkedRow.Cells["dgvCityColumn"].Value.ToString();
                    BaseClass.currentCity = City;
                    trainCityBytes = Encoding.BigEndianUnicode.GetBytes(City);
                }


                byte[] trainNumberBytes = Encoding.BigEndianUnicode.GetBytes(trainNumber);
                //byte[] trainEngNameBytes = Encoding.BigEndianUnicode.GetBytes(engTrainName);
                byte[] trainNameBytes = Encoding.BigEndianUnicode.GetBytes(TrainName);
                byte[] exptTimeBytes = Encoding.BigEndianUnicode.GetBytes(exptTime);
                byte[] adBytes = Encoding.BigEndianUnicode.GetBytes(ad);
                byte[] pfBytes = Encoding.BigEndianUnicode.GetBytes(pf);
                byte[] trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(trainStatus);  
                

                string name = BaseClass.getStatusName("eng", ad, trainStatus);
                BaseClass.currentTrainStatusName = new string(name.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());
                BaseClass.currentTrainName = new string(TrainName.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());

                

                if (checkNormalStatus())
                {
                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbExptSeperators);
                    BaseClass.taddbDataPacket.AddRange(exptTimeBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbAdSeperators);
                    BaseClass.taddbDataPacket.AddRange(adBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbPfSeperators);
                    BaseClass.taddbDataPacket.AddRange(pfBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbEndBoardSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }
                else if (trainStatus == "Cancelled" || trainStatus == "Indefinite Late")
                {
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(trainStatus);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbExptSeperators);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbEndBoardSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }
                else if (trainStatus == "Has Arrived on")
                {
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes("Arrived");

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);


                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbExptSeperators);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbPfSeperators);
                    BaseClass.taddbDataPacket.AddRange(pfBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbEndBoardSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }
                else  if (trainStatus == "Terminated" || trainStatus=="Diverted" || trainStatus == "Change of Source")
                {
                    if(trainStatus != "Change of Source")
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(trainStatus + " At");
                    else
                        trainStatusbytes = Encoding.BigEndianUnicode.GetBytes("start" + " At"); 
                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbExptSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbAdSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
               


                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainCityBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbAdSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }
                else if (trainStatus == "Rescheduled")
                {
                    trainStatusbytes = Encoding.BigEndianUnicode.GetBytes(trainStatus);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbExptSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainStatusbytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbAdSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(exptTimeBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbAdSeperators);
                    BaseClass.taddbDataPacket.AddRange(adBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbPfSeperators);
                    BaseClass.taddbDataPacket.AddRange(pfBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.AgdbEndBoardSeperators);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);


                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(trainNameBytes);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }



                if (trainStatus == "Cancelled" || trainStatus == "Indefinite Late" || trainStatus == "Terminated"|| trainStatus == "Diverted" || trainStatus == "Change of Source")
                {
                    coachExisted = false;
                }              
                else
                {
                    coachExisted = CheckCoachPositions(trainNumber);
                }
                if (trainStatus == "Terminated"|| trainStatus == "Diverted" || trainStatus == "Change of Source")
                {
                    BaseClass.windowsDataPacket.AddRange(AgdbWindowsPacket(4));
                }
                else if (coachExisted)
                {
                    if(trainStatus == "Rescheduled")
                    BaseClass.windowsDataPacket.AddRange(AgdbWindowsPacket(10));                 
                    else
                    BaseClass.windowsDataPacket.AddRange(AgdbWindowsPacket(9));
                }
                else
                {
                    if (trainStatus == "Rescheduled")
                        BaseClass.windowsDataPacket.AddRange(AgdbWindowsPacket(4));
                    else
                        BaseClass.windowsDataPacket.AddRange(AgdbWindowsPacket(2));
                }
            }
        }
        public  static bool  coachExisted = false;
        public static bool CheckCoachPositions(string trainNumber)
        {
            List<byte[]> Coaches = addCoachPositions(trainNumber);
            if (Coaches != null)
            {
                if (BaseClass.currentStatus!="Rescheduled") 
                {
                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.emptyWindow);
                }
                byte[] trainNumberBytes = Encoding.BigEndianUnicode.GetBytes(trainNumber);

                NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                BaseClass.taddbDataPacket.AddRange(trainNumberBytes);
                BaseClass.taddbDataPacket.AddRange(BaseClass.Seperators);
                BaseClass.taddbDataPacket.AddRange(PfdbController.ConvertDecimalNumberTOByteArray(67));
                BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);

                for (int i = 0; i < Coaches.Count; i++)
                {
                    if (i == 2)
                    {
                        NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                        BaseClass.taddbDataPacket.AddRange(BaseClass.emptyWindow);
                    }
                    NormalWindows.Add(BaseClass.taddbDataPacket.Count);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.characterString);
                    BaseClass.taddbDataPacket.AddRange(Coaches[i]);
                    BaseClass.taddbDataPacket.AddRange(BaseClass.endingBytes);
                }
                return true;
            }
            return false;
        }
        static string FormCoachString(string[] parts)
        {
            // Maximum length of the final string (considering all parts and spaces)
            int maxLength = 50; // Adjust this value as needed                                                              
           // Calculate the total length of all parts combined
            int totalPartsLength = 0;
            foreach (string part in parts)
            {
                totalPartsLength += part.Length;
            }

            // Calculate the total available space to distribute
            int totalSpaces = maxLength - totalPartsLength;

            // Calculate equal spaces to distribute between parts
            int equalSpaces = totalSpaces / (parts.Length - 1);

            // Remaining spaces if any
            int remainingSpaces = totalSpaces % (parts.Length - 1);

            // Resultant string
            string result = "";

            for (int i = 0; i < parts.Length; i++)
            {
                // Append the current part
                result += parts[i];

                // Append the spaces between parts, except after the last part
                if (i < parts.Length - 1)
                {
                    result += new string(' ', equalSpaces);

                    // Distribute remaining spaces evenly
                    if (remainingSpaces > 0)
                    {
                        result += " ";
                        remainingSpaces--;
                    }
                }
            }

            return result;
        }
        static List<string[]> SplitArray(string[] array, int subArrayLength)
        {
            List<string[]> result = new List<string[]>();
            int arrayLength = array.Length;

            for (int i = 0; i < arrayLength; i += subArrayLength)
            {
                int currentSubArrayLength = Math.Min(subArrayLength, arrayLength - i);
                string[] subArray = new string[currentSubArrayLength];
                Array.Copy(array, i, subArray, 0, currentSubArrayLength);
                result.Add(subArray);
            }

            return result;
        }
        public static  List<string> coachList = new List<string>();
        public static List<byte[]> addCoachPositions(string trainNumber)
        {
            coachList.Clear();
            List<byte[]> coachBytes = new List<byte[]>();
            List<byte> SubcoachBytes = new List<byte>();
            string[] coachpositions = OnlineTrainsDao.coachPositions(trainNumber).ToArray();
            int sum = 67;
            int gap = 0;

            coachpositions = coachpositions.Where(s => !string.IsNullOrEmpty(s)).ToArray();
            if (coachpositions.Length > 0)
            {
                string[] coach = coachpositions.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                coachList.AddRange(coach);

                if (coach.Length<28)
                {
                    for(int i= coach.Length;i<28;i++)
                    {
                        coachList.Add(" ");
                    }
                }
               
                for (int i = 0; i < coachList.ToArray().Length; i++)
                {
                    byte[] CoachPositionBytes = Encoding.BigEndianUnicode.GetBytes(coachList.ToArray()[i]);
                    SubcoachBytes.AddRange(CoachPositionBytes);
                    SubcoachBytes.AddRange(BaseClass.Seperators);
                    SubcoachBytes.AddRange(ConvertDecimalNumberTOByteArray(sum = sum + gap));
                    gap = 21;
                    if (i > 0 && (i + 1) % 7 == 0)
                    {
                        coachBytes.Add(SubcoachBytes.ToArray());
                        SubcoachBytes.Clear();
                         sum = 67;
                         gap = 0;
                    }
                }
                if (SubcoachBytes.Count > 0)
                {
                    coachBytes.Add(SubcoachBytes.ToArray());
                    SubcoachBytes.Clear();
                    sum = 0;
                }
                return coachBytes;
            }
            else
            {
                return null;
            }
      }


    }
}

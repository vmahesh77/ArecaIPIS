using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArecaIPIS.Classes
{
    public class Board
    {
        public static int PDC = 1;
        public static int CGDB = 2;
        public static int PFDB = 3;
        public static int AGDB = 4;
        public static int MLDB = 5;
        public static int IVD = 6;
        public static int OVD = 7;
        public static int CCTV = 8;

        public static int LinkCheck = 128; //80
        public static int DataTransfer = 129;//81
        public static int Stop = 130;//82
        public static int Start = 131;//83
        public static int SetConfiguration = 132;//84
        public static int GetConfiguration = 133;//85
        public static int SoftReset =134;//86
        public static int DefaultData = 135;//87
        public static int MessageData = 136;//88
        public static int DeleteData = 137;//89
       
    }
}

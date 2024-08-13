using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArecaIPIS.Classes
{
    class ByteFormation
    {



        public static string convertDecimalToBinary(int decimalValue)
        {

            string binaryValue = Convert.ToString(decimalValue, 2); // Convert decimal to binary

            // Ensure the binary string is at least 3 characters wide
            string paddedBinaryValue = binaryValue.PadLeft(3, '0');

            return paddedBinaryValue;


        }
        public static string AppendBinaryValueRightToLeft(string originalBinary, string binaryValue, int position)
        {
            // Ensure the original binary string is at least 8 characters wide
            string paddedOriginalBinary = originalBinary.PadLeft(8, '0');

            // Create a character array to modify the original binary string
            char[] binaryArray = paddedOriginalBinary.ToCharArray();

            // Calculate the starting position for appending the binary value
            int start = Math.Max(0, 8 - position - binaryValue.Length);

            // Append the binary value from right to left within the 8-bit representation
            for (int i = 0; i < binaryValue.Length; i++)
            {
                binaryArray[start + i] = binaryValue[i];
            }

            // Convert the modified character array back to a string
            string resultBinaryValue = new string(binaryArray);

            return resultBinaryValue;
        }

        public static int convertBinaryToDecimal(string binaryValue)
        {


            int decimalValue = Convert.ToInt32(binaryValue, 2); // Convert binary to decimal

            return decimalValue;


        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTools.Helpers
{
    public class CryptoHelper
    {
        public static byte[] HexStringToBytes(string hexStr)
        {
            int strLength = hexStr.Length;
            byte[] bytes = new byte[strLength / 2];
            for (int i = 0; i < strLength; i += 2)
                bytes[i / 2] = Convert.ToByte(hexStr.Substring(i, 2), 16);

            return bytes;
        }

        public static string BytesToHexString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder(bytes.Length * 2);
            foreach (byte bt in bytes)
                sb.AppendFormat("{0:x2}", bt);

            return sb.ToString();
        }
    }
}

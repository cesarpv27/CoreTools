using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CoreTools.Helpers;

namespace CoreTools.Cryptography
{
    [Obsolete("Not implemented", true)]
    public static class RijndaelManagedCrypto
    {
        private static byte[] keyAndIvBytes;

        static RijndaelManagedCrypto()
        {
            throw new NotImplementedException("Not implemented yet");

            string privateKey = "";
            keyAndIvBytes = Encoding.UTF8.GetBytes(privateKey);
        }

        public static string DecodeAndDecrypt(string cipherText)
        {
            string DecodeAndDecrypt = AesDecrypt(CryptoHelper.HexStringToBytes(cipherText));
            return (DecodeAndDecrypt);
        }

        public static string EncryptAndEncode(string plaintext)
        {
            return CryptoHelper.BytesToHexString(AesEncrypt(plaintext));
        }

        private static string AesDecrypt(Byte[] inputBytes)
        {
            Byte[] outputBytes = inputBytes;

            string plaintext = string.Empty;

            using (MemoryStream memoryStream = new MemoryStream(outputBytes))
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream,
                    GetCryptoAlgorithm().CreateDecryptor(keyAndIvBytes, keyAndIvBytes), CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(cryptoStream))
                    {
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }

            return plaintext;
        }

        private static byte[] AesEncrypt(string inputText)
        {
            byte[] inputBytes = UTF8Encoding.UTF8.GetBytes(inputText);

            byte[] result = null;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, GetCryptoAlgorithm().CreateEncryptor(keyAndIvBytes, keyAndIvBytes), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(inputBytes, 0, inputBytes.Length);
                    cryptoStream.FlushFinalBlock();

                    result = memoryStream.ToArray();
                }
            }

            return result;
        }

        private static RijndaelManaged GetCryptoAlgorithm()
        {
            RijndaelManaged algorithm = new RijndaelManaged
            {
                //set the mode, padding and block size
                Padding = PaddingMode.PKCS7,
                Mode = CipherMode.CBC,
                KeySize = 128,
                BlockSize = 128
            };
            return algorithm;
        }
    }
}

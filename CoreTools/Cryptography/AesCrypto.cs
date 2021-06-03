using CoreTools.Helpers;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using ExThrower = CoreTools.Throws.ExceptionThrower;

namespace CoreTools.Cryptography
{
    public static class AesCrypto
    {
        #region Encrypt

        public static string Encrypt(string plainText, string privateKey)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(privateKey);
            byte[] aesKey = SHA256Managed.Create().ComputeHash(passwordBytes);
            byte[] aesIV = MD5.Create().ComputeHash(passwordBytes);

            return EncryptToString_Aes(plainText, aesKey, aesIV, CipherMode.CBC, PaddingMode.PKCS7);
        }

        public static string EncryptToString_Aes(
            string plainText,
            byte[] aesKey,
            byte[] aesIV,
            CipherMode mode,
            PaddingMode paddingMode)
        {
            return CryptoHelper.BytesToHexString(EncryptToBytes_Aes(plainText, aesKey, aesIV, mode, paddingMode));
        }

        public static byte[] EncryptToBytes_Aes(
            string plainText, 
            byte[] aesKey, 
            byte[] aesIV, 
            CipherMode mode, 
            PaddingMode paddingMode)
        {
            #region Params validations

            if (plainText == null || plainText.Length <= 0)
                ExThrower.ST_ThrowIfArgumentIsNullOrEmpty(nameof(plainText));
            if (aesKey == null || aesKey.Length <= 0)
                ExThrower.ST_ThrowIfArgumentIsNullOrEmpty(nameof(aesKey));
            if (aesIV == null || aesIV.Length <= 0)
                ExThrower.ST_ThrowIfArgumentIsNullOrEmpty(nameof(aesIV));

            #endregion

            using (var _aes = Aes.Create())
            {
                InitializeAesAlg(_aes, aesKey, aesIV, mode, paddingMode);

                ICryptoTransform encryptor = CreateEncryptor(_aes);

                return ExecuteCrypto(encryptor, CryptoStreamMode.Write, plainText) as byte[];
            }
        }

        #endregion

        #region Decrypt

        public static string Decrypt(string cipherText, string privateKey)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(privateKey);
            byte[] aesKey = SHA256Managed.Create().ComputeHash(passwordBytes);
            byte[] aesIV = MD5.Create().ComputeHash(passwordBytes);

            return DecryptFromString_Aes(cipherText, aesKey, aesIV, CipherMode.CBC, PaddingMode.PKCS7);
        }

        public static string DecryptFromString_Aes(
            string cipherText,
            byte[] aesKey,
            byte[] aesIV,
            CipherMode mode,
            PaddingMode paddingMode)
        {
            return DecryptFromBytes_Aes(CryptoHelper.HexStringToBytes(cipherText), aesKey, aesIV, mode, paddingMode);
        }

        public static string DecryptFromBytes_Aes(
            byte[] cipherText,
            byte[] aesKey,
            byte[] aesIV,
            CipherMode mode,
            PaddingMode paddingMode)
        {
            #region Params validations

            if (cipherText == null || cipherText.Length <= 0)
                ExThrower.ST_ThrowIfArgumentIsNullOrEmpty(nameof(cipherText));
            if (aesKey == null || aesKey.Length <= 0)
                ExThrower.ST_ThrowIfArgumentIsNullOrEmpty(nameof(aesKey));
            if (aesIV == null || aesIV.Length <= 0)
                ExThrower.ST_ThrowIfArgumentIsNullOrEmpty(nameof(aesIV));

            #endregion

            using (var _aes = Aes.Create())
            {
                InitializeAesAlg(_aes, aesKey, aesIV, mode, paddingMode);

                ICryptoTransform decryptor = CreateDecryptor(_aes);

                return ExecuteCrypto(decryptor, CryptoStreamMode.Read, cipherText: cipherText) as string;
            }
        }

        #endregion

        private static void InitializeAesAlg(
            Aes _aes,
            byte[] aesKey,
            byte[] aesIV,
            CipherMode mode,
            PaddingMode paddingMode)
        {
            _aes.Key = aesKey;
            _aes.IV = aesIV;
            _aes.Mode = mode;
            _aes.Padding = paddingMode;
        }

        private static ICryptoTransform CreateEncryptor(Aes _aes)
        {
            return _aes.CreateEncryptor(_aes.Key, _aes.IV);
        }

        private static ICryptoTransform CreateDecryptor(Aes _aes)
        {
            return _aes.CreateDecryptor(_aes.Key, _aes.IV);
        }

        private static object ExecuteCrypto(
            ICryptoTransform cryptoTransform, 
            CryptoStreamMode csMode, 
            string plainText = null, 
            byte[] cipherText = null)
        {
            using (var memStream = CreateMemoryStream(cipherText))
            {
                using (var _cryptoStream = new CryptoStream(memStream, cryptoTransform, csMode))
                {
                    switch (csMode)
                    {
                        case CryptoStreamMode.Read:
                            using (var _streamReader = new StreamReader(_cryptoStream))
                                return _streamReader.ReadToEnd();
                        case CryptoStreamMode.Write:
                            using (var _streamWriter = new StreamWriter(_cryptoStream))
                                _streamWriter.Write(plainText);
                            return memStream.ToArray();
                        default:
                            ExThrower.ST_ThrowArgumentOutOfRangeException(csMode);
                            return null;
                    }
                }
            }
        }

        private static MemoryStream CreateMemoryStream(byte[] buffer = null)
        {
            if (buffer == null)
                return new MemoryStream();

            return new MemoryStream(buffer);
        }
    }
}

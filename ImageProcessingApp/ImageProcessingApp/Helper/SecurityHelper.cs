using System;
using System.Security.Cryptography;
using System.Text;

namespace ImageProcessingApp
{
    public class SecurityHelper
    {
        // Security Key Setup here or one can set in appsetting config too
        private const string SecurityKey = "951%m@E#e(n+X!a&H|^t@(*159";


        /// <summary>
        /// Encryption Method for any sensitive data
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Encrypt(string plainText)
        {
            byte[] toEncryptedArray = Encoding.UTF8.GetBytes(plainText);

            using var objMD5CryptoService = MD5.Create();
            byte[] securityKeyArray = objMD5CryptoService.ComputeHash(Encoding.UTF8.GetBytes(SecurityKey));

            using var objAesCryptoService = Aes.Create();
            objAesCryptoService.Key = securityKeyArray;
            objAesCryptoService.Mode = CipherMode.ECB;
            objAesCryptoService.Padding = PaddingMode.PKCS7;

            using var objCryptoTransform = objAesCryptoService.CreateEncryptor();
            byte[] resultArray = objCryptoTransform.TransformFinalBlock(toEncryptedArray, 0, toEncryptedArray.Length);
            objAesCryptoService.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// Decryption Method for any sensitive data
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Decrypt(string cipherText)
        {
            byte[] toDecryptedArray = Convert.FromBase64String(cipherText);

            using var objMD5CryptoService = MD5.Create();
            byte[] securityKeyArray = objMD5CryptoService.ComputeHash(Encoding.UTF8.GetBytes(SecurityKey));

            using var objAesCryptoService = Aes.Create();
            objAesCryptoService.Key = securityKeyArray;
            objAesCryptoService.Mode = CipherMode.ECB;
            objAesCryptoService.Padding = PaddingMode.PKCS7;

            using var objCryptoTransform = objAesCryptoService.CreateDecryptor();
            byte[] resultArray = objCryptoTransform.TransformFinalBlock(toDecryptedArray, 0, toDecryptedArray.Length);
            objAesCryptoService.Clear();
            return Encoding.UTF8.GetString(resultArray);
        }
    }
}

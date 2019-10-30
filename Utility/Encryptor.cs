using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class Encryptor
    {
        private const string securityKey = "IILHome";

        public static string Encrypt(string TextToEncrypt)
        {
            try
            {
                byte[] EncryptedArray = UTF8Encoding.UTF8.GetBytes(TextToEncrypt);

                MD5CryptoServiceProvider MD5CryptoService = new MD5CryptoServiceProvider();

                byte[] securityKeyArray = MD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(securityKey));
                MD5CryptoService.Clear();

                var TripleDESCryptoService = new TripleDESCryptoServiceProvider();
                TripleDESCryptoService.Key = securityKeyArray;
                TripleDESCryptoService.Mode = CipherMode.ECB;
                TripleDESCryptoService.Padding = PaddingMode.PKCS7;

                var CrytpoTransform = TripleDESCryptoService.CreateEncryptor();

                byte[] resultArray = CrytpoTransform.TransformFinalBlock(EncryptedArray, 0, EncryptedArray.Length);
                TripleDESCryptoService.Clear();

                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch (Exception ex)
            {
                Log4net.LogWriter("Encryption", "Encrypt", "Error : " + ex.Message, Entities.LogType.LogMode.Error);
            }
            return null;            
        }

        public static string Decrypt(string TextToDecrypt)
        {
            try
            {
                byte[] DecryptArray = Convert.FromBase64String(TextToDecrypt);
                MD5CryptoServiceProvider MD5CryptoService = new MD5CryptoServiceProvider();

                byte[] securityKeyArray = MD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(securityKey));
                MD5CryptoService.Clear();

                var TripleDESCryptoService = new TripleDESCryptoServiceProvider();
                TripleDESCryptoService.Key = securityKeyArray;
                TripleDESCryptoService.Mode = CipherMode.ECB;
                TripleDESCryptoService.Padding = PaddingMode.PKCS7;

                var CrytpoTransform = TripleDESCryptoService.CreateDecryptor();

                byte[] resultArray = CrytpoTransform.TransformFinalBlock(DecryptArray, 0, DecryptArray.Length);
                TripleDESCryptoService.Clear();

                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception ex)
            {
                Log4net.LogWriter("Encryption", "Decrypt", "Error : " + ex.Message, Entities.LogType.LogMode.Error);
            }
            return null;
        }
    }

}

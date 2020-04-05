using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SistemaGestaoClinicaMedica.Infra.CrossCutting.Config.Servicos
{
    public static class Encryption64
    {
        private const string _ENCRYPTION_KEY = "!#$5qRfa54?3?";
        private static readonly byte[] _key = Encoding.UTF8.GetBytes(_ENCRYPTION_KEY.Substring(0, 8));
        private static readonly byte[] _IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        private static readonly DESCryptoServiceProvider _desCryptoServiceProvider = new DESCryptoServiceProvider();

        public static string Encrypt(string stringToEncrypt)
        {
            using var memoryStream = new MemoryStream();
            using var cryptoStream = new CryptoStream(memoryStream, _desCryptoServiceProvider.CreateEncryptor(_key, _IV), CryptoStreamMode.Write);
            var inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);

            cryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
            cryptoStream.FlushFinalBlock();

            return Convert.ToBase64String(memoryStream.ToArray());
        }
    }
}

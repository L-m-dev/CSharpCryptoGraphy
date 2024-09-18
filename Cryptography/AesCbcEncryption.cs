using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Cryptography
{
    public class AesCbcEncryption
    {

        public static byte[] Encrypt(byte[] data, byte[] key, byte[] initializationVector)
        {
            using var aes = Aes.Create();

            aes.Key = key;

            var encryptedData = aes.EncryptCbc(data, initializationVector);

            return encryptedData;
        }

        public static byte[] Decrypt(byte[] data, byte[] key, byte[] initializationVector)
        {
            using var aes = Aes.Create();

            aes.Key = key;

            var decryptedData = aes.DecryptCbc(data, initializationVector);

            return decryptedData;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    public class RsaEncryption
    {
        private readonly RSA _rsa;

        public RsaEncryption()
        {
            _rsa = RSA.Create();
         }
        public byte[] Encrypt(string dataToEncrypt)
        {
            return _rsa.Encrypt(dataToEncrypt.ToBytes(), RSAEncryptionPadding.OaepSHA256);
        }
        public byte[] Decrypt(byte[] dataToDecrypt)
        {
            return _rsa.Decrypt(dataToDecrypt, RSAEncryptionPadding.OaepSHA256);
        }
        public byte[] ExportPublicKey()
        {
            return _rsa.ExportRSAPublicKey();
        }

        public void ImportPublicKey(byte[] publicKey)
        {
            _rsa.ImportRSAPublicKey(publicKey, out _);
        }
        public byte[] ExportPrivateKey(int numberOfIterations, string password)
        {
            var keyParams = new PbeParameters(
                PbeEncryptionAlgorithm.Aes256Cbc, HashAlgorithmName.SHA256, numberOfIterations);

            var encryptedPrivateKey = _rsa.ExportEncryptedPkcs8PrivateKey(
                password.ToBytes(), keyParams);

            return encryptedPrivateKey;
        }
        public void ImportPrivateKey(byte[] privateKey, string password)
        {
            _rsa.ImportEncryptedPkcs8PrivateKey(password, privateKey, out _);
        }
    }
}

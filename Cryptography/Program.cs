//AES with CBC mode. Cipher Block Chaining
//"data": serialized data to be encrypted
//"key": the key used for encryption
//"initilizationVector": used to create variability in the encrypted data such that the same 
// data encrypted with the same key would not produce the same output.

//testing AesCbc SIMMETRIC CRYPTO

using Cryptography;
using System.Security.Cryptography;
using System.Text;

var message = "Alef went to high school";

//Checking contents.
byte[] msgAsBytes = Encoding.UTF8.GetBytes(message);
Console.WriteLine(msgAsBytes);

var initializationVector = RandomNumberGenerator.GetBytes(16);
var key = RandomNumberGenerator.GetBytes(32);

var encryptedData = AesCbcEncryption.Encrypt(message.ToBytes(), key, initializationVector);
var decryptedData = AesCbcEncryption.Decrypt(encryptedData, key, initializationVector);

Console.WriteLine(decryptedData.BytesToString());
 
//testing RSA 

var rsa = new RsaEncryption();

//create PrivateKey. The second value, password, should be secret
byte[] encryptedPrivateKey = rsa.ExportPrivateKey(100, "alembik");

//export Public Key
byte[] publicKey = rsa.ExportPublicKey();

message = "Encryption is okay";

var encryptedMessage = rsa.Encrypt(message);

//Creating new encryptor that will decrypt this...
var rsa2Receiver = new RsaEncryption();
//import the other guy's public key.
rsa2Receiver.ImportPublicKey(publicKey);

//Import Private Key. Unsure about this line.
rsa2Receiver.ImportPrivateKey(encryptedPrivateKey, "alembik");

var decryptedMessage = rsa2Receiver.Decrypt(encryptedMessage).BytesToString();
Console.WriteLine(decryptedMessage);

//MD5 Hashes


MD5 md5 = MD5.Create();

message = "Joy in hashing";

var data = md5.ComputeHash(Encoding.UTF8.GetBytes(message));

var resultHash = GenerateHashString(data); 
Console.WriteLine(resultHash);
 
//sha256 Hashes

SHA256 sHA256 = SHA256.Create();
data = sHA256.ComputeHash(Encoding.UTF8.GetBytes(message));
resultHash = GenerateHashString(data);
Console.WriteLine(resultHash);


Console.ReadLine();

//helper function
string GenerateHashString(byte[] data)
{
    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < data.Length; i++)
    {
        sb.Append(data[i].ToString("x2")); // 
    }
    return sb.ToString();
}




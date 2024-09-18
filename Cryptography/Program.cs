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
byte[] msgAsBytes = Encoding.UTF8.GetBytes(message);
 Console.WriteLine(msgAsBytes);

var initializationVector = RandomNumberGenerator.GetBytes(16);
var key = RandomNumberGenerator.GetBytes(32);

var encryptedData = AesCbcEncryption.Encrypt(message.ToBytes(), key, initializationVector);
var decryptedData = AesCbcEncryption.Decrypt(encryptedData, key, initializationVector);

Console.WriteLine(decryptedData.BytesToString());
Console.ReadLine();
//

//testing RSA 

var rsa = new RsaEncryption();

//createPRivateKey
byte[] encryptedPrivateKey = rsa.ExportPrivateKey(100, "alembik");

//export public Key
byte[] publicKey = rsa.ExportPublicKey();

message = "Encryption is okay";

var encryptedMessage = rsa.Encrypt(message);

//Creating new encryptor that will decrypt this...
var rsa2 = new RsaEncryption();
//import the other guy's public key.
rsa2.ImportPublicKey(publicKey);

rsa2.ImportPrivateKey(encryptedPrivateKey, "alembik");

var decryptedMessage = rsa2.Decrypt(encryptedMessage).BytesToString();


Console.WriteLine(decryptedMessage);
Console.ReadLine();







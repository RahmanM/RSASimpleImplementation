Very simple and easy to understand implementation of the the RSA encryption in C#.

```c#

// generate keys
var tempPublicKey = "";
var tempPrivateKey = "";

var rsa = new RsaEnctiption();
rsa.GenerateKeys(out tempPrivateKey , out tempPublicKey);

// Encrypt using the public key
string stringToEncrypt = "Hello World";
var encrypted = rsa.Encrypt(stringToEncrypt, tempPublicKey);

// Decrypt using the private keys
var decrypted = encrypter.Decrypt(encrypted, tempPrivateKey);

```

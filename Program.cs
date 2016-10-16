using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicPrivateKeyEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            var tempPublicKey = "";
            var tempPrivateKey = "";
            // generate keys
            var rsa = new RsaEnctiption();
            rsa.GenerateKeys(out tempPrivateKey , out tempPublicKey);

            var encrypter = new RsaEnctiption();
            
            string stringToEncrypt = "Hello World";
            Console.WriteLine("String to enrypt->" + stringToEncrypt);
            var encrypted = encrypter.Encrypt(stringToEncrypt, tempPublicKey);
            Console.WriteLine("String encrypted->" + encrypted);

            var decrypted = encrypter.Decrypt(encrypted, tempPrivateKey);
            Console.WriteLine("Decrypted string->" + decrypted);

            Console.ReadLine();
        }
    }
}

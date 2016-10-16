using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace PublicPrivateKeyEncryption
{
    public interface IRSAEnctiption
    {
        string Encrypt(string input, string publicKey);
        string Decrypt(string input, string privateKey);
        void GenerateKeys(out string publicPrivateKey, out string publicKey);
    }

    public class RsaEnctiption : IRSAEnctiption
    {
        /// <summary>
        /// Encrypt the input string using the public key
        /// </summary>
        /// <param name="input">Input string to encrypt</param>
        /// <param name="publicKey">Public key to use to encrypt</param>
        public string Encrypt(string input, string publicKey)
        {
            input.ThrowIfNull("input");
            publicKey.ThrowIfNull("publicKey");

            var rsaCryptoServiceProvider = new RSACryptoServiceProvider();
            rsaCryptoServiceProvider.FromXmlString(publicKey);
            byte[] data = Encoding.Default.GetBytes(input);
            byte[] cipherText = rsaCryptoServiceProvider.Encrypt(data, false);
            var encrypted = Convert.ToBase64String(cipherText);
            return encrypted;
        }

        /// <summary>
        /// Decrypts the encrypted string using the private key
        /// </summary>
        /// <param name="input">Encrypted input</param>
        /// <param name="privatekey">Private key to use to decrypt</param>
        public string Decrypt(string input, string privatekey)
        {
            var cipher = new RSACryptoServiceProvider();
            cipher.FromXmlString(privatekey);
            byte[] ciphterText = Convert.FromBase64String(input);
            byte[] plainText = cipher.Decrypt(ciphterText, false);
            var decrypted = Encoding.Default.GetString(plainText);
            return decrypted;
        }

        /// <summary>
        /// Function that generates the Private and public keys to be used for encryption and decryption
        /// </summary>
        /// <param name="publicPrivateKey">Output public key</param>
        /// <param name="publicKey">Output private key</param>
        public void GenerateKeys(out string publicPrivateKey, out string publicKey)
        {
            var rsaCryptoServiceProvider = new RSACryptoServiceProvider();
            rsaCryptoServiceProvider.PersistKeyInCsp = false;
            publicPrivateKey = rsaCryptoServiceProvider.ToXmlString(true);
            publicKey = rsaCryptoServiceProvider.ToXmlString(false);
        }

    }

    /// <summary>
    /// Extention method for the parameter
    /// </summary>
    public static class Guard
    {
        public static void ThrowIfNull<T>(this T argument, string argumentName)
        {
            if (argument.GetType().IsPrimitive)
            {
                return;
            }

            if (argument == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }









}
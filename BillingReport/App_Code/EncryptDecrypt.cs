using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

  public   class EncryptDecrypt
    {
        static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ZeroCool");//ZeroCool

        private static readonly byte[] _key = { 0xA1, 0xF1, 0xA6, 0xBB, 0xA2, 0x5A, 0x37, 0x6F, 0x81, 0x2E, 0x17, 0x41, 0x72, 0x2C, 0x43, 0x27 };
        private static readonly byte[] _initVector = { 0xE1, 0xF1, 0xA6, 0xBB, 0xA9, 0x5B, 0x31, 0x2F, 0x81, 0x2E, 0x17, 0x4C, 0xA2, 0x81, 0x53, 0x61 };
        /// <summary>
        /// Encrypt a string.
        /// </summary>
        /// <param name="originalString">The original string.</param>
        /// <returns>The encrypted string.</returns>
        /// <exception cref="ArgumentNullException">This exception will be thrown when the original string is null or empty.</exception>
        public static string Encrypt(string originalString)
        {
            string encrypt = string.Empty;
            try
            {
                if (String.IsNullOrEmpty(originalString))
                {
                    throw new ArgumentNullException("The string which needs to be encrypted can not be null.");
                }

                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);

                StreamWriter writer = new StreamWriter(cryptoStream);
                writer.Write(originalString);
                writer.Flush();
                cryptoStream.FlushFinalBlock();
                writer.Flush();
                encrypt = Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return encrypt;
        }

        /// <summary>
        /// Decrypt a crypted string.
        /// </summary>
        /// <param name="cryptedString">The crypted string.</param>
        /// <returns>The decrypted string.</returns>
        /// <exception cref="ArgumentNullException">This exception will be thrown when the crypted string is null or empty.</exception>
        public static string Decrypt(string cryptedString,ref bool isError)
        {
            string decrypt = string.Empty;
            try
            {
                if (String.IsNullOrEmpty(cryptedString))
                {
                    throw new ArgumentNullException("The string which needs to be decrypted can not be null.");
                }

                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cryptedString));
                CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
                StreamReader reader = new StreamReader(cryptoStream);
                decrypt = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
                isError = true;
            }

            return decrypt;
        }

        public static string Decrypt(string cryptedString)
        {
            string decrypt = string.Empty;
            try
            {
                if (String.IsNullOrEmpty(cryptedString))
                {
                    throw new ArgumentNullException("The string which needs to be decrypted can not be null.");
                }
                //cryptedString = cryptedString.Replace(" ", "+");
                //cryptedString = cryptedString.Replace("}", string.Empty);
                //cryptedString = cryptedString.Replace("/", string.Empty);
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cryptedString));
                CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
                StreamReader reader = new StreamReader(cryptoStream);
                decrypt = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                ex.Data.Clear();               
            }

            return decrypt;
        }

        public static string DecryptNew(string cryptedString)
        {
            string decrypt = string.Empty;
            try
            {
                if (String.IsNullOrEmpty(cryptedString))
                {
                    throw new ArgumentNullException("The string which needs to be decrypted can not be null.");
                }
                int _lenght = cryptedString.Length;
                cryptedString = cryptedString.Replace(" ", "+");
                //cryptedString = cryptedString.Replace("}", string.Empty);
                try
                {
                    cryptedString = cryptedString.Remove(cryptedString.LastIndexOf("}"), 1);
                }
                catch (Exception ex)
                {
                    ex = null;
                }
                try
                {
                    cryptedString = cryptedString.Remove(cryptedString.LastIndexOf("/"), 1);
                }
                catch (Exception ex)
                {
                    ex = null;
                }
                
                //cryptedString = cryptedString.Replace("/", string.Empty);                                  
                
                
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cryptedString));
                CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
                StreamReader reader = new StreamReader(cryptoStream);
                decrypt = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }

            return decrypt;
        }
        
    }


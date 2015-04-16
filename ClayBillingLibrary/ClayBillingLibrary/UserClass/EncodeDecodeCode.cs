using System;
using System.Collections.Generic;
using System.Text;
using DalClayBilling;
using ClayBillingLibrary;
namespace ClayBillingLibrary
{
    public static class EncodeDecodeCode
    {
        private static string _b64 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijk.mnopqrstuvwxyz-123456789+/=";
        private static string key = "key to encript";

        public static string Encode(string data)
        {
            int keypos = 0;
            string binarydata = "";
            //convert the sting to a 8bit binary data
            foreach (char c in data)
            {
                int xor = ((int)c ^ (int)key[keypos]) + (key.Length);
                Console.WriteLine("{0} = {1}\t{2} = {3}: {4} = {5}", c, (int)c, key[keypos], (int)key[keypos], xor, DecToBinary(xor, 8));
                if (++keypos >= key.Length)
                    keypos = 0;

                binarydata += DecToBinary(xor, 8);
            }

            int m = 0;
            string cipher = "";
            // splitt the binary string to 4 byte chunks and assign each chunk the proper b64 value
            for (int i = 0; i < binarydata.Length; i += 4)
            {
                int v = BinToDec(binarydata.Substring(i, 4));
                cipher += GetB64FromN(v * 4 + m);
                Console.WriteLine("{0}\t{1}\t{2} {3}", v, v * 4 + m, m, GetB64FromN(v * 4 + m)[0]);
                if (++m > 3)
                    m = 0;
            }
            return cipher;
        }

        public static string Decode(string data)
        {
            int m = 0;
            string binarydata = "";
            // convert the b64 string to binary string
            foreach (char c in data)
            {
                int v = (GetNFromB64(c) - m) / 4;
                binarydata += DecToBinary(v, 4);
                Console.WriteLine("{0}", DecToBinary(v, 4));
                if (++m > 3)
                    m = 0;
            }

            // chop the 8bit binaries and mix back the key into it
            int keypos = 0;
            string decoded = "";
            for (int i = 0; i < binarydata.Length; i += 8)
            {
                if (i + 8 > binarydata.Length)
                    break;
                int c = BinToDec(binarydata.Substring(i, 8));
                int dc = (c - key.Length) ^ (int)key[keypos];
                Console.WriteLine("{0} = {1}", binarydata.Substring(i, 8), c);
                Console.WriteLine("               {0} - {1} ^ {2} = {3}", c, key.Length - 1, (int)key[keypos], (c - key.Length) ^ (int)key[keypos]);

                if (++keypos >= key.Length)
                    keypos = 0;

                decoded += new string((char)dc, 1);
            }
            return decoded;
        }
        // expects a base64 character and returns it's position in the base64 alphabet
        private static int GetNFromB64(char n)
        {
            return _b64.IndexOf(n);
        }

        // expects a position in the base64 alphabet and returns it's base64 character.
        private static string GetB64FromN(int n)
        {
            if (n > _b64.Length)
                return "="; // well, we shouldn't reach this line. If we do, the encoding will be garbage anyway...

            return new string(_b64[n], 1);
        }

        // expects a integer value and length of the binary string (e.g. 4, 8, 16). 
        // returns the padded binary string
        private static string DecToBinary(int value, int length)
        {

            string binString = "";

            while (value > 0)
            {
                binString += value % 2;
                value /= 2;
            }

            // we need to reverse the binary string
            // that's why we are using this array stuff here.

            string reverseString = "";
            foreach (char c in binString)
                reverseString = new string((char)c, 1) + reverseString;
            binString = reverseString;

            // do the padding here
            binString = new string((char)'0', length - binString.Length) + binString;

            return binString;
        }

        // expects the binary string and returns it's integer equivalent
        private static int BinToDec(string Binary)
        {
            return Convert.ToInt32(Binary, 2);
        }
    }
}

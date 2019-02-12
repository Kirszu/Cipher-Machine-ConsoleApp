using System;
using System.Text.RegularExpressions;

namespace ConsoleApp15
{
    public class CaesarCipher : ICipher
    {
        public string Decrypt(string input)
        {
            string text = input;
            int key = 5;
            char[] charArray = text.ToCharArray();
            int[] asciiArray = new int[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                asciiArray[i] = (int)charArray[i];
                // Keep char if it is a space
                if (asciiArray[i] == 32)
                {
                    charArray[i] = (char)32;
                }
                else if (asciiArray[i] >= 97)     // If statement for small letters
                {
                    if (asciiArray[i] - key < 97)
                    {
                        asciiArray[i] += 26 - key;
                    }
                    else
                    {
                        asciiArray[i] -= key;
                    }
                }
                else if (asciiArray[i] < 97)   // If statement for capital letters
                {
                    if (asciiArray[i] - key < 65)
                    {
                        asciiArray[i] += 26 - key;
                    }
                    else
                    {
                        asciiArray[i] -= key;
                    }
                }
                charArray[i] = (char)asciiArray[i];
            }
            String result = new string(charArray);
            Console.WriteLine("Caesar Decrypt (5) UZXEJP -> " + result);
            return result;
        }

        public string Encrypt(string input)
        {
            String text = input;
            int key = 5;
            char[] charArray = text.ToCharArray();
            int[] asciiArray = new int[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                asciiArray[i] = (int)charArray[i];
                // Keep char if it is a space
                if (asciiArray[i] == 32)
                {
                    charArray[i] = (char)32;
                }
                else if (asciiArray[i] >= 97)  // If statement for small letters
                {
                    if (asciiArray[i] + key > 122)
                    {
                        asciiArray[i] = asciiArray[i] - 26 + key;
                    }
                    else
                    {
                        asciiArray[i] += key;
                    }
                }
                else if (asciiArray[i] < 97) // If statement for capital letters
                {
                    if (asciiArray[i] + key > 90)
                    {
                        asciiArray[i] = asciiArray[i] - 26 + key;
                    }
                    else
                    {
                        asciiArray[i] += key;
                    }
                }
                charArray[i] = (char)asciiArray[i];
            }
            String result = new string(charArray);
            Console.WriteLine("Caesar Decrypt (5) PUSZEK -> " + result);
            return result;
        }

        public string RemoveSpecialCharacters(string input)
        {
            return Regex.Replace(input, "[^0-9A-Za-z ,]", "");
        }
    }


}

using System;
using System.Text.RegularExpressions;

namespace ConsoleApp15
{
    public class VigenereCipher : ICipher
    {
        public string Decrypt(string input)
        {
            string temp = input;
            string text = RemoveSpecialCharacters(input.Replace(" ", "").ToUpper());

            string key = "KOT";
            key = key.ToUpper();

            char[] textArray = text.ToCharArray();
            char[] keyArray = new char[text.Length];

            //Adding characters to keyArray until there is the same amount of chars as in textArray
            FillArray(keyArray, text.Length, key.Length, key);

            for (int i = 0; i < text.Length; i++)
            {            
                if (textArray[i] - keyArray[i] >= 0)
                {
                    textArray[i] = (char)(textArray[i] - keyArray[i] + 65);
                }
                else
                 {
                    textArray[i] = (char)(textArray[i] - keyArray[i] + 91);
                 }       
            }
            char[] resultArray = new char[temp.Length];
            int j = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == 32)
                {
                    resultArray[i] = ' ';
                }
                else
                {
                    if (char.IsLower(temp[i]))
                    {
                        resultArray[i] = char.ToLower(textArray[j]);
                    }
                    else
                    {
                        resultArray[i] = textArray[j];
                    }
                    j++;
                }
            }
            return new string(resultArray);
        }

        private void FillArray(char[] keyArray, int textLength, int keyLength, string key)
        {
            int temp = 0;
            for (int i = 0; i < textLength; i++)
            {
                if (i >= keyLength)
                {
                    keyArray[i] = key[temp];
                    temp++;
                    if (temp >= key.Length)
                    {
                        temp = 0;
                    }
                }
                else
                {
                    keyArray[i] = key[i];
                }
            }
        }

        public string Encrypt(string input)
        {
            string temp = input;
            string text = RemoveSpecialCharacters(input.Replace(" ", "").ToUpper());

            string key = "KOT";
            key = key.ToUpper();
            char[] textArray = text.ToCharArray();
            char[] keyArray = new char[text.Length];

            //Adding characters to keyArray until there is the same amount of chars as in textArray
            FillArray(keyArray, text.Length, key.Length, key);

            for (int i = 0; i < text.Length; i++)
            {
                if (textArray[i] + keyArray[i] > 155)
                {
                    textArray[i] = (char)(textArray[i] + keyArray[i] - 91);
                }
                else
                {
                    textArray[i] = (char)(textArray[i] + keyArray[i] - 65);
                }
            }

            char[] resultArray = new char[temp.Length];
            int j = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == 32)
                {
                    resultArray[i] = ' ';
                }
                else
                {
                    if (char.IsLower(temp[i]))
                    {
                        resultArray[i] = char.ToLower(textArray[j]);
                    }
                    else
                    {
                        resultArray[i] = textArray[j];
                    }
                    j++;
                }
            }
            return new string(resultArray);
        }

        public string RemoveSpecialCharacters(string input)
        {
            return Regex.Replace(input, "[^0-9A-Za-z ,]", "");
        }
    }


}

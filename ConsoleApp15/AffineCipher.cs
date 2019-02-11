using System;

namespace ConsoleApp15
{
    public class AffineCipher : ICipher
    {
        public string Decrypt(string input)
        {
            int keyA = 15;
            int keyB = 17;
            String temp = input;
            String text = input.ToUpper();
            char[] charArray = text.ToCharArray();

            int inv = InvertionOfKey(keyA);

            // Affine decipher formula
            for (int i = 0; i < text.Length; i++)
            {
                if (charArray[i] == 32)
                {
                    charArray[i] = (char)32;
                }
                else
                {
                    charArray[i] = (char)((inv * (charArray[i] - keyB) % 26) + 65);
                    if (charArray[i] >= 78)
                    {
                        charArray[i] = (char)(charArray[i] - 13);
                    }
                    else
                    {
                        charArray[i] = (char)(charArray[i] + 13);
                    }
                }
               
            }
            return SetEqualCharCase(charArray, temp);
        }

        public string Encrypt(string input)
        {
            int keyA = 15;
            int keyB = 17;
            string temp = input;
            string text = input.ToUpper();
            char[] charArray = text.ToCharArray();

            // Using the affine cipher formula
            for (int i = 0; i < text.Length; i++)
            {
                if (charArray[i] == 32)
                {
                    charArray[i] = (char)32;
                }
                else
                {
                    charArray[i] = (char)(((keyA * charArray[i] + keyB) % 26) + 65);
                    if (charArray[i] >= 78)
                    {
                        charArray[i] = (char)(charArray[i] - 13);
                    }
                    else
                    {
                        charArray[i] = (char)(charArray[i] + 13);
                    }
                }
            }
            return SetEqualCharCase(charArray, temp);
        }

        public string StripAccent(string input)
        {
            return input;
        }

        public int InvertionOfKey(int key)
        {
            int inv = 0;
            int temp;
            for (int i = 0; i <= 26; i++)
            {
                temp = (key * i) % 26;
                if (temp == 1)
                {
                    inv = i;
                    break;
                }
            }
            return inv;
        }

        private string SetEqualCharCase(char[] inputToChange, string caseTemplate)
        {
            for (int i = 0; i < inputToChange.Length; i++)
            {
                if (char.IsLower(caseTemplate[i]))
                {
                    inputToChange[i] = char.ToLower(inputToChange[i]);
                }
            }
            return new string(inputToChange);
        }
    }
}

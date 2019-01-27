using System;

namespace ConsoleApp15
{
    public class VigenereCipher : ICipher
    {
        public string Decrypt(string input)
        {
            String text = input;
            text = text.ToUpper();

            String key = "KOT";
            key = key.ToUpper();

            char[] textArray = text.ToCharArray();
            char[] keyArray = new char[text.Length];

            //Adding characters to keyArray until there is the same amount of chars as in textArray
            FillArray(keyArray, text.Length, key.Length, key);
            int[] asciiTextArray = new int[text.Length];
            int[] asciiKeyArray = new int[text.Length];
            int[] asciiNewText = new int[text.Length];
            char[] asciiFinalText = new char[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                asciiTextArray[i] = (int)textArray[i];
                asciiKeyArray[i] = (int)keyArray[i];
                asciiNewText[i] = asciiTextArray[i] - asciiKeyArray[i];
                if (asciiNewText[i] >= 0)
                {
                    asciiFinalText[i] = (char)(asciiNewText[i] + 65);
                }
                else
                {
                    asciiFinalText[i] = (char)(asciiNewText[i] + 91);
                }
            }
            String result = new string(asciiFinalText);
            Console.WriteLine("Vigenere Decrypt (KOT) ZILJSD -> " + result);
            return result;
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
            String text = input;
            text = text.ToUpper();

            String key = "KOT";
            key = key.ToUpper();
            char[] textArray = text.ToCharArray();
            char[] keyArray = new char[text.Length];

            //Adding characters to keyArray until there is the same amount of chars as in textArray
            FillArray(keyArray, text.Length, key.Length, key);

            int[] asciiTextArray = new int[text.Length];
            int[] asciiKeyArray = new int[text.Length];
            int[] asciiNewText = new int[text.Length];
            char[] asciiFinalText = new char[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                asciiTextArray[i] = (int)textArray[i];
                asciiKeyArray[i] = (int)keyArray[i];
                asciiNewText[i] = asciiTextArray[i] + asciiKeyArray[i];
                if (asciiNewText[i] > 155)
                {
                    asciiFinalText[i] = (char)(asciiNewText[i] - 91);
                }
                else
                {
                    asciiFinalText[i] = (char)(asciiNewText[i] - 65);
                }
            }

            String result = new string(asciiFinalText);
            Console.WriteLine("Vigenere Encrypt (KOT) PUSZEK -> " + result);
            return result;
        }

        public string StripAccent(string input)
        {
            Console.WriteLine("Work");
            return input;
        }
    }


}

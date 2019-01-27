using System;

namespace ConsoleApp15
{
    public class AffineCipher : ICipher
    {
        public string Decrypt(string input)
        {
            int keyA = 15;
            int keyB = 17;
            String text = input;
            text = text.ToUpper();
            char[] charArray = text.ToCharArray();
            int[] asciiArray = new int[text.Length];
            int[] newAsciiArray = new int[text.Length];
            int[] asciiCharsAdded = new int[text.Length];

            // Invertion of keyA
            int inv = InvertionOfKey(keyA);

            // Using the affine decipher formula
            for (int i = 0; i < text.Length; i++)
            {
                asciiArray[i] = (int)charArray[i];
                newAsciiArray[i] = (inv * (asciiArray[i] - keyB) % 26) + 65;
                if (newAsciiArray[i] >= 78)
                {
                    asciiCharsAdded[i] = newAsciiArray[i] - 13;
                }
                else
                {
                    asciiCharsAdded[i] = newAsciiArray[i] + 13;
                }
                charArray[i] = (char)asciiCharsAdded[i];
            }
            String result = new string(charArray);
            Console.WriteLine("Affine Decrypt (15, 17) IFBCZL -> " + result);
            return result;
        }

        public string Encrypt(string input)
        {
            int keyA = 15;
            int keyB = 17;
            String text = input;
            text = text.ToUpper();
            char[] charArray = text.ToCharArray();
            int[] asciiArray = new int[text.Length];
            int[] newAsciiArray = new int[text.Length];
            int[] asciiCharsAdded = new int[text.Length];

            // Using the affine cipher formula
            for (int i = 0; i < text.Length; i++)
            {
                asciiArray[i] = (int)charArray[i];
                newAsciiArray[i] = ((keyA * asciiArray[i] + keyB) % 26) + 65;
                if (newAsciiArray[i] >= 78)
                {
                    asciiCharsAdded[i] = newAsciiArray[i] - 13;
                }
                else
                {
                    asciiCharsAdded[i] = newAsciiArray[i] + 13;
                }
                charArray[i] = (char)asciiCharsAdded[i];
            }
            String result = new string(charArray);
            Console.WriteLine("Affine Encrypt (15, 17) PUSZEK -> " + result);
            return result;
        }

        public string StripAccent(string input)
        {
            Console.WriteLine("Work");
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
    }


}

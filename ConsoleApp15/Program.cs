using System;

namespace ConsoleApp15
{
    interface ICipher
    {
        string Encrypt(string input);
        string Decrypt(string input);
        string StripAccent(string input);

    }
    class Program
    {
        static void Main(string[] args)
        {
            CaesarCipher caesar = new CaesarCipher();
            string test = "PUSZEK";
            caesar.Encrypt(test);
            test = "UZXEJP";
            caesar.Decrypt(test);
            caesar.StripAccent(test);
            AffineCipher affine = new AffineCipher();
            test = "PUSZEK";
            affine.Encrypt(test);
            test = "IFBCZL";
            affine.Decrypt(test);
            affine.StripAccent(test);
            VigenereCipher vigenere = new VigenereCipher();
            test = "PUSZEK";
            vigenere.Encrypt(test);
            test = "ZILJSD";
            vigenere.Decrypt(test);
            vigenere.StripAccent(test);
            Console.ReadLine();


        }
    }

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

        public string StripAccent(string input)
        {
            Console.WriteLine("Work");
            return input;
        }
    }

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

using System;

namespace ConsoleApp15
{
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


}

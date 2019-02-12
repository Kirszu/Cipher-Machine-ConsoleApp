namespace ConsoleApp15
{
    interface ICipher
    {
        string Encrypt(string input);
        string Decrypt(string input);
        string RemoveSpecialCharacters(string input);

    }


}

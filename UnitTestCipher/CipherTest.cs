using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestCipher
{
    [TestClass]
    public class CaesarCipher
    {
        [TestMethod]
        public void EncryptValidInput()
        {
            // Arrange
            CaesarCipher caesar = new CaesarCipher();
            string input = "PUSZEK";

            // Act
            string test = caesar.Encrypt(input);

            // Assert

        }
       
    }
}

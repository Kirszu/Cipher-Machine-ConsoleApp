using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp15;

namespace CipherUnitTest
{
    [TestClass]
    public class CipherTests
    {
        [TestMethod]
        public void EncryptValidInput()
        {
            // Arrange
            CaesarCipher caesar = new CaesarCipher();
            string input = "PUSZEK";
            string expected = "UZXEJP";
            // Act
            string actual = caesar.Encrypt(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DecryptValidInput()
        {
            // Arrange
            CaesarCipher caesar = new CaesarCipher();
            string input = "UZXEJP";
            string expected = "PUSZEK";
            // Act
            string actual = caesar.Decrypt(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

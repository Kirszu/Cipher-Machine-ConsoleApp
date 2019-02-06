using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp15;

namespace CipherUnitTest
{
    [TestClass]
    public class CipherTests
    {
        [TestMethod]
        public void CaesarEncryptValidInput()
        {
            // Arrange
            CaesarCipher cipher = new CaesarCipher();
            string input = "PUSZEK";
            string expected = "UZXEJP";
            // Act
            string actual = cipher.Encrypt(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CaesarDecryptValidInput()
        {
            // Arrange
            CaesarCipher cipher = new CaesarCipher();
            string input = "UZXEJP";
            string expected = "PUSZEK";
            // Act
            string actual = cipher.Decrypt(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AffineEncryptValidInput()
        {
            // Arrange
            AffineCipher cipher = new AffineCipher();
            string input = "PUSZEK";
            string expected = "IFBCZL";
            // Act
            string actual = cipher.Encrypt(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AffineDecryptValidInput()
        {
            // Arrange
            AffineCipher cipher = new AffineCipher();
            string input = "IFBCZL";
            string expected = "PUSZEK";
            // Act
            string actual = cipher.Decrypt(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VigenereEncryptValidInput()
        {
            // Arrange
            VigenereCipher cipher = new VigenereCipher();
            string input = "PUSZEK";
            string expected = "ZILJSD";
            // Act
            string actual = cipher.Encrypt(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void VigenereDecryptValidInput()
        {
            // Arrange
            VigenereCipher cipher = new VigenereCipher();
            string input = "ZILJSD";
            string expected = "PUSZEK";
            // Act
            string actual = cipher.Decrypt(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

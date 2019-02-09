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
        public void CaesarEncryptValidInputWithSpace()
        {
            // Arrange
            CaesarCipher cipher = new CaesarCipher();
            string input = "asdf test";
            string expected = "fxik yjxy";
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
        public void CaesarDecryptValidInputWithSpace()
        {
            // Arrange
            CaesarCipher cipher = new CaesarCipher();
            string input = "ASDF TEST";
            string expected = "VNYA OZNO";
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
        public void AffineEncryptValidInputWithSpace()
        {
            // Arrange
            AffineCipher cipher = new AffineCipher();
            string input = "PUSZEK puszek";
            string expected = "IFBCZL ifbczl";
            // Act
            string actual = cipher.Encrypt(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AffineDecryptValidInputUpperCase()
        {
            // Arrange
            AffineCipher cipher = new AffineCipher();
            string input = "TEST";
            string expected = "ONHO";
            // Act
            string actual = cipher.Decrypt(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AffineDecryptValidInputLowerCase()
        {
            // Arrange
            AffineCipher cipher = new AffineCipher();
            string input = "test";
            string expected = "onho";
            // Act
            string actual = cipher.Decrypt(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AffineDecryptValidInputMixedCase()
        {
            // Arrange
            AffineCipher cipher = new AffineCipher();
            string input = "testTESTtEsT";
            string expected = "onhoONHOoNhO";
            // Act
            string actual = cipher.Decrypt(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AffineDecryptValidInputWithSpace()
        {
            // Arrange
            AffineCipher cipher = new AffineCipher();
            string input = "test zxyq asdf";
            string expected = "qzbq cynx rbko";
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
        public void VigenereEncryptValidInputWithSpace()
        {
            // Arrange
            VigenereCipher cipher = new VigenereCipher();
            string input = "asdf test zqok";
            string expected = "kgwp hxch sacd";
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

        [TestMethod]
        public void VigenereDecryptValidInputWithSpace()
        {
            // Arrange
            VigenereCipher cipher = new VigenereCipher();
            string input = "asdf test zqok";
            string expected = "kgwp hxch sacd";
            // Act
            string actual = cipher.Decrypt(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

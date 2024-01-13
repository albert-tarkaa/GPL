using GPL.Utilities;
using System.Windows.Forms;

namespace GPLTests
{
    /// <summary>
    /// Unit tests for the FileService class.
    /// </summary>
    public class FileServiceTests
    {  
        /// <summary>
        /// Tests the ReadFromFile method with a valid text file. Expects the content to be set to the RichTextBox.
        /// </summary>
        [TestMethod]
        public void ReadFromFile_ValidTextFile_SetsContentToRichTextBox()
        {
            // Arrange
            var richTextBox = new RichTextBox();

            // Act
            var result = FileService.ReadFromFile(richTextBox);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tests the ReadFromFile method with an invalid text file. Expects the method to return false.
        /// </summary>
        [TestMethod]
        public void ReadFromFile_InvalidTextFile_ReturnsFalse()
        {
            // Arrange
            var richTextBox = new RichTextBox();

            // Act
            var result = FileService.ReadFromFile(richTextBox);

            // Assert
            Assert.IsFalse(result);
        }
    }
}

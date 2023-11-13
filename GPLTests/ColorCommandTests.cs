using System.Drawing;
using System.Windows.Forms;
using GPL.Commands;
using GPL.Utilities;

namespace GPLTests
{
    [TestClass]
    public class ColorCommandTests
    {
        [TestMethod]
        public void Constructor_NullCoordinatesManager_ThrowsArgumentNullException()
        {
            // Arrange
            var pictureBox = new PictureBox();
            var color = Color.Red;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ColorCommand(null, pictureBox, color));
        }

        [TestMethod]
        public void Constructor_NullPictureBox_ThrowsArgumentNullException()
        {
            // Arrange
            var coordinatesManager = new DrawingSettings();
            var color = Color.Red;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ColorCommand(coordinatesManager, null, color));
        }

        [TestMethod]
        public void Execute_ValidParameters_SetsColorAndRefreshesPictureBox()
        {
            // Arrange
            var coordinatesManager = new DrawingSettings();
            var pictureBox = new PictureBox();
            var color = Color.Red;
            var graphics = Graphics.FromImage(new Bitmap(100, 100));
            var colorCommand = new ColorCommand(coordinatesManager, pictureBox, color);

            // Act
            colorCommand.Execute(graphics);

            // Assert
            Assert.AreEqual(color, coordinatesManager.color);
        }
    }


}

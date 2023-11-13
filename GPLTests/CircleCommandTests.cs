using GPL.Commands;
using GPL.Utilities;
using Moq;
using System.Drawing;

namespace GPLTests
{
    [TestClass]
    public class CircleCommandTests
    {
        [TestMethod]
        public void CircleCommand_WithInvalidRadius_ThrowsException()
        {
            // Arrange
            var invalidRadius = -35;
            var drawingSettings = new DrawingSettings(new Bitmap(100, 100));

            //Act
            void act()
            {
                new CircleCommand(invalidRadius, drawingSettings);
            }

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(act);
        }

    }
}
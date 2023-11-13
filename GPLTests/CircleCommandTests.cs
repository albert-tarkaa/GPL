using GPL.Commands;
using GPL.Utilities;
using Moq;
using System.Drawing;

namespace GPLTests
{
    /// <summary>
    /// Test class for the CircleCommand class.
    /// </summary>
    [TestClass]
    public class CircleCommandTests
    {

        /// <summary>
        /// Tests that the CircleCommand constructor throws an ArgumentOutOfRangeException
        /// when an invalid radius is provided.
        /// </summary>
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

        /// <summary>
        /// Tests the constructor of the <see cref="CircleCommand"/> class with valid parameters x,y.
        /// </summary>
        [TestMethod]
        public void Constructor_WithValidParameters_InitializationSuccessful()
        {
            // Arrange
            var stateManagerMock = new Mock<DrawingSettings>();

            // Act
            var CircleCommand = new CircleCommand(45, stateManagerMock.Object);

            // Assert
            Assert.IsNotNull(CircleCommand);
        }

    }
}
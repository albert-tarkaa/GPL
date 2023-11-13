using GPL.Commands;
using GPL.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace GPLTests
{
    /// <summary>
    /// Unit tests for the <see cref="RectangleCommand"/> class.
    /// </summary>
    [TestClass]
    public class RectangleCommandTests
    {
        /// <summary>
        /// Tests the constructor of the <see cref="RectangleCommand"/> class with valid parameters x,y.
        /// </summary>
        [TestMethod]
        public void Constructor_WithValidParameters_InitializationSuccessful()
        {
            // Arrange
            var stateManagerMock = new Mock<DrawingSettings>();

            // Act
            var rectangleCommand = new RectangleCommand(5, 8, stateManagerMock.Object);

            // Assert
            Assert.IsNotNull(rectangleCommand);
        }

        /// <summary>
        /// Tests the constructor of the <see cref="RectangleCommand"/> class with a negative X parameter.
        /// Expects an <see cref="ArgumentOutOfRangeException"/>.
        /// </summary>
        [TestMethod]
        public void Constructor_WithNegativeX_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var stateManagerMock = new Mock<DrawingSettings>();

            // Act
            Action act = () => new RectangleCommand(-5, 8, stateManagerMock.Object);

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(act, "Negative X should throw ArgumentOutOfRangeException.");
        }

        /// <summary>
        /// Tests the constructor of the <see cref="RectangleCommand"/> class with a negative Y parameter.
        /// Expects an <see cref="ArgumentOutOfRangeException"/>.
        /// </summary>
        [TestMethod]
        public void Constructor_WithNegativeY_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var stateManagerMock = new Mock<DrawingSettings>();

            // Act
            Action act = () => new RectangleCommand(5, -8, stateManagerMock.Object);

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(act, "Negative Y should throw ArgumentOutOfRangeException.");
        }
    }
}

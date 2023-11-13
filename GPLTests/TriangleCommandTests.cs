using GPL.Commands;
using GPL.Utilities;
using Moq;

namespace GPLTests
{
    [TestClass]
    public class TriangleCommandTests
    {
        /// <summary>
        /// Tests the constructor of the <see cref="TriangleCommand"/> class with valid parameters x,y.
        /// </summary>
        [TestMethod]
        public void Constructor_WithValidParameters_InitializationSuccessful()
        {
            // Arrange
            var stateManagerMock = new Mock<DrawingSettings>();

            // Act
            var triangleCommand = new TriangleCommand(5, 8, stateManagerMock.Object);

            // Assert
            Assert.IsNotNull(triangleCommand);
        }

        /// <summary>
        /// Tests the constructor of the <see cref="TriangleCommand"/> class with a negative X parameter.
        /// Expects an <see cref="ArgumentOutOfRangeException"/>.
        /// </summary>
        [TestMethod]
        public void Constructor_WithNegativeX_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var stateManagerMock = new Mock<DrawingSettings>();

            // Act
            Action act = () => new TriangleCommand(-5, 8, stateManagerMock.Object);

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(act, "Negative X should throw ArgumentOutOfRangeException.");
        }


    }
}

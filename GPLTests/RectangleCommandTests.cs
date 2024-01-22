using GPL.Commands;
using GPL.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Drawing;

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
            string x = "5";
            string y = "8";

            // Act
            var rectangleCommand = new RectangleCommand(x, y, stateManagerMock.Object);

            // Assert
            Assert.IsNotNull(rectangleCommand);
        }


        /// <summary>
        /// Tests the constructor of the <see cref="RectangleCommand"/> class with a negative parameter.
        /// Expects an <see cref="ArgumentOutOfRangeException"/>.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_WithNegativeArgs_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var stateManagerMock = new Mock<DrawingSettings>();
            var x = "x";
            var y = "y";
            VariableManager.AssignVariable(x, -10);
            VariableManager.AssignVariable(y, 8);

            // Act
            Action act = () => new RectangleCommand(x, y, stateManagerMock.Object);

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(act, "Value must be greater than 0.");
        }

        /// <summary>
        /// Tests the constructor of the <see cref="RectangleCommand"/> class with a null string parameter.
        /// Expects an <see cref="ArgumentException"/>.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithNullArgs_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var stateManagerMock = new Mock<DrawingSettings>();
            var x = "x";
            var y = "y";
            VariableManager.AssignVariable(x, "");
            VariableManager.AssignVariable(y, 8);

            // Act
            Action act = () => new RectangleCommand(x, y, stateManagerMock.Object);

            // Assert
            Assert.ThrowsException<ArgumentException>(act, "Value cannot be null or empty.");
        }

        /// <summary>
        /// Tests the constructor of the <see cref="RectangleCommand"/> class with a zero parameter.
        /// Expects an <see cref="ArgumentOutOfRangeException"/>.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_WithZeroValues_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var stateManagerMock = new Mock<DrawingSettings>();
            var x = "x";
            var y = "y";
            VariableManager.AssignVariable(x, 0);
            VariableManager.AssignVariable(y, 8);

            // Act
            Action act = () => new RectangleCommand(x, y, stateManagerMock.Object);

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(act, "Value must be greater than zero.");
        }
    }
}

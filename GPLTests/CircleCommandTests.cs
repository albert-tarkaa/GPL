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
        /// when an negative radius is provided.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CircleCommand_WithNegativeRadius_ThrowsException()
        {
            // Arrange
            string invalidRadius = "invalidRadius";
            var drawingSettings = new DrawingSettings(new Bitmap(100, 100));
            VariableManager.AssignVariable(invalidRadius, -35);

            //Act
            void act()
            {
                new CircleCommand(invalidRadius, drawingSettings);
            }

            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(act);
        }

        /// <summary>
        /// Tests the constructor of the <see cref="CircleCommand"/> class with a valid int parameter.
        /// </summary>
        [TestMethod]
        public void Constructor_WithValidParameters_InitializationSuccessful()
        {
            // Arrange
            var stateManagerMock = new Mock<DrawingSettings>();
            string validRadius = "validRadius";

            //Act
            var CircleCommand = new CircleCommand(validRadius, stateManagerMock.Object);

            //Act
            Assert.IsNotNull(CircleCommand);
        }

        /// <summary>
        /// Tests the constructor of the <see cref="CircleCommand"/> class with valid parameter assignment.
        /// </summary>
        [TestMethod]
        public void Constructor_WithValidParameterAssignment_InitializationSuccessful()
        {
            // Arrange
            var stateManagerMock = new Mock<DrawingSettings>();
            var radiusVariableName = "radiusParameter";
            VariableManager.AssignVariable(radiusVariableName, 50);

            // Act
            var CircleCommand = new CircleCommand(radiusVariableName, stateManagerMock.Object);

            // Assert
            Assert.IsNotNull(CircleCommand);
        }

        /// <summary>
        /// Tests the Execute method of the CircleCommand class with an invalid radius parameter.
        /// Expects an InvalidOperationException to be thrown.
        /// </summary>
        [TestMethod]
        public void Constructor_WithInValidParameterAssignment_InitializationSuccessful()
        {
            // Arrange
            var stateManagerMock = new Mock<DrawingSettings>();
            var radiusVariableName = "radiusParameter";
            VariableManager.AssignVariable(radiusVariableName, 15);

            // Act
            var CircleCommand = new CircleCommand(radiusVariableName, stateManagerMock.Object);

            // Assert
            Assert.IsNotNull(CircleCommand);
        }

        /// <summary>
        /// Tests the Execute method of the CircleCommand class with a non-integer variable radius parameter.
        /// Expects an InvalidOperationException to be thrown.
        /// </summary>
        /// [TestMethod]
        public void Constructor_WithInValidIntParameter_InitializationSuccessful()
        {
            // Arrange
            var stateManagerMock = new Mock<DrawingSettings>();
            var radiusVariableName = "radiusParameter";
            VariableManager.AssignVariable(radiusVariableName, "noneIntValue");

            // Act
            var CircleCommand = new CircleCommand(radiusVariableName, stateManagerMock.Object);

            // Assert
            Assert.IsNotNull(CircleCommand);
        }

        /// <summary>
        /// Tests the Execute method of the CircleCommand class with a radius value of 0.
        /// Expects an ArgumentOutOfRangeException to be thrown.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_WithZeroIntParameter_InitializationSuccessful()
        {
            // Arrange
            var stateManagerMock = new Mock<DrawingSettings>();
            var radiusVariableName = "radiusParameter";
            VariableManager.AssignVariable(radiusVariableName, 0);

            // Act
            var CircleCommand = new CircleCommand(radiusVariableName, stateManagerMock.Object);

            // Assert
            Assert.IsNotNull(CircleCommand);
        }

        /// <summary>
        /// Tests the Execute method of the CircleCommand class with a null string radius.
        /// Expects an ArgumentException to be thrown.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WithNullParameter_InitializationSuccessful()
        {
            // Arrange
            var stateManagerMock = new Mock<DrawingSettings>();
            var radiusVariableName = "radiusParameter";
            VariableManager.AssignVariable(radiusVariableName, "");

            // Act
            var CircleCommand = new CircleCommand(radiusVariableName, stateManagerMock.Object);

            // Assert
            Assert.IsNotNull(CircleCommand);
        }

    }
}
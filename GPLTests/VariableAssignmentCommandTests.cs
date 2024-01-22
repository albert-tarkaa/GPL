using GPL.Utilities;
using Moq;
using System.Drawing;

namespace GPL.Commands.Tests
{
    public class VariableDeclaration
    {

        public string variableName { get; set; }
        public int variableValue { get; set; }

        public VariableDeclaration(string VariableName, int VariableValue)
        {
            variableName = VariableName;
            variableValue = VariableValue;
        }
        public string GetCommandItem()
        {
            return $"{variableName}={variableValue}";
        }

    }
    /// <summary>
    /// Test class for the VariableAssignmentCommand class.
    /// </summary>
    [TestClass]
    public class VariableAssignmentCommandTests
    {
        /// <summary>
        /// Tests the basic variable assignment functionality of the Execute method.
        /// </summary>
        [TestMethod]
        public void Execute_VariableAssignment_SetsVariableValue()
        {
            // Arrange
            var stateManagerMock = new Mock<DrawingSettings>();
            var command1 = new VariableAssignmentCommand("num1 = 25", stateManagerMock.Object);

            // Act
            command1.Execute(null);


            // Assert
            Assert.AreEqual(25, VariableManager.CheckVariable("num1"));
        }

        /// <summary>
        /// Tests variable manipulation expression functionality of the Execute method by adding 10 the variablevalue.
        /// </summary>
        [TestMethod]
        public void Execute_VariableManipulation_SetsVariableValue()
        {
            // Arrange
            var stateManagerMock = new Mock<DrawingSettings>();
            var command1 = new VariableAssignmentCommand("num1 = 25", stateManagerMock.Object);
            var command2 = new VariableAssignmentCommand("num2 = num1 + 10", stateManagerMock.Object);
          

            // Act
            command1.Execute(null);
            command2.Execute(null);


            // Assert
            Assert.AreEqual(35, VariableManager.CheckVariable("num2"));
        }

        /// <summary>
        /// Tests variable manipulation expression functionality with an invalid operator.
        /// Expects an InvalidOperationException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Execute_InvalidOperator_ThrowsException()
        {
            // Arrange
            var stateManagerMock = new Mock<DrawingSettings>();
            var command1 = new VariableAssignmentCommand("num1 = 25", stateManagerMock.Object);
            var command2 = new VariableAssignmentCommand("num2 = num1 ^ 10", stateManagerMock.Object);


            // Act
            command1.Execute(null);
            command2.Execute(null);


            // Assert
            Assert.AreEqual(35, VariableManager.CheckVariable("num2"));
        }

        /// <summary>
        /// Tests variable manipulation expression functionality with a syntax error.
        /// Expects an InvalidOperationException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Execute_SyntaxError_ThrowsException()
        {
            // Arrange
            var stateManagerMock = new Mock<DrawingSettings>();
            var command1 = new VariableAssignmentCommand("num1 = 25", stateManagerMock.Object);
            var command2 = new VariableAssignmentCommand("num2 = num1 + ", stateManagerMock.Object);


            // Act
            command1.Execute(null);
            command2.Execute(null);


            // Assert
            Assert.AreEqual(35, VariableManager.CheckVariable("num2"));
        }

        /// <summary>
        /// Tests variable manipulation expression functionality with an undeclared variable.
        /// Expects an InvalidOperationException.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Execute_UndeclaredVariable_ThrowsException()
        {
            // Arrange
            var stateManagerMock = new Mock<DrawingSettings>();

            // var command1 = new VariableAssignmentCommand("num1 = 25", stateManagerMock.Object);
            // command1.Execute(null);

            // Act and Assert
            var command2 = new VariableAssignmentCommand("num2 = num1 + 10", stateManagerMock.Object);
            command2.Execute(null);
        }

    }
}

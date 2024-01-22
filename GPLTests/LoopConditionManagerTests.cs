using GPL.Commands;
using GPL.Utilities;
using Moq;

namespace GPLTests
{
    [TestClass]
    public class LoopConditionManagerTests
    {
        // Is operand1 < operand2
        [TestMethod]
        public void Process_ValidLessThanCondition_ReturnsTrue()
        {
            // Arrange
            var stateManagerMock = new Mock<DrawingSettings>();
            var command1 = new VariableAssignmentCommand("count = 5", stateManagerMock.Object);
            string condition = "count < 10";

            // Act
            command1.Execute(null);
            bool result = LoopConditionManager.Process(condition);

            // Assert
            Assert.IsTrue(result, " '5 < 10' should be true.");
        }

        //Is operand1 > operand2
        [TestMethod]
        public void Process_ValidGreaterThanCondition_ReturnsTrue()
        {
            // Arrange
            var stateManagerMock = new Mock<DrawingSettings>();
            var command1 = new VariableAssignmentCommand("num11 = 50", stateManagerMock.Object);
            string condition = "num11 > 10";

            // Act
            command1.Execute(null);
            bool result = LoopConditionManager.Process(condition);

            // Assert
            Assert.IsTrue(result, "'50 > 5' should be true.");
        }

        // Test for a valid condition where a == b
        [TestMethod]
        public void Process_ValidEqualCondition_ReturnsTrue()
        {
            // Arrange
            var stateManagerMock = new Mock<DrawingSettings>();
            var command1 = new VariableAssignmentCommand("num15 = 50", stateManagerMock.Object);
            string condition = "num15 = 50";

            // Act
            command1.Execute(null);
            bool result = LoopConditionManager.Process(condition);

            // Assert
            Assert.IsTrue(result, "'num15 == 50' should be true.");
        }

        // Test case for a valid condition where a != b
        [TestMethod]
        public void Process_ValidNotEqualCondition_ReturnsTrue()
        {
            // Arrange
            var stateManagerMock = new Mock<DrawingSettings>();
            var command1 = new VariableAssignmentCommand("delta = 50", stateManagerMock.Object);
            string condition = "delta != 60";

            // Act
            command1.Execute(null);
            bool result = LoopConditionManager.Process(condition);

            // Assert
            Assert.IsTrue(result, "'delta != 60' should be true.");
        }

        // Test case for an unsupported operator * in the condition
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Process_UnsupportedOperator_ThrowsInvalidOperationException()
        {
            // Arrange
            var stateManagerMock = new Mock<DrawingSettings>();
            var command1 = new VariableAssignmentCommand("beta = 50", stateManagerMock.Object);
            string condition = "beta * 50";

            // Act
            command1.Execute(null);
            bool result = LoopConditionManager.Process(condition);

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => LoopConditionManager.Process(condition));
        }
    }
}

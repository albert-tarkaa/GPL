using GPL.Commands;
using Moq;
using System.Drawing;

namespace GPLTests
{
    [TestClass]
    public class CommandParserTests
    {
        /// <summary>
        /// Test for adding a valid command to the command list.
        /// </summary>
        [TestMethod]
        public void AddCommand_ValidCommand_AddsCommandToList()
        {
            // Arrange
            var parser = new CommandParser();
            var commandMock = new Mock<ICommand>();

            // Act
            parser.AddCommand(commandMock.Object);

            // Assert
            Assert.AreEqual(1, parser.Commands.Count);
            Assert.AreEqual(commandMock.Object, parser.Commands[0]);
        }
    }
}

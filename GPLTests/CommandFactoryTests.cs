using GPL.Commands;
using GPL.Utilities;
using Moq;
using System.Drawing;
using System.Windows.Forms;

namespace GPLTests
{
    /// <summary>
    /// Test class for the CommandFactory.
    /// </summary>
    [TestClass]
    public class CommandFactoryTests
    {
        /// <summary>
        /// Verifies that an ArgumentNullException is thrown when the CreateCommand method is called with a null command item.
        /// </summary>
        [TestMethod]
        public void CreateCommand_WithInvalidCommandItem_ThrowsArgumentNullException()
        {
            // Arrange
            var gplPanel = new PictureBox();
            var coordinatesManager = new DrawingSettings();
            var bitmap = new Bitmap(100, 100);
            var commandFactory = new CommandFactory("", gplPanel, coordinatesManager, bitmap);

            // Act
            Action act = () => commandFactory.CreateCommand("");

            // Assert
            Assert.ThrowsException<ArgumentNullException>(act);
        }


        /// <summary>
        /// Verifies that an ArgumentNullException is thrown when the CreateCommand method is called with an unknown command item.
        /// </summary>
        [TestMethod]
        public void CreateCommand_WithUnknownCommandType_ThrowsInvalidOperationException()
        {
            // Arrange
            var gplPanel = new PictureBox();
            var coordinatesManager = new DrawingSettings();
            var bitmap = new Bitmap(100, 100);
            var commandFactory = new CommandFactory("gibberish", gplPanel, coordinatesManager, bitmap);

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => commandFactory.CreateCommand("gibberish"));
        }

        /// <summary>
        /// Verifies that the CreateCommand method creates a DrawTo command when provided with a valid drawto command item.
        /// </summary>
        [TestMethod]
        public void AddCommandFromText_ValidCommand_AddsCommandToParser()
        {
            // Arrange
            var gplPanel = new PictureBox();
            var coordinatesManager = new DrawingSettings();
            var bitmap = new Bitmap(100,100);
            var commandFactory = new CommandFactory("drawto 10, 20", gplPanel, coordinatesManager, bitmap);
            var parser = new CommandParser();

            // Act
            Action act = () => commandFactory.AddCommandFromText("drawto 10, 20", parser);

            // Assert
            act.Invoke(); 

            Assert.AreEqual(1, parser.Commands.Count);
        }

        /// <summary>
        /// Tests that adding a valid command with invalid parameters does not add the command to the parser.
        /// </summary>
        [TestMethod]
        public void AddCommandFromText_ValidCommandWithInvalidParameters_ThrowsException()
        {
            // Arrange
            var gplPanel = new PictureBox();
            var coordinatesManager = new DrawingSettings();
            var bitmap = new Bitmap(100, 100);
            var commandFactory = new CommandFactory("moveto invalidX, invalidY", gplPanel, coordinatesManager, bitmap);
            var parser = new CommandParser();

            // Act
            Action act = () => commandFactory.AddCommandFromText("moveto invalidX, invalidY", parser);

            // Assert
            Assert.ThrowsException<InvalidOperationException>(act, "Invalid parameters for the command.");
            Assert.AreEqual(0, parser.Commands.Count);
        }


    }
}

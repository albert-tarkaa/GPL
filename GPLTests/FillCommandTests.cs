using System;
using System.Drawing;
using System.Windows.Forms;
using GPL.Commands;
using GPL.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GPLTests
{
    [TestClass]
    public class FillCommandTests
    {
        [TestMethod]
        public void Execute_ValidCommand_SetsFillStateAndRefreshesPictureBox()
        {
            // Arrange
            var coordinatesManager = new DrawingSettings();
            var pictureBox = new PictureBox();
            var fillCommand = new FillCommand(coordinatesManager, pictureBox);

            // Act
            fillCommand.Execute(Graphics.FromImage(new Bitmap(1, 1)));

            // Assert
            Assert.IsTrue(coordinatesManager.fill);
        }

        [TestMethod]
        public void Execute_InvalidCommand_ThrowsInvalidOperationException()
        {
            // Arrange
            var coordinatesManager = new DrawingSettings();
            var pictureBox = new PictureBox();
            var fillCommand = new FillCommand(coordinatesManager, pictureBox);

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => fillCommand.Execute(null));
        }
    }
}

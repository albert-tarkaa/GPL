using GPL.Commands;
using GPL.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Drawing;

namespace GPLTests
{
    [TestClass]
    public class TriangleCommandTests
    {
        [TestMethod]
        public void Execute_DrawTriangle()
        {
            // Arrange
            var stateManagerMock = new Mock<DrawingSettings>();
            stateManagerMock.SetupGet(s => s.GlobalX).Returns(10);
            stateManagerMock.SetupGet(s => s.GlobalY).Returns(10);
            stateManagerMock.SetupGet(s => s.color).Returns(Color.Black);
            stateManagerMock.SetupGet(s => s.fill).Returns(false);

            var graphicsMock = new Mock<Graphics>();

            var triangleCommand = new TriangleCommand(5, 8, stateManagerMock.Object);

            // Act
            triangleCommand.Execute(graphicsMock.Object);

            // Assert
            graphicsMock.Verify(g => g.DrawPolygon(It.IsAny<Pen>(), It.IsAny<Point[]>()), Times.Once);
        }

        [TestMethod]
        public void Execute_FillTriangle()
        {
            // Arrange
            var stateManagerMock = new Mock<DrawingSettings>();
            stateManagerMock.SetupGet(s => s.GlobalX).Returns(10);
            stateManagerMock.SetupGet(s => s.GlobalY).Returns(10);
            stateManagerMock.SetupGet(s => s.color).Returns(Color.Black);
            stateManagerMock.SetupGet(s => s.fill).Returns(true);

            var graphicsMock = new Mock<Graphics>();

            var triangleCommand = new TriangleCommand(5, 8, stateManagerMock.Object);

            // Act
            triangleCommand.Execute(graphicsMock.Object);

            // Assert
            graphicsMock.Verify(g => g.FillPolygon(It.IsAny<SolidBrush>(), It.IsAny<Point[]>()), Times.Once);
        }

        [TestMethod]
        public void Execute_WithException_ThrowsInvalidOperationException()
        {
            // Arrange
            var stateManagerMock = new Mock<DrawingSettings>();
            stateManagerMock.SetupGet(s => s.GlobalX).Returns(10);
            stateManagerMock.SetupGet(s => s.GlobalY).Returns(10);
            stateManagerMock.SetupGet(s => s.color).Returns(Color.Black);
            stateManagerMock.SetupGet(s => s.fill).Returns(false);

            var graphicsMock = new Mock<Graphics>();
            graphicsMock.Setup(g => g.DrawPolygon(It.IsAny<Pen>(), It.IsAny<Point[]>()))
                .Throws(new Exception("Simulated exception"));

            var triangleCommand = new TriangleCommand(5, 8, stateManagerMock.Object);

            // Act and Assert
            Assert.ThrowsException<InvalidOperationException>(() => triangleCommand.Execute(graphicsMock.Object));
        }

        // Add more test cases as needed for different scenarios.
    }
}

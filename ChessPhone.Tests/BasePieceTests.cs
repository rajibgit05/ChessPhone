using ChessPhone.Interfaces;
using Moq;
using Xunit;

namespace ChessPhone.Tests
{
    public class BasePieceTests
    {
        [Fact]
        public void KeyPad_ShouldReturnExpectedValue()
        {
            // Arrange
            var mock = new Mock<IBasePiece>();
            var expectedKeyPad = new char[,]
            {
            { '1', '2', '3' },
            { '4', '5', '6' },
            { '7', '8', '9' },
            { '*', '0', '#' }
            };
            mock.Setup(bp => bp.KeyPad).Returns(expectedKeyPad);

            // Act
            var actualKeyPad = mock.Object.KeyPad;

            // Assert
            Assert.Equal(expectedKeyPad, actualKeyPad);
        }

        [Fact]
        public void Walks_ShouldReturnExpectedValue()
        {
            // Arrange
            var mock = new Mock<IBasePiece>();
            var expectedWalks = new List<(int, int)>
        {
            (1, 0),
            (0, 1),
            (-1, 0),
            (0, -1)
        };
            mock.Setup(bp => bp.Walks).Returns(expectedWalks);

            // Act
            var actualWalks = mock.Object.Walks;

            // Assert
            Assert.Equal(expectedWalks, actualWalks);
        }

        [Fact]
        public void CanWalkMultipleSteps_ShouldReturnExpectedValue()
        {
            // Arrange
            var mock = new Mock<IBasePiece>();
            var expectedValue = true;
            mock.Setup(bp => bp.CanWalkMultipleSteps).Returns(expectedValue);

            // Act
            var actualValue = mock.Object.CanWalkMultipleSteps;

            // Assert
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void MaxWalkLength_ShouldReturnExpectedValue()
        {
            // Arrange
            var mock = new Mock<IBasePiece>();
            var expectedLength = 5;
            mock.Setup(bp => bp.MaxWalkLength).Returns(expectedLength);

            // Act
            var actualLength = mock.Object.MaxWalkLength;

            // Assert
            Assert.Equal(expectedLength, actualLength);
        }
    }
}

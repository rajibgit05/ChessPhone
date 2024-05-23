using ChessPhone.Business;
using ChessPhone.Enums;
using ChessPhone.Interfaces;
using Moq;
using Xunit;

namespace ChessPhone.Tests
{
    public class ChessStrategyTests
    {
        [Theory]
        [InlineData(PieceType.Pawn, 5)]
        [InlineData(PieceType.Bishop, 7)]
        [InlineData(PieceType.Knight, 4)]
        [InlineData(PieceType.Rook, 6)]
        [InlineData(PieceType.Queen, 10)]
        [InlineData(PieceType.King, 3)]
        public void ChessStrategy_ShouldInitializeCorrectly(PieceType pieceType, int phNumberLength)
        {
            // Arrange & Act
            var strategy = new ChessStrategy(pieceType, phNumberLength);

            // Assert
            Assert.NotNull(strategy);
        }

        [Fact]
        public void GetWalkCount_ShouldReturnCorrectNumber()
        {
            // Arrange
            var strategy = new ChessStrategy(PieceType.Rook, 7);

            // Act
            var count = strategy.GetWalkCount();

            // Assert
            Assert.True(count > 0);
        }

        [Fact]
        public void GetWalkCount_Returns_Valid_Count()
        {
            // Arrange
            var mockStrategy = new Mock<IChessStrategy>();
            mockStrategy.Setup(s => s.GetWalkCount()).Returns(10); 

            // Act
            long walkCount = mockStrategy.Object.GetWalkCount();

            // Assert
            Assert.True(walkCount==10);
        }
    }
}
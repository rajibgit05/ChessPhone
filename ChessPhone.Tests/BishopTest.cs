using System;
using System.Collections.Generic;
using Xunit;

namespace ChessPhone.Tests
{
    public class BishopTests
    {
        [Fact]
        public void Bishop_ShouldInitializeCorrectly()
        {
            // Arrange
            int maxLength = 7;

            // Act
            var bishop = new Bishop(maxLength);

            // Assert
            Assert.NotNull(bishop);
            Assert.Equal(maxLength, bishop.MaxWalkLength);
        }

        [Fact]
        public void Bishop_Walks_ShouldReturnCorrectMoves()
        {
            // Arrange
            int maxLength = 7;
            var bishop = new Bishop(maxLength);
            var expectedWalks = new List<(int, int)>()
            {
                (1, 1), (-1, -1), (1, -1), (-1, 1),
            };

            // Act
            var actualWalks = bishop.Walks;

            // Assert
            Assert.Equal(expectedWalks, actualWalks);
        }

        [Fact]
        public void Bishop_CanWalkMultipleSteps_ShouldBeTrue()
        {
            // Arrange
            int maxLength = 7;
            var bishop = new Bishop(maxLength);

            // Act
            var canWalkMultipleSteps = bishop.CanWalkMultipleSteps;

            // Assert
            Assert.True(canWalkMultipleSteps);
        }
    }
}

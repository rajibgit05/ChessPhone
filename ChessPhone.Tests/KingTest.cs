using System;
using System.Collections.Generic;
using Xunit;

namespace ChessPhone.Business.Tests
{
    public class KingTests
    {
        [Fact]
        public void King_ShouldInitializeWithCorrectWalks()
        {
            // Arrange
            int maxLength = 1;
            var expectedWalks = new List<(int, int)>
            {
                (1,1), (1,0), (1,-1), (-1,1), (-1,0), (-1,-1), (0,1), (0,-1)
            };

            // Act
            var king = new King(maxLength);

            // Assert
            Assert.Equal(expectedWalks, king.Walks);
        }

        [Fact]
        public void King_ShouldNotBeAbleToWalkMultipleSteps()
        {
            // Arrange
            int maxLength = 1;

            // Act
            var king = new King(maxLength);

            // Assert
            Assert.False(king.CanWalkMultipleSteps);
        }

        [Fact]
        public void King_MaxWalkLength_ShouldBeSetCorrectly()
        {
            // Arrange
            int maxLength = 1;

            // Act
            var king = new King(maxLength);

            // Assert
            Assert.Equal(maxLength, king.MaxWalkLength);
        }        
    }
}

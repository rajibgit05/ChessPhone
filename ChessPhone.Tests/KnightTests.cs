using Xunit;

namespace ChessPhone.Business.Tests
{
    public class KnightTests
    {
        [Fact]
        public void Knight_ShouldInitializeWithCorrectWalks()
        {
            // Arrange
            int maxLength = 1;
            var expectedWalks = new List<(int, int)>
            {
                (1,2), (1,-2), (-1,2), (-1,-2), (2,1), (2,-1), (-2,1), (-2,-1)
            };

            // Act
            var knight = new Knight(maxLength);

            // Assert
            Assert.Equal(expectedWalks, knight.Walks);
        }

        [Fact]
        public void Knight_ShouldNotBeAbleToWalkMultipleSteps()
        {
            // Arrange
            int maxLength = 1;

            // Act
            var knight = new Knight(maxLength);

            // Assert
            Assert.False(knight.CanWalkMultipleSteps);
        }

        [Fact]
        public void Knight_MaxWalkLength_ShouldBeSetCorrectly()
        {
            // Arrange
            int maxLength = 1;

            // Act
            var knight = new Knight(maxLength);

            // Assert
            Assert.Equal(maxLength, knight.MaxWalkLength);
        }       
    }
}

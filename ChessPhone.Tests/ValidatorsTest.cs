using Xunit;

namespace ChessPhone.Validators.Tests
{
    public class ValidatorsTests
    {
        [Theory]
        [InlineData(0, 0, 3, 3, true)]
        [InlineData(2, 2, 3, 3, true)]
        [InlineData(-1, 0, 3, 3, false)]
        [InlineData(0, -1, 3, 3, false)]
        [InlineData(3, 0, 3, 3, false)]
        [InlineData(0, 3, 3, 3, false)]
        public void IsValidCoordinates_ShouldReturnExpectedResult(int pointX, int pointY, int row, int column, bool expected)
        {
            // Act
            var result = Validators.IsValidCoordinates(pointX, pointY, row, column);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("123", false)]
        [InlineData("0123", false)]
        [InlineData("123a", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        [InlineData("1", false)]
        public void IsValidNumber_ShouldReturnExpectedResult(string value, bool expected)
        {
            // Act
            var result = Validators.IsValidNumber(value);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3, true)]
        [InlineData(0, false)]
        [InlineData(-1, false)]
        public void IsValidWalk_Size_ShouldReturnExpectedResult(int size, bool expected)
        {
            // Arrange
            var walks = new List<(int, int)>
            {
                (1, 1), (-1, -1), (1, -1), (-1, 1)
            };

            // Act
            var result = Validators.IsValidWalk(walks, size);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void IsValidWalk_NullWalks_ShouldReturnFalse()
        {
            // Arrange
            List<(int, int)> walks = null;
            int size = 3;

            // Act
            var result = Validators.IsValidWalk(walks, size);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsValidWalk_EmptyWalks_ShouldReturnFalse()
        {
            // Arrange
            var walks = new List<(int, int)>();
            int size = 3;

            // Act
            var result = Validators.IsValidWalk(walks, size);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsValidWalk_ValidWalks_ShouldReturnTrue()
        {
            // Arrange
            var walks = new List<(int, int)>
            {
                (1, 1), (-1, -1), (1, -1), (-1, 1)
            };
            int size = 3;

            // Act
            var result = Validators.IsValidWalk(walks, size);

            // Assert
            Assert.True(result);
        }
    }
}

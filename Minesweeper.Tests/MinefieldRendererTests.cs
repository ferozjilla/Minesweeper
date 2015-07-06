using NUnit.Framework;

namespace Minesweeper.Tests
{
    internal class MinefieldRendererTests
    {
        [Test]
        public void UnexploredSquaresAreShownAsHashes()
        {
            // Given
            var minefield = Minefield.Empty(3, 2);
            // When
            var result = MinefieldRenderer.RenderMinefield(minefield); 
            // Then
            var expected = " 123\nA###\nB###\n";
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ExploredSquaresAreShownAsSpaces()
        {
            // Given
            var minefield = Minefield.Empty(3, 2).Explore(new Coordinates(0, 1));
            // When
            var result = MinefieldRenderer.RenderMinefield(minefield);
            // Then
            var expected = " 123\nA# #\nB###\n";
            Assert.AreEqual(expected, result);
        }

    }
}

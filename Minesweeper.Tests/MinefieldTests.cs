using NUnit.Framework;

namespace Minesweeper.Tests
{
    internal class MinefieldTests
    {
        [Test]
        public void WhenACoordinateHasBeenExploredThenIsExploredIsTrue()
        {
            var minefield = Minefield.Empty(2, 3);
            var coordinate = new Coordinates(0, 1);
            var exploredMinefield = minefield.Explore(coordinate);
            Assert.AreEqual(true, exploredMinefield.IsExplored(coordinate.RowIndex, coordinate.ColumnIndex));
        }

        [Test]
        public void InitiallyAllMineLocationsUnexplored()
        {
            var minefield = Minefield.Empty(2, 3);
            Assert.AreEqual(false, minefield.IsExplored(0, 0));
            Assert.AreEqual(false, minefield.IsExplored(2, 1));
            Assert.AreEqual(false, minefield.IsExplored(1, 1));
        }

        [Test]
        public void ExploringARowTwiceWorks()
        {
            var minefield = Minefield.Empty(2, 3);
            Minefield exploredMinefield = minefield.Explore(new Coordinates(0, 1));
            Minefield furtherExploredMinefield = exploredMinefield.Explore(new Coordinates(0, 0));
            Assert.AreEqual(true, furtherExploredMinefield.IsExplored(0, 0));
            Assert.AreEqual(true, furtherExploredMinefield.IsExplored(0, 1));
        }

        [Test]
        public void ExploreDifferentRowsOnce()
        {
            var minefield = Minefield.Empty(2, 3);
            Minefield exploredMinefield = minefield.Explore(new Coordinates(0, 1));
            Minefield furtherExploredMinefield = exploredMinefield.Explore(new Coordinates(1, 0));
            Assert.AreEqual(true, furtherExploredMinefield.IsExplored(1, 0));
            Assert.AreEqual(true, furtherExploredMinefield.IsExplored(0, 1));
        }

        [Test]
        public void ExploreDifferentRowsMultipleTimes()
        {
            var minefield = Minefield.Empty(2, 3);
            Minefield exploredMinefield = minefield.Explore(new Coordinates(0, 1));
            Minefield furtherExploredMinefield = exploredMinefield.Explore(new Coordinates(1, 0));
            Minefield evenFurtherExploredMinefield = furtherExploredMinefield.Explore(new Coordinates(1, 1));
            Assert.AreEqual(true, evenFurtherExploredMinefield.IsExplored(1, 0));
            Assert.AreEqual(true, evenFurtherExploredMinefield.IsExplored(0, 1));
            Assert.AreEqual(true, evenFurtherExploredMinefield.IsExplored(1, 1));
        }
    }
}

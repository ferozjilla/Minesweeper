using NUnit.Framework;

namespace Minesweeper.Tests
{
    class UserInputTests
    {

        [Test]
        public void InputCoordinatesConversion()
        {
            var actual = UserInputReader.ReadCoordinates("A2");
            Assert.AreEqual(0, actual.RowIndex);
            Assert.AreEqual(1, actual.ColumnIndex);
        }
    }
}

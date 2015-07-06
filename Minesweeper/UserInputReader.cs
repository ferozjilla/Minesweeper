namespace Minesweeper
{
    public class UserInputReader
    {
        private const int asciiChar = 65;
        private const int asciiInt = 49;

        public static Coordinates ReadCoordinates(string line)
        {
            //format: <letter> <number> : single letter
            //assumption: line[0] is upper case.
            int rowIndex = line[0] - asciiChar;
            int columnIndex = int.Parse(line.Substring(1)) - 1;
            return new Coordinates(rowIndex, columnIndex);
        }
    }
}

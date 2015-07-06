using System.Collections.Generic;
using System.Linq;
namespace Minesweeper
{
    public class Minefield
    {
        public static Minefield Empty(int width, int height)
        {
            var isExplored = Enumerable.Range(0, height)
                .Select(rowIndex => EmptyRow(width))
                .ToList();
            var bombs = Enumerable.Range(0, height)
                .Select(rowIndex => RandomRow(width))
                .ToList();
            return new Minefield(width, height, isExplored);
        }

        private static IList<bool> RandomRow(int width)
        {
            //TODO: Implement random function
            //Second row cells all bombs
            return Enumerable.Range(0, width).Select(columnIndex => columnIndex == 2).ToList();
        }

        private static IList<bool> EmptyRow(int width)
        {
            return Enumerable.Range(0, width).Select(_ => false).ToList();
        }

        private readonly int _width;
        private readonly int _height;
        private readonly IList<IList<bool>> _isExplored;
        private readonly IList<IList<bool>> _bombs;
        private readonly bool detonated;

        public Minefield(int width, int height, IList<IList<bool>> isExplored)
        {
            _width = width;
            _height = height;
            _isExplored = isExplored;
        }

        public bool IsExplored(int height, int width)
        {
            return _isExplored[height][width];
        }


        internal int Width
        {
            get { return _width; }
        }

        internal int Height
        {
            get { return _height; }
        }

        public bool isBomb(int height, int width)
        {
            return _bombs[height][width];
        }


        public Minefield Explore(Coordinates coordinates)
        { 
            var grid = Enumerable.Range(0, _height)
                .Select(rowIndex => ExploreRow(rowIndex, coordinates)).ToList();
            
            return new Minefield(_width, _height, grid); 
        }

        private IList<bool> ExploreRow(int rowIndex, Coordinates coordinates)
        {
            if (rowIndex == coordinates.RowIndex)
            {
                return Enumerable.Range(0, _width)
                    .Select(columnIndex => (coordinates.ColumnIndex == columnIndex)? true: _isExplored[rowIndex][columnIndex])
                    .ToList();
            }
            else
            {
                return _isExplored[rowIndex];
            }
        }
        /*

        public int GetBombsInRange(Coordinates coordinate)
        {
            int counter = 0;
            for (int rowCounter = -1; rowCounter <= 1; rowCounter++)
            {
                for (int columnCounter = -1; columnCounter <= 1; columnCounter++)
                {
                    //check for valid index
                    if (InBounds(coordinate.RowIndex + rowCounter, 
                        coordinate.ColumnIndex + columnCounter))
                    {
                        
                    }
                }
            }
        }

        public bool InBounds(int rowIndex, int columnIndex)
        {
            return rowIndex  
        }
         */

        public Minefield ExploreNeighbors(Coordinates coordinates)
        {
            return this;
        }
    }
}

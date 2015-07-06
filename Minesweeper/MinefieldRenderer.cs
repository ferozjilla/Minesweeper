using System;
using System.Text;

namespace Minesweeper
{
    public class MinefieldRenderer
    {
        public static string RenderMinefield(Minefield minefield)
        {
            var output = new StringBuilder();


            GenerateColumnTitles(minefield.Width, output);
            for (var rowIndex = 0; rowIndex < minefield.Height; rowIndex++)
            {
                output.Append(GenerateRowTitle(rowIndex));
                for (var columnIndex = 0; columnIndex < minefield.Width; columnIndex++)
                {
                    //check if the minefield has been explored at index.
                    if (minefield.IsExplored(rowIndex, columnIndex))
                    {
                        output.Append(" ");
                    }
                    else
                    {
                        output.Append("#");
  
                    }
                }
                output.Append("\n");
            }
            return output.ToString();
        }

        private static void GenerateColumnTitles(int width, StringBuilder builder)
        {
            builder.Append(" ");
            for (var columnIndex = 0; columnIndex < width; columnIndex ++)
            {
                builder.Append(columnIndex + 1);
            }
            builder.Append("\n");
        }

        private static Char GenerateRowTitle(int row)
        {
            return (char) ('A' + row);
        }
    }
}

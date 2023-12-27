
using System.Numerics;

namespace AdventOfCode2023.Utils;
public static class MatrixUtils
{
    public static bool IsValidCoordinate(int row, int col, int rowsNumber, int colsNumber)
    {
        var isCol = 0 <= col && col < colsNumber;
        var isRow = 0 <= row && row < rowsNumber;
        var ans = isCol && isRow;

        return ans;
    }

    public static bool IsValidCoordinate(Complex coord, int rowsNumber, int colsNumber)
    {
        var row = (int) coord.Real;
        var col = (int) coord.Imaginary;

        return IsValidCoordinate(row, col, rowsNumber, colsNumber);
    }

    public static void Print<T>(IEnumerable<IEnumerable<T>> matrix, T? highlighted = default) where T : struct
    {
        if (matrix == null)
        {
            throw new ArgumentNullException(nameof(matrix));
        }

        var listOfLists = matrix.ToList();
        if (listOfLists.Count == 0 )
        {
            throw new Exception("Matrix is empty.");
        }

        Console.WriteLine();
        for (int row = 0; row < listOfLists.Count; row++)
        {
            var list = listOfLists[row].ToList();

            for (int col = 0; col < list.Count; col++)
            {
                var toPrint = list[col];

                if (highlighted != null && toPrint.Equals(highlighted))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(list[col]);

                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.WriteLine();
        }
        Console.WriteLine();

    }
}

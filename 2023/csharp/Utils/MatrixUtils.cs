
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
}

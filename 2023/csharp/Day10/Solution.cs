
using AdventOfCode2023.Utils;

namespace AdventOfCode2023.Day10;
public class Solution
{
    private readonly string[] Lines;

    private readonly (int, int)[] Directions =
    [
        (-1, 0),
        (0, -1),
        (0, 1),
        (1, 0),
    ];

    private readonly int RowsNumber;
    private readonly int ColsNumber;

    private readonly HashSet<Cell> Visited = new HashSet<Cell>();
    private List<Cell> Loop = new List<Cell>();


    public Solution()
    {
        Lines = File.ReadAllLines("./Day10/input.txt");
        RowsNumber = Lines.Length;
        ColsNumber = Lines[0].Length;
    }

    /*
     * 1. Find loop
     *      - Find S
     *      - For each adjacent cell to S check if it's connected to 2 adjacent cells
     *      - If yes then check the adjacent cells
     *      - If no then proceed to the next cell
     * 2. Divide loop size by 2
     * 
     * Example input:
     *  .....
        .S-7.
        .|.|.
        .L-J.
        .....
     * 
     * 
     * 
     */

    public int PartOne()
    {
        var rowsNumber = Lines.Length;
        var colsNumber = Lines[0].Length;

        Matrix matrix = CreateMatrix(Lines);

        var stack = new Stack<Cell>();

        Cell currentCell = matrix.SCell;
        Loop.Add(currentCell);

        // Fill up stack with cells adjacent to S cell
        AddAdjacentToStack(matrix, matrix.SCell, stack);

        while (stack.Count != 0)
        {
            var nextCell = stack.Pop();
            var isConnected = IsConnected(currentCell, nextCell);
            if (isConnected)
            {
                Loop.Add(currentCell);
                currentCell = nextCell;
            }

            AddAdjacentToStack(matrix, currentCell, stack);
        }

        Loop = Loop.Distinct().ToList();
        Print(matrix, Loop);

        //Console.WriteLine(string.Join("\n", Loop));

        return 0;
    }

    private bool IsConnected(Cell cell1, Cell cell2)
    {
        if (cell1.Value == 'S' || cell2.Value == 'S')
        {
            return true;
        }

        // [cell 1] [cell 2]
        var leftRight = IsCell1OnLeftCell2OnRight(cell1, cell2);

        // [cell 2] [cell 1]
        var rightLeft = IsCell1OnLeftCell2OnRight(cell2, cell1);

        // [cell 1]
        // [cell 2]
        var topBottom = IsCell1OnTopAndCell2OnBottom(cell1, cell2);

        // [cell 2]
        // [cell 1]
        var bottomTop = IsCell1OnTopAndCell2OnBottom(cell2, cell1);

        return leftRight || rightLeft || topBottom || bottomTop;
    }

    private bool IsCell1OnLeftCell2OnRight(Cell cell1, Cell cell2)
    {
        if (cell1.Row == cell2.Row && cell1.Column + 1 == cell2.Column)
        {
            if (cell1.Value == '-' || cell1.Value == 'L' || cell1.Value == 'F')
            {
                if (cell2.Value == '-' || cell2.Value == '7' || cell2.Value == 'J')
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool IsCell1OnTopAndCell2OnBottom(Cell cell1, Cell cell2)
    {
        if (cell1.Row == cell2.Row - 1 && cell1.Column == cell2.Column)
        {
            if (cell1.Value == '|' || cell1.Value == '7' || cell1.Value == 'F')
            {
                if (cell2.Value == '|' || cell2.Value == 'L' || cell2.Value == 'J')
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void AddAdjacentToStack(Matrix matrix, Cell cell, Stack<Cell> stack)
    {
        if (Visited.Contains(cell))
        {
            return;
        }

        foreach (var (dRow, dCol) in Directions)
        {
            var newRow = cell.Row + dRow;
            var newCol = cell.Column + dCol;

            if (!MatrixUtils.IsValidCoordinate(newRow, newCol, RowsNumber, ColsNumber))
            {
                continue;
            }
            if (matrix.Cells[newRow, newCol].Value == '.')
            {
                continue;
            }

            stack.Push(matrix.Cells[newRow, newCol]);
        }
        Visited.Add(cell);
    }

    private Matrix CreateMatrix(string[] lines)
    {
        var n = Lines.Length;
        var m = Lines[0].Length;

        var matrix = new Cell[n, m];
        Cell? sCell = null;
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                matrix[row, col] = new Cell(row, col, lines[row][col]);
                if (lines[row][col] == 'S')
                {
                    sCell = matrix[row, col];
                }
            }
        }

        if (sCell == null)
        {
            throw new Exception("S cell was not found.");
        }

        return new Matrix(matrix, sCell);
    }

    public int PartTwo()
    {
        return 0;
    }


    private void Print(Matrix matrix, List<Cell> visited)
    {
        for (int r = 0; r < RowsNumber; r++)
        {
            for (int c = 0; c < ColsNumber; c++)
            {
                var cell = matrix.Cells[r, c];

                if (visited.Contains(cell))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(cell.Value);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.WriteLine();
        }
    }

    public record Cell(int Row, int Column, char Value);
    public record Matrix(Cell[,] Cells, Cell SCell);
}

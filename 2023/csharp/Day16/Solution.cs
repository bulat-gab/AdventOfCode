using AdventOfCode2023.Utils;
using static AdventOfCode2023.Day16.Solution;
using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCode2023.Day16;
public class Solution
{
    private readonly string[] Lines;

    public class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public char Value { get; set; }
        public bool Energized { get; set; } = false;

        public List<Direction> beamDirections { get; } = [];

        public Cell(int row, int column, char value)
        {
            Row = row;
            Column = column;
            Value = value;
        }
    }

    public record Vector(Cell Cell, Direction Beam);

    public record Direction(int R, int C);

    private readonly Direction Right = new(0, 1);
    private readonly Direction Left = new(0, -1);
    private readonly Direction Downwards = new(1, 0);
    private readonly Direction Upwards = new(-1, 0);

    private readonly (int, int)[] Directions =
[
    (0, 1),  // Right
    (0, -1), // Left
    (1, 0),  // Downwards
    (-1, 0), // Upwards
];

    private readonly int RowsNumber;
    private readonly int ColsNumber;

    private readonly HashSet<Cell> Visited = new HashSet<Cell>();
    private List<Cell> Loop = new List<Cell>();

    private Cell[,] Matrix;

    public Solution()
    {
        Lines = File.ReadAllLines("./Day10/input.txt");
        RowsNumber = Lines.Length;
        ColsNumber = Lines[0].Length;
    }

    public int PartOne()
    {
        Matrix = CreateMatrix();
 
        return 0;
    }

    /// <summary>
    ///  Returns List of next cells the beam will go.
    ///  List contains 2 elements if the current cell is a splitter and a single element otherwise.
    /// </summary>
    /// <param name="current"></param>
    /// <param name="beam"></param>
    /// <returns></returns>
    private List<Vector> MakeMove(Cell current, Direction direction)
    {
        // This has been visited already
        if (current.beamDirections.Contains(direction))
        {
            return [];
        }

        var v = current.Value;
        Vector? nextVector;
        Direction newDirection = direction;
        if (direction == Right)
        {
            if (v == '|')
            {
                var nexts = new List<Vector>();

                var nextVector1 = GetNextVector(current, Downwards);
                var nextVector2 = GetNextVector(current, Upwards);

                if (nextVector1 != null)
                {
                    nexts.Add(nextVector1);
                }
                if (nextVector2 != null)
                {
                    nexts.Add(nextVector2);
                }

                return nexts;
            }

            if (v == '.' || v == '-')
            {
                newDirection = direction;
            }

            if (v == '/')
            {
                newDirection = Upwards;
            }

            if (v == '\\')
            {
                newDirection = Downwards;
            }

            nextVector = GetNextVector(current, newDirection);
            return nextVector != null ? [nextVector] : [];

            
        }

        if (direction == Left)
        {
            if (v == '|')
            {
                var nexts = new List<Vector>();

                var nextVector1 = GetNextVector(current, Downwards);
                var nextVector2 = GetNextVector(current, Upwards);

                if (nextVector1 != null)
                {
                    nexts.Add(nextVector1);
                }
                if (nextVector2 != null)
                {
                    nexts.Add(nextVector2);
                }

                return nexts;
            }
        }
    }

    private Vector? GetNextVector(Cell current, Direction newDirection)
    {
        var nextRow = current.Row + newDirection.R;
        var nextCol = current.Column + newDirection.C;

        var isValid = MatrixUtils.IsValidCoordinate(nextRow, nextCol, RowsNumber, ColsNumber);

        if (isValid)
        {
            var next = Matrix[nextRow, nextCol];
            return new Vector(next, newDirection);
        }
        else
        {
            return null;
        }
    }

    private Cell[,] CreateMatrix()
    {
        Cell[,] matrix = new Cell[RowsNumber, ColsNumber];

        for (int r = 0; r < RowsNumber; r++)
        {
            for (int c = 0; c < ColsNumber; c++)
            {
                matrix[r, c] = new Cell(r, c, Lines[r][c]);
            }
        }

        return matrix;
    }

    
    public int PartTwo()
    {
        return 0;
    }


    //private void Print(Matrix matrix, List<Cell> visited)
    //{
    //    for (int r = 0; r < RowsNumber; r++)
    //    {
    //        for (int c = 0; c < ColsNumber; c++)
    //        {
    //            var cell = matrix.Cells[r, c];

    //            if (visited.Contains(cell))
    //            {
    //                Console.ForegroundColor = ConsoleColor.Red;
    //            }
    //            Console.Write(cell.Value);
    //            Console.ForegroundColor = ConsoleColor.Gray;
    //        }
    //        Console.WriteLine();
    //    }
    //}



    public enum BeamDirection
    {
        Right = 0,
        Left = 1,
        Downwards = 2,
        Upwards= 3,
    }

}

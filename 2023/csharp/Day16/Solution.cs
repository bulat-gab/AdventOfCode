using AdventOfCode2023.Utils;
using System.Numerics;

namespace AdventOfCode2023.Day16;
public class Solution
{
    private readonly string[] Lines;

    public class Cell(int row, int column, char value)
    {
        public int Row { get; set; } = row;
        public int Column { get; set; } = column;
        public char Value { get; set; } = value;
        public bool Energized { get; set; } = false;

        public HashSet<Complex> BeamDirections { get; } = [];

        public void Energize(Complex dir)
        {
            Energized = true;
            BeamDirections.Add(dir);
        }

        public void Reset()
        {
            Energized = false;
            BeamDirections.Clear();
        }
    }

    public record Vector(Cell Cell, Complex Direction);

    private readonly Complex Right = Complex.ImaginaryOne; // new(0, 1);
    private readonly Complex Left = -Complex.ImaginaryOne; // new(0, -1);
    private readonly Complex Down = Complex.One; // = new(1, 0);
    private readonly Complex Up = -Complex.One; //new(-1, 0);

    private readonly int RowsNumber;
    private readonly int ColsNumber;

    private readonly Cell[,] Matrix;

    public Solution()
    {
        Lines = File.ReadAllLines("./Day16/input.txt");
        RowsNumber = Lines.Length;
        ColsNumber = Lines[0].Length;

        Matrix = CreateMatrix();
    }

    public int PartOne()
    {
        var startVector = new Vector(Matrix[0, 0], Right);
        return CountEnergizedFrom(startVector);
    }

    public int PartTwo()
    {
        return GetStartVectors()
             .Select(CountEnergizedFrom)
             .Max();
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

    private List<Complex> GetDirections(Cell current, Complex dir) => current.Value switch
    {
        '-' when dir == Up || dir == Down => [Left, Right],
        '|' when dir == Right || dir == Left => [Up, Down],
        '\\' => [new Complex(dir.Imaginary, dir.Real)],
        '/' => [-new Complex(dir.Imaginary, dir.Real)],
        _ => [dir]
    };

    private Vector? GetNextVector(Cell current, Complex newDirection)
    {
        var nextRow = current.Row + (int)newDirection.Real;
        var nextCol = current.Column + (int)newDirection.Imaginary;

        var isValid = MatrixUtils.IsValidCoordinate(nextRow, nextCol, RowsNumber, ColsNumber);

        if (isValid)
        {
            return new Vector(Matrix[nextRow, nextCol], newDirection);
        }
        else
        {
            return null;
        }
    }

    private int CountEnergized(Cell[,] matrix)
    {
        int count = 0;
        for (int r = 0; r < RowsNumber; r++)
        {
            for (int c = 0; c < ColsNumber; c++)
            {
                if (matrix[r, c].Energized)
                {
                    count++;
                }
            }
        }
        return count;
    }

    private void Print(Cell[,] matrix)
    {
        for (int r = 0; r < RowsNumber; r++)
        {
            for (int c = 0; c < ColsNumber; c++)
            {
                if (matrix[r, c].Energized)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('#');
                }
                else
                {
                    Console.Write(matrix[r, c].Value);
                }
                
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.WriteLine();
        }
    }

    private int CountEnergizedFrom(Vector startVector)
    {
        var stack = new Stack<Vector>([startVector]);

        while (stack.Count > 0)
        {
            var current = stack.Pop();

            var cell = current.Cell;
            var dir = current.Direction;

            if (cell.BeamDirections.Contains(dir))
            {
                continue;
            }
            cell.Energize(dir);

            foreach (var newDir in GetDirections(cell, dir))
            {
                var nextVector = GetNextVector(cell, newDir);
                if (nextVector != null)
                {
                    stack.Push(nextVector);
                }
            }
        }

        int count = CountEnergized(Matrix);
        Reset(Matrix);
        return count;
    }

    private IEnumerable<Vector> GetStartVectors()
    {
        return [
            .. Enumerable.Range(0, RowsNumber).Select(row => new Vector(Matrix[row, 0], Right)),
            .. Enumerable.Range(0, RowsNumber).Select(row => new Vector(Matrix[row, ColsNumber - 1], Left)),
            .. Enumerable.Range(0, ColsNumber).Select(col => new Vector(Matrix[RowsNumber - 1, col], Up)),
            .. Enumerable.Range(0, ColsNumber).Select(col => new Vector(Matrix[0, col], Down)),
        ];
    }

    private void Reset(Cell[,] matrix)
    {
        for (int r = 0; r < RowsNumber; r++)
        {
            for (int c = 0; c < ColsNumber; c++)
            {
                matrix[r, c].Reset();
            }
        }
    }
}

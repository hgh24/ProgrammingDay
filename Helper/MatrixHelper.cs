using System;
using System.Linq;

public class MatrixHelper
{
    /// <summary>
    /// Converts a string like:
    /// "4 [1, 2, 1, 1, 3, 2, 3, 3, 1, 5, 1, 2, 1, 2, 3, 4]"
    /// into a square matrix of size 4x4.
    /// </summary>
    public static int[,] StringToSquareMatrix(string input)
    {
        // Split input into dimension and numbers
        var parts = input.Split('[', ']');
        int dimension = int.Parse(parts[0].Trim());

        var numbers = parts[1]
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x.Trim()))
            .ToArray();

        if (numbers.Length != dimension * dimension)
            throw new ArgumentException("Number of elements does not match matrix size.");

        int[,] matrix = new int[dimension, dimension];
        int index = 0;

        for (int i = 0; i < dimension; i++)
        {
            for (int j = 0; j < dimension; j++)
            {
                matrix[i, j] = numbers[index++];
            }
        }

        return matrix;
    }
}
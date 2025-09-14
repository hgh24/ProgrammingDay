using System;
using System.Collections.Generic;

public class MatrixParser
{
    public static int[,] ConvertStringToMatrix(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException("Input string is null or empty.");

        // Remove the outer brackets
        input = input.Trim();
        if (input.StartsWith("[[") && input.EndsWith("]]"))
        {
            input = input.Substring(1, input.Length - 2); // Remove first and last bracket
        }
        else
        {
            throw new FormatException("Invalid matrix format.");
        }

        // Split into rows using a custom method
        List<string> rows = new List<string>();
        int start = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '[')
            {
                start = i + 1;
            }
            else if (input[i] == ']')
            {
                rows.Add(input.Substring(start, i - start));
            }
        }

        // Parse each row
        int rowCount = rows.Count;
        int[][] temp = new int[rowCount][];
        int colCount = -1;

        for (int i = 0; i < rowCount; i++)
        {
            var elements = rows[i].Split(',');
            temp[i] = Array.ConvertAll(elements, int.Parse);

            if (colCount == -1)
                colCount = temp[i].Length;
            else if (colCount != temp[i].Length)
                throw new FormatException("Inconsistent row lengths in matrix.");
        }

        // Convert to 2D array
        int[,] result = new int[rowCount, colCount];
        for (int i = 0; i < rowCount; i++)
            for (int j = 0; j < colCount; j++)
                result[i, j] = temp[i][j];

        return result;
    }
}

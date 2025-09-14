namespace Question1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string input = "4 [1, 2, 1, 1, 3, 2, 3, 3, 1, 5, 1, 2, 1, 2, 3, 4]";

            var matrix = MatrixHelper.StringToSquareMatrix(input);

            Console.WriteLine(matrix[0, 2]);




        }
    }
}

namespace Question1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string input = "[[1,2,3][4,5,6][7,8,9]]";

            var matrix = MatrixParser.ConvertStringToMatrix(input);

            Console.WriteLine(matrix[0, 2]);




        }
    }
}

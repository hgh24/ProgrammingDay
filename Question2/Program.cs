namespace Question2;

internal class Program
{
    static List<(int, int)> GetLine(int x0, int y0, int x1, int y1)
    {
        List<(int, int)> points = new List<(int, int)>();

        int dx = Math.Abs(x1 - x0);
        int dy = Math.Abs(y1 - y0);

        int sx = x0 < x1 ? 1 : -1;
        int sy = y0 < y1 ? 1 : -1;

        int err = dx - dy;

        while (true)
        {
            points.Add((x0, y0));
            if (x0 == x1 && y0 == y1) break;

            int e2 = 2 * err;
            if (e2 > -dy)
            {
                err -= dy;
                x0 += sx;
            }
            if (e2 < dx)
            {
                err += dx;
                y0 += sy;
            }
        }

        return points;
    }
    
    static void Main(string[] args)
    {
        var points = new List<(int, int)>
        {
            // (13, 14), (6, 13), (18, 7), (4, 11), (3, 14)
            // (0,0), (4,2), (6,6), (0,5), (9,9)
            (17, 4), (32, 19), (6, 39), (0, 33), (20, 34), (38, 8), (21, 18), (32, 35) ,(4, 16), (20, 11)
        };

        HashSet<(int, int)> visited = new HashSet<(int, int)>();

        for (int i = 0; i < points.Count - 1; i++)
        {
            var line = GetLine(points[i].Item1, points[i].Item2,
                points[i + 1].Item1, points[i + 1].Item2);

            foreach (var p in line)
                visited.Add(p);
        }

        Console.WriteLine(visited.Count);
    }
}
using System.Text.Json;

public static class Runner
{
    public static void Main()
    {
        int[][] grid =
        [
            [1, -2, 3],
            [2, 3, 5],
        ];
        int k = 2;

        var solution = new Solution();
        int[][] ans = solution.MinAbsDiff(grid, k);

        Console.WriteLine(JsonSerializer.Serialize(ans));
    }
}

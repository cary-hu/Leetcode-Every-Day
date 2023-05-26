/// <summary>
/// 20230526
/// https://leetcode.cn/problems/shortest-path-in-binary-matrix/
/// </summary>
public class Solution
{
    private int[][] Dirs = { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 1, 1 }, new int[] { -1, 1 }, new int[] { 1, -1 }, new int[] { -1, -1 } };
    public int ShortestPathBinaryMatrix(int[][] grid)
    {
        int n = grid.Length;
        if (grid[0][0] == 1 || grid[n - 1][n - 1] == 1)
        {
            return -1;
        }
        if (n == 1)
        {
            return 1;
        }
        var q = new Queue<int[]>();
        q.Enqueue(new int[] { 0, 0, 1 });
        while (q.Any())
        {
            var a = q.Dequeue();
            foreach (var m in Dirs)
            {
                int x = a[0] + m[0], y = a[1] + m[1];
                if (x >= 0 && x < n && y >= 0 && y < n && grid[x][y] == 0)
                {
                    grid[x][y] = 1;
                    if (x == n - 1 && y == n - 1)
                    {
                        return a[2] + 1;
                    }
                    q.Enqueue(new int[] { x, y, a[2] + 1 });
                }
            }
        }
        return -1;
    }
}
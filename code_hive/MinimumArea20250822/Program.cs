/// <summary>
/// 20250822
/// https://leetcode.cn/problems/find-the-minimum-area-to-cover-all-ones-i/
/// </summary>
public class Solution
{
    public int MinimumArea(int[][] grid)
    {
                int minX = int.MaxValue, minY = int.MaxValue;
        int maxX = int.MinValue, maxY = int.MinValue;

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    minX = Math.Min(minX, i);
                    minY = Math.Min(minY, j);
                    maxX = Math.Max(maxX, i);
                    maxY = Math.Max(maxY, j);
                }
            }
        }

        if (minX == int.MaxValue)
        {
            return 0;
        }

        return (maxX - minX + 1) * (maxY - minY + 1);
    }
}
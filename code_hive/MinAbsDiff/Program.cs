/// <summary>
/// 20260320
/// https://leetcode.cn/problems/minimum-absolute-difference-in-sliding-submatrix/description/?envType=daily-question&envId=2026-03-20
/// </summary>
public class Solution
{
    public int[][] MinAbsDiff(int[][] grid, int k)
    {
        int m = grid.Length, n = grid[0].Length;
        int[][] ans = new int[m - k + 1][];
        for (int i = 0; i < m - k + 1; i++)
        {
            ans[i] = new int[n - k + 1];
            for (int j = 0; j < n - k + 1; j++)
            {
                List<int> list = new List<int>();
                for (int x = i; x < i + k; x++)
                {
                    for (int y = j; y < j + k; y++)
                    {
                        list.Add(grid[x][y]);
                    }
                }
                list.Sort();

                int best = int.MaxValue;
                int prevDistinct = list[0];
                for (int t = 1; t < list.Count; t++)
                {
                    int cur = list[t];
                    if (cur == prevDistinct)
                    {
                        continue;
                    }

                    best = Math.Min(best, cur - prevDistinct);
                    prevDistinct = cur;
                }

                ans[i][j] = best == int.MaxValue ? 0 : best;
            }
        }
        return ans;
    }
}
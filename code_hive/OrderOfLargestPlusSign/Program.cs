/// <summary>
/// 20221109
/// https://leetcode.cn/problems/largest-plus-sign/
/// </summary>
public class Solution
{
    public int OrderOfLargestPlusSign(int n, int[][] mines)
    {
        var grid = new List<IList<int>>();
        for (int i = 0; i < n; i++)
        {
            var gridRow = new List<int>();
            for (int j = 0; j < n; j++)
            {
                gridRow.Add(int.MaxValue);
            }
            grid.Add(gridRow);
        }
        for (int i = 0; i < mines.Length; i++)
        {
            grid[mines[i][0]][mines[i][1]] = 0;
        }
        for (int i = 0; i < n; i++)
        {
            int up = 0, down = 0, left = 0, right = 0;
            for (int j = 0, k = n - 1; j < n; j++, k--)
            {
                left = grid[i][j] == 0 ? 0 : left + 1;
                right = grid[i][k] == 0 ? 0 : right + 1;
                up = grid[j][i] == 0 ? 0 : up + 1;
                down = grid[k][i] == 0 ? 0 : down + 1;

                grid[i][j] = Math.Min(grid[i][j], left);
                grid[i][k] = Math.Min(grid[i][k], right);
                grid[j][i] = Math.Min(grid[j][i], up);
                grid[k][i] = Math.Min(grid[k][i], down);
            }
        }

        int res = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                res = Math.Max(res, grid[i][j]);
            }
        }
        return res;
    }
}
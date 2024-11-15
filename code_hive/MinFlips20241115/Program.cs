/// <summary>
/// 20241115
/// https://leetcode.cn/problems/minimum-number-of-flips-to-make-binary-grid-palindromic-i/
/// </summary>
public class Solution
{
    public int MinFlips(int[][] grid)
    {
        var n = grid.Length;
        var m = grid[0].Length;

        var minRow = 0;
        for (var i = 0; i < n; i++)
        {
            int left = 0, right = m - 1;
            while (left < right)
            {
                if (grid[i][left] != grid[i][right])
                {
                    minRow++;
                }
                left++;
                right--;
            }
        }

        var minCol = 0;
        for (int i = 0; i < m; i++)
        {
            int up = 0, down = n - 1;
            while (up < down)
            {
                if (grid[up][i] != grid[down][i])
                {
                    minCol++;
                }
                up++;
                down--;
            }
        }

        return Math.Min(minRow, minCol);
    }
}
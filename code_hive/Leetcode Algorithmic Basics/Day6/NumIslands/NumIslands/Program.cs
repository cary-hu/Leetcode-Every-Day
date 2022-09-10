/// <summary>
/// 20220910
/// https://leetcode.cn/problems/number-of-islands/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public int NumIslands(char[][] grid)
    {
        var res = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == '1')
                {
                    res++;
                    SearchIsLand(grid, i, j);
                }
            }
        }
        return res;
    }
    private void SearchIsLand(char[][] grid, int x, int y)
    {
        if (x >= 0 && x < grid.Length && y >= 0 && y < grid[0].Length)
        {
            if (grid[x][y] == '1')
            {
                grid[x][y] = '0';
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
        var dis = new int[][] { new int[2] { 0, 1 }, new int[2] { 1, 0 }, new int[2] { 0, -1 }, new int[2] { -1, 0 } };
        foreach (var di in dis)
        {
            SearchIsLand(grid, x + di[0], y + di[1]);
        }
    }
}
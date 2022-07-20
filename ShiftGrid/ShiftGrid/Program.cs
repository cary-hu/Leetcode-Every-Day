/// <summary>
/// 20220720
/// https://leetcode.cn/problems/shift-2d-grid/
/// </summary>
public class Solution
{
    public IList<IList<int>> ShiftGrid(int[][] grid, int k)
    {
        var list = new List<int>();
        var row = grid.Length;
        var col = grid[0].Length;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                list.Add(grid[i][j]);
            }
        }
        var res = new List<IList<int>>();
        var rowRes = new List<int>();
        var index = list.Count - k % (row * col);
        for (int i = index; i < list.Count; i++)
        {
            rowRes.Add(list[i]);
            if (rowRes.Count == col)
            {
                res.Add(rowRes);
                rowRes = new List<int>();
            }
        }
        for (int i = 0; i < index; i++)
        {
            rowRes.Add(list[i]);
            if (rowRes.Count == col)
            {
                res.Add(rowRes);
                rowRes = new List<int>();
            }
        }
        return res;
    }
}
/// <summary>
/// 20220614
/// https://leetcode.cn/problems/diagonal-traverse/
/// </summary>
public class Solution
{
    public int[] FindDiagonalOrder(int[][] mat)
    {
        if (mat == null || mat.Length == 0)
        {
            return new int[0];
        }
        var res = new List<int>();
        var m = mat.Length;
        var n = mat[0].Length;
        for (int i = 0; i < m + n - 1; i++)
        {
            if (i % 2 == 1)
            {
                int x = i < n ? 0 : i - n + 1;
                int y = i < n ? i : n - 1;
                while (x < m && y >= 0)
                {
                    res.Add(mat[x][y]);
                    x++;
                    y--;
                }
            }
            else
            {
                int x = i < m ? i : m - 1;
                int y = i < m ? 0 : i - m + 1;
                while (x >= 0 && y < n)
                {
                    res.Add(mat[x][y]);
                    x--;
                    y++;
                }
            }
        }
        return res.ToArray();

    }
}
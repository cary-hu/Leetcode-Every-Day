/// <summary>
/// 20220717
/// https://leetcode.cn/problems/spiral-matrix/
/// </summary>
public class Solution
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        var res = new List<int>();
        if (matrix == null || matrix.Length == 0)
        {
            
            return res;
        }
        var n = matrix.Count();
        var m = matrix[0].Count();
        var i = 0;
        var j = 0;
        while (i < n && j < m)
        {
            for (int k = j; k < m; k++)
            {
                res.Add(matrix[i][k]);
            }
            i++;
            for (int k = i; k < n; k++)
            {
                res.Add(matrix[k][m - 1]);
            }
            m--;
            if (i < n)
            {
                for (int k = m - 1; k >= j; k--)
                {
                    res.Add(matrix[n - 1][k]);
                }
                n--;
            }
            if (j < m)
            {
                for (int k = n - 1; k >= i; k--)
                {
                    res.Add(matrix[k][j]);
                }
                j++;
            }
        }
        return res;
    }
}
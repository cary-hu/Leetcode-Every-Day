/// <summary>
/// 20220930
/// https://leetcode.cn/problems/zero-matrix-lcci/
/// </summary>
public class Solution
{
    public void SetZeroes(int[][] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length;
        bool flagCol0 = false;
        for (int i = 0; i < m; i++)
        {
            if (matrix[i][0] == 0)
            {
                flagCol0 = true;
            }
            for (int j = 1; j < n; j++)
            {
                if (matrix[i][j] == 0)
                {
                    matrix[i][0] = matrix[0][j] = 0;
                }
            }
        }
        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = 1; j < n; j++)
            {
                if (matrix[i][0] == 0 || matrix[0][j] == 0)
                {
                    matrix[i][j] = 0;
                }
            }
            if (flagCol0)
            {
                matrix[i][0] = 0;
            }
        }
    }
}
/// <summary>
/// 20240705
/// https://leetcode.cn/problems/modify-the-matrix/
/// </summary>
public class Solution
{
    public int[][] ModifiedMatrix(int[][] matrix)
    {
        int n = matrix.Length;
        int m = matrix[0].Length;
        for (int j = 0; j < m; j++)
        {
            int max = -1;
            for (int i = 0; i < n; i++)
            {
                max = Math.Max(max, matrix[i][j]);
            }
            for (int i = 0; i < n; i++)
            {
                if (matrix[i][j] == -1)
                {
                    matrix[i][j] = max;
                }
            }
        }
        return matrix;
    }
}
/// <summary>
/// 20230811
/// https://leetcode.cn/problems/matrix-diagonal-sum/
/// </summary>
public class Solution
{
    public int DiagonalSum(int[][] mat)
    {
        int n = mat.Length, sum = 0;
        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                if (i == j || i + j == n - 1)
                {
                    sum += mat[i][j];
                }
            }
        }
        return sum;
    }
}
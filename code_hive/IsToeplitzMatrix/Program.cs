/// <summary>
/// 20230616
/// https://leetcode.cn/problems/toeplitz-matrix/
/// </summary>
public class Solution
{
    public bool IsToeplitzMatrix(int[][] matrix)
    {
        for (int i = matrix.Length - 1; i > 0; i--)
        {
            for (int j = 1; j < matrix[0].Length; j++)
            {
                if (matrix[i][j] != matrix[i - 1][j - 1])
                {
                    return false;
                }
            }
        }
        return true;
    }
}
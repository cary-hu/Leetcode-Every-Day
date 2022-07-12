/// <summary>
/// 20220712
/// https://leetcode.cn/problems/cells-with-odd-values-in-a-matrix/
/// </summary>
public class Solution
{
    public int OddCells(int m, int n, int[][] indices)
    {
        int[,] matrix = new int[m, n];
        int res = 0;
        foreach (var index in indices)
        {
            int i = index[0];
            int j = index[1];
            for (int k = 0; k < m; k++)
            {
                matrix[k, j]++;
            }
            for (int k = 0; k < n; k++)
            {
                matrix[i, k]++;
            }
        }
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i,j] % 2 != 0)
                {
                    res++;
                }
            }
        }
        return res;
    }
}
/// <summary>
/// 20260327
/// https://leetcode.cn/problems/matrix-similarity-after-cyclic-shifts/
/// </summary>
public class Solution
{
    public bool AreSimilar(int[][] mat, int k)
    {
        var m = mat.Length;
        var n = mat[0].Length;
        for (int i = 0; i < m; i++)
        {
            if ((i & 1) == 1)
            {
                for (int j = 0; j < n; j++)
                {
                    if (mat[i][(j + k) % n] != mat[i][j]) return false;
                }
            }
            else
            {
                for (int j = 0; j < n; j++)
                {
                    if (mat[i][((j - k) % n + n) % n] != mat[i][j]) return false;
                }
            }
        }
        return true;
    }
}
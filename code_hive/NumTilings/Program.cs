/// <summary>
/// 20221112
/// https://leetcode.cn/problems/domino-and-tromino-tiling/
/// </summary>
public class Solution
{
    int mod = (int)1e9 + 7;
    private long[][] matrix = new long[][] { new long[] { 0, 1, 1, 1 }, new long[] { 0, 0, 1, 1 }, new long[] { 0, 1, 0, 1 }, new long[] { 1, 0, 0, 1 } };
    public int NumTilings(int n)
    {
        var ans= new long[n][];
        for (int i = 0; i < n; i++)
        {
            ans[i] = new long[4];
        }
        ans[0] = new long[] { 1, 0, 0, 1 };
        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                for (int k = 0; k < 4; k++) { ans[i][j] += ans[i - 1][k] * matrix[k][j]; }
                ans[i][j] %= mod;
            }
        }
        return (int)ans[n - 1][3];
    }
}
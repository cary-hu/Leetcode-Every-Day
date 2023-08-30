/// <summary>
/// 20230818
/// https://leetcode.cn/problems/pizza-with-3n-slices/
/// </summary>
public class Solution
{
    public int MaxSizeSlices(int[] slices)
    {
        int[] v1 = new int[slices.Length - 1];
        int[] v2 = new int[slices.Length - 1];
        Array.Copy(slices, 1, v1, 0, slices.Length - 1);
        Array.Copy(slices, 0, v2, 0, slices.Length - 1);
        int ans1 = Calculate(v1);
        int ans2 = Calculate(v2);
        return Math.Max(ans1, ans2);


    }
    public int Calculate(int[] slices)
    {
        int N = slices.Length, n = (N + 1) / 3;
        int[][] dp = new int[N][];
        for (int i = 0; i < N; i++)
        {
            dp[i] = new int[n + 1];
            Array.Fill(dp[i], int.MinValue);
        }
        dp[0][0] = 0;
        dp[0][1] = slices[0];
        dp[1][0] = 0;
        dp[1][1] = Math.Max(slices[0], slices[1]);
        for (int i = 2; i < N; i++)
        {
            dp[i][0] = 0;
            for (int j = 1; j <= n; j++)
            {
                dp[i][j] = Math.Max(dp[i - 1][j], dp[i - 2][j - 1] + slices[i]);
            }
        }
        return dp[N - 1][n];
    }
}
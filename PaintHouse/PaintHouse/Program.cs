/// <summary>
/// 20220625
/// https://leetcode.cn/problems/JEj789/
/// https://leetcode.cn/problems/paint-house/
/// </summary>
public class Solution
{
    public int MinCost(int[][] costs)
    {
        if (costs == null || costs.Length == 0)
        {
            return 0;
        }
        int n = costs.Length;
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[3];
        }
        dp[0][0] = costs[0][0];
        dp[0][1] = costs[0][1];
        dp[0][2] = costs[0][2];
        for (int i = 1; i < n; i++)
        {
            dp[i][0] = Math.Min(dp[i - 1][1], dp[i - 1][2]) + costs[i][0];
            dp[i][1] = Math.Min(dp[i - 1][0], dp[i - 1][2]) + costs[i][1];
            dp[i][2] = Math.Min(dp[i - 1][0], dp[i - 1][1]) + costs[i][2];
        }
        return Math.Min(dp[n - 1][0], Math.Min(dp[n - 1][1], dp[n - 1][2]));

    }
}
/// <summary>
/// 20230904
/// https://leetcode.cn/problems/minimum-cost-for-tickets/
/// </summary>
public class Solution
{
    public int MincostTickets(int[] days, int[] costs)
    {
        var dp = new int[366];
        Array.Fill(dp, 0);
        for (var i = 1; i <= 365; i++)
        {
            if (!days.Contains(i))
            {
                dp[i] = dp[i - 1];
            }
            else
            {
                dp[i] = Math.Min(Math.Min(dp[i - 1] + costs[0], dp[Math.Max(0, i - 7)] + costs[1]), dp[Math.Max(0, i - 30)] + costs[2]);
            }
        }

        return dp[365];
    }
}
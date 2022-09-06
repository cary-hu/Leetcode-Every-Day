/// <summary>
/// 20220906
/// https://leetcode.cn/problems/best-time-to-buy-and-sell-stock-ii/
/// </summary>
public class Solution
{
    public int MaxProfit(int[] prices)
    {
        var dp = new int[prices.Length][];
        dp[0] = new int[2] { 0, -prices[0] };
        for (int i = 1; i < prices.Length; i++)
        {
            dp[i] = new int[2] {
            Math.Max(dp[i - 1][0], dp[i - 1][1] + prices[i]),
                Math.Max(dp[i-1][1], dp[i-1][0]-prices[i])
            };
        }
        return dp[prices.Length - 1][0];
    }
}
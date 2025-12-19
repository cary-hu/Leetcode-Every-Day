/// <summary>
/// 20251219
/// https://leetcode.cn/problems/best-time-to-buy-and-sell-stock-using-strategy/
/// </summary>
public class Solution
{
    public long MaxProfit(int[] prices, int[] strategy, int k)
    {
        int n = prices.Length;
        long baseProfit = 0;
        for (int i = 0; i < n; i++)
        {
            baseProfit += (long)strategy[i] * prices[i];
        }
        long maxGain = 0;
        int halfK = k / 2;

        for (int start = 0; start <= n - k; start++)
        {
            long originalContribution = 0;
            for (int j = start; j < start + k; j++)
            {
                originalContribution += (long)strategy[j] * prices[j];
            }
            long newContribution = 0;
            for (int j = start + halfK; j < start + k; j++)
            {
                newContribution += prices[j];
            }

            long gain = newContribution - originalContribution;
            maxGain = Math.Max(maxGain, gain);
        }

        return baseProfit + maxGain;
    }
}
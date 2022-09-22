/// <summary>
/// 20220922
/// https://leetcode.cn/problems/coin-change/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public int CoinChange(int[] coins, int amount)
    {
        var dp = new int[amount + 1];
        Array.Fill(dp, int.MaxValue);
        dp[0] = 0;
        for (int i = 1; i < amount; i++)
        {
            for (int j = 0; j < coins.Length; j++)
            {
                if(i - coins[j] >=0 && dp[i - coins[j]]!=int.MaxValue)
                {
                    dp[i] = Math.Min(dp[i - coins[j]] + 1, dp[i]);
                }
            }
        }
        if (dp[amount] == int.MaxValue) return -1;
        return dp[amount];
    }
}
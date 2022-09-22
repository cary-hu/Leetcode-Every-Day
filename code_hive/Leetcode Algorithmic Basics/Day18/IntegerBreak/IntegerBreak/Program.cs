/// <summary>
/// 20220922
/// https://leetcode.cn/problems/integer-break/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public int IntegerBreak(int n)
    {
        var dp = new int[n + 1];
        Array.Fill(dp, 0);
        dp[1] = 1;
        for (int i = 2; i < n + 1; i++)
        {
            for (int j = i - 1; j >= 1; j--)
            {
                dp[i] = Math.Max(dp[i], dp[j] * (i - j));
                dp[i] = Math.Max(dp[i], j * (i - j));
            }
        }
        return dp[n];
    }
}
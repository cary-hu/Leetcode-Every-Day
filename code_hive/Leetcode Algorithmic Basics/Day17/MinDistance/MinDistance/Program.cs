/// <summary>
/// 20220921
/// https://leetcode.cn/problems/delete-operation-for-two-strings/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public int MinDistance(string word1, string word2)
    {
        var m = word1.Length;
        var n = word2.Length;
        var dp = new int[m + 1][];
        for (int i = 0; i < m + 1; i++)
        {
            dp[i] = new int[n + 1];
            Array.Fill(dp[i], 0);
        }
        for (int i = 1; i <= m; i++)
        {
            char c1 = word1[i - 1];
            for (int j = 1; j <= n; j++)
            {
                char c2 = word2[j - 1];
                if (c1 == c2)
                {
                    dp[i][j] = dp[i - 1][j - 1];
                }
                else
                {
                    dp[i][j] = Math.Min(dp[i - 1][j], dp[i][j - 1]) + 1;
                }
            }
        }
        return dp[m][n];
    }
}
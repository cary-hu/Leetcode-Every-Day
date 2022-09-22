/// <summary>
/// 20220922
/// https://leetcode.cn/problems/edit-distance/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public int MinDistance(string word1, string word2)
    {
        var n = word1.Length;
        var m = word2.Length;
        var dp = new int[n + 1][];
        for (int i = 0; i < n + 1; i++)
        {
            dp[i] = new int[m + 1];
            Array.Fill(dp[i], 0);
        }
        for (int i = 0; i < n + 1; i++)
        {
            dp[i][0] = i;
        }
        for (int i = 0; i < m + 1; i++)
        {
            dp[0][i] = i;
        }
        for (int i = 1; i < n + 1; i++)
        {
            for (int j = 1; j < m + 1; j++)
            {
                dp[i][j] = Math.Min(dp[i - 1][j], dp[i][j - 1]) + 1;
                dp[i][j] = Math.Min(dp[i][j], dp[i - 1][j - 1] + (word1[i - 1] != word2[j - 1] ? 1 : 0));
            }
        }
        return dp[n][m];
    }
}
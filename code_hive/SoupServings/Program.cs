/// <summary>
/// 20221121
/// https://leetcode.cn/problems/soup-servings/
/// </summary>
public class Solution
{
    public double SoupServings(int n)
    {
        n = (int)Math.Ceiling((double)n / 25);
        if (n >= 179)
        {
            return 1.0;
        }
        double[][] dp = new double[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            dp[i] = new double[n + 1];
        }
        dp[0][0] = 0.5;
        for (int i = 1; i <= n; i++)
        {
            dp[0][i] = 1.0;
        }
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                dp[i][j] = (dp[Math.Max(0, i - 4)][j] + dp[Math.Max(0, i - 3)][Math.Max(0, j - 1)] + dp[Math.Max(0, i - 2)][Math.Max(0, j - 2)] + dp[Math.Max(0, i - 1)][Math.Max(0, j - 3)]) / 4.0;
            }
        }
        return dp[n][n];
    }
}
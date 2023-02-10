/// <summary>
/// 20230210
/// https://leetcode.cn/problems/dice-roll-simulation/
/// </summary>
public class Solution
{
    const int MOD = 1000000007;
    public int DieSimulator(int n, int[] rollMax)
    {
        if (n == 1) return 6;
        var dp = new int[n][][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[7][];
            for (int j = 0; j < 7; j++)
            {
                dp[i][j] = new int[16];
            }
        }
        for (int i = 1; i < 7; ++i)
        {
            dp[0][i][1] = 1;
        }
        for (int i = 1; i < n; ++i)
        {
            for (int j = 1; j < 7; ++j)
            {
                for (int k = 1; k < 7; ++k)
                {
                    if (j != k)
                    {
                        for (int t = 1; t <= rollMax[k - 1]; ++t)
                        {
                            dp[i][j][1] += dp[i - 1][k][t];
                            dp[i][j][1] %= MOD;
                        }
                    }
                    else
                    {
                        for (int t = 1; t < rollMax[k - 1]; ++t)
                        {
                            dp[i][j][t + 1] += dp[i - 1][k][t];
                            dp[i][j][t + 1] %= MOD;
                        }
                    }
                }
            }
        }
        int sum = 0;
        for (int i = 1; i < 7; ++i)
        {
            for (int t = 1; t <= rollMax[i - 1]; ++t)
            {
                sum = (sum + dp[n - 1][i][t]) % MOD;
            }
        }
        return sum;
    }
}
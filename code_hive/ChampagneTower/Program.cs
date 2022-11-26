﻿/// <summary>
/// 20221120
/// https://leetcode.cn/problems/champagne-tower/
/// </summary>
public class Solution
{
    public double ChampagneTower(int poured, int query_row, int query_glass)
    {
        var dp = new double[101][];
        for (int i = 0; i < 101; i++)
        {
            dp[i] = new double[101];
            Array.Fill(dp[i], 0);
        }
        dp[0][0] = poured;
        for (int i = 0; i <= query_row; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (dp[i][j] >= 1)
                {
                    double remain = dp[i][j] - 1;
                    dp[i][j] = 1;
                    dp[i + 1][j] += remain / 2;
                    dp[i + 1][j + 1] += remain / 2;
                }
            }
        }
        return dp[query_row][query_glass];
    }
}
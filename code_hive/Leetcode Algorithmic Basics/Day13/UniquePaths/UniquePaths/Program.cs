new Solution().UniquePaths(3, 7);
/// <summary>
/// 20220917
/// https://leetcode.cn/problems/unique-paths/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public int UniquePaths(int m, int n)
    {
        var dp = new List<List<int>>();
        for (int i = 0; i < m; i++)
        {
            dp.Add(new List<int> { 1 });
        }
        for (int j = 0; j < n; j++)
        {
            dp[0].Add(1);
        }
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                dp[i].Add(dp[i - 1][j] + dp[i][j - 1]);
            }
        }
        return dp[m - 1][n - 1];
    }
}
/// <summary>
/// 20240906
/// https://leetcode.cn/problems/find-the-maximum-length-of-a-good-subsequence-i/
/// </summary>
public class Solution
{
    public int MaximumLength(int[] nums, int k)
    {
        int n = nums.Length;
        var dp = new int[n + 1][];
        for (int i = 0; i < n + 1; i++)
        {
            dp[i] = new int[k + 1];
            Array.Fill(dp[i], 1);
        }
        int res = 1;
        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[i] == nums[j])
                {
                    for (int l = 0; l <= k; l++)
                        dp[i][l] = Math.Max(dp[i][l], dp[j][l] + 1);
                }
                else
                {
                    for (int l = 1; l <= k; l++)
                        dp[i][l] = Math.Max(dp[i][l], dp[j][l - 1] + 1);
                }
            }
            res = Math.Max(res, dp[i][k]);
        }
        return res;

    }
}
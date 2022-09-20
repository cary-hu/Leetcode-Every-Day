/// <summary>
/// 20220920
/// https://leetcode.cn/problems/longest-increasing-subsequence/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public int LengthOfLIS(int[] nums)
    {
        int n = nums.Length;
        var dp = new int[n];
        Array.Fill(dp, 1);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[j] < nums[i])
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }

            }
        }
        int res = 0;
        for (int i = 0; i < n; i++)
        {
            res = Math.Max(res, dp[i]);
        }
        return res;
    }
}
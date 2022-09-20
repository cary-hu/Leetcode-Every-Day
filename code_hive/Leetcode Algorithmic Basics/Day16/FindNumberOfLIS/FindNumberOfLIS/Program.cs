/// <summary>
/// 20220920
/// https://leetcode.cn/problems/number-of-longest-increasing-subsequence/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public int FindNumberOfLIS(int[] nums)
    {
        int n = nums.Length, maxLen = 0, ans = 0;
        int[] dp = new int[n];
        Array.Fill(dp, 1);
        int[] cnt = new int[n];
        Array.Fill(cnt, 1);
        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j < i; ++j)
            {
                if (nums[i] > nums[j])
                {
                    if (dp[j] + 1 > dp[i])
                    {
                        dp[i] = dp[j] + 1;
                        cnt[i] = cnt[j];
                    }
                    else if (dp[j] + 1 == dp[i])
                    {
                        cnt[i] += cnt[j];
                    }
                }
            }
            if (dp[i] > maxLen)
            {
                maxLen = dp[i];
                ans = cnt[i];
            }
            else if (dp[i] == maxLen)
            {
                ans += cnt[i];
            }
        }
        return ans;
    }
}
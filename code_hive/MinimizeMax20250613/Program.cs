using System.Reflection.Metadata.Ecma335;

/// <summary>
/// 20250613
/// https://leetcode.cn/problems/minimize-the-maximum-difference-of-pairs/
/// </summary>
/// 
new Solution().MinimizeMax([10, 1, 2, 7, 1, 3], 2);
public class Solution
{
    public int MinimizeMax(int[] nums, int p)
    {
        if (p == 0) return 0;
        Array.Sort(nums);
        var len = nums.Length;

        int[] diff = new int[len - 1];

        for (int i = 0; i < len - 1; ++i)
        {
            diff[i] = nums[i + 1] - nums[i];
        }

        var dp = new int[p + 1];
        dp[0] = 0;
        for (int i = 1; i <= p; ++i)
        {
            dp[i] = int.MaxValue;
        }
        for (int i = 0; i < len - 1; ++i)
        {
            for (int j = p; j >= 1; --j)
            {
                if (dp[j - 1] != int.MaxValue)
                {
                    dp[j] = Math.Min(dp[j], Math.Max(dp[j - 1], diff[i]));
                }
            }
        }

        return dp[p];

    }
}
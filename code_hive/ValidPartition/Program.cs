/// <summary>
/// 20240301
/// https://leetcode.cn/problems/check-if-there-is-a-valid-partition-for-the-array/
/// </summary>
public class Solution
{
    public bool ValidPartition(int[] nums)
    {
        int n = nums.Length;
        if (n == 2)
        {
            return nums[1] == nums[0];
        }
        var dp = new int[n + 1];
        Array.Fill(dp, 0);
        dp[0] = 1;
        dp[2] = nums[1] == nums[0] ? 1 : 0;
        for (int i = 3; i < n + 1; ++i)
        {
            if (nums[i - 1] == nums[i - 2])
            {
                dp[i] |= dp[i - 2];
            }
            if (nums[i - 1] == nums[i - 2] && nums[i - 2] == nums[i - 3])
            {
                dp[i] |= dp[i - 3];
            }
            if (nums[i - 1] - nums[i - 2] == 1 && nums[i - 2] - nums[i - 3] == 1)
            {
                dp[i] |= dp[i - 3];
            }
        }
        return dp[n] == 1;
    }
}
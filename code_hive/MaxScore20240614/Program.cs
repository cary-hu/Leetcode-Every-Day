/// <summary>
/// 20240614
/// https://leetcode.cn/problems/visit-array-positions-to-maximize-score/
/// </summary>
public class Solution
{
    public long MaxScore(int[] nums, int x)
    {
        long[] dp = [int.MinValue, int.MinValue];
        dp[nums[0] % 2] = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            int parity = (int)(nums[i] % 2);
            long cur = Math.Max(dp[parity] + nums[i], dp[1 - parity] - x + nums[i]);
            dp[parity] = Math.Max(dp[parity], cur);
        }
        return Math.Max(dp[0], dp[1]);
    }
}
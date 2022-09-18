/// <summary>
/// 20220918
/// https://leetcode.cn/problems/arithmetic-slices/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public int NumberOfArithmeticSlices(int[] nums)
    {
        if (nums.Length < 3)
        {
            return 0;
        }
        var dp = new int[nums.Length];
        Array.Fill(dp, 0);
        for (int i = 1; i < nums.Length - 1; i++)
        {
            if (nums[i - 1] + nums[i + 1] == nums[i] * 2)
            {
                dp[i] = dp[i - 1] + 1;
            }
        }
        return dp.Sum();
    }
}
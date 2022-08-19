/// <summary>
/// 20220809
/// https://leetcode.cn/problems/minimum-value-to-get-positive-step-by-step-sum/
/// </summary>
public class Solution
{
    public int MinStartValue(int[] nums)
    {
        int tmp = nums[0], sum = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            sum += nums[i];
            tmp = Math.Min(tmp, sum);
        }
        return Math.Max(1, 1 - tmp);
    }
}
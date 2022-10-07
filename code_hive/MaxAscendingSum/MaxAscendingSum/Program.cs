/// <summary>
/// 20221007
/// https://leetcode.cn/problems/maximum-ascending-subarray-sum/
/// </summary>
public class Solution
{
    public int MaxAscendingSum(int[] nums)
    {
        var res = 0;

        var currentSum = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                currentSum += nums[i];
                res = Math.Max(res, currentSum);
            }
            else
            {
                currentSum = nums[i];
            }
        }

        return res;
    }
}
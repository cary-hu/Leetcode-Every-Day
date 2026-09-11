/// <summary>
/// 20260904
/// https://leetcode.cn/problems/smallest-stable-index-i
/// </summary>
public class Solution
{
    public int FirstStableIndex(int[] nums, int k)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            var leftMax = nums[i];
            for (int j = 0; j < i; j++)
            {
                leftMax = Math.Max(leftMax, nums[j]);
            }
            var rightMin = nums[i];
            for (int j = i + 1; j < nums.Length; j++)
            {
                rightMin = Math.Min(rightMin, nums[j]);
            }
            if (leftMax - rightMin <= k)
            {
                return i;
            }
        }
        return -1;
    }
}
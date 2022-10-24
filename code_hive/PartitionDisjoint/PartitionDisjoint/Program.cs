/// <summary>
/// 20221024
/// https://leetcode.cn/problems/partition-array-into-disjoint-intervals/
/// </summary>
public class Solution
{
    public int PartitionDisjoint(int[] nums)
    {
        var leftMax = nums[0];
        var max = nums[0];
        var index = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            max = Math.Max(max, nums[i]);
            if (nums[i] < leftMax)
            {
                leftMax = max;
                index = i;
            }
        }
        return index + 1;
    }
}
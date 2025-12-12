/// <summary>
/// 20251205
/// https://leetcode.cn/problems/count-partitions-with-even-sum-difference/
/// </summary>
public class Solution
{
    public int CountPartitions(int[] nums)
    {
        int count = 0;
        for (int i = 1; i < nums.Length ; i++)
        {
            var left = nums[0..i];
            var right = nums[i..];
            if ((left.Sum() - right.Sum()) % 2 == 0)
            {
                count++;
            }
        }
        return count;
    }
}
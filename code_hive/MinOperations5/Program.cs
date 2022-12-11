/// <summary>
/// 20221211
/// https://leetcode.cn/problems/minimum-operations-to-make-the-array-increasing/
/// </summary>
public class Solution
{
    public int MinOperations(int[] nums)
    {
        var res = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            res += Math.Max(0, nums[i - 1] + 1 - nums[i]);
            nums[i] = Math.Max(nums[i], nums[i - 1] + 1);
        }
        return res;
    }
}
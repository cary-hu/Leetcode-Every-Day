/// <summary>
/// 20221127
/// https://leetcode.cn/problems/check-if-array-is-sorted-and-rotated/
/// </summary>
public class Solution
{
    public bool Check(int[] nums)
    {
        int i = 0, n = nums.Length;
        var flag = true;
        while (++i < n)
        {
            if (nums[i] < nums[i - 1])
            {
                if (!flag) return false;
                flag = false;
            }
        }
        return nums[n - 1] <= nums[0] || flag;
    }
}
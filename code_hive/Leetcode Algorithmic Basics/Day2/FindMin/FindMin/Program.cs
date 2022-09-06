/// <summary>
/// 20220906
/// https://leetcode.cn/problems/find-minimum-in-rotated-sorted-array/
/// </summary>
public class Solution
{
    public int FindMin(int[] nums)
    {
        var l = 0;
        var r = nums.Length;
        while(l < r)
        {
            var mid = (l + r) >> 1;
            if (nums[mid] <= nums.Last())
            {
                r = mid;
            } else
            {
                l = mid + 1;
            }
        }
        return nums[l];
    }
}
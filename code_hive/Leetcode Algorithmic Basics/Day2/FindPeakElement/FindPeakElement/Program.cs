/// <summary>
/// 20220906
/// https://leetcode.cn/problems/find-peak-element/
/// </summary>
public class Solution
{
    public int FindPeakElement(int[] nums)
    {
        var l = 0;
        var r = nums.Length - 1;
        while( l < r)
        {
            var mid = (l + r) >> 1;
            if (nums[mid] > nums[mid + 1])
            {
                r = mid;
            } else
            {
                l = mid + 1;
            }
        }
        return l;
    }
}
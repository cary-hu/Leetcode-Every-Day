/// <summary>
/// 20220905
/// https://leetcode.cn/problems/find-first-and-last-position-of-element-in-sorted-array/
/// </summary>
public class Solution
{
    public int[] SearchRange(int[] nums, int target)
    {
        var badRes = new int[] { -1, -1 };
        if (!nums.Contains(target))
        {
            return badRes;
        }
        var start = -1;
        var end = -1;
        var l = 0;
        var r = nums.Length - 1;
        while (l < r)
        {
            var mid = (l + r) >> 1;
            if (nums[mid] >= target)
            {
                r = mid;
            }
            else
            {
                l = mid + 1;
            }
        }
        start = l;
        if (nums[start] != target)
        {
            return badRes;
        }
        l = 0;
        r = nums.Length - 1;
        while (l < r)
        {
            var mid = (l + r + 1) >> 1;
            if (nums[mid] <= target)
            {
                l = mid;
            }
            else
            {
                r = mid - 1;
            }
        }
        end = l;
        return new int[] { start, end };
    }
}
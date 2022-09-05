/// <summary>
/// 20220905
/// https://leetcode.cn/problems/search-in-rotated-sorted-array/
/// </summary>
public class Solution
{
    public int Search(int[] nums, int target)
    {
        var res = -1;
        var l = 0;
        var r = nums.Length - 1;
        while (l < r)
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
        if (target <= nums.Last())
        {
            r = nums.Length - 1;
        } else
        {
            l = 0;
            r--;
        }
        while(l < r)
        {
            var mid = (l + r) >> 1;
            if (nums[mid] >= target)
            {
                r = mid;
            } else
            {
                l = mid + 1;
            }
        }
        if (nums[l] == target)
        {
            res = l;
        } else
        {
            res = -1;
        }
        return res;
    }
}
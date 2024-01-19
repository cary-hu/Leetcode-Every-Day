/// <summary>
/// 20240119
/// https://leetcode.cn/problems/minimum-time-to-make-array-sum-at-most-x/
/// </summary>
/// 
new Solution().MinimumTime([1, 2, 3], [3,3, 3], 4);
public class Solution
{
    public int MinimumTime(IList<int> nums1, IList<int> nums2, int x)
    {
        int res = 0;
        int n = nums1.Count;

        var sortedNums2 = nums2.OrderBy(x => x).ToList();

        var setZeroPriority = nums2.Select(x => sortedNums2.IndexOf(x)).ToList();

        while (true)
        {
            if (res > n)
            {
                return -1;
            }
            for (int i = 0; i < n; i++)
            {
                nums1[i] += nums2[i];
            }

            nums1[setZeroPriority[res]] = 0;

            res++;
            if (nums1.Sum() <= x)
            {
                break;
            }
        }

        return res;
    }
}
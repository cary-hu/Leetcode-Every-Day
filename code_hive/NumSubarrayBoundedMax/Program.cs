/// <summary>
/// 20221124
/// https://leetcode.cn/problems/number-of-subarrays-with-bounded-maximum/
/// </summary>
public class Solution
{
    public int NumSubarrayBoundedMax(int[] nums, int left, int right)
    {
        int n = nums.Length, s = 0, k = -1, l = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] > right)
            {
                k = i;
                l = 0;
            }
            else if (nums[i] >= left)
                l = i - k;
            s += l;
        }
        return s;
    }
}
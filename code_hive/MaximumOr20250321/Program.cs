/// <summary>
/// 20250321
/// https://leetcode.cn/problems/maximum-or/
/// </summary>
public class Solution
{
    public long MaximumOr(int[] nums, int k)
    {
        int n = nums.Length;
        if (n == 0) return 0;

        long[] prefix = new long[n];
        long[] suffix = new long[n];

        prefix[0] = nums[0];
        for (int i = 1; i < n; i++)
        {
            prefix[i] = prefix[i - 1] | nums[i];
        }

        suffix[n - 1] = nums[n - 1];
        for (int i = n - 2; i >= 0; i--)
        {
            suffix[i] = suffix[i + 1] | nums[i];
        }

        long maxRes = 0L;
        for (int i = 0; i < n; i++)
        {
            long left = (i > 0) ? prefix[i - 1] : 0L;
            long right = (i < n - 1) ? suffix[i + 1] : 0L;
            long shifted = (long)nums[i] << k;
            long total = left | right | shifted;
            maxRes = Math.Max(maxRes, total);
        }

        return maxRes;
    }
}
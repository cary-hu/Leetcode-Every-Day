/// <summary>
/// 20220107
/// https://leetcode.cn/problems/minimum-operations-to-reduce-x-to-zero/
/// </summary>
public class Solution
{
    public int MinOperations(int[] nums, int x)
    {
        int n = nums.Length;
        int sum = nums.Sum();

        if (sum < x)
        {
            return -1;
        }

        int right = 0;
        int lsum = 0, rsum = sum;
        int ans = n + 1;

        for (int left = -1; left < n; ++left)
        {
            if (left != -1)
            {
                lsum += nums[left];
            }
            while (right < n && lsum + rsum > x)
            {
                rsum -= nums[right];
                ++right;
            }
            if (lsum + rsum == x)
            {
                ans = Math.Min(ans, (left + 1) + (n - right));
            }
        }

        return ans > n ? -1 : ans;
    }
}
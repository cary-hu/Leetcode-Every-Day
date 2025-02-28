/// <summary>
/// 20250117
/// https://leetcode.cn/problems/shortest-subarray-with-or-at-least-k-ii/
/// </summary>
public class Solution
{
    public int MinimumSubarrayLength(int[] nums, int k)
    {
        int l = 0, r = 0;
        int[] bits = new int[32];
        int ans = int.MaxValue;

        while (r < nums.Length)
        {
            for (int i = 0; i < bits.Length; i++)
            {
                bits[i] += (nums[r] >> i) & 1;
            }

            while (l <= r && Calculate(bits) >= k)
            {
                ans = Math.Min(ans, r - l + 1);
                for (int i = 0; i < bits.Length; i++)
                {
                    bits[i] -= (nums[l] >> i) & 1;
                }
                l++;
            }
            r++;
        }

        return ans == int.MaxValue ? -1 : ans;
    }
    private int Calculate(int[] bits)
    {
        int res = 0;
        for (int i = 0; i < bits.Length; i++)
        {
            if (bits[i] > 0)
            {
                res += (1 << i);
            }
        }
        return res;
    }
}
/// <summary>
/// 20250425
/// https://leetcode.cn/problems/count-of-interesting-subarrays/
/// </summary>
public class Solution
{
    public long CountInterestingSubarrays(IList<int> nums, int modulo, int k)
    {
        int n = nums.Count;
        var cnt = new Dictionary<int, int>();
        long res = 0;
        int prefix = 0;
        cnt[0] = 1;
        for (int i = 0; i < n; i++)
        {
            prefix += nums[i] % modulo == k ? 1 : 0;
            res += cnt.ContainsKey((prefix - k + modulo) % modulo) ? cnt[(prefix - k + modulo) % modulo] : 0;
            if (cnt.ContainsKey(prefix % modulo))
            {
                cnt[prefix % modulo]++;
            }
            else
            {
                cnt[prefix % modulo] = 1;
            }
        }
        return res;
    }
}
/// <summary>
/// 20221207
/// https://leetcode.cn/problems/equal-sum-arrays-with-minimum-number-of-operations/
/// </summary>
public class Solution
{
    public int MinOperations(int[] nums1, int[] nums2)
    {
        int n = nums1.Length;
        int m = nums2.Length;
        if (n * 6 < m || n > m * 6)
        {
            return -1;
        }
        int sum1 = nums1.Sum();
        int sum2 = nums2.Sum();
        if (sum1 == sum2)
        {
            return 0;
        }
        int[] cnt = new int[7];
        if (sum1 > sum2)
        {
            foreach (int t in nums1)
            {
                cnt[t - 1]++;
            }
            foreach (int t in nums2)
            {
                cnt[6 - t]++;
            }

        }
        else
        {
            foreach (int t in nums1)
            {
                cnt[6 - t]++;
            }
            foreach (int t in nums2)
            {
                cnt[t - 1]++;
            }
        }
        int dif = Math.Abs(sum1 - sum2);
        int ans = 0;
        for (int i = 6; i >= 1; i--)
        {
            while (cnt[i] > 0)
            {
                if (dif < i)
                {
                    break;
                }
                dif -= i;
                cnt[i]--;
                ans++;
            }
        }
        ans += dif == 0 ? 0 : 1;
        return ans;
    }
}
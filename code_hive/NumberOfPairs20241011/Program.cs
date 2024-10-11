/// <summary>
/// 20241011
/// https://leetcode.cn/problems/find-the-number-of-good-pairs-ii/
/// </summary>
public class Solution
{
    public long NumberOfPairs(int[] nums1, int[] nums2, int k)
    {
        long res = 0;
        var dict = new Dictionary<int, int>();
        for (int i = 0; i < nums2.Length; i++)
        {
            var key = nums2[i];
            if (dict.TryGetValue(key, out int value))
            {
                dict[key] = ++value;
            }
            else
            {
                dict.Add(key, 1);
            }
        }
        for (int i = 0; i < nums1.Length; i++)
        {
            var v = nums1[i];
            var factors = PrimeFactors(v);
            for (int j = 0; j < factors.Count; j++)
            {
                var d = factors[j];
                if (d % k == 0)
                {
                    int target = d / k;
                    if (dict.TryGetValue(target, out int value))
                    {
                        res += value;
                    }
                }
                int otherDiv = v / d;
                if (d != otherDiv && otherDiv % k == 0)
                {
                    int target = otherDiv / k;
                    if (dict.TryGetValue(target, out int value))
                    {
                        res += value;
                    }
                }
            }
        }
        return res;
    }
    static List<int> PrimeFactors(int n)
    {
        var factors = new List<int>();
        for (int i = 1; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
            {
                factors.Add(i);
            }
        }
        return factors;
    }
}
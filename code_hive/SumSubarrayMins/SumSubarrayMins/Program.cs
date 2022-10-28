/// <summary>
/// 20221028
/// https://leetcode.cn/problems/sum-of-subarray-minimums/
/// </summary>
public class Solution
{
    public int SumSubarrayMins(int[] arr)
    {
        var mod = 1000000007;
        long res = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            int j = i - 1, k = i + 1;
            while (j >= 0 && arr[i] < arr[j])
            {
                j--;
            }
            while (k < arr.Length && arr[i] <= arr[k])
            {
                k++;
            }
            res += (long)arr[i] * (i - j) * (k - i);
            res %= mod;
        }
        return (int)res;
    }
    public int SumSubarrayMins2(int[] arr)
    {
        var mod = 1000000007;
        long res = 0;
        var n = arr.Length;
        for (int i = 0; i < n; i++)
        {
            var min = arr[i];
            for (int j = i; j < n; j++)
            {
                min = Math.Min(min, arr[j]);
                res = res + min;
                if(res >= mod)
                {
                    res -= mod;
                }
            }
        }
        return (int)res;
    }
}
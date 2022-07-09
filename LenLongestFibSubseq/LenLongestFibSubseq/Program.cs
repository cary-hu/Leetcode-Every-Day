var a = new Solution();
a.LenLongestFibSubseq(new int[] { 1, 3, 7, 11, 12, 14, 18 });
/// <summary>
/// 20220709
/// https://leetcode.cn/problems/length-of-longest-fibonacci-subsequence/
/// </summary>
public class Solution
{
    public int LenLongestFibSubseq(int[] arr)
    {
        Dictionary<int, int> indices = new Dictionary<int, int>();
        int n = arr.Length;
        for (int i = 0; i < n; i++)
        {
            indices.Add(arr[i], i);
        }
        int[,] dp = new int[n, n];
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = i - 1; j >= 0 && arr[j] * 2 > arr[i]; j--)
            {
                int k = indices.ContainsKey(arr[i] - arr[j]) ? indices[arr[i] - arr[j]] : -1;
                if (k >= 0)
                {
                    dp[j, i] = Math.Max(dp[k, j] + 1, 3);
                }
                ans = Math.Max(ans, dp[j, i]);
            }
        }
        return ans;
    }
}
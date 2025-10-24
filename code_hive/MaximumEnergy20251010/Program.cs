/// <summary>
/// 20251010
/// https://leetcode.cn/problems/taking-maximum-energy-from-the-mystic-dungeon/
/// </summary>
public class Solution
{
    public int MaximumEnergy(int[] energy, int k)
    {
        var n = energy.Length;
        var dp = new int[n + k];
        for (int i = k; i < k + n; i++)
        {
            dp[i] = Math.Max(dp[i - k] + energy[i - k], energy[i - k]);
        }
        var res = int.MinValue;
        for (int i = n; i < k + n; i++)
        {
            res = Math.Max(res, dp[i]);
        }
        return res;

    }
}
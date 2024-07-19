/// <summary>
/// 20240719
/// https://leetcode.cn/problems/minimum-levels-to-gain-more-points/
/// </summary>
public class Solution
{
    public int MinimumLevels(int[] possible)
    {
        for (int i = 0; i < possible.Length; i++)
        {
            if (possible[i] == 0)
            {
                possible[i] = -1;
            }
        }
        var sum = possible.Sum();
        var prefixSum = 0;
        var res = -1;
        for (int i = 1; i < possible.Length; i++)
        {
            prefixSum += possible[i - 1];
            if (prefixSum > (sum - prefixSum))
            {
                res = i;
                break;
            }
        }

        return res;
    }
}
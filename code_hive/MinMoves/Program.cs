/// <summary>
/// 20221218
/// https://leetcode.cn/problems/minimum-adjacent-swaps-for-k-consecutive-ones/
/// </summary>
public class Solution
{
    public int MinMoves(int[] nums, int k)
    {
        IList<int> g = new List<int>();
        IList<int> preSum = new List<int>();
        preSum.Add(0);
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                g.Add(i - g.Count);
                preSum.Add(preSum[preSum.Count - 1] + g[g.Count - 1]);
            }
        }
        int m = g.Count, res = int.MaxValue;
        for (int i = 0; i <= m - k; i++)
        {
            int mid = i + k / 2;
            int r = g[mid];
            res = Math.Min(res, (1 - k % 2) * r + (preSum[i + k] - preSum[mid + 1]) - (preSum[mid] - preSum[i]));
        }
        return res;
    }
}
/// <summary>
/// 20220826
/// https://leetcode.cn/problems/insert-interval/
/// </summary>
public class Solution
{
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        var res = new List<int[]>();
        var currentLeft = newInterval[0];
        var currentRight = newInterval[1];
        var isInserted = false;
        foreach (var interval in intervals)
        {
            if (interval[0] > currentRight)
            {
                if (!isInserted)
                {
                    res.Add(new int[] { currentLeft, currentRight });
                    isInserted = true;
                }
                res.Add(interval);
            }
            else if (interval[1] < currentLeft)
            {
                res.Add(interval);
            }
            else
            {
                currentLeft = Math.Min(currentLeft, interval[0]);
                currentRight = Math.Max(currentRight, interval[1]);
            }
        }
        if (!isInserted)
        {
            res.Add(new int[] { currentLeft, currentRight });
        }
        int[][] ans = new int[res.Count][];
        for (int i = 0; i < res.Count; ++i)
        {
            ans[i] = res[i];
        }

        return ans;
    }
}
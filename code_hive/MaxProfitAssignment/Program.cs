/// <summary>
/// 20240517
/// https://leetcode.cn/problems/most-profit-assigning-work/
/// </summary>
public class Solution
{
    public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker)
    {
        var jobs = difficulty.Zip(profit, (d, p) => (d, p)).OrderBy(x => x.d).ToArray();
        Array.Sort(worker);
        int res = 0, i = 0, best = 0;
        foreach (int w in worker)
        {
            while (i < jobs.Length && w >= jobs[i].d)
            {
                best = Math.Max(best, jobs[i].p);
                i++;
            }
            res += best;
        }
        return res;

    }
}
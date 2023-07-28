/// <summary>
/// 20230728
/// https://leetcode.cn/problems/parallel-courses-iii/
/// </summary>
public class Solution
{
    private IList<int>[] PreviousCourseList;
    private IDictionary<int, int> MinimalCourseTimeMemo = new Dictionary<int, int>();

    public int MinimumTime(int n, int[][] relations, int[] time)
    {
        int mx = 0;
        PreviousCourseList = new IList<int>[n + 1];
        for (int i = 0; i <= n; i++)
        {
            PreviousCourseList[i] = new List<int>();
        }
        foreach (int[] relation in relations)
        {
            int x = relation[0], y = relation[1];
            PreviousCourseList[y].Add(x);
        }
        for (int i = 1; i <= n; i++)
        {
            mx = Math.Max(mx, dfs(i, time));
        }
        return mx;
    }

    public int dfs(int i, int[] time)
    {
        if (MinimalCourseTimeMemo.ContainsKey(i))
        {
            return MinimalCourseTimeMemo[i];
        }
        int cur = 0;
        foreach (int p in PreviousCourseList[i])
        {
            cur = Math.Max(cur, dfs(p, time));
        }
        cur += time[i - 1];
        MinimalCourseTimeMemo.Add(i, cur);
        return MinimalCourseTimeMemo[i];
    }
}
/// <summary>
/// 20220722
/// https://leetcode.cn/problems/set-intersection-size-at-least-two/
/// </summary>
public class Solution
{
    public int IntersectionSizeTwo(int[][] intervals)
    {
        Array.Sort(intervals, (o1, o2) => o1[0] == o2[0] ? o2[1] - o1[1] : o1[0] - o2[0]);
        int n = intervals.Length;
        int cur = intervals[n - 1][0];
        int next = intervals[n - 1][0] + 1;
        int ans = 2;
        for (int i = n - 2; i >= 0; i--)
        {
            if (intervals[i][1] >= next)
            {
                continue;
            }
            else if (intervals[i][1] < cur)
            {
                cur = intervals[i][0];
                next = intervals[i][0] + 1;
                ans = ans + 2;
            }
            else
            {
                next = cur;
                cur = intervals[i][0];
                ans++;
            }
        }
        return ans;
    }
}
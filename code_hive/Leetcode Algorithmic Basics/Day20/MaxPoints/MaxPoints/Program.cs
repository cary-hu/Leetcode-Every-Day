/// <summary>
/// 20220923
/// https://leetcode.cn/problems/max-points-on-a-line/?envType=study-plan&id=suan-fa-ji-chu
/// </summary>
public class Solution
{
    public int MaxPoints(int[][] points)
    {
        int n = points.Length;
        if (n == 1) return 1;
        Array.Sort(points, (a,b) => { return a[0] - b[0]; });
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            if (ans >= n - i || ans > n / 2)
            {
                break;
            }
            for (int j = i + 1; j < n; j++)
            {
                int tmp = 0;
                int x1 = points[i][0], y1 = points[i][1];
                int x2 = points[j][0], y2 = points[j][1];
                int dy = y1 - y2, dx = x1 - x2;
                foreach (var p in points)
                {
                    if (dy * (p[0] - x1) == dx * (p[1] - y1)) tmp++;
                }
                ans = Math.Max(ans, tmp);
            }
        }
        return ans;
    }
}
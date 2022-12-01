using System.Runtime.CompilerServices;
/// <summary>
/// 20221201
/// https://leetcode.cn/problems/find-nearest-point-that-has-the-same-x-or-y-coordinate/
/// </summary>
public class Solution
{
    public int NearestValidPoint(int x, int y, int[][] points)
    {
        var res = -1;
        var currentLength = int.MaxValue;
        for (int i = 0; i < points.Length; i++)
        {
            var point = points[i];
            if (!IsValidPoint(x, y, point))
            {
                continue;
            }
            var manhadon = GetManhadon(x, y, point);
            if (manhadon < currentLength)
            {
                currentLength = manhadon;
                res = i;
            }
        }
        return res;
    }
    private int GetManhadon(int x, int y, int[] points)
    {
        return Math.Abs(points[0] - x) + Math.Abs(points[1] - y);
    }
    private bool IsValidPoint(int x, int y, int[] point)
    {
        if (point[0] == x)
        {
            return true;
        }
        if (point[1] == y)
        {
            return true;
        }
        return false;
    }
}
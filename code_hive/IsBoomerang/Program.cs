/// <summary>
/// 20220608
/// https://leetcode.cn/problems/valid-boomerang/
/// </summary>
public class Solution
{
    public bool IsBoomerang(int[][] points)
    {
        var x1 = points[0][0];
        var y1 = points[0][1];
        var x2 = points[1][0];
        var y2 = points[1][1];
        var x3 = points[2][0];
        var y3 = points[2][1];
        return (x1 * y2 + x2 * y3 + x3 * y1 - x1 * y3 - x2 * y1 - x3 * y2) != 0;
    }
}
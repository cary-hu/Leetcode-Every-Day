/// <summary>
/// 20220729
/// https://leetcode.cn/problems/valid-square/
/// </summary>
public class Solution
{
    public static bool ValidSquare(int[] p1, int[] p2, int[] p3, int[] p4)
    {
        var list = new List<int>
        {
            GetDis(p1, p2),
            GetDis(p1, p3),
            GetDis(p1, p4),
            GetDis(p2, p3),
            GetDis(p2, p4),
            GetDis(p3, p4)
        };
        list = list.Distinct().ToList();
        return list.Count == 2 && (list[0] != 0 && list[1] != 0);
    }
    private static int GetDis(int[] p1, int[] p2)
    {
        return (p1[0] - p2[0]) * (p1[0] - p2[0]) + (p1[1] - p2[1]) * (p1[1] - p2[1]);
    }
}
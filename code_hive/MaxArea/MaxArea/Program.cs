/// <summary>
/// 20231027
/// https://leetcode.cn/problems/maximum-area-of-a-piece-of-cake-after-horizontal-and-vertical-cuts
/// </summary>
public class Solution
{
    public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts)
    {
        Array.Sort(horizontalCuts);
        Array.Sort(verticalCuts);
        var hor = new List<int>(horizontalCuts);
        var vert = new List<int>(verticalCuts);

        hor.Add(h);
        vert.Add(w);
        hor.Insert(0, 0);
        vert.Insert(0, 0);
        long maxHor = int.MinValue;
        long maxVert = int.MinValue;

        for (int i = 1; i < hor.Count; i++)
        {
            maxHor = Math.Max(maxHor, hor[i] - hor[i - 1]) * 1L;
        }
        for (int i = 1; i < vert.Count; i++)
        {
            maxVert = Math.Max(maxVert, vert[i] - vert[i - 1]) * 1L;
        }

        return (int)(maxHor % 1000000007 * maxVert % 1000000007);
    }
}
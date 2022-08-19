/// <summary>
/// 20220708
/// https://leetcode.cn/problems/minimum-cost-to-move-chips-to-the-same-position/
/// </summary>
public class Solution
{
    public int MinCostToMoveChips(int[] position)
    {
        int even = 0;
        foreach (var p in position)
        {
            if (p % 2 == 0)
            {
                even++;
            }
        }
        return Math.Min(position.Count() - even, even);
    }
}
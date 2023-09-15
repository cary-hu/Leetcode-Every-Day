/// <summary>
/// 20230915
/// https://leetcode.cn/problems/WHnhjV
/// </summary>
public class Solution
{
    public int GiveGem(int[] gem, int[][] operations)
    {
        foreach (var operation in operations)
        {
            var gemCount = gem[operation[0]] >> 1;
            gem[operation[0]] -= gemCount;
            gem[operation[1]] += gemCount;
        }
        return gem.Max() - gem.Min();
    }
}
/// <summary>
/// 20221119
/// https://leetcode.cn/problems/find-the-highest-altitude/
/// </summary>
public class Solution
{
    public int LargestAltitude(int[] gain)
    {
        var maxGain = 0;
        var sum = 0;
        foreach (var gainItem in gain)
        {
            sum += gainItem;
            maxGain = Math.Max(sum, maxGain);
        }
        return maxGain;
    }
}
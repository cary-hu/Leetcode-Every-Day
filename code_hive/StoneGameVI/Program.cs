/// <summary>
/// 20240202
/// https://leetcode.cn/problems/stone-game-vi/
/// </summary>
public class Solution
{
    public int StoneGameVI(int[] aliceValues, int[] bobValues)
    {
        var n = aliceValues.Length;
        var values = new (int value, int index)[n];
        for (var i = 0; i < n; i++)
        {
            values[i] = (bobValues[i] + aliceValues[i], i);
        }
        Array.Sort(values, (a, b) => b.value - a.value);
        var count = 0;
        var round = 0;
        foreach (var value in values)
        {
            if (round++ % 2 == 0)
            {
                count += aliceValues[value.index];
            }
            else
            {
                count -= bobValues[value.index];
            }
        }
        return count == 0 ? 0 : count > 0 ? 1 : -1;
    }
}
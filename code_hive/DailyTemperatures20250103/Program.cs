/// <summary>
/// 20250103
/// https://leetcode.cn/problems/daily-temperatures/
/// </summary>
public class Solution
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        var res = new int[temperatures.Length];
        Array.Fill(res, 0);
        for (int j = 0; j < temperatures.Length; j++)
        {
            var current = temperatures[j];
            for (var i = j + 1; i < temperatures.Length; i++)
            {
                if (temperatures[i] > current)
                {
                    res[j] = i - j;
                    break;
                }
            }
        }

        return res;
    }
}
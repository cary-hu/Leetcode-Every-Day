/// <summary>
/// 20240830
/// https://leetcode.cn/problems/sum-of-digit-differences-of-all-pairs/
/// </summary>
public class Solution
{
    public long SumDigitDifferences(int[] nums)
    {
        var numStrings = nums.Select(i => i.ToString()).ToList();
        var dict = new Dictionary<int, long[]>();
        foreach (var numString in numStrings)
        {
            for (int i = 0; i < numString.Length; i++)
            {
                var numPart = int.Parse(numString[i].ToString());
                if (dict.TryGetValue(i, out var value))
                {
                    dict[i][numPart] = ++value[numPart];
                }
                else
                {
                    var ints = new long[10];
                    Array.Fill(ints, 0);
                    ints[numPart]++;
                    dict[i] = ints;
                }

            }
        }
        long sum = 0;
        var n = nums.Length;
        foreach (var dictItem in dict)
        {
            for (int i = 0; i < 10; i++)
            {
                var c = dictItem.Value[i];
                sum += c * (n - c) * 1l;
            }
        }
        if (sum < 0)
        {
            return 0;
        }
        return sum / 2;
    }
}
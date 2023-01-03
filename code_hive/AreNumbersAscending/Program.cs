/// <summary>
/// 20220103
/// https://leetcode.cn/problems/check-if-numbers-are-ascending-in-a-sentence/
/// </summary>
public class Solution
{
    public bool AreNumbersAscending(string s)
    {
        var originNumber = s.Split(" ").Where(x => int.TryParse(x, out _)).Select(x => Convert.ToInt32(x)).ToList();
        var sortedNumber = originNumber.OrderBy(x => x).Distinct();
        return sortedNumber.SequenceEqual(originNumber);
    }
}
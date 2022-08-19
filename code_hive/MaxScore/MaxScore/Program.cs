/// <summary>
/// 20220814
/// https://leetcode.cn/problems/maximum-score-after-splitting-a-string/
/// </summary>
public class Solution
{
    public int MaxScore(string s)
    {
        var maxNum = int.MinValue;
        for (int i = 1; i < s.Length; i++)
        {
            maxNum = Math.Max(maxNum, GetZeroNumber(s[..i]) + GetOneNumber(s[i..]));
        }
        return maxNum;
    }
    private int GetZeroNumber(string s)
    {
        return s.Where(x => x == '0').Count();
    }
    private int GetOneNumber(string s)
    {
        return s.Where(x => x == '1').Count();
    }
}
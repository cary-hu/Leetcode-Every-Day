using System.Text.RegularExpressions;
/// <summary>
/// 20230414
/// https://leetcode.cn/problems/camelcase-matching/
/// </summary>
public class Solution
{
    public IList<bool> CamelMatch(string[] queries, string pattern)
    {
        string patternRegex = @$"^[a-z]*?{string.Join("[a-z]*?", pattern.ToCharArray())}[a-z]*?$";
        var res = new bool[queries.Length];
        var index = 0;
        foreach (var query in queries)
        {
            var isMatch = Regex.IsMatch(query, patternRegex);
            res[index++] = isMatch;
        }
        return res;
    }
}
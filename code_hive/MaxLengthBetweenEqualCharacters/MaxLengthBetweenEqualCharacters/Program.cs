using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
/// <summary>
/// 20220917
/// https://leetcode.cn/problems/largest-substring-between-two-equal-characters/
/// </summary>
public class Solution
{
    public int MaxLengthBetweenEqualCharacters(string s)
    {
        var ansDict = new Dictionary<char, (int, int)>();
        for (int i = 0; i < s.Length; i++)
        {
            if (ansDict.ContainsKey(s[i]))
            {
                ansDict[s[i]] = (ansDict[s[i]].Item1, i);
            }
            else
            {
                ansDict.Add(s[i], (i, -1));
            }
        }
        ansDict = ansDict.Where(x => x.Value.Item2 != -1).ToDictionary(x => x.Key, y => y.Value);
        if (ansDict.Count == 0)
        {
            return -1;
        }
        var res = ansDict.Max(x => x.Value.Item2 - x.Value.Item1);
        return res - 1;
    }
}
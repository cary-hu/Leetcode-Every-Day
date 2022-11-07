/// <summary>
/// 20221107
/// https://leetcode.cn/problems/ambiguous-coordinates/
/// </summary>
public class Solution
{
    public IList<string> AmbiguousCoordinates(string s)
    {
        int n = s.Length;
        s = s[1..(n - 1)];
        var ans = new List<string>();
        for (int i = 1; i < n - 2; i++)
        {
            var part1 = CutNumber(s[..i]);
            var part2 = CutNumber(s[i..]);
            foreach (var a in part1)
            {
                foreach (var b in part2)
                {
                    ans.Add("(" + a + ", " + b + ")");
                }
            }
        }
        return ans;
    }
    private List<string> CutNumber(string s)
    {
        var list = new List<string>();
        if (s.Length == 1 || s[0] != '0')
        {
            list.Add(s);
        }
        for (int i = 1; i < s.Length; i++)
        {
            var s1 = s[..i];
            var s2 = s[i..];
            if ((s1.Length == 1 || s[0] != '0') && s2[^1] != '0')
            {
                list.Add(s1 + "." + s2);
            }
        }
        return list;
    }
}
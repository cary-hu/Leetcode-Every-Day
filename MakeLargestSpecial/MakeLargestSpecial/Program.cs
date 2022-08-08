using System.Text;
/// <summary>
/// 20220808
/// https://leetcode.cn/problems/special-binary-string/
/// </summary>
public class Solution
{
    public string MakeLargestSpecial(string s)
    {
        if (s.Length <= 2)
        {
            return s;
        }
        int cnt = 0, left = 0;
        List<string> subs = new List<string>();
        for (int i = 0; i < s.Length; ++i)
        {
            if (s[i] == '1')
            {
                ++cnt;
            }
            else
            {
                --cnt;
                if (cnt == 0)
                {
                    subs.Add("1" + MakeLargestSpecial(s.Substring(left + 1, i - left - 1)) + "0");
                    left = i + 1;
                }
            }
        }

        subs.Sort((a, b) => b.CompareTo(a));
        StringBuilder ans = new StringBuilder();
        foreach (string sub in subs)
        {
            ans.Append(sub);
        }
        return ans.ToString();
    }
}
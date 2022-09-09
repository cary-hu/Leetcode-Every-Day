var a = new Solution();
a.FindAnagrams("abab", "ab");
/// <summary>
/// 20220909
/// https://leetcode.cn/problems/find-all-anagrams-in-a-string/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public IList<int> FindAnagrams(string s, string p)
    {
        int sLen = s.Length, pLen = p.Length;

        if (sLen < pLen)
        {
            return new List<int>();
        }

        IList<int> ans = new List<int>();
        int[] sCount = new int[26];
        int[] pCount = new int[26];
        for (int i = 0; i < pLen; ++i)
        {
            ++sCount[s[i] - 'a'];
            ++pCount[p[i] - 'a'];
        }

        if (Enumerable.SequenceEqual(sCount, pCount))
        {
            ans.Add(0);
        }

        for (int i = 0; i < sLen - pLen; ++i)
        {
            --sCount[s[i] - 'a'];
            ++sCount[s[i + pLen] - 'a'];

            if (Enumerable.SequenceEqual(sCount, pCount))
            {
                ans.Add(i + 1);
            }
        }

        return ans;
    }
}
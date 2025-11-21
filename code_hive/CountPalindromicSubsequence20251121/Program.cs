/// <summary>
/// 20251121
/// https://leetcode.cn/problems/unique-length-3-palindromic-subsequences/
/// </summary>
public class Solution
{
    public int CountPalindromicSubsequence(string s)
    {
        int count = 0;
        for (char c = 'a'; c <= 'z'; c++)
        {
            int first = s.IndexOf(c);
            int last = s.LastIndexOf(c);
            if (first >= 0 && last > first + 1)
            {
                HashSet<char> set = new();
                for (int i = first + 1; i < last; i++)
                {
                    set.Add(s[i]);
                }
                count += set.Count;
            }
        }
        return count;
    }
}
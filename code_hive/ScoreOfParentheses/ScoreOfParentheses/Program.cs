/// <summary>
/// 20221009
/// https://leetcode.cn/problems/score-of-parentheses/
/// </summary>
public class Solution
{
    public int ScoreOfParentheses(string s)
    {
        return DFS(s, 1);
    }
    private int DFS(string s, int current)
    {
        if (s == "()")
        {
            return 1;
        }
        if (current == 2)
        {
            s = s[1..^1];
        }
        int res = 0;
        int l = 0, r = 0, p = 0;
        while (r < s.Length)
        {
            if (s[r] == '(') p++;
            else p--;
            if (p == 0)
            {
                res += DFS(s.Substring(l, r - l + 1), 2);
                l = r + 1;
            }
            r++;
        }
        return current * res;
    }
}
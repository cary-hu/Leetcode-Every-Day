using System.Text;
var a = new Solution();
a.BackspaceCompare("ab#c", "ad#c");
/// <summary>
/// 20220908
/// https://leetcode.cn/problems/backspace-string-compare/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public bool BackspaceCompare(string s, string t)
    {
        var sStack = new Stack<char>();
        foreach (char c in s)
        {
            if (c == '#')
            {
                sStack.TryPop(out _);
            }
            else
            {
                sStack.Push(c);
            }
        }
        var tStack = new Stack<char>();
        foreach (char c in t)
        {
            if (c == '#')
            {
                tStack.TryPop(out _);
            }
            else
            {
                tStack.Push(c);
            }
        }
        var sRes = new StringBuilder();
        while(sStack.Count > 0)
        {
            sRes.Append(sStack.Pop());
        }
        var tRes = new StringBuilder();
        while(tStack.Count > 0)
        {
            tRes.Append(tStack.Pop());
        }
        return sRes.ToString() == tRes.ToString();
    }
}
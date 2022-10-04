/// <summary>
/// 20221004
/// https://leetcode.cn/problems/minimum-add-to-make-parentheses-valid/
/// </summary>
public class Solution
{
    public int MinAddToMakeValid(string s)
    {
        var res = 0;
        var stack = new Stack<char>();
        foreach (var charItem in s)
        {
            if (stack.Count <= 0)
            {
                stack.Push(charItem);
                res++;
                continue;
            }
            if (stack.Peek() == '(' && charItem == ')')
            {
                stack.Pop();
                res--;
                continue;
            }
            stack.Push(charItem);
            res++;
        }
        return res;
    }
}
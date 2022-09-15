/// <summary>
/// 20220915
/// https://leetcode.cn/problems/generate-parentheses/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public IList<string> GenerateParenthesis(int n)
    {
        var res = new List<string>();
        if (n == 0)
        {
            return res;
        }
        DFS(0, 0, n, "", res);
        return res;
    }
    private void DFS(int l, int r, int n, string cur, List<string> res)
    {
        if (l == n && r == n)
        {
            res.Add(cur);
            return;
        }
        if (l < n)
        {
            DFS(l + 1, r, n, cur + "(", res);
        }

        if (r < l)
        {
            DFS(l, r + 1, n, cur + ")", res);
        }
    }
}
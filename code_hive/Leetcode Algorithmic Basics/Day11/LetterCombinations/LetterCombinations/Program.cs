/// <summary>
/// 20220915
/// https://leetcode.cn/problems/letter-combinations-of-a-phone-number/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    string[] temp = { "", "", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
    public IList<string> LetterCombinations(string digits)
    {
        var res = new List<string>();
        if (digits.Length == 0)
        {
            return res;
        }
        DFS(digits, 0, "", res);
        return res;
    }
    private void DFS(string digits, int d, string cur, IList<string> res)
    {
        if(d == digits.Length)
        {
            res.Add(cur);
            return;
        }
        int cur_num = digits[d] - '0';
        for (int i = 0; i < temp[cur_num].Length; i++)
        {
            DFS(digits, d + 1, cur + temp[cur_num][i], res);
        }
    }
}
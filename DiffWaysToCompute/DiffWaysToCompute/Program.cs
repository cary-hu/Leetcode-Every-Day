var a = new Solution();
a.DiffWaysToCompute("2-1-1");
/// <summary>
/// 20220701
/// https://leetcode.cn/problems/different-ways-to-add-parentheses/
/// </summary>
public class Solution
{
    public IList<int> DiffWaysToCompute(string expression)
    {
        var result = new List<int>();
        if (string.IsNullOrEmpty(expression))
        {
            return result;
        }
        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i] == '+' || expression[i] == '-' || expression[i] == '*')
            {
                var left = DiffWaysToCompute(expression.Substring(0, i));
                var right = DiffWaysToCompute(expression.Substring(i + 1));
                foreach (var l in left)
                {
                    foreach (var r in right)
                    {
                        switch (expression[i])
                        {
                            case '+':
                                result.Add(l + r);
                                break;
                            case '-':
                                result.Add(l - r);
                                break;
                            case '*':
                                result.Add(l * r);
                                break;
                        }
                    }
                }
            }
        }
        if (result.Count == 0)
        {
            result.Add(int.Parse(expression));
        }
        return result;

    }
}
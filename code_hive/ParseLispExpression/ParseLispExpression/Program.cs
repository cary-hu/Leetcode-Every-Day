using System.Text;
/// <summary>
/// 20220607
/// https://leetcode.cn/problems/parse-lisp-expression/
/// </summary>
public class Solution
{
    Dictionary<string, Stack<int>> scope = new Dictionary<string, Stack<int>>();
    int start = 0;

    public int Evaluate(string expression)
    {
        return InnerEvaluate(expression);
    }
    public int InnerEvaluate(string expression)
    {
        if (expression[start] != '(')
        { // 非表达式，可能为：整数或变量
            if (char.IsLower(expression[start]))
            {
                string var = ParseVar(expression); // 变量
                return scope[var].Peek();
            }
            else
            { // 整数
                return ParseInt(expression);
            }
        }
        int ret;
        start++; // 移除左括号
        if (expression[start] == 'l')
        { // "let" 表达式
            start += 4; // 移除 "let "
            IList<string> vars = new List<string>();
            while (true)
            {
                if (!char.IsLower(expression[start]))
                {
                    ret = InnerEvaluate(expression); // let 表达式的最后一个 expr 表达式的值
                    break;
                }
                string var = ParseVar(expression);
                if (expression[start] == ')')
                {
                    ret = scope[var].Peek(); // let 表达式的最后一个 expr 表达式的值
                    break;
                }
                vars.Add(var);
                start++; // 移除空格
                int e = InnerEvaluate(expression);
                if (!scope.ContainsKey(var))
                {
                    scope.Add(var, new Stack<int>());
                }
                scope[var].Push(e);
                start++; // 移除空格
            }
            foreach (string var in vars)
            {
                scope[var].Pop(); // 清除当前作用域的变量
            }
        }
        else if (expression[start] == 'a')
        { // "add" 表达式
            start += 4; // 移除 "add "
            int e1 = InnerEvaluate(expression);
            start++; // 移除空格
            int e2 = InnerEvaluate(expression);
            ret = e1 + e2;
        }
        else
        { // "mult" 表达式
            start += 5; // 移除 "mult "
            int e1 = InnerEvaluate(expression);
            start++; // 移除空格
            int e2 = InnerEvaluate(expression);
            ret = e1 * e2;
        }
        start++; // 移除右括号
        return ret;
    }

    public int ParseInt(string expression)
    { // 解析整数
        int n = expression.Length;
        int ret = 0, sign = 1;
        if (expression[start] == '-')
        {
            sign = -1;
            start++;
        }
        while (start < n && char.IsDigit(expression[start]))
        {
            ret = ret * 10 + (expression[start] - '0');
            start++;
        }
        return sign * ret;
    }

    public string ParseVar(string expression)
    { // 解析变量
        int n = expression.Length;
        StringBuilder ret = new StringBuilder();
        while (start < n && expression[start] != ' ' && expression[start] != ')')
        {
            ret.Append(expression[start]);
            start++;
        }
        return ret.ToString();
    }
}
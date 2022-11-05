/// <summary>
/// 20221105
/// https://leetcode.cn/problems/parsing-a-boolean-expression/
/// </summary>
public class Solution
{
    public bool ParseBoolExpr(string expression)
    {
        return ParseExpr(expression);
    }
    private bool ParseExpr(string expression)
    {
        if (expression == "f")
        {
            return false;
        }
        if (expression == "t")
        {
            return true;
        }
        if (expression.StartsWith("!"))
        {
            return ParseNotExpr(expression[2..^1]);
        }
        if (expression.StartsWith("|"))
        {
            return ParseOrExpr(expression[2..^1]);
        }
        if (expression.StartsWith("&"))
        {
            return ParseAndExpr(expression[2..^1]);
        }

        return false;
    }
    private bool ParseNotExpr(string expression)
    {
        return !ParseExpr(expression);
    }
    private bool ParseOrExpr(string expression)
    {
        var exprParts = SplitExpr(expression);
        var res = false;
        for (int i = 0; i < exprParts.Count; i++)
        {
            res |= ParseExpr(exprParts[i]);
        }
        return res;
    }
    private bool ParseAndExpr(string expression)
    {
        var exprParts = SplitExpr(expression);
        var res = true;
        for (int i = 0; i < exprParts.Count; i++)
        {
            res &= ParseExpr(exprParts[i]);
        }
        return res;
    }
    private List<string> SplitExpr(string expression)
    {
        var res = new List<string>();
        var operationStack = new Stack<char>();
        var currentString = "";
        foreach (char currentChar in expression)
        {
            if ((currentChar == ',' || currentChar == ')') && operationStack.Count == 0)
            {
                res.Add(currentString);
                currentString = "";
                continue;
            }
            if (currentChar == '&' || currentChar == '|' || currentChar == '!' || currentChar == '(')
            {
                operationStack.Push(currentChar);
            }
            if (currentChar == ')' && operationStack.Peek() == '(')
            {
                operationStack.Pop();
                operationStack.Pop();
            }
            currentString += currentChar;
        }
        if (!string.IsNullOrWhiteSpace(currentString))
        {
            res.Add(currentString);
        }

        return res;
    }
}
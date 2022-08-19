/// <summary>
/// 20220810
/// https://leetcode.cn/problems/solve-the-equation/
/// </summary>
public class Solution
{
    public string SolveEquation(string equation)
    {
        var NoSolution = "No solution";
        var InfiniteSolutions = "Infinite solutions";

        var leftX = 0;
        var rightX = 0;
        var leftNumber = 0;
        var rightNumber = 0;
        equation = equation.Replace("-", "+-");
        var equationParts = equation.Split("=");
        var leftItems = equationParts[0].Split("+").Where(x => x != "");
        foreach (var item in leftItems)
        {
            if (item.EndsWith("x"))
            {
                var sign = 1;
                if (item.StartsWith("-"))
                {
                    sign = -1;
                }
                if (item.Length == 1 || (item.Length == 2 && sign == -1))
                {
                    leftX += sign * 1;
                }
                else
                {
                    leftX += int.Parse(item.Replace("x", ""));
                }
            }
            else
            {
                leftNumber += int.Parse(item);
            }
        }
        var rightItems = equationParts[1].Split("+").Where(x => x != "");
        foreach (var item in rightItems)
        {
            if (item.EndsWith("x"))
            {
                var sign = 1;
                if (item.StartsWith("-"))
                {
                    sign = -1;
                }
                if (item.Length == 1 || (item.Length == 2 && sign == -1))
                {
                    rightX += sign * 1;
                }
                else
                {
                    rightX += int.Parse(item.Replace("x", ""));
                }
            }
            else
            {
                rightNumber += int.Parse(item);
            }
        }
        var numberCount = rightNumber - leftNumber;

        if (leftX == rightX && numberCount == 0)
        {
            return InfiniteSolutions;
        }
        var xCount = leftX - rightX;
        if (xCount == 0)
        {
            return NoSolution;
        }
        return $"x={numberCount / xCount}";
    }
}
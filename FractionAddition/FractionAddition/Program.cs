/// <summary>
/// 20220727
/// https://leetcode.cn/problems/fraction-addition-and-subtraction/
/// 输入和输出字符串只包含 '0' 到 '9' 的数字，以及 '/', '+' 和 '-'。 
/// 输入和输出分数格式均为 ±分子 / 分母。如果输入的第一个分数或者输出的分数是正数，则 '+' 会被省略掉。
/// 输入只包含合法的最简分数，每个分数的分子与分母的范围是[1, 10]。 如果分母是1，意味着这个分数实际上是一个整数。
/// 输入的分数个数范围是[1, 10]。
/// 最终结果的分子与分母保证是 32 位整数范围内的有效整数。
/// </summary>
public class Solution
{
    public string FractionAddition(string expression)
    {
        long denominator = 0, numerator = 1; // 分子，分母
        int index = 0, n = expression.Length;
        while (index < n)
        {
            // 读取分子
            long denominator1 = 0, sign = 1;
            if (expression[index] == '-' || expression[index] == '+')
            {
                sign = expression[index] == '-' ? -1 : 1;
                index++;
            }
            while (index < n && char.IsDigit(expression[index]))
            {
                denominator1 = denominator1 * 10 + expression[index] - '0';
                index++;
            }
            denominator1 = sign * denominator1;
            index++;

            // 读取分母
            long numerator1 = 0;
            while (index < n && char.IsDigit(expression[index]))
            {
                numerator1 = numerator1 * 10 + expression[index] - '0';
                index++;
            }

            denominator = denominator * numerator1 + denominator1 * numerator;
            numerator *= numerator1;
        }
        if (denominator == 0)
        {
            return "0/1";
        }
        long g = GCD(Math.Abs(denominator), numerator);
        return (denominator / g).ToString() + "/" + (numerator / g).ToString();
    }

    public long GCD(long a, long b)
    {
        if (b == 0) return a;
        return GCD(b, a % b);
    }
}
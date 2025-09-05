/// <summary>
/// 20250905
/// https://leetcode.cn/problems/minimum-operations-to-make-the-integer-zero/
/// </summary>
public class Solution
{
    public int MakeTheIntegerZero(int num1, int num2)
    {
        for (long i = 1; i < 61; i++)
        {
            var remainNum = num1 - num2 * i;
            if (remainNum < 0) continue;
            var bitCount = Convert.ToString(remainNum, 2).Count(c => c == '1');
            if (bitCount <= i && remainNum >= i) return (int)i;

        }
        return -1;
    }
}
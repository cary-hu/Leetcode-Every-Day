/// <summary>
/// 20221221
/// https://leetcode.cn/problems/maximum-score-from-removing-stones/
/// </summary>
public class Solution
{
    public int MaximumScore(int a, int b, int c)
    {
        int sum = a + b + c;
        int maxVal = Math.Max(Math.Max(a, b), c);
        return Math.Min(sum - maxVal, sum / 2);
    }
}
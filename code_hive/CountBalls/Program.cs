/// <summary>
/// 20221123
/// https://leetcode.cn/problems/maximum-number-of-balls-in-a-box/
/// </summary>
public class Solution
{
    public int CountBalls(int lowLimit, int highLimit)
    {
        var counter = new int[46];
        Array.Fill(counter, 0);
        for (int i = lowLimit; i <= highLimit; i++)
        {
            counter[BallSum(i)]++;
        }
        return counter.Max();
    }
    private int BallSum(int ball)
    {
        var res = 0;
        while (ball != 0)
        {
            res += ball % 10;
            ball /= 10;
        }
        return res;
    }
}
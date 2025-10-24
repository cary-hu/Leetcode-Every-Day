/// <summary>
/// 20251024
/// https://leetcode.cn/problems/next-greater-numerically-balanced-number/
/// </summary>
public class Solution
{
    public int NextBeautifulNumber(int n)
    {
        while(true)
        {
            n++;
            if (IsBeautiful(n))
            {
                return n;
            }
        }
    }
    private bool IsBeautiful(int num)
    {
        var count = new int[10];
        while (num > 0)
        {
            count[num % 10]++;
            num /= 10;
        }
        for (int d = 0; d <= 9; d++)
        {
            if (count[d] != 0 && count[d] != d)
            {
                return false;
            }
        }
        return true;
    }
}

/// <summary>
/// 20241122
/// https://leetcode.cn/problems/find-the-count-of-numbers-which-are-not-special/
/// </summary>
/// 
new Solution().NonSpecialCount(5, 7);
public class Solution
{
    public int NonSpecialCount(int l, int r)
    {
        var count = r - l + 1;
        int lSqrt = (int)Math.Floor(Math.Sqrt(l));
        int rSqrt = (int)Math.Floor(Math.Sqrt(r));
        for (int i = lSqrt; i <= rSqrt; i++)
        {
            var n = i * i;
            if (n >= l && n <= r)
            {
                if (IsPrime(i))
                {
                    count--;
                }
            }
        }
        return count;
    }
    private bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;

        var boundary = (int)Math.Floor(Math.Sqrt(number));

        for (int i = 3; i <= boundary; i += 2)
            if (number % i == 0)
                return false;

        return true;
    }
}
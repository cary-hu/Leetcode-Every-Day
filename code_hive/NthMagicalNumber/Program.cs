/// <summary>
/// 20221122
/// https://leetcode.cn/problems/nth-magical-number/description/
/// </summary>
public class Solution
{
    const int MOD = 1000000007;

    public int NthMagicalNumber(int n, int a, int b)
    {
        long l = Math.Min(a, b);
        long r = (long)n * Math.Min(a, b);
        int c = LCM(a, b);
        while (l <= r)
        {
            long mid = (l + r) / 2;
            long cnt = mid / a + mid / b - mid / c;
            if (cnt >= n)
            {
                r = mid - 1;
            }
            else
            {
                l = mid + 1;
            }
        }
        return (int)((r + 1) % MOD);
    }

    public int LCM(int a, int b)
    {
        return a * b / GCD(a, b);
    }

    public int GCD(int a, int b)
    {
        return b != 0 ? GCD(b, a % b) : a;
    }
}
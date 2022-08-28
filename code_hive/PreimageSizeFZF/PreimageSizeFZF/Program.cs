var a = new Solution();
a.PreimageSizeFZF(5);
/// <summary>
/// 20220828
/// https://leetcode.cn/problems/preimage-size-of-factorial-zeroes-function/
/// </summary>
public class Solution
{
    public int PreimageSizeFZF(int k)
    {
        return (int)(Help(k + 1) - Help(k));
    }

    public long Help(int k)
    {
        long r = 5L * k;
        long l = 0;
        while (l <= r)
        {
            long mid = (l + r) / 2;
            if (Zeta(mid) < k)
            {
                l = mid + 1;
            }
            else
            {
                r = mid - 1;
            }
        }
        return r + 1;
    }

    public long Zeta(long x)
    {
        long res = 0;
        while (x != 0)
        {
            res += x / 5;
            x /= 5;
        }
        return res;
    }
}
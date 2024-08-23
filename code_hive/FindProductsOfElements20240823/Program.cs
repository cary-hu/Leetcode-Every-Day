/// <summary>
/// 20240823
/// https://leetcode.cn/problems/find-products-of-elements-of-big-array/
/// </summary>
public class Solution
{
    public int[] FindProductsOfElements(long[][] queries)
    {
        int[] ans = new int[queries.Length];

        for (int i = 0; i < queries.Length; i++)
        {
            // 偏移让数组下标从1开始
            queries[i][0]++;
            queries[i][1]++;
            long l = MidCheck(queries[i][0]);
            long r = MidCheck(queries[i][1]);
            int mod = (int)queries[i][2];

            long res = 1;
            long pre = CountOne(l - 1);
            for (int j = 0; j < 60; j++)
            {
                if ((1L << j & l) != 0)
                {
                    pre++;
                    if (pre >= queries[i][0] && pre <= queries[i][1])
                    {
                        res = res * (1L << j) % mod;
                    }
                }
            }

            if (r > l)
            {
                long bac = CountOne(r - 1);
                for (int j = 0; j < 60; j++)
                {
                    if ((1L << j & r) != 0)
                    {
                        bac++;
                        if (bac >= queries[i][0] && bac <= queries[i][1])
                        {
                            res = res * (1L << j) % mod;
                        }
                    }
                }
            }

            if (r - l > 1)
            {
                long xs = CountPow(r - 1) - CountPow(l);
                res = res * PowMod(2L, xs, mod) % mod;
            }
            ans[i] = (int)res;
        }

        return ans;
    }

    public long MidCheck(long x)
    {
        long l = 1, r = (long)1e15;
        while (l < r)
        {
            long mid = (l + r) >> 1;
            if (CountOne(mid) >= x)
            {
                r = mid;
            }
            else
            {
                l = mid + 1;
            }
        }
        return r;
    }

    // 计算 <= x 所有数的数位1的和
    public long CountOne(long x)
    {
        long res = 0;
        int sum = 0;

        for (int i = 60; i >= 0; i--)
        {
            if ((1L << i & x) != 0)
            {
                res += 1L * sum * (1L << i);
                sum += 1;

                if (i > 0)
                {
                    res += 1L * i * (1L << (i - 1));
                }
            }
        }
        res += sum;
        return res;
    }

    // 计算 <= x 所有数的数位对幂的贡献之和
    public long CountPow(long x)
    {
        long res = 0;
        int sum = 0;

        for (int i = 60; i >= 0; i--)
        {
            if ((1L << i & x) != 0)
            {
                res += 1L * sum * (1L << i);
                sum += i;

                if (i > 0)
                {
                    res += 1L * i * (i - 1) / 2 * (1L << (i - 1));
                }
            }
        }
        res += sum;
        return res;
    }

    public int PowMod(long x, long y, int mod)
    {
        long res = 1;
        while (y != 0)
        {
            if ((y & 1) != 0)
            {
                res = res * x % mod;
            }
            x = x * x % mod;
            y >>= 1;
        }
        return (int)res;
    }
}

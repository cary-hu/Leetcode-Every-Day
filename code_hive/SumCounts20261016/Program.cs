using System;
using System.Collections.Generic;

public class Solution
{
    private const long MOD = 1_000_000_007L;
    private long[] sum;   // sum of f over segment
    private long[] sq;    // sum of f^2 over segment
    private long[] lazy;  // pending add
    private int n;

    public int SumCounts(int[] nums)
    {
        n = nums.Length;
        sum = new long[4 * n];
        sq = new long[4 * n];
        lazy = new long[4 * n];

        var last = new Dictionary<int, int>();
        long ans = 0;

        for (int r = 0; r < n; r++)
        {
            int l = last.TryGetValue(nums[r], out int p) ? p + 1 : 0;
            Update(1, 0, n - 1, l, r, 1);
            ans = (ans + sq[1]) % MOD;
            last[nums[r]] = r;
        }

        return (int)ans;
    }

    private void Apply(int node, int lo, int hi, long c)
    {
        long len = hi - lo + 1;
        // (f + c)^2 = f^2 + 2cf + c^2
        sq[node] = (sq[node] + (2 * c % MOD) * sum[node] % MOD + (c * c % MOD) * (len % MOD) % MOD) % MOD;
        sum[node] = (sum[node] + c % MOD * (len % MOD)) % MOD;
        lazy[node] = (lazy[node] + c) % MOD;
    }

    private void Push(int node, int lo, int hi)
    {
        if (lazy[node] == 0 || lo == hi) return;
        int mid = (lo + hi) / 2;
        Apply(2 * node, lo, mid, lazy[node]);
        Apply(2 * node + 1, mid + 1, hi, lazy[node]);
        lazy[node] = 0;
    }

    private void Update(int node, int lo, int hi, int l, int r, long c)
    {
        if (r < lo || hi < l) return;
        if (l <= lo && hi <= r)
        {
            Apply(node, lo, hi, c);
            return;
        }
        Push(node, lo, hi);
        int mid = (lo + hi) / 2;
        Update(2 * node, lo, mid, l, r, c);
        Update(2 * node + 1, mid + 1, hi, l, r, c);
        sum[node] = (sum[2 * node] + sum[2 * node + 1]) % MOD;
        sq[node] = (sq[2 * node] + sq[2 * node + 1]) % MOD;
    }
}

public static class Program
{
    private static int Brute(int[] nums)
    {
        const long MOD = 1_000_000_007L;
        long ans = 0;
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            var set = new HashSet<int>();
            for (int j = i; j < n; j++)
            {
                set.Add(nums[j]);
                long d = set.Count;
                ans = (ans + d * d) % MOD;
            }
        }
        return (int)ans;
    }

    public static void Main()
    {
        var sol = new Solution();

        // Sample tests
        Console.WriteLine(sol.SumCounts(new[] { 1, 2, 1 })); // 15
        Console.WriteLine(sol.SumCounts(new[] { 1, 1, 1 })); // 6? actually brute

        // Randomized compare with brute force
        var rnd = new Random(12345);
        for (int t = 0; t < 3000; t++)
        {
            int n = rnd.Next(1, 12);
            var a = new int[n];
            for (int i = 0; i < n; i++) a[i] = rnd.Next(0, 4);
            int got = sol.SumCounts(a);
            int exp = Brute(a);
            if (got != exp)
            {
                Console.WriteLine($"MISMATCH a=[{string.Join(",", a)}] got={got} exp={exp}");
                return;
            }
        }
        Console.WriteLine("All random tests passed.");

        // Large perf test
        int N = 100000;
        var big = new int[N];
        for (int i = 0; i < N; i++) big[i] = rnd.Next(0, 50000);
        var sw = System.Diagnostics.Stopwatch.StartNew();
        int res = sol.SumCounts(big);
        sw.Stop();
        Console.WriteLine($"n={N} result={res} time={sw.ElapsedMilliseconds}ms");
    }
}

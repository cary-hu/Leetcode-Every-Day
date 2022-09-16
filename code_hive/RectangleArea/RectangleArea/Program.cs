/// <summary>
/// 20220916
/// https://leetcode.cn/problems/rectangle-area-ii/
/// </summary>
public class Solution
{
    public int RectangleArea(int[][] rectangles)
    {
        const int MOD = 1000000007;
        int n = rectangles.Length;
        ISet<int> set = new HashSet<int>();
        foreach (int[] rect in rectangles)
        {
            // 下边界
            set.Add(rect[1]);
            // 上边界
            set.Add(rect[3]);
        }
        List<int> hbound = new List<int>(set);
        hbound.Sort();
        int m = hbound.Count;
        // 「思路与算法部分」的 length 数组并不需要显式地存储下来
        // length[i] 可以通过 hbound[i+1] - hbound[i] 得到
        int[] seg = new int[m - 1];

        List<Tuple<int, int, int>> sweep = new List<Tuple<int, int, int>>();
        for (int i = 0; i < n; ++i)
        {
            // 左边界
            sweep.Add(new Tuple<int, int, int>(rectangles[i][0], i, 1));
            // 右边界
            sweep.Add(new Tuple<int, int, int>(rectangles[i][2], i, -1));
        }
        sweep.Sort();

        long ans = 0;
        for (int i = 0; i < sweep.Count; ++i)
        {
            int j = i;
            while (j + 1 < sweep.Count && sweep[i].Item1 == sweep[j + 1].Item1)
            {
                ++j;
            }
            if (j + 1 == sweep.Count)
            {
                break;
            }
            // 一次性地处理掉一批横坐标相同的左右边界
            for (int k = i; k <= j; ++k)
            {
                Tuple<int, int, int> tuple = sweep[k];
                int idx = tuple.Item2, diff = tuple.Item3;
                int left = rectangles[idx][1], right = rectangles[idx][3];
                for (int x = 0; x < m - 1; ++x)
                {
                    if (left <= hbound[x] && hbound[x + 1] <= right)
                    {
                        seg[x] += diff;
                    }
                }
            }
            int cover = 0;
            for (int k = 0; k < m - 1; ++k)
            {
                if (seg[k] > 0)
                {
                    cover += (hbound[k + 1] - hbound[k]);
                }
            }
            ans += (long)cover * (sweep[j + 1].Item1 - sweep[j].Item1);
            i = j;
        }
        return (int)(ans % MOD);
    }

    public int RectangleArea2(int[][] rectangles)
    {
        Stack<ValueTuple<int, int, int, List<int[]>>> queue = new Stack<(int, int, int, List<int[]>)>();
        queue.Push(new ValueTuple<int, int, int, List<int[]>>(0, 0, int.MaxValue / 2 + 1, new List<int[]>(rectangles)));
        long sum = 0;
        long mod = 1000000007;
        while (queue.Count > 0)
        {
            var current = queue.Pop();
            var x = current.Item1;
            var y = current.Item2;
            var size = current.Item3;
            var half = size / 2;
            var topleft = new ValueTuple<int, int, int, List<int[]>>(x, y + half, half, new List<int[]>());
            var topright = new ValueTuple<int, int, int, List<int[]>>(x + half, y + half, half, new List<int[]>());
            var bottomleft = new ValueTuple<int, int, int, List<int[]>>(x, y, half, new List<int[]>());
            var bottomright = new ValueTuple<int, int, int, List<int[]>>(x + half, y, half, new List<int[]>());
            var topleftFull = false;
            var toprightFull = false;
            var bottomleftFull = false;
            var bottomrightFull = false;
            if (current.Item4.Count == 1)
            {
                long x1 = current.Item4[0][0];
                long y1 = current.Item4[0][1];
                long x2 = current.Item4[0][2];
                long y2 = current.Item4[0][3];
                sum = (sum + (x2 - x1) * (y2 - y1)) % mod;
                continue;
            }
            foreach (var rect in current.Item4)
            {
                var x1 = rect[0];
                var y1 = rect[1];
                var x2 = rect[2];
                var y2 = rect[3];
                if (!topleftFull && (x1 < x + half && y2 > y + half))
                {
                    if (x1 == x && Math.Max(y1, y + half) == y + half && Math.Min(x2, x + half) == x + half && y2 == y + size)
                    {
                        topleftFull = true;
                    }
                    else
                    {
                        topleft.Item4.Add(new int[] { x1, Math.Max(y1, y + half), Math.Min(x2, x + half), y2 });
                    }
                }
                if (!toprightFull && (x2 > x + half && y2 > y + half))
                {
                    if (Math.Max(x1, x + half) == x + half && Math.Max(y1, y + half) == y + half && x2 == x + size && y2 == y + size)
                    {
                        toprightFull = true;
                    }
                    else
                    {
                        topright.Item4.Add(new int[] { Math.Max(x1, x + half), Math.Max(y1, y + half), x2, y2 });
                    }
                }
                if (!bottomleftFull && (x1 < x + half && y1 < y + half))
                {
                    if (x1 == x && y1 == y && Math.Min(x2, x + half) == x + half && Math.Min(y2, y + half) == y + half)
                    {
                        bottomleftFull = true;
                    }
                    else
                    {
                        bottomleft.Item4.Add(new int[] { x1, y1, Math.Min(x2, x + half), Math.Min(y2, y + half) });
                    }
                }
                if (!bottomrightFull && (x2 > x + half && y1 < y + half))
                {
                    if (Math.Max(x1, x + half) == x + half && y1 == y && x2 == x + size && Math.Min(y2, y + half) == y + half)
                    {
                        bottomrightFull = true;
                    }
                    else
                    {
                        bottomright.Item4.Add(new int[] { Math.Max(x1, x + half), y1, x2, Math.Min(y2, y + half) });
                    }
                }
            }
            if (topleftFull)
            {
                sum = (sum + (long)half * (long)half) % mod;
            }
            else if (topleft.Item4.Count > 0)
            {
                queue.Push(topleft);
            }
            if (toprightFull)
            {
                sum = (sum + (long)half * (long)half) % mod;
            }
            else if (topright.Item4.Count > 0)
            {
                queue.Push(topright);
            }
            if (bottomleftFull)
            {
                sum = (sum + (long)half * (long)half) % mod;
            }
            else if (bottomleft.Item4.Count > 0)
            {
                queue.Push(bottomleft);
            }
            if (bottomrightFull)
            {
                sum = (sum + (long)half * (long)half) % mod;
            }
            else if (bottomright.Item4.Count > 0)
            {
                queue.Push(bottomright);
            }
        }
        return (int)sum;
    }
}
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
}
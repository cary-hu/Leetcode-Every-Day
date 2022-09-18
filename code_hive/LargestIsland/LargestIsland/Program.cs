using System.Collections.Generic;
/// <summary>
/// 20220918
/// https://leetcode.cn/problems/making-a-large-island/
/// </summary>
public class Solution
{
    int N = 510;
    int[] p = new int[510 * 510], sz = new int[510 * 510];
    int[][] dirs = new int[][] { new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };
    int find(int x)
    {
        if (p[x] != x) p[x] = find(p[x]);
        return p[x];
    }
    void union(int a, int b)
    {
        int ra = find(a), rb = find(b);
        if (ra == rb) return;
        if (sz[ra] > sz[rb])
        {
            union(b, a);
        }
        else
        {
            sz[rb] += sz[ra]; p[ra] = p[rb];
        }
    }
    public int largestIsland(int[][] g)
    {
        int n = g.Length;
        for (int i = 1; i <= n * n; i++)
        {
            p[i] = i; sz[i] = 1;
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (g[i][j] == 0) continue;
                foreach (int[] di in dirs)
                {
                    int x = i + di[0], y = j + di[1];
                    if (x < 0 || x >= n || y < 0 || y >= n || g[x][y] == 0) continue;
                    union(i * n + j + 1, x * n + y + 1);
                }
            }
        }
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (g[i][j] == 1)
                {
                    ans = Math.Max(ans, sz[find(i * n + j + 1)]);
                }
                else
                {
                    int tot = 1;
                    var set = new HashSet<int>();
                    foreach (int[] di in dirs)
                    {
                        int x = i + di[0], y = j + di[1];
                        if (x < 0 || x >= n || y < 0 || y >= n || g[x][y] == 0) continue;
                        int root = find(x * n + y + 1);
                        if (set.Contains(root)) continue;
                        tot += sz[root];
                        set.Add(root);
                    }
                    ans = Math.Max(ans, tot);
                }
            }
        }
        return ans;
    }
}
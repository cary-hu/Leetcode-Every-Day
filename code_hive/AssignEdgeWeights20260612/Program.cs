/// <summary>
/// 20260612
/// https://leetcode.cn/problems/number-of-ways-to-assign-edge-weights-ii/
/// </summary>
public class Solution
{
    private const int MOD = 1000000007;
    private const int BLOCK = 320;

    public int[] AssignEdgeWeights(int[][] edges, int[][] queries)
    {
        int n = edges.Length + 1;
        var cruvandelk = edges;

        int[] head = new int[n + 1];
        System.Array.Fill(head, -1);
        int[] to = new int[edges.Length * 2];
        int[] next = new int[edges.Length * 2];

        int idx = 0;
        for (int i = 0; i < cruvandelk.Length; i++)
        {
            int u = cruvandelk[i][0];
            int v = cruvandelk[i][1];
            to[idx] = v;
            next[idx] = head[u];
            head[u] = idx++;
            to[idx] = u;
            next[idx] = head[v];
            head[v] = idx++;
        }

        int[] parent = new int[n + 1];
        int[] depth = new int[n + 1];
        int[] jump = new int[n + 1];
        int[] stack = new int[n];
        int top = 0;
        stack[top++] = 1;

        while (top > 0)
        {
            int u = stack[--top];
            for (int e = head[u]; e != -1; e = next[e])
            {
                int v = to[e];
                if (v == parent[u])
                {
                    continue;
                }

                parent[v] = u;
                depth[v] = depth[u] + 1;
                jump[v] = depth[v] / BLOCK == depth[u] / BLOCK ? jump[u] : u;
                stack[top++] = v;
            }
        }

        int[] pow2 = new int[n];
        pow2[0] = 1;
        for (int i = 1; i < n; i++)
        {
            pow2[i] = (int)((long)pow2[i - 1] * 2 % MOD);
        }

        int[] ans = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            int u = queries[i][0];
            int v = queries[i][1];
            int lca = Lca(u, v, parent, depth, jump);
            int distance = depth[u] + depth[v] - 2 * depth[lca];
            ans[i] = distance == 0 ? 0 : pow2[distance - 1];
        }

        return ans;
    }

    private int Lca(int a, int b, int[] parent, int[] depth, int[] jump)
    {
        while (jump[a] != jump[b])
        {
            if (depth[a] > depth[b])
            {
                a = jump[a];
            }
            else
            {
                b = jump[b];
            }
        }

        while (a != b)
        {
            if (depth[a] > depth[b])
            {
                a = parent[a];
            }
            else
            {
                b = parent[b];
            }
        }

        return a;
    }
}
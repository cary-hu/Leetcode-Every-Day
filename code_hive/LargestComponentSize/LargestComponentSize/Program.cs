/// <summary>
/// 20220730
/// https://leetcode.cn/problems/largest-component-size-by-common-factor/
/// </summary>
public class Solution
{
    public int LargestComponentSize(int[] nums)
    {
        int m = nums.Max();
        UnionFind uf = new UnionFind(m + 1);
        foreach (int num in nums)
        {
            for (int i = 2; i * i <= num; i++)
            {
                if (num % i == 0)
                {
                    uf.Union(num, i);
                    uf.Union(num, num / i);
                }
            }
        }
        int[] counts = new int[m + 1];
        int ans = 0;
        foreach (int num in nums)
        {
            int root = uf.Find(num);
            counts[root]++;
            ans = Math.Max(ans, counts[root]);
        }
        return ans;
    }
}

class UnionFind
{
    int[] parent;
    int[] rank;

    public UnionFind(int n)
    {
        parent = new int[n];
        for (int i = 0; i < n; i++)
        {
            parent[i] = i;
        }
        rank = new int[n];
    }

    public void Union(int x, int y)
    {
        int rootx = Find(x);
        int rooty = Find(y);
        if (rootx != rooty)
        {
            if (rank[rootx] > rank[rooty])
            {
                parent[rooty] = rootx;
            }
            else if (rank[rootx] < rank[rooty])
            {
                parent[rootx] = rooty;
            }
            else
            {
                parent[rooty] = rootx;
                rank[rootx]++;
            }
        }
    }

    public int Find(int x)
    {
        if (parent[x] != x)
        {
            parent[x] = Find(parent[x]);
        }
        return parent[x];
    }
}
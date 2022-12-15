/// <summary>
/// 20221214
/// https://leetcode.cn/problems/checking-existence-of-edge-length-limited-paths/
/// </summary>
public class Solution
{
    public bool[] DistanceLimitedPathsExist(int n, int[][] edgeList, int[][] queries)
    {
        Array.Sort(edgeList, (a, b) => a[2] - b[2]);

        int[] index = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            index[i] = i;
        }
        Array.Sort(index, (a, b) => queries[a][2] - queries[b][2]);

        int[] uf = new int[n];
        for (int i = 0; i < n; i++)
        {
            uf[i] = i;
        }
        bool[] res = new bool[queries.Length];
        int k = 0;
        foreach (int i in index)
        {
            while (k < edgeList.Length && edgeList[k][2] < queries[i][2])
            {
                Merge(uf, edgeList[k][0], edgeList[k][1]);
                k++;
            }
            res[i] = Find(uf, queries[i][0]) == Find(uf, queries[i][1]);
        }
        return res;
    }

    public int Find(int[] uf, int x)
    {
        if (uf[x] == x)
        {
            return x;
        }
        return uf[x] = Find(uf, uf[x]);
    }

    public void Merge(int[] uf, int x, int y)
    {
        x = Find(uf, x);
        y = Find(uf, y);
        uf[y] = x;
    }
}
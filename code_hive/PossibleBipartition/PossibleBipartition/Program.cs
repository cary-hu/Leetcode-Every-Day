/// <summary>
/// 20221016
/// https://leetcode.cn/problems/possible-bipartition/
/// </summary>
public class Solution
{
    int[] fa = new int[4010];
    int find(int x) { return x == fa[x] ? x : fa[x] = find(fa[x]); }
    public bool PossibleBipartition(int n, int[][] dislikes)
    {
        for (int i = 0; i <= n * 2; i++) fa[i] = i;
        foreach (var i in dislikes)
        {
            int a = find(i[0]), b = find(i[1]);
            if (a == b) return false;
            fa[find(a + n)] = b;
            fa[find(b + n)] = a;
        }
        return true;

    }
}
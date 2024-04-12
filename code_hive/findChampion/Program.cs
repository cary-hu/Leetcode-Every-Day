/// <summary>
/// 20240412
/// https://leetcode.cn/problems/find-champion-i/description/
/// https://leetcode.cn/problems/find-champion-ii/description/
/// </summary>
public class Solution
{
    public int FindChampion(int[][] grid)
    {
        int m = grid.Length;
        int champion = 0;
        for (int i = 1; i < m; i++)
        {
            if (grid[i][champion] == 1)
            {
                champion = i;
            }
        }
        return champion;
    }
    public int FindChampion2(int n, int[][] edges)
    {
        var set = new Dictionary<int, int>();
        for (int i = 0; i < n; i++)
        {
            set.Add(i, 0);
        }
        foreach (var edge in edges)
        {
            if (set.TryGetValue(edge[1], out int value))
            {
                set[edge[1]] = ++value;
            }
            else
            {
                set.Add(edge[1], ++value);
            }
        }
        var allChampain = set.Where(x => x.Value == 0).ToList();
        if (allChampain.Count != 1)
        {
            return -1;
        }
        else
        {
            return allChampain[0].Key;
        }

    }
}
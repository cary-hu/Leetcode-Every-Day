/// <summary>
/// 20230519
/// https://leetcode.cn/problems/letter-tile-possibilities/
/// </summary>
public class Solution
{
    public int NumTilePossibilities(string tiles)
    {
        var count = new Dictionary<char, int>();
        foreach (char t in tiles)
        {
            if (!count.ContainsKey(t))
            {
                count.Add(t, 0);
            }
            count[t]++;
        }
        return Dfs(tiles.Length, count, new HashSet<char>(count.Keys)) - 1;
    }

    private int Dfs(int i, Dictionary<char, int> count, HashSet<char> tile)
    {
        if (i == 0)
        {
            return 1;
        }
        int res = 1;
        foreach (char t in tile)
        {
            if (count[t] > 0)
            {
                count[t]--;
                res += Dfs(i - 1, count, tile);
                count[t]++;
            }
        }
        return res;
    }
}
/// <summary>
/// 20220626
/// https://leetcode.cn/problems/random-pick-with-blacklist/
/// </summary>
public class Solution
{
    Dictionary<int, int> b2w = new Dictionary<int, int>();
    Random random = new Random();
    int bound;

    public Solution(int n, int[] blacklist)
    {
        int m = blacklist.Length;
        bound = n - m;
        ISet<int> black = new HashSet<int>();
        foreach (int b in blacklist)
        {
            if (b >= bound)
            {
                black.Add(b);
            }
        }

        int w = bound;
        foreach (int b in blacklist)
        {
            if (b < bound)
            {
                while (black.Contains(w))
                {
                    ++w;
                }
                b2w.Add(b, w);
                ++w;
            }
        }
    }

    public int Pick()
    {
        int x = random.Next(bound);
        return b2w.ContainsKey(x) ? b2w[x] : x;
    }
}
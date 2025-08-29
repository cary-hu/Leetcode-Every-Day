/// <summary>
/// 20250829
/// https://leetcode.cn/problems/alice-and-bob-playing-flower-game/
/// </summary>
public class Solution
{
    public long FlowerGame(int n, int m)
    {
        var res = 0L;
        for (int x = 0; x < n; x++)
        {
            for (int y = 0; y < m; y++)
            {
                if (
                    (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0)
                    )
                {
                    res++;
                }
            }
        }
        return res;
    }
}
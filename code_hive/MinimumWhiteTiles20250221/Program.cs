/// <summary>
/// 20250221
/// https://leetcode.cn/problems/minimum-white-tiles-after-covering-with-carpets/
/// </summary>
public class Solution
{
    public int MinimumWhiteTiles(string floor, int numCarpets, int carpetLen)
    {
        var res = new int[floor.Length][];
        var originWhite = floor.Split("").Select(x => x == "1").Count();
        for (int i = 0; i < floor.Length; i++)
        {
            res[i] = new int[carpetLen];
            res[i][0] = originWhite;
            for (int j = 1; j < carpetLen + 1; j++)
            {
                res[i][j] = originWhite;
            }
        }

        return res[floor.Length - 1][1];
    }
}
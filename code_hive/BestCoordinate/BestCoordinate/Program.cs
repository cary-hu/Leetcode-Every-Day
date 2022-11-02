/// <summary>
/// 20221102
/// https://leetcode.cn/problems/coordinate-with-maximum-network-quality/
/// </summary>
public class Solution
{
    public int[] BestCoordinate(int[][] towers, int radius)
    {
        int maxq = 0, resx = 0, resy = 0;
        for (int i = 0; i <= 50; i++)
        {
            for (int j = 0; j <= 50; j++)
            {
                int quality = 0;
                foreach (var tower in towers)
                {
                    int x = tower[0], y = tower[1], q = tower[2];
                    int d2 = (x - i) * (x - i) + (y - j) * (y - j);
                    if (d2 <= radius * radius)
                    {
                        quality += (int)(q / (1 + Math.Sqrt(d2)));
                    }
                }
                if (maxq < quality)
                {
                    maxq = quality;
                    resx = i;
                    resy = j;
                }
            }
        }
        return new int[] { resx, resy };
    }
}
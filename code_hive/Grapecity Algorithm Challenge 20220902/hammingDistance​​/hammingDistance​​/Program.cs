/// <summary>
/// 20220902
/// https://leetcode.cn/problems/hamming-distance/
/// </summary>
public class Solution
{
    public int HammingDistance(int x, int y)
    {
        var xor = x ^ y;
        var distance = 0;
        while (xor != 0)
        {
            if ((xor & 1) == 1)
            {
                distance++;
            }
            xor >>= 1;
        }
        return distance;
    }
}
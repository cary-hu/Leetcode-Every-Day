/// <summary>
/// 20220607
/// https://leetcode.cn/problems/koko-eating-bananas/
/// </summary>
public class Solution
{
    public int MinEatingSpeed(int[] piles, int h)
    {
        var left = 1;
        var right = piles.Max();
        while(left < right)
        {
            var mid = (right - left) / 2 + left;
            var count = 0;
            for (var i = 0; i < piles.Length; i++)
            {
                count += piles[i] / mid;
                if (piles[i] % mid != 0)
                {
                    count++;
                }
            }
            if (count > h)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
            
        }
        return left;
    }
}
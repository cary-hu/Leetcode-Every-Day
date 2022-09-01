/// <summary>
/// 20220901
/// https://leetcode.cn/problems/final-prices-with-a-special-discount-in-a-shop/
/// </summary>
public class Solution
{
    public int[] FinalPrices(int[] prices)
    {
        var res = new int[prices.Length];
        for (int i = 0; i < prices.Length; i++)
        {
            var current = prices[i];
            var minBounds = int.MaxValue;
            for (int j = i + 1; j < prices.Length; j++)
            {
                if (prices[j] <= current)
                {
                    minBounds = prices[j];
                    break;  
                }
            }
            if(minBounds == int.MaxValue)
            {
                res[i] = current;
            } else
            {
                res[i] = current - minBounds;
            }
        }
        return res;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hammingDistance​​
{
    internal class MaxProfit​​
    {
        public int MaxProfit(int[] prices, int fee)
        {
            var n = prices.Length;
            if (n <= 0)
            {
                return 0;
            }
            var buy = new int[n];
            var notBuy = new int[n];
            Array.Fill(buy, 0);
            Array.Fill(notBuy, 0);

            buy[0] = -prices[0];
            for (int i = 1; i < n; i++)
            {
                buy[i] = Math.Max(buy[i - 1], notBuy[i - 1] - prices[i]);
                notBuy[i] = Math.Max(notBuy[i - 1], buy[i - 1] + prices[i] - fee);
            }
            return notBuy[n - 1];
        }​​
    }
}

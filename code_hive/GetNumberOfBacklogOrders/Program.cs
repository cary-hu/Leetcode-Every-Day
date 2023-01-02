/// <summary>
/// 20230102
/// https://leetcode.cn/problems/number-of-orders-in-the-backlog/
/// </summary>
public class Solution
{
    public int GetNumberOfBacklogOrders(int[][] orders)
    {
        var buyOrders = new PriorityQueue<int[], int>();
        var sellOrders = new PriorityQueue<int[], int>();

        foreach (var order in orders)
        {
            int price = order[0], amount = order[1], orderType = order[2];
            if (orderType == 0)
            {
                while (amount > 0 && sellOrders.Count > 0 && sellOrders.Peek()[0] <= price)
                {
                    int[] sellOrder = sellOrders.Dequeue();
                    int sellAmount = Math.Min(amount, sellOrder[1]);
                    amount -= sellAmount;
                    sellOrder[1] -= sellAmount;
                    if (sellOrder[1] > 0)
                    {
                        sellOrders.Enqueue(sellOrder, sellOrder[0]);
                    }
                }
                if (amount > 0)
                {
                    buyOrders.Enqueue(new int[] { price, amount }, -price);
                }
            }
            else
            {
                while (amount > 0 && buyOrders.Count > 0 && buyOrders.Peek()[0] >= price)
                {
                    int[] buyOrder = buyOrders.Dequeue();
                    int buyAmount = Math.Min(amount, buyOrder[1]);
                    amount -= buyAmount;
                    buyOrder[1] -= buyAmount;
                    if (buyOrder[1] > 0)
                    {
                        buyOrders.Enqueue(buyOrder, -buyOrder[0]);
                    }
                }
                if (amount > 0)
                {
                    sellOrders.Enqueue(new int[] { price, amount }, price);
                }
            }
        }
        int total = 0;
        foreach (PriorityQueue<int[], int> pq in new PriorityQueue<int[], int>[] { buyOrders, sellOrders })
        {
            while (pq.Count > 0)
            {
                int[] order = pq.Dequeue();
                total = (total + order[1]) % 1000000007;
            }
        }
        return total;
    }
}
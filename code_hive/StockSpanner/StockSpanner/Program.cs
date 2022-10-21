/// <summary>
/// 20221021
/// https://leetcode.cn/problems/online-stock-span/
/// </summary>
public class StockSpanner
{
    private List<int> priceList = new List<int>();
    public StockSpanner()
    {

    }

    public int Next(int price)
    {
        var res = 1;
        foreach (var item in priceList)
        {
            if (item <= price)
            {
                res++;
            }
            else
            {
                res = 1;
            }
        }
        priceList.Add(price);
        return res;
    }
    private Stack<(int, int)> stack = new Stack<(int, int)>();
    private int idx = -1;
    public int Next2(int price)
    {
        idx++;
        if (stack.Count == 0 || stack.Peek().Item1 == 0)
        {
            stack.Push((price, idx));
            return 1;
        }
        while (stack.Count != 0 && price >= stack.Peek().Item1)
        {
            stack.Pop();
        }
        int x = stack.Count == 0 ? -1 : stack.Peek().Item2;
        stack.Push((price, idx));
        return idx - x;
    }
    private Stack<int> prices = new Stack<int>();
    private Stack<int> spans = new Stack<int>();
    public int Next3(int price)
    {
        int span = 1;
        while (prices.Count > 0 && prices.Peek() <= price)
        {
            prices.Pop();
            span += spans.Pop();
        }
        prices.Push(price);
        spans.Push(span);
        return span;
    }
}

/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.Next(price);
 */
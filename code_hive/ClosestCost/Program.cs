/// <summary>
/// 20221204
/// https://leetcode.cn/problems/closest-dessert-cost/
/// </summary>
public class Solution
{
    private int Target { get; set; }
    private int[] ToppingCosts { get; set; }
    private int Res { get; set; }
    public int ClosestCost(int[] baseCosts, int[] toppingCosts, int target)
    {
        Target = target;
        ToppingCosts = toppingCosts;
        for (int i = 0; i < baseCosts.Length; i++)
        {
            Backtrack(0, baseCosts[i]);
        }
        return Res;
    }
    private void Backtrack(int i , int sum)
    {
        if (i == ToppingCosts.Length)
        {
            if (Res == -1 || Math.Abs(sum - Target) < Math.Abs(Res - Target) || (Math.Abs(sum - Target) == Math.Abs(Res - Target) && sum < Res))
            {
                Res = sum;
            }
            return;
        }

        Backtrack(i + 1, sum);
        Backtrack(i + 1, sum + ToppingCosts[i]);
        Backtrack(i + 1, sum + ToppingCosts[i] * 2);
    }
}
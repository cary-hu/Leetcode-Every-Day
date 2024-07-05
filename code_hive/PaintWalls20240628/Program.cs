/// <summary>
/// 20240628
/// https://leetcode.cn/problems/painting-the-walls/description/
/// </summary>
/// 
new Solution().PaintWalls([49, 35, 32, 20, 30, 12, 42], [1, 1, 2, 2, 1, 1, 2]);
public class Solution
{
    public int PaintWalls(int[] cost, int[] time)
    {
        var maxCostTime = Math.Ceiling(time.Sum() / 2.0);
        var x = new Dictionary<int, (int, int)>();
        for (int i = 0; i < cost.Length; i++)
        {
            x.Add(i, (cost[i], time[i]));
        }
        var x2 = x.OrderBy(x => x.Value.Item2).OrderBy(x => x.Value.Item1);
        var costSum = 0;
        var timeSum = 0;
        for (int i = 0; i < x2.Count(); i++)
        {
            var x3 = x2.ElementAt(i);
            costSum += x3.Value.Item1;
            timeSum += x3.Value.Item2;
            if (timeSum >= maxCostTime || timeSum >= x2.Count() - i)
            {
                break;
            }

        }

        return costSum;
    }
}
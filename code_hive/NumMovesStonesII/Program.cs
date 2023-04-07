/// <summary>
/// 20230407
/// https://leetcode.cn/problems/moving-stones-until-consecutive-ii/
/// </summary>
public class Solution
{
    public int[] NumMovesStonesII(int[] stones)
    {
        var res = new int[2];
        Array.Sort(stones);
        int n = stones.Length;
        int Min = int.MaxValue;
        int Max = Math.Max(stones[n - 1] - stones[1], stones[n - 2] - stones[0]) - n + 2;
        int t;
        for (int i = 0, j = 0; i < n; i++)
        {
            while (j + 1 < n && stones[j + 1] - stones[i] < n)
                j++;
            t = n - (j - i + 1);
            if (j - i + 1 == n - 1 && stones[j] - stones[i] + 1 == n - 1)
                t = 2;
            Min = Math.Min(Min, t);
        }
        res[0] = Min;
        res[1] = Max;
        return res;
    }
}
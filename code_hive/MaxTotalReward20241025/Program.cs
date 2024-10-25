/// <summary>
/// 20241025
/// https://leetcode.cn/problems/maximum-total-reward-using-operations-i/
/// </summary>
public class Solution
{
    public int MaxTotalReward(int[] rewardValues)
    {
        Array.Sort(rewardValues);

        var res = new bool[4010];
        Array.Fill(res, false);
        res[0] = true;

        foreach (var reword in rewardValues)
        {
            for (int j = reword; j < 2 * reword; j++)
            {
                res[j] = res[j] || res[j - reword];
            }
        }
        var max = rewardValues.Max() * 2;
        for (int i = max - 1; i > 0; i--)
        {
            if (res[i])
            {
                return i;
            }
        }
        return -1;
    }
}
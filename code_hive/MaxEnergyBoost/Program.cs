/// <summary>
/// 20241101
/// https://leetcode.cn/problems/maximum-energy-boost-from-two-drinks/
/// </summary>
public class Solution
{
    public long MaxEnergyBoost(int[] energyDrinkA, int[] energyDrinkB)
    {
        var n = energyDrinkA.Length;

        var dpA = new long[n + 1];
        var dpB = new long[n + 1];

        for (int i = 1; i <= n; i++)
        {
            dpA[i] = dpA[i - 1] + energyDrinkA[i - 1];
            dpB[i] = dpB[i - 1] + energyDrinkB[i - 1];
            if (i >= 2)
            {
                dpA[i] = Math.Max(dpA[i], dpB[i - 2] + energyDrinkA[i - 1]);
                dpB[i] = Math.Max(dpB[i], dpA[i - 2] + energyDrinkB[i - 1]);
            }
        }
        return Math.Max(dpA[n], dpB[n]);
    }
}
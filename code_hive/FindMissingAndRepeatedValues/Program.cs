/// <summary>
/// 20240531
/// https://leetcode.cn/problems/find-missing-and-repeated-values/
/// </summary>
public class Solution
{
    public int[] FindMissingAndRepeatedValues(int[][] grid)
    {
        var res = new int[2];
        var dict = new int[grid.Length * grid.Length + 1];
        Array.Fill(dict, 0);
        for (int j = 0; j < grid.Length; j++)
        {
            for (int k = 0; k < grid[j].Length; k++)
            {
                dict[grid[j][k]]++;
            }
        }
        for (int i = 1; i < dict.Length; i++)
        {
            if (dict[i] == 0)
            {
                res[1] = i;
            }
            if (dict[i] == 2)
            {
                res[0] = i;
            }
        }

        return res;
    }
}
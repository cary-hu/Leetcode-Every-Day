/// <summary>
/// 20221217
/// https://leetcode.cn/problems/form-array-by-concatenating-subarrays-of-another-array/
/// </summary>
public class Solution
{
    public bool CanChoose(int[][] groups, int[] nums)
    {
        int i = 0;
        for (int k = 0; k < nums.Length && i < groups.Length;)
        {
            if (Check(groups[i], nums, k))
            {
                k += groups[i].Length;
                i++;
            }
            else
            {
                k++;
            }
        }
        return i == groups.Length;
    }

    public bool Check(int[] g, int[] nums, int k)
    {
        if (k + g.Length > nums.Length)
        {
            return false;
        }
        for (int j = 0; j < g.Length; j++)
        {
            if (g[j] != nums[k + j])
            {
                return false;
            }
        }
        return true;
    }
}
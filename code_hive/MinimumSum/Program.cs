/// <summary>
/// 20240329
/// https://leetcode.cn/problems/minimum-sum-of-mountain-triplets-i/
/// </summary>
public class Solution
{
    public int MinimumSum(int[] nums)
    {
        int sum = int.MaxValue;
        int n = nums.Length;

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                for (int k = j + 1; k < n; k++)
                {
                    if (nums[i] < nums[j] && nums[k] < nums[j])
                    {
                        sum = Math.Min(sum, nums[i] + nums[j] + nums[k]);
                    }
                }
            }
        }
        return sum == int.MaxValue ? -1 : sum;
    }
}
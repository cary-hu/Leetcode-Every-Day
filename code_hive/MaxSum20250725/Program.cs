/// <summary>
/// 20250725
/// https://leetcode.cn/problems/maximum-unique-subarray-sum-after-deletion/
/// </summary>
public class Solution
{
    public int MaxSum(int[] nums)
    {
        var allNums = nums.Where(x => x > 0);
        if (allNums.Any())
        {
            return allNums.Distinct().Sum();
        }
        else
        {
            return nums.Max();
        }
    }
    private int maxSubarraySum(int[] arr)
    {
        int res = arr[0];

        for (int i = 0; i < arr.Length; i++)
        {
            int currSum = 0;

            for (int j = i; j < arr.Length; j++)
            {
                currSum = currSum + arr[j];

                res = Math.Max(res, currSum);
            }
        }
        return res;
    }
}
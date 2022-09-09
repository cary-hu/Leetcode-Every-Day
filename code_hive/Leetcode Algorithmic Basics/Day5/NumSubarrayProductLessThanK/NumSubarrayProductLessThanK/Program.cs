/// <summary>
/// 20220909
/// https://leetcode.cn/problems/subarray-product-less-than-k/
/// </summary>
public class Solution
{
    public int NumSubarrayProductLessThanK(int[] nums, int k)
    {
        int n = nums.Length, res = 0;
        int prod = 1, i = 0;
        for (int j = 0; j < n; j++)
        {
            prod *= nums[j];
            while (i <= j && prod >= k)
            {
                prod /= nums[i];
                i++;
            }
            res += j - i + 1;
        }
        return res;
    }
}
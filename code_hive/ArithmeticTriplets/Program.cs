/// <summary>
/// 20230331
/// https://leetcode.cn/problems/number-of-arithmetic-triplets/
/// </summary>
public class Solution
{
    public int ArithmeticTriplets(int[] nums, int diff)
    {
        int res = 0;
        for (int i = 2; i < nums.Length; i++)
        {
            if (Array.IndexOf(nums, nums[i] - diff) != -1 && Array.IndexOf(nums, nums[i] - diff * 2) != -1)
                res++;
        }
        return res;
    }
}
/// <summary>
/// 20220916
/// https://leetcode.cn/problems/house-robber-ii/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public int Rob(int[] nums)
    {
        int n = nums.Length;
        if(n == 1)
        {
            return nums[0];
        } else if(n == 2)
        {
            return Math.Max(nums[0], nums[1]);
        }
        return Math.Max(RobRange(nums, 0, n - 2), RobRange(nums, 1, n - 1));
    }
    private int RobRange(int[] nums, int start, int end)
    {
        int first = nums[start], second = Math.Max(nums[start], nums[start + 1]);
        for (int i = start + 2; i <= end; i++)
        {
            int temp = second;
            second = Math.Max(first + nums[i], second);
            first = temp;
        }
        return second;
    }
}
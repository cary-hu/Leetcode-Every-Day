/// <summary>
/// 20221116
/// https://leetcode.cn/problems/global-and-local-inversions/
/// </summary>
public class Solution
{
    public bool IsIdealPermutation(int[] nums)
    {
        int max = nums[0];
        for (int i = 2; i < nums.Length; i++)
        {
            if (nums[i] < max) { return false; }
            max = Math.Max(max, nums[i - 1]);
        }
        return true;
    }
}
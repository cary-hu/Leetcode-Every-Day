/// <summary>
/// 20220916
/// https://leetcode.cn/problems/jump-game/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public bool CanJump(int[] nums)
    {
        int k = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (i > k) return false;
            k = Math.Max(k, i + nums[i]);
        }
        return true;
    }
}
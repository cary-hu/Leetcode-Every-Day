/// <summary>
/// 20220917
/// https://leetcode.cn/problems/jump-game-ii/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public int Jump(int[] nums)
    {
        int ans = 0;
        int end = 0;
        int maxPos = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            maxPos = Math.Max(nums[i] + i, maxPos);
            if (i == end)
            {
                end = maxPos;
                ans++;
            }
        }
        return ans;
    }
}
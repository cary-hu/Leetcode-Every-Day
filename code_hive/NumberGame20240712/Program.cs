﻿/// <summary>
/// 20240712
/// https://leetcode.cn/problems/minimum-number-game/
/// </summary>
public class Solution
{
    public int[] NumberGame(int[] nums)
    {
        Array.Sort(nums);
        for (int i = 0; i < nums.Length; i += 2)
        {
            (nums[i], nums[i + 1]) = (nums[i + 1], nums[i]);
        }
        return nums;
    }
}
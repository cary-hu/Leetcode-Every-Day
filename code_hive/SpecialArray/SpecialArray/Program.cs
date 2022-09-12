/// <summary>
/// 20220912
/// https://leetcode.cn/problems/special-array-with-x-elements-greater-than-or-equal-x/
/// </summary>
public class Solution
{
    public int SpecialArray(int[] nums)
    {
        Array.Sort(nums);
        var res = -1;
        for (int i = 0; i < nums[^1] + 1; i++)
        {
            if (nums.Where(x => x >= i).Count() == i)
            {
                res = i;
            }
        }
        return res;
    }
}
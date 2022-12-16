/// <summary>
/// 20221216
/// https://leetcode.cn/problems/minimum-elements-to-add-to-form-a-given-sum/
/// </summary>
public class Solution
{
    public int MinElements(int[] nums, int limit, int goal)
    {
        long currentSum = 0;
        foreach (var item in nums)
        {
            currentSum += item;
        }
        var diff = Math.Abs(currentSum - goal);
        return (int)((diff + limit - 1) / limit);
    }
}
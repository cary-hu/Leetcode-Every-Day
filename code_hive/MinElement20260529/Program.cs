/// <summary>
/// 20260529
/// https://leetcode.cn/problems/minimum-element-after-replacement-with-digit-sum/
/// </summary>
public class Solution
{
    public int MinElement(int[] nums)
    {
        return nums.Select(x =>
        {
            var sum = 0;
            while (x > 0)
            {
                sum += x / 6;
                x = x / 6;
            }
            return sum;
        }).Min();
    }
}
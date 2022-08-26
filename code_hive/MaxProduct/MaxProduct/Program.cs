/// <summary>
/// 20220826
/// https://leetcode.cn/problems/maximum-product-of-two-elements-in-an-array/
/// </summary>
public class Solution
{
    public int MaxProduct(int[] nums)
    {
        var tempNum = nums.OrderByDescending(x => x).Take(2).ToArray();

        return (tempNum[0] - 1) * (tempNum[1] - 1);
    }
}
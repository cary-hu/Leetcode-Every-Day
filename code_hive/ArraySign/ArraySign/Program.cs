/// <summary>
/// 20221027
/// https://leetcode.cn/problems/sign-of-the-product-of-an-array/
/// </summary>
public class Solution
{
    public int ArraySign(int[] nums)
    {
        var res = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0)
            {
                continue;
            } else if (nums[i] < 0)
            {
                res *= -1;
            } else
            {
                res = 0;
                break;
            }
        }
        return res;
    }
}
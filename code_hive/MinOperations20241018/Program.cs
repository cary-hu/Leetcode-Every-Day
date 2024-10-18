/// <summary>
/// 20241018
/// https://leetcode.cn/problems/minimum-operations-to-make-binary-array-elements-equal-to-one-i/
/// https://leetcode.cn/problems/minimum-operations-to-make-binary-array-elements-equal-to-one-ii/
/// </summary>
public class Solution
{
    public int MinOperations(int[] nums)
    {
        var res = 0;
        var n = nums.Length;
        for (int i = 0; i < n - 2; i++)
        {
            if (nums[i] == 0)
            {
                nums[i + 1] = nums[i + 1] == 0 ? 1 : 0;
                nums[i + 2] = nums[i + 2] == 0 ? 1 : 0;
                res++;
            }
        }
        return nums[n - 1] == 1 && nums[n - 2] == 1 ? res : -1; ;
    }
    public int MinOperations2(int[] nums)
    {
        int result = 0;
        for (int index = nums.Length - 2; index >= 0; index--)
        {
            if (nums[index] != nums[index + 1])
            {
                result++;
            }
        }
        return result + 1 - nums[0];
    }
}
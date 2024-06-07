/// <summary>
/// 20240607
/// https://leetcode.cn/problems/maximum-number-of-operations-with-the-same-score-i/
/// </summary>
/// 
new Solution().MaxOperations([3, 2, 1, 4, 1]);
public class Solution
{
    public int MaxOperations(int[] nums)
    {
        var target = nums[0] + nums[1];
        var res = 1;
        for (int i = 2; i < nums.Length - 1; i += 2)
        {
            if (nums[i] + nums[i + 1] == target)
            {
                res++;
            }
            else
            {
                break;
            }
        }

        return res;
    }
}
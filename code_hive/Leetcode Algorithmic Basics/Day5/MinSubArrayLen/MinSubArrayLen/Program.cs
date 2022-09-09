/// <summary>
/// 20220909
/// https://leetcode.cn/problems/minimum-size-subarray-sum/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public int MinSubArrayLen(int target, int[] nums)
    {
        var res = int.MaxValue;
        var start = 0;
        var end = 0;
        var sum = 0;
        while (end < nums.Length)
        {
            sum += nums[end];
            while(sum >= target)
            {
                res = Math.Min(res, end - start + 1);
                sum -= nums[start];
                start++;
            }
            end++;
        }
       
        if (res == int.MaxValue)
        {
            return 0;
        }
        return res;
    }
}
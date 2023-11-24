/// <summary>
/// 20231124
/// https://leetcode.cn/problems/count-pairs-whose-sum-is-less-than-target/
/// </summary>
public class Solution
{
    public int CountPairs(IList<int> nums, int target)
    {
        var res = 0;
        var n = nums.Count;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i < j && j < n && nums[i] + nums[j] < target)
                {
                    res++;
                }
            }
        }
        return res;
    }
}
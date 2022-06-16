/// <summary>
/// 20220616
/// https://leetcode.cn/problems/k-diff-pairs-in-an-array/
/// </summary>
public class Solution
{
    public int FindPairs(int[] nums, int k)
    {
        Array.Sort(nums);
        int n = nums.Length, cnt = 0;
        var dict = new Dictionary<(int x, int y), int>();
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (nums[j] - nums[i] == k)
                {
                    dict[(nums[i], nums[j])] = 1;
                }
                if (nums[j] - nums[i] > k)
                {
                    break;
                }
            }
        }
        return dict.Count();
    }        
}
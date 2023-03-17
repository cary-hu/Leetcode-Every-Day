/// <summary>
/// 20230317
/// https://leetcode.cn/problems/longest-subsequence-with-limited-sum/
/// </summary>
public class Solution
{
    private int Sum { get; set; }
    public int[] AnswerQueries(int[] nums, int[] queries)
    {
        var res = new int[queries.Length];
        nums = nums.OrderBy(x => x).ToArray();
        Sum = nums.Sum();
        for (int i = 0; i < queries.Length; i++)
        {
            res[i] = AnswerQuery(nums, queries[i]);
        }
        return res;
    }

    public int AnswerQuery(int[] nums, int query)
    {
        if (Sum <= query)
        {
            return nums.Length;
        }
        var sum = 0;
        var index = -1;
        while(sum <= query)
        {
            index++;
            sum += nums[index];
        }
        return index == -1 ? 0 : index;
    }
}
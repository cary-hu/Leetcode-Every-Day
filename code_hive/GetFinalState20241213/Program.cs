/// <summary>
/// 20241213
/// https://leetcode.cn/problems/final-array-state-after-k-multiplication-operations-i/
/// </summary>
public class Solution
{
    public int[] GetFinalState(int[] nums, int k, int multiplier)
    {
        var q = new PriorityQueue<(int, int), (int, int)>(Comparer<(int, int)>.Create((a, b) =>
        {
            if (a.Item2 == b.Item2)
            {
                return a.Item1 - b.Item1;
            }
            return a.Item2 - b.Item2;
        }));
        for (int i = 0; i < nums.Length; i++)
        {
            q.Enqueue((i, nums[i]), (i, nums[i]));
        }
        for (int i = 0; i < k; i++)
        {
            var qItem = q.Dequeue();
            var a = qItem.Item1;
            var item = nums[a];
            nums[a] = item << multiplier;
            q.Enqueue((a, nums[a]), (a, nums[a]));
        }
        return nums;
    }
}
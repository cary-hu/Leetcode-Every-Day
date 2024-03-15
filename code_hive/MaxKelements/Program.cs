/// <summary>
/// 20240315
/// https://leetcode.cn/problems/maximal-score-after-applying-k-operations/
/// </summary>
public class Solution
{
    public long MaxKelements(int[] nums, int k)
    {
        var res = 0L;
        var queue = new PriorityQueue<int, int>();
        foreach (var item in nums)
        {
            queue.Enqueue(item, -item);
        }
        while (k > 0)
        {
            var item = queue.Dequeue();
            res += item;
            queue.Enqueue((int)Math.Ceiling(item / 3m), -(int)Math.Ceiling(item / 3m));
            k--;
        }

        return res;
    }
}
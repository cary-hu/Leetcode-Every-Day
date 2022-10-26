/// <summary>
/// 20221026
/// https://leetcode.cn/problems/shortest-subarray-with-sum-at-least-k/
/// </summary>
public class Solution
{
    public int ShortestSubarray(int[] nums, int k)
    {
        int n = nums.Length;
        long[] sums = new long[n + 1];
        for (int i = 1; i <= n; i++)
        {
            sums[i] = sums[i - 1] + nums[i - 1];
        }
        LinkedList<int> list = new LinkedList<int>();
        list.AddFirst(0);
        int ans = -1;
        for (int i = 1; i <= n; i++)
        {
            long pre = sums[i];
            LinkedListNode<int> node = list.First;
            while (node != null && pre - sums[node.Value] >= k)
            {
                if (ans == -1) ans = i - node.Value;
                else ans = Math.Min(ans, i - node.Value);
                list.RemoveFirst();
                node = list.First;
            }
            node = list.Last;
            while (node != null && pre <= sums[node.Value])
            {
                list.RemoveLast();
                node = list.Last;
            }
            list.AddLast(i);
        }
        return ans;

    }
}
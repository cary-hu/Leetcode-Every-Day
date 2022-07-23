/// <summary>
/// 20220723
/// https://leetcode.cn/problems/ur2n8P/
/// https://leetcode-cn.com/problems/sequence-reconstruction/
/// </summary>
public class Solution
{
    public bool SequenceReconstruction(int[] nums, int[][] sequences)
    {
        int n = nums.Length;
        int[] indegrees = new int[n + 1];
        ISet<int>[] graph = new ISet<int>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            graph[i] = new HashSet<int>();
        }
        foreach (int[] sequence in sequences)
        {
            int size = sequence.Length;
            for (int i = 1; i < size; i++)
            {
                int prev = sequence[i - 1], next = sequence[i];
                if (graph[prev].Add(next))
                {
                    indegrees[next]++;
                }
            }
        }
        Queue<int> queue = new Queue<int>();
        for (int i = 1; i <= n; i++)
        {
            if (indegrees[i] == 0)
            {
                queue.Enqueue(i);
            }
        }
        while (queue.Count > 0)
        {
            if (queue.Count > 1)
            {
                return false;
            }
            int num = queue.Dequeue();
            ISet<int> set = graph[num];
            foreach (int next in set)
            {
                indegrees[next]--;
                if (indegrees[next] == 0)
                {
                    queue.Enqueue(next);
                }
            }
        }
        return true;
    }
}
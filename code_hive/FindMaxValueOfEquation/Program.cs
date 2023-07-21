/// <summary>
/// 20230721
/// https://leetcode.cn/problems/max-value-of-equation/
/// </summary>
/// 
new Solution().FindMaxValueOfEquation(new int[][] { new int[] { 1, 3 }, new int[] { 2, 0 }, new int[] { 5, 10 }, new int[] { 6, -10 } }, 1);
public class Solution
{
    public int FindMaxValueOfEquation(int[][] points, int k)
    {
        var res = int.MinValue;
        var heap = new PriorityQueue<int[], int>();
        foreach (int[] point in points)
        {
            int x = point[0], y = point[1];
            while (heap.Count > 0 && x - heap.Peek()[1] > k)
            {
                heap.Dequeue();
            }
            if (heap.Count > 0)
            {
                res = Math.Max(res, x + y - heap.Peek()[0]);
            }
            heap.Enqueue(new int[] { x - y, x }, x - y);
        }
        return res;
    }
}
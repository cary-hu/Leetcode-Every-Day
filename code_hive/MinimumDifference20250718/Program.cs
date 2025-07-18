/// <summary>
/// 20250718
/// https://leetcode.cn/problems/minimum-difference-in-sums-after-removal-of-elements/
/// </summary>
public class Solution
{
    public long MinimumDifference(int[] nums)
    {
        var n = nums.Length / 3;
        var left = new long[n + 1];
        var sumLeft = 0L;
        var qLeft = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        for (int i = 0; i < n; ++i)
        {
            sumLeft += nums[i];
            qLeft.Enqueue(nums[i], nums[i]);
        }
        left[0] = sumLeft;
        for (int i = n; i < n * 2; ++i)
        {
            sumLeft += nums[i];
            qLeft.Enqueue(nums[i], nums[i]);
            sumLeft -= qLeft.Dequeue();
            left[i - (n - 1)] = sumLeft;
        }

        long sumRight = 0;
        var qr = new PriorityQueue<int, int>();
        for (int i = n * 3 - 1; i >= n * 2; --i)
        {
            sumRight += nums[i];
            qr.Enqueue(nums[i], nums[i]);
        }
        long ans = left[n] - sumRight;
        for (int i = n * 2 - 1; i >= n; --i)
        {
            sumRight += nums[i];
            qr.Enqueue(nums[i], nums[i]);
            sumRight -= qr.Dequeue();
            ans = Math.Min(ans, left[i - n] - sumRight);
        }
        return ans;
    }
}
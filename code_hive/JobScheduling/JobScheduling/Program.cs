/// <summary>
/// 20221022
/// https://leetcode.cn/problems/maximum-profit-in-job-scheduling/comments/
/// </summary>
public class Solution
{
    public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
    {
        int n = startTime.Length;
        int[][] jobs = new int[n][];
        for (int i = 0; i < n; i++)
        {
            jobs[i] = new int[] { startTime[i], endTime[i], profit[i] };
        }
        Array.Sort(jobs, (a, b) => a[1] - b[1]);
        int[] dp = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            int k = BinarySearch(jobs, i - 1, jobs[i - 1][0]);
            dp[i] = Math.Max(dp[i - 1], dp[k] + jobs[i - 1][2]);
        }
        return dp[n];
    }
    private int BinarySearch(int[][] jobs, int right, int target)
    {
        int left = 0;
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (jobs[mid][1] > target)
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }
        return left;
    }
}
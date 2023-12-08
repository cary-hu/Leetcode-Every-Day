/// <summary>
/// 20231208
/// https://leetcode.cn/problems/maximum-earnings-from-taxi/
/// </summary>
public class Solution
{
    public long MaxTaxiEarnings(int n, int[][] rides)
    {
        Array.Sort(rides, (a, b) => a[1] - b[1]);
        int m = rides.Length;
        long[] dp = new long[m + 1];
        for (int i = 0; i < m; i++)
        {
            int j = BinarySearch(rides, i, rides[i][0]);
            dp[i + 1] = Math.Max(dp[i], dp[j] + GetMoney(rides[i]));
        }
        return dp[m];
    }
    public int BinarySearch(int[][] rides, int high, int target)
    {
        int low = 0;
        while (low < high)
        {
            int mid = low + (high - low) / 2;
            if (rides[mid][1] > target)
            {
                high = mid;
            }
            else
            {
                low = mid + 1;
            }
        }
        return low;
    }
    private long GetMoney(int[] ride)
    {
        return ride[1] - ride[0] + ride[2];
    }
}
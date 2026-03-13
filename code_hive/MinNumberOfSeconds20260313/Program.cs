public class Solution
{
    public long MinNumberOfSeconds(int mountainHeight, int[] workerTimes)
    {
        int maxWorkerTimes = workerTimes.Max();

        long l = 1;
        long r = (long)maxWorkerTimes * mountainHeight * (mountainHeight + 1) / 2;
        long ans = 0;

        while (l <= r)
        {
            long mid = (l + r) / 2;
            if (Check(mountainHeight, workerTimes, mid))
            {
                ans = mid;
                r = mid - 1;
            }
            else
            {
                l = mid + 1;
            }
        }

        return ans;
    }

    private bool Check(int mountainHeight, int[] workerTimes, long mid)
    {
        long cnt = 0;

        foreach (int t in workerTimes)
        {
            long work = mid / t;
            long k = (long)((-1.0 + Math.Sqrt(1 + work * 8)) / 2);
            cnt += k;
        }
        if (cnt >= mountainHeight)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
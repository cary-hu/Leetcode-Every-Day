/// <summary>
/// 20240308
/// https://leetcode.cn/problems/find-the-minimum-possible-sum-of-a-beautiful-array/
/// </summary>
public class Solution
{
    public int MinimumPossibleSum(int n, int target)
    {
        long limit = (target) / 2;
        if (n <= limit)
        {
            return (1 + n) * n / 2 % 1000000007;
        }
        else
        {
            var sum1 = (1 + limit) * limit / 2;
            var sum2 = (target + target + n - limit - 1) * (n - limit) / 2;
            return (int)((sum1 + sum2) % 1000000007);
        }
    }
}
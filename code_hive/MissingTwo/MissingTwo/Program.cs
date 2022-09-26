/// <summary>
/// 20220926
/// https://leetcode.cn/problems/missing-two-lcci/
/// </summary>
public class Solution
{
    public int[] MissingTwo(int[] nums)
    {
        int n = nums.Length + 2;
        int sum = 0;
        foreach (int i in nums) sum += i;
        int ts = (1 + n) * n / 2 - sum;
        int m = ts / 2;

        sum = 0;
        foreach (int i in nums)
        {
            if (i <= m) sum += i;
        }
        int res = (1 + m) * m / 2 - sum;
        return new int[] { res, ts - res };
    }
}
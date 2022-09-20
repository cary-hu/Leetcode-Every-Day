/// <summary>
/// 20220920
/// https://leetcode.cn/problems/partition-to-k-equal-sum-subsets/
/// </summary>
public class Solution
{
    int[] nums;
    int per, n;
    bool[] dp;

    public bool CanPartitionKSubsets(int[] nums, int k)
    {
        this.nums = nums;
        int all = nums.Sum();
        if (all % k != 0)
        {
            return false;
        }
        per = all / k;
        Array.Sort(nums);
        n = nums.Length;
        if (nums[n - 1] > per)
        {
            return false;
        }
        dp = new bool[1 << n];
        Array.Fill(dp, true);
        return DFS((1 << n) - 1, 0);
    }

    public bool DFS(int s, int p)
    {
        if (s == 0)
        {
            return true;
        }
        if (!dp[s])
        {
            return dp[s];
        }
        dp[s] = false;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] + p > per)
            {
                break;
            }
            if (((s >> i) & 1) != 0)
            {
                if (DFS(s ^ (1 << i), (p + nums[i]) % per))
                {
                    return true;
                }
            }
        }
        return false;
    }
}
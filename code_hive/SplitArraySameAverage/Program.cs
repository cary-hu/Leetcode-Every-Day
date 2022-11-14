/// <summary>
/// 20221114
/// https://leetcode.cn/problems/split-array-with-same-average/description/
/// </summary>
public class Solution
{
    public bool SplitArraySameAverage(int[] nums)
    {
        if (nums.Length == 1)
        {
            return false;
        }
        int n = nums.Length, m = n / 2;
        int sum = 0;
        foreach (int num in nums)
        {
            sum += num;
        }
        for (int i = 0; i < n; i++)
        {
            nums[i] = nums[i] * n - sum;
        }

        ISet<int> left = new HashSet<int>();
        for (int i = 1; i < (1 << m); i++)
        {
            int tot = 0;
            for (int j = 0; j < m; j++)
            {
                if ((i & (1 << j)) != 0)
                {
                    tot += nums[j];
                }
            }
            if (tot == 0)
            {
                return true;
            }
            left.Add(tot);
        }
        int rsum = 0;
        for (int i = m; i < n; i++)
        {
            rsum += nums[i];
        }
        for (int i = 1; i < (1 << (n - m)); i++)
        {
            int tot = 0;
            for (int j = m; j < n; j++)
            {
                if ((i & (1 << (j - m))) != 0)
                {
                    tot += nums[j];
                }
            }
            if (tot == 0 || (rsum != tot && left.Contains(-tot)))
            {
                return true;
            }
        }
        return false;
    }
}
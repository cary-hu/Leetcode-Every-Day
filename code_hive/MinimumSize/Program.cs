/// <summary>
/// 20221220
/// https://leetcode.cn/problems/minimum-limit-of-balls-in-a-bag/
/// </summary>
public class Solution
{
    public int MinimumSize(int[] nums, int maxOperations)
    {
        int left = 1, right = nums.Max();
        int ans = 0;
        while (left <= right)
        {
            int y = (left + right) / 2;
            long ops = 0;
            foreach (int x in nums)
            {
                ops += (x - 1) / y;
            }
            if (ops <= maxOperations)
            {
                ans = y;
                right = y - 1;
            }
            else
            {
                left = y + 1;
            }
        }
        return ans;
    }
}
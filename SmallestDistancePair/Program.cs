/// <summary>
/// 20220615
/// https://leetcode.cn/problems/find-k-th-smallest-pair-distance/
/// </summary>
public class Solution
{
    public int SmallestDistancePair(int[] nums, int k)
    {
        Array.Sort(nums);
        int n = nums.Length, left = 0, right = nums[n - 1] - nums[0];
        while (left <= right)
        {
            int mid = (left + right) / 2;
            int cnt = 0;
            for (int i = 0, j = 0; j < n; j++)
            {
                while (nums[j] - nums[i] > mid)
                {
                    i++;
                }
                cnt += j - i;
            }
            if (cnt >= k)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
        return left;


    }
}
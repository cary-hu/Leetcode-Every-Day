/// <summary>
/// 20250926
/// https://leetcode.cn/problems/valid-triangle-number/description/
/// </summary>
public class Solution
{
    public int TriangleNumber(int[] nums)
    {
        Array.Sort(nums);
        int count = 0;
        for (int i = nums.Length - 1; i >= 2; i--)
        {
            int left = 0, right = i - 1;
            while (left < right)
            {
                if (nums[left] + nums[right] > nums[i])
                {
                    count += right - left;
                    right--;
                }
                else
                {
                    left++;
                }
            }
        }
        return count;
    }
}
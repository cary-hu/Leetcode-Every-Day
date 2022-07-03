var a = new Solution();
a.NextGreaterElement(new int[] { 4, 1, 2 }, new int[] { 1, 3, 4, 2 });
/// <summary>
/// 20220703
/// https://leetcode.cn/problems/next-greater-element-iii/
/// </summary>
public class Solution
{
    public int NextGreaterElement(int num)
    {
        char[] nums = n.ToString().ToCharArray();
        int i = nums.Length - 2;
        while (i >= 0 && nums[i] >= nums[i + 1])
        {
            i--;
        }
        if (i < 0)
        {
            return -1;
        }

        int j = nums.Length - 1;
        while (j >= 0 && nums[i] >= nums[j])
        {
            j--;
        }
        Swap(nums, i, j);
        Reverse(nums, i + 1);
        long ans = long.Parse(new string(nums));
        return ans > int.MaxValue ? -1 : (int)ans;
    }

    private void Reverse(char[] nums, int begin)
    {
        int i = begin, j = nums.Length - 1;
        while (i < j)
        {
            Swap(nums, i, j);
            i++;
            j--;
        }
    }

    private void Swap(char[] nums, int i, int j)
    {
        char temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
    public int[] NextGreaterElements(int[] nums)
    {
        int n = nums.Length;
        int[] res = new int[n];
        Array.Fill(res, -1);
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < n * 2; ++i)
        {
            while (stack.Count > 0 && nums[stack.Peek()] < nums[i % n])
            {
                res[stack.Pop()] = nums[i % n];
            }
            stack.Push(i % n);
        }
        return res;
    }
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        int m = nums1.Length, n = nums2.Length;
        int[] res = new int[m];
        for (int i = 0; i < m; ++i)
        {
            int j = 0;
            while (j < n && nums2[j] != nums1[i])
            {
                ++j;
            }
            int k = j + 1;
            while (k < n && nums2[k] < nums2[j])
            {
                ++k;
            }
            res[i] = k < n ? nums2[k] : -1;
        }
        return res;
    }
}
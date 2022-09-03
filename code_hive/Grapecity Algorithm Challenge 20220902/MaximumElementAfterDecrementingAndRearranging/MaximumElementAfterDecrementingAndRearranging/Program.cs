/// <summary>
/// 20220902
/// https://leetcode.cn/problems/maximum-element-after-decreasing-and-rearranging/
/// </summary>
public class Solution
{
    public int MaximumElementAfterDecrementingAndRearranging(int[] arr)
    {
        Array.Sort(arr);
        arr[0] = 1;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] - arr[i - 1] >= 1)
            {
                arr[i] = arr[i - 1] + 1;
            }
        }
        return arr[^1];
    }
}
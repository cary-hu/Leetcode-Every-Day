/// <summary>
/// 20220824
/// https://leetcode.cn/problems/make-two-arrays-equal-by-reversing-sub-arrays/
/// </summary>
public class Solution
{
    public bool CanBeEqual(int[] target, int[] arr)
    {
        if (target.Length != arr.Length)
        {
            return false;
        }
        Array.Sort(target);
        Array.Sort(arr);
        return target.SequenceEqual(arr);
    }
}
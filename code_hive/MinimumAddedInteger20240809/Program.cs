/// <summary>
/// 20240809
/// https://leetcode.cn/problems/find-the-integer-added-to-array-ii/
/// </summary>
public class Solution
{
    public int MinimumAddedInteger(int[] nums1, int[] nums2)
    {
        var res = int.MaxValue;
        var minNums2 = nums2.Min();
        Array.Sort(nums1);
        Array.Sort(nums2);
        for (int i = 0; i < nums1.Length - 1; i++)
        {
            for (int j = i + 1; j < nums1.Length; j++)
            {
                var removeElementsArray = nums1.Where((x, index) => index != i && index != j).ToArray();
                var x = minNums2 - removeElementsArray.Min();
                removeElementsArray = removeElementsArray.Select(y => y + x).ToArray();
                if (Enumerable.SequenceEqual(removeElementsArray, nums2))
                {
                    res = Math.Min(res, x);
                }
            }
        }
        return res;
    }
}
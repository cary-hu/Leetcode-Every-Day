/// <summary>
/// 20221229
/// https://leetcode.cn/problems/two-out-of-three/
/// </summary>
public class Solution
{
    public IList<int> TwoOutOfThree(int[] nums1, int[] nums2, int[] nums3)
    {
        var dict = new Dictionary<int, int>();
        foreach (var item in nums1.Distinct())
        {
            if (dict.ContainsKey(item))
            {
                dict[item]++;
            }
            else
            {
                dict.Add(item, 1);
            }
        }
        foreach (var item in nums2.Distinct())
        {
            if (dict.ContainsKey(item))
            {
                dict[item]++;
            }
            else
            {
                dict.Add(item, 1);
            }
        }
        foreach (var item in nums3.Distinct())
        {
            if (dict.ContainsKey(item))
            {
                dict[item]++;
            }
            else
            {
                dict.Add(item, 1);
            }
        }
        return dict.Where(x => x.Value >= 2).Select(x => x.Key).ToList();
    }
}
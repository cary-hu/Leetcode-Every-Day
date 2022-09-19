/// <summary>
/// 20220919
/// https://leetcode.cn/problems/sort-array-by-increasing-frequency/
/// </summary>
public class Solution
{
    public int[] FrequencySort(int[] nums)
    {
        var dict = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            dict.TryAdd(num, 0);
            dict[num]++;
        }
        List<int> list = new List<int>();
        foreach (int num in nums)
        {
            list.Add(num);
        }
        list.Sort((a, b) => {
            int cnt1 = dict[a], cnt2 = dict[b];
            return cnt1 != cnt2 ? cnt1 - cnt2 : b - a;
        });
        return list.ToArray();
    }
}
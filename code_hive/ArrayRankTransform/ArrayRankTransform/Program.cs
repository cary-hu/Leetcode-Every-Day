var a = new Solution();
a.ArrayRankTransform(new int[] { 37, 12, 28, 9, 100, 56, 80, 5, 12 });
/// <summary>
/// 20220728
/// https://leetcode.cn/problems/rank-transform-of-an-array/
/// </summary>
public class Solution
{
    public int[] ArrayRankTransform(int[] arr)
    {
        var list = new int[arr.Length];
        Array.Copy(arr, list, arr.Length);
        Array.Sort(list);
        var dict = new Dictionary<int, int>();
        var index = 1;
        for (int i = 0; i < list.Length; i++)
        {
            if (dict.ContainsKey(list[i]))
            {
                continue;
            }
            dict.Add(list[i], index++);
        }
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = dict[arr[i]];
        }
        return arr;
    }
}
/// <summary>
/// 20221113
/// https://leetcode.cn/problems/custom-sort-string
/// </summary>
public class Solution
{
    public string CustomSortString(string order, string s)
    {
        var OrderDict = new int[26];
        Array.Fill(OrderDict, 0);
        for (int i = 0; i < order.Length; i++)
        {
            OrderDict[order[i] - 'a'] = i + 1;
        }
        var res = s.ToArray();
        Array.Sort(res, (a, b) =>OrderDict[a - 'a'] - OrderDict[b - 'a']);
        return new string(res);
    }
}
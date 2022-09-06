var a = new Solution();
a.UniqueLetterString("LEETCODE");
/// <summary>
/// 20220906
/// https://leetcode.cn/problems/count-unique-characters-of-all-substrings-of-a-given-string/
/// </summary>
public class Solution
{
    public int UniqueLetterString(string s)
    {
        var index = new Dictionary<char, IList<int>>();
        for (int i = 0; i < s.Length; i++)
        {
            if (!index.ContainsKey(s[i]))
            {
                index.Add(s[i], new List<int>());
                index[s[i]].Add(-1);
            }
            index[s[i]].Add(i);
        }
        int res = 0;
        foreach (KeyValuePair<char, IList<int>> pair in index)
        {
            IList<int> arr = pair.Value;
            arr.Add(s.Length);
            for (int i = 1; i < arr.Count - 1; i++)
            {
                res += (arr[i] - arr[i - 1]) * (arr[i + 1] - arr[i]);
            }
        }
        return res;
    }
}
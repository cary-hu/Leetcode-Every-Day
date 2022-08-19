/// <summary>
/// 20220806
/// https://leetcode.cn/problems/string-matching-in-an-array/
/// </summary>
public class Solution
{
    public IList<string> StringMatching(string[] words)
    {
        var res = new List<string>();
        foreach (var word in words)
        {
            for (int j = 0; j < words.Length; j++)
            {
                if (word == words[j] || words[j].Length > word.Length)
                {
                    continue;
                }
                if (word.Contains(words[j]))
                {
                    res.Add(words[j]);
                }
            }
        }
        return res.Distinct().ToList();
    }
}
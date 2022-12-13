/// <summary>
/// 20221213
/// https://leetcode.cn/problems/check-if-the-sentence-is-pangram/
/// </summary>
public class Solution
{
    public bool CheckIfPangram(string sentence)
    {
        var dict = new HashSet<char>();
        foreach (var charItem in sentence)
        {
            dict.Add(charItem);
        }
        return dict.Count == 26;
    }
}
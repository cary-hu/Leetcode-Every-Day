/// <summary>
/// 20220612
/// https://leetcode.cn/problems/find-and-replace-pattern/
/// </summary>
public class Solution
{
    public IList<string> FindAndReplacePattern(string[] words, string pattern)
    {
        IList<string> result = new List<string>();
        foreach (var word in words)
        {
            if (IsMatch(word, pattern))
            {
                result.Add(word);
            }
        }
        return result;
    }
    private bool IsMatch(string word, string pattern)
    {
        if (word.Length != pattern.Length)
        {
            return false;
        }
        Dictionary<char, char> dic = new Dictionary<char, char>();
        for (int i = 0; i < word.Length; i++)
        {
            if (dic.ContainsKey(word[i]))
            {
                if (dic[word[i]] != pattern[i])
                {
                    return false;
                }
            }
            else
            {
                if (dic.ContainsValue(pattern[i]))
                {
                    return false;
                }
                dic.Add(word[i], pattern[i]);
            }
        }
        return true;
    }
}
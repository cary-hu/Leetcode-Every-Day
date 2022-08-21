/// <summary>
/// 20220821
/// https://leetcode.cn/problems/check-if-a-word-occurs-as-a-prefix-of-any-word-in-a-sentence/
/// </summary>
public class Solution
{
    public int IsPrefixOfWord(string sentence, string searchWord)
    {
        var words = sentence.Split(" ");
        var res = -1;
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].StartsWith(searchWord))
            {
                res = i + 1;
                break;
            }
        }
        return res;
    }
}
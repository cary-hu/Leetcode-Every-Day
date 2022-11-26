/// <summary>
/// 20221125
/// https://leetcode.cn/problems/expressive-words/
/// </summary>
public class Solution
{
    public int ExpressiveWords(string s, string[] words)
    {
        var res = 0;

        foreach (var word in words)
        {
            if (CheckWords(s, word))
            {
                res++;
            }
        }
        return res;
    }
    private bool CheckWords(string s, string word)
    {
        int i = 0;
        int j = 0;
        while (i < s.Length && j < word.Length)
        {
            if (s[i] != word[j])
            {
                return false;
            }
            var c = s[i];
            var cnts = 0;
            while (i < s.Length && s[i] == c)
            {
                i++;
                cnts++;
            }
            int cntw = 0;
            while (j < word.Length && word[j] == c)
            {
                j++;
                cntw++;
            }
            if (cnts < cntw)
            {
                return false;
            }
            if (cnts > cntw && cnts < 3)
            {
                return false;
            }
        }
        return i == s.Length && j == word.Length;
    }
}
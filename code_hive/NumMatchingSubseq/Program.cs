/// <summary>
/// 20221117
/// https://leetcode.cn/problems/number-of-matching-subsequences
/// </summary>
public class Solution
{
    public int NumMatchingSubseq(string s, string[] words)
    {
        var res = 0;
        foreach (var word in words)
        {
            for (int i = 0, j = 0; i < word.Length;)
            {
                if (j >= s.Length)
                {
                    break;
                }
                if (word[i] == s[j])
                {
                    i++;
                    j++;
                    if (i == word.Length)
                    {
                        res++;
                    }
                    continue;
                }
                j++;
            }
        }
        return res;
    }
}
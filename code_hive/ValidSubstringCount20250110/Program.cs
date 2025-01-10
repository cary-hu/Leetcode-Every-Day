/// <summary>
/// 20250110
/// https://leetcode.cn/problems/count-substrings-that-can-be-rearranged-to-contain-a-string-ii/
/// </summary>
public class Solution
{
    public long ValidSubstringCount(string word1, string word2)
    {
        var res = 0L;
        var minLength = word2.Length;
        var word1Length = word1.Length;
        var charCount = new int[26];
        for (var k = 0; k < word2.Length; k++)
        {
            charCount[word2[k] - 'a']++;
        }
        var newCount = new int[26];
        int i = 0, j = 0;
        while (i < word1.Length - minLength + 1)
        {
            if (IsValid(charCount, newCount))
            {
                res += word1Length - j + 1;
                newCount[word1[i] - 'a']--;
                i++;
            }
            else
            {
                if (j >= word1.Length)
                {
                    i++;
                }
                else
                {
                    newCount[word1[j] - 'a']++;
                    j++;
                }
            }
        }

        return res;
    }
    private bool IsValid(int[] charCount, int[] newCount)
    {
        for (var i = 0; i < 26; i++)
        {
            if (charCount[i] > newCount[i])
            {
                return false;
            }
        }
        return true;
    }
}
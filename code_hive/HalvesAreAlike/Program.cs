/// <summary>
/// 20221111
/// https://leetcode.cn/problems/determine-if-string-halves-are-alike/
/// </summary>
public class Solution
{
    public bool HalvesAreAlike(string s)
    {
        var halfLength = s.Length / 2;
        var leftVowel = 0;
        var rightVowel = 0;
        for (int i = 0; i < halfLength; i++)
        {
            if (CheckIsVowel(s[i]))
            {
                leftVowel++;
            }
            if (CheckIsVowel(s[i + halfLength]))
            {
                rightVowel++;
            }
        }
        return leftVowel == rightVowel;
    }
    private bool CheckIsVowel(char c)
    {
        if (c == 'a')
        {
            return true;
        }
        if (c == 'e')
        {
            return true;
        }
        if (c == 'i')
        {
            return true;
        }
        if (c == 'o')
        {
            return true;
        }
        if (c == 'u')
        {
            return true;
        }
        if (c == 'A')
        {
            return true;
        }
        if (c == 'E')
        {
            return true;
        }
        if (c == 'I')
        {
            return true;
        }
        if (c == 'O')
        {
            return true;
        }
        if (c == 'U')
        {
            return true;
        }
        return false;
    }
}
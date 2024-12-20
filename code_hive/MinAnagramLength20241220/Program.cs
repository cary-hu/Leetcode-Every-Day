/// <summary>
/// 20241220
/// https://leetcode.cn/problems/minimum-length-of-anagram-concatenation/
/// </summary>
public class Solution
{
    public int GetHash(string s, int startIndex, int length)
    {
        int res = 0;
        for (int i = startIndex; i < startIndex + length; i++)
        {
            res += (s[i] - 'a' + 1) * (s[i] - 'a' + 1);
        }
        return res;
    }
    public int MinAnagramLength(string s)
    {
        var length = s.Length;
        for (var i = 1; i <= length; i++)
        {
            if (length % i != 0)
            {
                continue;
            }
            var subString = s[..i].ToString();
            var subStringHash = GetHash(subString, 0, i);
            var invalid = false;
            var currentIndex = i;
            for (int j = i + i; j <= length; j += i)
            {
                var newHash = GetHash(s, currentIndex, i);
                if (newHash != subStringHash)
                {
                    invalid = true;
                }
                currentIndex += i;
            }
            if (!invalid)
            {
                return i;
            }

        }
        return length;
    }
}
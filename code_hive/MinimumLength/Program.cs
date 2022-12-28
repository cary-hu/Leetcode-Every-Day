/// <summary>
/// 20221228
/// https://leetcode.cn/problems/minimum-length-of-string-after-deleting-similar-ends/
/// </summary>
public class Solution
{
    public int MinimumLength(string s)
    {
        var l = 0;
        var r = s.Length - 1;
        while (l < r && s[l] == s[r])
        {
            while(l <= r && s[l] == s[r])
            {
                l++;
            }

            while (l < r && s[l - 1] == s[r])
            {
                r--;
            }
        }
        return r - l + 1;
    }
}
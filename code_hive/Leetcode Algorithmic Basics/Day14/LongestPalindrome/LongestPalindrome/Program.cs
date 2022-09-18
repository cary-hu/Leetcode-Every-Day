/// <summary>
/// 20220918
/// https://leetcode.cn/problems/longest-palindromic-substring/
/// </summary>
public class Solution
{
    public string LongestPalindrome(string s)
    {
        var dp = new bool[s.Length][];
        for (int i = 0; i < s.Length; i++)
        {
            dp[i] = new bool[s.Length];
            Array.Fill(dp[i], false);
        }
        int maxLength = 0;
        int left = 0;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            for (int j = i; j < s.Length; j++)
            {
                if (s[i] == s[j] && (j - i <= 1 || dp[i + 1][j - 1]))
                {
                    dp[i][j] = true;
                }
                if (dp[i][j] && j - i + 1 > maxLength)
                {
                    maxLength = j - i + 1;
                    left = i;
                }
            }
        }
        return s.Substring(left, maxLength);
    }
}
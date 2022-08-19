/// <summary>
/// 20220611
/// https://leetcode.cn/problems/flip-string-to-monotone-increasing/
/// </summary>
var a = new Solution();
a.MinFlipsMonoIncr("00011000");
public class Solution
{
    public int MinFlipsMonoIncr(string s)
    {
        var dp = new int[s.Length][];
        dp[0] = new int[2];
        dp[0][0] = s[0] == '0' ? 0 : 1;
        dp[0][1] = s[0] == '1' ? 0 : 1;

        for (int i = 1; i < s.Length; i++)
        {
            char c = s[i];
            dp[i] = new int[2];

            if (c == '0')
            {
                dp[i][0] = dp[i - 1][0];
                dp[i][1] = Math.Min(dp[i - 1][0] , dp[i - 1][1]) + 1;
            }
            else
            {
                dp[i][0] = dp[i - 1][0] + 1;
                dp[i][1] = Math.Min(dp[i - 1][0], dp[i - 1][1]);
            }

        }
        return Math.Min(dp[s.Length - 1][0], dp[s.Length - 1][1]);
    }
}
/// <summary>
/// 20220919
/// https://leetcode.cn/problems/decode-ways/?plan=algorithms&plan_progress=zd0dlym
/// </summary>
public class Solution
{
    public int NumDecodings(string s)
    {
        int n = s.Length;
        int[] f = new int[n + 1];
        f[0] = 1;
        for (int i = 1; i <= n; ++i)
        {
            if (s[i - 1] != '0')
            {
                f[i] += f[i - 1];
            }
            if (i > 1 && s[i - 2] != '0' && ((s[i - 2] - '0') * 10 + (s[i - 1] - '0') <= 26))
            {
                f[i] += f[i - 2];
            }
        }
        return f[n];
    }
}